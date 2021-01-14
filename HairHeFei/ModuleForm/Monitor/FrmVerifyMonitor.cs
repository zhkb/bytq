
using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmVerifyMonitor : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        private bool Stop_Flag = false;
        private string NowID;//存储ID
        private int NowColumnIndex;//存储行号
        private int NowRowIndex;//存储列号
        private int DetailCount = -1;
        private int NextSort = 0;
        #region 扫码器变量
        //******************** 扫码枪  以太网  ****************************
        private static Socket ScanSocket; //扫码socket
        private static IPEndPoint ScanPoint;//IP及端口信息
        private static bool BarScanConn = false;
        private static Thread InSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer ReConnectDeviceTimer; //重新连接socket
        private static int BarReConnCount = 0;
        #endregion

        public FrmVerifyMonitor()
        {
            InitializeComponent();
            dgv_BOM.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmVerifyMonitor_Load(object sender, EventArgs e)
        {
            ControlMaster.SystemInitialization();//初始化PLC
         //   ControlToask.SystemInitialization();//新建任务
            CreateBarScanSocket();//初始化Socket
            ReConnectDeviceTimer = new System.Threading.Timer(ReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 
            //定时刷新显示任务表
            GetBOMMaster();
            FirstDoToask();
        }



        #region  DataGridView 数据表设计

        private void GetBOMMaster() //获取BOM数据
        {
            try
            {
                //从BOM表中直接获取
                String sql = String.Format(@"SELECT
                                                ID,
                                                Material_Code,
	                                            Material_Name,
	                                            Station_No,
	                                            Convert(varchar(50),Call_Time,120) Call_Time
                                            FROM
	                                            IMOS_Lo_Task
                                            WHERE
	                                            Delete_Flag = 0
                                            AND Company_Code = '{0}'
                                            AND Factory_Code = '{1}'
                                            AND Product_Line_Code = '{2}'
                                            ORDER BY Call_Time",
               BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    return;
                }
                dgv_BOM.DataSource = ds.Tables[0];
                bool getFlag = false;
                foreach (DataGridViewRow dgvRow in dgv_BOM.Rows)
                {
                    if (dgvRow.Cells["ID"].Value.ToString().Equals(NowID))
                    {
                        dgvRow.Cells[NowColumnIndex].Selected = true;
                        NowRowIndex = dgvRow.Index;
                        NowColumnIndex = 0;
                        getFlag = true;
                    }
                }
                if (getFlag)
                {
                    NowColumnIndex = 0;
                    NowRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取任务列表发生异常！"+ex.Message);
            }
        }

        #endregion    

        #region  扫码器扫描
        public void CreateBarScanSocket()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanProIP);
            ScanPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanProPort));
            ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocket.Blocking = true;
            try
            {
                ScanSocket.Connect(ScanPoint);
                ScanSocket.Blocking = false;
                BarScanConn = true;
            }
            catch (SocketException ex)
            {
                BarScanConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.BarScanProPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            InSocketThread = new Thread(QualitySocketRecMsg);
            InSocketThread.IsBackground = true;
            InSocketThread.Start();
            #endregion
        }

        private void QualitySocketRecMsg()
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

                    BarScanConn = true;

                }
                catch (Exception ex)
                {
                    BarScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (BarScanConn))
                {
                    HandleQualityBarCode(strMsg.Trim());
                }
            }
        }

        public static void ReConnectDevice(object o)//socket重连接
        {

            //扫码器重新连接
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!BarScanConn)
                {
                    try
                    {
                        if (BarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocket.Connect(ScanPoint);
                        BarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, ScanPoint.ToString()));
                        BarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = ScanSocket.Send(arrMsgRec);
                    BarScanConn = sLen == 1;
                }
                catch
                {
                    BarScanConn = false;
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

        private void HandleQualityBarCode(string strMsg)
        {

            BeginInvoke(new Action(() =>
            {
                string BarCode = strMsg.Trim();
                SysBusinessFunction.WriteLog(string.Format("固定扫码器扫码：" + BarCode));
                MianDo(BarCode);

            }));
        }
        #endregion

        private void MianDo(String code)//刷新数据
        {
            try
            {
                //暂停时可以扫码但是不会验证
                if (Stop_Flag)
                {
                    return;
                }
                lbl_Msg.Text = "";
                lbl_BarCode.Text = code;
                lbl_MName.Text = "";
                lbl_ScanTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (code.ToUpper() == "NOREAD")
                {
                    lbl_Msg.Text = "条码扫描失败......";
                    lbl_Msg.ForeColor = Color.Red;
                    return;
                }
                if (code.Length != 20)
                {
                    lbl_Msg.Text = "扫描条码格式错误;";
                    lbl_Msg.ForeColor = Color.Red;
                    return;
                }
                SysBusinessFunction.WriteLog("扫码器扫码:"+code);
                String sql = String.Format(@"SELECT  Material_Name From IMOS_TA_Bom_Detail
                               where Material_Code = '{0}' and  BOM_Name = '{1}'", code.Substring(0, 9), lbl_MT_Name.Text.ToString().Trim());
                DataSet ds = DataHelper.Fill(sql);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    lbl_MName.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString().Trim();
                    lbl_Msg.Text = "扫码成功！";
                    lbl_Msg.ForeColor = Color.LimeGreen;
                    //扫码验证无序
                    bool Pass_Flag = false;
                    for (int i = 1; i <= DetailCount; i++)
                    {
                        Label ln = Controls.Find("lbl_MKN" + i, true)[0] as Label;
                        Panel p = Controls.Find("Pan_MK" + i, true)[0] as Panel;
                        Label lb = Controls.Find("lbl_MKB" + i, true)[0] as Label;
                        Label lno = Controls.Find("lbl_MK_No" + i, true)[0] as Label;
                        if (ln.Text.ToString().Trim().Equals(ds.Tables[0].Rows[0]["Material_Name"].ToString().Trim())&&p.BackColor == Color.Gray)
                        {
                            lb.Text = code;               
                            p.BackColor = Color.LimeGreen;
                            int sv = int.Parse(lbl_Succeed_Verify.Text.ToString().Trim());
                            int nv = int.Parse(lbl_Not_Verify.Text.ToString().Trim());
                            lbl_Succeed_Verify.Text = (sv + 1).ToString();
                            lbl_Not_Verify.Text = (nv - 1).ToString();
                            double d = (double)((double)(DetailCount - nv + 1) / (double)DetailCount) * 100;
                            lbl_Verify.Text = Math.Round(d, 1) + "%";
                            if (d > 100)
                            {
                                lbl_Verify.ForeColor = Color.Red;
                            }else
                            {
                                lbl_Verify.ForeColor = Color.Gold;
                            }
                            NextSort++;
                            Pass_Flag = true;
                        }
                    }               
                    if (!Pass_Flag)
                    {
                        //发生重复扫码
                        lbl_Msg.Text = "重复扫码！";
                        lbl_Msg.ForeColor = Color.LimeGreen;
                    }

                }
                else
                {
                    lbl_Msg.Text = "该型号不属于当前门体！";
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Result.Text = "验证失败！禁止放行!";
                    lbl_Result.ForeColor = Color.Red;
                    int fv = int.Parse(lbl_fail_Verify.Text.ToString().Trim());
                    lbl_fail_Verify.Text = (fv + 1).ToString();
                    double d = (double)((double)NextSort / (double)DetailCount) * 100;
                    lbl_Verify.Text = Math.Round(d, 1)+ "%";
                    if (d > 100)
                    {
                        lbl_Verify.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_Verify.ForeColor = Color.Gold;
                    }
                    lbl_Not_Verify.Text = (DetailCount - NextSort).ToString();
                    NextSort++;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("扫码器门壳扫码验证过程发生异常！"+ex.Message);
            }
        }



        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Stop_Flag)
                {
                    SysBusinessFunction.SystemDialog(4, "验证已暂停!");
                }
                else
                {
                    if (NextSort != (DetailCount+1))
                    {
                        lbl_Result.Text = "验证失败!";
                        lbl_Result.ForeColor = Color.Red;
                        return;
                    }
                    bool flag = false;
                    lbl_BarCode.Text = "";
                    lbl_ScanTime.Text = "";
                    lbl_Msg.Text = "";
                    lbl_MName.Text = "";
                    for (int i = 1; i <= DetailCount; i++)
                    {
                        Panel p = Controls.Find("Pan_MK" + i, true)[0] as Panel;
                        if (p.BackColor != Color.LimeGreen)
                        {
                            p.BackColor = Color.Red;
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        lbl_Result.Text = "验证失败!";
                        lbl_Result.ForeColor = Color.Red;
                        return;
                    }
                    //PLC 下传 验证成功信号
                    int address = 41;
                    object[] WBuf = new object[1];
                    WBuf[0] = 1;
                    bool Result = ControlMaster.WriteData(0, address, WBuf);
                    if (!Result)
                    {
                        SysBusinessFunction.WriteLog("PLC下传验证成功信号失败！");
                        return;
                    }
                    //删除数据
                    DelToask(NowID);
                    GetBOMMaster();         
                    FirstDoToask();//执行首行任务
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("验证过程发生异常！"+ex.Message);
            }
        }

        private void FirstDoToask()//执行首行任务
        {
            try
            {
                if (dgv_BOM.Rows.Count > 0)
                {
                    GetMK(dgv_BOM.Rows[0].Cells["Material_Code"].Value.ToString().Trim());
                    lbl_MT_Name.Text = dgv_BOM.Rows[0].Cells["Material_Name"].Value.ToString().Trim();
                    lbl_Station_No.Text = dgv_BOM.Rows[0].Cells["Station_No"].Value.ToString().Trim();
                    lbl_Call_Time.Text = dgv_BOM.Rows[0].Cells["Call_Time"].Value.ToString().Trim();
                    NowID = dgv_BOM.Rows[0].Cells["ID"].Value.ToString().Trim();
                    NowColumnIndex = 0;
                    NowRowIndex = 0;
                    NextSort = 1;
                    dgv_BOM.Rows[0].Cells[0].Selected = true;
                }
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("执行首行任务过程发生异常！" + ex.Message);
            }
        }

        private void btn_ReSet_Click(object sender, EventArgs e)//重置按钮 
        {
            try
            {
                //数据刷新
                RefreshDetail(new DataTable(), 2);//刷新界面
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("重置过程发生异常！"+ex.Message);
            }
        }

        private void btn_Close2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)//刷新按钮
        {
                GetBOMMaster();                  
        }

        private void dgv_BOM_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//单元格点击事件
        {
            try
            {
                if (e.RowIndex >= 0) //判断选中的行是不是表头
                {
                    if (e.ColumnIndex == 2)//取消操作（删除）
                    {
                        #region 取消任务
                        if (dgv_BOM.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim().Equals(NowID))
                        {
                            SysBusinessFunction.SystemDialog(4, "任务执行中，无法取消!");
                            dgv_BOM.Rows[NowRowIndex].Cells[0].Selected = true;
                            //记录鼠标点击的行号和列号
                            NowColumnIndex = 0;
                            NowRowIndex = e.RowIndex;
                            return;
                        }
                        //弹出提示框 提示是否删除任务                    
                        string sMessage = "确定删除门体名称为【" + dgv_BOM.Rows[e.RowIndex].Cells["Material_Name"].Value.ToString().Trim() + "】的任务？";
                        if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                        {
                            dgv_BOM.Rows[NowRowIndex].Cells[NowColumnIndex].Selected = true;
                            return;
                        }
                        DelToask(dgv_BOM.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim());
                        GetBOMMaster();
                        #endregion
                    }
                    else if (e.ColumnIndex == 0)//执行操作
                    {
                        #region 执行任务
                        //if (Stop_Flag)//验证暂停，无法执行
                        //{
                        //    if (dgv_BOM.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim().Equals(NowID))
                        //    {
                        //        SysBusinessFunction.SystemDialog(4, "任务已暂停，不能执行！");
                        //    }else
                        //    {
                        //        SysBusinessFunction.SystemDialog(4, "现有任务已暂停，不能执行新任务！");                              
                        //    }
                        //    dgv_BOM.Rows[NowRowIndex].Cells[NowColumnIndex].Selected = true;
                        //}
                        //else
                        //{                          
                            //获取Material_Name(门体型号)来查找详细BOM（ ）
                            GetMK(dgv_BOM.Rows[e.RowIndex].Cells["Material_Code"].Value.ToString().Trim());
                            //界面刷新
                            lbl_MT_Name.Text = dgv_BOM.Rows[e.RowIndex].Cells["Material_Name"].Value.ToString().Trim();
                            lbl_Station_No.Text = dgv_BOM.Rows[e.RowIndex].Cells["Station_No"].Value.ToString().Trim();
                            lbl_Call_Time.Text = dgv_BOM.Rows[e.RowIndex].Cells["Call_Time"].Value.ToString().Trim();
                            NowID = dgv_BOM.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim();
                            //记录鼠标点击的行号和列号
                            NowColumnIndex = e.ColumnIndex;
                            NowRowIndex = e.RowIndex;
                            Stop_Flag = false;                     
                        //}
                        #endregion
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        #region 暂停任务
                        if (Stop_Flag)//已暂停
                        {
                            if (dgv_BOM.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim().Equals(NowID))//判断是否是正在执行的任务
                            {
                                //继续运行
                                dgv_BOM.Rows[NowRowIndex].Cells[0].Selected = true;
                                NowColumnIndex = 0;
                                Stop_Flag = false;
                            }
                            else
                            {
                                //提示信息
                                SysBusinessFunction.SystemDialog(4, "该任务不是正在执行的任务，不能暂停！");
                                dgv_BOM.Rows[NowRowIndex].Cells[NowColumnIndex].Selected = true;
                            }
                        }
                        else//未暂停
                        {
                            if (dgv_BOM.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim().Equals(NowID))//判断是否是正在执行的任务
                            {
                                Stop_Flag = true;
                                //记录鼠标点击的行号和列号
                                NowColumnIndex = e.ColumnIndex;
                            }
                            else
                            {
                                SysBusinessFunction.SystemDialog(4, "该任务未执行！");
                                //回写
                                dgv_BOM.Rows[NowRowIndex].Cells[NowColumnIndex].Selected = true;
                            }
                        }
                        #endregion
                    }
                    else
                    {                        
                        dgv_BOM.CurrentCell.Selected = false;
                        dgv_BOM.Rows[NowRowIndex].Cells[NowColumnIndex].Selected = true;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("点击DataGridView中按钮发生异常！"+ex.Message);
            }
        }

        private void GetMK(string code)// 获取门壳详细信息
        {
            try
            {
                // 获取 BOM 详细信息
                String sql = String.Format(@"SELECT  Material_Code,Material_Name FROM IMOS_TA_Bom_Detail
                                                   WHERE BOM_Code = '{0}'", code);
                DataSet ds = DataHelper.Fill(sql);
                DetailCount = ds.Tables[0].Rows.Count;
                RefreshDetail(ds.Tables[0],1);//刷新界面
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取门壳信息发生异常！"+ex.Message);
            }
        }

        private void RefreshDetail(DataTable dt,int type)//type  1 新任务 插入门壳名称 2 重置 不插入门壳名称
        {
            try
            {
                for (int i = 0; i < 5; i++)//显示详细BOM
                {
                    Panel p = Controls.Find("Pan_MK" + (i + 1), true)[0] as Panel;
                    if (i < DetailCount)
                    {
                        p.Visible = true;
                        Label ln = Controls.Find("lbl_MKN" + (i + 1), true)[0] as Label;
                        Label lb = Controls.Find("lbl_MKB" + (i + 1), true)[0] as Label;
                        Label lno = Controls.Find("lbl_MK_No" + (i + 1), true)[0] as Label;
                        if(type == 1)
                        {
                            ln.Text = dt.Rows[i]["Material_Name"].ToString();
                        }
                        lb.Text = "";
                        p.BackColor = Color.Gray;
                    }
                    else
                    {
                        p.Visible = false;
                    }
                }
                //界面数据刷新
                lbl_Not_Verify.Text = DetailCount.ToString();
                lbl_fail_Verify.Text = "0";
                lbl_Succeed_Verify.Text = "0";
                lbl_Verify.Text = "0%";
                lbl_Result.Text = "正在验证门壳.....";
                lbl_Result.ForeColor = Color.LimeGreen;
                lbl_BarCode.Text = "";
                lbl_MName.Text = "";
                lbl_ScanTime.Text = "";
                lbl_Msg.Text = "";
                NextSort = 1;
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("门壳信息界面刷新过程发生异常！" + ex.Message);
            }
        }

        private void DelToask(string id)//删除任务
        {
            try
            {
                String sql = String.Format(@"UPDATE IMOS_Lo_Task SET Delete_Flag = 1,Modify_Time = getDate() where ID = {0}", id);
                DataHelper.Fill(sql);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("删除任务过程发生异常！" + ex.Message);
            }
        }

        private void dgv_BOM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            #region 设置表格序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,e.RowBounds.Location.Y,dgv_BOM.RowHeadersWidth,e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv_BOM.RowHeadersDefaultCellStyle.Font, rectangle, dgv_BOM.RowHeadersDefaultCellStyle.ForeColor,TextFormatFlags.Right & TextFormatFlags.VerticalCenter);
            #endregion
        }

        private void FrmVerifyMonitor_Shown(object sender, EventArgs e)
        {
            try
            {
                dgv_BOM.Rows[0].Cells[0].Selected = true;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
