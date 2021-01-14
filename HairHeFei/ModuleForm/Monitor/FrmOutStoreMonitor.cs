using Sys.DbUtilities;
using Sys.SysBusiness;
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
    public partial class FrmOutStoreMonitor : Form
    {
        private int count = 0;
        private DataSet storeds;
        public FrmOutStoreMonitor()
        {
            InitializeComponent();
        }



    
     
      

        private void FrmBinStoreMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                for(int i = 1; i <= 8; i++)
                {
                    FrmOutStoreDetailMonitor fsdm = new FrmOutStoreDetailMonitor();
                    fsdm.TopLevel = false;
                    fsdm.Parent = panel2;
                    fsdm.Dock = DockStyle.Top;
                    fsdm.BinCode = i;
                    fsdm.Show();
                }
            }catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

       

        private void timer2_Tick(object sender, EventArgs e)
        {
         
        }
    }
    
}
