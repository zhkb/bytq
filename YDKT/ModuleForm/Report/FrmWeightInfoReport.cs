using Sys.Config;
using FastReport;
using Sys.DbUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.SysBusiness;

namespace Report
{
    public partial class FrmWeightInfoReport : Form
    {
        private DataSet MasterDataSet = null;
        public FrmWeightInfoReport()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmWeightInfoReport_Load(object sender, EventArgs e)
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
                //SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");
                MessageBox.Show("开始日期时间大于结束日期时间.", "错误");
                return;
            }

            //初始化 序号列
            dgv_weightinfo.TopLeftHeaderCell.Value = "序号";
            
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {

                btn_Select.Enabled = false;

                string PlanStartTime = dt_StartDate.Text + " " + dt_StartTime.Text;
                string PlanEndTime = dt_EndDate.Text + " " + dt_EndTime.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    MessageBox.Show("开始日期时间大于结束日期时间.", "错误");
                    return;
                }

                string sKey = txt_Key.Text.Trim();

                QueryCombinCode(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                //btn_Print.Enabled = MasterDataSet.Tables[0].Rows.Count > 0;
               
            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog(ex.ToString());
            }
            finally
            {
                btn_Select.Enabled = true;
            }
        }

        private void QueryCombinCode(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [Product_BarCode]
                                                  ,[Material_Code]
                                                  ,[Material_Name]
                                                  ,[Station_No]
                                                  ,[Standard_Value]
                                                  ,[Standard_Error]
                                                  ,[Before_Value]
                                                  ,[After_Value]
                                                  ,[Error_Value]
                                                  ,CONVERT(varchar(100), [Scan_Time_Before], 120) as Scan_Time_Before
                                                  ,CONVERT(varchar(100), [Scan_Time_After], 120) as Scan_Time_After                                                
                                                  ,   CASE Check_Result 
                                                      WHEN 1 THEN '合格' 
                                                      WHEN 2 THEN '不合格' 
                                                      ELSE '' 
                                                      END as Check_Result                                                   
                                               FROM [IMOS_PR_Weigh]
                                               where CONVERT(varchar(100), [Scan_Time_Before], 120) >= '{0}'
                                               and CONVERT(varchar(100), [Scan_Time_Before], 120) <= '{1}'  ",
                                                  DownStartTime, DownEndTime);
                //物料编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Material_Code like '%{0}%'  or Material_Name like '%{1}%' or Product_BarCode like '%{2}%')", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Scan_Time_Before desc ";

                SqlStr += sOrder;

                MasterDataSet = null;

                MasterDataSet = DataHelper.Fill(SqlStr);
                if (MasterDataSet != null)
                {
                    dgv_weightinfo.DataSource = MasterDataSet.Tables[0];
                    dgv_weightinfo.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    dgv_weightinfo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                   
                }

               
            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog("查询设置的起始日期之内的停机记录失败." + ex.ToString());
                //SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

        private void dgv_weightinfo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = MasterDataSet.Tables[0];
                if (table != null && table.Rows.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    report.Load(Application.StartupPath + @"\Report\Info_Report_weight.frx");
                    report.RegisterData(table, "MainInfo");
                    DataBand data = report.FindObject("Data1") as DataBand;
                    data.DataSource = report.GetDataSource("MainInfo");
                    report.PrintSettings.Copies = 1;
                    report.PrintSettings.ShowDialog = false;
                    report.Prepare();
                    report.Show();
                    //report.Print();//直接进行打印
                    report.Dispose();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("称重信息打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "称重信息打印出错");
            }
        }
    }
}
