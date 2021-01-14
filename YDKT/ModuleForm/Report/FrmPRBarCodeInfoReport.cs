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
    public partial class FrmPRBarCodeInfoReport : Form
    {
        private DataSet MasterDataSet = null;
        public FrmPRBarCodeInfoReport()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPRBarCodeInfoReport_Load(object sender, EventArgs e)
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

                string StartTime = dt_StartDate.Text + " " + dt_StartTime.Text;
                string EndTime = dt_EndDate.Text + " " + dt_EndTime.Text;

                DateTime t1 = Convert.ToDateTime(StartTime);
                DateTime t2 = Convert.ToDateTime(EndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    MessageBox.Show("开始日期时间大于结束日期时间.", "错误");
                    return;
                }

                string sKey = txt_Key.Text.Trim();
                LoadData(StartTime, EndTime, sKey);//查询设置的起始日期之内的停机记录
            }
            catch (Exception ex)
            {


            }
            finally
            {
                btn_Select.Enabled = true;
            }
        }

        private void LoadData(string startTime, string endTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [Product_BarCode]
                                                  ,[Material_Code]
                                                  ,[Material_Name]
                                                  ,[Process_Name]
                                                  ,CONVERT(varchar(100), [Scan_Time], 120) as Scan_Time
                                              
                                               FROM [IMOS_PR_BarCode]
                                               where CONVERT(varchar(100), [Scan_Time], 120) >= '{0}'
                                               and CONVERT(varchar(100), [Scan_Time], 120) <= '{1}'  and Process_Code='{2}' ",
                                                  startTime, endTime, BaseSystemInfo.CurrentProcessCode);
                //物料编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Material_Code like '%{0}%'  or Material_Name like '%{1}%' or Product_BarCode like '%{2}%')", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Scan_Time desc ";

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

            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = MasterDataSet.Tables[0];
                if (table != null && table.Rows.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    report.Load(Application.StartupPath + @"\Report\Info_Report_scan.frx");
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
