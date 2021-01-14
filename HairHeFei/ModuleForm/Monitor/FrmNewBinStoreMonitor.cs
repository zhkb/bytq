using ControlLogic.Control;
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
    public partial class FrmNewBinStoreMonitor : Form
    {
        public FrmNewBinStoreMonitor()
        {
            InitializeComponent();
        }

        private void FrmNewBinStoreMonitor_Load(object sender, EventArgs e)
        {
            try
            {

                ControlStoreMonitor.SystemInitialization();
                for(int i = 1; i <= 8; i++)
                {
                    FrmOutStoreDetailMonitor frm = new FrmOutStoreDetailMonitor();
                    frm.TopLevel = false;
                    frm.Parent = panel5;
                    frm.Dock = DockStyle.Bottom;
                    frm.Height = panel5.Height / 8;
                    frm.BinCode = i;
                    frm.Width = panel5.Width;
                    frm.Show();
                }

            }catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            }catch(Exception ex)
            {

            }
        }
    }
}
