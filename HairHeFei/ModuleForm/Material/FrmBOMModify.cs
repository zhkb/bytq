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

    public partial class FrmBOMModify : Form
    {
        public string sMID = "";
        public string sMCode = "";
        public string sOldMCode = "";
        public string sMName = "";
        public string sTName = "";

        public bool bModify = false;
        public FrmBOMModify()
        {
            InitializeComponent();
        }
       
        private void FrmBOMModify_Load(object sender, EventArgs e)
        {
            //初始化
            ArrayList Groups = new ArrayList();
            string sSQL = string.Format(@"SELECT [Material_Code],[Material_Name] FROM [IMOS_TA_Material] WHERE [Material_Type_Code] = '{0}'", BaseSystemInfo.Material_Type_Code);
            DataSet ds = DataHelper.Fill(sSQL);
            //if (ds != null)
            //{
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        Groups.Add(new GroupInfo(dr["Material_Name"].ToString(), dr["Material_Code"].ToString()));
            //    }
            //}

            cbbMaterialName.DataSource = ds.Tables[0];
            cbbMaterialName.DisplayMember = "Material_Name";
            cbbMaterialName.ValueMember = "Material_Code";

            tbMID.Text = sMCode;
            sOldMCode = sMCode;
            //          tbMName.Text = sMName;
            cbbMaterialName.Text = sMName;
            //cbbMaterialName.SelectedValue = sMCode;
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
            sMCode = tbMID.Text.Trim();
            sMName = cbbMaterialName.Text;
            string typecode = "";
            //对数据进行检查

            if (sMCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编码不可为空");
                return;
            }

            if (sMName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品名称不可为空");
                return;
            }

            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_TA_BOM 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Material_Code = '{3}' or Material_Name = '{4}'",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编号或产品名称重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_TA_BOM
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                   and (Material_Code = '{3}' or Material_Name = '{4}') and ID != {5}",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName, sMID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编号或产品名称重复");
                    return;
                }
            }

            try
            {
                string SqlStr = string.Format(@"select [Material_Type_Code] , [Material_Type_Name] from [IMOS_TA_Material] where [Material_Code] = '{0}'", sMCode);
                DataSet ds = DataHelper.Fill(SqlStr);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    typecode = ds.Tables[0].Rows[0][0].ToString();
                    sTName = ds.Tables[0].Rows[0][1].ToString();
                }
                if (bModify == false)//添加类型记录
                {                   
                    SqlStr = string.Format(@"INSERT INTO [IMOS_TA_BOM]
                                                   ([Material_Code]
                                                    ,[Material_Name]
                                                    ,[Material_Type_Code]
                                                    ,[Remark]
                                                    ,[Created_By]
                                                    ,[Creation_Date]
                                                    ,[Last_Updated_By]
                                                    ,[Last_Update_Date],Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name)
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,'{4}'
                                                    ,GETDATE(),'{5}'
                                                    ,GETDATE(),'{6}','{7}','{8}','{9}','{10}','{11}')", sMCode, sMName, typecode, "",
                                                    BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID,
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    SqlStr = string.Format(@"UPDATE [IMOS_TA_BOM] 
                                                    SET [Material_Code] = '{0}' ,
                                                    [Material_Name] = '{1}',
                                                    [Material_Type_Code] = '{2}',
                                                    [Last_Updated_By] = '{3}' ,
                                                    [Last_Update_Date] = GETDATE()
                                                    WHERE ID = {4}",
                                                    sMCode, sMName, typecode,
                                                    BaseSystemInfo.CurrentUserID, sMID);
                    DataHelper.Fill(SqlStr);
                    SqlStr = string.Format(@"UPDATE [IMOS_TA_BOM_Detail] 
                                                    SET [Product_Code] = '{0}' ,
                                                    [Product_Name] = '{1}',
                                                    [Last_Updated_By] = '{2}' ,
                                                    [Last_Update_Date] = GETDATE()
                                                    WHERE [Product_Code] = '{3}'",
                                                    sMCode, sMName,
                                                    BaseSystemInfo.CurrentUserID, sOldMCode);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("BOM数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "BOM数据处理异常！.");
            }
        }

        private void cbbMaterialName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbMID.Text = cbbMaterialName.SelectedValue.ToString();
            }
            catch
            {

            }
            
        }
    }
}
