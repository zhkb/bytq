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
using System.Windows.Forms;

namespace PickingMonitor
{
    public partial class FrmBinDetail : Form
    {
        public int No = 0;
        
        public FrmBinDetail()
        {
            InitializeComponent();
        }

        private void FrmBinDetail_Load(object sender, EventArgs e)
        {
            lbl_BinNo.Text = No.ToString();
            timer1.Interval = 5000;
            timer1.Enabled = true;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.BinDetaildt == null)
                {
                    return;
                }
                for (int i = 0; i < OptionSetting.BinDetaildt.Rows.Count; i++)
                {

                    if (OptionSetting.BinDetaildt.Rows[i]["STORE_SORT"].ToString() == No.ToString())
                    {
                        //判断是否处于禁用状态
                        if (OptionSetting.BinDetaildt.Rows[i]["DELETE_FLAG"].ToString() == "1")
                        {
                            this.lbl_BinNo.BackColor = Color.Red;
                            return;
                        }
                        if (OptionSetting.BinDetaildt.Rows[i]["MATERIAL_STATE"].ToString() == "9")
                        {
                            this.lbl_BinNo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                        }
                        else if (OptionSetting.BinDetaildt.Rows[i]["MATERIAL_STATE"].ToString() == "4")
                        {
                            this.lbl_BinNo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                        }
                        else if (OptionSetting.BinDetaildt.Rows[i]["MATERIAL_STATE"].ToString() == "0")
                        {
                            this.lbl_BinNo.BackColor = Color.DarkOrange;
                        }
                        else
                        {
                            this.lbl_BinNo.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void lbl_BinNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //从数据库获取禁用状态
                String DFLAG = "";
                String sql = String.Format(@"SELECT
	                                            DELETE_FLAG
                                            FROM
	                                            IMOS_LO_STORE_BIN_DETIAL
                                            WHERE
                                            (
	                                            STORE_CODE = '{0}'
	                                            OR STORE_CODE = '{1}'
                                            )
                                            AND STORE_SORT = {2}",
                              BaseSystemInfo.StoreCode1,BaseSystemInfo.StoreCode2,No);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    DFLAG = ds.Tables[0].Rows[0]["DELETE_FLAG"].ToString();
                }
                else
                {
                    SysBusinessFunction.WriteLog("没有查找到对应库位的状态");
                    SysBusinessFunction.SystemDialog(2, "没有查找到对应库位的状态");
                    return;
                }
                if ("0"==DFLAG)
                {
                    DialogResult dres = SysBusinessFunction.SystemDialog(1, "确定将库位设置为禁用状态吗？");
                    if (dres == DialogResult.OK)
                    {
                        UpdDelete("1");
                        this.lbl_BinNo.BackColor = Color.Red;
                    }

                } else if("1" == DFLAG)
                {
                    DialogResult dres = SysBusinessFunction.SystemDialog(1, "确定将库位设置为启用状态吗？");
                    if (dres == DialogResult.OK)
                    {
                        UpdDelete("0");
                        this.lbl_BinNo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                    }
                }

            }catch(Exception ex)
            {

            }
        }
        private void UpdDelete(String dflag)
        {
            try
            {
                String sql = String.Format(@"UPDATE IMOS_LO_STORE_BIN_DETIAL
                                                SET DELETE_FLAG = '{3}'
                                                WHERE
	                                                (
		                                                STORE_CODE = '{0}'
		                                                OR STORE_CODE = '{1}'
	                                                )
                                                AND STORE_SORT = {2}",
                                                BaseSystemInfo.StoreCode1,
                                                BaseSystemInfo.StoreCode2,No,
                                                dflag);
                DataHelper.Fill(sql);

                
            }catch(Exception ex)
            {

            }
        }
    }
}
