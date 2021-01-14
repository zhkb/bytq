using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.SysBusiness;
namespace Monitor
{
    public partial class FrmTaskModel2 : Form
    {
        public int iXH = 0;//序号
        public FrmTaskModel2()
        {
            InitializeComponent();
        }

        private void FrmTaskModel2_Load(object sender, EventArgs e)
        {
            lblID.Text = iXH.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool Refresh = true;
                for (int i = 0; i < OptionSetting.StoreShowDataList2.Count; i++)
                {
                    if (OptionSetting.StoreShowDataList2[i].ID == iXH.ToString())
                    {

                        lblName.Text = OptionSetting.StoreShowDataList2[i].Material_Name;
                        lblBar_Code.Text = OptionSetting.StoreShowDataList2[i].Bar_Code;
                        lblTask_Store_Code.Text = OptionSetting.StoreShowDataList2[i].Store_Code;
                        lblTask_RFID.Text = OptionSetting.StoreShowDataList2[i].RFID_BarCode;
                        lblTask_State.Text = OptionSetting.StoreShowDataList2[i].Task_State;
                        lblStart_Time.Text = OptionSetting.StoreShowDataList2[i].Start_Time;

                        Refresh = false;
                    }
                    //break;
                }
                if (Refresh)
                {
                    lblName.Text = "";
                    lblBar_Code.Text = "";
                    lblTask_Store_Code.Text = "";
                    lblTask_RFID.Text = "";
                    lblTask_State.Text = "";
                    lblTask_State.ForeColor = Color.FromArgb(56, 68, 92);
                    lblStart_Time.Text = "";
                }

            }
            catch (Exception ex)
            {


            }

        }
    }
}
