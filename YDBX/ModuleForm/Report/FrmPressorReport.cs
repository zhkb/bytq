using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using Sys.DbUtilities;
using Sys.SysBusiness;
using Sys.Config;

namespace Report
{
    public partial class FrmPressorReport : Form
    {
        private DataSet MasterDataSet = null;
        private string processcode = "";
        public FrmPressorReport()
        {
            InitializeComponent();
        }

        private void FrmCompressorQuery_Load(object sender, EventArgs e)
        {
            dgvCompressor.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvCompressor.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

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
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");

                return;
            }


            //初始化 序号列
            dgvCompressor.TopLeftHeaderCell.Value = "序号";


            comboBox1.SelectedItem = "All Line";

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.Equals("All Line"))
                {
                    processcode = "";
                }
                else if (comboBox1.SelectedItem.Equals("Line A"))
                {
                    processcode = "1030";
                }
                if (comboBox1.SelectedItem.Equals("Line B"))
                {
                    processcode = "1031";
                }
                btn_Search.Enabled = false;

                string PlanStartTime = dt_StartDate.Text + " " + dt_StartTime.Text;
                string PlanEndTime = dt_EndDate.Text + " " + dt_EndTime.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");
                    return;
                }

                string sKey = tbKey.Text.Trim();

                QueryCompressorInfo(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                btn_Print.Enabled = MasterDataSet.Tables[0].Rows.Count > 0;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("查询数据异常," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询数据异常");

            }
            finally
            {
                btn_Search.Enabled = true;
            }
        }

        private void QueryCompressorInfo(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT Product_BarCode, Product_Name, Compressor_BarCode, Compressor_Name,CONVERT(varchar(100), [Create_Time], 120) Create_Time,
                                                 CASE WHEN(Match_flag = 2) THEN 'NG' WHEN(Match_flag = 1) THEN 'OK' ELSE 'NG' END AS Match_flag
                                                 FROM  IMOS_TA_ProPre_Record
                                                 where CONVERT(varchar(100), [Create_Time], 120) >= '{0}' 
                                                 and CONVERT(varchar(100), [Create_Time], 120) <= '{1}' 
                                                 and Company_Code = '{2}' and Factory_Code = '{3}' and Product_Line_Code = '{4}'and Process_Code like '%{5}%'",
                                                 DownStartTime, DownEndTime, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,processcode);

                //关键词查询
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Product_BarCode like '%{0}%' or Product_Name like '%{0}%' or Compressor_BarCode like '%{0}%' or Compressor_Name like '%{0}%') ", sKey);
                }
                //时间倒序排序
                string sOrder = " order by Create_Time desc ";

                SqlStr += sOrder;

                MasterDataSet = null;

                MasterDataSet = DataHelper.Fill(SqlStr);

                if (MasterDataSet != null)
                {
                    dgvCompressor.DataSource = MasterDataSet.Tables[0];
                    dgvCompressor.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    dgvCompressor.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("压缩机信息查询异常," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "压缩机信息查询异常");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPressorReport_Activated(object sender, EventArgs e)
        {
            OptionSetting.MenuTitle = "压缩机追溯";
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = MasterDataSet.Tables[0];
                if (table != null && table.Rows.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    report.Load(Application.StartupPath + @"\Report\Info_Report_compressor.frx");
                    report.RegisterData(table, "IMOS_TA_ProPre_Record");
                    DataBand data = report.FindObject("Data1") as DataBand;
                    data.DataSource = report.GetDataSource("IMOS_TA_ProPre_Record");
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
                SysBusinessFunction.WriteLog("压缩机信息打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "压缩机信息打印出错");
            }
        }

        private void dgvCompressor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for(int i = 0; i < dgvCompressor.Rows.Count; i++)
            {
                dgvCompressor.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvCompressor.Rows[i].HeaderCell.Value = string.Format("{0}", dgvCompressor.Rows[i].Index + 1);
            }

        }
    }
}
