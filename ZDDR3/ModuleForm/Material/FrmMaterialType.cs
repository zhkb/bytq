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

    public partial class FrmMaterialType : Form
    {
        private DataSet MasterDataSet = new DataSet();

        public FrmMaterialType()
        {
            InitializeComponent();
            dgvCommon.TopLeftHeaderCell.Value = "序号";
        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }


        private void FrmMaterialType_Load(object sender, EventArgs e)
        {
            GetMaterialTypeData("");
        }

        private void GetMaterialTypeData(string sKey)
        {
            try
            {
                string SqlStr = @"SELECT [Type_Code]
                                 ,[Type_Name]
                                 ,[Type_Desc]
                                 ,Convert(Varchar(100),Create_Time,120) Create_Time 
                                 ,[Create_User]
                                 ,Convert(Varchar(100),Modify_Time,120) Modify_Time 
                                 ,[Modify_User]
                                 FROM [Mixing_MaterialType] ";
                if (sKey.Length != 0)
                {
                    string sWhereMask = " where Type_Code like '%{0}%' or Type_Name like '%{1}%' or Type_Desc like '%{2}%' ";
                    string sWhere = string.Format(sWhereMask, sKey, sKey, sKey);
                    SqlStr += sWhere;
                }
                string sOrder = " order by Create_Time desc ";
                SqlStr += sOrder;

                MasterDataSet = DataHelper.Fill(SqlStr);

                dgvCommon.DataSource = MasterDataSet.Tables[0];

                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("查询物料类型失败，" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaterialTypeModify ModifyForm = new FrmMaterialTypeModify();
                ModifyForm.bModify = false;
                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMaterialTypeData("");
                }

                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加物料类型异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加物料类型异常！，请检查数据库连接.");
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

                FrmMaterialTypeModify PlanForm = new FrmMaterialTypeModify();
                PlanForm.bModify = true;

                PlanForm.sTID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Type_Code"].Value.ToString();
                PlanForm.sTName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Type_Name"].Value.ToString();
                PlanForm.sDesc = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Type_Desc"].Value.ToString();

                DialogResult r = PlanForm.ShowDialog();

                if (r == DialogResult.OK)
                {

                    GetMaterialTypeData("");
                }
                PlanForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改物料类型异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改物料类型异常！，请检查数据库连接.");
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

                string sTID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Type_Code"].Value.ToString();

                string sMessage = "是否删除编号为：" + sTID + " 的物料类型？";
                if (SysBusinessFunction.SystemDialog(
                    SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM [Mixing_MaterialType] WHERE [Type_Code] = '{0}'", sTID);

                DataHelper.Fill(SqlStr);


                GetMaterialTypeData("");
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

        private void FrmMaterialType_Activated(object sender, EventArgs e)
        {
            //  OptionSetting.MenuTitle = "物料类型";
        }
    }
}
