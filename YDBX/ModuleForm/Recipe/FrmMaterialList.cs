using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Recipe
{
    using Sys.DbUtilities;
    using Sys.Config;
    public partial class FrmMaterialList : Form
    {

        public string MaterialCode = "";
        public string MaterialName = "";
        public string MaterialSpec = "";
        public string MaterialTypeCode = "";
        public string MaterialTypeName = "";

        public FrmMaterialList()
        {
            InitializeComponent();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMaterialList_Load(object sender, EventArgs e)
        {
            try
            {
                GetMaterialList(txt_KeyInfo.Text);
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetMaterialList(txt_KeyInfo.Text);
        }

        private void GetMaterialList(string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT a.[Material_Code],a.[Material_Name],a.Material_Type_Code,a.Material_Type_Name,a.Material_Spec,Material_Unit,a.Remark
                                                FROM IMOS_TA_Material a 
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and (a.Material_Code like '%{3}%' or  a.Material_Name like '%{3}%' or a.Material_Type_Name like '%{3}%' or a.Remark like '%{3}%')
                                                order by a.Material_Name", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sKey);

                DataSet MasterDataSet = DataHelper.Fill(SqlStr);

                dgv_Material.DataSource = MasterDataSet.Tables[0];

                dgv_Material.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_Material.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch(Exception ex )
            { }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_Material_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            dgv_Material_CellDoubleClick(null,null);

        }

        private void dgv_Material_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Material.CurrentRow == null || dgv_Material.CurrentRow.Index == -1)
                {
                    return;
                }

                MaterialCode = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                MaterialName = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                MaterialSpec = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Spec"].Value.ToString();
                MaterialTypeName = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Type_Name"].Value.ToString();
                MaterialTypeCode = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Type_Code"].Value.ToString();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
