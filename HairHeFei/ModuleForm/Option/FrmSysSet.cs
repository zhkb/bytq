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
    public partial class FrmSysSet : Form
    {

        public string pStrMenuCode = "";     //菜单编号
        public string pStrMenuName = "";     //菜单名称
        public string pStrMenuSource = "";   //菜单资源
        public string pStrMenuWedget = "";   //窗体
        public int pStrMenuSort = 0;         //序号
        public string pStrMenuMark = "";     //备注
        public int pStrid;                   //menu id

        public string pOtionStrcode = "";       //操作编码
        public string pOptionStrName = "";       //操作名称
        public string pOptionStrValue = "";          //数值
        public string pOptionStrMark = "";      //备注
        public int pOptionStrid = 0;            //option id


        public FrmSysSet()
        {
            InitializeComponent();
        }

        #region 关闭
        private void btn_CloseOption_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void FrmSysSet_Load(object sender, EventArgs e)
        {
            GetMenuParamData();
            GetOptionParamData();
            dgv_menudata.TopLeftHeaderCell.Value = "序号";
            dgv_optiondata.TopLeftHeaderCell.Value = "序号";
        }
        public void GetOptionParamData()
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"select Option_Code,Option_Name,Option_Value,Remark from Sys_Option where Company_Code='{0}'and
                                   Factory_Code='{1}' and ProductLine_Code='{2}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);

                string sOrder = " order by Option_Code desc ";
                SqlStr += sOrder;

                DBDataSet = DataHelper.Fill(SqlStr);

                dgv_optiondata.DataSource = DBDataSet.Tables[0];
                dgv_optiondata.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_optiondata.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取选项信息异常！" + ex.Message);
            }
        }
        public void GetMenuParamData()
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"select Menu_Code,Menu_Name,Menu_Source,Menu_Form,Menu_Sort,Remark from Sys_Menu where Company_Code='{0}'and
                                   Factory_Code='{1}' and ProductLine_Code='{2}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                string sOrder = " order by Menu_Code desc ";
                SqlStr += sOrder;
                DBDataSet = DataHelper.Fill(SqlStr);
                

                dgv_menudata.DataSource = DBDataSet.Tables[0];
                dgv_menudata.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_menudata.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取菜单信息异常！" + ex.Message);
            }
        }

       #region 菜单编辑
        private void edit_menu_Click_1(object sender, EventArgs e)
        {

            try
            {
                pStrMenuCode = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                pStrMenuName = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Name"].Value.ToString();
                pStrMenuSource = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Source"].Value.ToString();

                pStrMenuWedget = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Form"].Value.ToString();
                pStrMenuSort = int.Parse(dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Sort"].Value.ToString());
                pStrMenuMark = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Remark1"].Value.ToString();

                /*根据编号得到id*/

                DataSet DBDataSet = new DataSet();
                string SelectSql = string.Format(@"select * from Sys_Menu 
                                                       where Menu_Code = '{0}' and Company_Code='{1}'and 
                                            Factory_Code='{2}' and ProductLine_Code='{3}'", pStrMenuCode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSql);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    pStrid = int.Parse(DBDataSet.Tables[0].Rows[0]["Menu_ID"].ToString());

                }

                FrmMenuModify Modify = new FrmMenuModify();
                Modify.strMenuId = pStrid;
                Modify.strMenuCode = pStrMenuCode;
                Modify.strMenuName = pStrMenuName;
                Modify.strMenuSource = pStrMenuSource;
                Modify.strMenuWedget = pStrMenuWedget;
                Modify.strMenuMark = pStrMenuMark;
                Modify.strMenuSort = pStrMenuSort;
                Modify.ModifyState = false;
                DialogResult r = Modify.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMenuParamData();//获取菜单信息
                }

                Modify.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑菜单信息异常！" + ex.Message);
            }
        }
        #endregion


        private void dgv_menudata_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//序号列
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void dgv_optiondata_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//序号列
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        #region       删除选项信息
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                pOtionStrcode = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Option_Code"].Value.ToString();
                pOptionStrName = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Option_Name"].Value.ToString();
                pOptionStrValue = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Option_Value"].Value.ToString();
                pOptionStrMark = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Remark"].Value.ToString();

                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认删除[{0}]的选项信息？", pOtionStrcode)) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"Delete From Sys_Option Where Option_Code = '{0}' and  Company_Code='{1}' and
                Factory_Code = '{2}' and ProductLine_Code = '{3}'", pOtionStrcode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DataHelper.Fill(SqlStr);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除选项信息成功.");

                pOtionStrcode = "";
                pOptionStrName = "";
                pOptionStrMark = "";
                pOptionStrValue = "";
                GetOptionParamData(); //获取
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("选项信息删除异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项信息删除失败.请检查数据库连接状态.");
            }

        }
        #endregion

        #region  增加选项信息
        private void btn_AddOption_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmOptionModify ModifyForm = new FrmOptionModify();
                ModifyForm.ModifyState = true;  //增加

                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetOptionParamData();
                }

                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加选项信息异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加选项信息异常！请检查数据库连接.");
            }

        }
        #endregion

        #region 增加菜单信息
        private void add_menu_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmMenuModify ModifyForm = new FrmMenuModify();
                ModifyForm.ModifyState = true;  //增加

                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetMenuParamData(); //获取数据
                }

                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加菜单信息异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加菜单信息异常，请检查数据库连接.");
            }
        }
        #endregion

         #region   编辑选项信息
        private void btn_EditOption_Click_1(object sender, EventArgs e)
        {
            try
            {
                pOtionStrcode = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Option_Code"].Value.ToString();
                pOptionStrName = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Option_Name"].Value.ToString();
                pOptionStrValue = dgv_optiondata.Rows[dgv_menudata.CurrentRow.Index].Cells["Option_Value"].Value.ToString();
                pOptionStrMark = dgv_optiondata.Rows[dgv_optiondata.CurrentRow.Index].Cells["Remark"].Value.ToString();



       
                /*根据编号得到id*/
                DataSet DBDataSet = new DataSet();
                string SelectSql = string.Format(@"select * from Sys_Option 
                                                       where Option_Code = '{0}' and  Company_Code='{1}'and 
                                            Factory_Code='{2}' and ProductLine_Code='{3}'", pOtionStrcode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSql);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    pOptionStrid = int.Parse(DBDataSet.Tables[0].Rows[0]["Option_ID"].ToString());

                }

                FrmOptionModify Modify = new FrmOptionModify();
                Modify.strId = pOptionStrid;
                Modify.strCode = pOtionStrcode;
                Modify.strName = pOptionStrName;
                Modify.strValue = pOptionStrValue;
                Modify.strMark = pOptionStrMark;
                Modify.ModifyState = false;
                DialogResult r = Modify.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetOptionParamData();
                }

                Modify.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑选项信息异常！" + ex.Message);
            }

        }
        #endregion

        #region 删除菜单信息
        private void delete_menu_Click_1(object sender, EventArgs e)
        {
            try
            {
                pStrMenuCode = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Code"].Value.ToString();
                pStrMenuName = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Name"].Value.ToString();
                pStrMenuSource = dgv_menudata.Rows[dgv_menudata.CurrentRow.Index].Cells["Menu_Source"].Value.ToString();

                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认删除[{0}]的菜单信息？", pStrMenuCode)) == DialogResult.No)
                {
                    return;
                }
         
                string SqlStr = string.Format(@"Delete From Sys_Menu Where Menu_Code = '{0}' and Company_Code='{1}' and 
                                           Factory_Code='{2}' and ProductLine_Code='{3}'", pStrMenuCode, BaseSystemInfo.CompanyCode,
                                        BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DataHelper.Fill(SqlStr);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除菜单信息成功.");

                pStrMenuCode = "";
                pStrMenuName = "";
                pStrMenuSource = "";

                GetMenuParamData(); //获取
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("菜单信息删除异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单信息删除失败.请检查数据库连接状态.");
            }
        }
        #endregion

        #region 关闭
        private void close_menu_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
   

        private void btn_CloseOption_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
