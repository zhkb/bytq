using System;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLogic
{
    public class ControlWeightInfoData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        #region 变量定义
        //A
        public static bool ScanConnOne = false; //扫描设备连接状态
        public static bool BarScanStateOne = false; //条码扫描是否正常
        private static Thread ScanSocketThreadOne = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocketOne = null;
        private static IPEndPoint ScanPointOne;
        private static int ScanReConnCountOne = 0;
        public static bool SerialPortStatusOne = false;
        private static int HisReceiveCountOne = 0;
        private static int ReceiveCountOne = 0;
        public static System.Threading.Timer CheckConnectionTimerOne;  //检查设备ONE连接状态Timer

        //B
        public static bool ScanConnTwo = false; //扫描设备连接状态
        public static bool BarScanStateTwo = false; //条码扫描是否正常
        private static Thread ScanSocketThreadTwo = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocketTwo = null;
        private static IPEndPoint ScanPointTwo;
        private static int ScanReConnCountTwo = 0;
        public static bool SerialPortStatusTwo = false;
        private static int HisReceiveCountTwo = 0;
        private static int ReceiveCountTwo = 0;
        public static System.Threading.Timer CheckConnectionTimerTwo;  //检查设备ONE连接状态Timer

        //C
        //充氮前称重设备
        public static bool BMaterInterConn = false; //充氮前称重设备连接状态
        public static bool BBarInterState = false; //充氮前称重是否正常
        private static Thread BInterSocketThread = null; // 创建用于接收服务端消息的 
        private static Socket BInterSocket = null;
        private static IPEndPoint BInterPoint;
        private static int BInterReConnCount = 0;
        public static bool BSerialPortStatus = false;
        private static int BInterHisReceiveCount = 0;
        private static int BInterReceiveCount = 0;
        public static System.Threading.Timer CheckBInterConnectionTimer;  //检查充氮前称重设备连接状态Timer
        public static System.Threading.Timer GetPLCFlagTimer1; //读取plc标志位（充氮前）

        //D
        //充氮后称重设备
        public static bool AMaterInterConn = false; //充氮后称重设备连接状态
        public static bool ABarInterState = false; //充氮后称重是否正常
        private static Thread AInterSocketThread = null; // 创建用于接收服务端消息的 
        private static Socket AInterSocket = null;
        private static IPEndPoint AInterPoint;
        private static int AInterReConnCount = 0;
        public static bool ASerialPortStatus = false;
        private static int AInterHisReceiveCount = 0;
        private static int AInterReceiveCount = 0;
        public static System.Threading.Timer CheckAInterConnectionTimer;  //检查充氮后称重设备连接状态Timer
        public static System.Threading.Timer GetPLCFlagTimer2; //读取plc标志位（充氮后）

        //串口扫码
        private static ScanProvider _scannerA;
        private static ScanProvider CheckScannerA;

        private static ScanProvider _scannerB;
        private static ScanProvider CheckScannerB;


        #endregion

        #region 初始化
        public static void SystemInitialization()//初始化
        {

            if (ConfigHelper.GetValue("IsInitBarOne") == "1")
            {
                InitOne();
                CheckConnectionTimerOne = new System.Threading.Timer(CheckConnectionStatusOne, null, 0, Timeout.Infinite);//扫码器 产品码A
            }
            if (ConfigHelper.GetValue("IsInitBarTwo") == "1")
            {
                InitTwo();
                CheckConnectionTimerTwo = new System.Threading.Timer(CheckConnectionStatusTwo, null, 0, Timeout.Infinite);//扫码器 产品码B
            }
            if (ConfigHelper.GetValue("IsInitBarThree") == "1")
            {
                InitBInter();
                CheckBInterConnectionTimer = new System.Threading.Timer(CheckBInterConnectionStatus, null, 0, Timeout.Infinite);//扫码器 产品码A
                GetPLCFlagTimer1 = new System.Threading.Timer(GetPLCFlag1, null, 0, Timeout.Infinite);
            }
            if (ConfigHelper.GetValue("IsInitBarFour") == "1")
            {
                InitAInter();
                CheckAInterConnectionTimer = new System.Threading.Timer(CheckAInterConnectionStatus, null, 0, Timeout.Infinite);//扫码器 产品码B
                GetPLCFlagTimer2 = new System.Threading.Timer(GetPLCFlag2, null, 0, Timeout.Infinite);
            }
            InitScanProvider();
        }
        #endregion

        #region
        public static void InitScanProvider ()
        {
            try
            {
                // 打开串口  
                _scannerA = new ScanProvider(BaseSystemInfo.SerialPortName1, 9600);
                Task task = new Task(() =>
                {
                    // 打开串口  
                    if (_scannerA.Open())
                        //关联事件处理程序  
                        _scannerA.DataReceived += _scanner_DataReceivedA;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("工位A称重串口连接出现异常.端口【{0}】波特率【{1}】，", BaseSystemInfo.SerialPortName1, 9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
            try
            {
                // 打开串口  
                _scannerB = new ScanProvider(BaseSystemInfo.SerialPortName2, 9600);
                Task task = new Task(() =>
                {
                    // 打开串口  
                    if (_scannerB.Open())
                        //关联事件处理程序  
                        _scannerB.DataReceived += _scanner_DataReceivedB;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("工位B称重串口连接出现异常.端口【{0}】波特率【{1}】，", BaseSystemInfo.SerialPortName2, 9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
        }
        #endregion

        /// <summary>
        /// 接收扫码枪信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void _scanner_DataReceivedA(object sender, SerialSortEventArgs e)
        {
           try
            {

            }
            catch
            {

            }
              
        }
        private static void _scanner_DataReceivedB(object sender, SerialSortEventArgs e)
        {


        }


        #region 扫码器 产品码A

        #region 初始化
        private static void InitOne()
        {
            IPAddress SanIPOne = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP1"));//IP
            ScanPointOne = new IPEndPoint(SanIPOne, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort1")));//端口
            ScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocketOne.Blocking = true;
            try
            {
                ScanSocketOne.Connect(ScanPointOne);
                ScanConnOne = true;
            }
            catch (SocketException ex)
            {
                ScanConnOne = false;
                string TipInfo = string.Format("A条码扫描设备连接出现异常.IP地址{0}端口{1}，", SanIPOne, ScanPointOne);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThreadOne = new Thread(ScanRecMsgOne);
            ScanSocketThreadOne.IsBackground = true;
            ScanSocketThreadOne.Start();
        }
        #endregion

        #region 重连
        private static void CheckConnectionStatusOne(object o)
        {
            try
            {
                Thread.Sleep(5);
                SerialPortStatusOne = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCountOne = ReceiveCountOne;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!ScanConnOne)
                {
                    try
                    {
                        if (ScanReConnCountOne == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPointOne.ToString()));
                        }
                        ScanReConnCountOne++;
                        ScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketOne.Blocking = true;
                        ScanSocketOne.Connect(ScanPointOne);
                        ScanConnOne = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCountOne, ScanPointOne.ToString()));
                        ScanReConnCountOne = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = ScanSocketOne.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConnOne = sLen == 1;
                }
                catch
                {
                    ScanConnOne = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimerOne.Change(10000, Timeout.Infinite);
            }
        }

        #endregion

        #region 数据获取
        public static void ScanRecMsgOne()
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
                        length = ScanSocketOne.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConnOne = true;
                    }
                    catch
                    {
                        //  SysBusinessFunction.WriteLog("产品码扫码器心跳信息号失败.");
                        ScanConnOne = false;
                        continue;
                    }

                    if ((strMsg.Trim().Length > 4) && (ScanConnOne) && strMsg.Trim() != "NO READ")
                    {
                        string code = strMsg.Trim();//获取条码  
                        OptionSetting.ScanFlagA = true;                   
                        BarCodeOneDataHandle(code);
                       
                    }
                    else
                    {
                        OptionSetting.ScanFlagA = true;
                        OptionSetting.MsgInfoA = "一号工位产品码读取失败！";
                        OptionSetting.ProBarCodeA = "";
                        OptionSetting.ProductModeA = "";
                        OptionSetting.CurrentWeight1 = "";
                        OptionSetting.CurrentWeightA = 0;
                        OptionSetting.TempStandWeightA = 0;
                        OptionSetting.TempToleranceA = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("一号工位产品码读取异常", ex.ToString()));
            }
        }


        #endregion

        #endregion

        #region 扫码器 产品码B

        #region 初始化

        private static void InitTwo()
        {
            IPAddress SanIPTwo = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP2"));//IP
            ScanPointTwo = new IPEndPoint(SanIPTwo, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort2")));//端口
            ScanSocketTwo = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocketTwo.Blocking = true;
            try
            {
                ScanSocketTwo.Connect(ScanPointTwo);
                ScanConnTwo = true;
            }
            catch (SocketException ex)
            {
                ScanConnTwo = false;
                string TipInfo = string.Format("B条码扫描设备连接出现异常.IP地址{0}端口{1}，", SanIPTwo, ScanPointTwo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThreadTwo = new Thread(ScanRecMsgTwo);
            ScanSocketThreadTwo.IsBackground = true;
            ScanSocketThreadTwo.Start();
        }
        #endregion

        #region 重连

        private static void CheckConnectionStatusTwo(object o)
        {
            try
            {
                Thread.Sleep(5);

                SerialPortStatusTwo = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCountTwo = ReceiveCountTwo;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!ScanConnTwo)
                {
                    try
                    {
                        if (ScanReConnCountTwo == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPointTwo.ToString()));
                        }
                        ScanReConnCountTwo++;
                        ScanSocketTwo = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketTwo.Blocking = true;
                        ScanSocketTwo.Connect(ScanPointTwo);
                        ScanConnTwo = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCountTwo, ScanPointTwo.ToString()));
                        ScanReConnCountTwo = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = ScanSocketTwo.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConnTwo = sLen == 1;
                }
                catch
                {
                    ScanConnTwo = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimerTwo.Change(10000, Timeout.Infinite);
            }
        }

        #endregion

        #region 数据获取

        private static void ScanRecMsgTwo()
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
                        length = ScanSocketTwo.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConnTwo = true;
                    }
                    catch
                    {
                        // SysBusinessFunction.WriteLog("托盘码扫码器心跳信息号失败.");
                        ScanConnTwo = false;
                        continue;
                    }

                    if ((strMsg.Trim().Length > 4) && (ScanConnTwo) && strMsg.Trim() != "NO READ")
                    {
                        string code = strMsg.Trim();//获取条码
                        OptionSetting.ScanFlagB = true;                     
                        BarCodeTwoDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.ScanFlagB = true;
                        OptionSetting.MsgInfoB = "二号工位产品码读取失败！";
                        OptionSetting.ProBarCodeB = "";
                        OptionSetting.ProductModeB = "";
                        OptionSetting.CurrentWeight2 = "";
                        OptionSetting.CurrentWeightB = 0;
                        OptionSetting.TempStandWeightB = 0;
                        OptionSetting.TempToleranceB = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(string.Format("二号工位产品码读取异常", ex.ToString()));
            }
        }
        #endregion


        #endregion

        #region 产品码处理
        private static void BarCodeOneDataHandle(string code)
        {
            try
            {
                SysBusinessFunction.WriteLog(string.Format("一号工位产品条码【{0}】", code));
                OptionSetting.ProBarCodeA = code;
                OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位读取产品条码【{0}】成功", code);
                string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                //查询物料信息
                string MaterialSQL = string.Format(@"SELECT  Material_Code,Material_Name  
                                                         FROM IMOS_TA_Material 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                DataSet ds = DataHelper.Fill(MaterialSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.ProductModeA = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                    string sMaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                    //查询标准重量和标准误差
                    string sSQL = string.Format(@"SELECT  Standard_Value,Standard_Error  
                                                         FROM IMOS_TA_WeighStandard 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                    DataSet ds2 = DataHelper.Fill(sSQL);
                    if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        OptionSetting.TempStandWeightA = Decimal.Parse(ds2.Tables[0].Rows[0]["Standard_Value"].ToString());
                        OptionSetting.TempToleranceA = Decimal.Parse(ds2.Tables[0].Rows[0]["Standard_Error"].ToString());
                    }
                    else
                    {
                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位产品条码【{0}】的标准重量或标准误差未维护", code);
                        OptionSetting.ProductModeA = "";
                        OptionSetting.CurrentWeight1 = "";
                        OptionSetting.CurrentWeightA = 0;
                        OptionSetting.TempStandWeightA = 0;
                        OptionSetting.TempToleranceA = 0;
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
                                                            OptionSetting.ProBarCodeA,
                                                            OptionSetting.ProductModeA,
                                                            sMaterialName,
                                                            BaseSystemInfo.CurrentStationNo1,
                                                            OptionSetting.TempStandWeightA,
                                                            OptionSetting.TempToleranceA);
                    DataSet ds1 = DataHelper.Fill(ssSQL);
                   
                }
                else
                {
                    OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位产品条码【{0}】的产品型号未维护", code);
                    OptionSetting.ProductModeA = "";
                    OptionSetting.CurrentWeight1 = "";
                    OptionSetting.CurrentWeightA = 0;
                    OptionSetting.TempStandWeightA = 0;
                    OptionSetting.TempToleranceA = 0;
                }
             }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog("一号工位接收条码异常！" + ex.Message);
                OptionSetting.ProductModeA = "";
                OptionSetting.CurrentWeight1 = "";
                OptionSetting.CurrentWeightA = 0;
                OptionSetting.TempStandWeightA = 0;
                OptionSetting.TempToleranceA = 0;
            }
         
        }

        private static void BarCodeTwoDataHandle(string code)
        {
            try
            {
                SysBusinessFunction.WriteLog(string.Format("二号工位产品条码【{0}】", code));
                OptionSetting.ProBarCodeB = code;
                OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位读取产品条码【{0}】成功", code);
                string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                //查询物料信息
                string MaterialSQL = string.Format(@"SELECT  Material_Code,Material_Name  
                                                         FROM IMOS_TA_Material 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                DataSet ds = DataHelper.Fill(MaterialSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.ProductModeB = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                    string sMaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                    //查询标准重量和标准误差
                    string sSQL = string.Format(@"SELECT  Standard_Value,Standard_Error  
                                                         FROM IMOS_TA_WeighStandard 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                    DataSet ds2 = DataHelper.Fill(sSQL);
                    if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        OptionSetting.TempStandWeightB = Decimal.Parse(ds2.Tables[0].Rows[0]["Standard_Value"].ToString());
                        OptionSetting.TempToleranceB = Decimal.Parse(ds2.Tables[0].Rows[0]["Standard_Error"].ToString());
                    }
                    else
                    {
                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位产品条码【{0}】的标准重量或标准误差未维护", code);
                        OptionSetting.ProductModeB = "";
                        OptionSetting.CurrentWeight2 = "";
                        OptionSetting.CurrentWeightB = 0;
                        OptionSetting.TempStandWeightB = 0;
                        OptionSetting.TempToleranceB = 0;
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
                                                            OptionSetting.ProBarCodeB,
                                                            OptionSetting.ProductModeB,
                                                            sMaterialName,
                                                            BaseSystemInfo.CurrentStationNo2,
                                                            OptionSetting.TempStandWeightB,
                                                            OptionSetting.TempToleranceB);
                    DataSet ds1 = DataHelper.Fill(ssSQL);
                    
                }
                else
                {
                    OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位产品条码【{0}】的产品型号未维护", code);
                    OptionSetting.ProductModeB = "";
                    OptionSetting.CurrentWeight2 = "";
                    OptionSetting.CurrentWeightB = 0;
                    OptionSetting.TempStandWeightB = 0;
                    OptionSetting.TempToleranceB = 0;
                }
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog("二号工位接收条码异常！" + ex.Message);
                OptionSetting.ProductModeB = "";
                OptionSetting.CurrentWeight2 = "";
                OptionSetting.CurrentWeightB = 0;
                OptionSetting.TempStandWeightB = 0;
                OptionSetting.TempToleranceB = 0;
            }

        }
        #endregion

        #region 充氮前称重

        #region 初始化
        private static void InitBInter()
        {
            IPAddress BSocketIP = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP3"));//IP 
            BInterPoint = new IPEndPoint(BSocketIP, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort3")));//端口
            BInterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BInterSocket.Blocking = true;
            try
            {
                BInterSocket.Connect(BInterPoint);
                BMaterInterConn = true;
            }
            catch (SocketException ex)
            {
                BMaterInterConn = false;
                string TipInfo = string.Format("充氮前称重设备连接出现异常.IP地址{0}端口{1}，", BSocketIP, BInterPoint);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            BInterSocketThread = new Thread(BInterRecMsg);
            BInterSocketThread.IsBackground = true;
            BInterSocketThread.Start();
        }
        #endregion

        #region 数据获取
        private static void BInterRecMsg()
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
                    length = BInterSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    BMaterInterConn = true;
                }
                catch
                {
                    //SysBusinessFunction.WriteLog("发泡前称重设备心跳信息号失败.");
                    BMaterInterConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (BMaterInterConn))
                {
                    //SysBusinessFunction.MonitorInfoInstance.BRealWeight = double.Parse(strMsg.Trim());
                    //SysBusinessFunction.MonitorInfoInstance.BActualWeight = double.Parse(strMsg.Trim());
                    //UpdateBData();
                    string code = strMsg.Trim();
                    OptionSetting.CurrentWeight1 = code;  
                }
                else
                {
                    SysBusinessFunction.WriteLog("发泡前称重设备读取称量信息失败，请重新读取！");
                }
            }
        }
        #endregion

        #region 重连
        private static void CheckBInterConnectionStatus(object o)
        {
            try
            {
                Thread.Sleep(5);

                BSerialPortStatus = true;
                BInterHisReceiveCount = BInterReceiveCount;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!BMaterInterConn)
                {
                    try
                    {
                        if (BInterReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("充氮前称重设备断线重连中......，{0}", BInterPoint.ToString()));
                        }
                        BInterReConnCount++;
                        BInterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        BInterSocket.Blocking = true;
                        BInterSocket.Connect(BInterPoint);
                        BMaterInterConn = true;
                        SysBusinessFunction.WriteLog(string.Format("充氮前称重设备重新连接成功，重连次数{0}，{1}", BInterReConnCount, BInterPoint.ToString()));
                        BInterReConnCount = 0;
                    }
                    catch (SocketException ex)
                    {

                    }
                }

                try
                {
                    int sLen = BInterSocket.Send(arrMsgRec); //检测发送与接收数据的
                    BMaterInterConn = sLen == 1;
                }
                catch
                {
                    BMaterInterConn = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckBInterConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #endregion

        #region 充氮后称重        

        #region 初始化
        private static void InitAInter()
        {
            IPAddress ASocketIP = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP4"));//IP 
            AInterPoint = new IPEndPoint(ASocketIP, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort4")));//端口
            AInterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            AInterSocket.Blocking = true;
            try
            {
                AInterSocket.Connect(AInterPoint);
                AMaterInterConn = true;
            }
            catch (SocketException ex)
            {
                AMaterInterConn = false;
                string TipInfo = string.Format("充氮后称重设备连接出现异常.IP地址{0}端口{1}，", ASocketIP, AInterPoint);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            AInterSocketThread = new Thread(AInterRecMsg);
            AInterSocketThread.IsBackground = true;
            AInterSocketThread.Start();
        }
        #endregion

        #region 数据获取
        private static void AInterRecMsg()
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
                    length = AInterSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    //if (arrMsgRec[0].ToString() == "1" && arrMsgRec[1].ToString() == "3" && arrMsgRec[2].ToString() == "1" && arrMsgRec[3].ToString() == "0")
                    //{
                    //    strMsg = arrMsgRec[4].ToString() + arrMsgRec[5].ToString() + arrMsgRec[6].ToString() + arrMsgRec[7].ToString() + "." + arrMsgRec[8].ToString();
                    //    if (double.Parse(strMsg) == 0)
                    //        continue;
                    //}
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    AMaterInterConn = true;
                }
                catch
                {
                    //SysBusinessFunction.WriteLog("充氮后称重设备心跳信息号失败.");
                    AMaterInterConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (AMaterInterConn))
                {
                    //SysBusinessFunction.MonitorInfoInstance.ARealWeight = double.Parse(strMsg.Trim());
                    //SysBusinessFunction.MonitorInfoInstance.AActualWeight = double.Parse(strMsg.Trim());
                    //UpdateAData();
                    string code = strMsg.Trim();
                    OptionSetting.CurrentWeight2 = code; 
                }
                else
                {
                    SysBusinessFunction.WriteLog("充氮后称重设备读取称量信息失败，请重新读取！");
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

        #region 重连
        private static void CheckAInterConnectionStatus(object o)
        {
            try
            {
                Thread.Sleep(5);

                ASerialPortStatus = true;
                AInterHisReceiveCount = AInterReceiveCount;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!AMaterInterConn)
                {
                    try
                    {
                        if (AInterReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("充氮后称重设备断线重连中......，{0}", AInterPoint.ToString()));
                        }
                        AInterReConnCount++;
                        AInterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        AInterSocket.Blocking = true;
                        AInterSocket.Connect(AInterPoint);
                        AMaterInterConn = true;
                        SysBusinessFunction.WriteLog(string.Format("充氮后称重设备重新连接成功，重连次数{0}，{1}", AInterReConnCount, AInterPoint.ToString()));
                        AInterReConnCount = 0;
                    }
                    catch (SocketException ex)
                    {

                    }
                }

                try
                {
                    int sLen = AInterSocket.Send(arrMsgRec); //检测发送与接收数据的
                    AMaterInterConn = sLen == 1;
                }
                catch
                {
                    AMaterInterConn = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckAInterConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion


        #endregion

        #region 1号工位PLC请求监控       
        public static void GetPLCFlag1(object o)
        {
            try
            {
                Thread.Sleep(10);

                int Address = int.Parse(BaseSystemInfo.WeightAddressA1);
                int Block = 0;
                int Len = 1;
                object[] Buf = new object[Len];

                bool PLCRead = ControlData.MasterPLC.Read(Block.ToString(), Address, Len, out Buf);
                if (!PLCRead)
                {
                    OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位读取充氮前PLC请求标志位失败！");
                    return;
                }               
                if ((int)Buf[0] == 1)//上位机接收到PLC上传的灌注前称量完成标记1后，获取称重仪器的称量结果
                {
                    OptionSetting.CurrentWeightA = Decimal.Parse(OptionSetting.CurrentWeight1);
                    string ssql2 = string.Format(@"update IMOS_PR_Weigh set Before_Value = {0} where Product_BarCode = '{1}' ",
                                               OptionSetting.CurrentWeightA, OptionSetting.ProBarCodeA);
                    DataHelper.Fill(ssql2);

                    object[] BackBuff = new object[1];
                    BackBuff[0] = 2;  //下传PLC存储称重信息完成标志2                
                    bool PLCWrite = ControlData.MasterPLC.Write(Block, Address, BackBuff);
                    if (!PLCWrite)
                    {
                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位下传PLC充氮前存储完成标志位失败！");
                    }
                    else
                    {
                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位获取充氮前称重结果成功，下传PLC成功！");
                    }
                }

                int DataAddress = int.Parse(BaseSystemInfo.WeightAddressB1);
                int DataBlock = 0;
                int DataLen = 1;
                object[] Buf2 = new object[DataLen];
                bool PLCDataRead = ControlData.MasterPLC.Read(DataBlock.ToString(), DataAddress, DataLen, out Buf2);
                if (!PLCDataRead)
                {
                    OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位读取充氮后PLC请求标志位失败！");
                    return;
                }
                if ((int)Buf2[0] == 1)//上位机接收到PLC上传的灌注后称量完成标记1后，获取称重仪器的称量结果
                {
                    OptionSetting.CurrentWeightA = Decimal.Parse(OptionSetting.CurrentWeight1);
                    decimal errval = System.Math.Abs(OptionSetting.CurrentWeightA - OptionSetting.TempStandWeightA);
                    int checkres = 0;
                    if (errval > OptionSetting.TempToleranceA)
                    {
                        checkres = 2;
                    }
                    else
                    {
                        checkres = 1;
                    }
                    string ssql3 = string.Format(@"update IMOS_PR_Weigh set After_Value = {0},
                                                                        Error_Value = {2},
                                                                        Check_Result = {3},
                                                                        Scan_Time_After = GETDATE()
                                                                        where Product_BarCode = '{1}' ",
                                               OptionSetting.CurrentWeightA, OptionSetting.ProBarCodeA, errval, checkres);
                    DataHelper.Fill(ssql3);
                    object[] BackBuff2 = new object[2];
                    BackBuff2[0] = 2;//下传PLC存储称重信息完成标志2        
                    BackBuff2[1] = checkres; //下传PLC称重是否合格标记      
                    bool PLCWrite = ControlData.MasterPLC.Write(DataBlock, DataAddress, BackBuff2);
                    if (!PLCWrite)
                    {
                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位下传PLC充氮后存储完成标志位失败！");
                    }
                    else
                    {
                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位获取充氮后称重结果成功，下传PLC成功！");
                        Thread.Sleep(1000);
                        OptionSetting.ScanFlagA = false;
                        OptionSetting.ProBarCodeA = "";
                        OptionSetting.ProductModeA = "";
                        OptionSetting.CurrentWeight1 = "";
                        OptionSetting.CurrentWeightA = 0;
                        OptionSetting.TempStandWeightA = 0;
                        OptionSetting.TempToleranceA = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("一号工位称量标志位异常." + ex.Message);
            }
            finally
            {
                if (GetPLCFlagTimer1 != null)
                {
                    GetPLCFlagTimer1.Change(1000, Timeout.Infinite);
                }
            }
        }


        #endregion

        #region 2号工位PLC请求监控       
        public static void GetPLCFlag2(object o)
        {
            try
            {
                Thread.Sleep(10);
                int Address = int.Parse(BaseSystemInfo.WeightAddressA2);
                int Block = 0;
                int Len = 1;
                object[] Buf = new object[Len];

                bool PLCRead = ControlData.MasterPLC.Read(Block.ToString(), Address, Len, out Buf);
                if (!PLCRead)
                {
                    OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位读取充氮前PLC请求标志位失败！");
                    return;
                }
                if ((int)Buf[0] == 1)//上位机接收到PLC上传的灌注前称量完成标记1后，获取称重仪器的称量结果
                {
                    OptionSetting.CurrentWeightB = Decimal.Parse(OptionSetting.CurrentWeight2);
                    string ssql2 = string.Format(@"update IMOS_PR_Weigh set Before_Value = {0} where Product_BarCode = '{1}' ",
                                               OptionSetting.CurrentWeightB, OptionSetting.ProBarCodeB);
                    DataHelper.Fill(ssql2);

                    object[] BackBuff = new object[1];
                    BackBuff[0] = 2;  //下传PLC存储称重信息完成标志2                
                    bool PLCWrite = ControlData.MasterPLC.Write(Block, Address, BackBuff);
                    if (!PLCWrite)
                    {
                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位下传PLC充氮前存储完成标志位失败！");
                    }
                    else
                    {
                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位获取充氮前称重结果成功，下传PLC成功！");
                    }
                }

                int DataAddress = int.Parse(BaseSystemInfo.WeightAddressB2);
                int DataBlock = 0;
                int DataLen = 1;
                object[] Buf2 = new object[DataLen];
                bool PLCDataRead = ControlData.MasterPLC.Read(DataBlock.ToString(), DataAddress, DataLen, out Buf2);
                if (!PLCDataRead)
                {
                    OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位读取充氮后PLC请求标志位失败！");
                    return;
                }
                if ((int)Buf2[0] == 1)//上位机接收到PLC上传的灌注后称量完成标记1后，获取称重仪器的称量结果
                {
                    OptionSetting.CurrentWeightB = Decimal.Parse(OptionSetting.CurrentWeight2);
                    decimal errval = System.Math.Abs(OptionSetting.CurrentWeightB - OptionSetting.TempStandWeightB);
                    int checkres = 0;
                    if (errval > OptionSetting.TempToleranceB)
                    {
                        checkres = 2;
                    }
                    else
                    {
                        checkres = 1;
                    }
                    string ssql3 = string.Format(@"update IMOS_PR_Weigh set After_Value = {0},
                                                                        Error_Value = {2},
                                                                        Check_Result = {3},
                                                                        Scan_Time_After = GETDATE()
                                                                        where Product_BarCode = '{1}' ",
                                               OptionSetting.CurrentWeightB, OptionSetting.ProBarCodeB, errval, checkres);
                    DataHelper.Fill(ssql3);
                    object[] BackBuff2 = new object[2];
                    BackBuff2[0] = 2;//下传PLC存储称重信息完成标志2        
                    BackBuff2[1] = checkres; //下传PLC称重是否合格标记      
                    bool PLCWrite = ControlData.MasterPLC.Write(DataBlock, DataAddress, BackBuff2);
                    if (!PLCWrite)
                    {
                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位下传PLC充氮后存储完成标志位失败！");
                    }
                    else
                    {
                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位获取充氮后称重结果成功，下传PLC成功！");
                        Thread.Sleep(1000);
                        OptionSetting.ScanFlagB = false;
                        OptionSetting.ProBarCodeB = "";
                        OptionSetting.ProductModeB = "";
                        OptionSetting.CurrentWeight2 = "";
                        OptionSetting.CurrentWeightB = 0;
                        OptionSetting.TempStandWeightB = 0;
                        OptionSetting.TempToleranceB = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("二号工位称量标志位异常." + ex.Message);
            }
            finally
            {
                if (GetPLCFlagTimer2 != null)
                {
                    GetPLCFlagTimer2.Change(1000, Timeout.Infinite);
                }
            }
        }


        #endregion

    }
}
