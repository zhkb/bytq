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

namespace Material
{
    public partial class FrmMaterialSelect : Form
    {
        public string MaterialType = "MN001";
        public string MaterialID = "";
        public string MaterialCode = "";
        public string MaterialName = "";
        public FrmMaterialSelect()
        {
            InitializeComponent();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_SearchText.Text = "";
            GetData(MaterialType);
        }
        public void GetData(string strMaterialType) //MN001
        {
            string strKey = "";
            strKey = txt_SearchText.Text.Trim();
            DataSet DBDataSet = new DataSet();
            string SelectSql = string.Format(@"select a.Material_ID,
                                     a.Material_Code,
                                     a.Material_Name 
                                   from [IMOS_TA_Material] a
                          
                                  where  a.Material_Type_Code='{1}' and (a.Material_Name like '%{0}%' or  a.Material_Code like '%{0}%' ) ", strKey, MaterialType);
        
            DBDataSet = DataHelper.Fill(SelectSql);

            PartGrid.DataSource = DBDataSet.Tables[0].DefaultView;

            PartGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            PartGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            DBDataSet.Dispose();
        }

        private void btn_Cance_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            PartGrid_CellDoubleClick(null,null);
        }

        private void PartGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (PartGrid.Rows.Count == 0)
                {
                    return;
                }
                MaterialID = PartGrid.Rows[PartGrid.CurrentRow.Index].Cells["Material_ID"].Value.ToString();
                MaterialCode = PartGrid.Rows[PartGrid.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                MaterialName = PartGrid.Rows[PartGrid.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                DialogResult = DialogResult.OK;

            }
            catch
            {
                return;
            }
        }

        private void FrmMaterialSelect_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            GetData(MaterialType);
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            GetData(MaterialType);
        }
    }
}
