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
    public partial class FrmFPMonitor : Form
    {
        public int mco = 1;
        public FrmFPMonitor()
        {
            InitializeComponent();
        }

        private void FrmFPMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();
            }catch(Exception ex)
            {

            }
        }

        private void LoadData()
        {
            try
            {
                String sql = String.Format(@"SELECT TOP 8
                                                A.ID,
	                                            (Case When (A.Use_Flag = '1') THEN '正在出库'  ELSE '等待出库' END ) Use_Flag, 
	                                            BB.Material_Name,
	                                            ( CASE WHEN ( A.ID - {0} < 0 ) THEN A.ID ELSE ID - 26 END ) MX 
                                            FROM
	                                            IMOS_Lo_FP_List AS A
	                                            LEFT JOIN IMOS_TA_Material AS BB ON A.Material_Sort = BB.Material_Sort 
                                            WHERE
	                                            A.ID >= {0}  
	                                            OR A.ID < 8- ( 26-{0}) 
                                            ORDER BY
	                                            MX", mco);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    dgv_fp.DataSource = ds.Tables[0];
                }
            }catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT 
                                                A.ID,
                                                BB.Material_Name
                                            FROM
	                                            IMOS_Lo_FP_List A Left Join 
                                                IMOS_TA_Material BB ON 
                                                A.Material_Sort = BB.Material_Sort
                                            WHERE
	                                            A.Use_Flag = {0}", "1");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    mco = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    lbl_Code.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                    lbl_Name.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                }
                LoadData();

            }
            catch(Exception ex)
            {

            }
        }

        private void dgv_fp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach(DataGridViewRow dr in dgv_fp.Rows)
                {
                    if (dr.Cells["Use_Flag"].Value.ToString() == "正在出库")
                    {
                        dr.Cells["Use_Flag"].Style.ForeColor = Color.Lime;
                    }
                    else
                    {
                        dr.Cells["Use_Flag"].Style.ForeColor = Color.Red;
                    }
                }

            }catch(Exception ex)
            {

            }
        }
    }
}
