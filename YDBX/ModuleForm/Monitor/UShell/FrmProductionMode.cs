using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.Config;

namespace Monitor
{
    public partial class FrmProductionMode : Form
    {
        int m_iProductionMode = 0;
        public FrmProductionMode()
        {
            InitializeComponent();
        }

        private void FrmProductionMode_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            switch (BaseSystemInfo.CurrentProductionOutMode)
            {
                case 1:
                    radioButton1.Checked=true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
            }        
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            ConfigHelper.SetValue("CurrentProductionOutMode", m_iProductionMode.ToString());
            BaseSystemInfo.CurrentProductionOutMode = m_iProductionMode;
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                m_iProductionMode = 1;
            }
            else if (radioButton2.Checked)
            {
                m_iProductionMode = 2;
            }
            else if (radioButton3.Checked)
            {
                m_iProductionMode = 3;
            }
        }
    }
}
