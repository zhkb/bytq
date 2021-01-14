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
    public partial class FrmSetPlan : Form
    {
        public FrmSetPlan()
        {
            InitializeComponent();
            dgv_Plan.TopLeftHeaderCell.Value = "序号";
        }

        private void btn_Add_Plan_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSetPlanModify fspm = new FrmSetPlanModify();
                fspm.ModifyFlag = false;
                DialogResult r = fspm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    getData();
                }

                fspm.Dispose();
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Del_Plan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Plan.CurrentRow == null || dgv_Plan.CurrentRow.Index == -1)
                {
                    return;
                }
                String sql = String.Format(@"UPDATE  IMOS_TA_Material Set Material_Plan_Num = {0} WHERE Material_Code = '{1}'", 0,
                                               dgv_Plan.Rows[dgv_Plan.CurrentRow.Index].Cells["Material_Code"].Value.ToString());

                DataHelper.Fill(sql);
                getData();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Upd_Plan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Plan.CurrentRow == null || dgv_Plan.CurrentRow.Index == -1)
                {
                    return;
                }
                FrmSetPlanModify fspm = new FrmSetPlanModify();
                fspm.ModifyFlag = true;
                fspm.MaterialCode = dgv_Plan.Rows[dgv_Plan.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                fspm.MaterialName = dgv_Plan.Rows[dgv_Plan.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                fspm.MaterialNum = int.Parse(dgv_Plan.Rows[dgv_Plan.CurrentRow.Index].Cells["Material_Plan_Num"].Value.ToString());
                DialogResult r = fspm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    getData();
                }

                fspm.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmSetPlan_Load(object sender, EventArgs e)
        {
            try
            {
                getData();
            }
            catch(Exception ex)
            {

            }
        }

        private void getData()
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name,Material_Plan_Num FROM IMOS_TA_Material WHERE Material_Plan_Num != 0 Order By Material_Sort");
                DataSet ds = DataHelper.Fill(sql);
                dgv_Plan.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {

            }
        }

        private void dgv_Plan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_Plan.Rows.Count; i++)
                {
                    dgv_Plan.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_Plan.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);

                }
                dgv_Plan.ClearSelection();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
