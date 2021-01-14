using ControlLogic;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmWeighDetail : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        public int Process_Flag = 1;//工位编号
        private int ScanAddress = 0;//扫码下传PLC地址
        private int WeightAddress = 0;//称重上传PLC地址
        private string barcode = "";//产品码
        private string Weight = "0";//实时的产品重量
        private string BeforeWeight = "0";//灌注前重量
        private string PerfusionWeigh = "0";//灌注重量
        private string Standard_Weight = "0";//标准重量
        private string Standard_Error = "0";//标准误差
        private string AfterWeight = "0";//灌注后重量
        private string DifWeight = "0";//差值
        private int Result;//结果
        private bool WeightCheckResult = false;//称重成功标志 true 称重成功  false 称重失败
        private bool WeightStartFlag = false;//称重开始标志 true 称重开始  false 称重结束
        private DateTime MarkTime = DateTime.Now;
        private System.Threading.Timer GetWeightThreadTimerA = null;
        private System.Threading.Timer GetWeightThreadTimerB = null;

        private Thread GetWeightThread = null;

        #region
        //串口扫码
        private ScanProvider _scanner;
        private ScanProvider CheckScanner;


        //A
        public bool ScanConn = false; //扫描设备连接状态
        public bool BarScanState = false; //条码扫描是否正常
        private Thread ScanSocketThread = null; // 创建用于接收服务端消息的 
        private Socket ScanSocket = null;
        private IPEndPoint ScanPoint;
        private int ScanReConnCount = 0;
        public bool SerialPortStatus = false;
        private int HisReceiveCount = 0;
        private int ReceiveCount = 0;
        public System.Threading.Timer CheckConnectionTimer;  //检查设备ONE连接状态Timer


        #endregion

        public FrmWeighDetail()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmWeighDetail_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlData.SystemInitialization();//PLC初始化
                InitScanProvider();//串口初始化
                                   //InitScanSocket();//扫码器初始化
                                   //CheckConnectionTimer = new System.Threading.Timer(CheckConnectionStatus, null, 0, Timeout.Infinite);//扫码器重连

                //switch (Process_Flag)
                //{
                //    case 1:
                //        ScanAddress = 20;
                //        WeightAddress = 30;
                //        GetWeightThreadTimerA = new System.Threading.Timer(GetWeightThreadTimerStatusA, null, 0, 500);//扫码器重连
                //        break;
                //    case 2:
                //        ScanAddress = 22;
                //        WeightAddress = 35;
                //        GetWeightThreadTimerB= new System.Threading.Timer(GetWeightThreadTimerStatusB, null, 0, 500);//扫码器重连
                //        break;
                //    case 3:
                //        ScanAddress = 24;
                //        WeightAddress = 40;
                //        GetWeightThreadTimerA = new System.Threading.Timer(GetWeightThreadTimerStatusA, null, 0, 500);//扫码器重连
                //        break;
                //    case 4:
                //        ScanAddress = 26;
                //        WeightAddress = 45;
                //        GetWeightThreadTimerB= new System.Threading.Timer(GetWeightThreadTimerStatusB, null, 0, 500);//扫码器重连
                //        break;
                //    default:
                //        SysBusinessFunction.WriteLog("配置信息错误");
                //        return;
                //}

                timer1.Interval = 300;
                timer1.Enabled = true;
                timer1.Start();
                
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 串口初始化
        public void InitScanProvider()
        {
            switch (Process_Flag)
            {
                case 1:
                    InitScanProviderDetail(BaseSystemInfo.SerialPortName1, 9600);//串口1初始化
                    break;
                case 2:
                    InitScanProviderDetail(BaseSystemInfo.SerialPortName2, 9600);//串口1初始化
                    break;
                case 3:
                    InitScanProviderDetail(BaseSystemInfo.SerialPortName3, 9600);//串口1初始化
                    break;
                case 4:
                    InitScanProviderDetail(BaseSystemInfo.SerialPortName4, 9600);//串口1初始化
                    break;
                default:
                    SysBusinessFunction.WriteLog("串口配置信息错误");
                    return;
            }


        }

        public void InitScanProviderDetail(string com, int d)
        {
            try
            {
                // 打开串口  
                _scanner = new ScanProvider(com, d);
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
                string TipInfo = string.Format("工位{0}称重串口连接出现异常.端口【{1}】波特率【{2}】，", Process_Flag, com, d);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
        }


        #endregion

        #region 扫码器初始化
        private void InitScanSocket()
        {
            switch (Process_Flag)
            {
                case 1:
                    if (ConfigHelper.GetValue("IsInitBarOne") == "1")
                    {
                        InitScanSocketDetail(ConfigHelper.GetValue("IntelligentDeviceIP1"), ConfigHelper.GetValue("IntelligentDevicePort1"));//扫码器1初始化
                    }
                    break;
                case 2:
                    if (ConfigHelper.GetValue("IsInitBarTwo") == "1")
                    {
                        InitScanSocketDetail(ConfigHelper.GetValue("IntelligentDeviceIP2"), ConfigHelper.GetValue("IntelligentDevicePort2"));//扫码器2初始化
                    }
                    break;
                case 3:
                    if (ConfigHelper.GetValue("IsInitBarThree") == "1")
                    {
                        InitScanSocketDetail(ConfigHelper.GetValue("IntelligentDeviceIP3"), ConfigHelper.GetValue("IntelligentDevicePort3"));//扫码器3初始化
                    }
                    break;
                case 4:
                    if (ConfigHelper.GetValue("IsInitBarFour") == "1")
                    {
                        InitScanSocketDetail(ConfigHelper.GetValue("IntelligentDeviceIP4"), ConfigHelper.GetValue("IntelligentDevicePort4"));//扫码器4初始化
                    }
                    break;
                default:
                    SysBusinessFunction.WriteLog("扫码器配置信息错误");
                    return;
            }

        }

        private void InitScanSocketDetail(string SocketIP, string SocketPort)
        {

            IPAddress SanIP = IPAddress.Parse(SocketIP);//IP
            ScanPoint = new IPEndPoint(SanIP, int.Parse(SocketPort));//端口
            ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocket.Blocking = true;
            try
            {
                ScanSocket.Connect(ScanPoint);
                ScanConn = true;
            }
            catch (SocketException ex)
            {
                ScanConn = false;
                string TipInfo = string.Format("条码扫描设备【】连接出现异常.IP地址{0}端口{1}，", Process_Flag, SanIP, ScanPoint);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThread = new Thread(ScanRecMsg);
            ScanSocketThread.IsBackground = true;
            ScanSocketThread.Start();
        }
        #endregion

        #region 重连扫码器
        private void CheckConnectionStatus(object o)
        {
            try
            {
                Thread.Sleep(5);
                SerialPortStatus = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCount = ReceiveCount;
                byte[] arrMsgRec = new byte[1];
                #region 条码扫描
                if (!ScanConn)
                {
                    try
                    {
                        if (ScanReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPoint.ToString()));
                        }
                        ScanReConnCount++;
                        ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocket.Blocking = true;
                        ScanSocket.Connect(ScanPoint);
                        ScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCount, ScanPoint.ToString()));
                        ScanReConnCount = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = ScanSocket.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConn = sLen == 1;
                }
                catch
                {
                    ScanConn = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }

        #endregion

        #region 通讯数据处理

        #region  串口数据处理
        private void _scanner_DataReceived(object sender, SerialSortEventArgs e)
        {
            BeginInvoke(new Action<string>(args =>
            {


                try
                {
                    if (args.Length != 16)
                    {
                        WeightCheckResult = false;
                        Weight = "0";
                        return;
                    }
                    else
                    {
                        WeightCheckResult = true;

                    }
                    //获取数据
                    string s = args.ToString().Replace("kg", "  ").Trim();
                    lbl_Cycle.Text = Regex.Replace(s, @"[^\d]*", ""); //去掉“非数字KG”
                    Weight = s;
                    lbl_Cycle.Text = Weight;

                    //SysBusinessFunction.WriteLog(args.ToString());
                    //连续输出解析
                    //string s = args.ToString().Substring(args.IndexOf("=") + 1).Replace(" ", "");
                    //double n = double.Parse(s) / 1000000000;
                    //lbl_Cycle.Text = n.ToString("0.000");
                }
                catch (Exception ex)
                {

                }
                //OptionSetting.PWeigh = n.ToString("0.000");
               
            }), e.Code);

        }
        #endregion

        #region 扫码器数据获取
        public void ScanRecMsg()
        {
            try
            {
                string strMsg = "";
                while (true)
                {
                    Thread.Sleep(5);
                    byte[] arrMsgRec = new byte[50];
                    // 将接收到的数据存入到输入  arrMsgRec中；  
                    int length = -1;
                    try
                    {
                        length = ScanSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConn = true;
                    }
                    catch
                    {
                        //  SysBusinessFunction.WriteLog("产品码扫码器心跳信息号失败.");
                        ScanConn = false;
                        continue;
                    }

                    if ((strMsg.Trim().Length > 4) && (ScanConn) && strMsg.Trim() != "NO READ")
                    {
                        barcode = strMsg.Trim();//获取条码  
                        BarCodeDataHandle(barcode);

                    }
                    else
                    {
                        lbl_Msg.Text = "";
                        barcode = "";
                        PerfusionWeigh = "0";
                        Standard_Weight = "0";
                        Standard_Error = "0";
                        BeforeWeight = "0";
                        AfterWeight = "0";
                        Result = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("【{0}】产品码读取异常{1}", Process_Flag, ex.ToString()));
            }
        }
        #endregion

        #region 扫码器数据处理
        private void BarCodeDataHandle(string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    SysBusinessFunction.WriteLog(string.Format("一号工位产品条码【{0}】", code));
                    lbl_barcode.Text = code;
                    string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                                                                       //查询物料信息
                    string MaterialSQL = string.Format(@"SELECT  Material_Code,Material_Name  
                                                         FROM IMOS_TA_Material 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                    DataSet ds = DataHelper.Fill(MaterialSQL);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_Name.Text = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        string sMaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        //查询标准重量和标准误差
                        string sSQL = string.Format(@"SELECT  Standard_Value,Standard_Error  
                                                         FROM IMOS_TA_WeighStandard 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                        DataSet ds2 = DataHelper.Fill(sSQL);
                        if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            Standard_Weight = ds2.Tables[0].Rows[0]["Standard_Value"].ToString();
                            Standard_Error = ds2.Tables[0].Rows[0]["Standard_Error"].ToString();
                            lbl_Standard_Tolerance.Text = Standard_Weight + "/" + Standard_Error;
                        }
                        else
                        {
                            lbl_Msg.Text = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位产品条码【{0}】的标准重量或标准误差未维护", code);
                            return;
                        }
                        //上传数据到数据库
                        string ssSQL = string.Format(@"INSERT INTO [IMOS_PR_Weigh]
                                                   ([Company_Code]
                                                    ,[Company_Name]
                                                    ,[Factory_Code]
                                                    ,[Factory_Name]
                                                    ,[Product_Line_Code]
                                                    ,[Product_Line_Name]
                                                    ,[Process_Code]
                                                    ,[Process_Name]
                                                    ,[Product_BarCode]
                                                    ,[Material_Code]
                                                    ,[Material_Name]
                                                    ,[Station_No]
                                                    ,[Standard_Value]
                                                    ,[Standard_Error]  
                                                    ,[Scan_Time_Before]                                                                                                        
                                                    )
                                                    VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}','{5}'
                                                    ,'{6}','{7}','{8}','{9}','{10}',{11},{12},{13},GETDATE())",
                                                                BaseSystemInfo.CompanyCode,
                                                                BaseSystemInfo.CompanyName,
                                                                BaseSystemInfo.FactoryCode,
                                                                BaseSystemInfo.FactoryName,
                                                                BaseSystemInfo.ProductLineCode,
                                                                BaseSystemInfo.ProductLineName,
                                                                BaseSystemInfo.CurrentProcessCode,
                                                                BaseSystemInfo.CurrentProcessName,
                                                                barcode,
                                                                sMaterialCode,
                                                                sMaterialName,
                                                                BaseSystemInfo.CurrentStationNo1,
                                                                Standard_Weight,
                                                                Standard_Error);
                        DataSet ds1 = DataHelper.Fill(ssSQL);
                        DownScanPLC();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {


                }
            }));

        }
        #endregion

        #endregion

        #region 扫码完成信息下传
        private void DownScanPLC()
        {
            try
            {
                int Block = 0;
                int Len = 2;
                object[] Buf = new object[Len];
                bool PLCWrite = ControlData.MasterPLC.Write(Block, ScanAddress, Buf);
                if (!PLCWrite)
                {
                    SysBusinessFunction.WriteLog(String.Format("@【{0}】工位写入称重PLC连接标志位失败！", Process_Flag));
                    return;
                }
                object[] RBuf = new object[Len];
                int LinerCount = GetTickCount();
                while (true)
                {
                    Thread.Sleep(5);
                    Application.DoEvents();
                    //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                    if (GetTickCount() - LinerCount > 5000) //超时处理
                    {
                        lbl_Msg.Text = "下传信号成功，等待反馈信号超时";
                        SysBusinessFunction.WriteLog("下传信号成功，等待反馈信号超时");
                        break;
                    }
                    bool PLCRead = ControlData.MasterPLC.Read(Block.ToString(), ScanAddress, Len, out RBuf);
                    if (RBuf[0].ToString() == "2")
                    {
                        object[] WBuf = new object[1];
                        WBuf[0] = 0;
                        ControlData.MasterPLC.Write(Block, ScanAddress, WBuf);
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region timer1实时获取PLC数据 （换成线程）

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                GetWeightPLC();
                if (WeightStartFlag)
                {
                    UpPLC();
                }
               
            }
            catch
            {

            }
        }

        #endregion

        #region 核心业务逻辑

        #region 获取PLC称重信号

        private void GetWeightPLC()
        {
            try
            {
                int Block = 0;
                int Len = 4;
                object[] Buf = new object[Len];
                bool PLCRead = ControlData.MasterPLC.Read(Block.ToString(), WeightAddress, Len, out Buf);
                if (!PLCRead)
                {
                    SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】读取PLC称重信号失败!!", Process_Flag));
                    return;
                }
                object[] WBuf = new object[1];
                WBuf[0] = 2;
                if ("1".Equals(Buf[0].ToString()))
                {
                    ControlData.MasterPLC.Write(Block, WeightAddress, WBuf);
                    SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】条码【{1}】称重开启信号接受成功！！", Process_Flag, barcode));
                }

                if ("1".Equals(Buf[2].ToString()))
                {
                    //ProviderWrite();
                    WBuf[0] = 0;
                    ControlData.MasterPLC.Write(Block, WeightAddress + 2, WBuf);
                    SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】条码【{1}】开始称重！！", Process_Flag,barcode));
                    WeightStartFlag = true;

                }else
                {
                    WeightStartFlag = false;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("从PLC获取灌注称重记录失败！");
            }
        }

        private void UpPLC()
        {
            try
            {
                int Len = 4;
                object[] Buf = new object[Len];

                object[] WBuf = new object[1];
                int Block = 0;
                ControlData.MasterPLC.Read(Block.ToString(), WeightAddress, Len, out Buf);

                if ("1".Equals(Buf[1].ToString()))
                {
                    BeforeWeight = Weight;
                    if (!WeightCheckResult || Weight == "0")
                    {
                        lbl_Msg.Text = String.Format(@"称重错误！！\r\n Weight Error!!");
                        lbl_Msg.ForeColor = Color.Red;
                        WBuf[0] = 2;
                        ControlData.MasterPLC.Write(Block, WeightAddress + 3, WBuf);
                        SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】称重【{1}】失败.....等待重新称重！！", Process_Flag, barcode));
                        return;
                    }
                    lbl_Weighing_Weight.Text = BeforeWeight + "/" + "0";
                    SysBusinessFunction.WriteLog(String.Format(@"条码【{0}】灌注前称重【{1}】！！", barcode, BeforeWeight));
                    WBuf[0] = 1;
                    ControlData.MasterPLC.Write(Block, WeightAddress + 3, WBuf);
                    SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】称重【{1}】称重成功！！", Process_Flag, barcode));
                }
                else if ("2".Equals(Buf[1].ToString()))
                {
                    if (!WeightCheckResult || Weight == "0")
                    {
                        lbl_Msg.Text = String.Format(@"称重错误！！\r\n Weight Error!!");
                        lbl_Msg.ForeColor = Color.Red;
                        WBuf[0] = 2;
                        ControlData.MasterPLC.Write(Block, WeightAddress + 3, WBuf);
                        SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】称重【{1}】失败.....等待重新称重！！", Process_Flag, barcode));
                        return;
                    }
                    AfterWeight = Weight;
                    lbl_Weighing_Weight.Text = BeforeWeight + "/" + AfterWeight;
                    SysBusinessFunction.WriteLog(String.Format(@"条码【{0}】灌注后称重【{1}】！！", barcode, AfterWeight));
                    WBuf[0] = 1;
                    ControlData.MasterPLC.Write(Block, WeightAddress + 3, WBuf);
                    MainDo(WeightAddress + 4);
                }
                else
                {
                    lbl_Msg.Text = String.Format(@"PLC写入错误！！\n\r PLC Write Error!!");
                    lbl_Msg.ForeColor = Color.Red;
                    SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】PLC写入错误！！", Process_Flag));
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ProviderWrite()
        {
            try
            {
                byte[] NormalDataBuff = System.Text.Encoding.Default.GetBytes("P");
                _scanner.Write(NormalDataBuff, 0, NormalDataBuff.Length);

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 称重检测
        private void MainDo(int address)
        {
            try
            {
                decimal bw = decimal.Parse(BeforeWeight);//灌注前重量
                decimal aw = decimal.Parse(AfterWeight);//灌注后重量
                decimal pw = decimal.Parse(PerfusionWeigh);//灌注机重量
                decimal sv = decimal.Parse(Standard_Weight);//标准重量
                decimal se = decimal.Parse(Standard_Error);//误差
                decimal dv = Math.Abs(aw - bw); //前后重量差值
                DifWeight = dv.ToString();
                //lbl_Weighing_WeightA.Text = bw.ToString() + "/" + aw.ToString();
                int Result_Flag = 0; //0 合格 1 前后重量差值不对  2 灌注重量不对  3 前后重量和灌注重量都不对
                SysBusinessFunction.WriteLog(String.Format(@"工位【{0}】灌注机提供的灌注重量为{1},前后称重的差值为{2}", Process_Flag, pw, dv));

                if (dv < (sv - se) || dv > (sv + se))//前后重量差值和标准重量比较
                {
                    Result_Flag = Result_Flag + 1;
                }
                //if (pw < (sv - se) || pw > (sv + se))//灌注重量和标准重量比较
                //{
                //    Result_Flag = Result_Flag + 2;
                //}

                if (Result_Flag == 0)
                {
                    lbl_Msg.ForeColor = Color.Lime;
                    lbl_Msg.Text = "灌注成功！" + "\n\r\n\r" + "Perfusion success！";
                    Result = 1;
                }
                else if (Result_Flag == 1)
                {
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Msg.Text = "灌注失败:前后称重差值与标准重量相比存在误差！" + "\n\r\n\r" + "ERROR:Weight difference！";
                    Result = 2;
                }
                else if (Result_Flag == 2)
                {
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Msg.Text = "灌注失败:灌注重量与标准重量相比存在误差！" + "\n\r\n\r" + "ERROR:Perfusion weight！";
                    Result = 2;
                }
                else
                {
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Msg.Text = "灌注失败:前后称重差值与灌注重量都不正确！" + "\n\r\n\r" + "ERROR:Weight difference and perfusion weight！";
                    Result = 2;
                }
                SysBusinessFunction.WriteLog(lbl_Msg.Text);
                object[] WBuff = new object[1];
                WBuff[0] = Result;
                ControlData.MasterPLC.Write(0, address, WBuff);
                //修改数据
                //UpdateData(PerfusionWeighA);
                //清空数据
                barcode = "";
                PerfusionWeigh = "0";
                Standard_Weight = "0";
                Standard_Error = "0";
                BeforeWeight = "0";
                AfterWeight = "0";
                Result = 0;
            }
            catch
            {

            }

        }
        #endregion

        #endregion

        #region  线程获取数据

        private void GetWeightThreadTimerStatusA(object o)
        {
            try
            {
                
                ProviderWrite();
            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimer.Change(1000,300 );
            }
        }

        private void GetWeightThreadTimerStatusB(object o)
        {
            try
            {

                ProviderWrite();
            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimer.Change(1000, 300);
            }
        }
        #endregion
    }
}