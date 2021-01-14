using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Option
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;

    using Sys.Config;
    public partial class FrmMenu : Form
    {

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmSysSet_Load(object sender, EventArgs e)
        {
            GetMenuParamData();
            dgv_Menu.TopLeftHeaderCell.Value = "序号";
            dgv_Module.TopLeftHeaderCell.Value = "序号";

            if (dgv_Menu.CurrentRow.Index >= 0)
            {
                string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                //加载模块信息
                GetModuleParamData(sMenuCode);
            }

        }

        private void btn_Menu_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMenuModify BaseModifyForm = new FrmMenuModify();
                BaseModifyForm.ModifyState = true;
                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMenuParamData();
                    ClearModuleList();
                    if (dgv_Menu.CurrentRow.Index >= 0)
                    {
                        string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                        GetModuleParamData(sMenuCode);
                    }
                }

                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加菜单异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加菜单异常！，请检查数据库连接.");
            }
        }

        private void btn_Menu_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Menu.CurrentRow == null || dgv_Menu.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmMenuModify BaseModifyForm = new FrmMenuModify();
                BaseModifyForm.ModifyState = false;

                BaseModifyForm.strMenuId = Convert.ToInt32(dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_ID"].Value);
                BaseModifyForm.strMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                BaseModifyForm.strMenuName = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Name"].Value.ToString();
                BaseModifyForm.strMenuNameEN = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Name_EN"].Value.ToString();
                BaseModifyForm.strMenuSort = Convert.ToInt32(dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Sort"].Value);
                BaseModifyForm.strMenuMark = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Remark"].Value.ToString();

                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMenuParamData();
                    ClearModuleList();
                    if (dgv_Menu.CurrentRow.Index >= 0)
                    {
                        string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                        GetModuleParamData(sMenuCode);
                    }
                }
                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改菜单数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改菜单数据异常！，请检查数据库连接.");
            }
        }

        private void btn_Menu_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Menu.CurrentRow == null || dgv_Menu.CurrentRow.Index == -1)
                {
                    return;
                }

                string sMenuID = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_ID"].Value.ToString();
                string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();

                string sMessage = "是否删除编号为：" + sMenuCode + " 的菜单数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM dbo.Sys_BaseMenu 
                                              where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' and Menu_Code = '{3}'",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMenuCode);
                DataHelper.Fill(SqlStr);

                SqlStr = string.Format(@"DELETE FROM dbo.Sys_BaseModule 
                                         where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' and  Menu_Code = {3}",
                                         BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMenuCode);
                DataHelper.Fill(SqlStr);


                //删除权限相关无菜单信息的记录
                string DelAuthority = string.Format(" Exec [DeleteAuthorityRecord]  '{0}','{1}','{2}','{3}','{4}','{5}'",
                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
                DataHelper.Fill(DelAuthority);

                GetMenuParamData();
                ClearModuleList();
                if (dgv_Menu.CurrentRow.Index >= 0)
                {
                    sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                    GetModuleParamData(sMenuCode);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("菜单信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单信息删除失败.请检查数据库连接状态.");
            }
        }

        private void btn_Menu_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetMenuParamData()
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"select a.Menu_ID, a.Menu_Code, a.Menu_Name, a.Menu_Name_EN, a.Menu_Sort, a.Remark, 
                                                Convert(varchar(20),a.Creation_Date,120)Creation_Date, b.User_Name Create_User_Name, 
                                                Convert(varchar(20),a.Last_Update_Date,120)Last_Update_Date, c.User_Name Edit_User_Name
                                                from dbo.Sys_BaseMenu a left join Sys_BaseUser b on (a.Company_Code = b.Company_Code and a.Factory_Code = b.Factory_Code and a.product_line_code = b.Product_Line_Code and  a.Created_By = b.User_ID)
                                                left join Sys_BaseUser c on (a.Company_Code = c.Company_Code and a.Factory_Code = c.Factory_Code and a.product_line_code = c.Product_Line_Code and  a.Last_Updated_By = c.User_ID)
                                                where a.Company_Code='{0}'and a.Factory_Code='{1}' and a.product_line_code='{2}'
                                                order by a.Menu_Sort", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DBDataSet = DataHelper.Fill(SqlStr);


                dgv_Menu.DataSource = DBDataSet.Tables[0];
                dgv_Menu.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_Menu.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取菜单信息异常！" + ex.Message);
            }
        }

        private void dgv_Menu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string sMenuCode = dgv_Menu.Rows[e.RowIndex].Cells["Menu_Code"].Value.ToString();
            //加载模块信息
            GetModuleParamData(sMenuCode);
        }

        public void GetModuleParamData(string sMenuCode)
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"SELECT A.Module_ID, A.Module_Code, A.Module_Name, A.Module_Name_EN, A.Module_Source, A.Module_Form, A.Module_Sort, A.Remark, 
													CONVERT(VARCHAR(20), A.Creation_Date, 120) AS Creation_Date, B.User_Name AS Create_User_Name, 
													CONVERT(VARCHAR(20), A.Last_Update_Date, 120) AS Last_Update_Date, B.User_Name AS Edit_User_Name 
                                                FROM dbo.sys_BaseModule AS A 
													LEFT JOIN dbo.Sys_BaseUser AS B ON (A.Company_Code = B.Company_Code AND A.Factory_Code = B.Factory_Code AND A.Product_Line_Code = B.Product_Line_Code AND A.Created_By = B.User_ID)
													LEFT JOIN dbo.Sys_BaseUser AS C ON (A.Company_Code = C.Company_Code AND A.Factory_Code = C.Factory_Code AND A.Product_Line_Code = C.Product_Line_Code AND A.Last_Updated_By = C.User_ID)
												WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Menu_Code = '{3}'
												ORDER BY A.Module_Sort", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMenuCode);

                DBDataSet = DataHelper.Fill(SqlStr);


                dgv_Module.DataSource = DBDataSet.Tables[0];
                dgv_Module.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_Module.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取模块信息异常！" + ex.Message);
            }
        }

        #region 增加模块信息
        private void btn_Module_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmModuleModify ModifyForm = new FrmModuleModify();
                ModifyForm.sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                ModifyForm.sMenuName = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Name"].Value.ToString();
                ModifyForm.ModifyState = true;
                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    ClearModuleList();
                    if (dgv_Menu.CurrentRow.Index >= 0)
                    {
                        string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                        GetModuleParamData(sMenuCode);
                    }
                }

                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加模块异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加模块异常！，请检查数据库连接.");
            }
        }
        #endregion

        #region 模块编辑
        private void btn_Module_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Module.CurrentRow == null || dgv_Module.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmModuleModify ModifyForm = new FrmModuleModify();
                ModifyForm.ModifyState = false;

                ModifyForm.sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                ModifyForm.sMenuName = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Name"].Value.ToString();
                ModifyForm.sMenuNameEN = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Name_EN"].Value.ToString();
                ModifyForm.strId = Convert.ToInt32(dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_ID"].Value);
                ModifyForm.sModuleCode = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Code"].Value.ToString();
                ModifyForm.sModuleName = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Name"].Value.ToString();
                ModifyForm.sModuleNameEN = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Name_EN"].Value.ToString();
                ModifyForm.sModuleSource = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Source"].Value.ToString();
                ModifyForm.sModuleForm = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Form"].Value.ToString();
                ModifyForm.sModuleSort = Convert.ToInt32(dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Sort"].Value);
                ModifyForm.sRemark = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Modlue_Remark"].Value.ToString();

                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    ClearModuleList();
                    if (dgv_Menu.CurrentRow.Index >= 0)
                    {
                        string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                        GetModuleParamData(sMenuCode);
                    }
                }
                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改模块数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改模块数据异常！，请检查数据库连接.");
            }
        }
        #endregion


        #region 删除菜单信息
        private void btn_Module_Del_Click(object sender, EventArgs e)
        {
            try
            {
                string sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                string sModuleCode = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Code"].Value.ToString();
                string sModuleName = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Name"].Value.ToString();
                string sModuleSource = dgv_Module.Rows[dgv_Module.CurrentRow.Index].Cells["Module_Source"].Value.ToString();

                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认删除[{0}]的菜单信息？", sModuleCode)) == DialogResult.No)
                {
                    return;
                }
         
                string SqlStr = string.Format(@"Delete From sys_BaseModule Where Menu_Code = '{0}' and Module_Code = '{1}' and Company_Code='{2}' and 
                                           Factory_Code='{3}' and Product_Line_Code='{4}'", sMenuCode, sModuleCode, BaseSystemInfo.CompanyCode,
                                        BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DataHelper.Fill(SqlStr);

                //删除权限相关无菜单信息的记录
                string DelAuthority = string.Format(" Exec [DeleteAuthorityRecord]  '{0}','{1}','{2}','{3}','{4}','{5}'",
                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
                DataHelper.Fill(DelAuthority);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除菜单信息成功.");

                ClearModuleList();
                if (dgv_Menu.CurrentRow.Index >= 0)
                {
                    sMenuCode = dgv_Menu.Rows[dgv_Menu.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                    GetModuleParamData(sMenuCode);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("菜单信息删除异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单信息删除失败.请检查数据库连接状态.");
            }
        }
        #endregion

        #region 关闭
        private void btn_Module_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void dgv_Menu_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_Module_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 清空参数内容列表
        /// </summary>
        public void ClearModuleList()
        {
            DataTable dt = (DataTable)dgv_Module.DataSource;
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Clear();
            }
        }
    }
}
