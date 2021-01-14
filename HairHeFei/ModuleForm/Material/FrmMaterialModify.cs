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
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text.RegularExpressions;

    public partial class FrmMaterialModify : Form
    {
        public string sMID = "";
        public string sMCode = "";
        public string sMName = "";

        public string FoamingIndex = "";
        public bool bModify = false;

        public string sMSort = "";
        public string sMLineNo = "";
        public string sMLineName = "";

        //private int sOldMID = 0;

        public FrmMaterialModify()
        {
            InitializeComponent();
        }

        private void FrmMaterialModify_Load(object sender, EventArgs e)
        {
            try

            {

              
                String sql2 = String.Format(@"SELECT
	                                                Parameter_Detail_Code,Parameter_Detail_Name 
                                                FROM
	                                                Sys_Parameters_Detail 
                                                WHERE
	                                                Parameter_Master_Code = '1001'");
                DataSet ds2 = DataHelper.Fill(sql2);
                if (ds2 != null)
                {
                    com_Line.DataSource = ds2.Tables[0];
                    com_Line.DisplayMember = "Parameter_Detail_Name";
                    com_Line.ValueMember = "Parameter_Detail_Code";
                }
                if (bModify)
                {
                    tbMID.Text = sMCode;
                    tbMName.Text = sMName;
                    txt_Sort.Text = sMSort;
                    com_Line.Text = sMLineName;
                }

            }
            catch (Exception ex)
            {

            }


            // sOldMID = sMCode;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sMCode = tbMID.Text.Trim();
            sMName = tbMName.Text.Trim();
            sMSort = txt_Sort.Text.Trim();
            sMLineName = com_Line.Text.Trim();
            sMLineNo = com_Line.SelectedValue.ToString().Trim();
            
           
            //对数据进行检查

            if (sMCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编码不可为空");
                return;
            }

            if (sMName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料名称不可为空");
                return;
            }
            if (sMLineName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料类型不可为空");
                return;
            }
            if (sMLineNo.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料类型编号不可为空");
                return;
            }
            if (!IsInt(sMSort))
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "代号非数字");
                return;
            }
            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_TA_Material 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and (Material_Code = '{3}' or Material_Name = '{4}' or Material_Sort = '{5}')",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName,sMSort);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编号或物料名称或物料代号重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_TA_Material 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                   and (Material_Code = '{3}' or Material_Name = '{4}' or  Material_Sort = '{6}') and Material_ID != {5}",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName, sMID,sMSort);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编号或物料名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO [IMOS_TA_Material]
                                                   ([Material_Code]
                                                    ,[Material_Name]
                                                    ,Material_Sort
                                                    ,Line_No
                                                    ,Line_Name
                                                    )
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}' ,'{4}')", sMCode, sMName, sMSort,sMLineNo,sMLineName);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE [IMOS_TA_Material] 
                                                    SET [Material_Code] = '{0}' ,
                                                    [Material_Name] = '{1}',
                                                    [Material_Sort] = '{2}',
                                                    Line_No = '{4}',
                                                    Line_Name = '{5}'
                                                    Where
                                                       Material_ID = '{3}'",
                                                    sMCode, sMName, sMSort, sMID,sMLineNo,sMLineName);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("物料数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料数据处理异常！.");
            }

        }


    


        #region 检验数量是否数字
        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        #endregion
    }




}


