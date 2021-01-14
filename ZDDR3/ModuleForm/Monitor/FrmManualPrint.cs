using FastReport;
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

namespace Monitor
{
    public partial class FrmManualPrint : Form
    {
        private DataTable mysqlDt;
        private Card c;
        public static FastReport.EnvironmentSettings eSet = new EnvironmentSettings();
        public FrmManualPrint()
        {
            InitializeComponent();
            dgv_BackProductList.TopLeftHeaderCell.Value = "序号";
        }

        private void dgv_BackProductList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            #region 设置表格序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dgv_BackProductList.RowHeadersWidth,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv_BackProductList.RowHeadersDefaultCellStyle.Font, rectangle, dgv_BackProductList.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.Right & TextFormatFlags.VerticalCenter);
            #endregion
        }
        //预览
        private void btn_Look_Click(object sender, EventArgs e)
        {
            if (dgv_BackProductList.SelectedRows.Count == 1)
            {
                string code = dgv_BackProductList.SelectedRows[0].Cells["WorkUser_BarCode"].Value.ToString();
                string cipher = dgv_BackProductList.SelectedRows[0].Cells["Cipher"].Value.ToString();
                string oid = dgv_BackProductList.SelectedRows[0].Cells["oid"].Value.ToString();
                //getData(code);
                c = SysBusinessFunction.MakeCard(code);
                if (c.BarCode == null)
                {
                    //弹出提示框提醒没有查到产品
                    SysBusinessFunction.SystemDialog(2, "条码" + code + "没有查到与改条码对应的产品信息!");
                    return;
                }
                else
                {
                    lbl_Style_Prod_Desc.Text = c.Prod_Desc;
                    lbl_Style_Prod_Desc2.Text = c.Prod_Desc;
                    lbl_Style_BarCode1.Text = code;
                    lbl_Style_BarCode2.Text = code;
                    lbl_Style_Waterproofing.Text = c.Waterproofing;
                    lbl_Style_Voltage.Text = c.Voltage;
                    lbl_Style_Frequency.Text = c.Frequency;
                    if (c.Power == null)
                    {
                        lbl_Style_Power.Text = c.SmallPower;
                    }
                    else
                    {
                        lbl_Style_Power.Text = c.Power;
                    }
                    lbl_Style_Capacity.Text = c.Capacity;
                    lbl_Style_Max_Temperature.Text = c.MaxTemperature;
                    lbl_Style_Pressure.Text = c.Pressure;
                    lbl_MakeDate.Text = "制造日期" + DateTime.Now.ToLocalTime().ToString("yyyyMMdd");
                }
                pic_Style_BarCode1.Image = SysBusinessFunction.CreateBarCode(code, 2800, 55);
                pic_Style_BarCode2.Image = SysBusinessFunction.CreateBarCode(code, 2800, 55);
                if (c.oid == null || c.VerificationCode == null)
                {
                    SysBusinessFunction.SystemDialog(2, "条码" + code + "未查到检验码网址等数据");
                    return;
                }
                else
                {
                    pic_Verification_Code.Image = SysBusinessFunction.CreateBarCode(c.VerificationCode, 320, 55);
                    pic_OID.Image = SysBusinessFunction.CreateQRCode(c.oid);
                }
            }else
            {
                SysBusinessFunction.SystemDialog(2, "选择了多条记录！！");
            
            }
        }
    

        private void btn_Print_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_BackProductList.SelectedRows.Count; i++)
            {
                string code = dgv_BackProductList.SelectedRows[i].Cells["WorkUser_BarCode"].Value.ToString();
                DataTable table = new DataTable();
                c = SysBusinessFunction.MakeCard(code);

                table.Columns.Add("Material_Spec", typeof(string));
                table.Columns.Add("P_Capacity", typeof(string));
                table.Columns.Add("P_Temperature", typeof(string));
                table.Columns.Add("P_Waterproof", typeof(string));
                table.Columns.Add("P_Voltage", typeof(string));
                table.Columns.Add("P_Frequency", typeof(string));
                table.Columns.Add("P_Power", typeof(string));
                table.Columns.Add("P_Pressure", typeof(string));
                table.Columns.Add("BarCode_No1", typeof(string));
                table.Columns.Add("BarCode_No2", typeof(string));
                table.Columns.Add("oid", typeof(string));
                if (c.oid == null || c.VerificationCode == null)
                {
                    //弹出提示框提示缺少信息结束方法
                    SysBusinessFunction.SystemDialog(2, "条码" + code + "没有查到验证码或者网址！");
                    return;
                }
                if (c.Power != null)
                {
                    table.Rows.Add(c.Prod_Desc, c.Capacity, c.MaxTemperature, c.Waterproofing, c.Voltage, c.Frequency, c.Power, c.Pressure,
                                                   code, c.VerificationCode, c.oid);
                }
                else
                {
                    table.Rows.Add(c.Prod_Desc, c.Capacity, c.MaxTemperature, c.Waterproofing, c.Voltage, c.Frequency, c.SmallPower, c.Pressure,
                                                   code, c.VerificationCode, c.oid);
                }
                eSet.ReportSettings.ShowProgress = false;
                FastReport.Report report = new FastReport.Report();
                bool flag = SysBusinessFunction.CardPrint(report, "BarCodeType051.frx", table, 1);
                if (flag)
                {
                    SysBusinessFunction.WriteLog("条码" + code + "打印成功！！！！");
                }
                else
                {
                    SysBusinessFunction.WriteLog("条码" + code + "打印失败！！");
                    return;
                }
                string reportSQL = string.Format(@"INSERT  into printonlinelog (Pro_Barcode,Card_Print_Flag,Print_Time)values('{0}','{1}','{2}')",
                                            code, "2", DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                DataHelper.MySqlFill(reportSQL);
            }
        }
         
        private void btn_Check_Click(object sender, EventArgs e)
        {
            try
            {
                string barcode = txt_Barcode.Text.ToString().Trim();
                string ordercode = txt_OrderCode.Text.ToString().Trim();
                //数据量过大模糊查找时间过长
                string sql = string.Format(@"SELECT WorkUser_BarCode,WorkUser_RightMostItemName,Cipher,oid,WorkUser_MOrderCode 
                                         FROM bns_pm_operation WHERE
                                        WorkUser_BarCode LIKE '%{0}%' and WorkUser_MOrderCode like '%{1}%'
                                        Order By WorkUser_BarCode ", barcode , ordercode);
                DataTable Dt = DataHelper.MySqlFill(sql).Tables[0];
                this.dgv_BackProductList.DataSource = Dt;
                dgv_BackProductList.ClearSelection();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(2, "查询信息失败！");
                SysBusinessFunction.WriteLog(ex.Message);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            for (int i=0;i< dgv_BackProductList.RowCount; i++)
            {
                
                    dgv_BackProductList.Rows[i].Selected = true;
                
            }
        
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_BackProductList.RowCount; i++)
            {

                dgv_BackProductList.Rows[i].Selected = false;

            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_OrderCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
