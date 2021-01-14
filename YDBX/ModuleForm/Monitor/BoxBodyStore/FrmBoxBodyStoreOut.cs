using Monitor.BoxBodyStore;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmBoxBodyStoreOut : Form
    {
        private ArrayList BinFormList = new ArrayList(); //库位详细信息
        private System.Timers.Timer RefreshDataTimer = new System.Timers.Timer(1000); //刷新库存数据Timer 
        private FrmPlanTask frmTask ;
        public FrmBoxBodyStoreOut()
        {
            InitializeComponent();
        }
    

        #region 窗体加载
        private void FrmBoxBodyStoreOut_Load(object sender, EventArgs e)
        {
           
            SetStoreBinForm();//设置货道数据
            GetPlanData(null);
            GetStoreBinData(null);
            RefreshDataTimer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshEvent);
            RefreshDataTimer.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            RefreshDataTimer.Enabled = true; //是否触发Elapsed事件
            RefreshDataTimer.Start();
        }   


        private void RefreshEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetStoreBinData(null);
            GetPlanData(null);
        }

        #endregion


        #region 按钮操作

        #region 打开任务界面
        private void button1_Click(object sender, EventArgs e)
        {

            if (frmTask == null || frmTask.IsDisposed)
            {
                frmTask = new FrmPlanTask();
                frmTask.Show();//未打开，直接打开。
            }
            else
            {
                frmTask.Activate();//已打开，获得焦点，置顶。
            }
              
        }

        #endregion

        #region 增加计划
        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmAddPlan addPlan = new FrmAddPlan();

            DialogResult r = addPlan.ShowDialog();

            if (r == DialogResult.OK)
            {
                string Msg = addPlan.Msg;
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, Msg);
            }
         

            GetPlanData(null);

        }
        #endregion


        #region 取消任务操作
        private void dgvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPlan.Columns[e.ColumnIndex].Name == "Cancel")
                {
                    int index = dgvPlan.CurrentRow.Index;
                    string Id = dgvPlan.CurrentRow.Cells["ID"].Value.ToString();
                    string Material_Name = dgvPlan.CurrentRow.Cells["Material_Name"].Value.ToString();
                    int Plan_Num = int.Parse(dgvPlan.CurrentRow.Cells["Plan_Num"].Value.ToString());
                    int Act_Num = int.Parse(dgvPlan.CurrentRow.Cells["Act_Num"].Value.ToString());
                    string sMessage = "是否取消名称为：" + Material_Name + "数量为"+ Plan_Num + "的任务？";
                    if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                    {
                        return;
                    }

                    EditListOut(Id);
                    GetPlanData(null);
                }

                }
            catch {


            }
        }

        #endregion

        #endregion

        #region 数据处理


        #region 加载库存表头
        private void SetStoreBinForm()
        {

            //panel5.Width = 680;
            Application.DoEvents();
            for (int i = 0; i < 13; i++)
            {
                Application.DoEvents();
                FrmStoreBin TempForm = new FrmStoreBin();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.BinNo = i + 1;//货道号
                TempForm.MaxBinNo = 13;//货道数量
                TempForm.TopLevel = false;


                TempForm.Parent = panel5;

                if (i == 0)
                {
                    TempForm.Height = 86;

                }
                else
                {
                    TempForm.Height = 43;
                    TempForm.Top = i * 43 + 43;
                }


                TempForm.Show();
                BinFormList.Insert(0, TempForm);
            }
            Application.DoEvents();
        }
        #endregion

        #region 加载库存数据
        private void GetStoreBinData(object o)
        {
            try
            {
                string SqlStr = "";
                Thread.Sleep(10);

                DataSet DBDataSet = new DataSet();
                SqlStr = string.Format(@" select * from IMOS_LO_BIN a
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Process_Code = '{3}'
                                          order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,BaseSystemInfo.CurrentProcessCode);
                DBDataSet = DataHelper.Fill(SqlStr);




                // 初始化
                OptionSetting.StoreBinDataList = new List<StoreBinData>();

                ////获取在库，在途数量

                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = DBDataSet.Tables[0].Rows[i];
                    int StoreBin = int.Parse(dr["Bin_No"].ToString());
                    StoreBinData StoreInfo = new StoreBinData();//
                    StoreInfo.Bin_ID = dr["Bin_ID"].ToString();
                    StoreInfo.BinNo = int.Parse(StoreBin.ToString());//货道名称
                    StoreInfo.Material_Code = dr["Material_Code"].ToString();//产品编码
                    StoreInfo.MaterialName = dr["Material_Name"].ToString();//产品名称
                    StoreInfo.TransitQty = int.Parse(dr["Transit_Qty"].ToString()); ;//货道在途
                    StoreInfo.ActualQty = int.Parse(dr["Actual_Qty"].ToString());//货道实际库存
                    StoreInfo.BinFlag = int.Parse(dr["Bin_Flag"].ToString());//货道状态
                    OptionSetting.StoreBinDataList.Add(StoreInfo);

                }


            }
            catch (Exception ex) {

            }
        }
        #endregion

        #region 加载计划
        private void GetPlanData(object o)
        {
            string SqlStr = string.Format(@" select top 12 ID,Material_Code,Material_Name,
                                           Plan_Num,Act_Num,CONVERT(varchar(100), Creation_Date, 108)  as Creation_Date,Flag=CASE WHEN Flag = 0
                                            THEN '未执行'
                                            WHEN Flag = 1
                                            THEN '执行中'
                                            WHEN Flag = 2
                                            THEN '取消'
                                            WHEN Flag = 3
                                            THEN '完成'
                                            ELSE ' ' END ,'取消Cancel' as Cancel  from IMOS_LIST_OUT     where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Workstation_No='{3}' and Flag <2   and Process_Code = '{4}'      ORDER BY   Creation_Date ",
                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.StationCode,BaseSystemInfo.CurrentProcessCode);

            DataSet ds = DataHelper.Fill(SqlStr);
            Action2<DataTable> a = new Action2<DataTable>(Actiondgv_mapping);
            Invoke(a, ds.Tables[0]);
           
        }

        public delegate void Action2<in T>(T t);
        public void Actiondgv_mapping(DataTable dt)
        {
            dgvPlan.DataSource = dt;
            dgvPlan.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlan.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPlan.ClearSelection();
        }


    #endregion


        #region 任务编辑
    private void EditListOut(string id)
        {
            try
            {
                string CheckStr = "";

                CheckStr = CheckStr + string.Format(@"Update IMOS_LIST_OUT Set Flag = {0}
                                                  Where ID = '{1}' ;", "2", id);
                CheckStr = CheckStr + string.Format(@"Update IMOS_BA_TRK Set Flag = {0}
                                                  Where LIST_ID = '{1}' and Flag !=2 ;", "1", id);
                DataHelper.Fill(CheckStr);
            }
            catch
            {

            }
            finally
            {

            }
        }
        #endregion

        #endregion



        private void dgvTask_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmBoxBodyStoreOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                RefreshDataTimer.Enabled = false;
                RefreshDataTimer.Stop();

              

                Thread.Sleep(5);
                if (RefreshDataTimer != null)
                {
                    RefreshDataTimer.Close();
                    RefreshDataTimer.Dispose();
                }
              
            }
            catch {


            }
        }
    }
}
