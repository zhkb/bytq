using Material;
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

namespace Monitor.BoxBodyStore
{
  
    public partial class FrmStoreBin : Form
    {

        public int MaxBinNo = 0;
        public int BinNo = 0;//货道号
        public int MaxNum = 20;
        public int Actual = 0;

        public FrmStoreBin()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool Refresh = true;
                for (int i = 0; i < OptionSetting.StoreBinDataList.Count; i++)
                {
                    if (OptionSetting.StoreBinDataList[i].BinNo == BinNo)
                    {

                        lb_Bin_ID.Text = OptionSetting.StoreBinDataList[i].Bin_ID;
                        Actual = OptionSetting.StoreBinDataList[i].ActualQty;
                        lbl_StoreMaterName.Text = OptionSetting.StoreBinDataList[i].MaterialName;
                        lb_Max_Qty.Text = MaxNum.ToString();
                        int ActualQty = int.Parse(OptionSetting.StoreBinDataList[i].ActualQty.ToString());
                        lb_Actual_Qty.Text = ActualQty.ToString();
                        int TransitQty = int.Parse(OptionSetting.StoreBinDataList[i].TransitQty.ToString());
                        lb_Transit_Qty.Text = TransitQty.ToString();
                        lb_Bin_Flag.Text = (OptionSetting.StoreBinDataList[i].BinFlag == 0) ? "OK" : "NG";
                        if (OptionSetting.StoreBinDataList[i].BinFlag == 0)
                        {
                            lb_Bin_Flag.BackColor = Color.FromArgb(16, 16, 16);
                            lb_Bin_Flag.ForeColor = Color.Gold;
                        }
                        else
                        {
                            lb_Bin_Flag.BackColor = Color.FromArgb(16, 16, 16);
                            lb_Bin_Flag.ForeColor = Color.Red;
                        }
                        LoadStock(ActualQty, TransitQty);
                        Refresh = false;
                    }

                }
                if (Refresh)
                {
                    lb_Bin_ID.Text = "0";
                    lbl_StoreMaterName.Text = "";
                    lb_Max_Qty.Text = MaxNum.ToString();
                    lb_Actual_Qty.Text = "0";
                    lb_Transit_Qty.Text = "0";
                    lb_Bin_Flag.Text = "OK";
                    LoadStock(0, 0);
                }


            }
            catch (Exception ex)
            {


            }






        }



        #region 库存显示


        private void LoadStock(int Actual, int TransitQty)
        {

            for (int i = 0; i < MaxNum; i++)
            {
                Button b = Controls.Find("btn_" + i, true)[0] as Button;
                b.BackColor = System.Drawing.Color.White;

            }

            for (int i = 0; i < MaxNum; i++)
            {
                if (i < Actual)
                {

                    Button b = Controls.Find("btn_" + i, true)[0] as Button;
                    b.BackColor = Color.Lime;
                }
                if ((TransitQty + Actual) > i && i >= Actual)
                {

                    Button b = Controls.Find("btn_" + i, true)[0] as Button;
                    b.BackColor = Color.DodgerBlue;
                }

            }


        }
        #endregion

    
     

        private void FrmStoreBin_Load(object sender, EventArgs e)
        {
            //设置货道号
            lbl_BinNo.Text = BinNo + "#";
            lb_Max_Qty.Text = MaxNum.ToString();


            pnl_Title.Visible = (BinNo == 1);

         
        }
    }
}
