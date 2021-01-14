using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

namespace ControlLogic
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;

    #region 条码实体类
    public class BcrModel
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 设备IP
        /// </summary>
        public string socketIp { get; set; }
        /// <summary>
        /// 设备端口
        /// </summary>
        public int socketPort { get; set; }
        /// <summary>
        /// socket客户端
        /// </summary>
        public Socket socketClient { get; set; }
        /// <summary>
        ///连接状态
        /// </summary>
        public bool connStu { get; set; }
        /// <summary>
        ///  重连次数
        /// </summary>
        public int reNum { get; set; }
        /// <summary>
        /// 条码
        /// </summary>
        public string barCode { get; set; }

        public string note { get; set; }


    }
    #endregion

    public class ControlData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private static SPlcLink MasterPLC_Siemens = new SPlcLink();
        private static SPlcLink ReConnectPLC_Siemens = new SPlcLink();

        private static MPlcLink MasterPLC_Mitsubishi = new MPlcLink();
        private static MPlcLink ReConnectPLC_Mitsubishi = new MPlcLink();

        //private static SPlcLink MasterPLC = new SPlcLink(); //线体PLC
        //private static SPlcLink CoamingPLC = new SPlcLink(); //U壳PLC

        //private static SPlcLink CheckOnlinePLC = new SPlcLink(); //设备PLC

        public static bool MasterPLCPLCConn = false;//线体PLC状态
        public static bool CoamingPLCConn = false;//U壳PLC状态
   
        public static int StirAlarmCount = 500;//报警数量
        public static AlarmInfo[] StirAlarmInfo = new AlarmInfo[StirAlarmCount];
        public static System.Threading.Timer GetAlarmDataTimer; //读取报警信息

        public static System.Threading.Timer CheckPlcStatusTimer;  //检测PLC在线状态

        public static System.Threading.Timer CheckScanStatusTimer1;  //检测混流扫码器在线状态
        public static System.Threading.Timer CheckScanStatusTimer2;  //检测南线扫码器在线状态
        public static System.Threading.Timer CheckScanStatusTimer3;  //检测北线扫码器在线状态

        public static System.Threading.Timer DownLoadMaterialDataTimer;  //根据PLC请求下传货道放行



        public static Thread BarScanSocketThread1 = null; // 创建用于接收服务端消息的 线程； 混流扫码 
        public static Socket BarScanSocket1 = null; // 创建用于接收服务端消息的 线程； 混流扫码 
        private static IPEndPoint BarScanendPoint1;
        public static bool BarScanBarConn1 = false; //条码扫描设备连接状态

        public static int BarScanBarConnCount1 = 1;
        public static int BarScanBarConnCount2 = 1;
        public static int BarScanBarConnCount3 = 1;

        public static List<BcrModel> BarList = new List<BcrModel>();

        public static void SystemInitialization()//初始化
        {
//            CreateBarScanSocket(); //创建条码扫描Socket

            if (BaseSystemInfo.PLCType == "1") // 三菱PLC
            {
                MasterPLC_Mitsubishi.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation_First);
                MasterPLCPLCConn = MasterPLC_Mitsubishi.Open();

            }
            else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
            {
                MasterPLC_Siemens.PLCConnectionIP = BaseSystemInfo.MasterPLCIP_First;
                MasterPLC_Siemens.PLCConNo = 1;
                MasterPLCPLCConn = MasterPLC_Siemens.Open();
            }

            CreateAssembleTimer();

        }

        public static void CreateBarScanSocket()//创建条码扫描Socket
        {
            try
            {
                #region 创建扫描Socket

                for (int i = 0; i < 15; i++)
                {
                    IPAddress BarScanIP = IPAddress.Parse(BaseSystemInfo.BarScanInfoList[i].BarIP);
                    BaseSystemInfo.BarScanendPoint[i] = new IPEndPoint(BarScanIP, int.Parse(BaseSystemInfo.BarScanInfoList[i].BarPort));
                    BaseSystemInfo.BarScanSocket[i] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    BaseSystemInfo.BarScanSocket[i].Blocking = false;
                    try
                    {
                        BaseSystemInfo.BarScanSocket[i].Connect(BaseSystemInfo.BarScanendPoint[i]);
                        BaseSystemInfo.BarScanBarConn[i] = true;
                    }
                    catch (SocketException ex)
                    {
                        BaseSystemInfo.BarScanBarConn[i] = false;
                        string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", BarScanIP, BaseSystemInfo.BarScanInfoList[i].BarPort);
                        SysBusinessFunction.WriteLog(TipInfo);
                    }

                    BaseSystemInfo.BarScanSocketThread[i] = new Thread(BarScanInRecMsg);
                    BaseSystemInfo.BarScanSocketThread[i].IsBackground = true;
                    BaseSystemInfo.BarScanSocketThread[i].Start(i);
                }
                #endregion
            }
            catch (Exception ex)
            {


            }
        }

        private static void BarScanInRecMsg(object o)
        {
            string strMsg = "";
            int SocketIndex = (int)o;
            while (true)
            {
                Thread.Sleep(5);
                byte[] arrMsgRec = new byte[50];
                // 将接受到的数据存入到arrMsgRec中；  
                int length = -1;
                try
                {
                    length = BaseSystemInfo.BarScanSocket[SocketIndex].Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    BaseSystemInfo.BarScanBarConn[SocketIndex] = true;
                }
                catch
                {
                    BaseSystemInfo.BarScanBarConn[SocketIndex] = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (BaseSystemInfo.BarScanBarConn[SocketIndex]))
                {
                    HandleScanBarData(strMsg.Trim(), SocketIndex);
                }
            }
        }

        private static void HandleScanBarData(string BarCode, int SocketIndex)
        {
            try
            {
                BaseSystemInfo.BarScanInfoList[SocketIndex].BarCode = BarCode + "  " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
            }
        }

        private static void DownLoadMaterialDataEvent(object o)//检查各PLC的在线状态 离线进行重连
        {
            // 与下位机数据交互 共3个字  1、PLC请求放行 2、上位机下传信号 3、放行线号
            try
            {

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private static void CheckPlcOnLineStatus(object o)//检查各PLC的在线状态 离线进行重连
        {
            try
            {
                //PLC连接
                ReConnectPLC_Mitsubishi.Close();
                ReConnectPLC_Mitsubishi.ActLogicalStationNumber = MasterPLC_Mitsubishi.ActLogicalStationNumber;
                MasterPLCPLCConn = ReConnectPLC_Mitsubishi.Open();
                if (!MasterPLCPLCConn) //PLC连接失败
                {
                    MasterPLC_Mitsubishi.Close();
                    MasterPLCPLCConn = MasterPLC_Mitsubishi.Open();
                }

            }
            catch
            {
            }
            finally
            {
                CheckPlcStatusTimer.Change(1000, Timeout.Infinite);
            }
        }

        public static void CreateAssembleTimer()//创建组装使用Timer
        {
            //  DownLoadMaterialDataTimer = new System.Threading.Timer(DownLoadMaterialDataEvent, null, 0, Timeout.Infinite);//根据PLC放行信号进行货道下传

            CheckPlcStatusTimer = new System.Threading.Timer(CheckPlcOnLineStatus, null, 0, Timeout.Infinite);//检测PLC在线状态timer

 //           CheckScanStatusTimer1 = new System.Threading.Timer(CheckScanStatusEvent, null, 0, Timeout.Infinite);//混流条码扫描设备1重连

            //CheckScanStatusTimer2 = new System.Threading.Timer(CheckScanStatusEvent2, null, 0, Timeout.Infinite);//南线条码扫描设备1重连

            //CheckScanStatusTimer3 = new System.Threading.Timer(CheckScanStatusEvent3, null, 0, Timeout.Infinite);//北线条码扫描设备1重连
            GetAlarmList();
            GetAlarmDataTimer = new System.Threading.Timer(GetAlarmData, null, 0, Timeout.Infinite);//读取报警信息
        }

        private static void GetAlarmList() //取得报警信息列表
        {
            try
            {
                string SqlStr = "";
                DataSet AlarmDataSet = new DataSet();

                SqlStr = string.Format(@"SELECT ID,Alarm_Desc,isnull(Equipment_Type,0) Equipment_Type,Equipment_Code,Equipment_Name,Alarm_Flag,Alarm_No FROM Sys_Alarm Order By ID");

                AlarmDataSet = DataHelper.Fill(SqlStr);

                for (int i = 0; i < AlarmDataSet.Tables[0].Rows.Count; i++)//i是查到的数据条数
                {
                    DataRow dr = AlarmDataSet.Tables[0].Rows[i];
                    StirAlarmInfo[i].AlarmID = dr["ID"].ToString();
                    StirAlarmInfo[i].AlarmNo = dr["Alarm_No"].ToString();
                    StirAlarmInfo[i].AlarmName = dr["Alarm_Desc"].ToString();
                    StirAlarmInfo[i].AlarmFlag = dr["Alarm_Flag"].ToString() == "1"; // 是否报警状态

                    StirAlarmInfo[i].EquipmentType = int.Parse(dr["Equipment_Type"].ToString());
                    StirAlarmInfo[i].EquipmentCode = dr["Equipment_Code"].ToString();
                    StirAlarmInfo[i].EquipmentName = dr["Equipment_Name"].ToString();

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "获取报警列表失败.");
                SysBusinessFunction.WriteLog(ex.ToString());
            }
            finally
            {

            }
        }

        public static void GetAlarmData(object o)
        {
            try
            {
                GetStirAlarmData();
            }
            catch
            {

            }
            finally
            {
                GetAlarmDataTimer.Change(1000, Timeout.Infinite);
            }
        }

        public static void GetStirAlarmData()
        {
            try
            {
                #region  读取报警数据
                int DataLen = 0;
                int remainder = 0;
                int DataBlock = 100;// StirAlarmDataBlock[AIndex];
                int DataAddress = 0;// StirAlarmDataAddress[AIndex];

                Boolean[] PlcAlarmFlag = new Boolean[StirAlarmCount];

                remainder = StirAlarmCount % 16;
                if (remainder == 0)
                {
                    DataLen = StirAlarmCount / 16;
                }
                else if (remainder > 0)
                {
                    DataLen = (StirAlarmCount / 16) + 1;
                }

                object[] DataBuff = new object[DataLen];

                bool PLCRead = MasterPLC_Mitsubishi.Read(DataBlock.ToString(), DataAddress, DataLen, out DataBuff);

                if (!PLCRead)
                {
                    return;
                }

                //               PlcAlarmFlag[0] = ((int)DataBuff[0] & OptionSetting.BinArray[0]) == OptionSetting.BinArray[0];
                int k = 0;
                for (int j = 0; j < DataLen; j++)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (k < StirAlarmCount)
                        {
                            PlcAlarmFlag[k] = ((int)DataBuff[j] & OptionSetting.BinArray[i]) == OptionSetting.BinArray[i];
                            UpDateStirAlarmData(PlcAlarmFlag[k], k);
                            k++;
                        }
                        else if (k >= StirAlarmCount)
                        {
                            break;
                        }
                    }
                }
                
                #endregion
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        public static void UpDateStirAlarmData(bool flag, int row_no)
        {
            try
            {
                bool AlarmFlag = flag;

                if (StirAlarmInfo[row_no].AlarmFlag != AlarmFlag)
                {
                    string UpdateAlarmSql = string.Format(@"UpDate Sys_Alarm Set Alarm_Flag = {0},Alarm_Time = GetDate() Where ID = {1}",
                                                    Convert.ToInt32(AlarmFlag), StirAlarmInfo[row_no].AlarmID);
                    DataHelper.Fill(UpdateAlarmSql);

                    if (AlarmFlag) //如是报警状态 进行新纪录的记录并生成报警编号 GUID
                    {
                        string AlarmNo = Guid.NewGuid().ToString("N");
                        //存储报警
                        string AlarmSql = string.Format(@"Insert Into IMOS_TA_AlarmLog(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                    Equipment_Type,Equipment_Code, Equipment_Name,Alarm_Desc,Alarm_No,Create_Time)
                                                              Select '{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}','{10}',GetDate()",
                                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                          StirAlarmInfo[row_no].EquipmentType, StirAlarmInfo[row_no].EquipmentCode, StirAlarmInfo[row_no].EquipmentName, StirAlarmInfo[row_no].AlarmName, AlarmNo);
                        DataHelper.Fill(AlarmSql);

                        string UpdateAlarmSql1 = string.Format(@"UpDate Sys_Alarm Set Alarm_No = '{0}' Where ID = {1}", AlarmNo, StirAlarmInfo[row_no].AlarmID);

                        DataHelper.Fill(UpdateAlarmSql1);
                        StirAlarmInfo[row_no].AlarmNo = AlarmNo;
                    }
                    else //报警清除
                    {
                        string ClearAlarmSql = string.Format(@"UpDate IMOS_TA_AlarmLog Set Clear_Time = GetDate(),Alarm_No ='' Where Alarm_No = '{0}'", StirAlarmInfo[row_no].AlarmNo);
                        DataHelper.Fill(ClearAlarmSql);

                        StirAlarmInfo[row_no].AlarmNo = "";
                    }
                }

                StirAlarmInfo[row_no].AlarmFlag = AlarmFlag;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("处理报警信息异常.异常信息：" + ex.Message);
            }
            finally
            {

            }
        }

        private static void CheckScanStatusEvent(object o)//混流扫描设备1重连
        {
            try
            {

                #region 混流完成扫描
                for (int i = 0; i < 15; i++)
                {
                    SysBusinessFunction.WriteLog((i + 1).ToString() + "混流条码扫描设备断线重连中1");
                    Thread.Sleep(2);

                    byte[] arrMsgRec = new byte[1];

                    if (!BaseSystemInfo.BarScanBarConn[i])
                    {
                        try
                        {
                            if (BaseSystemInfo.BarScanBarConnCount[i] == 1)
                            {
                                SysBusinessFunction.WriteLog(string.Format((i + 1).ToString() + "-混流条码扫描设备断线重连中......，{0}", BaseSystemInfo.BarScanendPoint[i].ToString()));
                            }
                            BaseSystemInfo.BarScanBarConnCount[i]++;
                            BaseSystemInfo.BarScanSocket[i] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            BaseSystemInfo.BarScanSocket[i].Connect(BaseSystemInfo.BarScanendPoint[i]);
                            BaseSystemInfo.BarScanBarConn[i] = true;
                            SysBusinessFunction.WriteLog(string.Format((i + 1).ToString() + "-混流条码扫描设备重新连接成功，重连次数{0}，{1}", BaseSystemInfo.BarScanBarConnCount[i], BaseSystemInfo.BarScanendPoint[i].ToString()));
                            BaseSystemInfo.BarScanBarConnCount[i] = 0;
                        }
                        catch (SocketException ex)
                        {
                        }
                    }

                    try
                    {
                        int sLen = BaseSystemInfo.BarScanSocket[i].Send(arrMsgRec);
                        BaseSystemInfo.BarScanBarConn[i] = sLen == 1;
                    }
                    catch
                    {
                        BaseSystemInfo.BarScanBarConn[i] = false;
                    }

                }
            }
            #endregion
            finally
            {
                CheckScanStatusTimer1.Change(2000, Timeout.Infinite);
            }
        }



        public static bool ReadData(int Block, int Start, int Len, out object[] Buffer)
        {
            bool TempResult = false;
            Buffer = new object[Len];
            try
            {
                //if (BaseSystemInfo.PLCType == "1") // 三菱PLC
                //{
                //    TempResult = MasterPLC_Mitsubishi.Read(Block.ToString(), Start, Len, out Buffer);


                //}
                //else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
                //{
                //    TempResult = MasterPLC_Siemens.Read(Block.ToString(), Start, Len, out Buffer);
                //}


            }
            catch
            {
                TempResult = false;
            }
            finally
            {

            }
            return TempResult;

        }

        //下传数据
        public static bool WriteData(int Block, int Start, object[] Buffer)
        {
            bool TempResult = false;
            try
            {
                //if (BaseSystemInfo.PLCType == "1") // 三菱PLC
                //{
                //    TempResult = MasterPLC_Mitsubishi.Write(Block, Start, Buffer);
                //}
                //else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
                //{
                //    TempResult = MasterPLC_Siemens.Write(Block, Start, Buffer);
                //}
            }
            catch
            {

            }

            return TempResult;
        }
    }
}
