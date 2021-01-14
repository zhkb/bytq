using Material;
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


    public partial class FrmStoreDetailUshell : Form
    {
        public int MaxBinNo = 0;
        public int BinNo = 0;//货道号
        public int MaxNum = 20;
        public int Actual = 0;
        public static Color[] btnColor = { Color.Lime, Color.SkyBlue };

        private Random FRandom = new Random();
        public FrmStoreDetailUshell()
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
                        lb_Material_Code.Text = OptionSetting.StoreBinDataList[i].Material_Code;
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
                            lb_Bin_Flag.ForeColor = Color.Lime;
                        }
                        else {
                            lb_Bin_Flag.BackColor = Color.FromArgb(16, 16, 16);
                            lb_Bin_Flag.ForeColor = Color.Red;
                        }
                        LoadStock(ActualQty, TransitQty);
                        Refresh = false;
                    }
                    //break;
                }
                if (Refresh)
                {
                    lb_Bin_ID.Text = "0";
                    lb_Material_Code.Text = "";
                    lbl_StoreMaterName.Text = "";
                    lb_Max_Qty.Text = MaxNum.ToString();
                    lb_Actual_Qty.Text = "0";
                    lb_Transit_Qty.Text = "0";
                    lb_Bin_Flag.Text = "OK";
                    LoadStock(0,0);  //全白色
                }

             
            }
            catch (Exception ex) {


            }

          




        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //设置货道号
            lbl_BinNo.Text = BinNo + "#";
            lb_Max_Qty.Text = MaxNum.ToString();
            //设置表头
            int num = 0;
            if ((MaxBinNo & 1) == 1)
            {
                num = (MaxBinNo + 1) / 2 + 1;
            }
            else
            {
                num = (MaxBinNo) / 2 + 1;
            }

            //pnl_Title.Visible = ((BinNo == 1) || (BinNo == num));
            pnl_Title.Visible = (BinNo == 1);

            int width = 680;
            int btnWidth = width / MaxNum;
            for (int i = 0; i < MaxNum; i++)
            {
                Button b = new Button();
                b.Name = "btn_" + i;
                b.Width = btnWidth;
                b.BackColor = System.Drawing.Color.Gray;
                b.Parent = panel2;
                b.Left = i * btnWidth;
                b.Height = 14;
                b.FlatStyle = FlatStyle.Flat;
            }

        }

        #region 库存显示
  

        private void LoadStock(int Actual,int TransitQty) {

            for (int i = 0; i < MaxNum; i++)
            {
                Button b = Controls.Find("btn_" + i, true)[0] as Button;
                b.BackColor = System.Drawing.Color.White;

            }

            for (int i = 0; i < MaxNum; i++)
            {
                if (i < Actual) {

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

        /// <summary>
        /// 库存状态
        /// 0 正常  1 禁用
        /// </summary>
        /// <param name="Bin_Flag"></param>
        public void AddIMOSLoBin(int Bin_Flag)
        {
            try
            {
                int Bin_No = int.Parse(lbl_BinNo.Text.Replace("#", ""));
                string Material_Code = lb_Material_Code.Text.Trim();
                string Material_Name = lbl_StoreMaterName.Text.Trim();
                string InsertSql = string.Format("Insert Into IMOS_Lo_Bin(Company_Code,Factory_Code,Product_Line_Code,Bin_No,Material_Code,Material_Name,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,Store_Code) Values ('{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},{9},'{10}')",
                    BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Bin_No, Material_Code, Material_Name, MaxNum, 0, 0, Bin_Flag, "1001");
                if (Bin_No > 4)
                {
                    InsertSql = string.Format("Insert Into IMOS_Lo_Bin(Company_Code,Factory_Code,Product_Line_Code,Bin_No,Material_Code,Material_Name,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,Store_Code) Values ('{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},{9},'{10}')",
                    BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Bin_No, Material_Code, Material_Name, MaxNum, 0, 0, Bin_Flag, "1002");
                }
                DataHelper.Fill(InsertSql);

                lb_Bin_Flag.Text = (Bin_Flag == 0) ? "OK" : "NG";
            }
            catch (Exception ex)
            {


            }




        }
        /// <summary>
        ///更新货道状态信息
        /// </summary>
        /// <param name="Type"></param>
        public void EditIMOSLoBinFlag(int Bin_Flag)
        {
            int Bin_ID = int.Parse(lb_Bin_ID.Text.Trim());
            try
            {

                string SqlStr = string.Format(@"Update IMOS_Lo_Bin Set Bin_Flag = {0}
                                                        Where Bin_ID = {1}", Bin_Flag, Bin_ID);
                DataHelper.Fill(SqlStr);
                lb_Bin_Flag.Text = (Bin_Flag == 0) ? "OK" : "NG";
            }
            catch (Exception ex)
            {


            }



        }
        /// <summary>
        /// 更新货道产品信息
        /// </summary>

        private void lb_Bin_Flag_DoubleClick(object sender, EventArgs e)
        {


            try
            {
                int Bin_Flag = 1;
                string StrBin_Flag = lb_Bin_Flag.Text.Trim();
                if (StrBin_Flag == "OK")
                {
                    Bin_Flag = 2;//正常改为禁用
                }
                if (StrBin_Flag == "NG")
                {
                    Bin_Flag = 0;
                }

                int Bin_ID = lb_Bin_ID.Text.Trim() != "" ? int.Parse(lb_Bin_ID.Text.Trim()) : 0;

                DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确认修改货道状态？" + Environment.NewLine  +
                                                                                                            "Are you sure to modify aisle status ?");

                if (r == DialogResult.OK)
                {

                    if (Bin_ID == 0)//插入
                    {
                        AddIMOSLoBin(Bin_Flag);
                    }
                    else//更新
                    {
                        EditIMOSLoBinFlag(Bin_Flag);
                    }
                }






            }
            catch (Exception ex)
            {



            }



        }

        private void lbl_StoreMaterName_DoubleClick(object sender, EventArgs e)
        {
            int Bin_Flag = lb_Bin_Flag.Text.Trim() == "OK" ? 0 : 1;
            int Bin_ID = lb_Bin_ID.Text.Trim() != "" ? int.Parse(lb_Bin_ID.Text.Trim()) : 0;
            int Bin_No = int.Parse(lbl_BinNo.Text.Replace("#", ""));
            string strMaterName_old = lbl_StoreMaterName.Text;
            FrmMaterialSelect SelectMaterial = new FrmMaterialSelect();
            SelectMaterial.MaterialType = "MN002";
            DialogResult r = SelectMaterial.ShowDialog();

            if (r == DialogResult.OK)
            {

                string MaterialCode = SelectMaterial.MaterialCode;
                string MaterialName = SelectMaterial.MaterialName;
                try
                {

                    if (Bin_ID == 0)
                    {
                        string InsertSql = string.Format("Insert Into IMOS_Lo_Bin(Company_Code,Factory_Code,Product_Line_Code,Bin_No,Material_Code,Material_Name,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,Store_Code) Values ('{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},{9},'{10}')",
                        BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Bin_No, MaterialCode, MaterialName, MaxNum, 0, 0, Bin_Flag,"1001");
                        if(Bin_No>4)
                        {
                            InsertSql = string.Format("Insert Into IMOS_Lo_Bin(Company_Code,Factory_Code,Product_Line_Code,Bin_No,Material_Code,Material_Name,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,Store_Code) Values ('{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},{9},'{10}')",
                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Bin_No, MaterialCode, MaterialName, MaxNum, 0, 0, Bin_Flag, "1002");
                        }

                        DataHelper.Fill(InsertSql);

                    }
                    else
                    {
                        if (strMaterName_old == MaterialName)
                        {
                            return;
                        }

                        int iActual_Qty = int.Parse(lb_Actual_Qty.Text.Trim());
                        int iTransit_Qty = int.Parse(lb_Transit_Qty.Text.Trim());
                        if((iActual_Qty + iTransit_Qty)>0)
                        { 
                            DialogResult r2 = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "货道内已经有货物，是否确认更改货道型号？" + Environment.NewLine + Environment.NewLine + "There are already products in aisle，Are you sure to Change the product model?");
                            if (r2 != DialogResult.OK)
                            {
                                return;
                            }
                        }
                        else if(strMaterName_old != MaterialName)
                        {
                            DialogResult r2 = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "确认要更改货道型号？" + Environment.NewLine + Environment.NewLine + "Are you sure to Change the product model?");
                            if (r2 != DialogResult.OK)
                            {
                                return;
                            }
                        }


                        string SqlStr = string.Format(@"Update IMOS_Lo_Bin Set Material_Code = '{0}',Material_Name='{1}'
                                                        Where Bin_ID = {2}", MaterialCode, MaterialName, Bin_ID);
                        DataHelper.Fill(SqlStr);

                    }



                    lb_Material_Code.Text = MaterialCode;
                    lbl_StoreMaterName.Text = MaterialName;
                }
                catch (Exception ex)
                {


                }

            }

        }
    }
}
