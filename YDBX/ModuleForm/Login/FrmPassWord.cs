using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    using Sys.DbUtilities;
    using Sys.Utilities;
    using Sys.Config;
    using Sys.SysBusiness;
    public partial class FrmPassWord : Form
    {
        public string UserName = "";
        public string UserNo = "";
        public string UserID = "";
        public string UserPass = "";

        public bool OperFlag; //操作员权限
        public bool TechFlag;//工艺员权限
        public bool PlanFlag;//计划员权限
        public bool CheckFlag;//质检员权限
        public bool AdminFlag;//管理员权限

        public int FIndex;
        public Color[] ViewBackColor = { Color.White, Color.White }; //列表间隔颜色
        public FrmPassWord()
        {
            InitializeComponent();
        }

        private void FrmSelectUser_Load(object sender, EventArgs e)
        {
            txt_UserCode.Text = BaseSystemInfo.CurrentUserName;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_PassWord.Text == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "旧密码不能为空.");
                    return;
                }

                if (txt_NewPassWord1.Text == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "新密码不能为空.");
                    return;
                }

                if (txt_NewPassWord2.Text == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "新密码不能为空.");
                    return;
                }

                if (txt_NewPassWord1.Text != txt_NewPassWord2.Text)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "两次输入密码不一致.");
                    return;
                }

                string PassWord = SysBusinessFunction.MD5(txt_PassWord.Text);

                DataSet DbDataSet = new DataSet();
                string sql = string.Format(@" select * from Sys_BaseUser where User_ID='{0}'and User_PassWord='{1}'", BaseSystemInfo.CurrentUserID, PassWord);
                DbDataSet = DataHelper.Fill(sql);

                if (DbDataSet.Tables[0].Rows.Count == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "旧密码错误，请重新输入.");
                    txt_PassWord.Clear();
                    txt_PassWord.Focus();
                    return;
                }

                string NewPassWord = SysBusinessFunction.MD5(txt_NewPassWord1.Text);
                string Updatesql = string.Format(@"Update Sys_BaseUser Set User_PassWord = '{0}' Where User_ID='{1}'", NewPassWord, BaseSystemInfo.CurrentUserID);
                DataHelper.Fill(Updatesql);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "密码修改成功.");
                DialogResult = DialogResult.OK;
            }
            catch
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "密码修改失败.");
            }
        }
    }
}
