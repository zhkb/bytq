using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using Authority;

namespace Material
{
    public partial class FrmBOM : Form
    {
        private string product_code = "";
        private string product_name = "";
        public FrmBOM()
        {
            InitializeComponent();
        }

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            //AuthorityInfo FAuthorityInfo = AuthorityManager.GetAuthority(BaseSystemInfo.CurrentUserID, this.Tag.ToString());

            //btn_Add.Enabled = FAuthorityInfo.AddFlag;
            //btn_Edit.Enabled = FAuthorityInfo.EditFlag;
            //btn_Del.Enabled = FAuthorityInfo.DeleteFlag;
            dgvMain.TopLeftHeaderCell.Value = "序号";
            dgvDetail.TopLeftHeaderCell.Value = "序号";
            GetBOMMainInfo();

        }

        private void GetBOMMainInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT DISTINCT a.Material_Code,a.ID,
                                                    a.Material_Name,
                                                    b.Material_Type_Name,
                                                    Convert(Varchar(100),a.Creation_Date,120) Creation_Date,
                                                    a.Created_By,
                                                    Convert(Varchar(100),a.Last_Update_Date,120) Last_Update_Date, 
                                                    a.Last_Updated_By,a.Memo
                                                    From IMOS_TA_BOM a , IMOS_TA_Material b where 
                                        a.Company_Code = '{0}' and a.Company_Name = '{1}' and a.Factory_Code = '{2}' and a.Factory_Name = '{3}' 
                                        and a.Product_Line_Code = '{4}' and a.Product_Line_Name = '{5}'   
                                        and a.Material_Type_Code = b.Material_Type_Code",
                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                        BaseSystemInfo.ProductLineName);
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("查询BOM主表操作失败！");
                    return;
                }
                dgvMain.DataSource = ds.Tables[0];
                dgvMain.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取BOM主表信息失败！");
            }
        }

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvMain.Rows)
            {
                r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                r.HeaderCell.Value = string.Format("{0}", r.Index + 1);
            }
            dgvMain.ClearSelection();
        }

        private void dgvMain_MouseClick(object sender, MouseEventArgs e)
        {
            if(dgvMain.Rows.Count > 0)
            {
                //获取成品型号
                product_code = dgvMain.SelectedRows[0].Cells["Material_Code"].Value.ToString();
                product_name = dgvMain.SelectedRows[0].Cells["Material_Name"].Value.ToString();
                GetBOMDetailInfo();
            }           
        }

        private void GetBOMDetailInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT   DISTINCT a.Material_Code, a.Product_Code,a.Product_Name,a.Material_Name, 
                                        b.Material_Type_Name , a.Qty , Convert(Varchar(100),a.Creation_Date,120) Creation_Date , a.Created_By,
                                        Convert(Varchar(100),a.Last_Update_Date,120) Last_Update_Date , a.Last_Updated_By, a.Memo From IMOS_TA_BOM_Detail a, IMOS_TA_Material b where 
                                        a.Company_Code = '{0}' and a.Company_Name = '{1}' and a.Factory_Code = '{2}' and a.Factory_Name = '{3}' and
                                        a.Product_Line_Code = '{4}' and a.Product_Line_Name = '{5}' and a.Product_Code = '{6}' and a.Product_Name = '{7}' 
                                        and a.Material_Type_Code = b.Material_Type_Code",
                                     BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                     BaseSystemInfo.ProductLineName, product_code, product_name);
                DataSet ds = DataHelper.Fill(sql);
                dgvDetail.DataSource = ds.Tables[0];
                dgvDetail.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取BOM从表信息失败！");
            }
        }

        private void btnMainEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmBOMModify PlanForm = new FrmBOMModify();
                PlanForm.bModify = true;

                PlanForm.sMID = dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["ID"].Value.ToString();
                PlanForm.sMCode = dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                PlanForm.sMName = dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                PlanForm.sTName = dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["Material_Type_Name"].Value.ToString();

                DialogResult r = PlanForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetBOMMainInfo();
                    GetBOMDetailInfo();
                }
                PlanForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改BOM数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改BOM数据异常！，请检查数据库连接.");
            }          
        }

        private void btnMainAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"DELETE FROM IMOS_TA_BOM  where 
                                        Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}' and Factory_Name = '{3}' and
                                        Product_Line_Code = '{4}' and Product_Line_Name = '{5}'  
                                        and Material_Type_Code = '{6}'",
                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, 
                                        BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,BaseSystemInfo.Material_Type_Code);
                DataSet ds = DataHelper.Fill(sql);
                /*              FrmBOMModify ModifyForm = new FrmBOMModify();
                              ModifyForm.bModify = false;
                              DialogResult r = ModifyForm.ShowDialog();

                              if (r == DialogResult.OK)
                              {
                                  product_code = "";
                                  product_name = "";
                                  GetBOMMainInfo();
                                  GetBOMDetailInfo();
                              }

                              ModifyForm.Dispose();*/
                sql = string.Format(@"INSERT INTO [IMOS_TA_BOM]
                                                   ([Material_Code]
                                                    ,[Material_Name]
                                                    ,[Material_Type_Code]
                                                    ,[Memo]
                                                    ,[Created_By]
                                                    ,[Creation_Date]
                                                    ,[Last_Updated_By]
                                                    ,[Last_Update_Date],[Company_Code], [Company_Name], [Factory_Code], [Factory_Name], [Product_Line_Code], [Product_Line_Name]) 
                                                    (SELECT [Material_Code]
                                                    ,[Material_Name]
                                                    ,[Material_Type_Code]
                                                    ,[Memo]
                                                    ,[Created_By]
                                                    ,GETDATE()
                                                    ,[Last_Updated_By]
                                                    ,GETDATE(),[Company_Code], [Company_Name], [Factory_Code], [Factory_Name], [Product_Line_Code], [Product_Line_Name]
                                                    FROM [IMOS_TA_Material] WHERE [Material_Type_Code] = '{0}')", BaseSystemInfo.Material_Type_Code);
                ds = DataHelper.Fill(sql);
                GetBOMMainInfo();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("更新产品异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "更新产品异常！，请检查数据库连接.");
            }
        }

        private void btnMainDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.Index == -1)
                {
                    return;
                }    
                string sMID = dgvMain.Rows[dgvMain.CurrentRow.Index].Cells["Material_Code"].Value.ToString();

                string sMessage = "是否删除编号为：" + sMID + " 的BOM数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM [IMOS_TA_BOM] WHERE 
                                             [Company_Code] = '{0}' AND [Company_Name] = '{1}' AND [Factory_Code] = '{2}'
                                             AND [Factory_Name] = '{3}' AND [Product_Line_Code]  = '{4}' AND [Product_Line_Name] = '{5}'
                                             AND [Material_Code] = '{6}'", 
                                             BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, 
                                             BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                             BaseSystemInfo.ProductLineName, sMID);

                DataHelper.Fill(SqlStr);

                SqlStr = string.Format(@"DELETE FROM [IMOS_TA_BOM_Detail] WHERE [Company_Code] = '{0}' AND [Company_Name] = '{1}' AND [Factory_Code] = '{2}'
                                         AND [Factory_Name] = '{3}' AND [Product_Line_Code]  = '{4}' AND [Product_Line_Name] = '{5}'
                                         AND [Product_Code] = '{6}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode,
                                             BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                             BaseSystemInfo.ProductLineName, sMID);

                DataHelper.Fill(SqlStr);
                GetBOMMainInfo();
                GetBOMDetailInfo();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("BOM主表信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "BOM主表信息删除失败.请检查数据库连接状态.");
            }
        }

        private void btnMainClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetailEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_code.Length == 0)
                {
                    return;
                }
                if (dgvDetail.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请只选择一条数据!" );
                    return;
                }
                FrmBOMDetailModify fcm = new FrmBOMDetailModify();
                fcm.bModify = true;
                fcm.Product_Code = product_code;
                fcm.Product_Name = product_name;
                fcm.sOldMCode = dgvDetail.SelectedRows[0].Cells["Mater_Code"].Value.ToString();
                fcm.sOldMName = dgvDetail.SelectedRows[0].Cells["Mater_Name"].Value.ToString();
                fcm.Qty = int.Parse(dgvDetail.SelectedRows[0].Cells["Qty"].Value.ToString());
                DialogResult r = fcm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetBOMDetailInfo();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑BOM主表-从表对应关系信息失败！");
            }
        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_code.Length == 0)
                {
                    return;
                }
                FrmBOMDetailModify fcm = new FrmBOMDetailModify();
                fcm.bModify = false;
                fcm.Product_Code = product_code;
                fcm.Product_Name = product_name;
                fcm.Qty = 0;
                DialogResult r = fcm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetBOMDetailInfo();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加BOM主表-从表对应关系信息失败！");
            }
        }

        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_code.Length == 0)
                {
                    return;
                }
                if (dgvDetail.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请只选择一条数据!");
                    return;
                }
                string sMID = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["Mater_Code"].Value.ToString();
                string sMessage = "是否删除物料编号为【" + sMID + "】的从表数据?";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                String sql = String.Format(@"DELETE FROM [IMOS_TA_BOM_Detail] WHERE [Company_Code] = '{0}' AND [Company_Name] = '{1}' AND [Factory_Code] = '{2}'
                                             AND [Factory_Name] = '{3}' AND [Product_Line_Code]  = '{4}' AND [Product_Line_Name] = '{5}'
                                             AND [Product_Code] = '{6}' AND [Material_Code] = '{7}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode,
                                             BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                             BaseSystemInfo.ProductLineName, product_code , sMID);
                DataHelper.Fill(sql);
                GetBOMDetailInfo();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("删除BOM主表-从表对应关系信息失败！");
            }
        }

        private void btnDetailClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvDetail.Rows)
            {
                r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                r.HeaderCell.Value = string.Format("{0}", r.Index + 1);
            }
            dgvDetail.ClearSelection();
        }
    
    }
}
