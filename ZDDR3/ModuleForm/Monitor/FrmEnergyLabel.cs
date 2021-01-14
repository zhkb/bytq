using ControlLogic.BarCode;
using FastReport;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Net;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmEnergyLabel : Form
    {
        #region 全局变量
        private ScanProvider _scanner;
        private static string CurrentProductBarCode = "";
        private static string CurrentQuaalityBarCode = "";
        private static string HisProductName = "";
        private static Socket EnergySocket; //能效标识socket
        private static IPEndPoint EnergyPoint;//IP及端口信息
        private static bool BarScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private static int BarReConnCount = 0;
        private SpeechSynthesizer speech = new SpeechSynthesizer();
        private DataSet MasterDataSet = new DataSet();//存储扫描记录
        private DataSet MaterialDataSet = new DataSet();//存储物料信息
        private DataSet ScanRecordDataSet = new DataSet();
        #endregion
        public FrmEnergyLabel()
        {
            InitializeComponent();

        }
        private void FrmEnergyLabel_Load(object sender, EventArgs e)
        {
            GetScanData();
            CreateBarScanSocket();
            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 包含PLC 条码
        }

        private void dgv_ScanRecordList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            #region 设置表格序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X+30,
            e.RowBounds.Location.Y,
            dgv_ScanRecordList.RowHeadersWidth+100,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv_ScanRecordList.RowHeadersDefaultCellStyle.Font, rectangle, dgv_ScanRecordList.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.Right&TextFormatFlags.VerticalCenter);
            dgv_ScanRecordList.Rows[0].Selected = false;
            #endregion
        }

        private void GetScanData()//获取扫描数据
        {
            #region 获取扫描数据
            try
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd");
                string SqlStr = string.Format(@"SELECT TOP 50 a.[Product_BarCode],a.[Material_Code],a.[Material_Name],a.[Material_Level],Convert(Varchar(100),a.Scan_Time,120) Scan_Time
                                                FROM IMOS_PR_Scan a 
                                                Where Convert(Varchar(100),[Scan_Time],120) like '%{0}%' and a.[Company_Code]='{1}'and a.[Factory_Code] = '{2}'and a.[Product_Line_Code] = '{3}'and a.[Process_Code] = '{4}'
                                                order by Scan_Time Desc",
                                                time, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode);

                MasterDataSet = DataHelper.Fill(SqlStr);
                dgv_ScanRecordList.DataSource = MasterDataSet.Tables[0];
                dgv_ScanRecordList.ClearSelection();

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取扫描信息失败." + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
            #endregion
        }

        private void EnergyLabelPrint(string code)//打印能效标识
        {
            #region 通过产品编码获取产品数据
            try
            {
                string SqlStr = string.Format(@"SELECT * FROM  IMOS_TA_Material a
                                              Where a.[Company_Code]='{0}'and a.[Factory_Code] = '{1}'and a.[Product_Line_Code] = '{2}' and a.[Material_Code]='{3}'",
                                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, code);
                MaterialDataSet = DataHelper.Fill(SqlStr);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取产品信息失败." + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
            #endregion

            #region 打印
            try
            {
                #region  可以删除
                //List<String> list = new List<string>();
                //for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)       //获取当前打印机
                //{
                //    list.Add(PrinterSettings.InstalledPrinters[i]);
                // }
                //String firstname = list[7];
                //String secondname = list[2];
                //String thridname = list[2];
                //chart1.Series[0].Points[0].Label = "";
                //chart1.Series[0].Points[1].Label = "";
                //chart1.Series[0].Points[2].Label = "";
                #endregion
                string level = MaterialDataSet.Tables[0].Rows[0]["Material_Level"].ToString();
                string filename = "";
                FastReport.Report report = new FastReport.Report();
                if ("1".Equals(level))
                {
                    filename = @"Report\first_Energy_Label.frx";
                    Externs.SetDefaultPrinter(BaseSystemInfo.EnergyPrinterName1);
                    chart1.Series[0].Points[2].Label = "一级";
                }
                else if ("2".Equals(level))
                {
                    filename = @"Report\second_Energy_Label.frx";
                    Externs.SetDefaultPrinter(BaseSystemInfo.EnergyPrinterName2);
                    chart1.Series[0].Points[1].Label = "二级";
                }
                else
                {
                    filename = @"Report\thrid_Energy_Label.frx";
                    Externs.SetDefaultPrinter(BaseSystemInfo.EnergyPrinterName3);
                    chart1.Series[0].Points[0].Label = "三级";
                }
                report.Load(filename);
                report.RegisterData(MaterialDataSet.Tables[0], "IMOS_TA_Material");
                DataBand data = report.FindObject("Data1") as DataBand;
                data.DataSource = report.GetDataSource("IMOS_TA_Material");
                report.PrintSettings.Copies = 1;
                report.PrintSettings.ShowDialog = false;
                //report.Show(true);           
                //report.Print();
                report.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("打印能耗贴失败." + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "打印能耗贴失败.");
            }
            #endregion
        }


        #region 固定扫码器扫码
        public void CreateBarScanSocket()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIP_1);
            EnergyPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPort_1));
            EnergySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EnergySocket.Blocking = true;
            try
            {
                EnergySocket.Connect(EnergyPoint);
                EnergySocket.Blocking = false;
                BarScanConn = true;
            }
            catch (SocketException ex)
            {
                BarScanConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, EnergyPoint);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            InSocketThread = new Thread(EnergySocketRecMsg);
            InSocketThread.IsBackground = true;
            InSocketThread.Start();
            #endregion
        }



        private void EnergySocketRecMsg()//获取条码
        {
            #region  获取条码
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(10);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = EnergySocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
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
                    HandleEnergyBarCode(strMsg.Trim());
                }
            }
            #endregion
        }


        private void HandleEnergyBarCode(string strMsg)  //对条码进行处理，插入扫描记录，显示扫描信息
        {
            #region
            BeginInvoke(new Action(() =>
            {
                try
                {
                    CurrentQuaalityBarCode = strMsg.Trim();
                    lbl_Material_Level.Text = "";
                    lbl_Material_Name.Text = "";
                    lbl_Matetial_Code.Text = "";
                    lbl_ScanTime.Text = "";
                    lbl_BackBarCode.ForeColor = Color.Gold;
                    lbl_Msgs.ForeColor = Color.Gold;
                    lbl_BackBarCode.Text = CurrentQuaalityBarCode;
                    SysBusinessFunction.WriteLog(string.Format("固定扫码器扫码：" + CurrentQuaalityBarCode));
                    for (int i = 0; i <= 2; i++)
                    {
                        chart1.Series[0].Points[i].Label = "";
                    }
                    if (CurrentQuaalityBarCode == "NO READ")
                    {
                        lbl_Msgs.Text = "没有读取到条码！";
                        lbl_Msgs.ForeColor = Color.Red;
                        lbl_BackBarCode.ForeColor = Color.Red;
                        speech.SpeakAsync("条码扫描失败");
                        return;
                    }
                    if (CurrentQuaalityBarCode.Trim().Length != 20)
                    {
                        lbl_Msgs.Text = "扫描条码格式错误!";
                        lbl_Msgs.ForeColor = Color.Red;
                        lbl_BackBarCode.ForeColor = Color.Red;
                        speech.SpeakAsync("扫描条码格式错误");
                        return;
                    }
                    lbl_BackBarCode.Text = CurrentQuaalityBarCode;

            string sqlStr = string.Format(@"SELECT  Material_Code ,Material_Name, Material_Level
                                                FROM imos_ta_material
                                                Where  Company_Code = '{0}' 
                                                And Factory_Code = '{1}' 
                                                And Product_Line_Code = '{2}'
                                                And Material_code = '{3}'",
                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, CurrentQuaalityBarCode.Substring(0, 9));

                    DataTable Dt = DataHelper.Fill(sqlStr).Tables[0];
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    if (Dt.Rows.Count > 0)
                    {
                        lbl_Matetial_Code.Text = Dt.Rows[0]["Material_Code"].ToString();
                        lbl_Material_Name.Text = Dt.Rows[0]["Material_Name"].ToString();
                        lbl_Material_Level.Text = Dt.Rows[0]["Material_Level"].ToString();
                        lbl_ScanTime.Text = time;
                        lbl_Msgs.Text = "查询物料信息成功！";
                    }
                    else
                    {
                        lbl_Msgs.Text = "查询物料信息失败，请重新扫描！";
                        lbl_Msgs.ForeColor = Color.Red;
                        return;
                    }

            SysBusinessFunction.WriteLog("扫码记录：" + OptionSetting.CurrentBarcode);
            //SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, BaseSystemInfo.CurrentProcessCode);

            DbParameter[] param0 = {
                              new SqlParameter("@CompanyCode",BaseSystemInfo.CompanyCode),//
                              new SqlParameter("@CompanyName",BaseSystemInfo.CompanyName),//
                              new SqlParameter("@FactoryCode",BaseSystemInfo.FactoryCode),//
                              new SqlParameter("@FactoryName",BaseSystemInfo.FactoryName),//
                              new SqlParameter("@ProductLineCode",BaseSystemInfo.ProductLineCode),//
                              new SqlParameter("@ProductLineName",BaseSystemInfo.ProductLineName),//
                              new SqlParameter("@ProcessCode",BaseSystemInfo.CurrentProcessCode),//工序编号
                              new SqlParameter("@ProcessName",BaseSystemInfo.CurrentProcessName),//工序名称
                              new SqlParameter("@CreateBy",BaseSystemInfo.CurrentUserName),
                              new SqlParameter("@Product_BarCode", CurrentQuaalityBarCode.Trim()),
                              new SqlParameter("@Material_Code", lbl_Matetial_Code.Text.Trim()),
                              new SqlParameter("@Material_Name", lbl_Material_Name.Text.Trim()),
                              new SqlParameter("@Material_Level",lbl_Material_Level.Text.Trim()),
                              new SqlParameter("@Material_QualityResult", "")
                            };
                    DataSet ds = DataHelper.ExecuteProcedure("up_PR_BarcodeScan_Insert", new String[] { "List" }, param0);
                    GetScanData();//显示扫描信息
                    EnergyLabelPrint(lbl_Matetial_Code.Text.Trim());//报表打印

                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("扫描条码发生异常："+ex.Message);
                    speech.SpeakAsync("处理异常:" + ex.Message);
                }

            }));
            #endregion
        }

        public static void ReConnectDevice(object o)//PLC  socket重连接
        {
            #region PLC重连
            try
            {
                Thread.Sleep(10);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!BarScanConn)
                {
                    try
                    {
                        if (BarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("能耗贴条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        EnergySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        EnergySocket.Connect(EnergyPoint);
                        BarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("能耗贴条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, EnergyPoint.ToString()));
                        BarReConnCount = 0;
                    }
                    catch
                    {
                        //SysBusinessFunction.WriteLog("能耗贴条码扫描设备失败："+ ex.Message);
                    }
                }

                try
                {
                    int sLen = EnergySocket.Send(arrMsgRec);
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
            #endregion
        }

    }
    #endregion

}

