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
    using FastReport;

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
                string SqlStr = string.Format(@"SELECT a.material_id,a.[Material_Code],a.[Material_Name],a.Material_Sort,
                                                a.Line_No,a.Line_Name     
                                                FROM IMOS_TA_Material a 
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and Material_Sort !='{3}'
                                                order by a.Material_Sort ",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,"99");
 
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
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }catch(Exception ex)
            {

            }
        
        }

        private void FrmMaterial_Load(object sender, EventArgs e)
        {
            //AuthorityInfo FAuthorityInfo = AuthorityManager.GetAuthority(BaseSystemInfo.CurrentUserID,this.Tag.ToString());

            //btn_Add.Enabled = FAuthorityInfo.AddFlag;
            //btn_Edit.Enabled = FAuthorityInfo.EditFlag;
            //btn_Del.Enabled = FAuthorityInfo.DeleteFlag;
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
                PlanForm.sMSort = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Material_Sort"].Value.ToString();
                PlanForm.sMLineNo = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Line_No"].Value.ToString();
                PlanForm.sMLineName = dgvCommon.Rows[dgvCommon.CurrentRow.Index].Cells["Line_Name"].Value.ToString();

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

        private void btn_StirPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FastReport.Report report = new FastReport.Report();
                string filename = @"5Material_QRCode.frx";
                report.Load(filename);
                string SqlStr = string.Format(@"SELECT Material_Code , Material_Name
                                                FROM IMOS_TA_Material 
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'                                                
                                                order by Last_Update_Date desc",
                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataSet ds = DataHelper.Fill(SqlStr);
                report.RegisterData(ds.Tables[0], "IMOS_TA_Material");
                DataBand masterBand = report.FindObject("Data1") as DataBand;
                masterBand.DataSource = report.GetDataSource("IMOS_TA_Material");
                report.Show(true);
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("物料二维码打印出错," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料二维码溯打印出错");
            }
        }
    }
}
