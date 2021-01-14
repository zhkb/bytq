using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    public partial class FrmWeigh : Form
    {
        public int PlanType = 0;
        private DataSet MasterDataSet_JB = null;
        private DataSet SerialDataSet = null;
        private DataSet WeighDataSet = null;
        private DataSet StepDataSet = null;
        private DataSet CheckDataSet = null;

        private string CheckPlanNo;
        private int CheckSerialNo;

        private FrmWeighReport WeighMainForm;
        public FrmWeigh(FrmWeighReport FrmWeighMain)
        {
            InitializeComponent();
            WeighMainForm = FrmWeighMain;
        }

        private void FrmWeigh_Load(object sender, EventArgs e)
        {
            btn_Save.Enabled = false;
            dt_StartTime_JB.CustomFormat = "HH:mm:ss";
            dt_EndTime_JB.CustomFormat = "HH:mm:ss";

            dt_StartTime_JB.Text = "00:00:01";
            dt_EndTime_JB.Text = "23:59:59";

            com_Equipment.Items.Clear();
            com_Equipment.Items.Add("全部");
            if (PlanType == (int)OptionSetting.PlanType.StirPlan)
            {
                if (BaseSystemInfo.SystemType == 1)
                {
                    com_Equipment.Items.Add("1号搅拌机台");
                    com_Equipment.Items.Add("2号搅拌机台");
                    com_Equipment.Items.Add("3号搅拌机台");
                    com_Equipment.Items.Add("4号搅拌机台");
                }

                if (BaseSystemInfo.SystemType == 2)
                {
                    com_Equipment.Items.Add("5号搅拌机台");
                    com_Equipment.Items.Add("6号搅拌机台");
                    com_Equipment.Items.Add("7号搅拌机台");
                    com_Equipment.Items.Add("8号搅拌机台");
                }

            }

            if (PlanType == (int)OptionSetting.PlanType.RubberPlan)
            {
                if (BaseSystemInfo.SystemType == 1)
                {
                    com_Equipment.Items.Add("1号制胶机台");
                    com_Equipment.Items.Add("2号制胶机台");

                }

                if (BaseSystemInfo.SystemType == 2)
                {
                    com_Equipment.Items.Add("3号搅拌机台");
                    com_Equipment.Items.Add("4号搅拌机台");
                }

            }

            if (PlanType == (int)OptionSetting.PlanType.TerrinePlan)
            {
                com_Equipment.Items.Add("1号制陶机台");
                com_Equipment.Items.Add("2号制陶机台");
            }

            com_Equipment.SelectedIndex = 0;
            //初始化 序号列
            dgv_Plan.TopLeftHeaderCell.Value = "序号";
            dgv_Weigh.TopLeftHeaderCell.Value = "序号";
            dgv_Step.TopLeftHeaderCell.Value = "序号";

            dgv_Plan.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_Plan.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgv_PlanSerial.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_PlanSerial.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgv_Weigh.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_Weigh.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgv_Step.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_Step.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgv_Step.Columns["Rubber_Code"].Visible = (PlanType == ((int)OptionSetting.RecipeType.StirType) || (PlanType == (int)OptionSetting.RecipeType.TerrineType));
            dgv_Step.Columns["Rubber_Weight"].Visible = (PlanType == ((int)OptionSetting.RecipeType.StirType) || (PlanType == (int)OptionSetting.RecipeType.TerrineType));

            dgv_Step.Columns["CNT_Code"].Visible = (PlanType == (int)OptionSetting.RecipeType.StirType);
            dgv_Step.Columns["CNT_Weight"].Visible = (PlanType == (int)OptionSetting.RecipeType.StirType);

            if (BaseSystemInfo.SystemType == 1)
            {
                dgv_Step.Columns["CNT_Code"].HeaderText = "CNT编码";
                dgv_Step.Columns["CNT_Weight"].HeaderText = "CNT(Kg)";
            }

            if (BaseSystemInfo.SystemType == 2)
            {
                dgv_Step.Columns["CNT_Code"].HeaderText = "SBR编码";
                dgv_Step.Columns["CNT_Weight"].HeaderText = "SBR(Kg)";
            }


        }

        private void GetPlanData()
        {
            try
            {
                string PlanStartTime = dt_StartDate_JB.Text + " " + dt_StartTime_JB.Text;
                string PlanEndTime = dt_EndDate_JB.Text + " " + dt_EndTime_JB.Text;

                DateTime t1 = Convert.ToDateTime(PlanStartTime);
                DateTime t2 = Convert.ToDateTime(PlanEndTime);

                if (DateTime.Compare(t1, t2) > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间.");

                    return;
                }

                string EquipIndex = "";
                string EquipNo = "0";
                if (com_Equipment.SelectedIndex > 0)
                {
                    EquipIndex = com_Equipment.SelectedIndex.ToString();
                }


                if (BaseSystemInfo.SystemType == 2)
                {
                    if (PlanType == (int)OptionSetting.PlanType.StirPlan)
                    {
                        EquipNo = "4";
                    }
                    if (PlanType == (int)OptionSetting.PlanType.RubberPlan)
                    {
                        EquipNo = "2";
                    }

                }

                string sKey = tbKey_JB.Text.Trim();
                string SqlStr = string.Format(@"SELECT Plan_ID,[Plan_No],Order_NO
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
                                            THEN '结束'
                                            ELSE ' ' END 
                                            ,CONVERT(varchar(100), [Plan_Date], 120) as Plan_Date 
                                            ,Cast (Equipment_No + {8} as Varchar(5)) + '号机台' Equipment_Name
                                            FROM [Mixing_Plan]
                                            where CONVERT(varchar(100), [Plan_Date], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Plan_Date], 120) <= '{1}' 
                                            and Plan_Type = {2} 
                                            and Company_Code = '{3}' and Factory_Code = '{4}' and ProductLine_Code = '{5}'
                                            and (Plan_No like '%{6}%' or Recipe_Code like '%{6}%' or Recipe_Name like '%{6}%')
                                            and Equipment_No like '%{7}%'
                                            order by Plan_Date desc",
                                            PlanStartTime, PlanEndTime, PlanType, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sKey, EquipIndex, EquipNo);

                MasterDataSet_JB = DataHelper.Fill(SqlStr);

                MasterDataSet_JB.Tables[0].TableName = "Mixing_Alarm";

                dgv_Plan.DataSource = MasterDataSet_JB.Tables[0];

                dgv_Plan_CellClick(null, null);

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("搅拌计划查询出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "搅拌计划查询出错，请检查数据库连接状态");
            }
        }

        private void GetPlanWeighData(string PlanNo, int SerialNo)
        {
            string WeighSql = string.Format(@"exec [Pr_GetMaterialWeigh] '{0}','{1}',{2}", PlanNo, PlanType, SerialNo);

            WeighDataSet = DataHelper.Fill(WeighSql);

            dgv_Weigh.DataSource = WeighDataSet.Tables[0];

            // dgv_Weigh_CellClick(null, null);
        }

        private void GetSerialStepData(string PlanNo, int SerialNo)
        {
            string StepSql = string.Format(@"exec [Pr_GetStepData] '{0}','{1}',{2}", PlanNo, PlanType, SerialNo);

            StepDataSet = DataHelper.Fill(StepSql);

            dgv_Step.DataSource = StepDataSet.Tables[0];

        }

        private void GetSerialCheckData(string PlanNo, int SerialNo)
        {
            try
            {
                string CheckSql = string.Format(@"select Viscosity_Value,Temp_Value,Solid_Value,Fineness_Value
                                         from mixing_check
                                         Where Plan_No = '{0}'
                                         And Serial_No = '{1}'", PlanNo, SerialNo);

                CheckDataSet = DataHelper.Fill(CheckSql);

                if (CheckDataSet.Tables[0].Rows.Count == 0)
                {
                    num_NDValue.Value = 0;
                    num_TempValue.Value = 0;
                    num_GHLValue.Value = 0;
                    num_XDValue.Value = 0;
                    return;
                }

                num_NDValue.Value = Convert.ToDecimal(CheckDataSet.Tables[0].Rows[0]["Viscosity_Value"].ToString());
                num_TempValue.Value = Convert.ToDecimal(CheckDataSet.Tables[0].Rows[0]["Temp_Value"].ToString());
                num_GHLValue.Value = Convert.ToDecimal(CheckDataSet.Tables[0].Rows[0]["Solid_Value"].ToString());
                num_XDValue.Value = Convert.ToDecimal(CheckDataSet.Tables[0].Rows[0]["Fineness_Value"].ToString());
            }
            catch
            {

            }
            finally
            {

            }


        }

        private void btn_StirClose_Click(object sender, EventArgs e)
        {
            WeighMainForm.Close();
        }

        private void btn_StirSearch_Click(object sender, EventArgs e)
        {
            GetPlanData();
        }

        private void GetCurveData(string PlanNo, int SerialNo)// 取得曲线数据
        {
            try
            {
                string SqlStr = string.Format(@"Select CONVERT(varchar(100), Create_Time, 24) CurveTime,JBSpeed,JBDL,FSSpeed,FSDL,Temp,Press
                                                From Mixing_Curve Where Plan_No = '{0}' and Serial_No = {1}", PlanNo, SerialNo);

                DataSet CurveDataSet = DataHelper.Fill(SqlStr);

                cht_JBZS.Series[0].Points.Clear();
                cht_JBDL.Series[0].Points.Clear();
                cht_FSZS.Series[0].Points.Clear();
                cht_FSDL.Series[0].Points.Clear();
                cht_Temp.Series[0].Points.Clear();
                cht_Press.Series[0].Points.Clear();

                for (int i = 0; i < CurveDataSet.Tables[0].Rows.Count; i++)//i是查到的数据条数
                {
                    DataRow dr = CurveDataSet.Tables[0].Rows[i];
                    decimal JBSpeed = Convert.ToDecimal(dr["JBSpeed"].ToString());
                    decimal JBDL = Convert.ToDecimal(dr["JBDL"].ToString());
                    decimal FSSpeed = Convert.ToDecimal(dr["FSSpeed"].ToString());
                    decimal FSDL = Convert.ToDecimal(dr["FSDL"].ToString());
                    decimal Temp = Convert.ToDecimal(dr["Temp"].ToString());
                    decimal Press = Convert.ToDecimal(dr["Press"].ToString());
                    string CurveTime = dr["CurveTime"].ToString();

                    cht_JBZS.Series[0].Points.AddXY(CurveTime, JBSpeed);
                    cht_JBDL.Series[0].Points.AddXY(CurveTime, JBDL);
                    cht_FSZS.Series[0].Points.AddXY(CurveTime, FSSpeed);
                    cht_FSDL.Series[0].Points.AddXY(CurveTime, FSDL);
                    cht_Temp.Series[0].Points.AddXY(CurveTime, Temp);
                    cht_Press.Series[0].Points.AddXY(CurveTime, Press);
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void btn_StirPrint_Click(object sender, EventArgs e)
        {

        }


        private void dgv_Weigh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_Weigh.Rows.Count == 0)
            //{
            //    return;
            //}

            //string Batch_No = dgv_Weigh.CurrentRow.Cells["Material_Batch"].Value.ToString();
            //GetBatchData(Batch_No);
        }

        private void dgv_Plan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int PlanQty = int.Parse(dgv_Plan.CurrentRow.Cells["Plan_Qty_JB"].Value.ToString());
                string SqlStr = string.Format(@"exec [Pr_GetPlanSerial] '{0}'", PlanQty);

                SerialDataSet = DataHelper.Fill(SqlStr);

                dgv_PlanSerial.DataSource = SerialDataSet.Tables[0];

                dgv_PlanSerial_CellClick(null, null);
            }
            catch
            {

            }
            finally
            {

            }


        }

        private void dgv_Plan_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_Weigh_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_PlanSerial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btn_Save.Enabled = false;
                if (dgv_PlanSerial.Rows.Count == 0)
                {
                    return;
                }
                btn_Save.Enabled = true;
                string PlanNo = dgv_Plan.CurrentRow.Cells["Plan_No"].Value.ToString();
                int SerialNo = int.Parse(dgv_PlanSerial.CurrentRow.Cells["Plan_Serial"].Value.ToString());
                CheckPlanNo = PlanNo;
                CheckSerialNo = SerialNo;
                GetPlanWeighData(PlanNo, SerialNo);
                GetSerialStepData(PlanNo, SerialNo);
                GetSerialCheckData(PlanNo, SerialNo);
                GetCurveData(PlanNo, SerialNo);

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void dgv_Step_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format(@"是否确认保存质检数据？")) != DialogResult.Yes)
                {
                    return;
                }

                double ND_Value = Convert.ToDouble(num_NDValue.Value);
                double Temp_Value = Convert.ToDouble(num_TempValue.Value);
                double GHL_Value = Convert.ToDouble(num_GHLValue.Value);
                double XD_Value = Convert.ToDouble(num_XDValue.Value);

                //删除旧的质检数据
                string WeighData = string.Format(@"Delete From Mixing_Check
                                                       Where Plan_No = '{0}' and Serial_No = {1}
                                                       and Company_Code = '{2}' and Factory_Code = '{3}' and ProductLine_Code = '{4}'",
                                                   CheckPlanNo, CheckSerialNo, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataHelper.Fill(WeighData);

                //增加新的质检数据
                string DataSql = string.Format(@"Insert Into Mixing_Check(Plan_No,Serial_No,Plan_Type,Viscosity_Value,Temp_Value,Solid_Value,Fineness_Value,
                                                     Company_Code, Company_Name, Factory_Code, Factory_Name, ProductLine_Code, ProductLine_Name)
                                                     Values('{0}',{1},{2},{3},{4},{5},{6},'{7}','{8}','{9}','{10}','{11}','{12}')",
                                                 CheckPlanNo, CheckSerialNo, OptionSetting.StirPlanType, ND_Value, Temp_Value, GHL_Value, XD_Value,
                                                 BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
                DataHelper.Fill(DataSql);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检数据保存完成.");
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检数据保存异常.");
                SysBusinessFunction.WriteLog("质检数据保存异常");
            }
            finally
            {

            }
        }
    }
}
