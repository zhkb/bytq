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
    public partial class FrmQuality : Form
    {
        public FrmQuality()
        {
            InitializeComponent();
        }

        private void FrmQuality_Load(object sender, EventArgs e)
        {
            lbl_Product.Text = string.Format("{0}扫描 {1} Scan", BaseSystemInfo.CurrentProcessName, BaseSystemInfo.CurrentProcessName_EN);
            lbl_EnergyExam.Text = string.Format("{0}扫描记录 {1} Scan record ", BaseSystemInfo.CurrentProcessName, BaseSystemInfo.CurrentProcessName_EN);
            cht_ProductHour.ChartAreas[0].AxisY.Maximum = 150;
            cht_ProductHour.ChartAreas[0].AxisY.Interval = 50;
            cht_ProductHour.ChartAreas[0].AxisX.Interval = 1;
            InitQualityMonitor();
            InitChart();//加载柱状图
        }

        private void InitQualityMonitor()
        {
          
            LoadDataBar_Quality();//加载界面列表显示
          
        }

        private void InitChart()
        {
            try
            {

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
         from IMOS_PR_Quality  a 
         Where  
	      	CONVERT(VARCHAR(100), Scan_Time, 23) = CONVERT(VARCHAR(100), GETDATE(), 23) and  Check_Result=1       AND Company_Code = '{0}' AND Factory_Code = '{1}' AND Product_Line_Code = '{2}' and  Process_Code ='{3}'   ",
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
               

            }
            catch (Exception ex)
            {

            }
        }

        private void LoadDataBar_Quality()
        {
            try
            {

                string sqlStr = string.Format(@"SELECT Top 5 Product_BarCode ,Material_Name,convert(varchar(10),Scan_Time,108) as Scan_Time
                                                FROM IMOS_PR_Quality
                                                Where convert(varchar(10),Scan_Time,120) = convert(varchar(10),GETDATE(),120)

                                                And Company_Code = '{0}' 
                                                And Factory_Code = '{1}' 
                                                And Product_Line_Code = '{2}'
                                                And Process_Code = '{3}'
                                                Order By Scan_Time DESC", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentProcessCode);


                DataSet dataset = DataHelper.Fill(sqlStr);
                this.dgv_BackProductList.DataSource = dataset.Tables[0];
                this.dgv_BackProductList.Rows[0].Selected = false;
                dgv_BackProductList.ClearSelection();
            
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(string.Format("数据处理异常." + ex));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            txt_BarCode.Text = OptionSetting.BarCode;
            txt_MaterialName.Text = OptionSetting.MName;
            txt_MaterialCode.Text = OptionSetting.MCode;
            lbl_CheckTime.Text = OptionSetting.ScanTime;
            txt_MsgInfo.Text = OptionSetting.Msg;
            if (OptionSetting.Check_Result == 1)
            {
                txt_ProductResult.Text = "OK";
            }
            else {
                txt_ProductResult.Text = "NG";
            }

            if (OptionSetting.TaktTimeFlag == true) {
                LoadDataBar_Quality();
                OptionSetting.TaktTimeFlag = false;
            }


        }
    }
}
