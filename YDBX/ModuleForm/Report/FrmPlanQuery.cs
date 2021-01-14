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

        private bool bInit_JB = false;
        private bool bInit_ZJ = false;
        private bool bInit_TG = false;

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
            InitDateTimePicker();

            dgvPlan_JB.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlan_JB.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPlanDetail_JB.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlanDetail_JB.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPlan_ZJ.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlan_ZJ.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPlanDetail_ZJ.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlanDetail_ZJ.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPlan_TG.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlan_TG.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPlanDetail_TG.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlanDetail_TG.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        private void QueryPlanInfo_JB(string DownStartTime, string DownEndTime, string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT [Plan_No] 
                                            ,[Recipe_Code] 
                                            ,[Recipe_Name] 
                                            ,[Plan_Qty] 
                                            ,[Actual_Qty] 
                                            ,Plan_Status=CASE WHEN Plan_Status = 0
                                            THEN '未执行'
                                            WHEN Plan_Status = 1
                                            THEN '执行中'
                                            WHEN Plan_Status = 2
                                            THEN '完成'
                                            WHEN Plan_Status = 3
                                            THEN '取消'
                                            ELSE ' ' END 
                                            ,CONVERT(varchar(100), [Plan_Date], 120) as Plan_Date 
                                            FROM [Mixing_Plan] 
                                            where CONVERT(varchar(100), [Plan_Date], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Plan_Date], 120) <= '{1}' 
                                            and Plan_Type = {2} 
                                            and Company_Code = '{3}' and Factory_Code = '{4}' and ProductLine_Code = '{5}'",
                                            DownStartTime, DownEndTime, OptionSetting.StirPlanType, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                //托盘编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Plan_No like '%{0}%' or Recipe_Code like '%{1}%' or Recipe_Name like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Plan_Date desc ";

                SqlStr += sOrder;

                MasterDataSet_JB = null;

                MasterDataSet_JB = DataHelper.Fill(SqlStr);

                if (MasterDataSet_JB != null)
                {
                    MasterDataSet_JB.Tables[0].TableName = "Mixing_Alarm";

                    dgvPlan_JB.DataSource = MasterDataSet_JB.Tables[0];
                    //dgvPlan_JB.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    //dgvPlan_JB.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                    if (MasterDataSet_JB.Tables[0].Rows.Count == 1)
                    {
                        string sPlanNo = MasterDataSet_JB.Tables[0].Rows[0]["Plan_No"].ToString();
                        QueryPlanWeight_JB(sPlanNo);
                    }
                    else
                    {
                        ClearDGV(dgvPlanDetail_JB);
                    }

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
                string SqlStr = string.Format(@"SELECT [Plan_No] 
                                            ,[Recipe_Code] 
                                            ,[Recipe_Name] 
                                            ,[Plan_Qty] 
                                            ,[Actual_Qty] 
                                            ,Plan_Status=CASE WHEN Plan_Status = 0
                                            THEN '未执行'
                                            WHEN Plan_Status = 1
                                            THEN '执行中'
                                            WHEN Plan_Status = 2
                                            THEN '完成'
                                            WHEN Plan_Status = 3
                                            THEN '取消'
                                            ELSE ' ' END 
                                            ,CONVERT(varchar(100), [Plan_Date], 120) as Plan_Date 
                                            FROM [Mixing_Plan] 
                                            where CONVERT(varchar(100), [Plan_Date], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Plan_Date], 120) <= '{1}' 
                                            and Plan_Type = {2}
                                            and Company_Code = '{3}' and Factory_Code = '{4}' and ProductLine_Code = '{5}'",
                                            DownStartTime, DownEndTime, OptionSetting.RubPlanType, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                //托盘编码
                if (sKey.Length > 0)
                {
                    SqlStr += string.Format(" and (Plan_No like '%{0}%' or Recipe_Code like '%{1}%' or Recipe_Name like '%{2}%') ", sKey, sKey, sKey);
                }
                //倒序排序
                string sOrder = " order by Plan_Date desc ";

                SqlStr += sOrder;

                MasterDataSet_ZJ = null;

                MasterDataSet_ZJ = DataHelper.Fill(SqlStr);

                if (MasterDataSet_ZJ != null)
                {
                    MasterDataSet_ZJ.Tables[0].TableName = "Mixing_Alarm";

                    dgvPlan_ZJ.DataSource = MasterDataSet_ZJ.Tables[0];
                    //dgvPlan_ZJ.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    //dgvPlan_ZJ.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                    if (MasterDataSet_ZJ.Tables[0].Rows.Count == 1)
                    {
                        string sPlanNo = MasterDataSet_ZJ.Tables[0].Rows[0]["Plan_No"].ToString();
                        QueryPlanWeight_ZJ(sPlanNo);
                    }
                    else
                    {
                        ClearDGV(dgvPlanDetail_ZJ);
                    }

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
            try
            {
                string SqlStr = string.Format(@"SELECT [Plan_No] 
                                            ,[Recipe_Code] 
                                            ,[Recipe_Name] 
                                            ,[Plan_Qty]
                                            ,[Actual_Qty]
                                            ,Plan_Status=CASE WHEN Plan_Status = 0
                                            THEN '未执行'
                                            WHEN Plan_Status = 1
                                            THEN '执行中'
                                            WHEN Plan_Status = 2
                                            THEN '完成'
                                            WHEN Plan_Status = 3
                                            THEN '取消'
                                            ELSE ' ' END 
                                            ,CONVERT(varchar(100), [Plan_Date], 120) as Plan_Date 
                                            FROM [Mixing_Plan] 
                                            where CONVERT(varchar(100), [Plan_Date], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Plan_Date], 120) <= '{1}' 
                                            and [Plan_Type] = {2}
                                            and Company_Code = '{3}' and Factory_Code = '{4}' and ProductLine_Code = '{5}'",
                                            DownStartTime, DownEndTime, OptionSetting.TGPlanType, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

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
                    //dgvPlan_TG.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    //dgvPlan_TG.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                    if (MasterDataSet_TG.Tables[0].Rows.Count == 1)
                    {
                        string sPlanNo = MasterDataSet_TG.Tables[0].Rows[0]["Plan_No"].ToString();
                        QueryPlanWeight_TG(sPlanNo);
                    }
                    else
                    {
                        ClearDGV(dgvPlanDetail_TG);
                    }

                }



            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("陶罐计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划查询出错，请检查数据库连接状态");
            }
        }

        private void InitDateTimePicker()
        {
            if (this.tabControl_PlanQuery.SelectedTab.Name == "tabPage_ZJ")
            {
                if (bInit_ZJ == false)
                {
                    InitFrm_ZJ();
                    bInit_ZJ = true;
                }
            }
            else if (this.tabControl_PlanQuery.SelectedTab.Name == "tabPage_TG")
            {
                if (bInit_TG == false)
                {
                    InitFrm_TG();
                    bInit_TG = true;
                }
            }
            else if (this.tabControl_PlanQuery.SelectedTab.Name == "tabPage_JB")
            {
                if (bInit_JB == false)
                {
                    InitFrm_JB();
                    bInit_JB = true;
                }
            }

        }

        private void tabControl_PlanQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDateTimePicker();
        }

        private void ClearDGV(DataGridView dgv)
        {
            DataTable dt = (DataTable)dgv.DataSource;
            if (dt != null)
            {
                dt.Rows.Clear();
                dgv.DataSource = dt;
            }
        }

        private void QueryPlanWeight_TG(string sPlanNo)
        {
            string sSQL = string.Format(@"SELECT [Serial_No]
                                        ,[Ingredients_Code]
                                        ,[Ingredients_Name]
                                        ,[Ingredients_Weight]
                                        ,[Ingredients_Error]
                                        ,CONVERT(varchar(100), [Ingredients_Time], 120) as Ingredients_Time 
                                        FROM [Mixing_Weigh] 
                                        where [Plan_No] = '{0}'
                                        and Company_Code = '{1}' and Factory_Code = '{2}' and ProductLine_Code = '{3}'
                                        order by serial_no", sPlanNo, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
            DataSet ds = DataHelper.Fill(sSQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                //ds.Tables[0].TableName = "Mixing_Alarm";

                dgvPlanDetail_TG.DataSource = ds.Tables[0];
                dgvPlanDetail_TG.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvPlanDetail_TG.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }

        }

        private void dgvPlan_TG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //未选中行，返回
                if (dgvPlan_TG.CurrentRow == null || dgvPlan_TG.CurrentRow.Index == -1)
                {
                    return;
                }

                string sPlanNo = dgvPlan_TG.CurrentRow.Cells["Plan_No_TG"].Value.ToString();
                //计划号为空，返回
                if (sPlanNo == "")
                {
                    return;
                }
                QueryPlanWeight_TG(sPlanNo);
            }
            catch (Exception ex)
            {

            }

        }

        private void QueryPlanWeight_ZJ(string sPlanNo)
        {
            string sSQL = string.Format(@"SELECT [Serial_No]
                                        ,[Ingredients_Code]
                                        ,[Ingredients_Name]
                                        ,[Ingredients_Weight]
                                        ,[Ingredients_Error]
                                        ,CONVERT(varchar(100), [Ingredients_Time], 120) as Ingredients_Time 
                                        FROM [Mixing_Weigh] where [Plan_No] = '{0}'
                                        and Company_Code = '{1}' and Factory_Code = '{2}' and ProductLine_Code = '{3}'
                                        order by serial_no", sPlanNo, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
            DataSet ds = DataHelper.Fill(sSQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                //ds.Tables[0].TableName = "Mixing_Alarm";

                dgvPlanDetail_ZJ.DataSource = ds.Tables[0];
                dgvPlanDetail_ZJ.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvPlanDetail_ZJ.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }

        }

        private void dgvPlan_ZJ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //未选中行，返回
                if (dgvPlan_ZJ.CurrentRow == null || dgvPlan_ZJ.CurrentRow.Index == -1)
                {
                    return;
                }

                string sPlanNo = dgvPlan_ZJ.CurrentRow.Cells["Plan_No_ZJ"].Value.ToString();
                //计划号为空，返回
                if (sPlanNo == "")
                {
                    return;
                }
                QueryPlanWeight_ZJ(sPlanNo);

            }
            catch (Exception ex)
            {

            }
        }

        private void QueryPlanWeight_JB(string sPlanNo)
        {
            string sSQL = string.Format(@"SELECT [Serial_No]
                                        ,[Ingredients_Code]
                                        ,[Ingredients_Name]
                                        ,[Ingredients_Weight]
                                        ,[Ingredients_Error]
                                        ,CONVERT(varchar(100), [Ingredients_Time], 120) as Ingredients_Time 
                                        ,[Accessories_Code1]
                                        ,[Accessories_Name1]
                                        ,[Accessories_Weight1]
                                        ,[Accessories_Error1]
                                        ,CONVERT(varchar(100), [Accessories_Time1], 120) as Accessories_Time1 
                                        ,[Accessories_Code2]
                                        ,[Accessories_Name2]
                                        ,[Accessories_Weight2]
                                        ,[Accessories_Error2]
                                        ,CONVERT(varchar(100), [Accessories_Time2], 120) as Accessories_Time2 
                                        ,[Accessories_Code3]
                                        ,[Accessories_Name3]
                                        ,[Accessories_Weight3]
                                        ,[Accessories_Error3]
                                        ,CONVERT(varchar(100), [Accessories_Time3], 120) as Accessories_Time3 
                                        ,[Rubber_Code]
                                        ,[Rubber_Name]
                                        ,[Rubber_Weight]
                                        ,[Rubber_Error]
                                        ,CONVERT(varchar(100), [Rubber_Time], 120) as Rubber_Time 
                                        ,[Solvent_Code1]
                                        ,[Solvent_Name1]
                                        ,[Solvent_Weight1]
                                        ,[Solvent_Error1]
                                        ,CONVERT(varchar(100), [Solvent_Time1], 120) as Solvent_Time1 
                                        ,[Solvent_Code2]
                                        ,[Solvent_Name2]
                                        ,[Solvent_Weight2]
                                        ,[Solvent_Error2]
                                        ,CONVERT(varchar(100), [Solvent_Time2], 120) as Solvent_Time2 
                                        ,[Solvent_Code3]
                                        ,[Solvent_Name3]
                                        ,[Solvent_Weight3]
                                        ,[Solvent_Error3]
                                        ,CONVERT(varchar(100), [Solvent_Time3], 120) as Solvent_Time3 
                                        FROM [Mixing_Weigh] where [Plan_No] = '{0}'
                                        and Company_Code = '{1}' and Factory_Code = '{2}' and ProductLine_Code = '{3}'
                                        order by serial_no", sPlanNo, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
            DataSet ds = DataHelper.Fill(sSQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                //ds.Tables[0].TableName = "Mixing_Alarm";

                dgvPlanDetail_JB.DataSource = ds.Tables[0];
                dgvPlanDetail_JB.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvPlanDetail_JB.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }

        }
        private void dgvPlan_JB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //未选中行，返回
                if (dgvPlan_JB.CurrentRow == null || dgvPlan_JB.CurrentRow.Index == -1)
                {
                    return;
                }

                string sPlanNo = dgvPlan_JB.CurrentRow.Cells["Plan_No_JB"].Value.ToString();
                //计划号为空，返回
                if (sPlanNo == "")
                {
                    return;
                }

                QueryPlanWeight_JB(sPlanNo);
            }
            catch (Exception ex)
            {

            }

        }

        private void dgvPlan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string sCellName = "";
            if (dgv.Name == "dgvPlan_JB")
            {
                sCellName = "Plan_Status_JB";
            }
            else if (dgv.Name == "dgvPlan_ZJ")
            {
                sCellName = "Plan_Status_ZJ";
            }
            else if (dgv.Name == "dgvPlan_TG")
            {
                sCellName = "Plan_Status_TG";
            }

            foreach (DataGridViewRow Myrow in dgv.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Myrow.Cells[sCellName].Value.ToString() == "未执行")// Or your condition 
                {
                    //Myrow.Cells[sCellName].Style.BackColor = Color;
                }
                if (Myrow.Cells[sCellName].Value.ToString() == "执行中")// Or your condition 
                {
                    Myrow.Cells[sCellName].Style.BackColor = Color.LightGreen;
                }
                if (Myrow.Cells[sCellName].Value.ToString() == "完成")// Or your condition 
                {
                    Myrow.Cells[sCellName].Style.BackColor = Color.LightBlue;
                }
                if (Myrow.Cells[sCellName].Value.ToString() == "取消")// Or your condition 
                {
                    Myrow.Cells[sCellName].Style.BackColor = Color.LightGray;
                }
            }
        }

        private void btn_StirClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_RubClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_TGSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btn_TGSearch.Enabled = false;

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
                btn_TGPrint.Enabled = MasterDataSet_TG.Tables[0].Rows.Count > 0;


            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("陶罐计划执行查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划执行查询出错");
            }
            finally
            {
                btn_TGSearch.Enabled = true;
            }
        }

        private void btn_TGPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //未选中行，返回
                if (dgvPlan_TG.CurrentRow == null || dgvPlan_TG.CurrentRow.Index == -1)
                {
                    return;
                }

                string sPlanNo = dgvPlan_TG.CurrentRow.Cells["Plan_No_TG"].Value.ToString();

                if (sPlanNo != "")
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"plan_report_TG.frx";
                    report.Load(filename);
                    report.Dictionary.Connections[0].ConnectionString = BaseSystemInfo.BusinessDbConnection;

                    TableDataSource tblPlan = report.GetDataSource("PlanInfo") as TableDataSource;
                    tblPlan.SelectCommand = string.Format(@"SELECT
                                                      b.[Plan_No]
                                                      ,b.[Recipe_Code]
                                                      ,b.[Recipe_Name]
                                                      ,b.[Plan_Qty]
                                                      ,b.[Actual_Qty]
                                                        ,Plan_Status = CASE WHEN b.Plan_Status = 0
                                                        THEN '未执行'
                                                        WHEN b.Plan_Status = 1
                                                        THEN '执行中'
                                                        WHEN b.Plan_Status = 2
                                                        THEN '完成'
                                                        WHEN b.Plan_Status = 3
                                                        THEN '取消'
                                                        ELSE ' ' END
                                                    ,CONVERT(varchar(100), b.[Plan_Date], 120) as Plan_Date
                                                    from Mixing_Plan b where b.[Plan_No] = '{0}'", sPlanNo);
                    //称量信息
                    TableDataSource tblWeight = report.GetDataSource("WeightInfo") as TableDataSource;
                    tblWeight.SelectCommand = string.Format(@"SELECT a.[Serial_No]
                                                      ,a.[Ingredients_Code]
                                                      ,a.[Ingredients_Name]
                                                      ,a.[Ingredients_Weight]
                                                      ,a.[Ingredients_Error]
                                                    ,CONVERT(varchar(100), a.[Ingredients_Time], 120) as Ingredients_Time 
                                                      FROM [Mixing_Weigh] a where a.[Plan_No] = '{0}'", sPlanNo);//.slTable = MasterDataSet_TG.Tables[0];

                    report.Show(true);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("陶罐计划打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "陶罐计划打印出错");
            }
        }

        private void btn_StirSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btn_StirSearch.Enabled = false;

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

                QueryPlanInfo_JB(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的计划
                btn_StirPrint.Enabled = MasterDataSet_JB.Tables[0].Rows.Count > 0;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("搅拌计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "搅拌计划查询出错");
            }
            finally
            {
                btn_StirSearch.Enabled = true;
            }
        }

        private void btn_StirPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //未选中行，返回
                if (dgvPlan_JB.CurrentRow == null || dgvPlan_JB.CurrentRow.Index == -1)
                {
                    return;
                }

                string sPlanNo = dgvPlan_JB.CurrentRow.Cells["Plan_No_JB"].Value.ToString();

                if (sPlanNo != "")
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"plan_report_JB.frx";
                    report.Load(filename);
                    report.Dictionary.Connections[0].ConnectionString = BaseSystemInfo.BusinessDbConnection;

                    //计划信息
                    TableDataSource tblPlan = report.GetDataSource("PlanInfo") as TableDataSource;
                    tblPlan.SelectCommand = string.Format(@"SELECT
                                                      [Plan_No]
                                                      ,[Recipe_Code]
                                                      ,[Recipe_Name]
                                                      ,[Plan_Qty]
                                                      ,[Actual_Qty]
                                                        ,Plan_Status = CASE WHEN Plan_Status = 0
                                                        THEN '未执行'
                                                        WHEN Plan_Status = 1
                                                        THEN '执行中'
                                                        WHEN Plan_Status = 2
                                                        THEN '完成'
                                                        WHEN Plan_Status = 3
                                                        THEN '取消'
                                                        ELSE ' ' END
                                                    ,CONVERT(varchar(100), [Plan_Date], 120) as Plan_Date
                                                    from Mixing_Plan where [Plan_No] = '{0}'", sPlanNo);

                    //称量信息
                    TableDataSource tblWeight = report.GetDataSource("WeightInfo") as TableDataSource;
                    tblWeight.SelectCommand = string.Format(@"SELECT [Serial_No]
                                                      ,[Ingredients_Code]
                                                      ,[Ingredients_Name]
                                                      ,[Ingredients_Weight]
                                                      ,[Ingredients_Error]
                                                    ,CONVERT(varchar(100), [Ingredients_Time], 120) as Ingredients_Time 
                                                      ,[Accessories_Code1]
                                                      ,[Accessories_Name1]
                                                      ,[Accessories_Weight1]
                                                      ,[Accessories_Error1]
                                                    ,CONVERT(varchar(100), [Accessories_Time1], 120) as Accessories_Time1 
                                                      ,[Accessories_Code2]
                                                      ,[Accessories_Name2]
                                                      ,[Accessories_Weight2]
                                                      ,[Accessories_Error2]
                                                    ,CONVERT(varchar(100), [Accessories_Time2], 120) as Accessories_Time2 
                                                      ,[Accessories_Code3]
                                                      ,[Accessories_Name3]
                                                      ,[Accessories_Weight3]
                                                      ,[Accessories_Error3]
                                                    ,CONVERT(varchar(100), [Accessories_Time3], 120) as Accessories_Time3 
                                                      ,[Rubber_Code]
                                                      ,[Rubber_Name]
                                                      ,[Rubber_Weight]
                                                      ,[Rubber_Error]
                                                    ,CONVERT(varchar(100), [Rubber_Time], 120) as Rubber_Time 
                                                      ,[Solvent_Code1]
                                                      ,[Solvent_Name1]
                                                      ,[Solvent_Weight1]
                                                      ,[Solvent_Error1]
                                                    ,CONVERT(varchar(100), [Solvent_Time1], 120) as Solvent_Time1 
                                                      ,[Solvent_Code2]
                                                      ,[Solvent_Name2]
                                                      ,[Solvent_Weight2]
                                                      ,[Solvent_Error2]
                                                    ,CONVERT(varchar(100), [Solvent_Time2], 120) as Solvent_Time2 
                                                      ,[Solvent_Code3]
                                                      ,[Solvent_Name3]
                                                      ,[Solvent_Weight3]
                                                      ,[Solvent_Error3]
                                                    ,CONVERT(varchar(100), [Solvent_Time3], 120) as Solvent_Time3 
                                                      FROM [Mixing_Weigh]  where [Plan_No] = '{0}'", sPlanNo);//.slTable = MasterDataSet_TG.Tables[0];

                    report.Show(true);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("搅拌计划打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "搅拌计划打印出错");
            }
        }

        private void btn_RubSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btn_RubSearch.Enabled = false;

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
                btn_RubPrint.Enabled = MasterDataSet_ZJ.Tables[0].Rows.Count > 0;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("制胶计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "制胶计划查询出错");
            }
            finally
            {
                btn_RubSearch.Enabled = true;
            }
        }

        private void btn_RubPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //未选中行，返回
                if (dgvPlan_ZJ.CurrentRow == null || dgvPlan_ZJ.CurrentRow.Index == -1)
                {
                    return;
                }

                string sPlanNo = dgvPlan_ZJ.CurrentRow.Cells["Plan_No_ZJ"].Value.ToString();

                if (sPlanNo != "")
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"plan_report_ZJ.frx";
                    report.Load(filename);
                    report.Dictionary.Connections[0].ConnectionString = BaseSystemInfo.BusinessDbConnection;

                    TableDataSource tblPlan = report.GetDataSource("PlanInfo") as TableDataSource;
                    tblPlan.SelectCommand = string.Format(@"SELECT
                                                      b.[Plan_No]
                                                      ,b.[Recipe_Code]
                                                      ,b.[Recipe_Name]
                                                      ,b.[Plan_Qty]
                                                      ,b.[Actual_Qty]
                                                        ,Plan_Status = CASE WHEN b.Plan_Status = 0
                                                        THEN '未执行'
                                                        WHEN b.Plan_Status = 1
                                                        THEN '执行中'
                                                        WHEN b.Plan_Status = 2
                                                        THEN '完成'
                                                        WHEN b.Plan_Status = 3
                                                        THEN '取消'
                                                        ELSE ' ' END
                                                    ,CONVERT(varchar(100), b.[Plan_Date], 120) as Plan_Date
                                                    from Mixing_Plan b where b.[Plan_No] = '{0}'", sPlanNo);
                    //称量信息
                    TableDataSource tblWeight = report.GetDataSource("WeightInfo") as TableDataSource;
                    tblWeight.SelectCommand = string.Format(@"SELECT a.[Serial_No]
                                                      ,a.[Ingredients_Code]
                                                      ,a.[Ingredients_Name]
                                                      ,a.[Ingredients_Weight]
                                                      ,a.[Ingredients_Error]
                                                    ,CONVERT(varchar(100), a.[Ingredients_Time], 120) as Ingredients_Time 
                                                      FROM [Mixing_Weigh] a where a.[Plan_No] = '{0}'", sPlanNo);//.slTable = MasterDataSet_TG.Tables[0];

                    report.Show(true);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("制胶计划打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "制胶计划打印出错");
            }
        }

        private void FrmPlanQuery_Activated(object sender, EventArgs e)
        {
            OptionSetting.MenuTitle = "计划数据";
        }
    }

    //public enum PlanType
    //{
    //    JB = 1,
    //    ZJ = 2,
    //    TG = 3
    //}

}
