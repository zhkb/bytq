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
        private static S7Client MasterPLC = new S7Client();
        private static System.Threading.Timer CheckPlcStatusTimer;//检查西门子PLC设备连接状态Time  

        private static MPlcLink MasterPLC_Mitsubishi = new MPlcLink();
        private static MPlcLink ReConnectPLC_Mitsubishi = new MPlcLink();

        private static int Rack = 0;
        private static int Slot = 0;
        private static int Count=0;
        private static bool MasterPLCPLCConn = false;//设备西门子PLC状态
        private static System.Threading.Timer MPReconnectionTimer;  //检查三菱PLC设备连接状态Time  
        /// 初始化
        public static void SystemInitialization()
        {

            if (BaseSystemInfo.PLCType == "1") // 三菱PLC
            {
                MasterPLC_Mitsubishi.ActLogicalStationNumber = int.Parse(BaseSystemInfo.MasterPLCStation);
                ReConnectPLC_Mitsubishi.ActLogicalStationNumber = MasterPLC_Mitsubishi.ActLogicalStationNumber;
                MasterPLCPLCConn = MasterPLC_Mitsubishi.Open();
                WriteData(0, 0, new object[1] {"1" });
                MPReconnectionTimer = new System.Threading.Timer(PLCReConnect, null, 0, Timeout.Infinite);


            }
            else if (BaseSystemInfo.PLCType == "2") // 西门子PLC
            {
                //初始化PLC连接
                int Result = 1;
                Result = MasterPLC.ConnectTo(BaseSystemInfo.LinerInScanIP, Rack, Slot);
                if (Result == 0)
                {
                    CheckPlcStatusTimer = new System.Threading.Timer(CheckPLCConnectionStatus, null, 0, Timeout.Infinite);
                }
            }
          
            
            
          
        }
        //读取数据方法
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
                    TempResult = MasterPLC.Read(Block.ToString(), Start, Len, out Buffer);
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


        //存储数据方法
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
                    TempResult = MasterPLC.Write(Block, Start, Buffer);
                }
            }
            catch
            {

            }

            return TempResult;
        }

        



        // 西门子PLC重连
        private static void CheckPLCConnectionStatus(object o)
        {
            try
            {
                if (MasterPLC.Connected)
                {
                    
                }
                else
                {
                    int Result = 1;
                    Result = MasterPLC.ConnectTo(BaseSystemInfo.LinerInScanIP, Rack, Slot);
                    if(Result == 0)
                    {
                        Count = 0;
                        SysBusinessFunction.WriteLog("PLC重连成功！重连次数【" + Count + "】");
                    }
                    else
                    {
                        Count ++;
                        SysBusinessFunction.WriteLog("PLC重连失败！重连次数【" + Count + "】");
                    }
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

        //三菱PLC重连
        public static void PLCReConnect(object o)
        {
            try
            {
                ReConnectPLC_Mitsubishi.Close();
                MasterPLCPLCConn = ReConnectPLC_Mitsubishi.Open();
                 if (!MasterPLCPLCConn)
                  {
                    MasterPLC_Mitsubishi.Close();
                    MasterPLCPLCConn = MasterPLC_Mitsubishi.Open();
                  }
               
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("1# PLC重连失败." + ex.Message);
            }
            finally
            {
                if (MPReconnectionTimer != null)
                {
                    MPReconnectionTimer.Change(3000, Timeout.Infinite);
                }
            }
        }


    }

}

