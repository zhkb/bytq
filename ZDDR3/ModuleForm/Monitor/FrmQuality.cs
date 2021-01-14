using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using ThoughtWorks.QRCode;

namespace Monitor
{

    using Sys.Config;
    using Sys.SysBusiness;
    using ControlLogic.BarCode;
    using ControlLogic.Control;
    using Sys.DbUtilities;
    using ThoughtWorks.QRCode.Codec;

    public partial class FrmQuality : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        //扫描枪变量
        private ScanProvider _scanner;
        private ScanProvider CheckScanner;

        private static string HisProductName = "";

        private static Socket QualitySocket; //返修socket
        private static IPEndPoint QualityPoint;//IP及端口信息

        private static bool BarScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        public static System.Threading.Timer CheckPlcStatusTimer; //重新连接PLC
        private static int BarReConnCount = 0;

        private SpeechSynthesizer speech = new SpeechSynthesizer();

        public FrmQuality()
        {
            InitializeComponent();
        }

        private void product_Load(object sender, EventArgs e)
        {
            panel1.Width = 960;
            panel19.Width = 675;
            panel23.Width = 675;
            panel10.Height = 280;
            panel15.Height = 280;
            // txt_StationName.Text = BaseSystemInfo.CurrentProcessName; //BaseSystemInfo.CurrentProcessCode
            txt_MsgInfo.Text = "请扫描条码......";
            txt_BarCode.Text = "";
            txt_MaterialName.Text = "";
            txt_MaterialCode.Text = "";
            txt_ProductResult.Text = "--";
            lbl_CheckTime.Text = "--";

            txt_BackMsgInfo.Text = "请扫描条码......";
            txt_BackBarCode.Text = "";
            txt_BackProductCode.Text = "";
            txt_BackProductName.Text = "";
            txt_BackProductResult.Text = "--";

            lbl_QualityTime.Text = "--";
            LoadDataForDGVProBar_Quality();
            LoadDataForDGVProBar_Check();

            //初始化PLC连接

            if (BaseSystemInfo.PLC_UseFlag)
            {
                ControlMaster.SystemInitialization();
            }

            // InitScanner();
            CreateBarScanSocket();
            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 包含PLC 条码
                                                                                                           //   CheckPlcStatusTimer = new System.Threading.Timer(CheckPLCConnectionStatus, null, 0, Timeout.Infinite);//PLC断线重连
        }

