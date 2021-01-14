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
using System.Windows.Forms;

namespace PickingMonitor
{
    public partial class FrmNewStoreMonitor : Form
    {
        public FrmNewStoreMonitor()
        {
            InitializeComponent();
        }

        private void FrmNewStoreMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Interval = 5000;
                timer1.Start();
                timer2.Enabled = true;
                timer2.Interval = 1000;
                timer2.Start();
                timer3.Enabled = true;
                timer3.Interval = 1000;
                timer3.Start();
                for (int i = 0; i < 16; i++)
                {
                    FrmBinMonitor TempForm = new FrmBinMonitor();
                    TempForm.TopLevel = false;
                    TempForm.Parent = panel7;
                    TempForm.FormBorderStyle = FormBorderStyle.None;
                    TempForm.Height = 30;
                    TempForm.Width = 950;
                    TempForm.Top = i * 30;
                    TempForm.Left = 0;
                    TempForm.BinNo = (10 * i);
                    TempForm.Show();
                }
                for (int i = 0; i < 16; i++)
                {
                    FrmBinMonitor TempForm = new FrmBinMonitor();
                    TempForm.TopLevel = false;
                    TempForm.Parent = panel6;
                    TempForm.FormBorderStyle = FormBorderStyle.None;
                    TempForm.Height = 30;
                    TempForm.Width = 950;
                    TempForm.Top = i * 30;
                    TempForm.Left = 10;
                    TempForm.BinNo = 160 + (10 * i);
                    TempForm.Show();
                }
            }
            catch(Exception ex)
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
                upStoreData();
            }
            catch(Exception ex)
            {

            }
        }

        private void upStoreData()
        {
            try
            {
                String selsql = String.Format(@"SELECT
	                                                MATERIAL_CODE,
	                                                MATERIAL_NAME,
	                                                SUM(case when MATERIAL_STATE != 9 AND  MATERIAL_STATE != 4   then 1 else 0 end) Store_Qty
                                                FROM
	                                                IMOS_LO_STORE_BIN_DETIAL
                                                WHERE
	                                                (STORE_CODE = '{0}' or
                                                STORE_CODE = '{1}')
                                                AND MATERIAL_STATE != {2}
                                                GROUP BY
	                                                MATERIAL_CODE,
	                                                MATERIAL_NAME ", BaseSystemInfo.StoreCode1, BaseSystemInfo.StoreCode2, "9");
                DataSet ds = DataHelper.Fill(selsql);
                StoreChart.Series[0].Points.Clear();
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                          StoreChart.Series[0].Points.AddXY(ds.Tables[0].Rows[i]["MATERIAL_NAME"].ToString(), Double.Parse(ds.Tables[0].Rows[i]["Store_Qty"].ToString()));
                    }

                }
            }
            catch(Exception ex)
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = getDataSet("0", BaseSystemInfo.StoreCode1,1);
                if (ds!=null&&ds.Tables[0].Rows.Count>0)
                {
                    lbl_RK1_StoreCode.Text = ds.Tables[0].Rows[0]["STORE_SORT"].ToString();
                    lbl_RK1_Row.Text = ds.Tables[0].Rows[0]["STORE_ROW"].ToString()+"排";
                    lbl_RK1_Column.Text = ds.Tables[0].Rows[0]["STORE_COLUMN"].ToString() + "列";
                    lbl_RK1_Tier.Text = ds.Tables[0].Rows[0]["STORE_TIER"].ToString() + "层";
                    lbl_RK1_MName.Text = ds.Tables[0].Rows[0]["MATERIAL_NAME"].ToString();
                }
                ds = getDataSet("0", BaseSystemInfo.StoreCode1, 2);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lbl_RK2_StoreCode.Text = ds.Tables[0].Rows[0]["STORE_SORT"].ToString();
                    lbl_RK2_Row.Text = ds.Tables[0].Rows[0]["STORE_ROW"].ToString() + "排";
                    lbl_RK2_Column.Text = ds.Tables[0].Rows[0]["STORE_COLUMN"].ToString() + "列";
                    lbl_RK2_Tier.Text = ds.Tables[0].Rows[0]["STORE_TIER"].ToString() + "层";
                    lbl_RK2_MName.Text = ds.Tables[0].Rows[0]["MATERIAL_NAME"].ToString();
                }
                ds = getDataSet("3", BaseSystemInfo.StoreCode1, 3);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lbl_CK_StoreCode.Text = ds.Tables[0].Rows[0]["STORE_SORT"].ToString();
                    lbl_CK_Row.Text = ds.Tables[0].Rows[0]["STORE_ROW"].ToString() + "排";
                    lbl_CK_Column.Text = ds.Tables[0].Rows[0]["STORE_COLUMN"].ToString() + "列";
                    lbl_CK_Tier.Text = ds.Tables[0].Rows[0]["STORE_TIER"].ToString() + "层";
                    lbl_CK_MName.Text = ds.Tables[0].Rows[0]["MATERIAL_NAME"].ToString();
                }

            }
            catch (Exception ex)
            {

            }
        }
        private DataSet getDataSet(String state,String storecode,int getTy)
        {
            String str = "";
            if (getTy == 1)//入库1
            {
                str = " AND STORE_SORT <= 160 ";
            }
            else if(getTy == 2)//入库2
            {
                str = " AND STORE_SORT > 160 ";
            }
            else if(getTy == 3)//出库
            {
                str = " ";
            }
            String sql = String.Format(@"SELECT
                                                MATERIAL_NAME,
	                                            STORE_SORT,
	                                            STORE_ROW,
	                                            STORE_COLUMN,
	                                            STORE_TIER
                                            FROM
	                                            IMOS_LO_STORE_BIN_DETIAL
                                            WHERE
	                                            MATERIAL_STATE = '{0}'
                                            AND STORE_CODE = '{1}'
                                            {2}
                                            ORDER BY
	                                            IN_TIME DESC", state,storecode,str);
            DataSet ds = DataHelper.Fill(sql);
            return ds;
        }
    }
}
