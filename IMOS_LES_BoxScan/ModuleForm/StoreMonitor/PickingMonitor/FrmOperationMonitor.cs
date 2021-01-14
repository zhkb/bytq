using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PickingMonitor
{
    public partial class FrmOperationMonitor : Form
    {
        #region  出库扫码器变量
        //以太网扫码
        private  Socket Socket; //OUT扫码
        private  IPEndPoint SocketPoint;//IP及端口信息
        private  bool SocketConn = false;
        private  Thread SocketThread = null; // 创建用于接收服务端消息的 线程； 
        public  System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private  int ReConnCount = 0;
        private  ArrayList strlist = new ArrayList();
        #endregion
        public FrmOperationMonitor()
        {
            InitializeComponent();
        }

        private void FrmOperationMonitor_Load(object sender, EventArgs e)
        {
            timer1.Interval = 300;
            timer1.Enabled = true;
            timer1.Start();
            timer2.Interval = 300;
            timer2.Enabled = true;
            timer2.Start();
            CreateOUTSocket();
            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite);//条码扫描设备重连
        }

        #region OUT 扫码器创建
        private void CreateOUTSocket()//创建OUT扫码器
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.SocketIP);//扫码IP地址
            SocketPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.SocketPort));//端口号
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Blocking = true;
            try
            {
                Socket.Connect(SocketPoint);
                Socket.Blocking = false;
                SocketConn = true;
            }
            catch (SocketException ex)
            {
                SocketConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.SocketPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            SocketThread = new Thread(RecMsg);
            SocketThread.IsBackground = true;
            SocketThread.Start();
            #endregion
        }

        #endregion

        #region OUT扫码器获取数据
        private  void RecMsg()
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
                    length = Socket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    SocketConn = true;
                }
                catch
                {
                    SocketConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (SocketConn))
                {
                    HandleOUTData(strMsg.Trim());
                }
            }
        }

        #endregion

        #region OUT扫码器数据处理

        //扫码器扫到箱体码 通过BOM 找到门体型号 创建出库任务

        private  void HandleOUTData(string MBarCode)//产品条码
        {
            //扫码出库
            BeginInvoke(new Action(() =>
            {
                try
                {

                    String BarCode = MBarCode.Trim();
                    SysBusinessFunction.WriteLog("产品条码为【" + BarCode + "】");
                    lbl_BarCode.Text = BarCode;
                    //判断是否满足规范
                    if (BarCode.ToUpper() == "NO READ")
                    {
                        SysBusinessFunction.WriteLog("读取失败NOREAD");
                        return;
                    }
                    if (BarCode.Length != 20)
                    {
                        SysBusinessFunction.WriteLog("条码格式不对");
                        return;
                    }
                    //扫描产品码获取BOM
                    String sql = String.Format(@"SELECT
                                                MASTER_MATERIAL_NAME,
	                                            DETAIL_MATERIAL_CODE,
	                                            DETAIL_MATERIAL_NAME,
                                                DETAIL_TYPE_CODE,
                                                DETAIL_TYPE_NAME,
	                                            Qty
                                            FROM
	                                            IMOS_TE_BOM_LIST
                                            WHERE
	                                            MASTER_MATERIAL_CODE = '{0}'", BarCode.Substring(0, 10));
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            SysBusinessFunction.WriteLog("没有维护BOM");
                            return;
                        }
                        lbl_Product_Name.Text = ds.Tables[0].Rows[0]["MASTER_MATERIAL_NAME"].ToString();
                        lbl_Door_Name.Text = ds.Tables[0].Rows[0]["DETAIL_MATERIAL_NAME"].ToString();
                        //创建出库任务
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            String strguid = Guid.NewGuid().ToString();
                            System.Data.OracleClient.OracleParameter[] values = {
                                    new System.Data.OracleClient.OracleParameter("COMPANYCODE",BaseSystemInfo.Company_Code),
                                    new System.Data.OracleClient.OracleParameter("COMPANYNAME",BaseSystemInfo.Company_Name),
                                    new System.Data.OracleClient.OracleParameter("FACTORYCODE",BaseSystemInfo.Factory_Code),
                                    new System.Data.OracleClient.OracleParameter("FACTORYNAME",BaseSystemInfo.Factory_Name),
                                    new System.Data.OracleClient.OracleParameter("DEVICECODE", BaseSystemInfo.Device_Code),
                                    new System.Data.OracleClient.OracleParameter("DEVICENAME",BaseSystemInfo.Device_Name),
                                    new System.Data.OracleClient.OracleParameter("TASKID", strguid),
                                    new System.Data.OracleClient.OracleParameter("AUTOFLAG","0"),
                                    new System.Data.OracleClient.OracleParameter("TASKSTATE", "0"),
                                    new System.Data.OracleClient.OracleParameter("TASKTYPE","O" ),
                                    new System.Data.OracleClient.OracleParameter("TASKFROM",""),
                                    new System.Data.OracleClient.OracleParameter("MATERIALCODE",ds.Tables[0].Rows[i]["DETAIL_MATERIAL_CODE"].ToString()),
                                    new System.Data.OracleClient.OracleParameter("MATERIALNAME",ds.Tables[0].Rows[i]["DETAIL_MATERIAL_NAME"].ToString()),
                                    new System.Data.OracleClient.OracleParameter("MATERIALTYPECODE", ds.Tables[0].Rows[i]["DETAIL_TYPE_CODE"].ToString()),
                                    new System.Data.OracleClient.OracleParameter("MATERIALTYPENAME", ds.Tables[0].Rows[i]["DETAIL_TYPE_NAME"].ToString()),
                                    new System.Data.OracleClient.OracleParameter("MATERIALBARCODE","" ),
                                    new System.Data.OracleClient.OracleParameter("CREATEDBY","1023" ),
                                    new System.Data.OracleClient.OracleParameter("TASKEND","CK001")
                                    };
                            DataHelper.ExecuteProcedure("IN_TEMPOERARY_TASK", values);

                        }
                        lbl_Msg.Text = "出库任务生成成功!";
                        lbl_Msg.ForeColor = Color.Lime;
                        SysBusinessFunction.WriteLog("出库任务生成成功!");
                    }


                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("扫码出库出现异常" + ex.Message);
                }
            }));
        }

        #endregion

        #region 以太网扫码器重连
        public  void ReConnectDevice(object o)//OUT重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!SocketConn)
                {
                    try
                    {
                        if (ReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("出库扫描设备断线重连中......，{0}", ReConnCount.ToString()));
                        }
                        ReConnCount++;
                        Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        Socket.Connect(SocketPoint);
                        SocketConn = true;
                        SysBusinessFunction.WriteLog(string.Format("出库扫描设备重新连接成功，重连次数{0}，{1}", ReConnCount, SocketPoint.ToString()));
                        ReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = Socket.Send(arrMsgRec);
                    SocketConn = sLen == 1;
                }
                catch
                {
                    SocketConn = false;
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                StreamReader sR1 = new StreamReader(@"RunLog/"+ DateTime.Now.ToString("yyyyMMdd")+".txt",Encoding.Default);
                string str = null;//先声明一个字符串
                strlist.Clear();

                while ((str = sR1.ReadLine()) != null)//判断读取到的字符串是为null，如果为null，说明已经读取到文件末尾
                {
                    strlist.Add(str);
                }
                richTextBox1.Text = "";
                for(int i = strlist.Count-1; i>=0 && i >= strlist.Count - 10; i--)
                {
                    richTextBox1.Text = strlist[i].ToString() + "\n" + richTextBox1.Text;
                }
                sR1.Close();
            }
            catch(Exception ex)
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.Outflag)
                {
                    OptionSetting.Outflag = !OptionSetting.Outflag;
                    if (OptionSetting.OutMsgColor)
                    {
                        lbl_Msg.ForeColor = Color.Lime;

                    }
                    else
                    {
                        lbl_Msg.ForeColor = Color.Red;
                    }
                    lbl_Msg.Text = OptionSetting.OutMsg;
                    lbl_Store_Row.Text = OptionSetting.OutRow;
                    lbl_Store_Sort.Text = OptionSetting.OutSort;
                    lbl_Store_Column.Text = OptionSetting.OutColumn;
                    lbl_Store_Tier.Text = OptionSetting.OutTier;
                }
                getData("I");
                getData("O");


            }
            catch(Exception ex)
            {

            }
        }
        private void getData(String inttype)
        {
            try
            {
                String sql = String.Format(@"SELECT 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >0 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=1) THEN 1 ELSE 0 END) total_Qty0, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >1 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=2) THEN 1 ELSE 0 END) total_Qty1,
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >2 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=3) THEN 1 ELSE 0 END) total_Qty2, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >3 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=4) THEN 1 ELSE 0 END) total_Qty3,   
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >4 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=5) THEN 1 ELSE 0 END) total_Qty4, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >5 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=6) THEN 1 ELSE 0 END) total_Qty5, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >6 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=7) THEN 1 ELSE 0 END) total_Qty6, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >7 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=8) THEN 1 ELSE 0 END) total_Qty7, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >8 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=9) THEN 1 ELSE 0 END) total_Qty8, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >9 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=10) THEN 1 ELSE 0 END) total_Qty9, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >10 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=11) THEN 1 ELSE 0 END) total_Qty10, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >11 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=12) THEN 1 ELSE 0 END) total_Qty11,
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >12 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=13) THEN 1 ELSE 0 END) total_Qty12, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >13 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=14) THEN 1 ELSE 0 END) total_Qty13,
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >14 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=15) THEN 1 ELSE 0 END) total_Qty14, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >15 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=16) THEN 1 ELSE 0 END) total_Qty15, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >16 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=17) THEN 1 ELSE 0 END) total_Qty16,
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >17 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=18) THEN 1 ELSE 0 END) total_Qty17, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >18 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=19) THEN 1 ELSE 0 END) total_Qty18, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >19 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=20) THEN 1 ELSE 0 END) total_Qty19,
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >20 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=21) THEN 1 ELSE 0 END) total_Qty20, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >21 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=22) THEN 1 ELSE 0 END) total_Qty21,
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >22 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=23) THEN 1 ELSE 0 END) total_Qty22, 
	                                            SUM(CASE WHEN (TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 >23 AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <=24) THEN 1 ELSE 0 END) total_Qty23

                                             FROM IMOS_LO_TEMPORARY_TASK WHERE USE_FLAG = '{0}' AND TO_NUMBER(CREATION_DATE - Trunc(SYSDATE)) * 24 <= 24 AND TASK_TYPE = '{1}'", "1", inttype);
                DataSet ds = DataHelper.Fill(sql);

                if (ds != null)
                {
                    if ("I" == inttype)
                    {
                        In_Chart.Series[0].Points.Clear();
                        In_Chart.Series[0].Points.AddXY("00", ds.Tables[0].Rows[0]["total_Qty0"].ToString());
                        In_Chart.Series[0].Points.AddXY("01", ds.Tables[0].Rows[0]["total_Qty1"].ToString());
                        In_Chart.Series[0].Points.AddXY("02", ds.Tables[0].Rows[0]["total_Qty2"].ToString());
                        In_Chart.Series[0].Points.AddXY("03", ds.Tables[0].Rows[0]["total_Qty3"].ToString());
                        In_Chart.Series[0].Points.AddXY("04", ds.Tables[0].Rows[0]["total_Qty4"].ToString());
                        In_Chart.Series[0].Points.AddXY("05", ds.Tables[0].Rows[0]["total_Qty5"].ToString());
                        In_Chart.Series[0].Points.AddXY("06", ds.Tables[0].Rows[0]["total_Qty6"].ToString());
                        In_Chart.Series[0].Points.AddXY("07", ds.Tables[0].Rows[0]["total_Qty7"].ToString());
                        In_Chart.Series[0].Points.AddXY("08", ds.Tables[0].Rows[0]["total_Qty8"].ToString());
                        In_Chart.Series[0].Points.AddXY("09", ds.Tables[0].Rows[0]["total_Qty9"].ToString());
                        In_Chart.Series[0].Points.AddXY("10", ds.Tables[0].Rows[0]["total_Qty10"].ToString());
                        In_Chart.Series[0].Points.AddXY("11", ds.Tables[0].Rows[0]["total_Qty11"].ToString());
                        In_Chart.Series[0].Points.AddXY("12", ds.Tables[0].Rows[0]["total_Qty12"].ToString());
                        In_Chart.Series[0].Points.AddXY("13", ds.Tables[0].Rows[0]["total_Qty13"].ToString());
                        In_Chart.Series[0].Points.AddXY("14", ds.Tables[0].Rows[0]["total_Qty14"].ToString());
                        In_Chart.Series[0].Points.AddXY("15", ds.Tables[0].Rows[0]["total_Qty15"].ToString());
                        In_Chart.Series[0].Points.AddXY("16", ds.Tables[0].Rows[0]["total_Qty16"].ToString());
                        In_Chart.Series[0].Points.AddXY("17", ds.Tables[0].Rows[0]["total_Qty17"].ToString());
                        In_Chart.Series[0].Points.AddXY("18", ds.Tables[0].Rows[0]["total_Qty18"].ToString());
                        In_Chart.Series[0].Points.AddXY("19", ds.Tables[0].Rows[0]["total_Qty19"].ToString());
                        In_Chart.Series[0].Points.AddXY("20", ds.Tables[0].Rows[0]["total_Qty20"].ToString());
                        In_Chart.Series[0].Points.AddXY("21", ds.Tables[0].Rows[0]["total_Qty21"].ToString());
                        In_Chart.Series[0].Points.AddXY("22", ds.Tables[0].Rows[0]["total_Qty22"].ToString());
                        In_Chart.Series[0].Points.AddXY("23", ds.Tables[0].Rows[0]["total_Qty23"].ToString());
                    }
                    else if("O" == inttype)
                    {
                        Out_Chart.Series[0].Points.Clear();
                        Out_Chart.Series[0].Points.AddXY("00", ds.Tables[0].Rows[0]["total_Qty0"].ToString());
                        Out_Chart.Series[0].Points.AddXY("01", ds.Tables[0].Rows[0]["total_Qty1"].ToString());
                        Out_Chart.Series[0].Points.AddXY("02", ds.Tables[0].Rows[0]["total_Qty2"].ToString());
                        Out_Chart.Series[0].Points.AddXY("03", ds.Tables[0].Rows[0]["total_Qty3"].ToString());
                        Out_Chart.Series[0].Points.AddXY("04", ds.Tables[0].Rows[0]["total_Qty4"].ToString());
                        Out_Chart.Series[0].Points.AddXY("05", ds.Tables[0].Rows[0]["total_Qty5"].ToString());
                        Out_Chart.Series[0].Points.AddXY("06", ds.Tables[0].Rows[0]["total_Qty6"].ToString());
                        Out_Chart.Series[0].Points.AddXY("07", ds.Tables[0].Rows[0]["total_Qty7"].ToString());
                        Out_Chart.Series[0].Points.AddXY("08", ds.Tables[0].Rows[0]["total_Qty8"].ToString());
                        Out_Chart.Series[0].Points.AddXY("09", ds.Tables[0].Rows[0]["total_Qty9"].ToString());
                        Out_Chart.Series[0].Points.AddXY("10", ds.Tables[0].Rows[0]["total_Qty10"].ToString());
                        Out_Chart.Series[0].Points.AddXY("11", ds.Tables[0].Rows[0]["total_Qty11"].ToString());
                        Out_Chart.Series[0].Points.AddXY("12", ds.Tables[0].Rows[0]["total_Qty12"].ToString());
                        Out_Chart.Series[0].Points.AddXY("13", ds.Tables[0].Rows[0]["total_Qty13"].ToString());
                        Out_Chart.Series[0].Points.AddXY("14", ds.Tables[0].Rows[0]["total_Qty14"].ToString());
                        Out_Chart.Series[0].Points.AddXY("15", ds.Tables[0].Rows[0]["total_Qty15"].ToString());
                        Out_Chart.Series[0].Points.AddXY("16", ds.Tables[0].Rows[0]["total_Qty16"].ToString());
                        Out_Chart.Series[0].Points.AddXY("17", ds.Tables[0].Rows[0]["total_Qty17"].ToString());
                        Out_Chart.Series[0].Points.AddXY("18", ds.Tables[0].Rows[0]["total_Qty18"].ToString());
                        Out_Chart.Series[0].Points.AddXY("19", ds.Tables[0].Rows[0]["total_Qty19"].ToString());
                        Out_Chart.Series[0].Points.AddXY("20", ds.Tables[0].Rows[0]["total_Qty20"].ToString());
                        Out_Chart.Series[0].Points.AddXY("21", ds.Tables[0].Rows[0]["total_Qty21"].ToString());
                        Out_Chart.Series[0].Points.AddXY("22", ds.Tables[0].Rows[0]["total_Qty22"].ToString());
                        Out_Chart.Series[0].Points.AddXY("23", ds.Tables[0].Rows[0]["total_Qty23"].ToString());
                    }
                  

                }
            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTaskMonitor ftm = new FrmTaskMonitor();
                ftm.Show();
            }
            catch(Exception ex)
            {

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmStoreMonitor fsm = new FrmStoreMonitor();
                fsm.Show();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
