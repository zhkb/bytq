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

    public class BackControl
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private static SPlcLink MasterPLC = new SPlcLink();
        private static SPlcLink ReConnectPLC = new SPlcLink();
        public static bool MasterPLCPLCConn = false;//设备PLC状态
        public static System.Threading.Timer ReconnectionTimer;  //重连
        public static System.Threading.Timer GetPLCBFlagTimer; //读取plc标志位（发泡前）
        public static System.Threading.Timer GetPLCAFlagTimer; //读取plc标志位（发泡后）

        #region 从PLC读取实际重量
        /// <summary>
        /// 初始化
        /// </summary>
        public static void SystemInitialization()
        {
            //初始化PLC连接
            MasterPLC.PLCConnectionIP = BaseSystemInfo.MasterPLCIP_First;
            MasterPLC.PLCConNo = 11;
            MasterPLCPLCConn = MasterPLC.Open();
            GetPLCBFlagTimer = new System.Threading.Timer(GetPLCBFlag, null, 0, Timeout.Infinite);
            GetPLCAFlagTimer = new System.Threading.Timer(GetPLCAFlag, null, 0, Timeout.Infinite);
            ReconnectionTimer = new System.Threading.Timer(PLCReConnect, null, 0, Timeout.Infinite);
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
                ReConnectPLC.PLCConnectionIP = BaseSystemInfo.MasterPLCIP_First;
                //  ReConnectPLC.PLCConNo = 12;
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
                SysBusinessFunction.WriteLog("重连." + ex.Message);
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
    }
}
