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

    public partial class FrmPlanQuery : Form
    {
        private DataSet MasterDataSet_JB = null;
        private DataSet MasterDataSet_ZJ = null;
        private DataSet MasterDataSet_TG = null;

        public FrmPlanQuery()
        {
            InitializeComponent();
        }
        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void InitFrm_JB()
        {
            dt_StartTime_JB.CustomFormat = "HH:mm:ss";
            dt_EndTime_JB.CustomFormat = "HH:mm:ss";

            dt_StartTime_JB.Text = "00:00:01";
            dt_EndTime_JB.Text = "23:59:59";

            string PlanStartTime = dt_StartDate_JB.Text + " " + dt_StartTime_JB.Text;
            string PlanEndTime = dt_EndDate_JB.Text + " " + dt_EndTime_JB.Text;

            DateTime t1 = Convert.ToDateTime(PlanStartTime);
            DateTime t2 = Convert.ToDateTime(PlanEndTime);

            if (DateTime.Compare(t1, t2) > 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "搅拌计划-开始日期时间大于结束日期时间.");

                return;
            }

            //初始化 序号列
            dgvPlan_JB.TopLeftHeaderCell.Value = "序号";

        }

        private void InitFrm_ZJ()
        {
            dt_StartTime_ZJ.CustomFormat = "HH:mm:ss";
            dt_EndTime_ZJ.CustomFormat = "HH:mm:ss";

            dt_StartTime_ZJ.Text = "00:00:01";
            dt_EndTime_ZJ.Text = "23:59:59";

            string PlanStartTime = dt_StartDate_ZJ.Text + " " + dt_StartTime_ZJ.Text;
            string PlanEndTime = dt_EndDate_ZJ.Text + " " + dt_EndTime_ZJ.Text;

            DateTime t1 = Convert.ToDateTime(PlanStartTime);
            DateTime t2 = Convert.ToDateTime(PlanEndTime);

            if (DateTime.Compare(t1, t2) > 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "制胶计划-开始日期时间大于结束日期时间.");

                return;
            }

            //初始化 序号列
            dgvPlan_ZJ.TopLeftHeaderCell.Value = "序号";

        }

        private void InitFrm_TG()
        {
            dt_StartTime_TG.CustomFormat = "HH:mm:ss";
            dt_EndTime_TG.CustomFormat = "HH:mm:ss";

            dt_StartTime_TG.Text = "00:00:01";
            dt_EndTime_TG.Text = "23:59:59";

            string PlanStartTime = dt_StartDate_TG.Text + " " + dt_StartTime_TG.Text;
            string PlanEndTime = dt_EndDate_TG.Text + " " + dt_EndTime_TG.Text;

            DateTime t1 = Convert.ToDateTime(PlanStartTime);
            DateTime t2 = Convert.ToDateTime(PlanEndTime);

            if (DateTime.Compare(t1, t2) > 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划-开始日期时间大于结束日期时间.");

                return;
            }

            //初始化 序号列
            dgvPlan_TG.TopLeftHeaderCell.Value = "序号";

        }

        private void FrmPlanQuery_Load(object sender, EventArgs e)
        {
            try
            {
                InitFrm_JB();
                InitFrm_ZJ();
                InitFrm_TG();
            }
            catch (Exception ex)
            {

            }
        }     

        private void QueryPlanInfo_JB(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [Equipment_Code] 
                                            ,[Equipment_Name] 
                                            ,[Alarm_Desc] 
                                            ,CONVERT(varchar(100), [Create_Time], 120) as Create_Time 
                                            FROM [Mixing_Alarm] 
                                            where CONVERT(varchar(100), [Create_Time], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Create_Time], 120) <= '{1}' ", DownStartTime, DownEndTime);

                //托盘编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Equipment_Code like '%{0}%' or Equipment_Name like '%{1}%' or Alarm_Desc like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Create_Time desc ";

                SqlStr += sOrder;

                MasterDataSet_JB = null;

                MasterDataSet_JB = DataHelper.Fill(SqlStr);

                if (MasterDataSet_JB != null)
                {
                    MasterDataSet_JB.Tables[0].TableName = "Mixing_Alarm";

                    dgvPlan_JB.DataSource = MasterDataSet_JB.Tables[0];
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("搅拌计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "搅拌计划查询出错，请检查数据库连接状态");
            }
        }
        private void QueryPlanInfo_ZJ(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [Equipment_Code] 
                                            ,[Equipment_Name] 
                                            ,[Alarm_Desc] 
                                            ,CONVERT(varchar(100), [Create_Time], 120) as Create_Time 
                                            FROM [Mixing_Alarm] 
                                            where CONVERT(varchar(100), [Create_Time], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Create_Time], 120) <= '{1}' ", DownStartTime, DownEndTime);

                //托盘编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Equipment_Code like '%{0}%' or Equipment_Name like '%{1}%' or Alarm_Desc like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Create_Time desc ";

                SqlStr += sOrder;

                MasterDataSet_ZJ = null;

                MasterDataSet_ZJ = DataHelper.Fill(SqlStr);

                if (MasterDataSet_ZJ != null)
                {
                    MasterDataSet_ZJ.Tables[0].TableName = "Mixing_Alarm";

                    dgvPlan_ZJ.DataSource = MasterDataSet_ZJ.Tables[0];
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("制胶计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "制胶计划查询出错，请检查数据库连接状态");
            }
        }

        private void QueryPlanInfo_TG(string DownStartTime, string DownEndTime, string sKey)
        {
            /*
SELECT [Plan_No]
      ,[Recipe_Code]
      ,[Recipe_Name]
      ,[Plan_Qty]
      ,[Actual_Qty]
      ,[Plan_Date]
  FROM [Mixing_Plan] where [Plan_Type] = {0}             
             */
            try
            {
                string SqlStr = string.Format(@"SELECT [Plan_No] 
                                            ,[Recipe_Code] 
                                            ,[Recipe_Name] 
                                            ,[Plan_Qty]
                                            ,[Actual_Qty]
                                            ,CONVERT(varchar(100), [Plan_Date], 120) as Plan_Date 
                                            FROM [Mixing_Plan] 
                                            where CONVERT(varchar(100), [Plan_Date], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Plan_Date], 120) <= '{1}' and [Plan_Type] = {2}", DownStartTime, DownEndTime, (int)PlanType.TG);

                //查询关键词
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Plan_No like '%{0}%' or Recipe_Code like '%{1}%' or Recipe_Name like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Plan_Date desc ";

                SqlStr += sOrder;

                MasterDataSet_TG = null;

                MasterDataSet_TG = DataHelper.Fill(SqlStr);

                if (MasterDataSet_TG != null)
                {
                    MasterDataSet_TG.Tables[0].TableName = "Mixing_Alarm";

                    dgvPlan_TG.DataSource = MasterDataSet_TG.Tables[0];
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("陶罐计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划查询出错，请检查数据库连接状态");
            }
        }

        private void btnQuery_JB_Click(object sender, EventArgs e)
        {
            try
            {
                btnQuery_JB.Enabled = false;

                string PlanStartTime = dt_StartDate_JB.Text + " " + dt_StartTime_JB.Text;
                string PlanEndTime = dt_EndDate_JB.Text + " " + dt_EndTime_JB.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");
                    return;
                }

                string sKey = tbKey_JB.Text.Trim();

                QueryPlanInfo_JB(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                btnPrint_JB.Enabled = MasterDataSet_JB.Tables[0].Rows.Count > 0;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("执行查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "执行查询出错");

            }
            finally
            {
                btnQuery_JB.Enabled = true;
            }

        }

        private void btnPrint_JB_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterDataSet_JB != null && MasterDataSet_JB.Tables.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"warnreport.frx";
                    report.Load(filename);
                    TableDataSource table = report.GetDataSource("Mixing_Alarm") as TableDataSource;
                    table.Table = MasterDataSet_JB.Tables[0];
                    report.Show(true);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("搅拌计划打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "搅拌计划打印出错");
            }

        }

        private void btnQuery_ZJ_Click(object sender, EventArgs e)
        {
            try
            {
                btnQuery_ZJ.Enabled = false;

                string PlanStartTime = dt_StartDate_ZJ.Text + " " + dt_StartTime_ZJ.Text;
                string PlanEndTime = dt_EndDate_ZJ.Text + " " + dt_EndTime_ZJ.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");
                    return;
                }

                string sKey = tbKey_ZJ.Text.Trim();

                QueryPlanInfo_ZJ(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                btnPrint_ZJ.Enabled = MasterDataSet_ZJ.Tables[0].Rows.Count > 0;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("制胶计划执行查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "制胶计划执行查询出错");
            }
            finally
            {
                btnQuery_ZJ.Enabled = true;
            }

        }

        private void btnPrint_ZJ_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterDataSet_ZJ != null && MasterDataSet_ZJ.Tables.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"warnreport.frx";
                    report.Load(filename);
                    TableDataSource table = report.GetDataSource("Mixing_Alarm") as TableDataSource;
                    table.Table = MasterDataSet_ZJ.Tables[0];
                    report.Show(true);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("制胶计划打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "制胶计划打印出错");
            }

        }

        private void btnQuery_TG_Click(object sender, EventArgs e)
        {
            try
            {
                btnQuery_TG.Enabled = false;

                string PlanStartTime = dt_StartDate_TG.Text + " " + dt_StartTime_TG.Text;
                string PlanEndTime = dt_EndDate_TG.Text + " " + dt_EndTime_TG.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划开始日期时间大于结束日期时间.");
                    return;
                }

                string sKey = tbKey_TG.Text.Trim();

                QueryPlanInfo_TG(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                btnPrint_TG.Enabled = MasterDataSet_TG.Tables[0].Rows.Count > 0;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("陶罐计划执行查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划执行查询出错");
            }
            finally
            {
                btnQuery_TG.Enabled = true;
            }

        }
    }

    public enum PlanType
    {
        JB = 1,
        ZJ = 2,
        TG = 3
    }

}
