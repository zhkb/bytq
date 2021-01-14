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

namespace Monitor
{
    public partial class FrmProductMonitor : Form
    {
        public FrmProductMonitor()
        {
            InitializeComponent();
        }
        int TaktTime = 0;
        private void FrmProductMonitor_Load(object sender, EventArgs e)
        {
            cht_ProductHour.ChartAreas[0].AxisY.Maximum = 150;
            cht_ProductHour.ChartAreas[0].AxisY.Interval = 50;

            cht_ProductHour.ChartAreas[0].AxisX.Interval = 1;
            //   cht_ProductHour.ChartAreas[0].AxisX.Maximum = 23;
           
            InitProductMonitor();
            InitChart();
            InitOperationInfo();



        }

   

        #region 初始化界面数据
        private void InitProductMonitor()
        {
            //1.工位显示
            if (BaseSystemInfo.CurrentProcessCode == "1001") {
                lb_chs_process.Text = "产品上线";
                lb_en_process.Text = "On Line";
            }
            if (BaseSystemInfo.CurrentProcessCode == "1010")
            {
                lb_chs_process.Text = "产品焊接";
                lb_en_process.Text = "Product";
            }
            if (BaseSystemInfo.CurrentProcessCode == "1090")
            {
                lb_chs_process.Text = "产品下线"; 
                lb_en_process.Text = "Off Line";
            }
            //2.上岗人员
            lb_UserCode.Text = BaseSystemInfo.CurrentUserCode;
            lb_UserName.Text = BaseSystemInfo.CurrentUserName;
            //3.节拍初始化
            TaktTime = 0;
            //4.实际产量
            lbl_ActualCount.Text = "0";
         

        }

        #endregion

        #region 获取计划数量
        private void getProductNumDate()
        {
            try
            {
                string sSQL = string.Format(@"SELECT B.Parameter_Detail_ID, B.Parameter_Detail_Code, B.Remark FROM dbo.Sys_Parameters_Master AS A 
	                                        LEFT JOIN dbo.Sys_Parameters_Detail AS B ON A.Parameter_Master_Code = B.Parameter_Master_Code 
                                        WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Parameter_Master_Name = '{3}'",
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentPlanName);

                DataSet ds = DataHelper.Fill(sSQL);
                lbl_PlanNum.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                // lbl_difference.Text = (int.Parse(lbl_PlanNum.Text) - int.Parse(lbl_ActualCount.Text)).ToString();
                lbl_finish.Text = Math.Round(double.Parse(lbl_ActualCount.Text) / double.Parse(lbl_PlanNum.Text), 2) * 100 + "%";
            }
            catch (Exception) {

            }
        }

        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OptionSetting.TaktTimeFlag == true) {
                InitChart();
                TaktTime = 0;
                OptionSetting.TaktTimeFlag = false;
            }



            TaktTime = TaktTime + 1;
            lb_TaktTime.Text = TaktTime + "S";

