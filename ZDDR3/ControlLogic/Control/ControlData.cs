using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace ControlLogic.Control
{
    using Sys.Config;
    using Sys.SysBusiness;
    using ControlLogic.BarCode;
    using Sys.DbUtilities;
    using Communication;
    using System.Runtime.InteropServices;
    using System.Data;
    using System.Net.Sockets;
    using System.Net;

    public class ControlData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private static MPlcLink MasterPLC = new MPlcLink();
        private static MPlcLink ReConnectPLC = new MPlcLink();
        public static bool MasterPLCPLCConn = false;//设备PLC状态
        public static System.Threading.Timer ReconnectionTimer;  //重连
        public static System.Threading.Timer GetPLCBFlagTimer; //读取plc标志位（发泡前）
        public static System.Threading.Timer GetPLCAFlagTimer; //读取plc标志位（发泡后）


        public static bool RFIDScanConnOne = false; //RFID扫描设备连接状态//WYF:转台RFID
        public static bool RFIDBarScanStateOne = false; //RFID条码扫描是否正常
        private static Thread RFIDScanSocketThreadOne = null; // 创建用于接收服务端消息的 
        private static Socket RFIDScanSocketOne = null;
        private static IPEndPoint RFIDScanPointOne;
        private static int RFIDScanReConnCountOne = 0;
        public static bool SerialPortStatusOne = false;
        private static int HisReceiveCountOne = 0;
        private static int ReceiveCountOne = 0;
        public static System.Threading.Timer CheckConnectionTimerOne;  //检查RFID设备ONE连接状态Timer


        #region 
        /// <summary>
        /// 初始化
        /// </summary>
        public static void SystemInitialization()
        {
            //初始化PLC连接
            MasterPLC.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation_First);
            MasterPLCPLCConn = MasterPLC.Open();

            if (BaseSystemInfo.CurrentProcessCode == "108")
            {
                InitSocket1();
                CheckConnectionTimerOne = new System.Threading.Timer(CheckConnectionStatusOne, null, 0, Timeout.Infinite);
            }
            else
            {
                GetPLCBFlagTimer = new System.Threading.Timer(GetPLCBFlag, null, 0, Timeout.Infinite);
                GetPLCAFlagTimer = new System.Threading.Timer(GetPLCAFlag, null, 0, Timeout.Infinite);
                ReconnectionTimer = new System.Threading.Timer(PLCReConnect, null, 0, Timeout.Infinite);
            }
        }
        /// <summary>
        /// 读取发泡前称量标志位
        /// </summary>
        /// <param name="o"></param>
        public static void GetPLCBFlag(object o)
        {
            try
            {
                Thread.Sleep(10);
                int Start = 0;
                int Block = 1;
                int Len = 50;
                object[] Buf = new object[Len];
                bool PLCRead = MasterPLC.Read(Block.ToString(), Start, Len, out Buf);
                if (!PLCRead)
                {
                    return;
                }
                //称量实时重量信息
                GetPLCBRealTimeData(Buf);
                //称重完成标志位
                if ((int)Buf[0] == 1)
                {
                    object[] BackBuff = new object[1];
                    BackBuff[0] = 2;
                    MasterPLC.Write(Block, Start, BackBuff);
                    //UpdatePLCBData();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("读取发泡前称量标志位异常." + ex.Message);
            }
            finally
            {
                GetPLCBFlagTimer.Change(1000, Timeout.Infinite);
            }

        }
        /// <summary>
        /// 读取发泡前实时称量数据
        /// </summary>
        public static void GetPLCBRealTimeData(object[] dataBuf)
        {

            try
            {
                string BBarCode = "";
                for (int i = 0; i < 25; i++) //读取PLC数据 取得相应的计划编号 计划编号长度为50位 每个字占用2字符
                {
                    int AsciiCode = (int)dataBuf[i + 1];
                    if (AsciiCode == 0)
                    {
                        break;
                    }
                    BBarCode = BBarCode + SysBusinessFunction.ReverseString(SysBusinessFunction.BinaryToStr(AsciiCode));
                }
                if (BBarCode == OptionSetting.CurrentBeforeBarcode)
                {
                    MonitorInfo.BRealWeight = (int)(Convert.ToDecimal((int)dataBuf[26] + (int)dataBuf[27] * 65536) / 10) / 1000.0;   // 物料实时重量                   
                    UpdatePLCBData();
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("读取发泡前称量数据异常." + ex.Message);
            }

        }
        /// <summary>
        /// 更新发泡前称量数据
        /// </summary>
        public static void UpdatePLCBData()
        {
            try
            {
                string ssSQL = string.Format(@"UPDATE [IMOS_PR_FoamingWeigh] SET 
                                                 [Foaming_Weight_Before]={0}, 
                                                 [Foaming_Time_Bfter]=GETDATE(),                                                 
                                                 WHERE Company_Code = '{1}' AND Factory_Code = '{2}' AND Product_Line_Code = '{3}' AND Product_BarCode = '{4}'",
                                                   MonitorInfo.BRealWeight, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, OptionSetting.CurrentBeforeBarcode
                                                   );
                DataSet ds = DataHelper.Fill(ssSQL);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("更新发泡前称量数据异常." + ex.Message);
            }
        }
        /// <summary>
        /// 读取发泡后称量标志位
        /// </summary>
        /// <param name="o"></param>
        public static void GetPLCAFlag(object o)
        {
            try
            {
                Thread.Sleep(10);
                int Start = 50;
                int Block = 1;
                int Len = 100;
                object[] Buf = new object[Len];
                bool PLCRead = MasterPLC.Read(Block.ToString(), Start, Len, out Buf);
                if (!PLCRead)
                {
                    return;
                }

                //称量实时重量信息
                GetPLCARealTimeData(Buf);
                //称重完成标志位
                if ((int)Buf[0] == 1)
                {
                    object[] BackBuff = new object[1];
                    BackBuff[0] = 2;
                    MasterPLC.Write(Block, Start, BackBuff);
                    //UpdatePLCAData();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("读取发泡后称量标志位异常." + ex.Message);
            }
            finally
            {
                if (GetPLCAFlagTimer != null)
                {
                    GetPLCAFlagTimer.Change(1000, Timeout.Infinite);
                }
            }
        }
        /// <summary>
        /// 读取发泡后实时称量数据
        /// </summary>
        public static void GetPLCARealTimeData(object[] dataBuf)
        {

            try
            {
                string ABarCode = "";
                for (int i = 0; i < 25; i++) //读取PLC数据 取得相应的计划编号 计划编号长度为50位 每个字占用2字符
                {
                    int AsciiCode = (int)dataBuf[i + 1];
                    if (AsciiCode == 0)
                    {
                        break;
                    }
                    ABarCode = ABarCode + SysBusinessFunction.ReverseString(SysBusinessFunction.BinaryToStr(AsciiCode));
                }
                if (ABarCode == OptionSetting.CurrentAfterBarcode)
                {
                    MonitorInfo.ARealWeight = (int)(Convert.ToDecimal((int)dataBuf[26] + (int)dataBuf[27] * 65536) / 10) / 1000.0;   // 物料重量                   
                    UpdatePLCAData();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("读取发泡后称量数据异常." + ex.Message);
            }

        }
        /// <summary>
        /// 更新发泡后称量数据
        /// </summary>
        public static void UpdatePLCAData()
        {
            try
            {
                string ssSQL = string.Format(@"UPDATE [IMOS_PR_FoamingWeigh] SET 
                                                 [Foaming_Weight_After]={0}, 
                                                 [Foaming_Time_After]=GETDATE(),
                                                 [Foaming_Weight_Actual]={5}
                                                 WHERE Company_Code = '{1}' AND Factory_Code = '{2}' AND Product_Line_Code = '{3}' AND Product_BarCode = '{4}'",
                                                 MonitorInfo.ARealWeight, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, OptionSetting.CurrentAfterBarcode
                                                 , MonitorInfo.ARealWeight - MonitorInfo.BRealWeight);
                DataSet ds = DataHelper.Fill(ssSQL);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("更新发泡后称量数据异常." + ex.Message);
            }
        }
        public static void PLCReConnect(object o)
        {
            try
            {
                ReConnectPLC.Close();
                ReConnectPLC.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation_Sencond);
            //    ReConnectPLC.PLCConNo = 12;
                MasterPLCPLCConn = ReConnectPLC.Open();

                if (!MasterPLCPLCConn)
                {
                    MasterPLC.Close();
                    //MasterPLC.PLCConnectionIP = BaseSystemInfo.MasterPLCIP;
                    //MasterPLC.PLCConNo = 11;
                    MasterPLCPLCConn = MasterPLC.Open();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("1#PLC重连." + ex.Message);
            }
            finally
            {
                if (ReconnectionTimer != null)
                {
                    ReconnectionTimer.Change(5000, Timeout.Infinite);
                }
            }
        }
        #endregion



        private static void InitSocket1()
        {
            IPAddress RFIDSanIPOne = IPAddress.Parse(BaseSystemInfo.IPAddress1);//IP
            RFIDScanPointOne = new IPEndPoint(RFIDSanIPOne, int.Parse(BaseSystemInfo.IPEndPoint1));//端口
            RFIDScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            RFIDScanSocketOne.Blocking = true;
            try
            {
                RFIDScanSocketOne.Connect(RFIDScanPointOne);
                RFIDScanConnOne = true;
            }
            catch (SocketException ex)
            {
                RFIDScanConnOne = false;
                string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址{0}端口{1}，", RFIDSanIPOne, RFIDScanPointOne);
                SysBusinessFunction.WriteLog(TipInfo);
            }
            RFIDScanSocketThreadOne = new Thread(Socket1RecMsgThread);
            RFIDScanSocketThreadOne.IsBackground = true;
            RFIDScanSocketThreadOne.Start();
        }

        private static void CheckConnectionStatusOne(object o)
        {
            try
            {
                Thread.Sleep(5);

                SerialPortStatusOne = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCountOne = ReceiveCountOne;
                byte[] arrMsgRec = new byte[1];
                arrMsgRec[0] = 0x33;


                if (!RFIDScanConnOne)
                {
                    try
                    {
                        if (RFIDScanReConnCountOne == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", RFIDScanPointOne.ToString()));
                        }
                        RFIDScanReConnCountOne++;
                        RFIDScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        RFIDScanSocketOne.Blocking = true;
                        RFIDScanSocketOne.Connect(RFIDScanPointOne);
                        RFIDScanConnOne = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", RFIDScanReConnCountOne, RFIDScanPointOne.ToString()));
                        RFIDScanReConnCountOne = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = RFIDScanSocketOne.Send(arrMsgRec); //检测发送与接收数据的
                    RFIDScanConnOne = sLen == 1;
                }
                catch
                {
                    RFIDScanConnOne = false;
                }
            }
            catch
            {
            }
            finally
            {
                CheckConnectionTimerOne.Change(10000, 5000);
            }
        }


        public static void Socket1RecMsgThread()
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
                    length = RFIDScanSocketOne.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    RFIDScanConnOne = true;
                }
                catch
                {
                    SysBusinessFunction.WriteLog("扫描设备1心跳信息号失败.");
                    RFIDScanConnOne = false;
                    continue;
                }
                if (strMsg.Trim() == "NO READ")
                {
                    SysBusinessFunction.WriteLog("读取条码为：NO READ");
                }


                SysBusinessFunction.WriteLog("读取条码为：" + strMsg + "-状态" + RFIDScanConnOne.ToString());
                if ((strMsg.Trim().Length > 0) && (RFIDScanConnOne) && strMsg.Trim() != "NO READ")
                {

                    string code = strMsg.Trim();//获取条码
                    OptionSetting.G_productCodeA = code;
                    string Msg = "";
                    Msg = "读取条码信息成功！条码为" + code;
                    OptionSetting.G_productCodeMSG = Msg;
                    SysBusinessFunction.WriteLog(Msg);
                    OptionSetting.G_productCodeIsSuccessFlag = "1";
                }
                else
                {
                    string Msg = "扫描条码信息失败，请重新扫描！条码：" + strMsg.ToString();

                    OptionSetting.G_productCodeMSG = Msg;
                    SysBusinessFunction.WriteLog(Msg);
                    OptionSetting.G_productCodeIsSuccessFlag = "0";
                }
            }
        }

        
        public static bool WritePLCdata(int iData)
        {
            try
            {
                Thread.Sleep(10);
                int Block = 1;
                int Start = 0;
                int Len = 2;

                object[] WriteBuff = new object[2];
                WriteBuff[0] = 1;
                WriteBuff[1] = iData;
                bool PLCWrite = MasterPLC.Write(Block, Start, WriteBuff);
                return PLCWrite;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("WritePLCdata异常:" + ex.Message);
                return false; 
            }
        }
        public static bool WritePLCData(int DataBlock, int DataAddress, object[] DataBuff)
        {
            try
            {
                bool PLCWrite = MasterPLC.Write(DataBlock, DataAddress, DataBuff);
                return PLCWrite;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("WritePLCdata异常:" + ex.Message);
                return false;
            }
        }

        public static bool ReadPLCData(int DataBlock, int DataAddress, int DataLen, out object[] DataBuff)
        {
            try
            {
                DataBuff = new object[DataLen];
                bool PLCRead = MasterPLC.Read(DataBlock.ToString(), DataAddress, DataLen, out DataBuff);
                return PLCRead;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("WritePLCdata异常:" + ex.Message);
                DataBuff = null;
                return false; 
            }
       }
    }
}
