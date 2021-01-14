using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmPressorMonitor : Form
    {
        #region 以太网扫码器
        private static Socket ProductScanSocket; //产品扫码
        private static IPEndPoint ProductScanPoint;//产品IP及端口信息

        private static Socket CompressorScanSocket; //压缩机扫码
        private static IPEndPoint CompressorScanPoint;//压缩机IP及端口信息

        private static bool ProductScanConn = false;
        private static bool CompressorScanConn = false;
        private static Thread InProSocketThread = null; // 创建用于接收产品消息的 线程； 
        private static Thread InComSocketThread = null; // 创建用于接收压缩机消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private static int ProBarReConnCount = 0;
        private static int ComBarReConnCount = 0;
        private static string ProScanTime = "";
        private static string ComScanTime = "";
        private static DateTime oldtime = DateTime.Now;
        private static DateTime newtime = DateTime.Now;
        private static bool First_Flag = true;
        private string PlanName = "";
        #endregion
        public FrmPressorMonitor()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmPressorMonitor_Load(object sender, EventArgs e)
        {

            SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态
            SysBusinessFunction.ServerDBConn = DataHelper.DBServerConnection();//数据库连接状态
            SysBusinessFunction.CreateCheckDBConnection();
            ControlMaster.SystemInitialization();//初始化PLC
            if ("1030".Equals(BaseSystemInfo.CurrentProcessCode))
            {
                PlanName = "APlanQty";
            }
            if ("1031".Equals(BaseSystemInfo.CurrentProcessCode))
            {
                PlanName = "BPlanQty";
            }
            cht_ProductHour.ChartAreas[0].AxisY.Maximum = 150;
            cht_ProductHour.ChartAreas[0].AxisY.Interval = 50;
            cht_ProductHour.ChartAreas[0].AxisX.Interval = 1;
            //cht_ProductHour.ChartAreas[0].AxisX.Maximum = 23;
            InitChart();
            RefreshData(1);
            //扫码先后顺序是否确定
            timer1.Interval = 300;
            timer1.Enabled = true;
            timer1.Start();
            CreateProductScanSocket();
            CreateCompressorScanSocket();

            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备
        }
        #endregion

        #region 刷新计划数量,完成率，生产节拍
        private void RefreshData(int t)//刷新数据
        {
            try
            {
                #region  从数据库中获取数据
                //获取计划生产数据
                string PlanSql = String.Format(@"SELECT Remark FROM Sys_Parameters_Master where Parameter_Master_Code = '{0}'", PlanName);
                DataSet PlanDs = DataHelper.Fill(PlanSql);
                if (PlanDs.Tables[0].Rows.Count == 0)
                {
                    lbl_Scheduled_Qty.Text = "-1";
                }
                else
                {
                    lbl_Scheduled_Qty.Text = PlanDs.Tables[0].Rows[0]["Remark"].ToString();
                    txt_Scheduled_Qty.Text = PlanDs.Tables[0].Rows[0]["Remark"].ToString();
                }
                //获取生产节拍
                //String tsql = String.Format(@"SELECT TOP 2 Convert(varchar(50),Create_Time,120) Create_Time FROM IMOS_TA_ProPre_Record Where 1=1 ORDER BY Create_Time Desc");
                //DataSet TDS = DataHelper.Fill(tsql);
                //if (TDS.Tables[0].Rows.Count != 2)
                //{
                //    lbl_Current_Cycle_time.Text = "S";
                //}
                //else
                //{
                //    DateTime newtime = Convert.ToDateTime(TDS.Tables[0].Rows[0]["Create_Time"].ToString());
                //    DateTime oldtime = Convert.ToDateTime(TDS.Tables[0].Rows[1]["Create_Time"].ToString());
                //    TimeSpan ts = newtime.Subtract(oldtime);
                //    int sec = (int)ts.TotalSeconds;
                //    lbl_Current_Cycle_time.Text = sec.ToString()+"S";
                //}

                //if (First_Flag)
                //{
                //    lbl_Current_Cycle_time.Text = "0S";
                //    if (t == 2)
                //    {
                //        First_Flag = false;
                //    }
                //}
                //else
                //{
                //    TimeSpan ts = newtime.Subtract(oldtime);
                //    int sec = (int)ts.TotalSeconds;
                //    oldtime = newtime;
                //    lbl_Current_Cycle_time.Text = sec.ToString() + "S";
                //}
                int AQTY = int.Parse(lbl_Actual_Qty.Text);
                int SQTY = int.Parse(lbl_Scheduled_Qty.Text);
                if (SQTY == 0)
                {
                    lbl_Completion_Rate.Text = "0.0%";
                }
                else
                {
                    lbl_Completion_Rate.Text = (((double)AQTY / (double)SQTY) * 100).ToString("#0.0") + "%";
                }
                #endregion
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新数据失败！");
            }
        }
        #endregion

        #region 图表更新
        private void InitChart()//图表更新
        {

            try
            {
                cht_ProductHour.Series[0].Points.Clear();
                String sql = String.Format(@"select 
                                            SUM(CASE when  dateName(hh,a.Create_Time)>=0  then 1 ELSE 0 end ) Total_Qty,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=0  then 1 ELSE 0 end ) Hour_Qty,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=1  then 1 ELSE 0 end ) Hour_Qty1,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=2  then 1 ELSE 0 end ) Hour_Qty2,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=3  then 1 ELSE 0 end ) Hour_Qty3,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=4  then 1 ELSE 0 end ) Hour_Qty4,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=5  then 1 ELSE 0 end ) Hour_Qty5,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=6  then 1 ELSE 0 end ) Hour_Qty6,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=7  then 1 ELSE 0 end ) Hour_Qty7,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=8  then 1 ELSE 0 end ) Hour_Qty8,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=9  then 1 ELSE 0 end ) Hour_Qty9,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=10 then 1 ELSE 0 end ) Hour_Qty10,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=11 then 1 ELSE 0 end ) Hour_Qty11,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=12 then 1 ELSE 0 end ) Hour_Qty12,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=13  then 1 ELSE 0 end ) Hour_Qty13,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=14  then 1 ELSE 0 end ) Hour_Qty14,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=15  then 1 ELSE 0 end ) Hour_Qty15,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=16  then 1 ELSE 0 end ) Hour_Qty16,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=17  then 1 ELSE 0 end ) Hour_Qty17,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=18  then 1 ELSE 0 end ) Hour_Qty18,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=19  then 1 ELSE 0 end ) Hour_Qty19,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=20  then 1 ELSE 0 end ) Hour_Qty20,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=21  then 1 ELSE 0 end ) Hour_Qty21,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=22  then 1 ELSE 0 end ) Hour_Qty22,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=23  then 1 ELSE 0 end ) Hour_Qty23
                                            from IMOS_TA_ProPre_Record  a where   Create_Time >= CONVERT(varchar, getdate(), 23) 
                                            and Company_Code = '{0}' 
                                            and Factory_Code = '{1}'
                                            and Product_Line_Code = '{2}'
                                            and Process_Code = '{3}'", BaseSystemInfo.CompanyCode,
                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    return;
                }
                int[] HourQty = new int[24];
                cht_ProductHour.Series[0].Points.Clear();
                cht_ProductHour.Series[0].Points.AddXY("00", ds.Tables[0].Rows[0]["Hour_Qty"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("01", ds.Tables[0].Rows[0]["Hour_Qty1"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("02", ds.Tables[0].Rows[0]["Hour_Qty2"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("03", ds.Tables[0].Rows[0]["Hour_Qty3"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("04", ds.Tables[0].Rows[0]["Hour_Qty4"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("05", ds.Tables[0].Rows[0]["Hour_Qty5"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("06", ds.Tables[0].Rows[0]["Hour_Qty6"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("07", ds.Tables[0].Rows[0]["Hour_Qty7"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("08", ds.Tables[0].Rows[0]["Hour_Qty8"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("09", ds.Tables[0].Rows[0]["Hour_Qty9"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("10", ds.Tables[0].Rows[0]["Hour_Qty10"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("11", ds.Tables[0].Rows[0]["Hour_Qty11"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("12", ds.Tables[0].Rows[0]["Hour_Qty12"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("13", ds.Tables[0].Rows[0]["Hour_Qty13"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("14", ds.Tables[0].Rows[0]["Hour_Qty14"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("15", ds.Tables[0].Rows[0]["Hour_Qty15"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("16", ds.Tables[0].Rows[0]["Hour_Qty16"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("17", ds.Tables[0].Rows[0]["Hour_Qty17"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("18", ds.Tables[0].Rows[0]["Hour_Qty18"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("19", ds.Tables[0].Rows[0]["Hour_Qty19"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("20", ds.Tables[0].Rows[0]["Hour_Qty20"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("21", ds.Tables[0].Rows[0]["Hour_Qty21"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("22", ds.Tables[0].Rows[0]["Hour_Qty22"].ToString());
                cht_ProductHour.Series[0].Points.AddXY("23", ds.Tables[0].Rows[0]["Hour_Qty23"].ToString());
                //实际生产数据
                if (ds.Tables[0].Rows[0]["Total_Qty"].ToString().Length != 0)
                {
                    lbl_Actual_Qty.Text = ds.Tables[0].Rows[0]["Total_Qty"].ToString();
                }
                else
                {
                    lbl_Actual_Qty.Text = "0";
                }
                String SQL = String.Format(@"select 
                                            SUM(CASE when  dateName(hh,a.Create_Time)=0  then 1 ELSE 0 end ) Hour_Qty,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=1  then 1 ELSE 0 end ) Hour_Qty1,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=2  then 1 ELSE 0 end ) Hour_Qty2,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=3  then 1 ELSE 0 end ) Hour_Qty3,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=4  then 1 ELSE 0 end ) Hour_Qty4,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=5  then 1 ELSE 0 end ) Hour_Qty5,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=6  then 1 ELSE 0 end ) Hour_Qty6,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=7  then 1 ELSE 0 end ) Hour_Qty7,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=8  then 1 ELSE 0 end ) Hour_Qty8,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=9  then 1 ELSE 0 end ) Hour_Qty9,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=10 then 1 ELSE 0 end ) Hour_Qty10,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=11 then 1 ELSE 0 end ) Hour_Qty11,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=12 then 1 ELSE 0 end ) Hour_Qty12,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=13  then 1 ELSE 0 end ) Hour_Qty13,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=14  then 1 ELSE 0 end ) Hour_Qty14,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=15  then 1 ELSE 0 end ) Hour_Qty15,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=16  then 1 ELSE 0 end ) Hour_Qty16,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=17  then 1 ELSE 0 end ) Hour_Qty17,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=18  then 1 ELSE 0 end ) Hour_Qty18,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=19  then 1 ELSE 0 end ) Hour_Qty19,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=20  then 1 ELSE 0 end ) Hour_Qty20,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=21  then 1 ELSE 0 end ) Hour_Qty21,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=22  then 1 ELSE 0 end ) Hour_Qty22,
                                            SUM(CASE when  dateName(hh,a.Create_Time)=23  then 1 ELSE 0 end ) Hour_Qty23
                                            from IMOS_TA_ProPre_Record  a where   Create_Time >= CONVERT(varchar, getdate(), 23) 
                                            and Company_Code = '{0}' 
                                            and Factory_Code = '{1}'
                                            and Product_Line_Code = '{2}'
                                            and Process_Code = '{3}'
                                            and Match_Flag = '{4}'", BaseSystemInfo.CompanyCode,
                                           BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode, "2");
                DataSet nds = DataHelper.Fill(SQL);
                if (nds == null)
                {
                    return;
                }
                int[] NHourQty = new int[24];
                cht_ProductHour.Series[1].Points.Clear();
                cht_ProductHour.Series[1].Points.AddXY("00", nds.Tables[0].Rows[0]["Hour_Qty"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("01", nds.Tables[0].Rows[0]["Hour_Qty1"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("02", nds.Tables[0].Rows[0]["Hour_Qty2"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("03", nds.Tables[0].Rows[0]["Hour_Qty3"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("04", nds.Tables[0].Rows[0]["Hour_Qty4"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("05", nds.Tables[0].Rows[0]["Hour_Qty5"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("06", nds.Tables[0].Rows[0]["Hour_Qty6"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("07", nds.Tables[0].Rows[0]["Hour_Qty7"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("08", nds.Tables[0].Rows[0]["Hour_Qty8"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("09", nds.Tables[0].Rows[0]["Hour_Qty9"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("10", nds.Tables[0].Rows[0]["Hour_Qty10"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("11", nds.Tables[0].Rows[0]["Hour_Qty11"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("12", nds.Tables[0].Rows[0]["Hour_Qty12"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("13", nds.Tables[0].Rows[0]["Hour_Qty13"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("14", nds.Tables[0].Rows[0]["Hour_Qty14"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("15", nds.Tables[0].Rows[0]["Hour_Qty15"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("16", nds.Tables[0].Rows[0]["Hour_Qty16"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("17", nds.Tables[0].Rows[0]["Hour_Qty17"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("18", nds.Tables[0].Rows[0]["Hour_Qty18"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("19", nds.Tables[0].Rows[0]["Hour_Qty19"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("20", nds.Tables[0].Rows[0]["Hour_Qty20"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("21", nds.Tables[0].Rows[0]["Hour_Qty21"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("22", nds.Tables[0].Rows[0]["Hour_Qty22"].ToString());
                cht_ProductHour.Series[1].Points.AddXY("23", nds.Tables[0].Rows[0]["Hour_Qty23"].ToString());

                //for (int i = 0; i <= 23; i++)
                //{
                //    if (cht_ProductHour.Series[0].Points[i].YValues[0] == 0)
                //    {
                //        cht_ProductHour.Series[0].Points[i].IsEmpty = true;
                //    }
                //    if (cht_ProductHour.Series[1].Points[i].YValues[0] == 0)
                //    {
                //        cht_ProductHour.Series[1].Points[i].IsEmpty = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("图表刷新失败");
            }
        }

        #endregion

        #region 扫码器创建 产品扫码器 压缩机扫码器
        private void CreateProductScanSocket()//创建产品Socket
        {
            #region 创建Socket
            IPAddress InProIP = IPAddress.Parse(BaseSystemInfo.BarScanProIP);//获取产品扫码器IP地址
            ProductScanPoint = new IPEndPoint(InProIP, int.Parse(BaseSystemInfo.BarScanProPort));//产品端口号
            ProductScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ProductScanSocket.Blocking = true;
            try
            {
                ProductScanSocket.Connect(ProductScanPoint);
                ProductScanSocket.Blocking = false;
                ProductScanConn = true;
            }
            catch (SocketException ex)
            {
                ProductScanConn = false;
                string TipInfo = string.Format("压缩机防差错产品扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InProIP, BaseSystemInfo.BarScanProPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            InProSocketThread = new Thread(ProductSocketRecMsg);
            InProSocketThread.IsBackground = true;
            InProSocketThread.Start();
            #endregion
        }
        private void CreateCompressorScanSocket()//创建压缩机扫描器
        {
            #region 创建Socket
            IPAddress InComIP = IPAddress.Parse(BaseSystemInfo.BarScanComIP);//获取压缩机扫码器IP地址
            CompressorScanPoint = new IPEndPoint(InComIP, int.Parse(BaseSystemInfo.BarScanComPort));//压缩机端口号
            CompressorScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            CompressorScanSocket.Blocking = true;
            try
            {
                CompressorScanSocket.Connect(CompressorScanPoint);
                CompressorScanSocket.Blocking = false;
                CompressorScanConn = true;
            }
            catch (SocketException ex)
            {
                CompressorScanConn = false;
                string TipInfo = string.Format("压缩机防差错压缩机扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InComIP, BaseSystemInfo.BarScanComPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }
            InComSocketThread = new Thread(CompressorSocketRecMsg);
            InComSocketThread.IsBackground = true;
            InComSocketThread.Start();
            #endregion
        }

        #endregion

        #region 扫码器获取数据
        private void CompressorSocketRecMsg()//通过Socket获取数据
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
                    length = CompressorScanSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    CompressorScanConn = true;

                }
                catch (Exception ex)
                {
                    CompressorScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (CompressorScanConn))
                {
                    HandleComBarCode(strMsg.Trim());
                }
            }
        }

        private void ProductSocketRecMsg()//通过Socket获取数据
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
                    length = ProductScanSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    ProductScanConn = true;

                }
                catch (Exception ex)
                {
                    ProductScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (ProductScanConn))
                {
                    HandleProBarCode(strMsg.Trim());
                }
            }
        }

        #endregion

        #region 数据处理
        private void HandleProBarCode(string strMsg)//产品 Socket 执行步骤
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    if (OptionSetting.CompressorCode.Length == 0)
                    {
                        lbl_MessageInfo.Text = "";
                        lbl_CompressorInfo.Text = "";
                        lbl_Com_BarCode.Text = "";
                        lbl_Pro_BarCode.Text = "";
                        lbl_ProductInfo.Text = "";
                    }
                    OptionSetting.ProductBarCode = strMsg.Trim();
                    ProScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    lbl_Pro_BarCode.Text = strMsg.Trim();
                    lbl_ProductInfo.Text = "";
                    SysBusinessFunction.WriteLog("压缩机防差错工位产品扫码记录：" + OptionSetting.ProductBarCode);
                    if (OptionSetting.ProductBarCode.ToUpper() == "NOREAD")
                    {
                        OptionSetting.ProductCode = "";
                        OptionSetting.ProductName = "";
                        lbl_MessageInfo.Text = String.Format(@"产品条码扫描失败
Product Barcode Scan Fail");
                        lbl_MessageInfo.ForeColor = Color.Red;
                        return;
                    }
                    if (OptionSetting.ProductBarCode.Trim().Length != 20)
                    {
                        OptionSetting.ProductCode = "";
                        OptionSetting.ProductName = "";
                        lbl_MessageInfo.Text = String.Format(@"产品条码格式错误
Product Barcode Format Error");
                        lbl_MessageInfo.ForeColor = Color.Red;
                        return;
                    }
                    String sql = String.Format("SELECT Material_Name FROM IMOS_TA_Material WHERE Material_Code = '{0}'",
                                                OptionSetting.ProductBarCode.Substring(0, 11));
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        OptionSetting.ProductCode = "";
                        OptionSetting.ProductName = "";
                        lbl_MessageInfo.Text = String.Format(@"产品条码错误
Product Barcode Error");
                        lbl_MessageInfo.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_ProductInfo.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        OptionSetting.ProductName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        lbl_ProductInfo.ForeColor = Color.Gold;

                        lbl_MessageInfo.Text = String.Format(@"产品条码扫码成功
Product Barcode Scan Succeed");
                        lbl_MessageInfo.ForeColor = Color.Lime;
                        OptionSetting.ProductCode = OptionSetting.ProductBarCode.Substring(0, 11);
                    }

                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog(string.Format("产品条码处理异常:" + ex.Message + OptionSetting.EnergyBarcode));
                }


            }));
        }
        private void HandleComBarCode(string strMsg)//压缩机 Socket 执行步骤
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    if (OptionSetting.ProductCode.Length == 0)
                    {
                        lbl_MessageInfo.Text = "";
                        lbl_CompressorInfo.Text = "";
                        lbl_Com_BarCode.Text = "";
                        lbl_Pro_BarCode.Text = "";
                        lbl_ProductInfo.Text = "";
                    }
                    OptionSetting.CompressorBarCode = strMsg.Trim();
                    ComScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    lbl_Com_BarCode.Text = strMsg.Trim();
                    lbl_CompressorInfo.Text = "";
                    SysBusinessFunction.WriteLog("压缩机防差错工位压缩机扫码记录：" + OptionSetting.CompressorBarCode);
                    if (OptionSetting.CompressorBarCode.ToUpper() == "NOREAD")
                    {
                        OptionSetting.CompressorCode = "";
                        OptionSetting.CompressorName = "";
                        lbl_MessageInfo.Text = String.Format(@"压缩机条码扫描失败
Compressor Barcode Scan Fail");
                        lbl_MessageInfo.ForeColor = Color.Red;
                        return;
                    }
                    if (OptionSetting.CompressorBarCode.Trim().Length != 20)
                    {
                        OptionSetting.CompressorCode = "";
                        OptionSetting.CompressorName = "";
                        lbl_MessageInfo.Text = String.Format(@"压缩机条码格式错误
Compressor Barcode Format Error");
                        lbl_MessageInfo.ForeColor = Color.Red;
                        return;
                    }
                    String sql = String.Format("SELECT Material_Name FROM IMOS_TA_Map WHERE  Material_Code = '{0}' and Material_Type = '{1}' ",
                                                OptionSetting.CompressorBarCode.Substring(0, 11), "YSJ");
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        OptionSetting.CompressorCode = "";
                        OptionSetting.CompressorName = "";
                        lbl_MessageInfo.Text = String.Format(@"压缩机条码错误
Compressor Barcode Error");
                        lbl_MessageInfo.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_CompressorInfo.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        OptionSetting.CompressorName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        lbl_CompressorInfo.ForeColor = Color.Gold;
                        lbl_MessageInfo.Text = String.Format(@"压缩机条码扫码成功
Compressor Barcode Scan Succeed");
                        lbl_MessageInfo.ForeColor = Color.Lime;

                        OptionSetting.CompressorCode = OptionSetting.CompressorBarCode.Substring(0, 11);

                    }

                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog(string.Format("压缩机条码处理异常:" + ex.Message + OptionSetting.EnergyBarcode));
                }


            }));
        }

        #endregion

        #region 验证匹配
        private void timer1_Tick(object sender, EventArgs e)//验证匹配是否正确
        {
            try
            {
                Application.DoEvents();
                if (!ProductScanConn && !CompressorScanConn)
                {
                    return;
                }
                else if (!ProductScanConn && OptionSetting.CompressorBarCode.Length != 0)
                {
                    lbl_MessageInfo.Text = String.Format(@"没有扫到产品条码
No Read Product Code");
                    lbl_MessageInfo.ForeColor = Color.Red;
                    InsertRecord(2);
                    OptionSetting.ProductBarCode = "";
                    OptionSetting.ProductName = "";
                    OptionSetting.CompressorBarCode = "";
                    OptionSetting.CompressorName = "";
                    ProScanTime = "";
                    ComScanTime = "";
                    InitChart();
                    RefreshData(2);
                    return;
                }
                else if (!CompressorScanConn && OptionSetting.ProductBarCode.Length != 0)
                {
                    lbl_MessageInfo.Text = String.Format(@"没有扫到压缩机条码
No Read Compressor Code");
                    lbl_MessageInfo.ForeColor = Color.Red;
                    InsertRecord(2);
                    OptionSetting.ProductBarCode = "";
                    OptionSetting.ProductName = "";
                    OptionSetting.CompressorBarCode = "";
                    OptionSetting.CompressorName = "";
                    ProScanTime = "";
                    ComScanTime = "";
                    InitChart();
                    RefreshData(2);
                    return;
                }
                if (OptionSetting.ProductBarCode.Length != 0 && OptionSetting.CompressorBarCode.Length != 0)
                {
                    String sql = String.Format("SELECT ID FROM IMOS_TA_Map WHERE  Material_Code = '{0}' and Material_Type = '{1}' and Product_Code = '{2}'",
                                             OptionSetting.CompressorCode, "YSJ", OptionSetting.ProductCode);

                    DataSet ds = DataHelper.Fill(sql);
                    if (ds != null && ds.Tables[0].Rows.Count != 0)
                    {
                        lbl_MessageInfo.Text = String.Format(@"匹配正确
Matching Succeed");
                        lbl_MessageInfo.ForeColor = Color.Lime;
                        InsertRecord(1);
                    }
                    else
                    {
                        String nsql = String.Format("SELECT Material_Name FROM IMOS_TA_Map WHERE   Material_Type = '{0}' and Product_Code = '{1}'",
                                             "YSJ", OptionSetting.ProductCode);
                        DataSet nds = DataHelper.Fill(nsql);
                        if (nds.Tables[0].Rows.Count != 0)
                        {
                            //                            lbl_MessageInfo.Text = String.Format(@"压缩机与冰箱不匹配，正确匹配型号：{0}
                            //Matching Error", nds.Tables[0].Rows[0]["Material_Name"].ToString());
                            lbl_MessageInfo.Text = String.Format(@"压缩机与冰箱不匹配
Compressor Doesn't Match Refrigerator");
                            lbl_MessageInfo.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbl_MessageInfo.Text = String.Format(@"压缩机与冰箱不匹配，无匹配型号。
Matching Error");
                            lbl_MessageInfo.ForeColor = Color.Red;
                        }

                        InsertRecord(2);
                    }

                    OptionSetting.ProductBarCode = "";
                    OptionSetting.ProductName = "";
                    OptionSetting.CompressorBarCode = "";
                    OptionSetting.CompressorName = "";
                    ProScanTime = "";
                    ComScanTime = "";
                    InitChart();
                    RefreshData(2);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("匹配过程出错！" + ex.Message);
            }
        }

        #endregion

        #region 插入扫码记录
        private void InsertRecord(int TypeNum)//插入扫码记录 1 正确 2 不正确
        {
            try
            {
                if (First_Flag)
                {
                    newtime = DateTime.Now;

                }
                else
                {
                    oldtime = newtime;
                    newtime = DateTime.Now;
                }
                //插入匹配数据 
                String insertsql = String.Format(@"INSERT INTO IMOS_TA_ProPre_Record (
	                                                                                Company_Code,
	                                                                                Company_Name,
	                                                                                Factory_Code,
	                                                                                Factory_Name,
	                                                                                Product_Line_Code,
	                                                                                Product_Line_Name,
                                                                                    Product_BarCode,
                                                                                    Product_Name,
	                                                                                Product_Scan_Time,
                                                                                    ComPressor_BarCode,
                                                                                    ComPressor_Name,
	                                                                                Compressor_Scan_Time,
	                                                                                Match_flag,
                                                                                    Create_Time,
                                                                                    Process_Code,
                                                                                    Process_Name,
                                                                                    Process_Name_EN
                                                                                )
                                                                                VALUES
	                                                                                ('{0}','{1}','{2}','{3}', '{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',GetDate(),'{13}','{14}','{15}')",
                                                                                BaseSystemInfo.CompanyCode,
                                                                                BaseSystemInfo.CompanyName,
                                                                                BaseSystemInfo.FactoryCode,
                                                                                BaseSystemInfo.FactoryName,
                                                                                BaseSystemInfo.ProductLineCode,
                                                                                BaseSystemInfo.ProductLineName,
                                                                                OptionSetting.ProductBarCode,
                                                                                OptionSetting.ProductName,
                                                                                ProScanTime,
                                                                                OptionSetting.CompressorBarCode,
                                                                                OptionSetting.CompressorName,
                                                                                ComScanTime,
                                                                                TypeNum,
                                                                                BaseSystemInfo.CurrentProcessCode,
                                                                                BaseSystemInfo.CurrentProcessName,
                                                                                BaseSystemInfo.CurrentProcessName_EN);
                DataHelper.Fill(insertsql);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("插入扫码数据失败");
            }
        }

        #endregion

        #region 扫码器重连
        public static void ReConnectDevice(object o)//socket重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //产品条码扫描设备连接状态
                #region
                if (!ProductScanConn)
                {
                    try
                    {
                        if (ProBarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("产品条码扫描设备断线重连中......，{0}", ProBarReConnCount.ToString()));
                        }
                        ProBarReConnCount++;
                        ProductScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ProductScanSocket.Connect(ProductScanPoint);
                        ProductScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("产品条码扫描设备重新连接成功，重连次数{0}，{1}", ProBarReConnCount, ProductScanPoint.ToString()));
                        ProBarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = ProductScanSocket.Send(arrMsgRec);
                    ProductScanConn = sLen == 1;
                }
                catch
                {
                    ProductScanConn = false;
                }
                #endregion

                //压缩机条码扫描设备连接状态

                #region
                if (!CompressorScanConn)
                {
                    try
                    {
                        if (ComBarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("压缩机条码扫描设备断线重连中......，{0}", ComBarReConnCount.ToString()));
                        }
                        ComBarReConnCount++;
                        CompressorScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        CompressorScanSocket.Connect(CompressorScanPoint);
                        CompressorScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("压缩机条码扫描设备重新连接成功，重连次数{0}，{1}", ComBarReConnCount, CompressorScanPoint.ToString()));
                        ComBarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = CompressorScanSocket.Send(arrMsgRec);
                    CompressorScanConn = sLen == 1;
                }
                catch
                {
                    CompressorScanConn = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                ReConnectDeviceTimer.Change(10000, Timeout.Infinite);
                //报警

            }
        }

        #endregion

        #region 修改计划数量
        private void txt_Scheduled_Qty_DoubleClick(object sender, EventArgs e)//双击完成修改计划数量
        {
            try
            {
                if (txt_Scheduled_Qty.Visible)
                {
                    int qty;
                    try
                    {
                        qty = int.Parse(txt_Scheduled_Qty.Text.ToString());
                    }
                    catch
                    {
                        SysBusinessFunction.SystemDialog(2, String.Format(@"请输入数字
Please Enter Numbers"));
                        return;
                    }
                    if (qty <= 0)
                    {
                        SysBusinessFunction.SystemDialog(2, String.Format(@"请输入大于0的数字
Please enter a number greater than 0"));
                        return;
                    }
                    lbl_Scheduled_Qty.Text = txt_Scheduled_Qty.Text;
                    txt_Scheduled_Qty.Visible = !txt_Scheduled_Qty.Visible;
                    lbl_Scheduled_Qty.Visible = !lbl_Scheduled_Qty.Visible;

                    String Psql = String.Format(@"UPDATE Sys_Parameters_Master SET Remark = '{0}' where Parameter_Master_Code = '{1}'and Company_Code = '{2}'and Factory_Code = '{3}'and Product_Line_Code = '{4}'",
                    txt_Scheduled_Qty.Text.ToString().Trim(), PlanName, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                    DataHelper.Fill(Psql);
                    //String Asql = String.Format(@"UPDATE Sys_Parameters_Master SET Remark = '{0}' where Parameter_Master_Code = '{1}'and Company_Code = '{2}'and Factory_Code = '{3}'and Product_Line_Code = '{4}'",
                    //  0, "ACTUALNUM", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                    //DataHelper.Fill(Asql);
                    RefreshData(2);
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("计划数量修改错误！" + ex.Message);
            }
        }

        private void lbl_Scheduled_Qty_DoubleClick(object sender, EventArgs e)//双击开始修改计划数量
        {
            try
            {
                if (lbl_Scheduled_Qty.Visible)
                {
                    txt_Scheduled_Qty.Visible = !txt_Scheduled_Qty.Visible;
                    lbl_Scheduled_Qty.Visible = !lbl_Scheduled_Qty.Visible;
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}