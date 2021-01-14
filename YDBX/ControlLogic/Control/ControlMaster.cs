using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using Communication;
using System.IO;
using System.Windows.Forms;

namespace ControlLogic.Control
{
    using Sys.Config;
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using System.Runtime.InteropServices;
    using System.Data;

    public class ControlMaster
    {
        private static SPlcLink MasterPLC_Siemens = new SPlcLink();
        private static SPlcLink ReConnectPLC_Siemens = new SPlcLink();

        private static MPlcLink MasterPLC_Mitsubishi = new MPlcLink();
        private static MPlcLink ReConnectPLC_Mitsubishi = new MPlcLink();

        public static bool MasterPLCPLCConn = false;//设备PLC状态

        public static System.Threading.Timer ReconnectionTimer;  //重连

        /// 初始化
        public static void SystemInitialization()
        {
            //初始化PLC连接

            if (BaseSystemInfo.PLCType == "1") // 三菱PLC
            {
                MasterPLC_Mitsubishi.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation);
                MasterPLCPLCConn = MasterPLC_Mitsubishi.Open();

            }
            else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
            {
                MasterPLC_Siemens.PLCConnectionIP = BaseSystemInfo.MasterPLCStation;
                MasterPLC_Siemens.PLCConNo = 1;
                MasterPLCPLCConn = MasterPLC_Siemens.Open();
            }
            ReconnectionTimer = new System.Threading.Timer(PLCReConnect, null, 0, Timeout.Infinite);
        }

        // PLC重连
        public static void PLCReConnect(object o)
        {
            try
            {
                if (BaseSystemInfo.PLCType == "1") // 三菱PLC
                {
                    ReConnectPLC_Mitsubishi.Close();
                    ReConnectPLC_Mitsubishi.ActLogicalStationNumber = MasterPLC_Mitsubishi.ActLogicalStationNumber;
                    MasterPLCPLCConn = ReConnectPLC_Mitsubishi.Open();

                    if (!MasterPLCPLCConn)
                    {
                        MasterPLC_Mitsubishi.Close();
                        MasterPLCPLCConn = MasterPLC_Mitsubishi.Open();
                    }
                }

                if (BaseSystemInfo.PLCType == "2") // 西门子PLC
                {
                    ReConnectPLC_Siemens.Close();
                    ReConnectPLC_Siemens.PLCConnectionIP = MasterPLC_Siemens.PLCConnectionIP;
                    ReConnectPLC_Siemens.PLCConNo = 11;
                    MasterPLCPLCConn = ReConnectPLC_Siemens.Open();

                    if (!MasterPLCPLCConn)
                    {
                        MasterPLC_Siemens.Close();
                        MasterPLCPLCConn = MasterPLC_Siemens.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("1# PLC重连失败." + ex.Message);
            }
            finally
            {
                if (ReconnectionTimer != null)
                {
                    ReconnectionTimer.Change(3000, Timeout.Infinite);
                }
            }
        }

        //读取数据
        public static bool ReadData(int Block, int Start, int Len, out object[] Buffer)
        {
            bool TempResult = false;
            Buffer = new object[Len];
            try
            {
                if (BaseSystemInfo.PLCType == "1") // 三菱PLC
                {
                    TempResult = MasterPLC_Mitsubishi.Read(Block.ToString(), Start, Len, out Buffer);


                }
                else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
                {
                    TempResult = MasterPLC_Siemens.Read(Block.ToString(), Start, Len, out Buffer);
                }


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
                if (BaseSystemInfo.PLCType == "1") // 三菱PLC
                {
                    TempResult = MasterPLC_Mitsubishi.Write(Block, Start, Buffer);
                }
                else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
                {
                    TempResult = MasterPLC_Siemens.Write(Block, Start, Buffer);
                }
            }
            catch
            {

            }

            return TempResult;
        }

    }

}

