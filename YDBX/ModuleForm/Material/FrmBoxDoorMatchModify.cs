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
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using System.Collections;

    public partial class FrmBoxDoorMatchModify : Form
    {
        public string sMID = "";
        public string sMCode = "";
        public string sMName = "";
        public string sdoorcode = "";
        public string sdoorname = "";
       
        public bool bModify = false;
        public FrmBoxDoorMatchModify()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void FrmWeightStandardModify_Load(object sender, EventArgs e)
        {
            
            tbMID.Text = sMCode;
            tbMName.Text = sMName;
            tbdoorcode.Text = sdoorcode;
            tbdoorname.Text = sdoorname;                 
                
          
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sMCode = tbMID.Text.Trim();
            sMName = tbMName.Text.Trim();
            sdoorcode = tbdoorcode.Text.Trim();
            sdoorname = tbdoorname.Text.Trim();
            
            //对数据进行检查

            if (sMCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "箱体编码不可为空");
                return;
            }

            if (sMName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "箱体名称不可为空");
                return;
            }
            if (sdoorcode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "门体编码不可为空");
                return;
            }

            if (sdoorname.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "门体名称不可为空");
                return;
            }
            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Box_Code from IMOS_TA_Match_Record 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Box_Code = '{3}' or Box_Name = '{4}'",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "箱体编号或箱体名称重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Box_Code from IMOS_TA_Match_Record 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                   and (Box_Code = '{3}' or Box_Name = '{4}')and ID != {5} ",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName, sMID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "箱体编号或箱体名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO [IMOS_TA_Match_Record]
                                                   ([Box_Code]
                                                    ,[Box_Name]
                                                    ,[Door_Code]
                                                    ,[Door_Name]                                                   
                                                    ,[Create_By]
                                                    ,[Create_time]
                                                    ,[Last_Updated_By]
                                                    ,[Last_Update_Date],Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name)
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,'{4}',GETDATE()
                                                    ,'{5}' ,GETDATE(),'{6}','{7}'
                                                    ,'{8}'
                                                    ,'{9}','{10}','{11}')", sMCode, sMName, sdoorcode, sdoorname, BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID,
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE [IMOS_TA_Match_Record] 
                                                    SET [Box_Code] = '{0}' ,
                                                    [Box_Name] = '{1}',
                                                    [Door_Code] = '{2}',
                                                    [Door_Name] = '{3}',                                                   
                                                    [Last_Updated_By] = '{4}' ,
                                                    [Last_Update_Date] = GETDATE() 
                                                    WHERE ID = '{5}'",
                                                    sMCode, sMName, sdoorcode, sdoorname, BaseSystemInfo.CurrentUserID, sMID);
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
    }
}
