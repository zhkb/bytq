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

namespace Material
{
    public partial class FrmEnergyBinModify : Form
    {
        public  string binno;
        private string strpicture;
        public FrmEnergyBinModify()
        {
            InitializeComponent();
        }

        #region 维护界面加载
        private void FrmEnergyBinModify_Load(object sender, EventArgs e)//界面加载
        {
            GetEnergyLabel();
            FirstLoad();
            txt_BinNo.Text = binno;
            txt_ProductCode.Enabled = false;
            
        }
        #endregion

        #region 编辑界面初次刷新显示现有信息
        private void FirstLoad()
        {
            try
            {
                String sql = String.Format(@"SELECT Energy_Label_Code,Energy_Label_Name,Material_Actual_Qty,Material_Theory_Qty,Energy_Label_Image FROM IMOS_TA_Energy_List WHERE Bin_No='{0}'", binno);
                DataSet ds = DataHelper.Fill(sql);
                if(ds.Tables[0].Rows.Count != 1)
                {
                    return;
                }
                txt_Act_Qty.Text = ds.Tables[0].Rows[0]["Material_Actual_Qty"].ToString();
                txt_Theory_Qty.Text = ds.Tables[0].Rows[0]["Material_Theory_Qty"].ToString();
                txt_ProductCode.Text = ds.Tables[0].Rows[0]["Energy_Label_Code"].ToString();
                cbx_Energy_Name.SelectedValue = ds.Tables[0].Rows[0]["Energy_Label_Code"].ToString();
                byte[] imageBytes = Convert.FromBase64String(ds.Tables[0].Rows[0]["Energy_Label_Image"].ToString());
                this.Energy_Label_Image.Image = SysBusinessFunction.ArrayToPic(imageBytes);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region 获取能耗贴编号
        private void GetEnergyLabel()
        {
           try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name,Material_Image  FROM  IMOS_TA_Material  WHERE Material_Type_Code = '{0}'", "NHT");
                DataSet ds = DataHelper.Fill(sql);
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "";
                dr[1] = "NULL";
                //设定行中的值
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbx_Energy_Name.DataSource = ds.Tables[0];

                cbx_Energy_Name.ValueMember = "Material_Code";
                cbx_Energy_Name.DisplayMember = "Material_Name";
                
            } catch(Exception ex)
            {

            }
        }

        #endregion

        #region 根据选择的能效贴型号确定能效贴编码
        private void cbx_Energy_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_ProductCode.Text = cbx_Energy_Name.SelectedValue.ToString();

                String sql = String.Format(@"SELECT Material_Image  FROM  IMOS_TA_Material  WHERE Material_Type_Code = '{0}' and Material_Code = '{1}'",
                                                     "NHT", cbx_Energy_Name.SelectedValue.ToString());
                DataSet ds = DataHelper.Fill(sql);
//                if (ds.Tables[0].Rows.Count != 1)
//                {
//                    SysBusinessFunction.SystemDialog(2, String.Format(@"能耗贴图像查询失败！
//The Energy_Label_Image  Found Error"));
//                    return;
//                }
                strpicture = ds.Tables[0].Rows[0]["Material_Image"].ToString();
                byte[] imageBytes = Convert.FromBase64String(strpicture);
                this.Energy_Label_Image.Image = SysBusinessFunction.ArrayToPic(imageBytes);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region  系统按钮事件
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string bin_no = txt_BinNo.Text.ToString();//网格柜号
                string name = cbx_Energy_Name.Text.ToString();//能耗贴名称
                string code = txt_ProductCode.Text.ToString();//能耗贴编号
                if (Energy_Label_Image.Image == null)
                {
                    strpicture = "";
                }
                else
                {

                    strpicture = Convert.ToBase64String(SysBusinessFunction.PicToArray(Energy_Label_Image));
                }
                String sql = String.Format(@"select Bin_No , Energy_Label_Code from IMOS_TA_Energy_List
                                           where Bin_No = '{0}' or Energy_Label_Code = '{1}'", bin_no, code);
                DataSet ds = DataHelper.Fill(sql);
                if(ds.Tables[0].Rows.Count > 1)
                {
                    SysBusinessFunction.SystemDialog(2, String.Format(@"网柜和能耗贴一一对应
One Bin_No to one Energy_Label_Code"));
                    return;
                }

                int actqty ;//实际数量
                int theqty ;//理论数量
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
                sql = String.Format(@"UPDATE IMOS_TA_Energy_List
                                             SET Energy_Label_Code = '{0}',
                                                 Energy_Label_Name = '{1}',
                                                 Material_Actual_Qty = '{2}',
                                                 Material_Theory_Qty = '{3}',
                                                 Energy_Label_Image = '{4}',
                                                 In_Time = GetDate(),
                                                 Operator_Code = '{6}',
                                                 Use_Flag = 1
                                            WHERE
                                                  Bin_No = '{5}'", code,name,actqty,theqty,strpicture,binno,BaseSystemInfo.CurrentUserCode);
                DataHelper.Fill(sql);
                DialogResult = DialogResult.OK;

            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
