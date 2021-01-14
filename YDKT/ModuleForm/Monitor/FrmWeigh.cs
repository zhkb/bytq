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

    public partial class FrmWeigh : Form
    {
        public string WeighIP = "127.0.0.1";
        public int WeighPort = 4001;
        public string OperatorName_CH = "";
        public string OperatorName_EN = "";
        public string ProcessName_CH = "";
        public string ProcessName_EN = "";

        public string StationNo = "";

        public int CycleTime = 0;
        public string ScanBarCode = "";
        public string ProductModel = "";
        public string MsgInfo = "";

        public decimal CurrentWeight = 0;
        public decimal TempStandWeight = 0;
        public decimal TempTolerance = 0;


        public FrmWeigh()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_OperatoeName_CH.Text = OperatorName_CH;
            lbl_OperatoeName_EN.Text = OperatorName_EN;
            lbl_ProcessName_CH.Text = ProcessName_CH;
            lbl_ProcessName_EN.Text = ProcessName_EN;

            lbl_BarCode.Text = ScanBarCode;
            lbl_ProductModel.Text = ProductModel;
            lbl_MessageInfo.Text = MsgInfo;

            lbl_CycleTime_CH.Text = CycleTime.ToString() + "S";

            lbl_CurrentWeight.Text = CurrentWeight.ToString("N3");

            lbl_StandWeight.Text = TempStandWeight.ToString("N3");

            lbl_Tolerance.Text = TempTolerance.ToString("N3");
        }

        private void FrmWeigh_Load(object sender, EventArgs e)
        {
            OperatorName_CH = BaseSystemInfo.CurrentUserName;
            ProcessName_CH = StationNo + "# " + BaseSystemInfo.CurrentProcessName;
            ProcessName_EN = StationNo + "# " + BaseSystemInfo.CurrentProcessName_EN;
            OperatorName_EN = BaseSystemInfo.CurrentUserName_EN;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
