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
    using ControlLogic.Control;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using System.Threading;

    public partial class FrmStoreMonitor : Form
    {
       
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FrmStoreMonitor()
        {
            InitializeComponent();
            dgvLeftBin.TopLeftHeaderCell.Value = "序号";
            dgvRightBin.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmStoreMonitor_Load(object sender, EventArgs e)
        {
            try
            {
               
                //ControlMaster.SystemInitialization();
                //ControlInStore.SystemInitialization();
                //ControlOutStore.SystemInitialization();
                timer1.Enabled = true;
                timer1.Interval = 5000;
                timer1.Start();
                timer2.Enabled = true;
                timer2.Interval = 5000;
                timer2.Start();
                for (int i = 0; i < 16; i++)
                {
                    FrmBinMonitor TempForm = new FrmBinMonitor();
                    TempForm.TopLevel = false;
                    TempForm.Parent = panel4;
                    TempForm.FormBorderStyle = FormBorderStyle.None;
                    TempForm.Height = 30;                 
                    TempForm.Width = 950;
                    TempForm.Top = i * 30;
                    TempForm.Left  = 0;
                    TempForm.BinNo = (10*i);
                    TempForm.Show();
                }
                for (int i = 0; i < 16; i++)
                {
                    FrmBinMonitor TempForm = new FrmBinMonitor();
                    TempForm.TopLevel = false;
                    TempForm.Parent = panel3;
                    TempForm.FormBorderStyle = FormBorderStyle.None;
                    TempForm.Height = 30;
                    TempForm.Width = 950;
                    TempForm.Top = i * 30;
                    TempForm.Left =10;
                    TempForm.BinNo = 160+(10 * i);
                    TempForm.Show();
                }
            }
            catch
            { 
            
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //获取数据库数据
                String sql = String.Format(@"SELECT
	                                            STORE_SORT,
	                                            MATERIAL_STATE,
                                                DELETE_FLAG
                                            FROM
	                                            IMOS_LO_STORE_BIN_DETIAL
                                            WHERE
	                                            STORE_CODE = 'D0001'
                                            OR STORE_CODE = 'D0002'");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    OptionSetting.BinDetaildt = ds.Tables[0];
                }
                upStoreData("D0001");
                upStoreData("D0002");


            }
            catch(Exception ex)
            {

            }
        }
        private void upStoreData(String storecode)
        {
            String selsql = String.Format(@"SELECT
	                                                MATERIAL_CODE,
	                                                MATERIAL_NAME,
	                                                SUM(case when MATERIAL_STATE=0 OR MATERIAL_STATE = 4 then 1 else 0 end) ZT,
	                                                SUM(case when MATERIAL_STATE=1 OR MATERIAL_STATE = 2 OR MATERIAL_STATE = 3  then 1 else 0 end) RK
                                                FROM
	                                                IMOS_LO_STORE_BIN_DETIAL
                                                WHERE
	                                                STORE_CODE = '{0}'
                                                AND MATERIAL_STATE != {1}
                                                GROUP BY
	                                                MATERIAL_CODE,
	                                                MATERIAL_NAME ", storecode,"9");
            DataSet leftds = DataHelper.Fill(selsql);
            if (leftds != null)
            {
                if (storecode == "D0001")
                {
                    dgvLeftBin.DataSource = leftds.Tables[0];
                }
                else
                {
                    dgvRightBin.DataSource = leftds.Tables[0];
                }
                
            }
        }


        private void dgvLeftBin_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch(Exception ex)
            {

            }
        }

        private void dgvRightBin_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                        STORE_SORT,
                                            MATERIAL_BARCODE,
	                                        MATERIAL_CODE,
	                                        MATERIAL_NAME
                                        FROM
	                                        IMOS_LO_STORE_BIN_DETIAL
                                        WHERE
	                                        MATERIAL_STATE = '3'
                                        ORDER BY 
                                        	F_LASTMODIFYTIME DESC");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lbl_MaterialBarCode.Text = ds.Tables[0].Rows[0]["MATERIAL_BARCODE"].ToString();
                    lbl_Store_Sort.Text = ds.Tables[0].Rows[0]["STORE_SORT"].ToString();
                    lbl_Material_Code.Text = ds.Tables[0].Rows[0]["MATERIAL_CODE"].ToString();
                    lbl_Material_Name.Text = ds.Tables[0].Rows[0]["MATERIAL_NAME"].ToString();
                    lbl_Msg.Text = "正在出库";
                }
            }catch(Exception ex)
            {

            }
        }


    }
}
