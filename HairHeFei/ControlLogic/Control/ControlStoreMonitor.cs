using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLogic.Control
{
    public class ControlStoreMonitor
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        public static System.Threading.Timer GetStoreDataTimer; //接受PLC库存数据
        public static int kcount = 1;

        public static void SystemInitialization()//初始化
        {
           
            GetStoreDataTimer = new System.Threading.Timer(GetPLCDevice, null, 0, Timeout.Infinite);

        }

        private static void GetPLCDevice(object state)
        {
            try
            {
                //PLC获取产品型号
                Thread.Sleep(50);
                int address = BaseSystemInfo.KCaddress;
                int block = 0;
                int len = 80;
                object[] Rbuf = new object[len];
                bool result = ControlXPLC.ReadData(block, address, len, out Rbuf);
                if (result)
                {
                    OptionSetting.StoreBuff = Rbuf;
                }
                else
                {
                    SysBusinessFunction.WriteLog("库存数据读取失败！");
                }
                String sql = String.Format(@"SELECT Material_Code,Material_Name,Material_Sort From IMOS_TA_Material Where 1=1");
                OptionSetting.BinDetailds = DataHelper.Fill(sql);

                if (BaseSystemInfo.MCXFlag.ToString() == BaseSystemInfo.CurrentINStoreCode)
                {
                    //执行到哪里了
                    int Maddress = BaseSystemInfo.MMAddress;
                    int Mlen = 1;
                    object[] MRbuf = new object[Mlen];
                    bool Mresult = ControlXPLC.ReadData(0, Maddress, Mlen, out MRbuf);
                    if (Mresult)
                    {
                        kcount = (int.Parse(MRbuf[0].ToString()) + 1) / 2;
                    }

                    int FPaddress = BaseSystemInfo.FPAddress;
                    int FPblock = 0;
                    int FPlen = 52;
                    object[] FPRbuf = new object[FPlen];
                    bool FPresult = ControlXPLC.ReadData(FPblock, FPaddress, FPlen, out FPRbuf);
                    if (FPresult)
                    {
                        for (int i = 0; i < FPRbuf.Length; i = i + 2)
                        {
                            int m = i / 2;
                            if ((m + 1) == kcount)
                            {
                                String ksql = String.Format(@"UPDATE IMOS_Lo_FP_List  SET  Material_Sort = '{0}',Use_Flag = {2}  WHERE ID = '{1}'", FPRbuf[i].ToString(), m + 1, "1");
                                DataHelper.Fill(ksql);
                            }
                            else
                            {
                                String ksql = String.Format(@"UPDATE IMOS_Lo_FP_List  SET  Material_Sort = '{0}',Use_Flag = {2}  WHERE ID = '{1}'", FPRbuf[i].ToString(), m + 1, "0");
                                DataHelper.Fill(ksql);
                            }

                        }
                    }

                    
                }
              



            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("异常=》获取PLC库存信息异常"+ex.Message);
            }
            finally
            {
                GetStoreDataTimer.Change(3000, Timeout.Infinite);
            }

        }
    }
}
