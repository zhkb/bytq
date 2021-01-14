using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Monitor
{
    using Sys.DbUtilities;
    public partial class FrmStoreMonitor : Form
    {
        private delegate void ThreadWork(object o);
        public static System.Threading.Timer RefreshDataTimer; //刷新界面数据

        public FrmStoreMonitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet DbDataSet = new DataSet();
                string sql = string.Format(@"Select Bin_No,Material_Code,Material_Name,
                                                Case when ISNULL(Bin_UseFlag,1) =1 then '正常' else '禁用' end Use_FlagName,
                                                Case when ISNULL(Bin_InFlag,1) =1 then '正常' else '禁用' end In_FlagName,
                                                Case when ISNULL(Bin_OutFlag,1) =1 then '正常' else '禁用' end Out_FlagName,
                                                Case when ISNULL(Bin_AbnormalFlag,1) =1 then '正常' else '禁用' end Abnormal_FlagName,
                                                Bin_InFlag,Bin_UseFlag,Bin_OutFlag,Bin_AbnormalFlag,Max_Qty,Store_Qty,
                                                Cast(Convert(decimal(8,2),(Case when ISNULL(Max_Qty,0) =0 then 0 else 100.0*ISNULL(Store_Qty,0)/ISNULL(Max_Qty,0) end),2) as varchar(20)) + '%' Store_Rate
                                                from IMOS_LO_Bin");
                DbDataSet = DataHelper.Fill(sql);

                dgv_Store.DataSource = DbDataSet.Tables[0];

            }
            catch
            {

            }
        }

        private void dgv_Store_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // return;
            dgv_Store.Rows[e.RowIndex].Cells["Use_FlagName"].Style.ForeColor = Color.Black;
            dgv_Store.Rows[e.RowIndex].Cells["In_FlagName"].Style.ForeColor = Color.Black;
            dgv_Store.Rows[e.RowIndex].Cells["Out_FlagName"].Style.ForeColor = Color.Black;
            dgv_Store.Rows[e.RowIndex].Cells["Abnormal_FlagName"].Style.ForeColor = Color.Black;

            if (dgv_Store.Rows[e.RowIndex].Cells["Bin_UseFlag"].Value.ToString() == "1")
            {
                dgv_Store.Rows[e.RowIndex].Cells["Use_FlagName"].Style.BackColor = Color.Lime;// dgv_Store.Rows[e.RowIndex].Cells["Bin_No"].Style.BackColor;
            }
            else
            {
                dgv_Store.Rows[e.RowIndex].Cells["Use_FlagName"].Style.BackColor = Color.Red;
            }

            if (dgv_Store.Rows[e.RowIndex].Cells["Bin_InFlag"].Value.ToString() == "1")
            {
                dgv_Store.Rows[e.RowIndex].Cells["In_FlagName"].Style.BackColor = Color.Lime;//dgv_Store.Rows[e.RowIndex].Cells["In_FlagName"].Style.BackColor;

            }
            else
            {
                dgv_Store.Rows[e.RowIndex].Cells["In_FlagName"].Style.BackColor = Color.Red;
            }


            if (dgv_Store.Rows[e.RowIndex].Cells["Bin_OutFlag"].Value.ToString() == "1")
            {
                dgv_Store.Rows[e.RowIndex].Cells["Out_FlagName"].Style.BackColor = Color.Lime;//dgv_Store.Rows[e.RowIndex].Cells["Bin_No"].Style.BackColor;
            }
            else
            {
                dgv_Store.Rows[e.RowIndex].Cells["Out_FlagName"].Style.BackColor = Color.Red;
            }

            if (dgv_Store.Rows[e.RowIndex].Cells["Bin_AbnormalFlag"].Value.ToString() == "0")
            {
                dgv_Store.Rows[e.RowIndex].Cells["Abnormal_FlagName"].Style.BackColor = Color.Lime;// dgv_Store.Rows[e.RowIndex].Cells["Bin_No"].Style.BackColor;
            }
            else
            {
                dgv_Store.Rows[e.RowIndex].Cells["Abnormal_FlagName"].Style.BackColor = Color.Red;
            }
        }

        private void FrmStoreMonitor_Load(object sender, EventArgs e)
        {
            RefreshDataTimer = new System.Threading.Timer(RefreshDataEvent, null, 0, Timeout.Infinite);
        }

        private void RefreshDataEvent(object sender)// 
        {
            try
            {
                Invoke(new ThreadWork(GetStoreData), sender); //利用委托方式进行界面控件数据刷新
            }
            catch
            {
            }
            finally
            {
                RefreshDataTimer.Change(10000, Timeout.Infinite); //5 秒刷新一次 该刷新为上次刷新执行完毕后5秒再执行刷新
            }
        }

        public void GetStoreData(Object source) //刷新界面数据
        {
            try
            {
                DataSet DbDataSet = new DataSet();
                string sql = string.Format(@"Select Bin_No,Material_Code,Material_Name,
                                                Case when ISNULL(Bin_UseFlag,1) =1 then '正常' else '禁用' end Use_FlagName,
                                                Case when ISNULL(Bin_InFlag,1) =1 then '正常' else '禁用' end In_FlagName,
                                                Case when ISNULL(Bin_OutFlag,1) =1 then '正常' else '禁用' end Out_FlagName,
                                                Case when ISNULL(Bin_AbnormalFlag,1) =1 then '正常' else '禁用' end Abnormal_FlagName,
                                                Bin_InFlag,Bin_UseFlag,Bin_OutFlag,Bin_AbnormalFlag,Max_Qty,Store_Qty,
                                                Cast(Convert(decimal(8,2),(Case when ISNULL(Max_Qty,0) =0 then 0 else 100.0*ISNULL(Store_Qty,0)/ISNULL(Max_Qty,0) end),2) as varchar(20)) + '%' Store_Rate
                                                from IMOS_LO_Bin");
                DbDataSet = DataHelper.Fill(sql);

                dgv_Store.DataSource = DbDataSet.Tables[0];
            }
            catch (Exception ex)
            {
            }


        }
    }

}