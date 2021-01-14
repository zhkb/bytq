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
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    using Authority;

    public partial class FrmMaterial : Form
    {
        private DataSet MasterDataSet = new DataSet();

        public FrmMaterial()
        {
            InitializeComponent();
            dgvCommon.TopLeftHeaderCell.Value = "序号";
        }

        private void GetMaterialData(string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT a.material_id,a.[Material_Code],a.[Material_Name],a.Material_Type_Name,a.Material_Spec,Material_Unit,a.Remark,
                                                Convert(Varchar(100),a.Creation_Date,120) Create_Time ,a.Created_By,Convert(Varchar(100),a.Last_Update_Date,120) Modify_Time ,a.Last_Updated_By
                                                FROM IMOS_TA_Material a 
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and (a.Material_Name like '%{3}%' or a.Material_Type_Name like '%{3}%' or a.Remark like '%{3}%')
                                                order by a.Last_Update_Date desc",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sKey);
 
                MasterDataSet = DataHelper.Fill(SqlStr);

                dgvCommon.DataSource = MasterDataSet.Tables[0];

                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void FrmMaterial_Load(object sender, EventArgs e)
        {
            AuthorityInfo FAuthorityInfo = AuthorityManager.GetAuthority(BaseSystemInfo.CurrentUserID,this.Tag.ToString());

            btn_Add.Enabled = FAuthorityInfo.AddFlag;
            btn_Edit.Enabled = FAuthorityInfo.EditFlag;
            btn_Del.Enabled = FAuthorityInfo.DeleteFlag;
            GetMaterialData("");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaterialModify ModifyForm = new FrmMaterialModify();
                ModifyForm.bModify = false;
                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMaterialData("");
                }

                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加物料异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加物料异常！，请检查数据库连接.");
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCommon.CurrentRow == null || dgvCommon.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmMaterialModify PlanForm = new FrmMaterialModify();
                PlanForm.bModify = true;

                PlanForm.sMID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_ID"].Value.ToString();
                PlanForm.sMCode = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                PlanForm.sMName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                PlanForm.sTName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Type_Name"].Value.ToString();
                PlanForm.sSpesc = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Spec"].Value.ToString();
                PlanForm.sUnit = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Unit"].Value.ToString();
                PlanForm.sDesc = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Remark"].Value.ToString();

                DialogResult r = PlanForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMaterialData("");
                }
                PlanForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改物料数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改物料数据异常！，请检查数据库连接.");
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCommon.CurrentRow == null || dgvCommon.CurrentRow.Index == -1)
                {
                    return;
                }

                string sMID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Code"].Value.ToString();

                string sMessage = "是否删除编号为：" + sMID + " 的物料数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM [IMOS_TA_Material] WHERE [Material_Code] = '{0}'", sMID);

                DataHelper.Fill(SqlStr);


                GetMaterialData("");
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("物料信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料信息删除失败.请检查数据库连接状态.");
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMaterial_Activated(object sender, EventArgs e)
        {
            // GetMaterialData("");
            //OptionSetting.MenuTitle = "物料管理";
        }
    }
}
