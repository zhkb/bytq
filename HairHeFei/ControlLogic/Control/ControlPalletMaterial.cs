using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ControlLogic.Control
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;

    public class ControlPalletMaterial
    {
        #region 以太网扫码器变量
        private static Socket ScanSocket; //扫码枪
        private static IPEndPoint ScanPoint;//IP及端口信息
        private static bool ScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private static int BarReConnCount = 0;
        #endregion

        #region 初始化
        public static void SystemInitialization()//初始化
        {
            CreateBarScanSocket();//初始化以太网Socket
            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite);
        }
        #endregion

        #region 以太网扫码器创建
        private static void CreateBarScanSocket()//创建Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanProIP);//IP地址
            ScanPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanProPort));//端口号
            ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocket.Blocking = true;
            try
            {
                ScanSocket.Connect(ScanPoint);
                ScanSocket.Blocking = false;
                ScanConn = true;
            }
            catch (SocketException ex)
            {
                ScanConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanProPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            InSocketThread = new Thread(BarScanInRecMsg);
            InSocketThread.IsBackground = true;
            InSocketThread.Start();
            #endregion
        }

        private static void BarScanInRecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(5);
                byte[] arrMsgRec = new byte[50];
                // 将接受到的数据存入到arrMsgRec中；  
                int length = -1;
                try
                {
                    length = ScanSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    ScanConn = true;
                }
                catch
                {
                   ScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (ScanConn))
                {
                    HandleScanBarData(strMsg.Trim());
                }
            }
        }

        private static void HandleScanBarData(string BarCode)
        {
            try
            {
                string g_s_Data = BarCode;
                string Sql = string.Format(@"SELECT Pallet_Code FROM IMOS_Lo_Spreader WHERE Pallet_Code = '{0}'", g_s_Data);
                DataSet ds = DataHelper.Fill(Sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.PalletCode = ds.Tables[0].Rows[0]["Pallet_Code"].ToString();
                    OptionSetting.PalletMsgInfo = "扫描吊笼条码为" + g_s_Data;                   
                    OptionSetting.PalletMsgColorRed = false;
                }
                else
                {
                    Sql = string.Format(@"SELECT Pallet_Code , Qty  FROM IMOS_Lo_Pallet WHERE Pallet_Code = '{0}'", g_s_Data);
                    ds = DataHelper.Fill(Sql);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        OptionSetting.SpreaderCode = ds.Tables[0].Rows[0]["Pallet_Code"].ToString();
                        OptionSetting.PalletQty = int.Parse(ds.Tables[0].Rows[0]["Qty"].ToString());
                        OptionSetting.PalletMsgInfo = "扫描小车条码为" + g_s_Data;
                        OptionSetting.PalletScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        OptionSetting.PalletMsgColorRed = false;
                    }
                    else
                    {
                        OptionSetting.PalletMsgInfo = "读取条码失败" + g_s_Data;
                        OptionSetting.PalletMsgColorRed = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region 以太网扫码器重连
        public static void ReConnectDevice(object o)//socket重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!ScanConn)
                {
                    try
                    {
                        if (BarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("能耗贴条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocket.Connect(ScanPoint);
                        ScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("能耗贴条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, ScanPoint.ToString()));
                        BarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = ScanSocket.Send(arrMsgRec);
                    ScanConn = sLen == 1;
                }
                catch
                {
                    ScanConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                ReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion
   
    }

}
