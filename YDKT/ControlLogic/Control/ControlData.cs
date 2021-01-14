using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;

namespace ControlLogic
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    public class ControlData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        public static MPlcLink MasterPLC = new MPlcLink(); //PLC
        public static MPlcLink CheckOnlinePLC = new MPlcLink(); //PLC
        public static bool MasterPLCPLCConn = false;//PLC状态

        public static int StirAlarmCount = 1000;//报警数量


        public static System.Threading.Timer GetAlarmDataTimer; //读取报警信息

        public static System.Threading.Timer CheckPlcStatusTimer;  //检测PLC在线状态


        public static AlarmInfo[] StirAlarmInfo = new AlarmInfo[StirAlarmCount]; //搅拌罐报警


        public static void SystemInitialization()//初始化
        {
            //初始化PLC连接
            MasterPLC.ActLogicalStationNumber = 1;
            MasterPLCPLCConn = MasterPLC.Open();

            SysBusinessFunction.WriteLog("1#plc" + BaseSystemInfo.MasterPLCIP);
            MasterPLCPLCConn = MasterPLC.Open();

            //  GetAlarmDataTimer = new System.Threading.Timer(GetAlarmData, null, 0, Timeout.Infinite);//取得报警信息PLC数据

            CheckPlcStatusTimer = new System.Threading.Timer(CheckPlcOnLineStatus, null, 0, Timeout.Infinite);//检测PLC在线状态timer


        }




        private static void CheckPlcOnLineStatus(object o)//检查各PLC的在线状态 离线进行重连
        {
            try
            {
                //PLC连接
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



    }
}
