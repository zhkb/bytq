using FastReport.Data;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report
{
    public partial class EnergyReport : Form
    {
        private DataSet MasterDataSet = new DataSet();
        public EnergyReport()
        {
            InitializeComponent();
        }

        private void EnergyReport_Load(object sender, EventArgs e)
        {

            DateTime today1 = DateTime.Now.Date;
            dt_StartTime.Value = today1;
            dt_StartTime2.Value = today1;
            dt_EndTime.Value = DateTime.Now;
            dt_EndTime2.Value = DateTime.Now;
            GetData("", DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void GetData(String name, String starttime,String endtime)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT  a.[Product_BarCode],a.[Material_Code],a.[Material_Name],a.[Material_Level],Convert(Varchar(100),a.Scan_Time,120) Scan_Time
                                                FROM IMOS_PR_Scan a 
                                                Where Convert(Varchar(100),[Scan_Time],120) >= '{0}' and Convert(Varchar(100),[Scan_Time],120) <= '{1}' and a.[Company_Code]='{2}'and a.[Factory_Code] = '{3}'and a.[Product_Line_Code] = '{4}'and a.[Process_Code] = '{5}' and  a.[Material_Name] like '%{6}%'
                                                order by Scan_Time Desc",
                                                  starttime, endtime, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode, name);

                MasterDataSet = DataHelper.Fill(SqlStr);
                dgv_Common.DataSource = MasterDataSet.Tables[0];
                dgv_Common.ClearSelection();
                dgv_Common.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_Common.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("通过产品名称和时间查询扫描信息失败." + ex.ToString());
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

        private void dgv_Common_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            #region 设置表格序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X+18,
            e.RowBounds.Location.Y,
            dgv_Common.RowHeadersWidth,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv_Common.RowHeadersDefaultCellStyle.Font, rectangle, dgv_Common.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            dgv_Common.Rows[0].Selected = false;
            #endregion
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text.Trim();
            string starttime = dt_StartTime.Text.Trim()+" "+dt_StartTime2.Text.Trim();
            string endtime = dt_EndTime.Text.Trim()+" "+dt_EndTime2.Text.Trim();
            DateTime t1 = Convert.ToDateTime(starttime);
            DateTime t2 = Convert.ToDateTime(endtime);
            if (DateTime.Compare(t1, t2) > 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "开始日期时间大于结束日期时间，请重新输入.");

                return;
            }
            GetData(name,starttime,endtime);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterDataSet != null && MasterDataSet.Tables.Count > 0)
                {
                    FastReport.Report report = new FastReport.Report();
                    string filename = @"Report\plan_report_Energy.frx";
                    report.Load(filename);
                    report.RegisterData(MasterDataSet.Tables[0], "IMOS_PR_Scan");
                    report.Show(true);
                    report.Dispose();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("能耗标识扫描信息打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "能耗标识扫描信息打印出错");
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SysBusinessFunction.ExportReport(null, MasterDataSet, "IMOS_PR_Scan", @"Report\plan_report_Energy.frx", "能效贴扫描日志"+DateTime.Now.ToString("yyMMdd"));
            //try
            //{
            //    if (MasterDataSet != null && MasterDataSet.Tables.Count > 0)
            //    {
            //        FastReport.Report report = new FastReport.Report();
            //        string filename = @"Report\plan_report_Energy.frx";
            //        report.Load(filename);
            //        report.RegisterData(MasterDataSet.Tables[0], "IMOS_PR_Scan");
            //        FastReport.Export.OoXML.Excel2007Export export = new FastReport.Export.OoXML.Excel2007Export();
            //        string BarPath = "C:\\Users\\Administrator\\Desktop\\mmm.xls";
            //        report.Export(export, BarPath);
            //        report.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SysBusinessFunction.WriteLog("能耗标识扫描信息导出出错," + ex.Message);
            //    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "能耗标识扫描信息导出出错");
            //}
        }
    }
}
