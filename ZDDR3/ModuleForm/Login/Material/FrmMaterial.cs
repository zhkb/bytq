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

    public partial class FrmMaterial : Form
    {
        private DataSet MasterDataSet = new DataSet();
       
        public FrmMaterial()
        {
            InitializeComponent();
            dgvCommon.TopLeftHeaderCell.Value = "序号";
        }

        private void GetMaterialData(string sKey)//按照条件进行订单数据查询 and Is_Finish = 1
        {
            try
            {
                string SqlStr = @"SELECT a.[Material_Code]
                                 ,a.[Material_Name]
                                 ,b.[Type_Name]
                                 ,a.[Batch_No]
                                 ,a.[Material_Desc]
                                 ,Convert(Varchar(100),a.Create_Time,120) Create_Time 
                                 ,a.[Create_User]
                                 ,Convert(Varchar(100),a.Modify_Time,120) Modify_Time 
                                 ,a.[Modify_User]
                                 FROM [Mixing_Material] a, [Mixing_MaterialType] b
                                where a.Type_Code=b.Type_Code";
                if (sKey.Length != 0)
                {
                    string sWhereMask = " and (a.Material_Name like '%{0}%' or a.Batch_No like '%{1}%' or a.Material_Desc like '%{2}%') ";
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
            catch(Exception ex)
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

                PlanForm.sMID = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                PlanForm.sMName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                PlanForm.sTName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Type_Name"].Value.ToString();
                PlanForm.sBatch = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Batch_No"].Value.ToString();
                PlanForm.sDesc = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Desc"].Value.ToString();

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
                if (SysBusinessFunction.SystemDialog(
                    SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
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
    }
}
