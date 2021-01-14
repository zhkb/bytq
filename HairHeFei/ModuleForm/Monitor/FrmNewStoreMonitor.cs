using ControlLogic.Control;
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
    public partial class FrmNewStoreMonitor : Form
    {
        public FrmNewStoreMonitor()
        {
            InitializeComponent();
            dgv_Task.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmNewStoreMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态

                SysBusinessFunction.CreateCheckDBConnection();
                //ControlXPLC.SystemInitialization();
                //ControlStoreMonitor.SystemInitialization();
                //for (int i = 1; i <= 8; i++)
                //{
                //    FrmNOutStoreDetailMonitor frm = new FrmNOutStoreDetailMonitor();
                //    frm.TopLevel = false;
                //    frm.Parent = panel12;
                //    frm.Dock = DockStyle.Bottom;
                //    frm.Height = 50;
                //    frm.BinCode = i;
                //    frm.Width = panel12.Width;
                //    frm.Show();
                //}
                FrmFPMonitor ffp = new FrmFPMonitor();
                ffp.TopLevel = false;
                ffp.Parent = panel14;
                ffp.Dock = DockStyle.Fill;
                ffp.Show();
                updPlan();
                getTask();
                timer1.Enabled = true;
                timer1.Start();
                timer1.Interval = 5000;
                timer2.Enabled = true;
                timer2.Start();
                timer2.Interval = 1000;
            }
            catch(Exception ex)
            {

            }
         
        }

        private void updPlan()
        {
            try
            {
                String msql = String.Format(@"SELECT
	                                            B.Material_Name,
	                                            B.Material_Plan_Num,
	                                            ISNULL(
		                                            (
			                                            SELECT
				                                            COUNT (1)
			                                            FROM
				                                            IMOS_Lo_Task A
			                                            WHERE
				                                            A.Material_Code = B.Material_Code
			                                            AND A.Task_Type = 1
			                                             AND A.Create_Time >= '{0}'
                                                        AND A.Create_Time <= '{1}'
			                                            GROUP BY
				                                            A.Material_Code
		                                            ),
		                                            0
	                                            ) AcSum,
                                              B.Material_Plan_Num - ISNULL(
		                                            (
			                                            SELECT
				                                            COUNT (1)
			                                            FROM
				                                            IMOS_Lo_Task A
			                                            WHERE
				                                            A.Material_Code = B.Material_Code
			                                            AND A.Task_Type = 1
			                                             AND A.Create_Time >= '{0}'
                                                        AND A.Create_Time <= '{1}'
			                                            GROUP BY
				                                            A.Material_Code
		                                            ),
		                                            0
	                                            )   as CNum
                                            FROM
	                                            IMOS_TA_Material B
                                            WHERE
	                                            Material_Plan_Num != 0",lbl_StartTime.Text.ToString(),lbl_EndTime.Text.ToString());
                DataSet mds = DataHelper.Fill(msql);

                if (mds != null)
                {

                    dgv_Task.DataSource = mds.Tables[0];
                    int m = 0;
                    int n = 0;
                    for (int i = 0; i < mds.Tables[0].Rows.Count; i++)
                    {
                        m = m + int.Parse(mds.Tables[0].Rows[i]["AcSum"].ToString());
                        n = n + int.Parse(mds.Tables[0].Rows[i]["Material_Plan_Num"].ToString());
                    }
                    if (n != int.Parse(lbl_PlanNum.Text))
                    {
                        lbl_PlanNum.Text = n.ToString();
                    }
                    double k = Double.Parse(lbl_PlanNum.Text.ToString());
                    double s = (double)m / k;
                    lbl_AcSum.Text = m.ToString();
                    lbl_Rate.Text = String.Format("{0:F}", s * 100) + "%";
                    if (s * 100 > 90)
                    {
                        lbl_Rate.ForeColor = Color.Lime;
                    }
                }
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
            }catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT  Parameter_Master_Name From Sys_Parameters_Master  WHERE Parameter_Master_Code = '1008'");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    lbl_StartTime.Text = ds.Tables[0].Rows[0]["Parameter_Master_Name"].ToString();
                }
                sql = String.Format(@"SELECT  Parameter_Master_Name From Sys_Parameters_Master  WHERE Parameter_Master_Code = '1009'");
                ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    lbl_EndTime.Text = ds.Tables[0].Rows[0]["Parameter_Master_Name"].ToString();
                }
                updPlan();
                getTask();
                updStore();

            }
            catch (Exception ex)
            {

            }
        }

        private void updStore()
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            A.Material_Name,
	                                            
	                                            ( SELECT COUNT ( 1 ) FROM IMOS_Lo_Bin_Detial B WHERE A.Material_Sort = B.Material_Sort ) SDQty,
                                                SUM ( A.Store_Qty ) SSQty,
                                                SUM ( A.Max_Qty ) SMQty,
	                                            SUM ( A.Max_Qty ) - SUM ( A.Store_Qty ) - ( SELECT COUNT ( 1 ) FROM IMOS_Lo_Bin_Detial B WHERE A.Material_Sort = B.Material_Sort ) XUQty 
                                            FROM
	                                            IMOS_Lo_Bin A 
                                            GROUP BY
	                                            A.Material_Name,
	                                            A.Material_Sort");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    dgv_DStore.DataSource = ds.Tables[0];
                }

            }catch(Exception ex)
            {

            }
        }

        private void getTask()
        {
            try
            {
                String msql = String.Format(@"SELECT

                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 0 Then 1 ELSE 0 END) Q0,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 1 Then 1 ELSE 0 END) Q1,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 2 Then 1 ELSE 0 END) Q2,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 3 Then 1 ELSE 0 END) Q3,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 4 Then 1 ELSE 0 END) Q4,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 5 Then 1 ELSE 0 END) Q5,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 6 Then 1 ELSE 0 END) Q6,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 7 Then 1 ELSE 0 END) Q7,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 8 Then 1 ELSE 0 END) Q8,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 9 Then 1 ELSE 0 END) Q9,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 10 Then 1 ELSE 0 END) Q10,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 11 Then 1 ELSE 0 END) Q11,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 12 Then 1 ELSE 0 END) Q12,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 13 Then 1 ELSE 0 END) Q13,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 14 Then 1 ELSE 0 END) Q14,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 15 Then 1 ELSE 0 END) Q15,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 16 Then 1 ELSE 0 END) Q16,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 17 Then 1 ELSE 0 END) Q17,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 18 Then 1 ELSE 0 END) Q18,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 19 Then 1 ELSE 0 END) Q19,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 20 Then 1 ELSE 0 END) Q20,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 21 Then 1 ELSE 0 END) Q21,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 22 Then 1 ELSE 0 END) Q22,
                                               SUM(Case WHEN DATEDIFF(hh,CONVERT(VARCHAR(50),'{1}',23),Create_Time) = 23 Then 1 ELSE 0 END) Q23
                                            From  IMOS_Lo_Task
                                            WHERE 
                                                Create_Time >= '{1}' AND Create_Time <= '{2}' AND TASK_TYPE = '{0}'  AND Material_Code !='AAAA' ", "1", lbl_StartTime.Text.ToString(), lbl_EndTime.Text.ToString());


                DataSet ds = DataHelper.Fill(msql);

                if (ds != null)
                {

                    In_Chart.Series[0].Points.Clear();
                    String m = lbl_StartTime.Text.ToString();
                    String n = lbl_EndTime.Text.ToString();
                    DateTime t1 = DateTime.Parse(m);
                    DateTime t2 = DateTime.Parse(n);
                    TimeSpan t3 = t2.Subtract(t1);
                    if (t1 <= t2)
                    {
                        for (int i = 0; i <= t3.Hours; i++)
                        {
                            string str = m.Substring(11, 2);
                            int count = int.Parse(str) + i;

                            if (count >= 24)
                            {
                                count = count - 24;
                            }
                            In_Chart.Series[0].Points.AddXY(count.ToString().PadLeft(2, '0'), ds.Tables[0].Rows[0]["Q" + i].ToString());
                            //this.chart1.Series[0].Points[1].Color = Color.Green;
                            int ch = i;
                            if (i> (t3.Hours - 1) / 2)
                            {
                                ch = Math.Abs(t3.Hours-i);
                            }

                            In_Chart.Series[0].Points[i].Color = System.Drawing.Color.FromArgb(((int)(((byte)(Math.Abs(0))))), ((int)(((byte)(Math.Abs(50-5* ch))))), ((int)(((byte)(Math.Abs(150-10*ch ))))));
                        }
                    }
                   
                   

                }
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
            catch(Exception ex)
            {

            }
        }

        #region 任务排序
        private void dgv_Task_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_Task.Rows.Count; i++)
                {
                    dgv_Task.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_Task.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                    if (int.Parse(dgv_Task.Rows[i].Cells["CNum"].Value.ToString())<10)
                    {
                        dgv_Task.Rows[i].Cells["CNum"].Style.ForeColor = Color.Lime;
                    }
                }
                dgv_Task.ClearSelection();

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void dgv_DStore_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_DStore.Rows.Count; i++)
                {
                    if (int.Parse(dgv_DStore.Rows[i].Cells["XUQty"].Value.ToString()) <= 3)
                    {
                        dgv_DStore.Rows[i].Cells["XUQty"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgv_DStore.Rows[i].Cells["XUQty"].Style.ForeColor = Color.Lime;
                    }
                }
                dgv_DStore.ClearSelection();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
