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
    using Sys.DbUtilities;
    using Sys.Config;
    using Sys.Utilities;
    public partial class FrmRegTips : BaseForm
    {
        private int ExitTime = 0;
        public FrmRegTips()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_RegInfo1.Text = string.Format("系统未注册，将于{0}秒钟后关闭.", ExitTime);
            lbl_RegInfo2.Text = string.Format("如未注册，生产数据将不能正常存储.");
            lbl_RegInfo3.Text = string.Format("请在登录界面点击注册按钮进行产品注册.");
            ExitTime--;

            if (ExitTime == 0)
            {
                BaseSystemInfo.ForcedExit = true;
                Application.Exit();
            }
        }

        private void FrmRegTips_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lbl_RegInfo1.Text = string.Format("系统未注册，将于{0}秒钟后关闭.", ExitTime);
            lbl_RegInfo2.Text = string.Format("如未注册，生产数据将不能正常存储.");
            lbl_RegInfo3.Text = string.Format("请在登录界面点击注册按钮进行产品注册.");
            ExitTime = 10;
            timer1.Enabled = true;

        }

        private void btn_Reg_Click(object sender, EventArgs e)
        {

        }
    }
}
