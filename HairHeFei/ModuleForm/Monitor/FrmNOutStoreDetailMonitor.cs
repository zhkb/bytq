using ControlLogic.Control;
using Sys.Config;
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
    public partial class FrmNOutStoreDetailMonitor : Form
    {
        public int BinCode = 0;
        private string mcode = "";
        public bool firstflag = true;
        public bool OnlyShow = false;

        public FrmNOutStoreDetailMonitor()
        {
            InitializeComponent();
        }


        private void FrmOutStoreDetailMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                panel1.Height = this.Height;
                panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
                lbl_BinStore.Text = BinCode + "#";
                pan_KW1.Width = this.Width / 7;
                pan_KW2.Width = this.Width / 7;
                pan_KW3.Width = this.Width / 7;
                pan_KW4.Width = this.Width / 7;
                pan_KW5.Width = this.Width / 7;
                pan_KW6.Width = this.Width / 7;
                pan_KW7.Width = this.Width / 7;
                lbl_BinStore.Width = this.Width / 4;
                lbl_Material_Name.Width = this.Width / 2;
                lbl_Sum.Width = this.Width / 4;
                panel2.Visible = false;
               
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();

                //getBinData();
                
            }
            catch(Exception ex)
            {

            }
        }
        private void getBinData()
        {
            try
            {

                int ad = BaseSystemInfo.CKAddress + BinCode - 1;
                int len = BaseSystemInfo.CKLen;
                object[] rbuf = new object[len];
                bool fl = ControlXPLC.ReadData(0, ad, len,out rbuf);
                if (fl)
                {
                    String sql = String.Format(@"SELECT
                                                    Material_Sort,
	                                                Material_Code,
	                                                Material_Name
                                                FROM
	                                                IMOS_TA_Material
                                                WHERE
	                                                Material_Sort = '{0}'", rbuf[0].ToString());
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds != null)
                    {
                        mcode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        lbl_Material_Name.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();

                    }

                }
            
            }
            catch(Exception ex)
            {

            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            Material_Name,
	                                            Store_Qty 
                                            FROM
	                                            IMOS_Lo_Bin 
                                            WHERE
	                                            Store_Code = {0}",BinCode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null&&ds.Tables[0].Rows.Count>0)
                {
                    lbl_Material_Name.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                    lbl_Sum.Text = ds.Tables[0].Rows[0]["Store_Qty"].ToString();
                }
               
            }
            catch(Exception ex)
            {

            }
        }




    }
}
