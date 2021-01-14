using FastReport;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report
{
    public partial class FrmQualityCheckReport : Form
    {
        private DataSet Resultds = new DataSet();
        private DataSet Itemds = new DataSet();
        private DataSet Detailds = new DataSet();
        public FrmQualityCheckReport()
        {
            InitializeComponent();
            dgv_CheckItem_Report.TopLeftHeaderCell.Value = "序号";
            dgv_CheckItem.TopLeftHeaderCell.Value = "序号";
            dgv_CheckDetail.TopLeftHeaderCell.Value = "序号";
        }

        #region 界面加载
        private void FrmQualityCheckMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                dt_StartTime.CustomFormat = "HH:mm:ss";
                dt_EndTime.CustomFormat = "HH:mm:ss";

                dt_StartTime.Text = "00:00:01";
                dt_EndTime.Text = "23:59:59";

                string PlanStartTime = dt_StartDate.Text + " " + dt_StartTime.Text;
                string PlanEndTime = dt_EndDate.Text + " " + dt_EndTime.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    MessageBox.Show("开始日期时间大于结束日期时间.", "错误");
                    return;
                }

                GetQualityReport(txt_Product_BarCode.Text.ToString().Trim(), t1.ToString("yyyy-MM-dd HH:mm:ss"), t2.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 获取质检主表报表
        private void GetQualityReport(string barcode, string starttime, string endtime)
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            GUID,
	                                            Product_BarCode,
	                                            Material_Code,
	                                            Created_By,
	                                            CONVERT (
		                                            VARCHAR (50),
		                                            Creation_Date,
		                                            120
	                                            ) Creation_Date,
	                                            (CASE WHEN Check_Result = 1 THEN
	                                            'OK'
                                            ELSE
	                                            'NG'
                                            END) Check_Result
                                            FROM
	                                            IMOS_PR_QualityCheck
                                            WHERE
                                               Product_BarCode like '%{0}%'
                                            and CONVERT(varchar(100), [Creation_Date], 120) >= '{1}'
                                            and CONVERT(varchar(100), [Creation_Date], 120) <= '{2}'
                                            Order By Creation_Date Desc",
                                            barcode, starttime, endtime);
                Resultds = DataHelper.Fill(sql);
                if (Resultds == null)
                {
                    return;
                }
                dgv_CheckItem_Report.DataSource = Resultds.Tables[0];
                dgv_CheckItem_Report.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_CheckItem_Report.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                GetItemList();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region DataGridView排序
        private void dgv_CheckItem_Report_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void dgv_CheckItem_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_CheckDetail_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        #endregion

        #region 查找按钮事件
        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                string PlanStartTime = dt_StartDate.Text + " " + dt_StartTime.Text;
                string PlanEndTime = dt_EndDate.Text + " " + dt_EndTime.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    MessageBox.Show("开始日期时间大于结束日期时间.", "错误");
                    return;
                }

                GetQualityReport(txt_Product_BarCode.Text.ToString().Trim(), t1.ToString("yyyy-MM-dd HH:mm:ss"), t2.ToString("yyyy-MM-dd HH:mm:ss"));

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 获取质检项
        private void GetItemList()
        {
            try
            {
                if (dgv_CheckItem_Report.SelectedRows.Count != 1)
                {
                    return;
                }
                String sql = String.Format(@"SELECT
                                                a.GUID,
	                                            a.Product_BarCode,
	                                            b.Check_Item_Code,
	                                            b.Check_Item_Name
                                            FROM
	                                            IMOS_PR_QualityCheck_Detail a
                                            LEFT JOIN IMOS_PR_QualityItem_Master b ON a.Check_Item_Code = b.Check_Item_Code
                                            WHERE
	                                            a.GUID = '{0}'
                                            GROUP BY b.Check_Item_Code,a.Product_BarCode,b.Check_Item_Name,a.GUID", dgv_CheckItem_Report.SelectedRows[0].Cells["GUID"].Value.ToString().Trim());
                Itemds = DataHelper.Fill(sql);
                if (Itemds == null)
                {
                    return;
                }
                dgv_CheckItem.DataSource = Itemds.Tables[0];
                dgv_CheckItem.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_CheckItem.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                GetDetailList();
            }
            catch (Exception ex)
            {

            }
        }

        private void GetDetailList()
        {
            try
            {
                if (dgv_CheckItem.Rows.Count == 0)
                {
                    DataTable table = (DataTable)dgv_CheckDetail.DataSource;
                    table.Clear();
                    dgv_CheckDetail.DataSource = table;
                    return;
                }
                else
                {
                    if (dgv_CheckItem.SelectedRows.Count != 1)
                    {
                        return;
                    }

                    String sql = String.Format(@"SELECT
                                                Check_Item_Detail_Code,
                                                Check_Item_Detail_Name,
                                                Convert(varchar(50),Create_Time,120) Create_Time,
                                                Create_By
                                            FROM
	                                            IMOS_PR_QualityCheck_Detail 
                                            WHERE
	                                            GUID = '{0}' and Check_Item_Code = '{1}'",
                                               dgv_CheckItem.SelectedRows[0].Cells["DGUID"].Value.ToString().Trim(),
                                               dgv_CheckItem.SelectedRows[0].Cells["Check_Item_Code"].Value.ToString().Trim());
                    Detailds = DataHelper.Fill(sql);
                    if (Detailds == null)
                    {
                        return;
                    }
                    dgv_CheckDetail.DataSource = Detailds.Tables[0];
                    dgv_CheckDetail.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    dgv_CheckDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 点击DataGridView事件

        // 主表选择项改变事件
        private void dgv_CheckItem_Report_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                GetItemList();
                GetDetailList();
            }
            catch (Exception ex)
            {

            }
        }

        // 质检项选择改变事件
        private void dgv_CheckItem_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                GetDetailList();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 关闭按钮事件
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 打印按钮事件
        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = Resultds.Tables[0];
                if (table != null && table.Rows.Count > 0 )
                {
                    FastReport.Report report = new FastReport.Report();
                    report.Load(Application.StartupPath + @"\Report\Info_Quality_Report.frx");
                    report.RegisterData(table, "Quality_Master");
                    DataBand data = report.FindObject("Data1") as DataBand;
                    data.DataSource = report.GetDataSource("Quality_Master");
                    //report.PrintSettings.Copies = 1;
                    //report.PrintSettings.ShowDialog = false;
                    report.Prepare();
                    report.Show();
                    report.Dispose();
                }
            } catch (Exception ex)
            {

            }
        }
        #endregion

        #region 结果刷新效果
        private void dgv_CheckItem_Report_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for(int i = 0; i <dgv_CheckItem_Report.Rows.Count; i++)
                {
                    if ("OK".Equals(dgv_CheckItem_Report.Rows[i].Cells["Check_Result"].Value.ToString()))
                    {
                        dgv_CheckItem_Report.Rows[i].Cells["Check_Result"].Style.ForeColor = Color.Lime;
                    }else
                    {
                        dgv_CheckItem_Report.Rows[i].Cells["Check_Result"].Style.ForeColor = Color.Red;
                    }
                }
            }catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
