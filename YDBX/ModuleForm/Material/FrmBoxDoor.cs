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
    public partial class FrmBoxDoor : Form
    {
        private DataSet MasterDataSet = new DataSet();
        public FrmBoxDoor()
        {
            InitializeComponent();
            dgvCommon.TopLeftHeaderCell.Value = "序号";
        }
        private void GetMaterialData(string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"SELECT a.[ID],a.[Box_Code],a.[Box_Name],a.Door_Code,a.Door_Name,
                                                Convert(Varchar(100),a.Create_time,120) Create_time ,a.Create_By,
                                                Convert(Varchar(100),a.Last_Update_Date,120) Last_Update_Date ,a.Last_Updated_By
                                                FROM IMOS_TA_Match_Record a 
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and (a.Box_Code like '%{3}%' or a.Box_Name like '%{3}%')
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

        private void dgvCommon_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void FrmWeighStandard_Load(object sender, EventArgs e)
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
                FrmBoxDoorMatchModify ModifyForm = new FrmBoxDoorMatchModify();
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

                FrmBoxDoorMatchModify PlanForm = new FrmBoxDoorMatchModify();
                PlanForm.bModify = true;

                PlanForm.sMID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["ID"].Value.ToString();
                PlanForm.sMCode = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Box_Code"].Value.ToString();
                PlanForm.sMName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Box_Name"].Value.ToString();
                PlanForm.sdoorcode = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Door_Code"].Value.ToString();
                PlanForm.sdoorname = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Door_Name"].Value.ToString();
                

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

                string sMID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Box_Code"].Value.ToString();

                string sMessage = "是否删除编号为：" + sMID + " 的物料数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM [IMOS_TA_Match_Record] WHERE [Box_Code] = '{0}'", sMID);

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
    }
}
