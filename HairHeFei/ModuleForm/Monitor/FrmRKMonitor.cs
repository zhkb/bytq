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
    public partial class FrmRKMonitor : Form
    {
        public FrmRKMonitor()
        {
            InitializeComponent();
        }

        public int Mtype = 0;

        private void FrmRKMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                pan_JK1.Height = this.Height / 8;
                pan_JK2.Height = this.Height / 8;
                pan_JK3.Height = this.Height / 8;
                pan_JK4.Height = this.Height / 8;
                pan_JK5.Height = this.Height / 8;
                pan_JK6.Height = this.Height / 8;
                pan_JK7.Height = this.Height / 8;
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();

            }
            catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Mtype == 1)
                {
                    if (OptionSetting.RKStoreBuff == null)
                    {
                        return;
                    }

                    if (OptionSetting.BinDetailds != null)
                    {
                        for (int i = 0; i <= 7; i++)
                        {
                            String rfid = OptionSetting.RKStoreBuff[i].ToString();
                            bool flag = false;
                            String nmae = "";
                            for (int j = 0; j < OptionSetting.BinDetailds.Tables[0].Rows.Count; j++)
                            {
                                if (rfid == OptionSetting.BinDetailds.Tables[0].Rows[j]["RFID_Code"].ToString())
                                {
                                    nmae = OptionSetting.BinDetailds.Tables[0].Rows[j]["Material_Name"].ToString();
                                    flag = true;
                                }
                            }
                            Button btn = Controls.Find("btn_K" + (i + 1), true)[0] as Button;
                            btn.Text = nmae;
                            if (flag)
                            {
                                btn.BackColor = Color.Green;
                            }
                            else
                            {
                                btn.BackColor = Color.Gray;
                            }
                        }
                    }
                }
                else if (Mtype == 2)
                {
                    if (OptionSetting.CKStoreBuff == null)
                    {
                        return;
                    }

                    if (OptionSetting.BinDetailds != null)
                    {
                        for (int i = 0; i <= 7; i++)
                        {
                            String rfid = OptionSetting.CKStoreBuff[i].ToString();
                            bool flag = false;
                            String nmae = "";
                            for (int j = 0; j < OptionSetting.BinDetailds.Tables[0].Rows.Count; j++)
                            {
                                if (rfid == OptionSetting.BinDetailds.Tables[0].Rows[j]["RFID_Code"].ToString())
                                {
                                    nmae = OptionSetting.BinDetailds.Tables[0].Rows[j]["Material_Name"].ToString();
                                    flag = true;
                                }
                            }
                            Button btn = Controls.Find("btn_K" + (i+1), true)[0] as Button;
                            btn.Text = nmae;
                            if (flag)
                            {
                                btn.BackColor = Color.Green;
                            }
                            else
                            {
                                btn.BackColor = Color.Gray;
                            }
                        }
                    }
                }
                else
                {
                    return;
                }

            }
            catch(Exception ex)
            {

            }
        }
    }
}
