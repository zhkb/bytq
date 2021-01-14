using Sys.Config;
using Sys.DbUtilities;
using Sys.Language;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmGridding3 : Form
    {
        private string EnergyCode = "";//能耗贴编号
        private string EnergyName = "";//能耗贴名称
        private int TheoryQty = 0;//理论数量
        private int ActualQty = 0;//实际数量
        private string picture = "";//图片 
        private int mm = 0;
        public FrmGridding3()
        {
            InitializeComponent();
            
        }

        #region 界面加载

        private void FrmGridding_Load(object sender, EventArgs e)

        {
            if (BaseSystemInfo.LanguageType == "2")
            {
                ChangLanguage.SetLang("en-US", this, typeof(FrmGridding));
            }
            //刷新产品

            ReMaterialInfo();
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Enabled = true;
            //timer1.Tick += new EventHandler(timer1_Tick);
        }

        #endregion

        #region 时间控件执行事件 实现界面闪烁

        private void timer1_Tick(object sender, EventArgs e)
        {


            lbl_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            lbl_NO.ForeColor = Color.Aqua;
            if (OptionSetting.BNum==lbl_NO.Text.ToString().Trim())
            {
                lbl_NO.ForeColor = Color.Black;
                lbl_NO.BackColor = Color.Lime;
            }
            GetQty();
            if (ActualQty < 0)
            {
                lbl_Number.Text = "";
                return ;
            }
            lbl_Number.Text = ActualQty.ToString();

            if (lbl_Number.Text.ToString().Trim().Length != 0 && TheoryQty >= 0)//理论数量最好不小于100
            {
                double Wmarknum = 0.2 * TheoryQty;
                double Emarknum = 0.1 * TheoryQty;
                int num = int.Parse(lbl_Number.Text.ToString().Trim());
                if (num <= Wmarknum && num > Emarknum)
                {
                    timer2.Stop();
                    bool flag = timer2.Enabled;
                    lbl_Number.BackColor = Color.Yellow;
                    lbl_Number.ForeColor = Color.Black;        
                }
                else if (num <= Emarknum && num >= 0)
                {
                    #region 修改闪烁时间
                    Double d = (double)ActualQty / (double)TheoryQty;
                    int dd = (int)(d * 10000);
                    if (dd <= 200)
                    {
                        timer2.Interval = 200;
                    }
                    else
                    {
                        timer2.Interval = dd;
                    }
                    #endregion
                    if (!timer2.Enabled)//判断计时器是否正在运行
                    {                
                        timer2.Start();
                        timer2.Enabled = true;
                        mm = 1;
                    }
                }
                else
                {
                    timer2.Stop();
                    bool flag = timer2.Enabled;
                    lbl_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
                    lbl_Number.ForeColor = Color.Gold;                   
                }
            }
        }

        #endregion

        #region 获取能耗贴信息
        private void GetQty()
        {
            try
            {
                string sql = String.Format(@"SELECT
	                                          Energy_Label_Code,Energy_Label_Name,Material_Actual_Qty,Material_Theory_Qty,Energy_Label_Image
                                         FROM
	                                          IMOS_TA_Energy_List
                                        WHERE
	                                       Bin_No = {0} AND Company_Code = '{1}' AND Company_Name = '{2}' AND Factory_Code = '{3}' AND Factory_Name='{4}' AND Product_Line_Code ='{5}' AND Product_Line_Name='{6}'", lbl_NO.Text.ToString().Trim(),
                                               BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
                DataSet ds = DataHelper.Fill(sql);


                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    EnergyCode = ds.Tables[0].Rows[0]["Energy_Label_Code"].ToString();
                    EnergyName = ds.Tables[0].Rows[0]["Energy_Label_Name"].ToString();
                    picture = ds.Tables[0].Rows[0]["Energy_Label_Image"].ToString();
                    ActualQty = int.Parse(ds.Tables[0].Rows[0]["Material_Actual_Qty"].ToString());
                    TheoryQty = int.Parse(ds.Tables[0].Rows[0]["Material_Theory_Qty"].ToString());
                    return;
                }
                ActualQty = -1;
                TheoryQty = -1;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取数量发生异常:" + ex.Message);
                ActualQty = -2;
                TheoryQty = -2;
            }
        }

        #endregion
        #region 背景颜色变化

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_Number.ForeColor = Color.Black;
            if (mm == 0)
            {
                lbl_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
                mm++;
            }else
            {
                lbl_Number.BackColor = Color.Red;             
                mm=0;
            }
        }

        #endregion

        #region 双击网格号打开网格号维护界面
        private void lbl_NO_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //下传PLC停线

                //从现有的数据库中获取能耗贴
              
                FrmEnModify fem = new FrmEnModify();
                fem.BinNo = lbl_NO.Text.ToString();
                fem.EnCode = EnergyCode;
                fem.EnName = EnergyName;
                fem.TQty = TheoryQty.ToString();
                fem.AQty = lbl_Number.Text.ToString();
                fem.Picture = picture;
                DialogResult r = fem.ShowDialog();
                if (r == DialogResult.OK)
                {
                    ReMaterialInfo();
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("能耗贴维护失败！");
            }
        }
        #endregion

        #region 刷新产品信息
        private void ReMaterialInfo()
        {
            try
            {
                string sql = String.Format(@"SELECT
	                                         a.Product_Name
                                         FROM
	                                         IMOS_TA_Map AS a
                                         LEFT JOIN IMOS_TA_Energy_List AS b
                                              ON a.Material_Code = b.Energy_Label_Code
                                        AND a.Company_Code = b.Company_Code
                                        AND a.Company_Name = b.Company_Name
                                        AND a.Factory_Code = b.Factory_Code
                                        AND a.Factory_Name = b.Factory_Name
                                        AND a.Product_Line_Code = b.Product_Line_Code
                                        AND a.Product_Line_Name = b.Product_Line_Name
                                        WHERE
                                           	b.Bin_No = {0}
                                        AND a.Company_Code = '{1}'
                                        AND a.Company_Name = '{2}'
                                        AND a.Factory_Code = '{3}'
                                        AND a.Factory_Name = '{4}'
                                        AND a.Product_Line_Code = '{5}'
                                        AND a.Product_Line_Name = '{6}'
                                        GROUP BY
                                              a.Product_Name", lbl_NO.Text.ToString().Trim(), BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode,
                                              BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        Label t1 = Controls.Find("lbl_S" + i, true)[0] as Label;
                        if (i <= ds.Tables[0].Rows.Count)
                        {
                            t1.Text = ds.Tables[0].Rows[i - 1]["Product_Name"].ToString();
                        }
                        else
                        {
                            t1.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新产品信息失败！");
            }
        }
        #endregion
    }
}
