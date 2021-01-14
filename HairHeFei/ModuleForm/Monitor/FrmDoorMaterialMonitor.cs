using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using ControlLogic.Control;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using System.IO.Ports;
using ControlLogic;

namespace Monitor
{
    public partial class FrmDoorMaterialMonitor : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private int MaterialCount = 0;
        private String OldMaterialCode = "";

        //以太网RFID扫码
        private static Socket RFIDSocket; //RFID扫码
        private static IPEndPoint RFIDPoint;//IP及端口信息
        private static bool RFIDConn = false;
        private static Thread RFIDInSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer RFIDReConnectDeviceTimer; //重新连接socket
        private static int RFIDReConnCount = 0;

        // 扫码器扫码（手持）
        private static Socket ScanSocket; //扫码枪
        private static IPEndPoint ScanPoint;//IP及端口信息
        private static bool ScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private static int BarReConnCount = 0;

        //串口扫码
        #region 串口扫码器变量
        private ScanProvider _scanner;
        private ScanProvider CheckScanner;
        #endregion

        public  System.Threading.Timer GetFXPLCTimer; //获取放行信息
        public FrmDoorMaterialMonitor()
        {
            InitializeComponent();
            dgv_Task.TopLeftHeaderCell.Value = "序号";
        }

        #region 界面初始化
        private void FrmDoorMaterialMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                chx_BD.Checked = true;
                InitControlData();//数据初始化
                ControlMaster.SystemInitialization();
                //连接数据库
                if (!SysBusinessFunction.DBConn) //数据库连接失败时不再进行数据查询
                {
                    return;
                }
                //入库
                ControlInStore.SystemInitialization();
                //ControlOutStore.SystemInitialization();
                //连接扫码器
                InitScanProviderDetail();
                //CreateBarScanSocket();//初始化以太网Socket
                //ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite);
                CreateRFIDSocket();//初始化RFIDSocket
                RFIDReConnectDeviceTimer = new System.Threading.Timer(ReRFIDDevice, null, 0, Timeout.Infinite);
                GetFXPLCTimer = new System.Threading.Timer(GetFXPLCDevice, null, 0, Timeout.Infinite);
                //定时器加载
                timer1.Enabled = true;
                timer1.Interval = 300;
                timer1.Start();

