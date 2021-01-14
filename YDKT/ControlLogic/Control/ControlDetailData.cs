using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLogic.Control
{
    public class ControlDetailData
    {
        #region 变量
        //条码2
        public static bool ScanConn = false; //扫描设备连接状态
        public static bool BarScanState = false; //条码扫描是否正常
        private static Thread ScanSocketThread = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocket = null;
        private static IPEndPoint ScanPoint;
        private static int ScanReConnCount = 0;
        public static bool SerialPortStatus = false;
        private static int HisReceiveCount = 0;
        private static int ReceiveCount = 0;
        public static System.Threading.Timer CheckConnectionTimer;  //检查设备ONE连接状态Timer

  
        #endregion

        #region 初始化
        public static void SystemInitialization()//初始化
        {

            if (ConfigHelper.GetValue("IsInitBarTwo") == "1")
            {
                
                Init();
                CheckConnectionTimer = new System.Threading.Timer(CheckConnectionStatus, null, 0, Timeout.Infinite);//以太网产品码扫码器
            }
        }

        #endregion

        #region 初始化
        private static void Init()
        {
            IPAddress SanIP = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP2"));//IP
            ScanPoint = new IPEndPoint(SanIP, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort2")));//端口
            ScanSocket= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocket.Blocking = true;
            try
            {
                ScanSocket.Connect(ScanPoint);
                ScanConn = true;
            }
            catch (SocketException ex)
            {
                ScanConn = false;
                string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址{0}端口{1}，", SanIP, ScanPoint);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThread = new Thread(ScanRecMsg);
            ScanSocketThread.IsBackground = true;
            ScanSocketThread.Start();
        }
        #endregion

        #region 数据获取
        public static void ScanRecMsg()
        {
            try
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
                        length = ScanSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConn = true;
                    }
                    catch
                    {
                        //  SysBusinessFunction.WriteLog("产品码扫码器心跳信息号失败.");
                        ScanConn = false;
                        continue;
                    }

                    if ((strMsg.Trim().Length > 0) && (ScanConn) && strMsg.Trim() != "NO READ")
                    {
                        string code = strMsg.Trim();//获取条码
                        OptionSetting.DetailCode = code;
                        BarCodeDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.Msg = "读取产品码失败！";
                        //OptionSetting.ScanFlag = false;
                        SysBusinessFunction.WriteLog(string.Format("读取产品码失败！"));
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("产品码异常", ex.ToString()));
            }
        }


        #endregion

        #region 重连
        private static void CheckConnectionStatus(object o)
        {
            try
            {
                Thread.Sleep(5);
                SerialPortStatus = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCount = ReceiveCount;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!ScanConn)
                {
                    try
                    {
                        if (ScanReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPoint.ToString()));
                        }
                        ScanReConnCount++;
                        ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocket.Blocking = true;
                        ScanSocket.Connect(ScanPoint);
                        ScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCount, ScanPoint.ToString()));
                        ScanReConnCount = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = ScanSocket.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConn = sLen == 1;
                }
                catch
                {
                    ScanConn = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #region 数据操作

        private static void BarCodeDataHandle(string code)
        {
            try
            {
                SysBusinessFunction.WriteLog(string.Format("【{0}】", code));
                if (code.Length > 4)
                {
                    DataSet ds = new DataSet();
                    string sDetailCode = code.Substring(0, 4).Trim();//可扩展 条码前五位是物料编码
                    string SqlStr = string.Format(@"SELECT
	                                                    b.Check_Item_Code,
	                                                    b.Check_Item_Name,
	                                                    a.Check_Item_Detail_Name,
	                                                    a.Check_Item_Detail_Name_EN
                                                    FROM
	                                                    IMOS_PR_QualityItem_Detail a
                                                    LEFT JOIN
                                                       IMOS_PR_QualityItem_Master b
                                                    on  
                                                      a.Check_Item_Code = b.Check_Item_Code
                                                    WHERE
	                                                    a.Check_Item_Code = '{0}'
                                                    AND a.Check_Item_Detail_Code = '{1}'
                               ", OptionSetting.itemcode, sDetailCode);
                    ds = DataHelper.Fill(SqlStr);
                    if (ds != null && ds.Tables[0].Rows.Count == 1)
                    {
               
                        #region 定时刷新数据
                        CheckDetailData cdd = new CheckDetailData();
                        cdd.Item_Code = ds.Tables[0].Rows[0]["Check_Item_Code"].ToString();
                        cdd.Detail_Code = sDetailCode;
                        cdd.Item_Name = ds.Tables[0].Rows[0]["Check_Item_Name"].ToString();
                        cdd.Detail_Name_CN = ds.Tables[0].Rows[0]["Check_Item_Detail_Name"].ToString();
                        cdd.Detail_Name_EN = ds.Tables[0].Rows[0]["Check_Item_Detail_Name_EN"].ToString();
                        bool flag = false;
                        foreach(CheckDetailData ncdd in OptionSetting.CheckDetailList)
                        {
                            if (ncdd.Equals(cdd))
                            {
                                OptionSetting.CheckDetailList.Remove(cdd);
                                OptionSetting.ReDeFlag = true;
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            OptionSetting.CheckDetailList.Add(cdd);
                            OptionSetting.ReDeFlag = true;
                        }
                        #endregion
                    }
                    else
                    {
                        OptionSetting.Msg = "未获取产品信息";
                        SysBusinessFunction.WriteLog(string.Format("未获取产品信息"));
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion
    }
}
