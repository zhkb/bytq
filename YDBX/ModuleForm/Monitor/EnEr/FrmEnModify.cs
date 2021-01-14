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
    public partial class FrmEnModify : Form
    {
        public FrmEnModify()
        {
            InitializeComponent();
        }

        public string AQty = "";
        public string BinNo = "";
        public string EnCode = "";
        public string EnName = "";
        public string TQty = "";
        public string Picture = "";

        private void FrmEnModify_Load(object sender, EventArgs e)
        {
            try
            {
                txt_BinNo.Text = BinNo;
                txt_Code.Text = EnCode;
                txt_Act_Qty.Text = AQty;
                txt_Theory_Qty.Text = TQty;
                byte[] imageBytes = Convert.FromBase64String(Picture);
                Energy_Label_Image.Image = SysBusinessFunction.ArrayToPic(imageBytes);
                GetEnergyLabel();
                cbx_Energy_Name.Text = EnName;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.ToString());
            }
        }

        #region 获取能耗贴编号
        private void GetEnergyLabel()
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name,Material_Image  FROM  IMOS_TA_Material  WHERE Material_Type_Code = '{0}'", "NHT");
                DataSet ds = DataHelper.Fill(sql);
                cbx_Energy_Name.DataSource = ds.Tables[0];
                cbx_Energy_Name.ValueMember = "Material_Code";
                cbx_Energy_Name.DisplayMember = "Material_Name";

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.ToString());
            }
        }

        #endregion

        #region 根据选择的能效贴型号确定能效贴编码
        private void cbx_Energy_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Code.Text = cbx_Energy_Name.SelectedValue.ToString();
                
                String sql = String.Format(@"SELECT Material_Image  FROM  IMOS_TA_Material  WHERE Material_Type_Code = '{0}' and Material_Code = '{1}'",
                                                     "NHT", cbx_Energy_Name.SelectedValue.ToString());
                DataSet ds = DataHelper.Fill(sql);
                Picture = ds.Tables[0].Rows[0]["Material_Image"].ToString();
                byte[] imageBytes = Convert.FromBase64String(Picture);
                this.Energy_Label_Image.Image = SysBusinessFunction.ArrayToPic(imageBytes);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.ToString());
            }
        }
        #endregion

        #region  系统按钮事件
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string name = cbx_Energy_Name.Text.ToString();//能耗贴名称
                string code = txt_Code.Text.ToString();//能耗贴编号
                int actqty;//实际数量
                int theqty;//理论数量
                if (code.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, String.Format(@"能耗贴名称不能为空！
The Energy_Label_Name  cannot be empty"));
                    return;
                }
                if (name.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, String.Format(@"能耗贴编号不能为空！
The Energy_Label_Code  cannot be empty"));
                    return;
                }
                try
                {
                    actqty = int.Parse(txt_Act_Qty.Text.ToString());
                    theqty = int.Parse(txt_Theory_Qty.Text.ToString());
                }
                catch
                {
                    SysBusinessFunction.SystemDialog(2, String.Format(@"理论数量和实际数量不是数字！
Theoretical quantities and actual quantities are not Numbers"));
                    return;
                }
                String sql = String.Format(@"UPDATE IMOS_TA_Energy_List
                                             SET Energy_Label_Code = '{0}',
                                                 Energy_Label_Name = '{1}',
                                                 Material_Actual_Qty = '{2}',
                                                 Material_Theory_Qty = '{3}',
                                                 Energy_Label_Image = '{4}',
                                                 In_Time = GetDate(),
                                                 Operator_Code = '{6}',
                                                 Use_Flag = 1
                                            WHERE
                                                  Bin_No = '{5}'", code, name, actqty, theqty, Picture, BinNo, BaseSystemInfo.CurrentUserCode);
                DataHelper.Fill(sql);
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.ToString());
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion

    }
}