            lbl_BarCode.Text = OptionSetting.BarCode;
            lbl_ProductInfo.Text = OptionSetting.MCode;
            lbl_MessageInfo.Text = OptionSetting.Msg;



        }

        #region 初始化统计数据
        private void InitChart()
        {
          //  Random FNum = new Random();
            try
            {
                //加载实际数量
                string sSQL = string.Format(@"SELECT ISNULL(COUNT(*), 0) AS ActualCount FROM dbo.IMOS_PR_BarCode 
                                            WHERE CONVERT(VARCHAR(100), Scan_Time, 23) = CONVERT(VARCHAR(100), GETDATE(), 23) 
	                                            AND Company_Code = '{0}' AND Factory_Code = '{1}' AND Product_Line_Code = '{2}' and  Process_Code ='{3}'",
                                     BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,  BaseSystemInfo.CurrentProcessCode);
                DataTable ActualCountDt = DataHelper.Fill(sSQL).Tables[0];
                lbl_ActualCount.Text = ActualCountDt.Rows[0]["ActualCount"].ToString();



             //加载柱状图

                cht_ProductHour.Series[0].Points.Clear();

                string sSQL1 = string.Format(@"select  isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=0  then 1 ELSE 0 end ),0) Hour_Qty0,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=1  then 1 ELSE 0 end ),0) Hour_Qty1,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=2  then 1 ELSE 0 end ),0) Hour_Qty2,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=3  then 1 ELSE 0 end ),0) Hour_Qty3,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=4  then 1 ELSE 0 end ),0) Hour_Qty4,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=5  then 1 ELSE 0 end ),0) Hour_Qty5,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=6  then 1 ELSE 0 end ),0) Hour_Qty6,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=7  then 1 ELSE 0 end ),0) Hour_Qty7,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=8  then 1 ELSE 0 end ),0) Hour_Qty8,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=9  then 1 ELSE 0 end ),0) Hour_Qty9,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=10 then 1 ELSE 0 end ),0) Hour_Qty10,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=11 then 1 ELSE 0 end ),0) Hour_Qty11,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=12 then 1 ELSE 0 end ),0) Hour_Qty12,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=13  then 1 ELSE 0 end ),0) Hour_Qty13,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=14  then 1 ELSE 0 end ),0) Hour_Qty14,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=15  then 1 ELSE 0 end ),0) Hour_Qty15,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=16  then 1 ELSE 0 end ),0) Hour_Qty16,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=17  then 1 ELSE 0 end ),0) Hour_Qty17,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=18  then 1 ELSE 0 end ),0) Hour_Qty18,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=19  then 1 ELSE 0 end ),0) Hour_Qty19,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=20  then 1 ELSE 0 end ),0) Hour_Qty20,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=21  then 1 ELSE 0 end ),0) Hour_Qty21,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=22  then 1 ELSE 0 end ),0) Hour_Qty22,
                            isnull(SUM(CASE when  dateName(hh,a.Scan_Time)=23 then 1 ELSE 0 end ),0) Hour_Qty23
                             from IMOS_PR_BarCode  a 
                             Where  
	      	                    CONVERT(VARCHAR(100), Scan_Time, 23) = CONVERT(VARCHAR(100), GETDATE(), 23)        AND Company_Code = '{0}' AND Factory_Code = '{1}' AND Product_Line_Code = '{2}' and  Process_Code ='{3}'   ",
                                                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode);
                DataSet ds = DataHelper.Fill(sSQL1);
                DataTable dt = ds.Tables[0];

                cht_ProductHour.Series[0].Points.Clear();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        cht_ProductHour.Series[0].Points.AddXY("00", int.Parse(dr["Hour_Qty0"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("01", int.Parse(dr["Hour_Qty1"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("02", int.Parse(dr["Hour_Qty2"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("03", int.Parse(dr["Hour_Qty3"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("04", int.Parse(dr["Hour_Qty4"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("05", int.Parse(dr["Hour_Qty5"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("06", int.Parse(dr["Hour_Qty6"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("07", int.Parse(dr["Hour_Qty7"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("08", int.Parse(dr["Hour_Qty8"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("09", int.Parse(dr["Hour_Qty9"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("10", int.Parse(dr["Hour_Qty10"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("11", int.Parse(dr["Hour_Qty11"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("12", int.Parse(dr["Hour_Qty12"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("13", int.Parse(dr["Hour_Qty13"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("14", int.Parse(dr["Hour_Qty14"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("15", int.Parse(dr["Hour_Qty15"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("16", int.Parse(dr["Hour_Qty16"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("17", int.Parse(dr["Hour_Qty17"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("18", int.Parse(dr["Hour_Qty18"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("19", int.Parse(dr["Hour_Qty19"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("20", int.Parse(dr["Hour_Qty20"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("21", int.Parse(dr["Hour_Qty21"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("22", int.Parse(dr["Hour_Qty22"].ToString()));
                        cht_ProductHour.Series[0].Points.AddXY("23", int.Parse(dr["Hour_Qty23"].ToString()));

                    }
                }
                getProductNumDate();
              
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region 计划修改
        private void lbl_PlanNum_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sSQL = string.Format(@"SELECT B.Parameter_Detail_ID, B.Parameter_Detail_Code, B.Remark FROM dbo.Sys_Parameters_Master AS A 
	                                        LEFT JOIN dbo.Sys_Parameters_Detail AS B ON A.Parameter_Master_Code = B.Parameter_Master_Code 
                                        WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Parameter_Master_Name = '{3}'",
                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentPlanName);

                DataSet ds = DataHelper.Fill(sSQL);

                FrmPlanNumModify DownModifyForm = new FrmPlanNumModify();

                DownModifyForm.sPlanID = ds.Tables[0].Rows[0]["Parameter_Detail_ID"].ToString();
                DownModifyForm.sPlanNum = ds.Tables[0].Rows[0]["Remark"].ToString();

                DialogResult r = DownModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {

                }
                DownModifyForm.Dispose();
                getProductNumDate();
            }
            catch (Exception ex) {


            }
        }
        #endregion

        #region 操作说明

        private void InitOperationInfo()
        {
            try
            {
                string sSQL = string.Format(@"SELECT A.CHS,A.EN  FROM dbo.Sys_Operation_Info  A
	                                      
                                        WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Process_Code = '{3}'",
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode);

                DataSet ds = DataHelper.Fill(sSQL);
                lb_OperationInfo_CHS.Text = ds.Tables[0].Rows[0]["CHS"].ToString();
                lb_OperationInfo_EN.Text = ds.Tables[0].Rows[0]["CHS"].ToString();
            }
            catch (Exception)
            {

            }
        }
        #endregion

    }
}