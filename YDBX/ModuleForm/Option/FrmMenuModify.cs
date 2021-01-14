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
    public partial class FrmMenuModify : Form
    {


        public string strMenuCode = "";      //菜单编码
        public string strMenuName = "";      //菜单名称
        public string strMenuNameEN = "";      //菜单名称
        public int strMenuSort = 0;          //序号
        public string strMenuMark = "";      // 备注

        public int strMenuId = 0;            //menuid

        public string oldStrMenuCode="";
        public string oldStrMenuName="";
        public string oldStrMenuNameEN = "";

        public bool ModifyState = false;     //新增、添加标志位
        public FrmMenuModify()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 /*&& m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012*/)
            {
                base.WndProc(ref m);
            }
        }
        private void FrmMenuModify_Load(object sender, EventArgs e)
        {
            if (!ModifyState)
            {
                menucode.Text = strMenuCode;
                menuname.Text = strMenuName;
                menunameEN.Text = strMenuNameEN;
                menusort.Text = strMenuSort.ToString();
                menumark.Text = strMenuMark;
                oldStrMenuCode = strMenuCode;
                oldStrMenuName = strMenuName;
                oldStrMenuNameEN = strMenuNameEN;

            }
        }



        private void btn_Ok_Click(object sender, EventArgs e)
        {
            strMenuCode = menucode.Text;
            strMenuName = menuname.Text;
            strMenuNameEN = menunameEN.Text;
            strMenuMark = menumark.Text;


            //如果是新增
            if (ModifyState)
            {
                if (strMenuCode.Trim()=="")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单编号设置不能为空.");
                    return;
                }
                if (strMenuName.Trim() == "") 
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单名称设置不能为空.");
                    return;
                }
                if (strMenuNameEN.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单名称英文设置不能为空.");
                    return;
                }
                if (menusort.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单序号设置不能为空.");
                    return;
                }
                strMenuSort = int.Parse(menusort.Text);
                //设置数据库相关
                //1、menuname 是否存在，方便提示
                DataSet DBDataSet = new DataSet();
            
                string SelectSql = string.Format(@"select * from Sys_BaseMenu 
                                                      where Menu_Code = '{0}'  and  Company_Code='{1}'and 
                                            Factory_Code='{2}' and Product_Line_Code='{3}'", strMenuCode,BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                 DBDataSet = DataHelper.Fill(SelectSql);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单编号不能重复.");
                    return;
                }
                string SelectSql2 = string.Format(@"select * from Sys_BaseMenu 
                                                      where Menu_Name = '{0}'  and  Company_Code='{1}'and 
                                            Factory_Code='{2}' and Product_Line_Code='{3}'", strMenuName, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DBDataSet = DataHelper.Fill(SelectSql2);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单名称不能重复.");
                    return;
                }
                else
                {
                    strMenuSort = int.Parse(menusort.Text);
                    try
                    {
                        string SqlStr = string.Format(@"INSERT INTO dbo.Sys_BaseMenu (Menu_Code, Menu_Name, Menu_Sort, Remark, Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name, Creation_Date, Created_By, Last_Update_Date, Last_Updated_By,Menu_Name)
													        VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', GETDATE(), {10}, GETDATE(), {10},'{11}')",
                                                        strMenuCode, strMenuName, strMenuSort, strMenuMark, 
                                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, 
                                                        BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, 
                                                        BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, BaseSystemInfo.CurrentUserID, strMenuNameEN);
                        DataHelper.Fill(SqlStr);
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "增加菜单信息成功.");
                    }
                    catch (Exception ex)
                    {
                        SysBusinessFunction.WriteLog("增加菜单信息异常！"+ex.Message);
                    }
                }
            }
            else
            {
                //如果是修改，菜单名称、菜单编码不能重复。
                DataSet DBDataSet = new DataSet();
                string SelectSqlname = string.Format(@"select * from Sys_BaseMenu 
                                                       where Menu_ID <>'{0}' and Menu_Name='{1}' and  Company_Code='{2}' and 
                                            Factory_Code='{3}' and Product_Line_Code='{4}'", strMenuId, strMenuName,
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlname);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单名称不能重复.");
                    menuname.Text = oldStrMenuName;
                    return;
                }


                string SelectSqlcode = string.Format(@"select * from Sys_BaseMenu 
                                                       where Menu_ID <>'{0}' and Menu_Code='{1}' and Company_Code='{2}' and 
                                            Factory_Code='{3}' and Product_Line_Code='{4}'", strMenuId, strMenuCode, BaseSystemInfo.CompanyCode, 
                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlcode);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单编码不能重复.");
                    menucode.Text = oldStrMenuCode;
                    return;
                }

                if (menucode.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单编码设置不能为空.");
                    return;
                }
                if (menuname.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单名称设置不能为空.");
                    return;
                }
                if (menunameEN.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "菜单名称英文设置不能为空.");
                    return;
                }
                try
                {
                    string SqlStr = string.Format(@"Update Sys_BaseMenu Set Menu_Code = '{0}',Menu_Name = '{1}',Menu_Sort={2},Remark='{3}',Last_Update_Date = GETDATE(), Last_Updated_By = {4},Menu_Name_EN = '{6}'
                                                        Where Menu_ID = '{5}'", strMenuCode, strMenuName, strMenuSort, strMenuMark, BaseSystemInfo.CurrentUserID, strMenuId, strMenuNameEN);
                    DataHelper.Fill(SqlStr);
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "更新菜单信息成功.");
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("修改菜单信息异常！" + ex.Message);
                }
            }
            DialogResult = DialogResult.OK;
        }
      

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
