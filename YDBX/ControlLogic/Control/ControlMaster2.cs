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

    public class ControlMaster2
    {
        private static SPlcLink MasterPLC_Siemens = new SPlcLink();
        private static SPlcLink ReConnectPLC_Siemens = new SPlcLink();

        private static MPlcLink MasterPLC_Mitsubishi = new MPlcLink();
        private static MPlcLink ReConnectPLC_Mitsubishi = new MPlcLink();

        public static bool MasterPLCPLCConn_siemens = false;//西门子设备PLC状态
        public static bool MasterPLCPLCConn_Mitsubishi = false;//三菱设备PLC状态

        public static System.Threading.Timer ReconnectionTimer;  //重连

        /// 初始化
        public static void SystemInitialization()
        {
            //初始化PLC连接

            //if (BaseSystemInfo.PLCType == "1") // 三菱PLC
            {
                MasterPLC_Mitsubishi.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation);
                MasterPLCPLCConn_Mitsubishi = MasterPLC_Mitsubishi.Open();

            }
            //else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
            {
                MasterPLC_Siemens.PLCConnectionIP = BaseSystemInfo.MasterPLCStation;
                MasterPLC_Siemens.PLCConNo = 1;
                MasterPLCPLCConn_siemens = MasterPLC_Siemens.Open();
            }
            ReconnectionTimer = new System.Threading.Timer(PLCReConnect, null, 0, Timeout.Infinite);
        }

        // PLC重连
        public static void PLCReConnect(object o)
        {
            try
            {
                //if (BaseSystemInfo.PLCType == "1") // 三菱PLC
                {
                    ReConnectPLC_Mitsubishi.Close();
                    ReConnectPLC_Mitsubishi.ActLogicalStationNumber = MasterPLC_Mitsubishi.ActLogicalStationNumber;
                    MasterPLCPLCConn_Mitsubishi = ReConnectPLC_Mitsubishi.Open();

                    if (!MasterPLCPLCConn_Mitsubishi)
                    {
                        MasterPLC_Mitsubishi.Close();
                        MasterPLCPLCConn_Mitsubishi = MasterPLC_Mitsubishi.Open();
                    }
                }

                //if (BaseSystemInfo.PLCType == "2") // 西门子PLC
                {
                    ReConnectPLC_Siemens.Close();
                    ReConnectPLC_Siemens.PLCConnectionIP = MasterPLC_Siemens.PLCConnectionIP;
                    ReConnectPLC_Siemens.PLCConNo = 11;
                    MasterPLCPLCConn_siemens = ReConnectPLC_Siemens.Open();

                    if (!MasterPLCPLCConn_siemens)
                    {
                        MasterPLC_Siemens.Close();
                        MasterPLCPLCConn_siemens = MasterPLC_Siemens.Open();
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
        public static bool ReadData_siemens(int Block, int Start, int Len, out object[] Buffer)
        {//西门子
            bool TempResult = false;
            Buffer = new object[Len];
            try
            {
                TempResult = MasterPLC_Siemens.Read(Block.ToString(), Start, Len, out Buffer);
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

        public static bool ReadData_Mitsubishi(int Block, int Start, int Len, out object[] Buffer)
        {//三菱
            bool TempResult = false;
            Buffer = new object[Len];
            try
            {
                TempResult = MasterPLC_Mitsubishi.Read(Block.ToString(), Start, Len, out Buffer);
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
        public static bool WriteData_siemens(int Block, int Start, object[] Buffer)
        {//西门子
            bool TempResult = false;
            try
            {
                TempResult = MasterPLC_Siemens.Write(Block, Start, Buffer);
            }
            catch
            {

            }

            return TempResult;
        }

        public static bool WriteData_Mitsubishi(int Block, int Start, object[] Buffer)
        {//三菱
            bool TempResult = false;
            try
            {
                TempResult = MasterPLC_Mitsubishi.Write(Block, Start, Buffer);
            }
            catch
            {

            }

            return TempResult;
        }

    }

}

