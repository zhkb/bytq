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

    public partial class FrmDialog : Form
    {
        public int DialogType = 0;
        public string InfoTxt = "";
        public FrmDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Option_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void FrmDialog_Load(object sender, EventArgs e)
        {
            Height = 185;
            Width = 450;

            pnl_ask.Visible = DialogType == SysBusinessFunction.DialogAskMessage;
            pnl_ok.Visible = DialogType == SysBusinessFunction.DialogOKMessage;
            pnl_yn.Visible = DialogType == SysBusinessFunction.DialogYesNoMessage;

            if ((!pnl_ask.Visible) && (!pnl_ok.Visible) && (!pnl_yn.Visible)) //防止为设置提示类型  直接显示确定按钮
            {
                pnl_ok.Visible = true;
            }

            if (DialogType == SysBusinessFunction.DialogAskMessage)
            {
                pic_Message.BackgroundImage = Sys.SysBusiness.Properties.Resources.qustion;
            }
            else
            {
                pic_Message.BackgroundImage = Sys.SysBusiness.Properties.Resources.infomation;
            }

            lbl_Info.Text = InfoTxt;
        }

        private void btn_TipsOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
