using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equipment
{

    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    public partial class FrmEquModify : Form
    {
        public string strEquCode = "";     //机台编码
        public string strEquName = "";    //机台名称
        public string strEqutype = "";    //机台类型
        public string strEquMark  = "";    //备注

        public int strEquId = 0;

        public string oldEquCode = "";
        public string oldEquName = "";


        public int EquType;

        public bool ModifyState = false;  //标志位，判断是添加,修改


        public FrmEquModify()
        {
            InitializeComponent();
        }

        #region 机台管理维护-确定
        private void btn_Ok_Click_1(object sender, EventArgs e)
        {
            
            strEqutype = txt_EqucomboBox.Text;
            strEquCode = txt_Equnum.Text;
            strEquName = txt_Equname.Text;
            strEquMark = txt_Equmark.Text;


            //如果是新增
            if (ModifyState)
            {
                
                if (strEqutype.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台类型设置不能为空.");
                    return;
                }
                if (strEquCode.Trim()== "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台编码不能为空.");
                    return;
                }
                if (strEquName.Trim()== "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台名称不能为空.");
                    return;
                }

                DataSet DBDataSet = new DataSet();
     
                string SelectSql = string.Format(@"select * from Sys_Equipment where Equipment_Code = '{0}' and Company_Code='{1}'and 
                                                    Factory_Code='{2}' and ProductLine_Code='{3}'", strEquCode, BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DBDataSet = DataHelper.Fill(SelectSql);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台设置编号项不能重复.");
                    return;
                }
                string SelectSql1 = string.Format(@"select * from Sys_Equipment where Equipment_Name = '{0}' and Company_Code='{1}' and
                                                    Factory_Code='{2}'and ProductLine_Code='{3}'", strEquName, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                DBDataSet = DataHelper.Fill(SelectSql1);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台设置名称项不能重复.");
                    return;
                }
                else
                {
                    try
                    {
                        DBDataSet = null;
                        string SqlStr = string.Format(@"insert into Sys_Equipment(Company_Code,Company_Name,Factory_Code,Factory_Name,ProductLine_Code,ProductLine_Name,
                                                            Equipment_Type,Equipment_Code,Equipment_Name,Remark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", BaseSystemInfo.CompanyCode,
                                                            BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                                            BaseSystemInfo.ProductLineName, strEqutype, strEquCode, strEquName, strEquMark);
                        DataHelper.Fill(SqlStr);
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加机台信息成功.");
                    }

                    catch (Exception ex)
                    {
                        SysBusinessFunction.WriteLog("添加机台信息异常！"+ ex.Message);
                    }
                }
            }
            else
            {
                
                DataSet DBDataSet = new DataSet();
                string SelectSqlname = string.Format(@"select * from Sys_Equipment 
                                                       where ID <>'{0}' and Equipment_Name='{1}' and Company_Code='{2}'and Factory_Code='{3}' 
                                                        and ProductLine_Code='{4}'", strEquId, strEquName, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlname);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台名称不能重复.");
                    txt_Equname.Text = oldEquName;
                    return;
                }


                string SelectSqlcode = string.Format(@"select * from Sys_Equipment 
                                                       where ID <>'{0}' and Equipment_Code='{1}' and Company_Code='{2}'and Factory_Code='{3}' 
                                                        and ProductLine_Code='{4}'", strEquId, strEquCode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlcode);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台编码不能重复.");
                    txt_Equnum.Text = oldEquCode;
                    return;
                }

                if (txt_Equnum.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台编码设置不能为空.");
                    return;
                }
                if (txt_Equname.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台名称设置不能为空.");
                    return;
                  
                }
                try
                {
              
                    string SqlStr = string.Format(@"Update Sys_Equipment Set Equipment_Type = '{0}',Equipment_Code = '{1}',Equipment_Name='{2}',Remark='{3}'
                                                        Where ID = '{4}'", strEqutype, strEquCode, strEquName, strEquMark, strEquId);
                    DataHelper.Fill(SqlStr);
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "更新机台信息成功.");
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("更新机台信息异常！" + ex.Message);
                }



            }
            DialogResult = DialogResult.OK;
        }
        #endregion
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 /*&& m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012*/)
            {
                base.WndProc(ref m);
            }
        }

        private void FrmEquModify_Load(object sender, EventArgs e)
        {
       
            txt_EqucomboBox.Text = strEqutype;
            txt_Equnum.Text = strEquCode;
            txt_Equname.Text = strEquName;
            txt_Equmark.Text = strEquMark;
            oldEquCode = strEquCode;
            oldEquName = strEquName;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
