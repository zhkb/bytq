using Communication;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// 箱体寄存库逻辑处理
/// zhaocf
/// </summary>
namespace ControlLogic.Control
{

    public class ControlBoxBodyStoreData
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




        public static MPlcLink MasterPLC = new MPlcLink(); //定义PLC
        public static MPlcLink CheckOnlinePLC = new MPlcLink();//重连
        public static bool MasterPLCPLCConn = false;//设备PLC状态
        public static System.Threading.Timer CheckPlcStatusTimer;//检查PLC设备连接状态Time


        //读取PLC货道信息
        public static System.Threading.Timer GetStoStockDataTimer; //读取货道信息
        public static System.Threading.Timer GetStoStockDetailDataTimer; //读取货道信息




        public static System.Threading.Timer ATaskDataTimer; //下传出库任务
        public static System.Threading.Timer BTaskDataTimer; //下传出库任务
        public static bool AUploadFlag = true;
        public static bool BUploadFlag = true;


        #endregion

        #region 初始化
        public static void SystemInitialization()//初始化
        {
            //PLC
            InitMPlcLinkPLC();
            CheckPlcStatusTimer = new System.Threading.Timer(CheckPLCConnectionStatus, null, 0, Timeout.Infinite);//PLC断线重连

         //出库任务下传
                ATaskDataTimer = new System.Threading.Timer(ATaskData, null, 0, Timeout.Infinite);//
                BTaskDataTimer = new System.Threading.Timer(BTaskData, null, 0, Timeout.Infinite);//


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
            GetStoStockDataTimer = new System.Threading.Timer(GetStoStockData, null, 0, Timeout.Infinite);//获取库存
            GetStoStockDetailDataTimer = new System.Threading.Timer(GetStoStockDetailData, null, 0, Timeout.Infinite);//获取库存

        }

       




