using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLogic
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Net.Sockets;
    using System.Net;
    using System.Data;
    using Control;

    public class ControlBoxDoorMatchData
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
           

        }
        #endregion

        #region 扫码器 箱体码A

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
                        
                        BarCodeOneDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.BoxBarCodeA = "";
                        OptionSetting.BoxCodeA = "";
                        OptionSetting.BoxNameA = "";
                        OptionSetting.DoorCodeA = "";
                        OptionSetting.DoorNameA = "";
                        int Address = 0;
                        int Block = 0;
                        object[] BackBuff = new object[2];
                        BackBuff[0] = 2;  //下传PLC是否放行标志2 
                        BackBuff[1] = 1;  //下传PLC应答字1                      
                        bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                        if (!PLCWrite)
                        {
                            OptionSetting.MsgInfo =  string.Format("一号工位下传PLC是否放行信号失败！" +"\r\n"+ "No. 1 station down transmission PLC release signal failed!");
                        }
                        else
                        {
                            OptionSetting.MsgInfo =  string.Format("一号工位扫码失败，禁止放行！" + "\r\n" + "No. 1 station scanning code failed. Release is prohibited!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("一号工位箱体码读取异常", ex.ToString()));
            }
        }


        #endregion

        #endregion

        #region 扫码器 箱体码B

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
                       
                        BarCodeTwoDataHandle(code);

                    }
                    else
                    {
                        int Address = 2;
                        int Block = 0;
                        object[] BackBuff = new object[2];
                        BackBuff[0] = 1;  //下传PLC是否放行标志1 
                        BackBuff[1] = 1;  //下传PLC应答字1                    
                        bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                        if (!PLCWrite)
                        {
                            OptionSetting.MsgInfo =  string.Format("二号工位下传PLC是否放行信号失败！" + "\r\n" + "No. 2 station down transmission PLC release signal failed!");
                        }
                        else
                        {
                            OptionSetting.MsgInfo =  string.Format("二号工位扫码失败，正常放行！" + "\r\n" + "No. 2 station scanning code failed, normal release!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(string.Format("二号工位箱体码读取异常", ex.ToString()));
            }
        }
        #endregion


        #endregion

        #region 产品码处理
        private static void BarCodeOneDataHandle(string code)
        {
            try
            {
                int Address = 0;
                int Block = 0;
                object[] BackBuff = new object[2];
                SysBusinessFunction.WriteLog(string.Format("一号工位箱体条码【{0}】", code));
                OptionSetting.BoxBarCodeA = code;
                OptionSetting.MsgInfo =  string.Format("一号工位读取箱体条码【{0}】成功" + "\r\n" + "Station 1 reads the box bar code【{0}】successfully", code);
                string sMaterialCode = code.Substring(0, 8).Trim();//可扩展 条码前五位是物料编码
                string MaterialSQL = string.Format(@"SELECT  BOM_Code,BOM_Name  
                                                         FROM IMOS_TA_Bom 
                                                         WHERE BOM_Code = '{0}'", sMaterialCode);
                DataSet ds = DataHelper.Fill(MaterialSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.BoxCodeA = ds.Tables[0].Rows[0]["BOM_Code"].ToString();
                    OptionSetting.BoxNameA = ds.Tables[0].Rows[0]["BOM_Name"].ToString();
                    //查询门箱匹配关系信息
                    string sSQL = string.Format(@"SELECT  Door_Code,Door_Name  
                                                         FROM IMOS_TA_Match_Record 
                                                         WHERE Box_Code = '{0}'", sMaterialCode);
                    DataSet ds2 = DataHelper.Fill(sSQL);
                    if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        OptionSetting.DoorCodeA = ds2.Tables[0].Rows[0]["Door_Code"].ToString();
                        OptionSetting.DoorNameA = ds2.Tables[0].Rows[0]["Door_Name"].ToString();
                        //上传数据到数据库
                        string ssSQL = string.Format(@"INSERT INTO [IMOS_TA_BoxDoor_Record]
                                                   ([Company_Code]
                                                    ,[Company_Name]
                                                    ,[Factory_Code]
                                                    ,[Factory_Name]
                                                    ,[Product_Line_Code]
                                                    ,[Product_Line_Name]                                                  
                                                    ,[Box_BarCode]
                                                    ,[Box_Code]
                                                    ,[Box_Name]
                                                    ,[Door_Code]
                                                    ,[Door_Name]
                                                    ,[Scan_Flag]  
                                                    ,[Create_time]                                                                                                        
                                                    )
                                                    VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}','{5}'
                                                    ,'{6}','{7}','{8}','{9}','{10}',{11},GETDATE())",
                                                                BaseSystemInfo.CompanyCode,
                                                                BaseSystemInfo.CompanyName,
                                                                BaseSystemInfo.FactoryCode,
                                                                BaseSystemInfo.FactoryName,
                                                                BaseSystemInfo.ProductLineCode,
                                                                BaseSystemInfo.ProductLineName,
                                                                OptionSetting.BoxBarCodeA,
                                                                OptionSetting.BoxCodeA,
                                                                OptionSetting.BoxNameA,
                                                                OptionSetting.DoorCodeA,
                                                                OptionSetting.DoorNameA,
                                                                1);
                        DataSet ds1 = DataHelper.Fill(ssSQL);
                        BackBuff[0] = 1;  //下传PLC是否放行标志1 
                        BackBuff[1] = 1;  //下传PLC应答字1                  
                        bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                        if (!PLCWrite)
                        {
                            OptionSetting.MsgInfo =  string.Format("一号工位下传PLC是否放行信号失败！" + "\r\n" + "No. 1 station down transmission PLC release signal failed!");
                        }
                        else
                        {
                            OptionSetting.MsgInfo =  string.Format("一号工位箱体条码【{0}】数据上传数据库成功，正常放行" + "\r\n" + "Bar code 【{0}】 of the box body of station no. 1 was successfully uploaded to the database and released normally", code);
                        }
                    }
                    else
                    {
                        OptionSetting.DoorCodeA = "";
                        OptionSetting.DoorNameA = "";
                        BackBuff[0] = 2;  //下传PLC是否放行标志2   
                        BackBuff[1] = 1;  //下传PLC应答字1                
                        bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                        if (!PLCWrite)
                        {
                            OptionSetting.MsgInfo =  string.Format("一号工位下传PLC是否放行信号失败！" + "\r\n" + "No. 1 station down transmission PLC release signal failed!");
                        }
                        else
                        {
                            OptionSetting.MsgInfo =  string.Format("一号工位箱体条码【{0}】的门箱匹配关系未维护，禁止放行" + "\r\n" + "No. 1 station box barcode 【{0}】 door box matching relationship is not maintained, release is prohibited", code);
                        }
                    }
                }
                else
                {
                    OptionSetting.BoxCodeA = "";
                    OptionSetting.BoxNameA = "";
                    OptionSetting.DoorCodeA = "";
                    OptionSetting.DoorNameA = "";
                    BackBuff[0] = 2;  //下传PLC是否放行标志2  
                    BackBuff[1] = 1;  //下传PLC应答字1                   
                    bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                    if (!PLCWrite)
                    {
                        OptionSetting.MsgInfo =  string.Format("一号工位下传PLC是否放行信号失败！" + "\r\n" + "No. 1 station down transmission PLC release signal failed!");
                    }
                    else
                    {
                        OptionSetting.MsgInfo =  string.Format("一号工位箱体条码【{0}】的箱体型号未维护，禁止放行" + "\r\n" + "No. 1 station box body barcode 【{0}】 box body model is not maintained, release is prohibited", code);
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("一号工位接收条码异常！" + ex.Message);
            }
        }

        private static void BarCodeTwoDataHandle(string code)
        {
            try
            {
                int Address = 2;
                int Block = 0;
                object[] BackBuff = new object[2];
                SysBusinessFunction.WriteLog(string.Format("二号工位箱体条码【{0}】", code));                
                OptionSetting.MsgInfo = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位读取箱体条码【{0}】成功" + "\r\n" + "Station 2 reads the box bar code【{0}】successfully", code);                
                string MaterialSQL = string.Format(@"SELECT  Box_BarCode,Convert(Varchar(100),Create_time,120) Create_Time 
                                                         FROM IMOS_TA_BoxDoor_Record 
                                                         WHERE Box_BarCode = '{0}'and Company_Code = '{1}' and Factory_Code = '{2}' and Product_Line_Code = '{3}'",
                                                         code, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataSet ds = DataHelper.Fill(MaterialSQL);
                string scantime = ds.Tables[0].Rows[0]["Create_Time"].ToString();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string ssSQL = string.Format(@"update IMOS_TA_BoxDoor_Record set Scan_Flag = {0} where (Box_BarCode = '{1}' or Convert(Varchar(100),Create_time,120) <= '{2}') 
                                                 and Company_Code = '{3}' and Factory_Code = '{4}' and Product_Line_Code = '{5}' ",
                                                2, code, scantime,BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                    DataSet ds1 = DataHelper.Fill(ssSQL);
                    BackBuff[0] = 1;  //下传PLC是否放行标志1  
                    BackBuff[1] = 1;  //下传PLC应答字1                 
                    bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                    if (!PLCWrite)
                    {
                       OptionSetting.MsgInfo =  string.Format("二号工位下传PLC是否放行信号失败！" + "\r\n" + "No. 2 station down transmission PLC release signal failed!");
                    }
                    else
                    {
                       OptionSetting.MsgInfo =  string.Format("二号工位箱体条码【{0}】数据扫描标志修改成功，正常放行" + "\r\n" + "Bar code 【{0}】 data scan mark modification of box body of station 2, normal release", code);
                    }
                  
                }
                else
                {
                    BackBuff[0] = 1;  //下传PLC是否放行标志1  
                    BackBuff[1] = 1;  //下传PLC应答字1                   
                    bool PLCWrite = ControlMaster.WriteData(Block, Address, BackBuff);
                    if (!PLCWrite)
                    {
                        OptionSetting.MsgInfo =  string.Format("二号工位下传PLC是否放行信号失败！" + "\r\n" + "No. 2 station down transmission PLC release signal failed!");
                    }
                    else
                    {
                        OptionSetting.MsgInfo =  string.Format("二号工位箱体条码【{0}】记录表中不存在，正常放行" + "\r\n" + "Bar code 【{0}】 on box body of station 2 does not exist in the record sheet, normal release", code);
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("二号工位接收条码异常！" + ex.Message);
            }
        }
        #endregion
    }
}
