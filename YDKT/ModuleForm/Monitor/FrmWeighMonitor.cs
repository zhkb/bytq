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
    using Sys.Config;
    using Sys.SysBusiness;
    public partial class FrmWeighMonitor : Form
    {
      
        public FrmWeighMonitor()
        {
            InitializeComponent();
        }
        FrmWeigh TempForm1 = new FrmWeigh();
        FrmWeigh TempForm2 = new FrmWeigh();
        private void FrmProductMonitor_Load(object sender, EventArgs e)
        {
            panel1.Width = 950;

           
            TempForm1.TopLevel = false;
            TempForm1.FormBorderStyle = FormBorderStyle.None;
            TempForm1.StationNo = BaseSystemInfo.CurrentStationNo1;
            TempForm1.Parent = panel1;
            TempForm1.Dock = DockStyle.Fill;            
            TempForm1.Show();

            
            TempForm2.TopLevel = false;
            TempForm2.FormBorderStyle = FormBorderStyle.None;
            TempForm2.StationNo = BaseSystemInfo.CurrentStationNo2;
            TempForm2.Parent = panel3;
            TempForm2.Dock = DockStyle.Fill;
            TempForm2.Show();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OptionSetting.ScanFlagA == true)
            {
                TempForm1.ScanBarCode = OptionSetting.ProBarCodeA;
                TempForm1.ProductModel = OptionSetting.ProductModeA;               
                TempForm1.CurrentWeight = OptionSetting.CurrentWeightA;
                TempForm1.TempStandWeight = OptionSetting.TempStandWeightA;
                TempForm1.TempTolerance = OptionSetting.TempToleranceA;
            }

            TempForm1.MsgInfo = OptionSetting.MsgInfoA;
            TempForm2.MsgInfo = OptionSetting.MsgInfoB;

            if (OptionSetting.ScanFlagB == true)
            {
                TempForm2.ScanBarCode = OptionSetting.ProBarCodeB;
                TempForm2.ProductModel = OptionSetting.ProductModeB;                
                TempForm2.CurrentWeight = OptionSetting.CurrentWeightB;
                TempForm2.TempStandWeight = OptionSetting.TempStandWeightB;
                TempForm2.TempTolerance = OptionSetting.TempToleranceB;
            }
        }
    }
}