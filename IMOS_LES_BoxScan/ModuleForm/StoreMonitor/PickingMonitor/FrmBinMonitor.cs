using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlLogic;

namespace PickingMonitor
{
    public partial class FrmBinMonitor : Form
    {
        public int BinNo = 0;

        public FrmBinMonitor()
        {
            InitializeComponent();
        }

        private void FrmBinMonitor_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                FrmBinDetail fbd = new FrmBinDetail();
                fbd.TopLevel = false;
                fbd.Parent = panel1;
                fbd.Dock = System.Windows.Forms.DockStyle.Right;
                fbd.Width = panel1.Width / 10;
                fbd.No = BinNo+i;
                fbd.Show();
            }
        }
    }
}
