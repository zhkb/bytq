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
using System.Threading;
namespace Monitor
{
    public partial class FrmTaskModel : Form
    {
        public int iXH = 0;//序号
        public string strTask_Type = "";
        public string strStore_Code = "";
        public FrmTaskModel()
        {
            InitializeComponent();
        }

        private void FrmTaskModel_Load(object sender, EventArgs e)
        {
            lblID.Text = iXH.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool Refresh = true;
                for (int i = 0; i < OptionSetting.StoreShowDataList.Count; i++)
                {
                    if (OptionSetting.StoreShowDataList[i].ID == iXH.ToString() && OptionSetting.StoreShowDataList[i].Task_Type == strTask_Type)
                    {

                        lblName.Text = OptionSetting.StoreShowDataList[i].Material_Name;
                        lblBar_Code.Text = OptionSetting.StoreShowDataList[i].Bar_Code;
                        lblTask_Store_Code.Text = OptionSetting.StoreShowDataList[i].Store_Code;
                        lblTask_RFID_Code.Text = OptionSetting.StoreShowDataList[i].RFID_BarCode;

                        lblTask_State.Text = OptionSetting.StoreShowDataList[i].Task_State;
                        lblStart_Time.Text = OptionSetting.StoreShowDataList[i].Start_Time;

                        Refresh = false;
                        break;
                    }
                }
                if (Refresh)
                {
                    lblName.Text = "";
                    lblBar_Code.Text = "";
                    lblTask_Store_Code.Text = "";
                    lblTask_RFID_Code.Text = "";
                    lblTask_State.Text = "";
                    lblTask_State.ForeColor = Color.Gold;
                    lblTask_State.BackColor = Color.FromArgb(56, 68, 92);
                    lblStart_Time.Text = "";
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("FrmTaskModel timer1_Tick:" + ex.Message);
            }

        }
    }
}
