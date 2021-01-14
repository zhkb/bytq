using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLogic.Control
{
    public class ControlEnEr
    {
        private static string str = String.Format(@" Company_Code = '{0}' AND Factory_Code = '{1}'  AND Product_Line_Code ='{2}' ",
                      BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
        public static System.Threading.Timer AddRecordTimer;  //增加记录状

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        #region 以太网扫码器变量
        private static Socket ScanSocket; //扫码枪
        private static IPEndPoint ScanPoint;//IP及端口信息
        private static bool ScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private static int BarReConnCount = 0;
        private static int NActual_Qty = -1;
        #endregion

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

            if ("2".Equals(BaseSystemInfo.UseDiscernFlag))
            {
                CreateBarScanSocket();//初始化以太网Socket
                ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 包含PLC 条码
            }
            //AddRecordTimer = new System.Threading.Timer(AddRecord, null, 0, 100);
        }

        private static void CheckDoorStatus()
        {
            try
            {
                Thread.Sleep(500);
                int address = 166;
                object[] FRBuff = new object[1]; //网格开启标志1开启 0 关闭
                ControlMaster.ReadData(0, address, 1, out FRBuff);
                String ss = Convert.ToString((int)FRBuff[0], 2).PadLeft(16, '0');
                ArrayList list = new ArrayList();
                for (int i=0;i<ss.Length;i++)
                {
                    if (ss[i] == '1')
                    {
                        list.Add(16-i);
                    }
                }
                if (list.Count == 0)//没打开网格门
                {
                    SysBusinessFunction.WriteLog("网格门没有打开！！");
                }
                else
                {
                    if (list.Count > 1)
                    {
                        SysBusinessFunction.WriteLog("打开多个网格门!!");
                        SysBusinessFunction.SystemDialog(1, "警告:打开多个网格门!\n\rWarning: open multiple mesh doors");
                    } else
                    {
                        if (OptionSetting.BNum == list[0].ToString())
                        {
                            SysBusinessFunction.WriteLog("网格门打开正确!!");
                            UpdNum(OptionSetting.BNum,"1");//数据减1
                        }else
                        {
                            SysBusinessFunction.WriteLog("网格门打开错误!!");
                            SysBusinessFunction.SystemDialog(1, "警告:网格门错误!\n\r Warning: mesh door opening error");
                        }
                    }
                }
                //清空
                object[] WBuff = new object[1]; //网格开启标志1开启 0 关闭
                WBuff[0] = 0;
                ControlMaster.WriteData(0,address, WBuff);


            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region 以太网扫码器

        #region 以太网扫码器创建
        private static void CreateBarScanSocket()//创建Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIP);//IP地址
            ScanPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPort));//端口号
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
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            InSocketThread = new Thread(QualitySocketRecMsg);
            InSocketThread.IsBackground = true;
            InSocketThread.Start();
            #endregion
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

        #region 获取以太网扫码器数据
        private static void QualitySocketRecMsg()//通过Socket获取数据
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
                    length = ScanSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    ScanConn = true;

                }
                catch (Exception ex)
                {
                    ScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (ScanConn))
                {
                    if (!OptionSetting.PutFlag)//当放料时 不能贴能效贴码
                    {
                        HandleQualityBarCode(strMsg.Trim());
                    }
                }
            }
        }
        #endregion

        #endregion

        #region 串口扫码器

        #region 串口扫码器属性设置
        private static void InitBarScanPortProperty()//设置串口的属性
        {
            try
            {
                BarScanPort = new SerialPort();
                //AGVPort.PortName = BaseSystemInfo.SerialPortName;//设置串口名 默认COM1 
                BarScanPort.PortName = BaseSystemInfo.PortName;
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
                    catch (SocketException ex)
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
                    g_s_Data = BarScanPort.ReadExisting();
                }
                while (BarScanPort.BytesToRead > 0);
                if (g_s_Data.Length > 0)
                {
                    //能否识别冰箱型号标志 
                    if ("1".Equals(BaseSystemInfo.UseDiscernFlag))
                    {
                        if (!OptionSetting.PutFlag)
                        {
                            HandleQualityBarCode(g_s_Data);
                        }
                        else
                        {
                            GetAddEnergy(g_s_Data);
                        }

                    }
                    else
                    {
                        if (OptionSetting.PutFlag)
                        {
                            GetAddEnergy(g_s_Data);
                        }
                    }
                }
                else
                {

                    SysBusinessFunction.WriteLog(string.Format("读取条码信息失败，请重新读取！"));
                    SysBusinessFunction.SystemDialog(2, "读取条码信息失败，请重新读取！Read BarCode Fail,please scan again");

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("error:接收返回消息异常！具体原因：" + ex.Message);
            }
        }
        #endregion

        #endregion

        #region 扫码数据处理
        private static void HandleQualityBarCode(string strMsg)//Socket 执行步骤
        {
            try
            {
                OptionSetting.ShowFlag = true;
                OptionSetting.EProBarCode = strMsg.Trim();
                OptionSetting.BNum = "0";
                OptionSetting.EMsg = "";
                OptionSetting.EProCode = "";
                OptionSetting.EProName = "";

                SysBusinessFunction.WriteLog("能耗贴防差错工位扫码记录：" + OptionSetting.EProBarCode);

                if (OptionSetting.EProBarCode.ToUpper() == "NOREAD")
                {
                    OptionSetting.EProCode = "";
                    OptionSetting.EProName = "";
                    OptionSetting.EMsg = String.Format(@"条码扫描失败
Bar Code Scan Failed");
                    OptionSetting.EResultFlag = false;

                }
                else if (OptionSetting.EProBarCode.Trim().Length != 20)
                {
                    OptionSetting.EProCode = "";
                    OptionSetting.EProName = "";
                    OptionSetting.EMsg = String.Format(@"扫描条码格式错误
Bar Code Format Error");
                    OptionSetting.EResultFlag = false;

                }
                else
                {
                    #region 验证数据真实性
                    //从物料表中获取产品信息
                    String sql = String.Format(@"SELECT  
                                            Material_Code,Material_Name,Material_Image
                                            FROM 
                                                  IMOS_TA_Material
                                            WHERE 
                                                 Material_Code = '{0}'", OptionSetting.EProBarCode.ToString().Trim().Substring(0, 11));
                    sql = sql + " AND " + str;
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds == null || ds.Tables[0].Rows.Count == 0)
                    {
                        OptionSetting.EProCode = "";
                        OptionSetting.EProName = "";
                        OptionSetting.EMsg = String.Format(@"没有找到产品数据
No Product Data Not Found");
                        OptionSetting.EResultFlag = false;
                        return;
                        
                    }

                    //从网格信息列表中获取网格信息
                    string sql2 = String.Format(@"SELECT
                	                                  b.Bin_No,
                                                      b.Energy_Label_Code,
                                                      b.Energy_Label_Name,
                	                                  b.Material_Actual_Qty,
                	                                  b.Energy_Label_Image
                                              FROM
                	                                  IMOS_TA_Map a
                                              LEFT JOIN IMOS_TA_Energy_List b ON a.Material_Code = b.Energy_Label_Code
                                              WHERE
                	                               a.Product_Code = '{0}' and a.Material_Type = '{1}'", OptionSetting.EProBarCode.ToString().Trim().Substring(0, 11), "NXT");
                    DataSet ds2 = DataHelper.Fill(sql2);
                    if (ds2 == null || ds2.Tables[0].Rows.Count == 0)
                    {
                        SysBusinessFunction.WriteLog("未查询到网格信息！！");
                        OptionSetting.EMsg = String.Format(@"未查询到网格信息
Grid  Was Not Queried");
                        OptionSetting.EResultFlag = false;
                        return;
                    }

                    OptionSetting.EProCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                    OptionSetting.EProName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                    OptionSetting.EMsg = String.Format(@"扫描条码成功
Bar Code Scanning Successful");
                    OptionSetting.EResultFlag = true;//4表示扫描条码成功
                                                     //图片刷新
                    OptionSetting.ProImage = ds.Tables[0].Rows[0]["Material_Image"].ToString().Trim();
                    OptionSetting.EnergyImage = ds2.Tables[0].Rows[0]["Energy_Label_Image"].ToString().Trim();
                    OptionSetting.BNum = ds2.Tables[0].Rows[0]["Bin_No"].ToString();
                    OptionSetting.EEnergyCode = ds2.Tables[0].Rows[0]["Energy_Label_Code"].ToString();
                    OptionSetting.EEnergyName = ds2.Tables[0].Rows[0]["Energy_Label_Name"].ToString();
                    #endregion
                }
                int EnergyAddress = 160;
                object[] BackWBuff = new object[2];
                InsertRecord();
            
                //获取网格门状态
                int address = 167;
                object[] RBuff = new object[1];
                ControlMaster.ReadData(0, address, 1, out RBuff);

                string rstr = Convert.ToString((int)RBuff[0], 2).PadLeft(16, '0');
                bool DownFlag = false;
                int m = 0;
                //遍历
                for (int i = 0; i < rstr.Length; i++)
                {
                    if ('1' == rstr[i])
                    {
                        m = 16 - i;
                        DownFlag = true;
                    }
                }
                if (DownFlag)
                {
                    SysBusinessFunction.WriteLog(String.Format(@"网格门{0}没有关闭",m));
                    OptionSetting.EMsg = String.Format(@"网格门{0}没有关闭
The mesh door is not closed", m);
                    OptionSetting.EResultFlag = false;
                    return;
                }
                if (OptionSetting.BNum == "0")
                {
                    //可以手动打开网格
                    return;
                }
                BackWBuff[0] = OptionSetting.BNum;//网格门编号
                BackWBuff[1] = 1;//应答字

                bool result = ControlMaster.WriteData(0, EnergyAddress, BackWBuff);
                if (!result)
                {
                    SysBusinessFunction.WriteLog("下传信号异常......");
                    OptionSetting.EMsg = String.Format(@"下传信号异常
Down Signal Abnormal");
                    OptionSetting.EResultFlag = false;//下传信号异常
                    return;
                }
                SysBusinessFunction.WriteLog("编号为【" + OptionSetting.BNum + "】的网格信息下传正常");
                int LinerCount = GetTickCount();
                while (true)
                {
                    Thread.Sleep(10);
                    //Application.DoEvents();
                    //下位机在收到信息后需要将应答字修改为2 当下位机收到信息后将下传的信息清空
                    if (GetTickCount() - LinerCount > 1000) //超时处理1秒
                    {
                        SysBusinessFunction.WriteLog("下传信号成功，等待反馈信号超时");
                        return;
                    }
                    object[] RBuf1 = new object[1];
                    ControlMaster.ReadData(0, EnergyAddress + 1, 1, out RBuf1);
                    if (RBuf1[0].ToString() == "2")
                    {
                        SysBusinessFunction.WriteLog("反馈信号正常");
                        RBuf1[0] = 0;
                        ControlMaster.WriteData(0, EnergyAddress+1, RBuf1);
                        break;
                    }
                }
                CheckDoorStatus();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("处理异常:" + ex.Message + OptionSetting.EProBarCode));
            }

        }

        #endregion

        #region 插入贴码记录
        private static void InsertRecord()
        {
            try
            {
                String sql = String.Format(@"INSERT INTO IMOS_TA_Energy_Record (
	                                                    Company_Code,
	                                                    Company_Name,
	                                                    Factory_Code,
	                                                    Factory_Name,
	                                                    Product_Line_Code,
	                                                    Product_Line_Name,
	                                                    Bin_No,
	                                                    Energy_Label_Code,
	                                                    Energy_Label_Name,
	                                                    Material_BarCode,
	                                                    Material_Code,
	                                                    Material_Name,
                                                        Create_Time,
	                                                    Create_By
                                                    )
                                                    VALUES
	                                                    ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',
                                                         '{8}','{9}','{10}','{11}',GetDate(),'{12}')",
                                                        BaseSystemInfo.CompanyCode,
                                                        BaseSystemInfo.CompanyName,
                                                        BaseSystemInfo.FactoryCode,
                                                        BaseSystemInfo.FactoryName,
                                                        BaseSystemInfo.ProductLineCode,
                                                        BaseSystemInfo.ProductLineName,
                                                        OptionSetting.BNum,
                                                        OptionSetting.EEnergyCode,
                                                        OptionSetting.EEnergyName,
                                                        OptionSetting.EProBarCode,
                                                        OptionSetting.EProCode,
                                                        OptionSetting.EProName,
                                                        BaseSystemInfo.CurrentUserCode
                                                        );
                DataHelper.Fill(sql);
                SysBusinessFunction.WriteLog("插入能耗贴防差错记录成功！！");
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("插入能耗贴防差错记录失败！！" + ex.Message);
            }
        }
        #endregion

        #region 数量修改

        private static bool UpdNum(String s, String num)//修改数量-1
        {
            #region 修改数量
            //实际数量总在不断地变化，所以修改实际数量时要获取当前最新的实际数量来修改
            //重新获取实际数量
            //贴码成功则数量减一贴码失败则数量不变
            try
            {
                int n = int.Parse(num);
                string sql = String.Format(@"SELECT
	                                          Material_Actual_Qty
                                         FROM
	                                          IMOS_TA_Energy_List
                                        WHERE
	                                       Bin_No = {0} AND Company_Code = '{1}' AND Company_Name = '{2}' AND Factory_Code = '{3}' AND Factory_Name='{4}' AND Product_Line_Code ='{5}' AND Product_Line_Name='{6}'", s,
                      BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
                DataSet ds = DataHelper.Fill(sql);
                NActual_Qty = int.Parse(ds.Tables[0].Rows[0]["Material_Actual_Qty"].ToString().Trim());
                if (NActual_Qty >= n)
                {
                    string upsql = String.Format(@"Update IMOS_TA_Energy_List Set  Material_Actual_Qty = {0} where Bin_No = {1}", NActual_Qty - n, s);
                    DataHelper.Fill(upsql);
                    return true;
                }
                SysBusinessFunction.SystemDialog(2, "能耗贴缺失！！！！ Energy Label is empty ");
                return false;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("能耗贴数量修改错误！" + ex.Message);
                return false;
            }

            #endregion

        }

        #endregion

        #region 能耗贴扫描条码信息处理
        private static void GetAddEnergy(string s)
        {
            try
            {
                BarScanConn = true;
                string code = s.Trim();//获取条码
                OptionSetting.Ecode = code.Substring(0, 11);
                //判断条码格式 格式错误 未扫描到条码
                String sql = String.Format(@"SELECT   b.Bin_No,b.Material_Actual_Qty,a.Material_Code,a.Material_Name
                                                 FROM	IMOS_TA_Map a
                                                 LEFT JOIN IMOS_TA_Energy_List b ON a.Material_Code = b.Energy_Label_Code
                                                 where a.Material_Code = '{0}' and a.Material_Type = '{1}'", code.Substring(0, 11), "NXT");
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "没有找到与条码【" + code + "】有关的能效贴！Not found Energy Label for the BarCode");
                    return;
                }

                OptionSetting.Ebinno = ds.Tables[0].Rows[0]["Bin_No"].ToString(); //网格编号
                OptionSetting.Ename = ds.Tables[0].Rows[0]["Material_Name"].ToString(); //物料名称
                OptionSetting.Eqty = ds.Tables[0].Rows[0]["Material_Actual_Qty"].ToString(); //能耗贴实际数量

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("扫描获取添加能效贴信息失败！");
            }
        }

        #endregion

    }
}
