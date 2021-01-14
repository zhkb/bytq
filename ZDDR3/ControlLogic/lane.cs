using ControlLogic.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ControlLogic
{
    class lane
    {
        public static System.Threading.Timer GetDataTimer;  //重连
        public static void SystemInitialization()
        {
            //初始化PLC连接
            ControlMaster.SystemInitialization();
            GetDataTimer = new System.Threading.Timer(GetDataStaus, null, 0, Timeout.Infinite);
            //
        }

        private static void GetDataStaus(object state)
        {
            try
            {
                //获取PLC


            }
            catch
            {

            }
            finally
            {
                GetDataTimer.Change(500, Timeout.Infinite);
            }
        }
    }
}
