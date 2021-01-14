using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.SysBusiness
{
    using Sys.Utilities;
    using Sys.Config;
    using Sys.DbUtilities;
    public partial class FrmLocalPwd : BaseForm
    {
        public FrmLocalPwd()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string LocaPassWord = SysBusinessFunction.HashPassword(txt_LocalPwd.Text.Trim());
            //    if (LocaPassWord == BaseSystemInfo.LocalPWD)
            //    {
            //        DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("密码输入错误，请重新输入.")) != DialogResult.Yes)
            //        {
            //            txt_LocalPwd.Focus();
            //        }
                        
            //        return;

            //    }
            //}
            //catch
            //{

            //}
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
