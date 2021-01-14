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
            GetEquipmentData();
            dgv_Alarm.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_Alarm.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

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
            dgv_Alarm.TopLeftHeaderCell.Value = "序号";

        }

        private void GetEquipmentData()
        {
            try
            {
                string SqlStr = "";
                DataSet PartDataSet = new DataSet();

                //SqlStr = string.Format(@"SELECT * FROM Sys_Equipment 
                //                       Where Equipment_Type={0} and Company_Code = '{1}' and Factory_Code = '{2}' and ProductLine_Code = '{3}'
                //                       Order By Equipment_Code", 1, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                SqlStr = string.Format(@"SELECT * FROM Sys_Equipment 
                                       Order By Equipment_Code");

                PartDataSet = DataHelper.Fill(SqlStr);

                com_Equipment.Items.Clear();

                //com_Equipment.Items.Add("");
                for (int i = 0; i < PartDataSet.Tables[0].Rows.Count; i++)//i是查到的数据条数
                {
                    DataRow dr = PartDataSet.Tables[0].Rows[i];
                    com_Equipment.Items.Add(dr["Equipment_Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询设备数据失败，请检查数据库连接.");
            }
            finally
            {

            }
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
                string SqlStr = string.Format(@"SELECT CONVERT(varchar(100), [Create_Time], 120) as Create_Time,[Equipment_Code] 
                                            ,[Equipment_Name] 
                                            ,[Alarm_Desc] 
                                            ,CONVERT(varchar(100), [Clear_Time], 120) as Clear_Time 
                                            FROM [IMOS_TA_AlarmLog] 
                                            where CONVERT(varchar(100), [Create_Time], 120) >= '{0}' 
                                            and CONVERT(varchar(100), [Create_Time], 120) <= '{1}' 
                                            and Company_Code = '{2}' and Factory_Code = '{3}' and Product_Line_Code = '{4}'
                                            and (Equipment_Name like '%{5}%' or Alarm_Desc like '%{5}%')
                                           order by Create_Time desc", 

                                            DownStartTime, DownEndTime, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sKey);


                MasterDataSet = null;

                MasterDataSet = DataHelper.Fill(SqlStr);
                
                if (MasterDataSet != null)
                {
                    MasterDataSet.Tables[0].TableName = "Mixing_Alarm";

                    dgv_Alarm.DataSource = MasterDataSet.Tables[0];
                    dgv_Alarm.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    dgv_Alarm.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
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

                string sKey = com_Equipment.Text.Trim();

                QueryWarningInfo(PlanStartTime, PlanEndTime, sKey);//查询设置的起始日期之内的停机记录
                btn_Print.Enabled = MasterDataSet.Tables[0].Rows.Count > 0;
                btn_Export.Enabled = MasterDataSet.Tables[0].Rows.Count > 0;
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
                btn_Print.Enabled = false;
                SysBusinessFunction.PrintReport(null, MasterDataSet, "Mixing_Alarm", @"warnreport.frx");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                btn_Print.Enabled = true;
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

        private void btn_Export_Click(object sender, EventArgs e)
        {

            try
            {
                btn_Export.Enabled = false;
                SysBusinessFunction.ExportReport(null, MasterDataSet, "Mixing_Alarm", @"warnreport.frx", "报警日志记录");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                btn_Export.Enabled = true;
            }

        }
    }
}
