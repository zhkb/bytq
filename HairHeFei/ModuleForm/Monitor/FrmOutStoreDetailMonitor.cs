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
    public partial class FrmOutStoreDetailMonitor : Form
    {
        public int BinCode = 0;
        private string mcode = "";
        public int OnlyShow = int.Parse(BaseSystemInfo.CurrentINStoreCode);//1主程序 2 次程序 3 看板

        public FrmOutStoreDetailMonitor()
        {
            InitializeComponent();
        }


        private void FrmOutStoreDetailMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                panel1.Height = this.Height / 2;
                if (OnlyShow == 3)
                {
                    panel1.BackColor =  System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
                    btn_Init_Code.Visible = false;
                    btn_Use.Visible = false;
                    panel2.Visible = false;
                    panel1.Height = this.Height ;
                    lbl_Sum.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lbl_Material_Name.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lbl_BinStore.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                 
                }
                lbl_BinStore.Text = BinCode + "#";
                pan_KW1.Width = this.Width / 7;
                pan_KW2.Width = this.Width / 7;
                pan_KW3.Width = this.Width / 7;
                pan_KW4.Width = this.Width / 7;
                pan_KW5.Width = this.Width / 7;
                pan_KW6.Width = this.Width / 7;
                pan_KW7.Width = this.Width / 7;
                lbl_BinStore.Width = this.Width / 4;
                lbl_Material_Name.Width = this.Width / 4;
                
                if (OnlyShow == 3)
                {
                    lbl_Material_Name.Width = this.Width / 2;
                    lbl_Sum.Width = this.Width / 4;
                    btn_Init_Code.Width = this.Width / 8;
                    btn_Use.Width = this.Width / 8;
                }
                else
                {
                    lbl_Sum.Width = this.Width / 8;
                    btn_Init_Code.Width = this.Width / 8;
                    btn_Use.Width = this.Width / 8;
                }
              
           
               
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();

                getBinData();
                
            }
            catch(Exception ex)
            {

            }
        }
        private void getBinData()
        {
            try
            {
                if(OptionSetting.StoreBuff == null)
                {
                    return;
                }
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
                    if (ds != null && ds.Tables[0].Rows.Count>0)
                    {
                        mcode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        lbl_Material_Name.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        if (OnlyShow == BaseSystemInfo.MCXFlag)
                        {
                            //主程序一直执行 
                            String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET Material_Code = '{0}',Material_Name = '{1}',Material_Sort = '{3}',Store_Qty = '{4}' Where Store_Code = '{2}'", mcode, ds.Tables[0].Rows[0]["Material_Name"].ToString(), BinCode, rbuf[0].ToString(),OptionSetting.StoreBuff[(BinCode-1)*10].ToString());
                            DataHelper.Fill(upsql);
                        }
                    }

                }
                int YXJad = BaseSystemInfo.YXJaddress + BinCode - 1;
                object[] ybuf = new object[1];
                bool yfl = ControlXPLC.ReadData(0, YXJad, 1, out ybuf);
                if (yfl)
                {
                    if (OnlyShow == BaseSystemInfo.MCXFlag)
                    {
                        //主程序一直执行 
                        String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET In_Flag = '{0}' Where Store_Code = '{1}'", ybuf[0].ToString(), BinCode);
                        DataHelper.Fill(upsql);
                        if("0"== ybuf[0].ToString())
                        {
                            btn_Use.Text = "正常模式";
                            btn_Use.ForeColor = Color.Lime;
                        }
                        else
                        {
                            btn_Use.Text = "禁进先出";
                            btn_Use.ForeColor = Color.Red;
                        }
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
                if (OnlyShow == 3)
                {
                    if (OptionSetting.StoreBuff[0] == null)
                    {
                        return;
                    }
                    getBinData();
                    lbl_Sum.Text = OptionSetting.StoreBuff[(BinCode - 1) * 10].ToString();
                }
                else
                {
                    if (OptionSetting.StoreBuff[0] == null)
                    {
                        return;
                    }
                    lbl_Sum.Text = OptionSetting.StoreBuff[(BinCode - 1) * 10].ToString();
                    
                    if (OptionSetting.BinDetailds != null)
                    {
                        for (int i = 1; i <= 7; i++)
                        {

                            String sort = OptionSetting.StoreBuff[(BinCode - 1) * 10 + i].ToString();
                            Button btn = Controls.Find("btn_K" + i, true)[0] as Button;
                            if(sort == "0")
                            {
                                btn.BackColor = Color.Gray;
                                btn.Text = "";
                                continue;
                            }
                            for (int j = 0; j < OptionSetting.BinDetailds.Tables[0].Rows.Count; j++)
                            {
                                
                                if (sort == OptionSetting.BinDetailds.Tables[0].Rows[j]["Material_Sort"].ToString())
                                {
                                    btn.Text = OptionSetting.BinDetailds.Tables[0].Rows[j]["Material_Name"].ToString();
                                    btn.BackColor = Color.Green;
                                    break;
                                }
                            }
                            

                           

                           
                        }
                    }
                    getBinData();
                }
               
            }
            catch(Exception ex)
            {

            }
        }

        private void lbl_Material_Name_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnlyShow==3)
                {
                    return;
                }
                FrmBinMonitor fbm = new FrmBinMonitor();
                fbm.OldMName = lbl_Material_Name.Text;
                fbm.BinCode = BinCode;

                DialogResult dia = fbm.ShowDialog();
                if (dia == DialogResult.OK)
                {
                    getBinData();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Init_Code_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnlyShow==3)
                {
                    return;
                }
                getBinData();
                if (mcode.Length == 9)
                {
                    OptionSetting.SDRKCode = mcode;
                    OptionSetting.JLFlag = false;
                }
                else
                {
                    SysBusinessFunction.SystemDialog(2,"物料编码不足九位，请重新维护物料物料编码！");
                }
                
            }catch(Exception ex)
            {

            }
        }

        private void btn_Use_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Use.Text =="正常模式")
                {
                    string sMessage = "确认将货道修改为【禁进先出】模式吗？";
                    if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        int YXJad = BaseSystemInfo.YXJaddress + BinCode - 1;
                        object[] ybuf = new object[1];
                        ybuf[0] = 1;
                        bool yfl = ControlXPLC.WriteData(0, YXJad,ybuf);
                        if (yfl)
                        {
                            if (OnlyShow == BaseSystemInfo.MCXFlag)
                            {
                                //主程序一直执行 
                                String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET In_Flag = '{0}' Where Store_Code = '{1}'", ybuf[0].ToString(), BinCode);
                                DataHelper.Fill(upsql);
                            }
                        }
                        btn_Use.Text = "禁进先出";
                        btn_Use.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string sMessage = "确认将货道修改为【正常】模式吗？";
                    if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        int YXJad = BaseSystemInfo.YXJaddress + BinCode - 1;
                        object[] ybuf = new object[1];
                        ybuf[0] = 0;
                        bool yfl = ControlXPLC.WriteData(0, YXJad, ybuf);
                        if (yfl)
                        {
                            if (OnlyShow ==BaseSystemInfo.MCXFlag)
                            {
                                //主程序一直执行 
                                String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET In_Flag = '{0}' Where Store_Code = '{1}'", ybuf[0].ToString(), BinCode);
                                DataHelper.Fill(upsql);
                            }
                        }
                        btn_Use.Text = "正常模式";
                        btn_Use.ForeColor = Color.Lime;
                    }
                }
                


            }
            catch (Exception ex)
            {

            }
        }
    }
}
