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
    public partial class FrmEnergyModify : Form
    {
        public bool bModify = false; // false 增加数据 true 修改数据
        public string MapID;
        public string Product_Code = "";
        public string Product_Name = "";
        public string OldEnergyCode = "";
        public string OldEnergyName = "";
        private bool First_Flag = true;
        public FrmEnergyModify()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmEnergyModify_Load(object sender, EventArgs e)
        {
            if (BaseSystemInfo.LanguageType == "2")
            {
                ChangLanguage.SetLang("en-US", this, typeof(FrmEnergyModify));
            }
            txt_EnergyCode.Text = OldEnergyCode;
            txt_EnergyName.Text = OldEnergyName;
            GetEnergyInfo();
            if (bModify)
            {
                cbx_Product_Name.Text = Product_Name;
                txt_Product_Code.Text = Product_Code;
            }
           
            First_Flag = false;
        }
        #endregion

        #region OK按钮点击事件
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                //判断条件
                string productcode = txt_Product_Code.Text.ToString();
                string productname = cbx_Product_Name.Text.ToString();
                string Energycode = txt_EnergyCode.Text.ToString();
                string Energyname = txt_EnergyName.Text.ToString();
                if (productcode.Length == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品型号不可为空 Product Code is empty");
                    return;
                }
                if (productname.Length == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品名称不可为空 Product Name is empty");
                    return;
                }
                if (Energycode.Length == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "能效贴型号不可为空 Energy Label Code is empty");
                    return;
                }
                if (Energyname.Length == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "能效贴名称不可为空 Energy Label Name is empty");
                    return;
                }

                if (!bModify)
                {
                    //判断重不重复
                    string check = String.Format(@"SELECT ID FROM IMOS_TA_Map WHERE Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}'
                                             and Factory_Name = '{3}' and Product_Line_Code  = '{4}' and Product_Line_Name = '{5}' and Product_Code = '{6}'  and Material_Type = '{7}'",
                                                 BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                                 BaseSystemInfo.ProductLineName, productcode, "NXT");
                    DataSet ds = DataHelper.Fill(check);
                    if (ds != null && ds.Tables[0].Rows.Count != 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "同一冰箱型号只能有一种能效贴相对应！One Product to one Energy Label");
                        return;
                    }
                    string sql2 = String.Format(@"INSERT INTO IMOS_TA_Map (Company_Code,
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
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName,
                                                BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, productcode, productname, Energycode, Energyname, "NXT");
                    DataHelper.Fill(sql2);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    string check = String.Format(@"SELECT ID FROM IMOS_TA_Map WHERE Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}'
                                             and Factory_Name = '{3}' and Product_Line_Code  = '{4}' and Product_Line_Name = '{5}' and Product_Code = '{6}' and Material_Type = '{7}'",
                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                          BaseSystemInfo.ProductLineName, productcode, "NXT");
                    DataSet ds = DataHelper.Fill(check);
                    if (ds != null && ds.Tables[0].Rows.Count != 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "同一冰箱型号只能有一种能效贴相对应！One Product to one Energy Label");
                        return;
                    }
                }
                string sql = String.Format(@"UPDATE IMOS_TA_Map SET  Product_Code = '{0}',Product_Name = '{1}',Modify_Time = getDate()
                                                         where   Material_Type = '{2}' and ID='{3}'",
                                              productcode, productname, "NXT", MapID);
                DataHelper.Fill(sql);
                DialogResult = DialogResult.OK;
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("修改信息失败！");
            }
        }
        #endregion

        #region 获取能耗贴信息
        private void GetEnergyInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT DISTINCT(Material_Code),Material_Name FROM IMOS_TA_Material WHERE Material_Type_Code = '{0}'", "MN001");
                DataSet ds = DataHelper.Fill(sql);

                cbx_Product_Name.DataSource = ds.Tables[0];

                cbx_Product_Name.DisplayMember = "Material_Name";
                cbx_Product_Name.ValueMember = "Material_Code";

                cbx_Product_Name.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取能耗贴信息列表失败！");
            }
        }
        #endregion

        #region 关闭窗口
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 选择产品事件
        private void cbx_Product_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (First_Flag)
                {
                    txt_Product_Code.Text = "";
                }
                else
                {
                    txt_Product_Code.Text = cbx_Product_Name.SelectedValue.ToString();
                }

            }
            catch
            {
                SysBusinessFunction.WriteLog("选择产品信息失败！");
            }
        }
        #endregion
    }
}
