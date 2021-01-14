using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;

namespace ControlLogic.Control
{
    public class ControlDoorMaterial
    {
        #region 串口扫码器变量
        //条码
        public static SerialPort BarScanPort;
        public static bool BarScanConn = false; //条码扫描设备连接状态
        private static int HisReceiveCount = 0;
        private static int ReceiveCount = 0;
        private static int BarScanReConnCount = 0;
        public static System.Threading.Timer CheckConnectionTimer;  //检查设备连接状态Timer
        #endregion

        #region 初始化
        public static void SystemInitialization()//初始化
        {
            InitBarScanPortProperty();//初始化串口扫码器
            CheckConnectionTimer = new System.Threading.Timer(CheckConnectionStatus, null, 0, Timeout.Infinite);//条码扫描设备重连           
        }
        #endregion

        #region 串口扫码器属性设置
        private static void InitBarScanPortProperty()//设置串口的属性
        {
            try
            {
                BarScanPort = new SerialPort();
                //AGVPort.PortName = BaseSystemInfo.SerialPortName;//设置串口名 默认COM1 
                BarScanPort.PortName = BaseSystemInfo.SerialPortName1;
                BarScanPort.BaudRate = 9600;//设置串口的波特率
                BarScanPort.StopBits = StopBits.One;
                BarScanPort.DataBits = 8;//设置数据位
                BarScanPort.Parity = Parity.None;
                BarScanPort.ReadTimeout = -1;//设置超时读取时间
                //sp.RtsEnable=true; //定义DataReceived事件，当串口收到数据后触发事件
                BarScanPort.ReceivedBytesThreshold = 1;
                BarScanPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                BarScanPort.Open();
                BarScanConn = true;
            }
            catch
            {
                BarScanConn = false;
            }
        }

        #endregion

        #region  串口扫码设备重连
        private static void CheckConnectionStatus(object o)//PLC和条码扫描设备重连
        {
            try
            {
                Thread.Sleep(5);
                HisReceiveCount = ReceiveCount;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!BarScanConn)
                {
                    try
                    {
                        if (BarScanReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", BarScanPort.ToString()));
                        }
                        BarScanReConnCount++;
                        BarScanPort.Open();
                        BarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", BarScanReConnCount));
                        BarScanReConnCount = 0;
                    }
                    catch (Exception ex)
                    {

                    }
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

        #region 串口扫码器数据获取
        private static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string g_s_Data = "";
            try
            {
                do
                {
                    g_s_Data = BarScanPort.ReadExisting().Trim();
                }
                while (BarScanPort.BytesToRead > 0);

                if(g_s_Data.Length > 0)
                {
                    if (g_s_Data.Length == 6 && g_s_Data.Substring(0, 1).ToString() == "R")
                    {
                        OptionSetting.MaterialCode = g_s_Data;
                        OptionSetting.ScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        OptionSetting.MsgInfo = "扫描物料条码为" + g_s_Data;
                        OptionSetting.MsgColorRed = false;
                        string sql = String.Format(@"Select Material_Name From IMOS_TA_Material 
                                             Where Company_Code = '{0}' And Factory_Code = '{1}'
                                             And Product_Line_Code = '{2}' And Material_Code = '{3}'",
                                             BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,g_s_Data);
                        DataSet ds = DataHelper.Fill(sql);
                        OptionSetting.MaterialName = "";
                        if(ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            OptionSetting.MaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        }
                    }
                    else
                    {
                        OptionSetting.BasketCode = g_s_Data;
//                        OptionSetting.MaterialCode = "";
//                        OptionSetting.MaterialName = "";
                        OptionSetting.MsgInfo = "扫描吊笼条码为" + g_s_Data;
                        OptionSetting.MsgColorRed = false;
                    }

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("error:接收返回消息异常！具体原因：" + ex.Message);
            }
        }
        #endregion
    }
}
