using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace User
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;

    public partial class FrmUserModify : Form
    {
        public string uloginname = "";
        public string ucname = "";
        public string upassword = "";
        public string userid = "";
        public bool OperFlag = false;
        public bool TechFlag = false;
        public bool PlanFlag = false;
        public bool CheckFlag = false;
        public bool AdminFlag = false;

        public bool ModifyState = true; //新增 true 编辑  false
        public string InitialPwd = "123";

        private bool InitializePass = false; //是否重置密码
        public FrmUserModify()
        {
            InitializeComponent();
        }

        private void FrmUserModify_Load(object sender, EventArgs e)//加载
        {
            if (!ModifyState) //编辑状态显示信息
            {
                txt_uloginname.Text = uloginname;
                txt_ucname.Text = ucname;
                //txt_uloginname.ReadOnly = true;

                txt_upassword.Enabled = false;
                txt_ConfirmPwd.Enabled = false;

                chk_Oper.Checked = OperFlag;
                chk_Tech.Checked = TechFlag;
                chk_Plan.Checked = PlanFlag;
                chk_Check.Checked = CheckFlag;
                chk_Admin.Checked = AdminFlag;
            }
            else
            {
                btn_InitialPwd.Visible = false;
            }
        }



        private void btn_InitialPwd_Click(object sender, EventArgs e)//初始化密码
        {
            if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认重置密码？", uloginname)) == DialogResult.No)
            {
                return;
            }

            InitializePass = true;

            txt_upassword.Enabled = true;
            txt_ConfirmPwd.Enabled = true;

            txt_upassword.Text = "123";
            txt_ConfirmPwd.Text = "123";
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                uloginname = txt_uloginname.Text;
                ucname = txt_ucname.Text;

                if (ModifyState)//新增
                {
                    if (uloginname == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录名不能为空.");
                        txt_uloginname.Focus();
                        return;
                    }
                    if (ucname == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "姓名不能为空.");
                        txt_ucname.Focus();
                        return;
                    }
                    if (txt_upassword.Text == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "密码不能为空.");
                        txt_upassword.Focus();
                        return;
                    }
                    if (txt_ConfirmPwd.Text == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请再次输入密码.");
                        txt_ConfirmPwd.Focus();
                        return;
                    }
                    if (txt_upassword.Text != txt_ConfirmPwd.Text)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "两次输入的密码不一致，请重新输入.");
                        txt_upassword.Clear();
                        txt_ConfirmPwd.Clear();
                        txt_upassword.Focus();
                        return;
                    }

                    DataSet DBDataSet = new DataSet();
                    string SelectSql = string.Format(@"select * from Sys_User 
                                                       where User_Code = '{0}'", uloginname);
                    DBDataSet = DataHelper.Fill(SelectSql);
                    if (DBDataSet.Tables[0].Rows.Count > 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录名不能重复.");
                        txt_uloginname.Clear();
                        txt_uloginname.Focus();
                        return;
                    }
                    else//调用存储过程添加新用户
                    {
                        try
                        {
                            OperFlag = chk_Oper.Checked;
                            TechFlag = chk_Tech.Checked;
                            PlanFlag = chk_Plan.Checked;
                            CheckFlag = chk_Check.Checked;
                            AdminFlag = chk_Admin.Checked;

                            upassword = SysBusinessFunction.MD5(txt_upassword.Text);

                            string SqlStr = string.Format(@"insert into Sys_User(User_Code,User_Name,User_PassWord,Operator_Flag,Tech_Flag,Plan_Flag,Check_Flag,Admin_Flag)
                                                            values('{0}','{1}','{2}',{3},{4},{5},{6},{7})",
                                                            uloginname, ucname, upassword, Convert.ToInt32(OperFlag), Convert.ToInt32(TechFlag), Convert.ToInt32(PlanFlag), Convert.ToInt32(CheckFlag), Convert.ToInt32(AdminFlag));
                            DataHelper.Fill(SqlStr);
                            SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "增加新用户成功.");
                        }
                        catch (Exception ex)
                        {
                            SysBusinessFunction.WriteLog(ex.ToString());
                        }
                    }
                }
                else//修改
                {
                    DataSet DBDataSet = new DataSet();
                    string SelectSql = string.Format(@"select * from Sys_User 
                                                       where User_Code = '{0}'and User_ID <>'{1}'", uloginname, userid);
                    DBDataSet = DataHelper.Fill(SelectSql);
                    if (DBDataSet.Tables[0].Rows.Count > 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录名不能重复.");
                        txt_uloginname.Clear();
                        txt_uloginname.Focus();
                        return;
                    }
                    else
                    {
                        if (InitializePass)
                        {
                            if (txt_upassword.Text == "")
                            {
                                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "密码不能为空.");
                                txt_upassword.Focus();
                                return;
                            }



                            if (txt_ConfirmPwd.Text == "")
                            {
                                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请再次输入密码.");
                                txt_ConfirmPwd.Focus();
                                return;
                            }


                            if (txt_upassword.Text != txt_ConfirmPwd.Text)
                            {
                                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "两次输入的密码不一致，请重新输入.");
                                txt_upassword.Clear();
                                txt_ConfirmPwd.Clear();
                                txt_upassword.Focus();
                                return;
                            }
                        }
                        OperFlag = chk_Oper.Checked;
                        TechFlag = chk_Tech.Checked;
                        PlanFlag = chk_Plan.Checked;
                        CheckFlag = chk_Check.Checked;
                        AdminFlag = chk_Admin.Checked;
                        string NewPassword = "";
                        if (InitializePass)
                        {
                            NewPassword = SysBusinessFunction.MD5(txt_upassword.Text);
                        }
                        else
                        {
                            NewPassword = upassword;
                        }
                            
                        string SqlStr = string.Format(@"Update Sys_User Set User_Code = '{0}',User_Name = '{1}',User_password='{2}',
                                                        Operator_Flag = {4},Tech_Flag= {5},Plan_Flag = {6},Check_Flag= {7},Admin_Flag= {8}
                                                        Where User_ID = '{3}'", uloginname, ucname, NewPassword, userid,
                                                        Convert.ToInt32(OperFlag), Convert.ToInt32(TechFlag), Convert.ToInt32(PlanFlag), Convert.ToInt32(CheckFlag), Convert.ToInt32(AdminFlag));
                        DataHelper.Fill(SqlStr);
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改用户信息成功.");
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "用户信息存储失败，注意用户ID不能重复.");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
