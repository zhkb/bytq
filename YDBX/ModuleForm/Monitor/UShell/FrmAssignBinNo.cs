using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmAssignBinNo : Form
    {
        public string m_strBin = "";
  
        public FrmAssignBinNo()
        {
            InitializeComponent();
        }

        private void FrmAssignBinNo_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBin1_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "1" + "#";
            m_strBin = "1";
        }

        private void btnBin2_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "2" + "#";
            m_strBin = "2";
        }

        private void btnBin3_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "3" + "#";
            m_strBin = "3";
        }

        private void btnBin4_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "4" + "#";
            m_strBin = "4";
        }

        private void btnBin5_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "5" + "#";
            m_strBin = "5";
        }

        private void btnBin6_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "6" + "#";
            m_strBin = "6";
        }

        private void btnBin7_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "7" + "#";
            m_strBin = "7";
        }

        private void btnBin8_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "8" + "#";
            m_strBin = "8";
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if(m_strBin.Length<1)
            {
                MessageBox.Show("请选择1个货道" + Environment.NewLine + "Please select a aisle");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
            
            #region PLC 下传

            #endregion
        }

        
    }
}
