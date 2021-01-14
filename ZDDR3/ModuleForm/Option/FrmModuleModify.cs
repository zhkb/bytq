using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Option
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using Sys.Config;
    

    public partial class FrmModuleModify : Form
    {
        public string sMenuCode = "";
        public string sMenuName = "";
        public string sModuleCode ="";   
        public string sModuleName="";    
        public string sModuleSource = "";      
        public string sModuleForm = "";    
        public int sModuleSort = 0;      
        public string sRemark = "";    

        public int strId =0;

        public string oldStrCode = "";
        public string oldStrName = "";

        public  bool ModifyState = false;  //标志位，判断是添加,修改
        public FrmModuleModify()
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
        private void FrmModuleModify_Load(object sender, EventArgs e)
        {
            if (!ModifyState) 
            {
                txt_ModuleCode.Text = sModuleCode;
                txt_ModuleName.Text = sModuleName;
                txt_ModuleSource.Text = sModuleSource;
                txt_ModuleForm.Text = sModuleForm;
                txt_ModuleSort.Text = sModuleSort.ToString();
                txt_Remark.Text = sRemark;
                oldStrCode = sModuleCode;
                oldStrName = sModuleName;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sModuleCode = txt_ModuleCode.Text;
            sModuleName = txt_ModuleName.Text;
            sModuleSource = txt_ModuleSource.Text;
            sModuleForm = txt_ModuleForm.Text;
            sModuleSort = Convert.ToInt32(txt_ModuleSort.Text);
            sRemark = txt_Remark.Text;

            //如果是新增
            if (ModifyState)
            {
                
                if (sModuleCode.Trim()=="")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块编号设置不能为空.");
                    return;
                }
                if (sModuleName.Trim()=="")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块名称设置不能为空.");
                    return;
                }

                DataSet DBDataSet = new DataSet();
                string SelectSql = string.Format(@"select * from sys_BaseModule 
                                                       where Module_Code = '{0}' and  Company_Code='{1}'and 
                                             Factory_Code='{2}' and Product_Line_Code='{3}'", sModuleCode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSql);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块编号不能重复.");
                    return;
                }

                string SelectSql2 = string.Format(@"select * from sys_BaseModule 
                                                       where Module_Name = '{0}' and  Company_Code='{1}'and 
                                             Factory_Code='{2}' and Product_Line_Code='{3}'", sModuleName, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSql2);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块名称不能重复.");
                    return;
                }
                else
                {
                    try
                    {
                        string SqlStr = string.Format(@"INSERT INTO dbo.sys_BaseModule (Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name, Menu_Code, Menu_Name, Module_Code, Module_Name, Module_Source, Module_Form, Module_Sort, Remark, Creation_Date, Created_By, Last_Update_Date, Last_Updated_By)
	                                                    VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', {12}, '{13}', GETDATE(), '{14}', GETDATE(), '{14}')",
                                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName,
                                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName,
                                                            BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                            sMenuCode, sMenuName, sModuleCode, sModuleName, sModuleSource, sModuleForm,
                                                            sModuleSort, sRemark, BaseSystemInfo.CurrentUserID);
                        DataHelper.Fill(SqlStr);
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "增加模块信息成功.");
                    }
                    catch (Exception ex)
                    {
                        SysBusinessFunction.WriteLog("增加模块信息异常！" + ex.Message);
                    }
                }

            }
            else  //修改状态
            {
     
                DataSet DBDataSet = new DataSet();
                string SelectSqlname = string.Format(@"select * from sys_BaseModule 
                                                       where Module_ID <>'{0}' and Module_Name='{1}' and Company_Code='{2}' and  Factory_Code='{3}' and Product_Line_Code ='{4}'", strId, sModuleName, 
                                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlname); 
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块名称不能重复.");
                    txt_ModuleName.Text = oldStrName;
                    return;
                }


                string SelectSqlcode = string.Format(@"select * from sys_BaseModule 
                                                       where Module_ID <>'{0}' and Module_Code='{1}' and Company_Code='{2}' and Factory_Code='{3}' and  Product_Line_Code='{4}'", strId, sModuleCode,
                                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlcode);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块编码不能重复.");
                    txt_ModuleCode.Text = oldStrCode;
                    return;
                }

                if (txt_ModuleCode.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块编号设置不能为空.");
                    return;
                }
                if (txt_ModuleName.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "模块名称设置不能为空.");
                    return;
                }

                try
                {
                    string SqlStr = string.Format(@"UPDATE dbo.sys_BaseModule SET Module_Code = '{0}', Module_Name = '{1}', Module_Source = '{2}', Module_Form = '{3}', Module_Sort = {4}, Remark = '{5}', Last_Update_Date = GETDATE(), Last_Updated_By = {6}
                                                            WHERE Module_ID = {7}", sModuleCode, sModuleName, sModuleSource, sModuleForm, sModuleSort, sRemark, BaseSystemInfo.CurrentUserID, strId);
                    DataHelper.Fill(SqlStr);
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改选项信息成功.");
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("修改选项信息异常！" + ex.Message);
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