                //界面加载
                String[] strMaterial = BaseSystemInfo.selectMaterialStr.Split(',');
                OptionSetting.SelectMaterialList.Clear();
                MaterialCount = strMaterial.Length;
                for (int j = 0; j < MaterialCount; j++)
                {
                    AddForm(j, strMaterial[j], "");
                    OptionSetting.SelectMaterialList.Add(strMaterial[j]);
                }

            }
            catch (Exception ex)
            {

            }
        }


        #endregion


        #region 界面数据初始化
        private void InitControlData()
        {

            lbl_BasketCode.Text = "";
            lbl_MaterialCode.Text = "";
            lbl_MaterialName.Text = "";
            lbl_Msg.Text = "";
            lbl_ScanTime.Text = "";
            txt_Qty.Text = "1";
            OptionSetting.BasketCode = "";
            OptionSetting.MaterialBarCode = "";
            OptionSetting.MaterialCode = "";
            OptionSetting.MaterialName = "";
            OptionSetting.ScanTime = "";
            OptionSetting.MsgInfo = "";
            OptionSetting.MsgColorRed = false;
        }


        #endregion



        #region 网格添加
        private void AddForm(int i, string material_code, string material_name)
        {
            FrmMaterialGridding fg = new FrmMaterialGridding();
            fg.MaterialCode = material_code;
            fg.MaterialName = material_name;
            fg.TopLevel = false;
            fg.Parent = panel4;
            fg.Name = "MC" + i;
            fg.Top = (i / 2) * 190;
            switch (i % 2)
            {
                case 0:
                    fg.Left = 100;
                    break;
                case 1:
                    fg.Left = 650;
                    break;

            }
            fg.Show();
            /*            #region 横着排放
                        switch ((i - 1) / 5)
                        {
                            case 0:
                                fg.Parent = this.panel6;
                                break;
                            case 1:
                                fg.Parent = this.panel7;
                                break;
                            case 2:
                                fg.Parent = this.panel8;
                                break;
                            case 3:
                                fg.Parent = this.panel9;
                                break;
                            case 4:
                                fg.Parent = this.panel10;
                                break;
                        }
                        #endregion*/
        }
        #endregion

        #region 系统事件 刷新界面
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //界面改变
                if (OldMaterialCode == OptionSetting.MaterialCode)
                {

                }
                else
                {
                    lbl_MaterialCode.Text = OptionSetting.MaterialBarCode;
                    lbl_MaterialName.Text = OptionSetting.MaterialName;
                    lbl_ScanTime.Text = OptionSetting.ScanTime;
                    if (OptionSetting.UseMsg)
                    {
                        lbl_Msg.Text = OptionSetting.MsgInfo;
                        if (OptionSetting.MsgColorRed)
                        {
                            lbl_Msg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbl_Msg.ForeColor = Color.Lime;
                        }

                    }

                }
                lbl_BasketCode.Text = OptionSetting.BasketCode;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region 吊笼条码绑定物料条码
        private void btn_OK_Click(object sender, EventArgs e)
        {
            BindingMaterial();
        }
        #endregion

      
        #region 检验数量是否数字
        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        #endregion

        #region 物料选择按钮
        private void btn_select_material_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSelectMaterial fsm = new FrmSelectMaterial();
                DialogResult r = fsm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //清除列表
                    for (int i = 0; i < MaterialCount; i++)
                    {
                        FrmMaterialGridding p = Controls.Find("MC" + i.ToString(), true)[0] as FrmMaterialGridding;
                        p.Dispose();
                    }
                    MaterialCount = OptionSetting.SelectMaterialList.Count;
                    for (int j = 0; j < MaterialCount; j++)
                    {
                        AddForm(j, OptionSetting.SelectMaterialList[j], "");
                    }
                }
                fsm.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion


        #region 以太网扫码器创建
        private void CreateBarScanSocket()//创建Socket扫码器
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

        #endregion

        #region 以太网扫码器获取数据
        private void BarScanInRecMsg()
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

        #endregion

        #region 以太网扫码器数据处理
        private void HandleScanBarData(string BarCode)//产品条码
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    string g_s_Data = BarCode.Trim();
                    OptionSetting.MaterialBarCode = BarCode.Trim();
                    if (g_s_Data.ToUpper() == "NO READ")
                    {
                        SysBusinessFunction.WriteLog("条码读取失败NOREAD");
                        lbl_Msg.Text = "NOREAD";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }
                    if (g_s_Data.Length != 9)//
                    {
                        SysBusinessFunction.WriteLog("条码格式不对");
                        lbl_Msg.Text = "条码格式不对";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }
                    string Sql = string.Format(@"SELECT Material_Code,Material_Name FROM IMOS_TA_Material where Material_Code = '{0}'", g_s_Data.Substring(0, 9));
                    DataSet ds = DataHelper.Fill(Sql);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_Msg.Text = "扫码器扫描条码【" + BarCode + "】成功";
                        lbl_Msg.ForeColor = Color.Lime;
                        OptionSetting.MaterialCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        OptionSetting.MaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();

                    }
                    else
                    {
                        lbl_Msg.Text = "查询条码【" + BarCode + "】物料失败";
                        lbl_Msg.ForeColor = Color.Red;
                        OptionSetting.MaterialCode = "";
                        OptionSetting.MaterialName = "";
                        return;
                    }

                    //判断库存是否已满
                    String chsql = String.Format(@"SELECT
	                                                    A.Store_Code,
	                                                    COUNT (1) SumNUM
                                                    FROM
	                                                    IMOS_Lo_Bin A
                                                    LEFT JOIN IMOS_Lo_Bin_Detial B ON A.Store_Code = B.Store_Code
                                                    AND A.Material_Code = B.Material_Code
                                                    WHERE
	                                                    B.Material_Code = '{0}'
                                                    GROUP BY
	                                                    A.Store_Code", BarCode.Substring(0,9));

                    DataSet chds = DataHelper.Fill(chsql);
                  
                    if(chds != null)
                    {
                        for(int i = 0; i < chds.Tables[0].Rows.Count; i++)
                        {
                            if(int.Parse(chds.Tables[0].Rows[0]["SumNUM"].ToString())  >= 7)
                            {
                                lbl_Msg.Text = "库存已满，请等待或者重新分配货道！";
                                lbl_Msg.ForeColor = Color.Red;
                                return;
                            }
                        }

                    }

                    OptionSetting.ScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    lbl_MaterialCode.Text = OptionSetting.MaterialBarCode;
                    lbl_MaterialName.Text = OptionSetting.MaterialName;
                    lbl_ScanTime.Text = OptionSetting.ScanTime;
                    if (chx_BD.Checked)//自动绑定
                    {
                        BindingMaterial();
                    }
                    else
                    {
                        //手动绑定（点击按钮）
                    }

                }
                catch (Exception ex)
                {
                }
            }));
        }
        #endregion

        #region 以太网扫码器重连
        public void ReConnectDevice(object o)//socket重连接
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
                            SysBusinessFunction.WriteLog(string.Format("绑定条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocket.Connect(ScanPoint);
                        ScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("绑定条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, ScanPoint.ToString()));
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


        #region  绑定物料
        private void BindingMaterial()
        {
            try
            {
                Application.DoEvents();
                int result = 0;
                string BasketCode = OptionSetting.BasketCode;
                string BarCode = OptionSetting.MaterialBarCode;
                string MaterialCode = OptionSetting.MaterialCode;
                string MaterialName = OptionSetting.MaterialName;
                string ScanTime = OptionSetting.ScanTime;
                string Qty = txt_Qty.Text.ToString().Trim();

                int QtyInt = 0;
                if (string.IsNullOrEmpty(lbl_BasketCode.Text.ToString()))
                {
                    lbl_Msg.Text = "请扫工装板条码";
                    lbl_Msg.ForeColor = Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(lbl_MaterialCode.Text.ToString()) || string.IsNullOrEmpty(lbl_MaterialName.Text.ToString()))
                {
                    lbl_Msg.Text = "产品型号为空";
                    lbl_Msg.ForeColor = Color.Red;
                    return;
                }
                if (MaterialCode.ToString().Length != 6 || MaterialCode.Substring(0, 1) != "R")
                {
                    lbl_Msg.Text = "条码信息为空";
                    lbl_Msg.ForeColor = Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(lbl_ScanTime.Text.ToString()))
                {
                    lbl_Msg.Text = "扫描时间为空";
                    lbl_Msg.ForeColor = Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txt_Qty.Text.ToString()))
                {

                    lbl_Msg.Text = "请输入产品数量";
                    lbl_Msg.ForeColor = Color.Red;
                    txt_Qty.Focus();
                    return;
                }
                if (!IsInt(txt_Qty.Text.ToString()))
                {
                    lbl_Msg.Text = "请输入正确的产品数量数字";
                    lbl_Msg.ForeColor = Color.Red;
                    txt_Qty.Focus();
                    return;
                }
                QtyInt = int.Parse(Qty);
                // 创建个存储过程 ，实现更新数据和插入任务
                //验证RFID是否存在绑定信息表中
                string sql = String.Format(@"Select  RFID_Code From IMOS_Lo_Pallet 
                                       Where Company_Code = '{0}' And Factory_Code = '{1}' 
                                       And Product_Line_Code = '{2}' And
                                       RFID_Code = '{3}'",
                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,
                                      BasketCode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.WriteLog("绑定信息表中存在该工装板RFID【" + BasketCode + "】的绑定信息");
                    DialogResult r = SysBusinessFunction.SystemDialog(1, "绑定信息表中存在该工装板RFID【" + BasketCode + "】的绑定信息，是否重新绑定？");
                    if (r == DialogResult.OK)
                    {

                        bool rflag = UpdateForm(true);
                        if (rflag)
                        {
                            lbl_Msg.Text = "绑定信息成功！";
                            lbl_Msg.ForeColor = Color.Lime;
                            result = 1;
                            SysBusinessFunction.WriteLog("绑定信息成功！工装板RFID【"+BasketCode+"产品信息【"+ BarCode + "】");
                        }
                        else
                        {
                            lbl_Msg.Text = "绑定信息失败！！";
                            lbl_Msg.ForeColor = Color.Red;
                            SysBusinessFunction.WriteLog("绑定信息失败！！");
                        }
                    }
                    else
                    {
                        lbl_Msg.Text = "绑定信息表中存在该工装板RFID【" + BasketCode + "】的绑定信息,重新绑定！";
                        lbl_Msg.ForeColor = Color.Red;
                        SysBusinessFunction.WriteLog("绑定信息表中存在该工装板RFID【" + BasketCode + "】的绑定信息,重新绑定！");
                        return;
                    }
                }
                else
                {
                    bool rflag = UpdateForm(false);
                    if (rflag)
                    {
                        lbl_Msg.Text = "绑定信息成功！";
                        lbl_Msg.ForeColor = Color.Lime;
                        result = 1;
                        SysBusinessFunction.WriteLog("绑定信息成功！工装板RFID【" + BasketCode + "】产品信息【" + BarCode + "】");
                    }
                    else
                    {
                        //lbl_Msg.Text = "绑定信息失败！！";
                        // lbl_Msg.ForeColor = Color.Red;
                        SysBusinessFunction.WriteLog("绑定信息失败！！");
                    }
                }
                DownPLC(result);
                updTaskInterface();//刷新界面
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("绑定信息异常！");
                lbl_Msg.Text = String.Format(@"绑定过程出现异常，请重新扫码绑定");
                lbl_Msg.ForeColor = Color.Red;
                //

            }
        }


        #endregion

        #region 下传PLC
        private void DownPLC(int result)
        {
            try
            {
                //直接下传PLC放行
                int Address = 0;
                int Block = 0;
                object[] WBuf = new object[5];
                WBuf[0] = OptionSetting.BasketCode;
                WBuf[1] = 0;
                WBuf[2] = 1;
                WBuf[3] = result;
                WBuf[4] = 0;
                SysBusinessFunction.WriteLog("下传的信号是【" + result + "】");
                bool resultflag = ControlMaster.WriteData(Block, Address, WBuf);
                if (!resultflag)
                {
                    lbl_Msg.Text = "PLC连接失败！！";
                    lbl_Msg.ForeColor = Color.Red;
                    SysBusinessFunction.WriteLog("PLC连接失败！！");
                    return;
                }
                int DownCount = GetTickCount();
                while (true)
                {
                    Thread.Sleep(5);
                    // Application.DoEvents();
                    //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                    if (GetTickCount() - DownCount > 5000) //超时处理
                    {
                        SysBusinessFunction.WriteLog("下传信号成功，等待反馈信号超时");
                        break;
                    }
                    object[] RBuf = new object[1];
                    ControlMaster.ReadData(0, Address + 3, 1, out RBuf);
                    if (RBuf[0].ToString() == "2")
                    {
                        SysBusinessFunction.WriteLog("下传信号成功，接受反馈信号成功");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region  更新数据库
        private bool UpdateForm(bool typeflag)
        {
            try
            {
                string selectsql = String.Format(@"Select Store_Code,Store_Name From IMOS_Lo_Bin where Material_Code = '{0}' and Area_Code = '{1}'", OptionSetting.MaterialCode, BaseSystemInfo.AreaCode);
                DataSet selectds = DataHelper.Fill(selectsql);
                if (selectds != null && selectds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    SysBusinessFunction.WriteLog("该型号没有分配的货道！！");
                    lbl_Msg.Text = "该型号没有分配的货道！！";
                    lbl_Msg.ForeColor = Color.Red;
                    return false;
                }
                String TaskID = Guid.NewGuid().ToString();
                // 创建个存储过程 ，实现更新数据和插入任务
                SqlParameter[] values = {
                                            new SqlParameter("@Task_ID", TaskID),
                                            new SqlParameter("@Company_Code", BaseSystemInfo.CompanyCode),
                                            new SqlParameter("@Company_Name", BaseSystemInfo.CompanyName),
                                            new SqlParameter("@Factory_Code", BaseSystemInfo.FactoryCode),
                                            new SqlParameter("@Factory_Name", BaseSystemInfo.FactoryName),
                                            new SqlParameter("@Product_Line_Code", BaseSystemInfo.ProductLineCode),
                                            new SqlParameter("@Product_Line_Name", BaseSystemInfo.ProductLineName),
                                            new SqlParameter("@Area_Code", BaseSystemInfo.AreaCode),
                                            new SqlParameter("@Area_Name", BaseSystemInfo.AreaCode),
                                            new SqlParameter("@Store_Code", selectds.Tables[0].Rows[0]["Store_Code"]),
                                            new SqlParameter("@Store_Name ",  selectds.Tables[0].Rows[0]["Store_Name"]),
                                            new SqlParameter("@Material_Code", OptionSetting.MaterialCode),
                                            new SqlParameter("@Material_Name", OptionSetting.MaterialName),
                                            new SqlParameter("@Bar_Code",OptionSetting.MaterialBarCode),
                                            new SqlParameter("@Task_State","0"),
                                            new SqlParameter("@Task_Type", "1"),
                                            new SqlParameter("@RFID_Code", OptionSetting.BasketCode),
                                            new SqlParameter("@Qty", int.Parse(txt_Qty.Text.ToString())),
                                            new SqlParameter("@Scan_Time", OptionSetting.ScanTime),
                                            new SqlParameter("@Process_Code", BaseSystemInfo.CurrentProcessCode),
                                            new SqlParameter("@Process_Name", BaseSystemInfo.CurrentProcessName)
                                      };
               
                if (typeflag)
                {
                    DataHelper.ExecuteProcedure("del_Pallet_Task", new String[] { "List" }, values);
                    DataHelper.ExecuteProcedure("in_Pallet_Task", new String[] { "List" }, values);
                }
                else
                {
                    DataHelper.ExecuteProcedure("in_Pallet_Task", new String[] { "List" }, values);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region 根据绑定信息决定绑定按钮是否可用
        private void chx_BD_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_BD.Checked)
            {
                btn_OK.Enabled = false;
            }
            else
            {
                btn_OK.Enabled = true;
            }
        }
        #endregion

        #region RFID 扫码器创建

        private void CreateRFIDSocket()//创建RFID扫码器                  
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.RFIDIP);//IP地址
            RFIDPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.RFIDPort));//端口号
            RFIDSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            RFIDSocket.Blocking = true;
            try
            {
                RFIDSocket.Connect(RFIDPoint);
                RFIDSocket.Blocking = false;
                RFIDConn = true;
            }
            catch (SocketException ex)
            {
                RFIDConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.RFIDPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            RFIDInSocketThread = new Thread(RFIDInRecMsg);
            RFIDInSocketThread.IsBackground = true;
            RFIDInSocketThread.Start();
            #endregion
        }

        #endregion

        #region RFID扫码器获取数据
        private void RFIDInRecMsg()
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
                    length = RFIDSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    RFIDConn = true;
                }
                catch
                {
                    RFIDConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (RFIDConn))
                {
                    HandleRFIDData(strMsg.Trim());
                }
            }
        }

        #endregion

        #region RFID扫码器数据处理
        private void HandleRFIDData(string BarCode)//产品条码
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    InitControlData();
                    string RFIDCode = BarCode.Trim();
                    if (RFIDCode.ToUpper() == "NO READ")
                    {
                        SysBusinessFunction.WriteLog("RFID读取失败NOREAD");
                        lbl_Msg.Text = "RFID读取失败NOREAD";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }
                    if (RFIDCode.Length != 5)
                    {
                        SysBusinessFunction.WriteLog("RFID条码格式不对");
                        lbl_Msg.Text = "RFID条码格式不对";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }
                    OptionSetting.BasketCode = RFIDCode;
                    lbl_BasketCode.Text = RFIDCode;
                }
                catch (Exception ex)
                {
                }
            }));
        }
        #endregion

        #region 以太网扫码器重连
        public void ReRFIDDevice(object o)//RFID重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!RFIDConn)
                {
                    try
                    {
                        if (RFIDReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("绑定RFID扫描设备断线重连中......，{0}", RFIDReConnCount.ToString()));
                        }
                        RFIDReConnCount++;
                        RFIDSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        RFIDSocket.Connect(RFIDPoint);
                        RFIDConn = true;
                        SysBusinessFunction.WriteLog(string.Format("绑定RFID扫描设备重新连接成功，重连次数{0}，{1}", RFIDReConnCount, RFIDPoint.ToString()));
                        RFIDReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = RFIDSocket.Send(arrMsgRec);
                    RFIDConn = sLen == 1;
                }
                catch
                {
                    RFIDConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                RFIDReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion


        #region 串口扫码器属性设置
        public void InitScanProviderDetail()
        {
            try
            {
                // 打开串口  
                _scanner = new ScanProvider(BaseSystemInfo.SerialPortName1,9600);
                Task task = new Task(() =>
                {
                    // 打开串口  
                    if (_scanner.Open())
                        //关联事件处理程序  
                        _scanner.DataReceived += _scanner_DataReceived;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("工位{0}称重串口连接出现异常.端口【{1}】波特率【{2}】，",BaseSystemInfo.CurrentProcessName,BaseSystemInfo.SerialPortName1,9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
        }
        #endregion




        #region 串口扫码器数据获取
        private void _scanner_DataReceived(object sender, SerialSortEventArgs e)
        {
            BeginInvoke(new Action<string>(args =>
            {
                try
                {
                    HandleScanBarData(args.Trim());
                }
                catch (Exception ex)
                {

                }


            }), e.Code);

        }
        #endregion

        #region 任务排序
        private void dgv_Task_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try{
               for(int i = 0; i < dgv_Task.Rows.Count; i++)
                {
                    dgv_Task.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_Task.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }
                dgv_Task.ClearSelection();
             
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region  更新任务界面
        private void updTaskInterface()
        {
            try
            {
                string sql = String.Format(@"SELECT
	                                             RFID_BarCode,
	                                             Material_Code,
	                                             Material_Name,
	                                             Bar_Code,
                                                 CONVERT(VARCHAR(50),Create_Time,120)Create_Time
                                            FROM
	                                            IMOS_Lo_Task
                                            WHERE
	                                            Task_Type = '{0}'
                                            AND Task_State = '{1}'
                                            ORDER BY
	                                            Create_Time Desc", "1","0");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    dgv_Task.DataSource = ds.Tables[0];
                }
               

            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region 按钮事件
        private void btn_ReTask_Click(object sender, EventArgs e)
        {
            updTaskInterface();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTaskMonitor ftm = new FrmTaskMonitor();
                ftm.Show();

            }catch(Exception ex)
            {

            }
        }

        #endregion

        #region 获取放行信号

        private  void GetFXPLCDevice(object state)
        {
            try
            {
                Thread.Sleep(10);
                int address = 600;
                int block = 0;
                int len = 1;
                object[] Rbuf = new object[len];
                bool result = ControlMaster.ReadData(block, address, len, out Rbuf);
                if (result)
                {
                    if ("1".Equals(Rbuf[0].ToString()))
                    {
                        //接受到报警信息
                        SysBusinessFunction.WriteLog("接受到报警信息，工装板【"+ OptionSetting.BasketCode + "】未绑定放行");
                        BeginInvoke(new Action(() =>
                        {
                            lbl_Msg.Text = "工装板【" + OptionSetting.BasketCode + "】未绑定放行";
                            lbl_Msg.ForeColor = Color.Red;
                        }));

                        object[] Wbuf = new object[len];
                        Wbuf[0] = 0;
                        ControlMaster.WriteData(block, address, Wbuf);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetFXPLCTimer.Change(2000, Timeout.Infinite);
            }

        }
        #endregion
    }
}
