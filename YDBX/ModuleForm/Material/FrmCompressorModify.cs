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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material
{
    public partial class FrmCompressorModify : Form
    {
        public bool bModify = false; // false 增加数据 true 修改数据
        public string Product_Code = "";
        public string Product_Name = "";
        public string OldCompressorCode = "";
        public string OldCompressorName = "";
        private bool First_Flag = true;
        public FrmCompressorModify()
        {
            InitializeComponent();
        }

        private void FrmCompressorModify_Load(object sender, EventArgs e)
        {
            if (BaseSystemInfo.LanguageType == "2")
            {
                ChangLanguage.SetLang("en-US", this, typeof(FrmCompressorModify));
            }
            txt_ProductCode.Text = Product_Code;
            txt_ProductName.Text = Product_Name;
            if(bModify)
            {
                cbx_Compressor_Name.Text = OldCompressorName;
                txt_Compressor_Code.Text = OldCompressorCode;
            }
            GetCompressorInfo();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //判断条件
            string productcode = txt_ProductCode.Text.ToString();
            string productname = txt_ProductName.Text.ToString();
            string compressorcode = txt_Compressor_Code.Text.ToString();
            string compressorname = cbx_Compressor_Name.Text.ToString();
            if(productcode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品型号不可为空");
                return;
            }
            if (productname.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品名称不可为空");
                return;
            }
            if (compressorcode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "压缩机型号不可为空");
                return;
            }
            if (compressorname.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "压缩机名称不可为空");
                return;
            }
           
            if (!bModify)
            {
                //判断重不重复
                string check = String.Format(@"SELECT ID FROM IMOS_TA_Map WHERE Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}'
                                             and Factory_Name = '{3}' and Product_Line_Code  = '{4}' and Product_Line_Name = '{5}' and Product_Code = '{6}' and Material_Code = '{7}' and Material_Type = '{8}'",
                                             BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                             BaseSystemInfo.ProductLineName, productcode, compressorcode, "YSJ");
                DataSet ds = DataHelper.Fill(check);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "冰箱和压缩机的对应关系不能出现重复！The Product to the Compressor is repeated");
                    return;
                }
                string sql = String.Format(@"INSERT INTO IMOS_TA_Map (Company_Code,
                                                                             Company_Name,
                                                                             Factory_Code,
                                                                             Factory_Name,
                                                                             Product_Line_Code,
                                                                             Product_Line_Name,
                                                                             Product_Code,
                                                                             Product_Name,
                                                                             Material_Code,
                                                                             Material_Name,
                                                                             Material_Type)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                            BaseSystemInfo.CompanyCode,BaseSystemInfo.CompanyName,BaseSystemInfo.FactoryCode,BaseSystemInfo.FactoryName,
                                            BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,productcode,productname,compressorcode,compressorname,"YSJ");
                DataHelper.Fill(sql);
                DialogResult = DialogResult.OK;
            }
            else
            {
                //判断重不重复
                if (compressorcode.Equals(OldCompressorCode))
                {

                }else
                {
                    string check = String.Format(@"SELECT ID FROM IMOS_TA_Map WHERE Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}'
                                             and Factory_Name = '{3}' and Product_Line_Code  = '{4}' and Product_Line_Name = '{5}' and Product_Code = '{6}' and Material_Code = '{7}' and Material_Type = '{8}'",
                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                          BaseSystemInfo.ProductLineName, productcode, compressorcode, "YSJ");
                    DataSet ds = DataHelper.Fill(check);
                    if (ds != null && ds.Tables[0].Rows.Count != 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "冰箱和压缩机的对应关系不能出现重复！The Product to the Compressor is repeated");
                        return;
                    }
                }         
                string sql = String.Format(@"UPDATE IMOS_TA_Map SET Material_Code = '{0}',Material_Name = '{1}',Modify_Time = getDate()
                                                         where Material_Code = '{2}' and Product_Code = '{3}' and Material_Name = '{4}' and Product_Name = '{5}' and Material_Type = '{6}'",
                                             compressorcode,compressorname,OldCompressorCode,productcode,OldCompressorName,productname,"YSJ");
                DataHelper.Fill(sql);
                DialogResult = DialogResult.OK;
            }
        }
        private void GetCompressorInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name FROM IMOS_TA_Material WHERE Material_Type_Code = '{0}'","YSJ");
                DataSet ds = DataHelper.Fill(sql);
                //型号和编号 txt_Compressor_Code 显示 压缩机名称 txt_Compressor_Name 显示压缩机型号
                cbx_Compressor_Name.DataSource = ds.Tables[0];              
                cbx_Compressor_Name.DisplayMember = "Material_Name";
                cbx_Compressor_Name.ValueMember = "Material_Code";


            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbx_Compressor_Name_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_Compressor_Code.Text = cbx_Compressor_Name.SelectedValue.ToString();
        }
    }
}
