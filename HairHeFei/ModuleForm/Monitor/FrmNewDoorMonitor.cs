using ControlLogic;
using ControlLogic.Control;
using Material;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmNewDoorMonitor : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        //以太网RFID扫码
        private static Socket RFIDSocket; //RFID扫码
        private static IPEndPoint RFIDPoint;//IP及端口信息
        private static bool RFIDConn = false;
        private static Thread RFIDInSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer RFIDReConnectDeviceTimer; //重新连接socket
        private static int RFIDReConnCount = 0;
        public static string oldMaterialCode = "";
        public  System.Threading.Timer GetMTCodeTimer; //获取门体
        public static bool flag = false;
        private ArrayList strlist = new ArrayList();
        //串口扫码
        #region 串口扫码器变量
        private ScanProvider _scanner;
        private ScanProvider CheckScanner;

        public string OldSDRKCode = "";
        #endregion


        public FrmNewDoorMonitor()
        {
            InitializeComponent();
            dgv_Task.TopLeftHeaderCell.Value = "序号";
            dgv_detail.TopLeftHeaderCell.Value = "序号";
        }



        private void FrmNewDoorMonitor_Load(object sender, EventArgs e)
        {

            try
            {
                //删除存储表
                String delsql = String.Format(@"DELETE FROM IMOS_Lo_Scan_Code Where Store_Sort = '{0}'", BaseSystemInfo.CurrentINStoreCode);
                DataHelper.Fill(delsql);
                ControlXPLC.SystemInitialization();
                ControlMaster.SystemInitialization();//PLC
                ControlStoreMonitor.SystemInitialization();//获取库存数据
                FrmBindingControlcs.SystemInitialization();//绑定相关
                ControlInStore.SystemInitialization();//入库
                //连接扫码器
                InitScanProviderDetail();
                CreateRFIDSocket();//初始化RFIDSocket
                RFIDReConnectDeviceTimer = new System.Threading.Timer(ReRFIDDevice, null, 0, Timeout.Infinite);//重连
                GetMTCodeTimer = new System.Threading.Timer(GetMTDevice, null, 0, Timeout.Infinite);//重连
                InitTabControl();
                for (int i = 1; i <= 8; i++)
                {
                    FrmOutStoreDetailMonitor frm = new FrmOutStoreDetailMonitor();
                    frm.TopLevel = false;
                    frm.Parent = panel10;
                    frm.Dock = DockStyle.Bottom;
                    frm.Height = panel10.Height / 9;
                    frm.BinCode = i;
                    frm.Width = panel10.Width;
                    frm.Show();
                }
                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer1.Start();
                timer2.Interval = 1000;
                timer2.Enabled = true;
                timer2.Start();
                timer3.Interval = 300;
                timer3.Enabled = true;
                timer3.Start();
                timer4.Interval = 1000;
                timer4.Enabled = true;
                timer4.Start();
                timer5.Start();
                updPlan();
                String sql = String.Format(@"SELECT
	                                            * 
                                            FROM
	                                            IMOS_Lo_RKPlan 
                                            WHERE
	                                            Use_Flag = 1");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.PlanCount = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                
            }
            catch (Exception ex)
            {

            }

        }

       
        private void InitTabControl()
        {
            try
            {
                FrmSetPlan fsp = new FrmSetPlan();
                fsp.TopLevel = false;
                fsp.Dock = DockStyle.Fill;
                fsp.Parent = tabControl1.TabPages[1];
                fsp.Show();
                FrmMaterial fm = new FrmMaterial();
                fm.TopLevel = false;
                fm.Dock = DockStyle.Fill;
                fm.Parent = tabControl1.TabPages[2];
                fm.Show();
                FrmFPMonitor ffp = new FrmFPMonitor();
                ffp.TopLevel = false;
                ffp.Parent = tabControl1.TabPages[6];
                ffp.Dock = DockStyle.Fill;
                ffp.Show();
                String sql = String.Format(@"SELECT Material_Code,Material_Name FROM IMOS_TA_Material WHERE 1=1 Order By Material_Sort");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    com_Material.DataSource = ds.Tables[0];
                    com_Material.DisplayMember = "Material_Name";
                    com_Material.ValueMember = "Material_Code";
                }
                String sql2 = String.Format(@"SELECT
	                                                Parameter_Detail_Code,Parameter_Detail_Name 
                                                FROM
	                                                Sys_Parameters_Detail 
                                                WHERE
	                                                Parameter_Master_Code = '1001'");
                DataSet ds2 = DataHelper.Fill(sql2);
                if (ds2 != null)
                {
                    com_Line.DataSource = ds2.Tables[0];
                    com_Line.DisplayMember = "Parameter_Detail_Name";
                    com_Line.ValueMember = "Parameter_Detail_Code";
                }
                String gsql = String.Format(@"SELECT  Parameter_Master_Name From Sys_Parameters_Master  WHERE Parameter_Master_Code = '1008'");
                DataSet gds = DataHelper.Fill(gsql);
                if (gds != null && gds.Tables[0].Rows.Count == 1)
                {
                    dt_Start.Value = DateTime.Parse(gds.Tables[0].Rows[0]["Parameter_Master_Name"].ToString());
                }
                gsql = String.Format(@"SELECT  Parameter_Master_Name From Sys_Parameters_Master  WHERE Parameter_Master_Code = '1009'");
                gds = DataHelper.Fill(gsql);
                if (gds != null && gds.Tables[0].Rows.Count == 1)
                {
                    dt_End.Value = DateTime.Parse(gds.Tables[0].Rows[0]["Parameter_Master_Name"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }



        #region 串口扫码器属性设置
        public void InitScanProviderDetail()
        {
            try
            {
                // 打开串口  
                _scanner = new ScanProvider(BaseSystemInfo.SerialPortName1, 9600);
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
                string TipInfo = string.Format("工位{0}称重串口连接出现异常.端口【{1}】波特率【{2}】，", BaseSystemInfo.CurrentProcessName, BaseSystemInfo.SerialPortName1, 9600);
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

                    if (g_s_Data.Length != 9)
                    {
                        SysBusinessFunction.WriteLog("条码格式不对");
                        lbl_Msg.Text = "条码格式不对";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }
                    int address = BaseSystemInfo.RKAddress1;
                    //读取信号是否可以进
                    if ("2" == BaseSystemInfo.CurrentINStoreCode)
                    {
                       address = BaseSystemInfo.RKAddress2;
                    }
                    
                    
                    object[] RBuf = new object[1];
                    bool f = ControlMaster.ReadData(0, address, 1, out RBuf);
                    if (f && RBuf[0].ToString() == "1")
                    {
                        lbl_Msg.Text = "已经存在产品，请稍后";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }

                    string Sql = string.Format(@"SELECT Material_Code,Material_Name,Material_Sort  FROM IMOS_TA_Material where Material_Code = '{0}'", g_s_Data.Substring(0, 9));
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

                    //删除存储表
                    String delsql = String.Format(@"DELETE FROM IMOS_Lo_Scan_Code Where Store_Sort = '{0}'", BaseSystemInfo.CurrentINStoreCode);
                    DataHelper.Fill(delsql);

                    //插入存储表
                    String sql = String.Format(@"INSERT into IMOS_Lo_Scan_Code (Store_Sort,BarCode,MaterialSort,MaterialCode,MaterialName,ProcessCode,ProcessName)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", BaseSystemInfo.CurrentINStoreCode,
                                                                        BarCode, ds.Tables[0].Rows[0]["Material_Sort"].ToString(), BarCode.Substring(0, 9), ds.Tables[0].Rows[0]["Material_Name"].ToString(),
                                                                        BaseSystemInfo.CurrentProcessCode, BaseSystemInfo.CurrentProcessName);
                    DataHelper.Fill(sql);

                    DownNamePLC(ds.Tables[0].Rows[0]["Material_Sort"].ToString(),BaseSystemInfo.CurrentINStoreCode);
                    OptionSetting.ScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    lbl_MaterialCode.Text = OptionSetting.MaterialCode;
                    lbl_MaterialName.Text = OptionSetting.MaterialName;
                    lbl_ScanTime.Text = OptionSetting.ScanTime;


                    //if (chx_BD.Checked)//自动绑定
                    //{
                    //    BindingMaterial();
                    //}
                    //else
                    //{
                    //    //手动绑定（点击按钮）
                    //}

                }
                catch (Exception ex)
                {
                }
            }));
        }


        #endregion


        #region 下传型号
        private void DownNamePLC(string StrBarCode,string no)
        {
            try
            {
                int Address = BaseSystemInfo.RKAddress1 + 1;
                if (no == "2")
                {
                    Address = BaseSystemInfo.RKAddress2 + 1;
                }
               
               
                //直接下传PLC放行

                
                int len = BaseSystemInfo.RKLen;
                int Block = 0;
                object[] WBuf = new object[len];
                WBuf[1] = 1;
                WBuf[0] = StrBarCode;

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
                    if (GetTickCount() - DownCount > 3000) //超时处理
                    {
                        SysBusinessFunction.WriteLog("下传[" + StrBarCode + "]信号成功，等待反馈信号超时");
                        lbl_Msg.Text = "下传[" + StrBarCode + "]信号成功，等待反馈信号超时";
                        lbl_Msg.ForeColor = Color.Red;
                        break;
                    }

                    object[] RBuf = new object[2];
                    ControlMaster.ReadData(0, Address, len, out RBuf);
                    if (RBuf[1].ToString() == "2")
                    {
                        
                        WBuf[0] = 0;
                        WBuf[1] = 0;
                        bool result = ControlMaster.WriteData(Block, Address, WBuf);
                        if (result)
                        {
                            SysBusinessFunction.WriteLog("下传[" + StrBarCode + "]信号成功，等待反馈信号成功");
                        }

                        break;
                    }

                }
            }
            catch (Exception ex)
            {

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
                    //InitControlData();
                    string RFIDCode = BarCode.Trim();

                    if (RFIDCode.ToUpper() == "NOREAD")
                    {
                        SysBusinessFunction.WriteLog("RFID读取失败NOREAD");
                        //int ad = BaseSystemInfo.Maddress;
                        //int len = BaseSystemInfo.Mlen;
                        //object[] RB = new object[len];
                        //bool fldg = ControlMaster.ReadData(0,ad, len,out RB);
                        //if (!fldg)
                        //{

                        //    return;
                        //}
                        //if(RB[0].ToString() == "1")//有工装板
                        //{
                        String gsql = String.Format(@"SELECT Sort_Num From IMOS_TA_Sort where 1=1");
                        DataSet gds = DataHelper.Fill(gsql);
                        if (gds != null && gds.Tables[0].Rows.Count == 1)
                        {
                            RFIDCode = gds.Tables[0].Rows[0]["Sort_Num"].ToString();
                            SysBusinessFunction.WriteLog("生成虚拟工装板【" + RFIDCode + "】");
                            int m = int.Parse(RFIDCode) + 1;
                            if (m >= 20000)
                            {
                                m = 15000;
                            }
                            String usql = String.Format(@"UPDATE IMOS_TA_Sort SET  Sort_Num = {0} where 1=1", m);
                            DataHelper.Fill(usql);
                        }
                        //}
                    }
                    if (RFIDCode.Length != 5)
                    {
                        SysBusinessFunction.WriteLog("RFID条码格式不对");
                        lbl_Msg.Text = "RFID条码格式不对";
                        lbl_Msg.ForeColor = Color.Red;
                        return;
                    }
                    //删除绑定信息

                    String sql = String.Format(@"DELETE FROM IMOS_Lo_Pallet WHERE RFID_Code = '{0}'", RFIDCode);
                    DataSet ds = DataHelper.Fill(sql);
                    SysBusinessFunction.WriteLog("绑定信息删除【" + RFIDCode + "】");

                    //删除库存信息
                    String delsql = String.Format(@"DELETE From IMOS_Lo_Bin_Detial Where   RFID_Code = '{0}'  ", RFIDCode);
                    DataHelper.Fill(delsql);
                    SysBusinessFunction.WriteLog("工装板【" + RFIDCode + "】出库完成，详细表删除");

                    OptionSetting.BasketCode = RFIDCode;
                    lbl_BasketCode.Text = RFIDCode;
                    SysBusinessFunction.WriteLog("扫描到的工装板【" + RFIDCode + "】");
                    String insql = String.Format(@"INSERT INTo IMOS_RFID_List (RFID_Code) VALUES ('{0}')", RFIDCode);
                    DataHelper.Fill(insql);
                    String selsql = String.Format(@"SELECT RFID_Code  From IMOS_RFID_List WHERE 1=1 ORDER BY Create_Time");
                    DataSet selds = DataHelper.Fill(selsql);
                    if (selds != null)
                    {
                        if (selds.Tables[0].Rows.Count > 10)
                        {
                            String desql = String.Format(@"DELETE FROM IMOS_RFID_List WHERE RFID_CODE = '{0}'", selds.Tables[0].Rows[0]["RFID_Code"].ToString());
                            DataHelper.Fill(desql);
                            //SysBusinessFunction.WriteLog("工装板【" + RFIDCode + "】堆栈列表删除");
                        }
                    }


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



        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT Top 6 Material_Name FROM IMOS_Lo_Bin_Detial WHere Material_State = '0' Order By Create_Time ");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count >= 0)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Label lbl = Controls.Find("lbl_In" + (i + 1), true)[0] as Label;
                        if (i < ds.Tables[0].Rows.Count)
                        {

                            lbl.Text = ds.Tables[0].Rows[i]["Material_Name"].ToString();
                            lbl.BackColor = Color.Green;
                        }
                        else
                        {
                            lbl.Text = "";
                            lbl.BackColor = Color.Gray;
                        }

                    }
                }
                if (OptionSetting.Bindingflag)
                {
                    updPlan();
                    OptionSetting.Bindingflag = false;
                }
                pictureBox1.Left = pictureBox1.Left - 50;
                pictureBox2.Left = pictureBox2.Left + 50;
                if (pictureBox1.Left < 0)
                {
                    pictureBox1.Left = 753;
                }
                if (pictureBox2.Left > 753)
                {
                    pictureBox2.Left = 0;
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        private void updPlan()
        {
            try
            {
                string sdt = dt_Start.Text.ToString();
                string edt = dt_End.Text.ToString();
                String ksql = String.Format(@"UPDATE Sys_Parameters_Master SET Parameter_Master_Name = '{0}' WHERE Parameter_Master_Code = '1008'",sdt);
                DataHelper.Fill(ksql);
                ksql = String.Format(@"UPDATE Sys_Parameters_Master SET Parameter_Master_Name = '{0}' WHERE Parameter_Master_Code = '1009'", edt);
                DataHelper.Fill(ksql);
                String msql = String.Format(@"SELECT
	                                            B.Material_Name,
	                                            B.Material_Plan_Num,
	                                            ISNULL(
		                                            (
			                                            SELECT
				                                            COUNT (1)
			                                            FROM
				                                            IMOS_Lo_Task A
			                                            WHERE
				                                            A.Material_Code = B.Material_Code
			                                            AND A.Task_Type = 1
			                                            AND A.Create_Time >= '{0}'
                                                        AND A.Create_Time <= '{1}'
			                                            GROUP BY
				                                            A.Material_Code
		                                            ),
		                                            0
	                                            ) AcSum,
                                              B.Material_Plan_Num - ISNULL(
		                                            (
			                                            SELECT
				                                            COUNT (1)
			                                            FROM
				                                            IMOS_Lo_Task A
			                                            WHERE
				                                            A.Material_Code = B.Material_Code
			                                            AND A.Task_Type = 1
			                                            AND A.Create_Time >= '{0}'
                                                        AND A.Create_Time <= '{1}'
			                                            GROUP BY
				                                            A.Material_Code
		                                            ),
		                                            0
	                                            )   as CNum
                                            FROM
	                                            IMOS_TA_Material B
                                            WHERE
	                                            Material_Plan_Num != 0
                                            ",sdt,edt);
                DataSet mds = DataHelper.Fill(msql);

                if (mds != null)
                {

                    dgv_Task.DataSource = mds.Tables[0];
                    int m = 0;
                    int n = 0;
                    for (int i = 0; i < mds.Tables[0].Rows.Count; i++)
                    {
                        m = m + int.Parse(mds.Tables[0].Rows[i]["AcSum"].ToString());
                        n = n + int.Parse(mds.Tables[0].Rows[i]["Material_Plan_Num"].ToString());
                    }
                    if (n != int.Parse(lbl_PlanNum.Text))
                    {
                        lbl_PlanNum.Text = n.ToString();
                    }
                    double k = Double.Parse(lbl_PlanNum.Text.ToString());
                    double s = (double)m / k;
                    lbl_AcSum.Text = m.ToString();
                    lbl_Rate.Text = String.Format("{0:F}", s * 100) + "%";
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void dgv_Task_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgv_Task.Rows.Count; i++)
            {
                dgv_Task.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_Task.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
            }
            dgv_Task.ClearSelection();
        }







        private void btn_InStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (BaseSystemInfo.CurrentINStoreCode == BaseSystemInfo.MCXFlag.ToString())
                {
                    if (btn_InStore.Text == "手动入库")
                    {
                        btn_InStore.Text = "扫码入库";
                        OptionSetting.RKTypeFlag++;
                        return;
                    }
                    if (btn_InStore.Text == "扫码入库")
                    {
                        btn_InStore.Text = "计划入库";
                        OptionSetting.RKTypeFlag++;
                        return;
                    }
                    if (btn_InStore.Text == "计划入库")
                    {
                        OptionSetting.SDRKCode = "";
                        btn_InStore.Text = "手动入库";
                        OptionSetting.RKTypeFlag = 1;
                        return;
                    }
                }
                else
                {
                    if (btn_InStore.Text == "手动入库")
                    {
                        btn_InStore.Text = "扫码入库";
                        OptionSetting.RKTypeFlag++;
                        return;
                    }
                    if (btn_InStore.Text == "扫码入库")
                    {
                        btn_InStore.Text = "手动入库";
                        OptionSetting.RKTypeFlag--;
                        return;
                    }
                
                }
               
            }
            catch (Exception ex)
            {


            }
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                updPlan();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.OldBasketCode == null || OptionSetting.OldBasketCode.Length == 0)
                {
                    OptionSetting.OldBasketCode = "NOREAD";
                }
                OptionSetting.BasketCode = OptionSetting.OldBasketCode;
            }
            catch (Exception ex)
            {

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {

                int ad = BaseSystemInfo.Naddress;
                int len = BaseSystemInfo.Nlen;
                object[] RB = new object[len];
                bool fldg = ControlMaster.ReadData(0, ad, len, out RB);
                if (!fldg)
                {

                    return;
                }
                if (RB[0].ToString() == "1")//空板模式
                {
                    OptionSetting.Check = true;
                    lbl_MoShi.Text = "空板模式";
                    lbl_MoShi.ForeColor = Color.Red;
                }
                else
                {
                    OptionSetting.Check = false;
                    lbl_MoShi.Text = "正常模式";
                    lbl_MoShi.ForeColor = Color.Lime;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    int address = BaseSystemInfo.INRAddress;
                    int block = 0;
                    int len = 5;
                    object[] WBuf = new object[len];
                    WBuf[0] = lbl_RKRFID.Text.ToString();//RFID编号
                    WBuf[1] = lbl_RKSort.Text.ToString();      //产品代码

                    WBuf[2] = 0;      //货道号(PLC 自己获取)
                    WBuf[3] = 1;      //应答字
                    WBuf[4] = 0;      //反馈信息
                    bool flsg = ControlXPLC.WriteData(block, address, WBuf);
                    if (!flsg)
                    {
                        SysBusinessFunction.WriteLog("PLC下传失败");
                    }
                    int DownCount = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(5);
                        // Application.DoEvents();
                        //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                        if (GetTickCount() - DownCount > 5000) //超时处理
                        {
                            SysBusinessFunction.WriteLog("下传[" + "99" + "]入库放行信号成功，产品代号【" + 99 + "】等待入库放行信号超时");
                            //lbl_Msg.Text = "下传[" + "99" + "]入库放行信号成功，产品代号【" + 99 + "】等待入库放行信号超时";
                            //lbl_Msg.ForeColor = Color.Red;
                            break;
                        }

                        object[] RBuf = new object[1];
                        ControlXPLC.ReadData(0, address + 3, 1, out RBuf);

                        if (RBuf[0].ToString() == "2")
                        {
                            WBuf[0] = 0;
                            WBuf[1] = 0;
                            WBuf[2] = 0;
                            WBuf[3] = 0;
                            WBuf[4] = 0;
                            ControlXPLC.WriteData(block, address, WBuf);
                            SysBusinessFunction.WriteLog("手动下传[" + lbl_RKRFID.Text.ToString() + "]入库放行信号成功,产品代号【" + lbl_RKSort.Text.ToString() + "】接受入库放行信号成功");
                            String updsql = String.Format(@"UPDATE IMOS_Lo_Bin_Detial SET Material_State = '{0}' Where  
                                                                RFID_Code = '{1}' 
                                                            AND Area_Code = '{2}'
                                                            AND Material_State = '{3}' ", "1", lbl_RKRFID.Text.ToString(), BaseSystemInfo.AreaCode, "0");

                            DataHelper.Fill(updsql);
                            break;
                        }

                    }
                }));
            }
            catch (Exception ex)
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "是否清除所有在途信息？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }
                String updsql = String.Format(@"UPDATE IMOS_Lo_Bin_Detial SET Material_State = '{0}' Where  
                                                                 Area_Code = '{1}'
                                                           
                                                            AND Material_State = '{2}' ", "1", BaseSystemInfo.AreaCode, "0");

                DataHelper.Fill(updsql);
            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT * FROM IMOS_Lo_Bin_Detial WHERE Material_State = '0' ORDER BY Create_Time ");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    lbl_RKRFID.Text = ds.Tables[0].Rows[0]["RFID_CODE"].ToString();
                    lbl_RKSort.Text = ds.Tables[0].Rows[0]["Material_Sort"].ToString();
                    lbl_RKHD.Text = ds.Tables[0].Rows[0]["Store_Code"].ToString();
                }

            }
            catch (Exception ex)
            {

            }
        }


        private  void GetMTDevice(object state)
        {
            try
            {

                Thread.Sleep(10);
                if (OptionSetting.Check)//空板模式
                {
                    return;
                }

                if (OptionSetting.RKTypeFlag == 1)//手动
                {
                    int ad = BaseSystemInfo.RKAddress1;
                    if (BaseSystemInfo.CurrentINStoreCode == "2")
                    {
                        ad = BaseSystemInfo.RKAddress2;
                    }
                     
                    int len = 1;
                    object[] RB = new object[len];
                    bool fldg = ControlMaster.ReadData(0, ad, len, out RB);
                    if (!fldg)
                    {
                        return;
                    }
                    if (RB[0].ToString() == "0")//
                    {
                        if (OptionSetting.SDRKCode.Length == 9)
                        {
                            Thread.Sleep(50);
                            HandleScanBarData(OptionSetting.SDRKCode);
                            //if (OldSDRKCode != OptionSetting.SDRKCode)
                            //{
                            //    OldSDRKCode = OptionSetting.SDRKCode;  
                            //}
                            //else
                            //{
                            //    SysBusinessFunction.WriteLog("已经下传【"+OptionSetting.SDRKCode+"】成功,不再重复下传");
                            //}
                          
                            //OptionSetting.SDRKCode = "";
                        }
                    }
                    
                }
                else if (OptionSetting.RKTypeFlag == 3)//计划
                {
                    //flag = false;
                    Thread.Sleep(50);
                    String sql = String.Format(@"SELECT
	                                            * 
                                            FROM
	                                            IMOS_Lo_RKPlan 
                                            WHERE
	                                            1 = 1");
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds != null && ds.Tables[0].Rows.Count == 26)
                    {
                        for (int i = 0; i < 26; i++)
                        {

                            if (ds.Tables[0].Rows[i]["Use_Flag"].ToString() == "1")
                            {
                                OptionSetting.PlanCount = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                                if (ds.Tables[0].Rows[i]["Material_Code"].ToString() == "AAAA" || ds.Tables[0].Rows[i]["Material_Code"].ToString() == "BBBB")
                                {
                                    sql = String.Format(@"UPDATE IMOS_Lo_RKPlan SET Use_Flag = '{0}' Where ID = '{1}'", 0, OptionSetting.PlanCount);
                                    DataHelper.Fill(sql);
                                    if (OptionSetting.PlanCount == 26)
                                    {
                                        sql = String.Format(@"UPDATE IMOS_Lo_RKPlan SET Use_Flag = '{0}' Where ID = '{1}'", 1, 1);
                                        DataHelper.Fill(sql);
                                    }
                                    else
                                    {
                                        sql = String.Format(@"UPDATE IMOS_Lo_RKPlan SET Use_Flag = '{0}' Where ID = '{1}'", 1, OptionSetting.PlanCount + 1);
                                        DataHelper.Fill(sql);
                                    }
                                    return;
                                }
                                string mcode = ds.Tables[0].Rows[i]["Material_Code"].ToString();
                                string Sql = string.Format(@"SELECT Material_Code,Material_Name,Material_Sort  FROM IMOS_TA_Material where Material_Code = '{0}'", mcode);
                                DataSet sds = DataHelper.Fill(Sql);
                                //下传型号
                                DownNamePLC(sds.Tables[0].Rows[0]["Material_Sort"].ToString(), ds.Tables[0].Rows[i]["Line_Code"].ToString());
                               
                                if (sds != null && sds.Tables[0].Rows.Count > 0)
                                {
                                    BeginInvoke(new Action(() =>
                                    {
                                        lbl_Msg.Text = "计划执行产品【" + mcode + "】成功";
                                        lbl_Msg.ForeColor = Color.Lime;
                                        lbl_MaterialCode.Text = ds.Tables[0].Rows[i]["Material_Code"].ToString();
                                        lbl_MaterialName.Text = ds.Tables[0].Rows[i]["Material_Name"].ToString();
                                        lbl_ScanTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    }));
                                }
                                //库存数据更新
                                for (int k = 1; k <= 8; k++)
                                {
                                    int kaddress = BaseSystemInfo.KCaddress + (k - 1) * 10;

                                    object[] KRbuf = new object[1];
                                    bool result = ControlXPLC.ReadData(0, kaddress, 1, out KRbuf);
                                    if (result)
                                    {
                                        String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET Store_Qty = '{0}' Where Store_Code = '{1}'", KRbuf[0].ToString(), k);
                                        DataHelper.Fill(upsql);
                                    }
                                    else
                                    {
                                        return;
                                    }

                                }
                                //绑定数据
                                //验证库存是否已满
                                String chsql = String.Format(@"SELECT
	                                                           ISNULL(SUM (Store_Qty), 0) Store_Sum_Qty,
	                                                           ISNULL(SUM (Max_Qty), 0) Max_Sum_Qty
                                                            FROM
	                                                            IMOS_Lo_Bin
                                                            WHERE
	                                                            Material_Code = '{0}' and In_Flag = '{1}' ", mcode, "0");

                                DataSet chds = DataHelper.Fill(chsql);

                                if (chds != null)
                                {

                                    if (chds.Tables[0].Rows.Count >= 0)
                                    {
                                        String getsql = String.Format(@"SELECT ISNULL(SUM (1), 0) de_sum_Qty  FROM IMOS_Lo_Bin_Detial Where Material_Code = '{0}'", mcode);
                                        DataSet getds = DataHelper.Fill(getsql);
                                        if (getds != null && getds.Tables[0].Rows.Count > 0)
                                        {
                                            int ssq = int.Parse(chds.Tables[0].Rows[0]["Store_Sum_Qty"].ToString());
                                            int msq = int.Parse(chds.Tables[0].Rows[0]["Max_Sum_Qty"].ToString());
                                            int dsq = int.Parse(getds.Tables[0].Rows[0]["de_sum_Qty"].ToString());
                                            if (dsq + ssq >= msq)
                                            {
                                                flag = false;
                                                SysBusinessFunction.WriteLog(mcode+"库存已满,"+dsq+","+ssq + "," + msq);
                                                return;
                                            }
                                            SysBusinessFunction.WriteLog("这个没满可以入库," + dsq + "," + ssq + "," + msq);
                                            
                                        }

                                    }
                                }
                                int ad = BaseSystemInfo.FWaddress;
                                if("2"== ds.Tables[0].Rows[i]["Line_Code"].ToString())
                                {
                                    ad = BaseSystemInfo.FWaddress + 1;
                                }
                                int len = BaseSystemInfo.FWlen;
                                object[] RB = new object[len];
                                bool fldg = ControlMaster.ReadData(0, ad, len, out RB);
                                if (!fldg)
                                {

                                    return;
                                }
                                if (RB[0].ToString() == "0")
                                {
                                    OptionSetting.smi.MaterialBarCode = mcode;
                                    OptionSetting.smi.MaterialSort = sds.Tables[0].Rows[0]["Material_Sort"].ToString();
                                    OptionSetting.smi.MaterialCode = mcode;
                                    OptionSetting.smi.MaterialName = ds.Tables[0].Rows[i]["Material_Name"].ToString();

                                    //下传PLC
                                    flag = FrmBindingControlcs.DownPLC(ds.Tables[0].Rows[i]["Line_Code"].ToString());
                                }

                              

                                

                            }
                        }
                    }
                }
                else
                {

                }



            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetMTCodeTimer.Change(1000, Timeout.Infinite);
            }

        }

       
        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                 getPlanData();
                 
            }
            catch (Exception ex)
            {

            }
        }


        private void getPlanData()
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            * 
                                            FROM
	                                            IMOS_Lo_RKPlan 
                                            WHERE
	                                            1 = 1");
                DataSet ds = DataHelper.Fill(sql);
                if(ds!=null&&ds.Tables[0].Rows.Count == 26)
                {
                    for(int i = 0; i < 26; i++)
                    {
                        Panel pan = Controls.Find("pan_RKM" + (i+1), true)[0] as Panel;
                        Button Mbtn = Controls.Find("btn_RKMA" + (i + 1), true)[0] as Button;
                        Button Lbtn = Controls.Find("btn_RKLine" + (i + 1), true)[0] as Button;
                        Mbtn.Text = ds.Tables[0].Rows[i]["Material_Name"].ToString();
                        Mbtn.Tag = ds.Tables[0].Rows[i]["Material_Code"].ToString();
                        Lbtn.Text = ds.Tables[0].Rows[i]["Line_Name"].ToString();
                        Lbtn.Tag = ds.Tables[0].Rows[i]["Line_Code"].ToString();
                       
                        if (OptionSetting.PlanCount == int.Parse(ds.Tables[0].Rows[i]["ID"].ToString()))
                        {
                            
                                //OptionSetting.PlanCount = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                                pan.BackColor = Color.DarkGreen;
                                Mbtn.BackColor = Color.DarkGreen;
                                Lbtn.BackColor = Color.DarkGreen;
                            
                        }
                        else
                        {
                            pan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                            Mbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                            Lbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btn_SurePlan_Click(object sender, EventArgs e)
        {
            try
            {
                string start = txt_StartNo.Text.ToString();
                string end = txt_EndNo.Text.ToString();
                string materialname = com_Material.Text.ToString();
                string materialcode = com_Material.SelectedValue.ToString();
                string linename = com_Line.Text.ToString();
                string linecode = com_Line.SelectedValue.ToString();
                if (!IsInt(start))
                {
                    SysBusinessFunction.SystemDialog(2, "起始号不是数字");
                    return;
                }
                if (!IsInt(end))
                {
                    SysBusinessFunction.SystemDialog(2, "终止号不是数字");
                    return;
                }
                if (int.Parse(start) <= 0 || int.Parse(start) >= 27)
                {
                    SysBusinessFunction.SystemDialog(2, "起始号超出范围");
                    return;
                }
                if (int.Parse(end) <= 0 || int.Parse(end) >= 27)
                {
                    SysBusinessFunction.SystemDialog(2, "终止号超出范围");
                    return;
                }
                //if (linecode == null || linecode.Length == 0)
                //{
                //    SysBusinessFunction.SystemDialog(2, "类型不能为空");
                //    return;
                //}
                //if (linename == null || linename.Length == 0)
                //{
                //    SysBusinessFunction.SystemDialog(2, "类型不能为空");
                //    return;
                //}


                if (materialcode != null && materialname !=null)
                {
                    for (int i = int.Parse(start); i <= int.Parse(end); i++)
                    {
                        String sql = String.Format(@"UPDATE IMOS_Lo_RKPlan 
                                                    SET Material_Code = '{0}',
                                                    Material_Name = '{1}',
                                                    Line_Code = '{2}',
                                                    Line_Name = '{3}' 
                                                    WHERE
	                                                    ID = '{4}'", materialcode, materialname,linecode,linename,i);
                        DataSet ds = DataHelper.Fill(sql);
                    }
                    getPlanData();

                }
            }
            catch (Exception ex)
            {

            }
        }

      
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                txt_EndNo.Text = lbl.Text.ToString();
                txt_StartNo.Text = lbl.Text.ToString();
            }catch(Exception ex)
            {

            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            try
            {
                StreamReader sR1 = new StreamReader(@"RunLog/" + DateTime.Now.ToString("yyyyMMdd") + ".txt", Encoding.Default);
                string str = null;//先声明一个字符串
                strlist.Clear();

                while ((str = sR1.ReadLine()) != null)//判断读取到的字符串是为null，如果为null，说明已经读取到文件末尾
                {
                    strlist.Add(str);
                }
                richTextBox1.Text = "";
                for (int i = strlist.Count - 1; i >= 0 && i >= strlist.Count - 10; i--)
                {
                    richTextBox1.Text = strlist[i].ToString() + "\n" + richTextBox1.Text;
                }
                sR1.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_detail.Rows.Count; i++)
                {
                    dgv_detail.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_detail.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);

                }
                dgv_detail.ClearSelection();

            }
            catch(Exception ex)
            {

            }
        }

        private void getDetailData()
        {
            try
            {
                String sql = String.Format(@"SELECT  Detial_ID,Material_Name,Create_Time FROM IMOS_Lo_Bin_Detial where 1=1 ORDER BY Create_Time ");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    dgv_detail.DataSource = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void timer5_Tick_1(object sender, EventArgs e)
        {
            try
            {
                getDetailData();
            }
            catch(Exception ex)
            {

            }
        }

        private void brn_del_detail_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgv_detail.CurrentRow == null || dgv_detail.CurrentRow.Index == -1)
                {
                    return;
                }
                string mid = dgv_detail.CurrentRow.HeaderCell.Value.ToString();
                string sMessage = "确定删除【"+mid+"】行的数据吗？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    String sql = String.Format(@"DELETE FROM IMOS_Lo_Bin_Detial WHERE Detial_ID = '{0}'", dgv_detail.CurrentRow.Cells["Detial_ID"].Value.ToString());
                    DataHelper.Fill(sql);
                    SysBusinessFunction.WriteLog("手动删除"+ dgv_detail.CurrentRow.Cells["Material_Name"].Value.ToString()+"记录");
                    getDetailData();
                }
                
            }
            catch(Exception ex)
            {

            }
        }
    }
}
