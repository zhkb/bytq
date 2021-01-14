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

    public partial class FrmAlarmQuery : Form
    {
        private DataSet MasterDataSet = null;

        public FrmAlarmQuery()
        {
            InitializeComponent();
        }

        private void FrmWarningQuery_Load(object sender, EventArgs e)
        {
            dgvWarning.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvWarning.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

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
        private void QueryWarningInfo(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [Equipment_Code] 
                                            ,[Equipment_Name] 
                                            ,[Alarm_Desc] 
                                            ,CONVERT(varchar(100), [Create_Time], 120) as Create_Time 
                                            FROM [Mixing_Alarm] 
                                            where CONVERT(varchar(100), [Create_Time], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Create_Time], 120) <= '{1}' 
                                            and Company_Code = '{2}' and Factory_Code = '{3}' and ProductLine_Code = '{4}'", 
                                            DownStartTime, DownEndTime, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                //托盘编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Equipment_Code like '%{0}%' or Equipment_Name like '%{1}%' or Alarm_Desc like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Create_Time desc ";

                SqlStr += sOrder;

                MasterDataSet = null;

                MasterDataSet = DataHelper.Fill(SqlStr);
                
                if (MasterDataSet != null)
                {
                    MasterDataSet.Tables[0].TableName = "Mixing_Alarm";

                    dgvWarning.DataSource = MasterDataSet.Tables[0];
                    dgvWarning.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    dgvWarning.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("报警信息查询异常," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警信息查询异常");
            }
        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
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

                QueryWarningInfo(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
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

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterDataSet != null && MasterDataSet.Tables.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"warnreport.frx";
                    report.Load(filename);
                    report.Dictionary.Connections[0].ConnectionString = BaseSystemInfo.BusinessDbConnection;

                    TableDataSource table = report.GetDataSource("Mixing_Alarm") as TableDataSource;
                    table.Table = MasterDataSet.Tables[0];
                    report.Show(true);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("报警信息打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警信息打印出错");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAlarmQuery_Activated(object sender, EventArgs e)
        {
            OptionSetting.MenuTitle = "报警记录";
        }
    }
}