        private void InitScanner()
        {
            try
            {
                // 打开串口  
                _scanner = new ScanProvider(BaseSystemInfo.SerialPortName1, 9600);
                Task task = new Task(() =>
                {
                    // 打开串口  
                    if (_scanner.Open())
                        //关联事件处理程序  
                        _scanner.DataReceived += _scanner_DataReceived;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("终检条码枪连接出现异常.端口【{0}】波特率【{1}】，", BaseSystemInfo.SerialPortName1, 9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }

            //返修扫描
            try
            {
                // 打开串口  
                CheckScanner = new ScanProvider(BaseSystemInfo.SerialPortName2, 115200);
                Task task = new Task(() =>
                {
                    // 打开串口  
                    if (CheckScanner.Open())
                        //关联事件处理程序  
                        CheckScanner.DataReceived += CheckScanner_DataReceived;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("返修条码枪连接出现异常.端口【{0}】波特率【{1}】，", BaseSystemInfo.SerialPortName1, 9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
        }

        /// <summary>
        /// 接收扫码枪信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _scanner_DataReceived(object sender, SerialSortEventArgs e)
        {
            BeginInvoke(new Action<string>(args =>
            {
                OptionSetting.CurrentBarcode = args.Trim();
                //CurrentProductBarCode = OptionSetting.CurrentBarcode;
                txt_BarCode.Text = OptionSetting.CurrentBarcode;

                SysBusinessFunction.WriteLog("终检工位扫码记录：" + OptionSetting.CurrentBarcode);

                if (OptionSetting.CurrentBarcode.ToUpper() == "NOREAD")
                {
                    txt_MaterialCode.Text = "";
                    txt_MaterialName.Text = "";
                    txt_MsgInfo.Text = "条码扫描失败......";
                    txt_MsgInfo.ForeColor = Color.Red;
                    txt_ProductResult.Text = "无质检信息";
                    txt_ProductResult.ForeColor = Color.Red;
                    txt_MaterialName.Text = "";
                    speech.SpeakAsync("条码扫描失败");
                    return;
                }
                else if (OptionSetting.CurrentBarcode.Trim().Length != 20)
                {
                    txt_MsgInfo.Text = "扫描条码格式错误！";
                    txt_MsgInfo.ForeColor = Color.Red;
                    txt_ProductResult.Text = "无质检信息";
                    txt_ProductResult.ForeColor = Color.Red;
                    txt_MaterialCode.Text = "";
                    txt_MaterialName.Text = "";
                    speech.SpeakAsync("扫描条码格式错误");
                    return;
                }

                //查询物料信息
                string MaterialSQL = string.Format(@"SELECT  Prod_Desc,Prod_Code  
                                                     FROM view_product_info 
                                                     WHERE prod_code = '{0}'", OptionSetting.CurrentBarcode.Substring(0, 9));
                DataTable Dt = DataHelper.MySqlFill(MaterialSQL).Tables[0];

                if (Dt.Rows.Count > 0)
                {
                    txt_MaterialName.Text = Dt.Rows[0]["Prod_Desc"].ToString();
                    txt_MaterialCode.Text = Dt.Rows[0]["prod_code"].ToString();
                }
                else
                {
                    txt_MaterialName.Text = "";
                    txt_MaterialCode.Text = "";
                }
                //查询质检信息
                string sSQL = string.Format(@"SELECT  (CASE WHEN TestResult = 1 THEN 'OK' ELSE 'NG' END)  TestResult,DATE_FORMAT(TestTime,'%Y-%m-%d %k:%i:%S') TestTime
                                                      FROM bns_qm_performancetesting 
                                                      WHERE  WorkUser_BarCode = '{0}' 
                                                      Order By TestTime DESC ", OptionSetting.CurrentBarcode);
                DataTable RDt = DataHelper.MySqlFill(sSQL).Tables[0];

                if (RDt.Rows.Count > 0)
                {
                    txt_MsgInfo.Text = "产品信息查询正常......";
                    txt_MsgInfo.ForeColor = Color.Lime;

                    if ("OK".Equals(RDt.Rows[0]["TestResult"].ToString().Trim()))
                    {
                        txt_ProductResult.ForeColor = Color.Lime;
                        txt_ProductResult.Text = RDt.Rows[0]["TestResult"].ToString();
                        lbl_CheckTime.Text = RDt.Rows[0]["TestTime"].ToString();
                    }
                    else
                    {
                        txt_ProductResult.ForeColor = Color.Red;
                        txt_ProductResult.Text = RDt.Rows[0]["TestResult"].ToString();
                        lbl_CheckTime.Text = RDt.Rows[0]["TestTime"].ToString();
                    }
                }
                else
                {
                    txt_ProductResult.Text = "";
                    txt_ProductResult.ForeColor = Color.Red;
                    lbl_CheckTime.Text = "--";

                    txt_MsgInfo.Text = "该条码无质检结果......";
                    txt_MsgInfo.ForeColor = Color.Lime;
                }


                OptionSetting.CurrentMatercode = txt_MaterialCode.Text.ToString();
                OptionSetting.CurrentMaterName = txt_MaterialName.Text.ToString();

                //存储扫描信息

                if (OptionSetting.CurrentMatercode != "")
                {
                    string MaterialReslt = txt_ProductResult.Text.ToString();
                    DbParameter[] param0 = {
                              new SqlParameter("@CompanyCode",BaseSystemInfo.CompanyCode),
                              new SqlParameter("@CompanyName",BaseSystemInfo.CompanyName),
                              new SqlParameter("@FactoryCode",BaseSystemInfo.FactoryCode),
                              new SqlParameter("@FactoryName",BaseSystemInfo.FactoryName),
                              new SqlParameter("@ProductLineCode",BaseSystemInfo.ProductLineCode),
                              new SqlParameter("@ProductLineName",BaseSystemInfo.ProductLineName),
                              new SqlParameter("@ProcessCode",BaseSystemInfo.CurrentProcessCode),//工序
                              new SqlParameter("@ProcessName",BaseSystemInfo.CurrentProcessName),//工序
                              new SqlParameter("@CreateBy",BaseSystemInfo.CurrentUserName),
                              new SqlParameter("@Product_BarCode", OptionSetting.CurrentBarcode.Trim()),
                              new SqlParameter("@Material_Code", OptionSetting.CurrentMatercode),
                              new SqlParameter("@Material_Name",OptionSetting.CurrentMaterName),
                              new SqlParameter("@Material_Level", OptionSetting.CurrentLevel),
                              new SqlParameter("@Material_QualityResult", MaterialReslt.Trim())
                            };
                    DataSet ds = DataHelper.ExecuteProcedure("up_PR_BarcodeScan_Insert", new String[] { "List" }, param0);
                    LoadDataForDGVProBar_Check();
                }

            }), e.Code);
        }

        private void CheckScanner_DataReceived(object sender, SerialSortEventArgs e)
        {
            BeginInvoke(new Action<string>(args =>
            {
                OptionSetting.CurrentBackBarcode = args.Trim();

                if (OptionSetting.CurrentBackBarcode.Substring(0, 2) == "GA")
                {
                    OptionSetting.CurrentBackBarcode = args.Trim().Substring(0, 20);
                    txt_BackBarCode.Text = OptionSetting.CurrentBackBarcode;

                    HandleQualityBarCode(OptionSetting.CurrentBackBarcode);

                }
                else
                {
                    OptionSetting.CurrentBackBarcode = args.Trim().Substring(0, 20);
                    txt_BackBarCode.Text = OptionSetting.CurrentBackBarcode;
                    txt_BackMsgInfo.Text = "产品条码格式异常，请重新扫描......";
                    txt_BackMsgInfo.ForeColor = Color.Red;
                    speech.SpeakAsync("产品条码格式异常，请重新扫描");
                    SysBusinessFunction.WriteLog("返修扫码记录：" + OptionSetting.CurrentBackBarcode);
                }

            }), e.Code);
        }

        public void CreateBarScanSocket()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIP_1);
            QualityPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPort_1));
            QualitySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            QualitySocket.Blocking = true;
            try
            {
                QualitySocket.Connect(QualityPoint);
                QualitySocket.Blocking = false;
                BarScanConn = true;
            }
            catch (SocketException ex)
            {
                BarScanConn = false;
                string TipInfo = string.Format("返修下线扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanPort_1);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            InSocketThread = new Thread(QualitySocketRecMsg);
            InSocketThread.IsBackground = true;
            InSocketThread.Start();
            #endregion
        }
        private void QualitySocketRecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(10);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = QualitySocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    BarScanConn = true;

                }
                catch (Exception ex)
                {
                    BarScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (BarScanConn))
                {
                    HandleQualityBarCode(strMsg.Trim());
                }
            }
        }

        private void HandleQualityBarCode(string strMsg)
        {

            BeginInvoke(new Action(() =>
            {
                try
                {
                    lbl_QualityTime.Text = "--";
                    OptionSetting.CurrentBackBarcode = strMsg.Trim();
                    txt_BackBarCode.Text = OptionSetting.CurrentBackBarcode;
                    SysBusinessFunction.WriteLog(string.Format("返修下线固定扫码器扫码：" + OptionSetting.CurrentBackBarcode));
                    // string[] barCodes = CurrentQuaalityBarCode.Split(new char[] { ',' });

                    int TempResult = 0;
                    if (OptionSetting.CurrentBackBarcode.ToUpper() == "NOREAD")
                    {
                        txt_BackProductCode.Text = "";
                        txt_BackProductName.Text = "";
                        txt_BackMsgInfo.Text = "条码扫描失败......";
                        txt_BackMsgInfo.ForeColor = Color.Red;
                        txt_BackProductResult.Text = "NG";
                        txt_BackProductResult.ForeColor = Color.Red;
                        txt_BackProductName.Text = "";
                        lbl_QualityTime.Text = "--";
                        speech.SpeakAsync("条码扫描失败");
                        TempResult = 2;
                    }
                    else
                    if (OptionSetting.CurrentBackBarcode.Trim().Length != 20)
                    {
                        this.txt_BackMsgInfo.Text = "扫描条码格式错误！";
                        this.txt_BackMsgInfo.ForeColor = Color.Red;
                        txt_BackProductResult.Text = "NG";
                        txt_BackProductResult.ForeColor = Color.Red;
                        txt_BackProductCode.Text = "";
                        txt_BackProductName.Text = "";
                        lbl_QualityTime.Text = "--";
                        speech.SpeakAsync("扫描条码格式错误");
                        TempResult = 2;
                    }
                    else
                    {

                        //查询物料信息
                        string MaterialSQL = string.Format(@"SELECT  Prod_Desc,Prod_Code  
                                                             FROM view_product_info 
                                                             WHERE prod_code = '{0}'", OptionSetting.CurrentBackBarcode.Substring(0, 9));

                        DataTable Dt = DataHelper.MySqlFill(MaterialSQL).Tables[0];

                        if (Dt.Rows.Count > 0)
                        {
                            txt_BackProductName.Text = Dt.Rows[0]["Prod_Desc"].ToString();
                            txt_BackProductCode.Text = Dt.Rows[0]["prod_code"].ToString();
                            txt_BackMsgInfo.Text = "产品信息查询正常......";
                            txt_BackMsgInfo.ForeColor = Color.Lime;
                        }
                        else
                        {
                            txt_BackProductName.Text = "";
                            txt_BackProductCode.Text = "";
                            txt_BackMsgInfo.Text = "该条码无产品信息......";
                            txt_BackMsgInfo.ForeColor = Color.Red;
                        }
                        //查询质检信息
                        string sSQL = string.Format(@"SELECT  (CASE WHEN TestResult = 1 THEN 'OK' ELSE 'NG' END)  TestResult,DATE_FORMAT(TestTime,'%Y-%m-%d %k:%i:%S') TestTime
                                                      FROM bns_qm_performancetesting 
                                                      WHERE  WorkUser_BarCode = '{0}' 
                                                      Order By TestTime DESC ", OptionSetting.CurrentBackBarcode);
                        DataTable RDt = DataHelper.MySqlFill(sSQL).Tables[0];
                        if (RDt.Rows.Count > 0)
                        {
                            lbl_QualityTime.Text = RDt.Rows[0]["TestTime"].ToString();

                            if ("OK".Equals(RDt.Rows[0]["TestResult"].ToString().Trim()))
                            {
                                txt_BackProductResult.ForeColor = Color.Lime;
                                txt_BackProductResult.Text = RDt.Rows[0]["TestResult"].ToString();
                                TempResult = 1;
                            }
                            else
                            {
                                txt_BackProductResult.ForeColor = Color.Red;
                                txt_BackProductResult.Text = RDt.Rows[0]["TestResult"].ToString();
                                TempResult = 2;
                            }

                            txt_BackMsgInfo.Text = "质检信息查询正常......";
                            txt_BackMsgInfo.ForeColor = Color.Lime;
                        }
                        else
                        {
                            lbl_QualityTime.Text = "--";
                            txt_BackProductResult.Text = "No Data";
                            txt_BackMsgInfo.Text = "该条码无对应产品信息......";
                            txt_BackMsgInfo.ForeColor = Color.Red;
                            speech.SpeakAsync("该条码无对应产品信息");

                            TempResult = 2;
                        }


                        OptionSetting.CurrentBackMaterName = txt_BackProductName.Text.ToString();
                        OptionSetting.CurrentBackMatercode = txt_BackProductCode.Text.ToString();

                        if (OptionSetting.CurrentBackMatercode != "")
                        {
                            string MaterialReslt = txt_BackProductResult.Text.ToString();
                            DbParameter[] param0 = {
                              new SqlParameter("@CompanyCode",BaseSystemInfo.CompanyCode),//
                              new SqlParameter("@CompanyName",BaseSystemInfo.CompanyName),//
                              new SqlParameter("@FactoryCode",BaseSystemInfo.FactoryCode),//
                              new SqlParameter("@FactoryName",BaseSystemInfo.FactoryName),//
                              new SqlParameter("@ProductLineCode",BaseSystemInfo.ProductLineCode),//
                              new SqlParameter("@ProductLineName",BaseSystemInfo.ProductLineName),//
                              new SqlParameter("@ProcessCode",BaseSystemInfo.CurrentProcessCode_Sec),//工序
                              new SqlParameter("@ProcessName",BaseSystemInfo.CurrentProcessName_Sec),//工序
                              new SqlParameter("@CreateBy",BaseSystemInfo.CurrentUserName),
                              new SqlParameter("@Product_BarCode", OptionSetting.CurrentBackBarcode.Trim()),
                              new SqlParameter("@Material_Code", OptionSetting.CurrentBackMatercode),
                              new SqlParameter("@Material_Name",OptionSetting.CurrentBackMaterName),
                              new SqlParameter("@Material_Level", OptionSetting.CurrentBackLevel),
                              new SqlParameter("@Material_QualityResult", MaterialReslt.Trim())
                            };
                            DataSet ds = DataHelper.ExecuteProcedure("up_PR_BarcodeScan_Insert", new String[] { "List" }, param0);
                            LoadDataForDGVProBar_Quality();
                        }
                    }

                    #region 下传质检结果
                    int QualityAddress = 5046;
                    object[] BackWBuff = new object[2];
                    BackWBuff[0] = TempResult;
                    BackWBuff[1] = 1;
                    bool wresult1 = ControlMaster.WriteData(0, QualityAddress, BackWBuff);

                    if (!wresult1)
                    {
                        SysBusinessFunction.WriteLog("下传返修信号异常......");
                        return;
                    }

                    int LinerCount = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(5);
                        Application.DoEvents();
                        //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                        if (GetTickCount() - LinerCount > 5000) //超时处理
                        {
                            txt_BackMsgInfo.Text = "下传返修信号成功，等待反馈信号超时......";
                            txt_BackMsgInfo.ForeColor = Color.Red;
                            SysBusinessFunction.WriteLog("下传返修信号成功，等待反馈信号超时");
                            break;
                        }

                        object[] RBuf1 = new object[2];
                        ControlMaster.ReadData(0, QualityAddress, 2, out RBuf1);

                        if (RBuf1[1].ToString() == "2")
                        {

                            BackWBuff[0] = 0;
                            BackWBuff[1] = 0;
                            ControlMaster.WriteData(0, QualityAddress, BackWBuff);
                            break;
                        }
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog(string.Format("处理异常:" + ex.Message + OptionSetting.CurrentBackBarcode));
                    speech.SpeakAsync("处理异常:" + ex.Message);
                }

            }));
        }

        private void LoadDataForDGVProBar_Quality()
        {
            try
            {

                string sqlStr = string.Format(@"SELECT Top 5 Product_BarCode ,Material_Name,convert(varchar(10),Scan_Time,108) as Scan_Time
                                                FROM IMOS_PR_Scan
                                                Where convert(varchar(10),Scan_Time,120) = convert(varchar(10),GETDATE(),120)

                                                And Company_Code = '{0}' 
                                                And Factory_Code = '{1}' 
                                                And Product_Line_Code = '{2}'
                                                And Process_Code = '{3}'
                                                Order By Scan_Time DESC", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode_Sec);


                DataSet dataset = DataHelper.Fill(sqlStr);
                this.dgv_BackProductList.DataSource = dataset.Tables[0];
                this.dgv_BackProductList.Rows[0].Selected = false;
                dgv_BackProductList.ClearSelection();
                //dGVProBar.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                //dGVProBar.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(string.Format("数据处理异常." + ex));
            }
        }

        private void LoadDataForDGVProBar_Check()
        {
            try
            {

                string sqlStr = string.Format(@"SELECT  Top 5 Product_BarCode ,Material_Name,convert(varchar(10),Scan_Time,108) as Scan_Time
                                                FROM IMOS_PR_Scan
                                                Where convert(varchar(10),Scan_Time,120) = convert(varchar(10),GETDATE(),120)
                                                And Company_Code = '{0}' 
                                                And Factory_Code = '{1}' 
                                                And Product_Line_Code = '{2}'
                                                And Process_Code = '{3}'
                                                Order By Scan_Time DESC", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode);


                DataSet dataset = DataHelper.Fill(sqlStr);
                this.dataGridView1.DataSource = dataset.Tables[0];
                this.dataGridView1.Rows[0].Selected = false;
                dataGridView1.ClearSelection();
                //dGVProBar.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                //dGVProBar.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(string.Format("数据处理异常." + ex));
            }
        }
        public static void ReConnectDevice(object o)//PLC  socket重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!BarScanConn)
                {
                    try
                    {
                        if (BarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("返修条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        QualitySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        QualitySocket.Connect(QualityPoint);
                        BarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, QualityPoint.ToString()));
                        BarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = QualitySocket.Send(arrMsgRec);
                    BarScanConn = sLen == 1;
                }
                catch
                {
                    BarScanConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                ReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static Bitmap CreateQRCode(string content)
        {
            try
            {
                QRCodeEncoder qrEncoder = new QRCodeEncoder();
                //二维码类型
                qrEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                //二维码尺寸
                qrEncoder.QRCodeScale = 4;
                //二维码版本
                qrEncoder.QRCodeVersion = 7;
                //二维码容错程度
                qrEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //字体与背景颜色
                qrEncoder.QRCodeBackgroundColor = Color.White;
                qrEncoder.QRCodeForegroundColor = Color.Black;
                //UTF-8编码类型
                Bitmap qrcode = qrEncoder.Encode(content, Encoding.UTF8);

                return qrcode;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void lbl_CheckTime_Click(object sender, EventArgs e)
        {

        }
    }
}
