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
    public partial class FrmBinMonitor : Form
    {
        public int BinCode = 0;
        public string OldMName = "";
        public FrmBinMonitor()
        {
            InitializeComponent();
        }

        private void FrmBinMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Sort,Material_Name FROM IMOS_TA_Material WHERE 1=1 Order By Material_Sort ");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    comboBox1.DataSource = ds.Tables[0];
                    comboBox1.DisplayMember = "Material_Name";
                    comboBox1.ValueMember = "Material_Sort";
                }
                comboBox1.Text = OldMName;

            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.StoreBuff[(BinCode - 1) * 10].ToString() != "0")
                {
                    SysBusinessFunction.SystemDialog(2, "货道未清空！");
                    return;
                }
                
                int ad = BaseSystemInfo.CKAddress+BinCode-1;
                int len = BaseSystemInfo.CKLen;
                object[] wbuf = new object[len];
                object[] rbuf = new object[len];
                ControlXPLC.ReadData(0, ad,len,out rbuf);
                //验证库存是否足够
                String chsql = String.Format(@"SELECT
	                                                 ISNULL(SUM (Store_Qty), 0) Store_Sum_Qty,
	                                                 ISNULL(SUM (Max_Qty), 0) Max_Sum_Qty
                                               FROM
	                                                 IMOS_Lo_Bin
                                               WHERE
	                                                 Material_Sort = '{0}' and In_Flag = '{1}'", rbuf[0].ToString(), "0");

                DataSet chds = DataHelper.Fill(chsql);
                if (chds != null)
                {
                    if (chds.Tables[0].Rows.Count >= 0)
                    {
                        String getsql = String.Format(@"SELECT ISNULL(SUM (1), 0) de_sum_Qty  FROM IMOS_Lo_Bin_Detial Where Material_Sort = '{0}'", rbuf[0].ToString());
                        DataSet getds = DataHelper.Fill(getsql);
                        if (getds != null && getds.Tables[0].Rows.Count > 0)
                        {
                            int ssq = int.Parse(chds.Tables[0].Rows[0]["Store_Sum_Qty"].ToString());
                            int msq = int.Parse(chds.Tables[0].Rows[0]["Max_Sum_Qty"].ToString());
                            int dsq = int.Parse(getds.Tables[0].Rows[0]["de_sum_Qty"].ToString());
                            if (dsq + ssq > msq-7)
                            {
                                SysBusinessFunction.SystemDialog(2, "修改后货道不能满足入库需求！在途"+dsq+ "在库"+ssq+"最大"+msq);
                                return;
                            }
                            
                        }
                    }
                }

                //
                wbuf[0] = comboBox1.SelectedValue.ToString();
                bool fl = ControlXPLC.WriteData(0, ad, wbuf);
                if (fl)
                {
                    SysBusinessFunction.WriteLog("更新货道存储型号成功：货道【"+ BinCode + "】产品【" + comboBox1.SelectedValue.ToString()+"】");
                }
                String sql = String.Format(@"SELECT
                                                    Material_Sort,
	                                                Material_Code,
	                                                Material_Name
                                                FROM
	                                                IMOS_TA_Material
                                                WHERE
	                                                Material_Sort = '{0}'", comboBox1.SelectedValue.ToString());
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET Material_Code = '{0}',Material_Name = '{1}',Material_Sort = '{3}' Where Store_Code = '{2}'", ds.Tables[0].Rows[0]["Material_Code"].ToString(), comboBox1.Text.ToString(), BinCode, comboBox1.SelectedValue.ToString());
                    DataHelper.Fill(upsql);
                }
                DialogResult = DialogResult.OK;



            }
            catch (Exception ex)
            {

            }
        }

        private void btn_K3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.No;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
