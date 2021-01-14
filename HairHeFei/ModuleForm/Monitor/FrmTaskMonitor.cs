using Sys.DbUtilities;
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
    public partial class FrmTaskMonitor : Form
    {
        public FrmTaskMonitor()
        {
            InitializeComponent();
        }

        private void FrmTaskMonitor_Load(object sender, EventArgs e)
        {
            GetTask("1");//入库任务
            GetTask("2");//出库任务
            GetOutTask("1");//入库数据
            GetOutTask("2");//出库数据
            timer1.Interval = 10000;
            timer1.Enabled = true;
            timer1.Start();
            timer2.Interval = 500;
            timer2.Enabled = true;
            timer2.Start();
        }

        #region 获取数据图表
        private void GetTask(String In_Out)
        {
           try
            {
                String sql = String.Format(@"SELECT
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)>=0 then 1 ELSE 0 end ),0) Total_Qty,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=0  then 1 ELSE 0 end ),0) Hour_Qty,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=1  then 1 ELSE 0 end ),0) Hour_Qty1,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=2  then 1 ELSE 0 end ),0) Hour_Qty2,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=3  then 1 ELSE 0 end ),0) Hour_Qty3,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=4  then 1 ELSE 0 end ),0) Hour_Qty4, 
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=5  then 1 ELSE 0 end ),0) Hour_Qty5,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=6  then 1 ELSE 0 end ),0) Hour_Qty6,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=7  then 1 ELSE 0 end ),0) Hour_Qty7,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=8  then 1 ELSE 0 end ),0) Hour_Qty8,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=9  then 1 ELSE 0 end ),0) Hour_Qty9,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=10 then 1 ELSE 0 end ),0) Hour_Qty10,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=11 then 1 ELSE 0 end ),0) Hour_Qty11,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=12 then 1 ELSE 0 end ),0) Hour_Qty12,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=13  then 1 ELSE 0 end ),0) Hour_Qty13,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=14  then 1 ELSE 0 end ),0) Hour_Qty14,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=15  then 1 ELSE 0 end ),0) Hour_Qty15,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=16  then 1 ELSE 0 end ),0) Hour_Qty16,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=17  then 1 ELSE 0 end ),0)Hour_Qty17,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=18  then 1 ELSE 0 end ),0) Hour_Qty18,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=19  then 1 ELSE 0 end ),0) Hour_Qty19,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=20  then 1 ELSE 0 end ),0) Hour_Qty20,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=21  then 1 ELSE 0 end ),0) Hour_Qty21,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=22  then 1 ELSE 0 end ),0) Hour_Qty22,
                                           ISNULL(SUM(CASE when  dateName(hh,Create_Time)=23  then 1 ELSE 0 end ),0) Hour_Qty23 
                                           FROM
	                                            IMOS_Lo_Task
                                           WHERE
	                                            Task_Type = '{0}' and DATEDIFF(dd,Create_Time,GETDATE()) = 0", In_Out);
                DataSet ds = DataHelper.Fill(sql);
                int[] HourQty = new int[24];
              
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HourQty[0] = HourQty[0] + int.Parse(dr["Hour_Qty"].ToString());
                    HourQty[1] = HourQty[1] + int.Parse(dr["Hour_Qty1"].ToString());
                    HourQty[2] = HourQty[2] + int.Parse(dr["Hour_Qty2"].ToString());
                    HourQty[3] = HourQty[3] + int.Parse(dr["Hour_Qty3"].ToString());
                    HourQty[4] = HourQty[4] + int.Parse(dr["Hour_Qty4"].ToString());
                    HourQty[5] = HourQty[5] + int.Parse(dr["Hour_Qty5"].ToString());
                    HourQty[6] = HourQty[6] + int.Parse(dr["Hour_Qty6"].ToString());
                    HourQty[7] = HourQty[7] + int.Parse(dr["Hour_Qty7"].ToString());
                    HourQty[8] = HourQty[8] + int.Parse(dr["Hour_Qty8"].ToString());
                    HourQty[9] = HourQty[9] + int.Parse(dr["Hour_Qty9"].ToString());
                    HourQty[10] = HourQty[10] + int.Parse(dr["Hour_Qty10"].ToString());
                    HourQty[11] = HourQty[11] + int.Parse(dr["Hour_Qty11"].ToString());
                    HourQty[12] = HourQty[12] + int.Parse(dr["Hour_Qty12"].ToString());
                    HourQty[13] = HourQty[13] + int.Parse(dr["Hour_Qty13"].ToString());
                    HourQty[14] = HourQty[14] + int.Parse(dr["Hour_Qty14"].ToString());
                    HourQty[15] = HourQty[15] + int.Parse(dr["Hour_Qty15"].ToString());
                    HourQty[16] = HourQty[16] + int.Parse(dr["Hour_Qty16"].ToString());
                    HourQty[17] = HourQty[17] + int.Parse(dr["Hour_Qty17"].ToString());
                    HourQty[18] = HourQty[18] + int.Parse(dr["Hour_Qty18"].ToString());
                    HourQty[19] = HourQty[19] + int.Parse(dr["Hour_Qty19"].ToString());
                    HourQty[20] = HourQty[20] + int.Parse(dr["Hour_Qty20"].ToString());
                    HourQty[21] = HourQty[21] + int.Parse(dr["Hour_Qty21"].ToString());
                    HourQty[22] = HourQty[22] + int.Parse(dr["Hour_Qty22"].ToString());
                    HourQty[23] = HourQty[23] + int.Parse(dr["Hour_Qty23"].ToString());

                }
                if (In_Out == "1")
                {
                    chart_InTask.Series[0].Points.Clear();
                    chart_InTask.Series[0].Points.AddXY("00", HourQty[0]);
                    chart_InTask.Series[0].Points.AddXY("01", HourQty[1]);
                    chart_InTask.Series[0].Points.AddXY("02", HourQty[2]);
                    chart_InTask.Series[0].Points.AddXY("03", HourQty[3]);
                    chart_InTask.Series[0].Points.AddXY("04", HourQty[4]);
                    chart_InTask.Series[0].Points.AddXY("05", HourQty[5]);
                    chart_InTask.Series[0].Points.AddXY("06", HourQty[6]);
                    chart_InTask.Series[0].Points.AddXY("07", HourQty[7]);
                    chart_InTask.Series[0].Points.AddXY("08", HourQty[8]);
                    chart_InTask.Series[0].Points.AddXY("09", HourQty[9]);
                    chart_InTask.Series[0].Points.AddXY("10", HourQty[10]);
                    chart_InTask.Series[0].Points.AddXY("11", HourQty[11]);
                    chart_InTask.Series[0].Points.AddXY("12", HourQty[12]);
                    chart_InTask.Series[0].Points.AddXY("13", HourQty[13]);
                    chart_InTask.Series[0].Points.AddXY("14", HourQty[14]);
                    chart_InTask.Series[0].Points.AddXY("15", HourQty[15]);
                    chart_InTask.Series[0].Points.AddXY("16", HourQty[16]);
                    chart_InTask.Series[0].Points.AddXY("17", HourQty[17]);
                    chart_InTask.Series[0].Points.AddXY("18", HourQty[18]);
                    chart_InTask.Series[0].Points.AddXY("19", HourQty[19]);
                    chart_InTask.Series[0].Points.AddXY("20", HourQty[20]);
                    chart_InTask.Series[0].Points.AddXY("21", HourQty[21]);
                    chart_InTask.Series[0].Points.AddXY("22", HourQty[22]);
                    chart_InTask.Series[0].Points.AddXY("23", HourQty[23]);
                }else
                {

                    chart_OutTask.Series[0].Points.Clear();
                    chart_OutTask.Series[0].Points.AddXY("00", HourQty[0]);
                    chart_OutTask.Series[0].Points.AddXY("01", HourQty[1]);
                    chart_OutTask.Series[0].Points.AddXY("02", HourQty[2]);
                    chart_OutTask.Series[0].Points.AddXY("03", HourQty[3]);
                    chart_OutTask.Series[0].Points.AddXY("04", HourQty[4]);
                    chart_OutTask.Series[0].Points.AddXY("05", HourQty[5]);
                    chart_OutTask.Series[0].Points.AddXY("06", HourQty[6]);
                    chart_OutTask.Series[0].Points.AddXY("07", HourQty[7]);
                    chart_OutTask.Series[0].Points.AddXY("08", HourQty[8]);
                    chart_OutTask.Series[0].Points.AddXY("09", HourQty[9]);
                    chart_OutTask.Series[0].Points.AddXY("10", HourQty[10]);
                    chart_OutTask.Series[0].Points.AddXY("11", HourQty[11]);
                    chart_OutTask.Series[0].Points.AddXY("12", HourQty[12]);
                    chart_OutTask.Series[0].Points.AddXY("13", HourQty[13]);
                    chart_OutTask.Series[0].Points.AddXY("14", HourQty[14]);
                    chart_OutTask.Series[0].Points.AddXY("15", HourQty[15]);
                    chart_OutTask.Series[0].Points.AddXY("16", HourQty[16]);
                    chart_OutTask.Series[0].Points.AddXY("17", HourQty[17]);
                    chart_OutTask.Series[0].Points.AddXY("18", HourQty[18]);
                    chart_OutTask.Series[0].Points.AddXY("19", HourQty[19]);
                    chart_OutTask.Series[0].Points.AddXY("20", HourQty[20]);
                    chart_OutTask.Series[0].Points.AddXY("21", HourQty[21]);
                    chart_OutTask.Series[0].Points.AddXY("22", HourQty[22]);
                    chart_OutTask.Series[0].Points.AddXY("23", HourQty[23]);
           
                }
             
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region 获取出库数据图表
        private void GetOutTask(String In_Out)
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            RFID_BarCode,
	                                            Material_Code,
	                                            Material_Name,
	                                            Bar_Code,
	                                            CONVERT (
		                                            VARCHAR (50),
		                                            Create_Time,
		                                            120
	                                            ) Create_Time
                                            FROM
	                                            IMOS_Lo_Task
                                            WHERE
	                                            Task_Type = '{0}'
                                            ORDER BY
	                                            Create_Time DESC", In_Out);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    if(In_Out == "1")
                    {
                        dgv_In_Task.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        dgv_Out_Task.DataSource = ds.Tables[0];
                    }                  
                }

            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            GetTask("1");//入库任务
            GetTask("2");//出库任务
            GetOutTask("1");//入库数据
            GetOutTask("2");//出库数据
        }

        private void dgv_In_Task_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_In_Task.Rows.Count; i++)
                {
                    dgv_In_Task.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_In_Task.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }
                dgv_In_Task.ClearSelection();

            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_Out_Task_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_Out_Task.Rows.Count; i++)
                {
                    dgv_Out_Task.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_Out_Task.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }
                dgv_Out_Task.ClearSelection();

            }
            catch (Exception ex)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

       
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
