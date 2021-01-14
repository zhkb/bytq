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

namespace Material
{
    public partial class FrmStoreMonitor : Form
    {
        private bool editflag = true;
        public FrmStoreMonitor()
        {
            InitializeComponent();
        }

        private void FrmStoreMonitor_Load(object sender, EventArgs e)
        {
            getStoreBinInfo();
        }

        private void getStoreBinInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            Material_Code,
	                                            Material_Name,
	                                            Area_Code,
	                                            Area_Name,
	                                            Store_Code,
	                                            Store_Qty,
	                                            Transit_Qty,
	                                            Max_Qty,
	                                            Use_Flag,
	                                            Convert(varchar(50),Create_Time,120)Create_Time,
	                                            Convert(varchar(50),Update_Time,120)Update_Time
                                            FROM
	                                            IMOS_Lo_Bin
                                            WHERE
	                                            Area_Code = '{0}'", BaseSystemInfo.AreaCode);
                DataSet ds = DataHelper.Fill(sql);
                if(ds != null)
                {
                    dgvCommon.DataSource = ds.Tables[0];
                    dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                    dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                  
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvCommon_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            for (int i = 0; i < dgvCommon.Rows.Count; i++)
            {
                
                dgvCommon.Rows[i].Cells[2].Value = "编辑";
            }
        }

        private void dgvCommon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {

                if ("编辑".Equals(dgvCommon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    dgvCommon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "确认";
                    dgvCommon.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvCommon.Columns[3].ReadOnly = false;
                    dgvCommon.Columns[4].ReadOnly = false;
                    dgvCommon.Columns[11].ReadOnly = false;
                }
                else
                {
                    dgvCommon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "编辑";
                    dgvCommon.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    dgvCommon.Columns[3].ReadOnly = true;
                    dgvCommon.Columns[4].ReadOnly = true;
                    dgvCommon.Columns[11].ReadOnly = true;
                }
            }
            
        }
    }
}
