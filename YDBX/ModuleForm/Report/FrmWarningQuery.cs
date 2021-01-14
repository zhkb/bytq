using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport.Data;

namespace Report
{
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;

    public partial class FrmWarningQuery : Form
    {
        private DataSet MasterDataSet = null;
        private string sSQL4Print = "";
        public FrmWarningQuery()
        {
            InitializeComponent();
        }

        private void FrmWarningQuery_Load(object sender, EventArgs e)
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
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");
                
                return;
            }

            //初始化 序号列
            dgvWarning.TopLeftHeaderCell.Value = "序号";

        }
        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                btnQuery.Enabled = false;

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

                QueryWarningInfo(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                btnPrint.Enabled = MasterDataSet.Tables[0].Rows.Count > 0;
                
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("执行查询出错,"+ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "执行查询出错");

            }
            finally
            {
                btnQuery.Enabled = true;
            }
        }
        private void QueryWarningInfo(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [MachineID] 
                                            ,[MachineName] 
                                            ,[Descr] 
                                            ,CONVERT(varchar(100), [RecTime], 120) as RecTime 
                                            FROM [Mixing_Warning] 
                                            where CONVERT(varchar(100), [rectime], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [rectime], 120) <= '{1}' ", DownStartTime, DownEndTime);

                //托盘编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (MachineID like '%{0}%' or MachineName like '%{1}%' or Descr like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by RECTIME desc ";

                SqlStr += sOrder;

                MasterDataSet = null;

                MasterDataSet = DataHelper.Fill(SqlStr);

                
                if (MasterDataSet != null)
                {
                    MasterDataSet.Tables[0].TableName = "Mixing_Warning";

                    dgvWarning.DataSource = MasterDataSet.Tables[0];
                    //dgvWarning.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    //dgvWarning.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                }
                sSQL4Print = SqlStr;
            }
            catch (Exception ex)
            {
                sSQL4Print = "";
                SysBusinessFunction.WriteLog("查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询出错，请检查数据库连接状态");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterDataSet != null && MasterDataSet.Tables.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"warnreport.frx";
                    report.Load(filename);
                    TableDataSource table = report.GetDataSource("Mixing_Warning") as TableDataSource;
                    table.Table = MasterDataSet.Tables[0];
                    report.Show(true);
                }
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("报警信息打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警信息打印出错");

            }

        }
    }
}