        #endregion

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
                        BarCodeOneDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.XTMsgA = "A读取条码失败";
                        OptionSetting.XTBarCodeA = "";
                        OptionSetting.XTBinNoA = "";
                       
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("一号工位产品码读取异常", ex.ToString()));
            }
        }

        private static void BarCodeOneDataHandle(string code)
        {
            try
            {
                string Store_Code ="2001";
                SysBusinessFunction.WriteLog(string.Format("A产品条码【{0}】", code));
                OptionSetting.XTBarCodeA = code;
                //string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                DbParameter[] param = {
                                      new SqlParameter("@Company_Code", BaseSystemInfo.CompanyCode),//产品条码
                                      new SqlParameter("@Company_Name",BaseSystemInfo.CompanyName),//产品条码
                                      new SqlParameter("@Factory_Code",BaseSystemInfo.FactoryCode),//产品条码
                                      new SqlParameter("@Factory_Name",BaseSystemInfo.FactoryName),//产品条码
                                      new SqlParameter("@Product_Line_Code",BaseSystemInfo.ProductLineCode),//产品条码
                                      new SqlParameter("@Product_Line_Name",BaseSystemInfo.ProductLineName),//产品条码
                                      new SqlParameter("@Process_Code",BaseSystemInfo.CurrentProcessCode),//
                                      new SqlParameter("@Store_Code",Store_Code),//
                                      new SqlParameter("@BarCode",code),//产品条码
     
                                      };
                DataSet ds = DataHelper.ExecuteProcedure("IMOS_XT_Query_BinNo", new String[] { "List" }, param);
                DataTable dt = ds.Tables[0];
                if (dt.Columns.Count > 0) {
                    string CHKRST = dt.Rows[0]["CHKRST"].ToString();
                    string MSGIFO = dt.Rows[0]["MSGIFO"].ToString();
                   
                    if (CHKRST == "S")
                    {
                        string Material_Code =dt.Rows[0]["Material_Code"].ToString();
                        string Material_Name = dt.Rows[0]["Material_Name"].ToString();
                      
                        int BinNo = int.Parse(dt.Rows[0]["BinNo"].ToString());
                        //下传PLC
                        if (!MasterPLCPLCConn) //读取PLC失败
                        {
                            SysBusinessFunction.WriteLog("读取设备状态PLC数据失败，请检查PLC连接.");
                            OptionSetting.XTMsgA = "PLC连接异常！"+Environment.NewLine+ "PLC connection is abnormal";
                            OptionSetting.XTBarCodeA = code;
                            OptionSetting.XTBinNoA = BinNo + "#";
                            return;
                        }
                        int DataAddress = 0;
                        int DataLen = 0;
                        DataAddress = int.Parse(BaseSystemInfo.AFDAddress);
                        DataLen = int.Parse(BaseSystemInfo.AFDlength);
                        object[] Buf = new object[DataLen];
                        Buf[0] = 1;
                        Buf[1] = BinNo;
                        bool PLCWrite = MasterPLC.Write(0, DataAddress, Buf);

                        if (PLCWrite)
                        {

                            //插入入库记录信息
                            AddInDetail(Material_Code, Material_Name, code, BinNo.ToString(),"1",Store_Code);
                            //插入库存明细
                            AddBinDetail(code, BinNo.ToString(), Store_Code);
                            OptionSetting.XTMsgA = "分道成功";
                            OptionSetting.XTBarCodeA = code;
                            OptionSetting.XTBinNoA = BinNo+"#";
                        }




                    }
                    else
                    {
                        string[] arr = MSGIFO.Split('-');
                        OptionSetting.XTMsgA = arr[0]+ Environment.NewLine + arr[1];
                        OptionSetting.XTBarCodeA = code;
                        OptionSetting.XTBinNoA = "";

                    }



                }




            }
            catch (Exception ex) {


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
                       
                        BarCodeTwoDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.XTMsgB = "B读取条码失败";
                        OptionSetting.XTBarCodeB = "";
                        OptionSetting.XTBinNoB = "";
                    }
                }
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(string.Format("二号工位产品码读取异常", ex.ToString()));
            }
        }

        private static void BarCodeTwoDataHandle(string code)
        {
            try
            {
                string Store_Code = "2002";
                SysBusinessFunction.WriteLog(string.Format("A产品条码【{0}】", code));
                OptionSetting.XTBarCodeA = code;
                //string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                DbParameter[] param = {
                                      new SqlParameter("@Company_Code", BaseSystemInfo.CompanyCode),//产品条码
                                      new SqlParameter("@Company_Name",BaseSystemInfo.CompanyName),//产品条码
                                      new SqlParameter("@Factory_Code",BaseSystemInfo.FactoryCode),//产品条码
                                      new SqlParameter("@Factory_Name",BaseSystemInfo.FactoryName),//产品条码
                                      new SqlParameter("@Product_Line_Code",BaseSystemInfo.ProductLineCode),//产品条码
                                      new SqlParameter("@@Product_Line_Name",BaseSystemInfo.ProductLineName),//产品条码
                                      new SqlParameter("@Store_Code",Store_Code),//
                                      new SqlParameter("@BarCode",code),//产品条码
     
                                      };
                DataSet ds = DataHelper.ExecuteProcedure("IMOS_XT_Query_BinNo", new String[] { "List" }, param);
                DataTable dt = ds.Tables[0];
                if (dt.Columns.Count > 0)
                {
                    string CHKRST = dt.Rows[0]["CHKRST"].ToString();
                    string MSGIFO = dt.Rows[0]["MSGIFO"].ToString();
                    string Material_Code = dt.Rows[0]["Material_Code"].ToString();
                    string Material_Name = dt.Rows[0]["Material_Name"].ToString();
                    int BinNo = int.Parse(dt.Rows[0]["BinNo"].ToString());
                    if (CHKRST == "S")
                    {
                        //下传PLC
                        if (!MasterPLCPLCConn) //读取PLC失败
                        {
                            SysBusinessFunction.WriteLog("读取设备状态PLC数据失败，请检查PLC连接.");
                            return;
                        }
                        int DataAddress = 0;
                        int DataLen = 0;
                        DataAddress = int.Parse(BaseSystemInfo.AFDAddress);
                        DataLen = int.Parse(BaseSystemInfo.AFDlength);
                        object[] Buf = new object[DataLen];
                        Buf[0] = 1;
                        Buf[1] = BinNo;
                        bool PLCWrite = MasterPLC.Write(0, DataAddress, Buf);

                        if (PLCWrite)
                        {
                            AddInDetail(Material_Code, Material_Name, code, BinNo.ToString(), "2", Store_Code);
                            //插入库存明细
                            AddBinDetail(code, BinNo.ToString(), Store_Code);
                            OptionSetting.XTMsgB = "分道成功";
                            OptionSetting.XTBarCodeB = code;
                            OptionSetting.XTBinNoB = BinNo + "#";
                        }




                    }
                    else {
                        OptionSetting.XTMsgB = MSGIFO;
                        OptionSetting.XTBarCodeB = code;
                        OptionSetting.XTBinNoB ="";

                    }



                }




            }
            catch (Exception ex)
            {


            }
        }
        #endregion


        #endregion

        #region PLC处理

        #region PLC初始化
        private static void InitMPlcLinkPLC()
        {
            try
            {
                //初始化PLC连接
                MasterPLC.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation);
                MasterPLCPLCConn = MasterPLC.Open();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("PLC初始化失败！");
            }
        }
        #endregion

        #region PLC重连
        private static void CheckPLCConnectionStatus(object state)
        {
            try
            {
                //PLC连接
                CheckOnlinePLC.Close();
                CheckOnlinePLC.ActLogicalStationNumber = MasterPLC.ActLogicalStationNumber;
                MasterPLCPLCConn = CheckOnlinePLC.Open();
                if (!MasterPLCPLCConn) //PLC连接失败
                {
                    MasterPLC.Close();
                    MasterPLCPLCConn = MasterPLC.Open();
                }

            }
            catch
            {

            }
            finally
            {
                CheckPlcStatusTimer.Change(3000, Timeout.Infinite);
            }
        }
        #endregion

        #region 从PLC获取库存信息
        private static void GetStoStockData(object state)
        {
            try
            {

                if (!MasterPLCPLCConn) //读取PLC失败
                {
                    return;
                }

                int DataAddress = 0;
                int DataLen = 0;
                DataAddress =int.Parse( BaseSystemInfo.StockAddress);
                DataLen = int.Parse(BaseSystemInfo.Stocklength);
                object[] Buf = new object[DataLen];//库存
                for (int i = 0; i < DataLen; i++)
                {
                    Buf[i] = 0;
                }
                MasterPLC.Read("0", DataAddress, DataLen, out Buf);
                string StoreCode = "";
                string sql = "";
                for (int i = 0; i < 13; i++) {
                    int Bin_No = i + 1;
                    int Transit_Qty = int.Parse(Buf[i*5].ToString());
                    int Actual_Qty =  int.Parse(Buf[i * 5 + 1].ToString());
                    int BinFlag=      int.Parse(Buf[i * 5 + 2].ToString());
                    int FullFlag=     int.Parse(Buf[i * 5 + 3].ToString());
                    if (i < 7)
                    {
                        StoreCode = "2001";
                    }
                    else {
                        StoreCode = "2002";
                    }

                 sql = sql + string.Format(@" if exists(select 1 from IMOS_Lo_Bin where Bin_No={0} and Process_Code='{8}')
                                                update IMOS_Lo_Bin
                                                set Transit_Qty = {1},Actual_Qty={2},FullFlag={4},Bin_Flag={3}
                                                where Bin_No = {0} and Process_Code='{8}'
                                                else 
                                                Insert Into IMOS_Lo_Bin(Company_Code,Factory_Code,Product_Line_Code,Bin_No,Material_Code,Material_Name,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,Process_Code,Store_Code) 
                                               Values ('{5}','{6}','{7}',{0},'','',20,{1},{2},{3} ,'{8}','{9}');"
                                       , Bin_No, Transit_Qty, Actual_Qty, BinFlag, FullFlag, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode, StoreCode);
                }

                DataHelper.Fill(sql);

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("库存"+ex.ToString());

            }
            finally {
                GetStoStockDataTimer.Change(3000, Timeout.Infinite);
            }
        }

        /// <summary>
        /// 在途信息，在库信息
        /// 1.根据在途信息更新成在库信息
        /// 2.根据在库信息更新出库的信息
        /// </summary>
        /// <param name="state"></param>
        private static void GetStoStockDetailData(object state)
        {
            try
            {
                if (!MasterPLCPLCConn) //读取PLC失败
                {
                    return;
                }

                int DataAddress = 0;
                int DataLen = 0;
                DataAddress = int.Parse(BaseSystemInfo.StockAddress);
                DataLen = int.Parse(BaseSystemInfo.Stocklength);
                object[] Buf = new object[DataLen];//库存
                for (int i = 0; i < DataLen; i++)
                {
                    Buf[i] = 0;
                }
                MasterPLC.Read("0", DataAddress, DataLen, out Buf);
                string StoreCode = "";
                string sql = "";
                for (int i = 0; i < 13; i++)
                {
                    int Bin_No = i + 1;
                    int Transit_Qty = int.Parse(Buf[i * 5].ToString());
                    int Actual_Qty = int.Parse(Buf[i * 5 + 1].ToString());
                   
                    if (i < 7)
                    {
                        StoreCode = "2001";
                    }
                    else
                    {
                        StoreCode = "2002";
                    }
                    EditTransitBinDetail(Bin_No, Transit_Qty);//通过在途数量更改库存明细
                    EditActualBinDetail(Bin_No, Actual_Qty);//通过实际数量更改库存明细
                }

                DataHelper.Fill(sql);
            }
            catch (Exception ex)
            {


            }
            finally {
                GetStoStockDetailDataTimer.Change(3000, Timeout.Infinite);

            }
        }
        #region 根据PLC库存数量 更改库存明细
        private static void EditActualBinDetail(int bin_No, int actual_Qty)
        {
            try
            {
                string sql = "";
                sql = string.Format(@" UPDATE IMOS_Lo_Bin_Detail SET Material_Status = 2 where Bin_List_ID in (select Bin_List_ID from  (select Bin_List_ID,row_number() over( order by Create_Time desc) rs from IMOS_Lo_Bin_Detail where Process_Code= '{0}' and Bin_No = {1} and  Material_Status = 1 ) t  where  t.rs >{2});"
                           , BaseSystemInfo.CurrentProcessCode, bin_No, actual_Qty);

                DataHelper.Fill(sql);
            }
            catch (Exception ex)
            {


            }
        }

        private static void EditTransitBinDetail(int bin_No, int transit_Qty)
        {
            try
            {
                string sql = "";
                sql = string.Format(@" UPDATE IMOS_Lo_Bin_Detail SET Material_Status = 1 where Bin_List_ID in (select Bin_List_ID from  (select Bin_List_ID,row_number() over( order by Create_Time desc) rs from IMOS_Lo_Bin_Detail where Process_Code= '{0}' and Bin_No = {1} and  Material_Status = 0 ) t  where  t.rs >{2});"
                           ,  BaseSystemInfo.CurrentProcessCode,bin_No , transit_Qty);

                DataHelper.Fill(sql);
            }
            catch (Exception ex)
            {


            }
        }

        #endregion

        #endregion
        private static void ATaskData(object state)
        {
            try
            {

                if (!MasterPLCPLCConn) //读取PLC失败
                {
                    return;
                }

                if (AUploadFlag) {
                    AUploadFlag = false;
                    string RequestInf = "";
                    int DataBlock = 0;
                    int DataAddress = 0;
                    int DataLen = 20;

                        DataBlock = int.Parse(BaseSystemInfo.AXTCKBlock);//
                        DataAddress = int.Parse(BaseSystemInfo.AXTCKAddress);//

                 

                    object[] ReadBuf = new object[DataLen];
                    for (int i = 0; i < DataLen; i++)
                    {
                        ReadBuf[i] = 0;
                    }
                    MasterPLC.Read(DataBlock.ToString(), DataAddress, DataLen, out ReadBuf);
                    RequestInf = ReadBuf[0].ToString();

                    if (RequestInf == "1")
                    {
                        DataSet ds = new DataSet();
                        string sqlStr = string.Format(@" select top 1 T.ID,T.Material_Code,T.Material_Name,T.SortNum,T.Flag,B.Bin_No from IMOS_BA_TRK T LEFT   JOIN IMOS_Lo_Bin B on T.Material_Code = b.Material_Code
                        where t.Company_Code = '{0}' and T.Factory_Code = '{1}' and T.Product_Line_Code = '{2}' and T.Workstation_No='{3}'  and T.IO='I'   and T.Flag <2  and T.Process_Code='{4}'    ORDER BY   Creation_Date ,ID",
                                      BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,1,BaseSystemInfo.CurrentProcessCode);
                      ds = DataHelper.Fill(sqlStr);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            string ID = ds.Tables[0].Rows[0]["ID"].ToString();
                            string MaterialCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                            string MaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                            int Bin_No = int.Parse(ds.Tables[0].Rows[0]["Bin_No"].ToString());
                            string Flag = ds.Tables[0].Rows[0]["Flag"].ToString();

                            if (Flag == "1")
                            {

                                EditTask(ID,"1", Bin_No);
                                SysBusinessFunction.WriteLog(string.Format("产品【{0}】处理已取消任务", MaterialCode));
                            }
                            else {

                                object[] DownBuff = new object[DataLen];
                                for (int i = 0; i < DataLen; i++)
                                {
                                    DownBuff[i] = 0;
                                }

                                DownBuff[0] = 1;
                                DownBuff[1] = Bin_No;

                                bool PLCWrite = MasterPLC.Write(DataBlock, DataAddress + 1, DownBuff);
                                if (PLCWrite)
                                {
                                    //判断下位机是否读取，读取后数据清零
                                    int CoamingTick = GetTickCount();
                                    while (true)
                                    {
                                        Thread.Sleep(20);
                                        if (GetTickCount() - CoamingTick > 5000) //超时退出 重新下传 超时时间为5秒
                                        {

                                            SysBusinessFunction.WriteLog(string.Format("读取RFIDPLC反馈数据超时，请检查PLC连接或上传地址,数据地址{0}", DataAddress));
                                            break;
                                        }

                                        bool PLCRead = MasterPLC.Read(DataBlock.ToString(), DataAddress + 1, DataLen, out DownBuff);

                                        if ((int)DownBuff[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
                                        {
                                            for (int i = 0; i < DataLen; i++)
                                            {
                                                DownBuff[i] = 0;
                                            }

                                            PLCWrite = MasterPLC.Write(DataBlock, DataAddress, DownBuff);
                                            //更改任务状态

                                            //更改计划状态
                                            EditTask(ID,"0",0);
                                            SysBusinessFunction.WriteLog(string.Format("产品【{0}】货道号【{1}】下传成功", MaterialCode, Bin_No));


                                            break;
                                        }
                                    }


                                }




                            }






                        }
                    }//RequestInf  end







                }//UploadFlag  end

            }
            catch (Exception ex)
            {

            }
            finally {
                AUploadFlag = true;
                ATaskDataTimer.Change(3000, Timeout.Infinite);
            }
        }

        private static void BTaskData(object state)
        {
            try
            {

                if (!MasterPLCPLCConn) //读取PLC失败
                {
                    return;
                }

                if (BUploadFlag)
                {
                    BUploadFlag = false;
                    string RequestInf = "";
                    int DataBlock = 0;
                    int DataAddress = 0;
                    int DataLen = 20;

                 
                        DataBlock = int.Parse(BaseSystemInfo.BXTCKBlock);//
                        DataAddress = int.Parse(BaseSystemInfo.BXTCKAddress);//


                    object[] ReadBuf = new object[DataLen];
                    for (int i = 0; i < DataLen; i++)
                    {
                        ReadBuf[i] = 0;
                    }
                    MasterPLC.Read(DataBlock.ToString(), DataAddress, DataLen, out ReadBuf);
                    RequestInf = ReadBuf[0].ToString();

                    if (RequestInf == "1")
                    {
                        DataSet ds = new DataSet();
                        string sqlStr = string.Format(@" select top 1 T.ID,T.Material_Code,T.Material_Name,T.SortNum,T.Flag,B.Bin_No from IMOS_BA_TRK T LEFT   JOIN IMOS_Lo_Bin B on T.Material_Code = b.Material_Code
                        where t.Company_Code = '{0}' and T.Factory_Code = '{1}' and T.Product_Line_Code = '{2}' and T.Workstation_No='{3}'  and T.IO='I'   and T.Flag <2  and T.Process_Code='{4}'     ORDER BY   Creation_Date ,ID",
                                      BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, 2,BaseSystemInfo.CurrentProcessCode);
                        ds = DataHelper.Fill(sqlStr);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            string ID = ds.Tables[0].Rows[0]["ID"].ToString();
                            string MaterialCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                            string MaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                            int Bin_No = int.Parse(ds.Tables[0].Rows[0]["Bin_No"].ToString());
                            string Flag = ds.Tables[0].Rows[0]["Flag"].ToString();

                            if (Flag == "1")
                            {

                                EditTask(ID,"1",Bin_No);
                                SysBusinessFunction.WriteLog(string.Format("产品【{0}】处理已取消任务", MaterialCode));
                            }
                            else
                            {

                                object[] DownBuff = new object[DataLen];
                                for (int i = 0; i < DataLen; i++)
                                {
                                    DownBuff[i] = 0;
                                }

                                DownBuff[0] = 1;
                                DownBuff[1] = Bin_No;

                                bool PLCWrite = MasterPLC.Write(DataBlock, DataAddress + 1, DownBuff);
                                if (PLCWrite)
                                {
                                    //判断下位机是否读取，读取后数据清零
                                    int CoamingTick = GetTickCount();
                                    while (true)
                                    {
                                        Thread.Sleep(20);
                                        if (GetTickCount() - CoamingTick > 5000) //超时退出 重新下传 超时时间为5秒
                                        {

                                            SysBusinessFunction.WriteLog(string.Format("读取RFIDPLC反馈数据超时，请检查PLC连接或上传地址,数据地址{0}", DataAddress));
                                            break;
                                        }

                                        bool PLCRead = MasterPLC.Read(DataBlock.ToString(), DataAddress + 1, DataLen, out DownBuff);

                                        if ((int)DownBuff[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
                                        {
                                            for (int i = 0; i < DataLen; i++)
                                            {
                                                DownBuff[i] = 0;
                                            }

                                            PLCWrite = MasterPLC.Write(DataBlock, DataAddress, DownBuff);
                                            //更改任务状态

                                            //更改计划状态
                                            EditTask(ID,"0",0);
                                            SysBusinessFunction.WriteLog(string.Format("产品【{0}】货道号【{1}】下传成功", MaterialCode, Bin_No));


                                            break;
                                        }
                                    }


                                }




                            }






                        }
                    }//RequestInf  end







                }//UploadFlag  end

            }
            catch (Exception ex)
            {

            }
            finally
            {
                BUploadFlag = true;
                BTaskDataTimer.Change(3000, Timeout.Infinite);
            }
        }


        #region 出库任务下传成功后更改状态及计划数量
        private static void EditTask(string id,string type,int BinNo)
        {
            try
            {
                string CheckStr = "";
                if (type == "0")
                {
                    CheckStr = CheckStr + string.Format(@"Update IMOS_BA_TRK Set Flag = {0}  Where id = {1} ;", "2", id);
                }
                if (type == "1")
                {
                    CheckStr = CheckStr + string.Format(@"Update IMOS_BA_TRK Set Flag = {0},Bin_No={1} Where id = {1} ;", "3", id,BinNo);
                }
                //任务已完成
              
                //计划实际数量+1，状态改为已执行
                CheckStr = CheckStr + string.Format(@"UPDATE   IMOS_LIST_OUT  Set Flag = {0},Act_Num=(Act_Num+1) where Id=(select LIST_ID from  IMOS_BA_TRK where id={1});", "1", id);
                //计划改为已完成
                CheckStr = CheckStr + string.Format(@"UPDATE   IMOS_LIST_OUT  Set Flag = {0} where Id=(select LIST_ID from  IMOS_BA_TRK where id={1}) and Plan_Num<=Act_Num;", "3", id);

                DataHelper.Fill(CheckStr);
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
        #endregion
        #endregion


        private static void AddBinDetail(string code, string BinNo,string Store_Code) {

            try
            {
                string sql = "";
                sql = string.Format(@" Insert Into IMOS_Lo_Bin_Detail(Company_Code,Factory_Code,Product_Line_Code,Store_Code,Bin_No,Bar_Code,Material_Status,Create_Time,Process_Code) 
                                               Values ( '{0}','{1}','{2}','{3}','{4}','{5}',{6},GETDATE(),'{7}');"
                           , BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Store_Code,BinNo,code,0, BaseSystemInfo.CurrentProcessCode);

                DataHelper.Fill(sql);

            }
            catch
            {


            }

        }


        private static void AddInDetail(string MaterialCode, string MaterialName, string code, string BinNo, string WorkstationNo,string Store_Code)
        {

            try
            {
                string sql = "";
                sql = string.Format(@" Insert Into IMOS_LIST_IN_Detail(Company_Code,Factory_Code,Product_Line_Code,Station_Code,Material_Code,Material_Name,Bin_No,Product_BarCode,Creation_Date,Created_By,Process_Code,Store_Code) 
                                               Values ( '{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}',GETDATE(),'{8}','{9}');"
                           , BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, WorkstationNo, MaterialCode, MaterialName, BinNo, code, BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentProcessCode,Store_Code);

                DataHelper.Fill(sql);

            }
            catch
            {


            }

        }


    }
}
