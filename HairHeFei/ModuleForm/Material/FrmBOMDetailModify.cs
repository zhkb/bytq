using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Material
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    public partial class FrmBOMDetailModify : Form
    {
        public bool bModify = false; // false 增加数据 true 修改数据
        public string Product_Code = "";
        public string Product_Name = "";
        public string sMID = "";
        public string sOldMCode = "";
        public string sOldMName = "";
        public int Qty = 0;

        public FrmBOMDetailModify()
        {
            InitializeComponent();
        }

        private void FrmBOMDetailModify_Load(object sender, EventArgs e)
        {
            txt_ProductCode.Text = Product_Code;
            txt_ProductName.Text = Product_Name;
            try
            {
                //初始化
                ArrayList Groups = new ArrayList();
                string sSQL = string.Format(@"SELECT [Material_Code],[Material_Name] FROM [IMOS_TA_Material] WHERE  NOT [Material_Type_Code] = '{0}'", BaseSystemInfo.Material_Type_Code);
                DataSet ds = DataHelper.Fill(sSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0 )
                {
                    cbbMaterialName.DataSource = ds.Tables[0];
                    cbbMaterialName.DisplayMember = "Material_Name";
                    cbbMaterialName.ValueMember = "Material_Code";
                }


                if (bModify)
                {
                    cbbMaterialName.Text = sOldMName;
                    txt_MaterialCode.Text = sOldMCode;
                    txt_Qty.Text = Qty.ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

/*        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }*/

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //判断条件
            string productcode = txt_ProductCode.Text.ToString();
            string productname = txt_ProductName.Text.ToString();
            string materialcode = txt_MaterialCode.Text.ToString();
            string materialname = cbbMaterialName.Text.ToString();
            string materialtype = "";
            string qty = txt_Qty.Text.ToString();
            if (productcode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编号不可为空");
                return;
            }
            if (productname.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品名称不可为空");
                return;
            }
            if (materialcode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编号不可为空");
                return;
            }
            if (materialname.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料名称不可为空");
                return;
            }
            if(qty.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料数量不可为空");
                return;
            }
            try
            {
                string sql = String.Format(@"SELECT [Material_Type_Code] FROM IMOS_TA_Material WHERE [Material_Code] = '{0}'", materialcode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    materialtype = ds.Tables[0].Rows[0][0].ToString();
                }

                if (!bModify)
                {
                    //判断重不重复
                    string check = String.Format(@"SELECT ID FROM IMOS_TA_BOM_Detail WHERE Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}'
                                             and Factory_Name = '{3}' and Product_Line_Code  = '{4}' and Product_Line_Name = '{5}' and Product_Code = '{6}' and Material_Code = '{7}' and Material_Name = '{8}'",
                                                 BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                                 BaseSystemInfo.ProductLineName, productcode, materialcode, materialname);
                    ds = DataHelper.Fill(check);
                    if (ds != null && ds.Tables[0].Rows.Count != 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "BOM主表和从表的对应关系不能出现重复！");
                        return;
                    }

                    sql = String.Format(@"INSERT INTO IMOS_TA_BOM_Detail (Company_Code,
                                                                             Company_Name,
                                                                             Factory_Code,
                                                                             Factory_Name,
                                                                             Product_Line_Code,
                                                                             Product_Line_Name,
                                                                             Product_Code,
                                                                             Product_Name,
                                                                             Material_Code,
                                                                             Material_Name,
                                                                             Material_Type_Code,
                                                                             Qty,Memo,Creation_Date,Created_By,Last_Update_Date,Last_Updated_By)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'',GETDATE(),'{12}',GETDATE(),'{13}')",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName,
                                                BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, productcode, productname, materialcode, materialname, materialtype, int.Parse(qty), BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID);
                    DataHelper.Fill(sql);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    //判断重不重复
                    if (materialcode.Equals(sOldMCode))
                    {

                    }
                    else
                    {
                        string check = String.Format(@"SELECT ID FROM IMOS_TA_BOM_Detail WHERE Company_Code = '{0}' and Company_Name = '{1}' and Factory_Code = '{2}'
                                             and Factory_Name = '{3}' and Product_Line_Code  = '{4}' and Product_Line_Name = '{5}' and Product_Code = '{6}' and Material_Code = '{7}' and Material_Name = '{8}'",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                              BaseSystemInfo.ProductLineName, productcode, materialcode, materialname);
                        ds = DataHelper.Fill(check);
                        if (ds != null && ds.Tables[0].Rows.Count != 0)
                        {
                            SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "主表和从的对应关系不能出现重复！");
                            return;
                        }
                    }
                    sql = String.Format(@"UPDATE IMOS_TA_BOM_Detail SET Material_Code = '{0}',Material_Name = '{1}',Material_Type_Code = '{2}',Qty = {3},Memo = '',Last_Update_Date = getDate(),
                                                         Last_Updated_By = '{4}' where Company_Code = '{5}' and Company_Name = '{6}' and Factory_Code = '{7}'
                                                         and Factory_Name = '{8}' and Product_Line_Code  = '{9}' and Product_Line_Name = '{10}'
                                                         and Material_Code = '{11}' and Product_Code = '{12}' and Material_Name = '{13}' and Product_Name = '{14}'",
                                                 materialcode, materialname, materialtype, int.Parse(qty),BaseSystemInfo.CurrentUserID,
                                                 BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode,
                                                 BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                                 BaseSystemInfo.ProductLineName, sOldMCode, productcode, sOldMName, productname);
                    DataHelper.Fill(sql);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("BOM从表数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "BOM从表数据处理异常！");
            }
            
        }

        private void cbbMaterialName_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_MaterialCode.Text = cbbMaterialName.SelectedValue.ToString();
        }
    }
}
