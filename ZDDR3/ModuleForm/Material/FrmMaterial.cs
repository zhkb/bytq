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
                string SqlStr = string.Format(@"SELECT a.material_id,a.[Material_Code]
                                 ,a.[Material_Name]
                                 ,b.[Type_Name]
                                 ,a.[Material_Desc]
                                ,a.[P_Voltage]
                                ,a.[P_Capacity]
                                ,a.[P_Frequency]
                                ,a.[P_Temperature]
                                ,a.[P_Water]
                                ,a.[P_3D]
                                ,a.[P_Waterproof]
                                ,a.[P_Internal]
                                ,a.[Pic_Path]
                                 ,Convert(Varchar(100),a.Create_Time,120) Create_Time 
                                 ,a.[Create_User]
                                 ,Convert(Varchar(100),a.Modify_Time,120) Modify_Time 
                                 ,a.[Modify_User]
                                 FROM [Mixing_Material] a, [Mixing_MaterialType] b
                                where a.Type_Code=b.Type_Code
                                and Company_Code = '{0}' and Factory_Code = '{1}' and ProductLine_Code = '{2}'
                                and (a.Material_Name like '%{3}%' or a.Material_Desc like '%{3}%')",
                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sKey);
                string sOrder = " order by Create_Time desc ";
                SqlStr += sOrder;

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

            AuthorityInfo FAuthorityInfo = AuthorityManager.GetAuthority(BaseSystemInfo.CurrentUserID, this.Tag.ToString());

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
                PlanForm.sTName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Type_Name"].Value.ToString();
                PlanForm.sDesc = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Desc"].Value.ToString();

                PlanForm.sP_Voltage = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Voltage"].Value.ToString();
                PlanForm.sP_Capacity = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Capacity"].Value.ToString();
                PlanForm.sP_Frequency = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Frequency"].Value.ToString();
                PlanForm.sP_Temperature = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Temperature"].Value.ToString();
                PlanForm.sP_Water = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Water"].Value.ToString();
                PlanForm.sP_3D = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_3D"].Value.ToString();
                PlanForm.sP_Waterproof = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Waterproof"].Value.ToString();
                PlanForm.sP_Internal = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["P_Internal"].Value.ToString();
                PlanForm.sP_Pic_Path = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Pic_Path"].Value.ToString();

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

                string SqlStr = string.Format(@"DELETE FROM [Mixing_Material] WHERE [Material_Code] = '{0}'", sMID);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT a.id,a.Material_Code
                                 ,a.Material_Name
                                 FROM IMOS_MES_Material a");


                MasterDataSet = DataHelper.MySqlFill(SqlStr);

                dgvCommon.DataSource = MasterDataSet.Tables[0];

                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }

        }
    }
}
