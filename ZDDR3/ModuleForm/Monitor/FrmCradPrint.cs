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

namespace Monitor
{

    using Sys.Config;
    using Sys.SysBusiness;
    using ControlLogic.BarCode;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using FastReport;

    public partial class FrmCradPrint : Form
    {
        //扫描枪变量
        private ScanProvider _scanner;
        private ScanProvider CheckScanner;

        private static string CurrentProductBarCode = "";

        private static string CurrentQuaalityBarCode = "";

        private static string HisProductName = "";

        private static Socket QualitySocket; //返修socket
        private static IPEndPoint QualityPoint;//IP及端口信息
       
        private static bool BarScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket

        private static int BarReConnCount = 0;
        private SpeechSynthesizer speech = new SpeechSynthesizer();
        public static FastReport.EnvironmentSettings eSet = new EnvironmentSettings();
        public FrmCradPrint()
        {
            InitializeComponent();
        }

        private void product_Load(object sender, EventArgs e)
        {
            pic_OID.Image = SysBusinessFunction.CreateQRCode("http://oid.haier.com/oid?ewm=D006iM$MFTKA$AM$M$cM$KM$KKM$c$AM$KvA$FFM$$K$KKLKKM$$$TMAK$YKYKLMKKKKK$7");

            pic_Style_BarCode1.Image = SysBusinessFunction.CreateBarCode("wqwqqw",320,55);
            // txt_StationName.Text = BaseSystemInfo.CurrentProcessName; //BaseSystemInfo.CurrentProcessCode

            timer1.Enabled = false;

            timer1.Interval = 1000;

            timer1.Enabled = true;

            LoadDataForDGVProBar();
            InitScanner();
            CreateBarScanSocket();
            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 包含PLC 条码


        }
        #region  扫码枪串口扫描
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
                string TipInfo = string.Format("条码枪连接出现异常.端口【{0}】波特率【{1}】，", BaseSystemInfo.SerialPortName1, 9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
        }
        #endregion
        private void _scanner_DataReceived(object sender, SerialSortEventArgs e)
        {
            BeginInvoke(new Action<string>(args =>
            {
                string BarCode = args.Trim();
                SysBusinessFunction.WriteLog(string.Format("串口扫码枪扫码：" + BarCode));
                maindo(BarCode);

            }), e.Code);
        }
        #region 固定扫码器扫码
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
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanPort_1);
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
                string BarCode = strMsg.Trim();
                SysBusinessFunction.WriteLog(string.Format("固定扫码器扫码：" + BarCode));
                maindo(BarCode);

            }));
        }

        private void LoadDataForDGVProBar()
        {
            try
            {

                string sqlStr = string.Format(@"SELECT Product_BarCode ,Material_Name,convert(varchar(10),Scan_Time,108) as Scan_Time
                                                FROM IMOS_PR_Scan
                                                Where convert(varchar(10),Scan_Time,120) = convert(varchar(10),GETDATE(),120)

                                                And Company_Code = '{0}' 
                                                And Factory_Code = '{1}' 
                                                And Product_Line_Code = '{2}'
                                                Order By Scan_Time DESC", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);


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

        public static void ReConnectDevice(object o)//PLC  socket重连接
        {

            //扫码器重新连接
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



        #endregion




        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //txt_StationName.Text = BaseSystemInfo.CurrentProcessName;
                //txt_BarCode.Text = OptionSetting.CurrentBarcode;
                //txt_MaterialName.Text = OptionSetting.CurrentMaterImage;
                //txt_MaterialCode.Text = OptionSetting.CurrentMatercode;
                //txt_MaterialLevel.Text = OptionSetting.CurrentLevel;
            }
            catch
            {

            }
        }
        private void maindo(string code)
        {
            try
            {
                CurrentQuaalityBarCode = code.Trim();
                txt_BackBarCode.Text = CurrentQuaalityBarCode;
                txt_BackMsgInfo.Text = "";
                txt_BackProductCode.Text = "";
                txt_BackProductName.Text = "";
                txt_BackScanTime.Text = "";
                if (CurrentQuaalityBarCode == "NoRead")
            {
                txt_BackProductCode.Text = "";
                txt_BackProductName.Text = "";
                txt_BackMsgInfo.Text = "条码扫描失败......";
                txt_BackMsgInfo.ForeColor = Color.Red;
                txt_BackProductName.Text = "";
                txt_BackScanTime.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

                speech.SpeakAsync("条码扫描失败");

                return;
            }

            if (CurrentQuaalityBarCode.Trim().Length != 20)
            {
                this.txt_BackMsgInfo.Text = "扫描条码格式错误！";
                this.txt_BackMsgInfo.ForeColor = Color.Red;
                //txt_BackScanTime.Text = "无质检信息";
                //txt_BackScanTime.ForeColor = Color.Red;

                txt_BackProductCode.Text = "";
                txt_BackProductName.Text = "";
                txt_BackScanTime.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                speech.SpeakAsync("扫描条码格式错误");
                return;
            }
            //查询视图获取产品信息
            Card c = SysBusinessFunction.MakeCard(CurrentQuaalityBarCode);
            if (c.BarCode == null)
            {
                txt_BackProductName.Text = "";
                txt_BackProductCode.Text = "";
                txt_BackScanTime.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                txt_BackMsgInfo.Text = "该条码没有查询到物料";
                txt_BackMsgInfo.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbl_Style_Prod_Desc.Text = c.Prod_Desc;
                lbl_Style_Prod_Desc2.Text = c.Prod_Desc;
                lbl_Style_BarCode1.Text = CurrentQuaalityBarCode;
                lbl_Style_BarCode2.Text = CurrentQuaalityBarCode;
                lbl_Style_Waterproofing.Text = c.Waterproofing;
                lbl_Style_Voltage.Text = c.Voltage;
                lbl_Style_Frequency.Text = c.Frequency;
                if (c.Power == null)
                {
                    lbl_Style_Power.Text = c.SmallPower;
                }
                else
                {
                    lbl_Style_Power.Text = c.Power;
                }
                lbl_Style_Capacity.Text = c.Capacity;
                lbl_Style_Max_Temperature.Text = c.MaxTemperature;
                lbl_Style_Pressure.Text = c.Pressure;
                txt_BackProductName.Text = c.Prod_Desc;
                lbl_MakeDate.Text = "制造日期" + DateTime.Now.ToLocalTime().ToString("yyyyMMdd");
                txt_BackProductCode.Text = c.Prod_Code;
                txt_BackScanTime.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                txt_BackMsgInfo.Text = "条码扫描成功......";
                txt_BackMsgInfo.ForeColor = Color.Lime;
            }
            txt_BackBarCode.Text = CurrentQuaalityBarCode;
            pic_Style_BarCode1.Image = SysBusinessFunction.CreateBarCode(CurrentQuaalityBarCode, 2800, 55);
            pic_Style_BarCode2.Image = SysBusinessFunction.CreateBarCode(CurrentQuaalityBarCode, 2800, 55);

            if (c.oid == null || c.VerificationCode == null)
            {
                txt_BackMsgInfo.Text = "未查到检验码网址等数据";
                txt_BackMsgInfo.ForeColor = Color.Red;
                return;
            }
            else
            {
                pic_Verification_Code.Image = SysBusinessFunction.CreateBarCode(c.VerificationCode, 320, 55);
                pic_OID.Image = SysBusinessFunction.CreateQRCode(c.oid);
            }
            SysBusinessFunction.WriteLog("扫码记录：" + OptionSetting.CurrentBarcode);
            DbParameter[] param0 = {
                              new SqlParameter("@CompanyCode",BaseSystemInfo.CompanyCode),//
                              new SqlParameter("@CompanyName",BaseSystemInfo.CompanyName),//
                              new SqlParameter("@FactoryCode",BaseSystemInfo.FactoryCode),//
                              new SqlParameter("@FactoryName",BaseSystemInfo.FactoryName),//
                              new SqlParameter("@ProductLineCode",BaseSystemInfo.ProductLineCode),//
                              new SqlParameter("@ProductLineName",BaseSystemInfo.ProductLineName),//
                              new SqlParameter("@ProcessCode","101"),//工序
                              new SqlParameter("@ProcessName","生产"),//工序
                              new SqlParameter("@CreateBy",BaseSystemInfo.CurrentUserName),
                              new SqlParameter("@Product_BarCode", CurrentQuaalityBarCode.Trim()),
                              new SqlParameter("@Material_Code", txt_BackProductCode.Text.Trim()),
                              new SqlParameter("@Material_Name", txt_BackProductName.Text.Trim()),
                              new SqlParameter("@Material_Level", 1),
                              new SqlParameter("@Material_QualityResult", "OK")
                            };
            DataSet ds = DataHelper.ExecuteProcedure("up_PR_BarcodeScan_Insert", new String[] { "List" }, param0);
            DataTable table = new DataTable();
            table.Columns.Add("Material_Spec", typeof(string));
            table.Columns.Add("P_Capacity", typeof(string));
            table.Columns.Add("P_Temperature", typeof(string));
            table.Columns.Add("P_Waterproof", typeof(string));
            table.Columns.Add("P_Voltage", typeof(string));
            table.Columns.Add("P_Frequency", typeof(string));
            table.Columns.Add("P_Power", typeof(string));
            table.Columns.Add("P_Pressure", typeof(string));
            table.Columns.Add("BarCode_No1", typeof(string));
            table.Columns.Add("BarCode_No2", typeof(string));
            table.Columns.Add("oid", typeof(string));
            table.Rows.Add(lbl_Style_Prod_Desc.Text, lbl_Style_Capacity.Text, lbl_Style_Max_Temperature.Text, lbl_Style_Waterproofing.Text, lbl_Style_Voltage.Text, lbl_Style_Frequency.Text, lbl_Style_Power.Text, lbl_Style_Pressure.Text,
                                          CurrentQuaalityBarCode, lbl_Style_Verification_Code.Text, c.oid);

            //预览打印

            eSet.ReportSettings.ShowProgress = false;
            FastReport.Report report = new FastReport.Report();
            bool flag = SysBusinessFunction.CardPrint(report, "BarCodeType051.frx", table, 1);
            //插入printonlinelog
            if (flag)
            {
                SysBusinessFunction.WriteLog("条码" + CurrentQuaalityBarCode + "打印成功！！！！");

            }
            else
            {
                //SysBusinessFunction.WriteLog("条码" + CurrentQuaalityBarCode + "打印失败！！");
                return;
            }
            string reportSQL = string.Format(@"INSERT  into printonlinelog (Pro_Barcode,Card_Print_Flag,Print_Time)values('{0}','{1}','{2}')",
                                        CurrentQuaalityBarCode, "1", DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            DataHelper.MySqlFill(reportSQL);
            LoadDataForDGVProBar();
        }

                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog(ex.Message);

                    speech.SpeakAsync("数据处理异常:" + ex.Message);
                }
                finally
                {
                    
                }
        }

    }
}
