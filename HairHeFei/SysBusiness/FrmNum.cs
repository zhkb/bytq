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

    public partial class FrmNum : Form
    {
        public string NumStr = "1";
        public string TitleStr = "请输入数量";
        public FrmNum()
        {
            InitializeComponent();
        }

        private void btn_num1_Click(object sender, EventArgs e)
        {            
            NumStr = NumStr + "1";
            txt_planqty.Text = NumStr;
        }

        private void btn_num2_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "2";
            txt_planqty.Text = NumStr;
        }

        private void btn_num3_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "3";
            txt_planqty.Text = NumStr;
        }

        private void btn_num4_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "4";
            txt_planqty.Text = NumStr;
        }

        private void btn_num5_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "5";
            txt_planqty.Text = NumStr;
        }

        private void btn_num6_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "6";
            txt_planqty.Text = NumStr;
        }

        private void btn_num7_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "7";
            txt_planqty.Text = NumStr;
        }

        private void btn_num8_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "8";
            txt_planqty.Text = NumStr;
        }

        private void btn_num9_Click(object sender, EventArgs e)
        {
            NumStr = NumStr + "9";
            txt_planqty.Text = NumStr;
        }

        private void btn_num0_Click(object sender, EventArgs e)
        {
            if (NumStr == "")
            {
                return;
            }
            NumStr = NumStr + "0";
            txt_planqty.Text = NumStr;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            NumStr = "";
            txt_planqty.Text = "0";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (NumStr == "")
            {
                MessageBox.Show("请输入正确数量.", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void FrmNum_Load(object sender, EventArgs e)
        {
            txt_planqty.Text = NumStr;
            this.Text = TitleStr;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
