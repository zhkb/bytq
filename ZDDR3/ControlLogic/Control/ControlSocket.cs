using Sys.Config;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ControlLogic.Control
{
    public class ControlSocket
    {
        #region 扫码器变量
        //扫码器A
        public static bool SocketScanConnA = false; //扫码器A连接状态

        private static Thread ScanSocketThreadA = null; // 创建用于接收服务端消息的线程
        private static Socket ScanSocketA = null;//扫码器A实例
        private static IPEndPoint ScanPointA;//扫码器A端口
        private static int SocketScanReConnCountA = 0;//扫码器A重连次数
        public static bool SerialPortStatusA = false;//
        public static System.Threading.Timer ACheckConnectionTimer;  //检查扫码设备A连接状态Timer

        //扫码器B
        public static bool SocketScanConnB = false; //扫码器B连接状态

        private static Thread ScanSocketThreadB = null; // 创建用于接收服务端消息的线程
        private static Socket ScanSocketB = null;//扫码器B实例
        private static IPEndPoint ScanPointB;//扫码器B端口
        private static int SocketScanReConnCountB = 0;//扫码器B重连次数
        public static bool SerialPortStatusB = false;
        public static System.Threading.Timer BCheckConnectionTimer;  //检查扫码设备B连接状态Timer
        #endregion

        public static void SystemInitialization()
        {
            CreateBarScanSocketA();
            ACheckConnectionTimer = new System.Threading.Timer(CheckConnectionStatusA, null, 0, Timeout.Infinite);
            CreateBarScanSocketB();
            BCheckConnectionTimer = new System.Threading.Timer(CheckConnectionStatusB, null, 0, Timeout.Infinite);
        }

        private static void CheckConnectionStatusB(object state)
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!SocketScanConnB)
                {
                    try
                    {
                        if (SocketScanReConnCountB == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", SocketScanReConnCountB.ToString()));
                        }
                        SocketScanReConnCountB++;
                        ScanSocketB = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketB.Connect(ScanPointB);
                        SocketScanConnB = true;
                        SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备重新连接成功，重连次数{0}，{1}", SocketScanReConnCountB, ScanPointB.ToString()));
                        SocketScanReConnCountB = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = ScanSocketB.Send(arrMsgRec);
                    SocketScanConnB = sLen == 1;
                }
                catch
                {
                    SocketScanConnB = false;
                }
            }
            catch
            {
            }
            finally
            {
                BCheckConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }

        private static void CheckConnectionStatusA(object state)
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!SocketScanConnA)
                {
                    try
                    {
                        if (SocketScanReConnCountA == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", SocketScanReConnCountA.ToString()));
                        }
                        SocketScanReConnCountA++;
                        ScanSocketA = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketA.Connect(ScanPointA);
                        SocketScanConnA = true;
                        SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备重新连接成功，重连次数{0}，{1}", SocketScanReConnCountA, ScanPointA.ToString()));
                        SocketScanReConnCountA = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = ScanSocketA.Send(arrMsgRec);
                    SocketScanConnA = sLen == 1;
                }
                catch
                {
                    SocketScanConnA = false;
                }
            }
            catch
            {
            }
            finally
            {
                ACheckConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }

        public static void CreateBarScanSocketA()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIPA);//IP地址
            ScanPointA = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPortA));//端口号
            ScanSocketA = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket扫码器对象
            ScanSocketA.Blocking = true;
            try
            {
                ScanSocketA.Connect(ScanPointA);
                ScanSocketA.Blocking = false;
                SocketScanConnA = true;
            }
            catch (SocketException ex)
            {
                SocketScanConnA = false;//扫码器处于连接失败状态
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanPort_1);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThreadA = new Thread(SocketARecMsg);
            ScanSocketThreadA.IsBackground = true;
            ScanSocketThreadA.Start();
            #endregion
        }
        public static void CreateBarScanSocketB()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIPB);//IP地址
            ScanPointB = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPortB));//端口号
            ScanSocketB = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket扫码器对象
            ScanSocketB.Blocking = true;
            try
            {
                ScanSocketB.Connect(ScanPointA);
                ScanSocketB.Blocking = false;
                SocketScanConnB = true;
            }
            catch (SocketException ex)
            {
                SocketScanConnB = false;//扫码器处于连接失败状态
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanPort_1);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThreadB = new Thread(SocketBRecMsg);
            ScanSocketThreadB.IsBackground = true;
            ScanSocketThreadB.Start();
            #endregion
        }

        private static void SocketBRecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(10);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = ScanSocketB.Receive(arrMsgRec); // 接收数据，并返回数据的长度
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    SocketScanConnB = true;

                }
                catch (Exception ex)
                {
                    SocketScanConnB = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (SocketScanConnB))
                {
                    OptionSetting.G_productCodeA = strMsg.Trim();
                    if (OptionSetting.G_productCodeA.ToUpper() == "NOREAD")
                    {
                        string Msg = "读取条码信息失败！NO READ";
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.G_productCodeIsSuccessFlag = "0";
                    }
                    else if (OptionSetting.G_productCodeA.Trim().Length != 20)
                    {
                        string Msg = "";
                        Msg = "读取条码成功,但是条码不规范！条码为" + OptionSetting.G_productCodeA;
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.G_productCodeIsSuccessFlag = "0";
                    }
                    else
                    {
                        string Msg = "";
                        Msg = "读取条码成功！条码为" + OptionSetting.G_productCodeA;
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.G_productCodeIsSuccessFlag = "1";
                    }
                }
            }
        }

        private static void SocketARecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(10);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = ScanSocketA.Receive(arrMsgRec); // 接收数据，并返回数据的长度
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    SocketScanConnA = true;

                }
                catch (Exception ex)
                {
                    SocketScanConnA = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (SocketScanConnA))
                {
                    OptionSetting.G_productCodeA = strMsg.Trim();
                    if (OptionSetting.G_productCodeA.ToUpper() == "NOREAD")
                    {
                        string Msg = "读取条码信息失败！NO READ";
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.G_productCodeIsSuccessFlag = "0";
                    }
                    else if (OptionSetting.G_productCodeA.Trim().Length != 20)
                    {
                        string Msg = "";
                        Msg = "读取条码成功,但是条码不规范！条码为" + OptionSetting.G_productCodeA;
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.G_productCodeIsSuccessFlag = "0";
                    }
                    else
                    {
                        string Msg = "";
                        Msg = "读取条码成功！条码为" + OptionSetting.G_productCodeA;
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.G_productCodeIsSuccessFlag = "1";
                    }
                }
            }
        }


    }
}
