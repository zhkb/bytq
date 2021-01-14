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


    public partial class FrmMaterialTypeModify : Form
    {
        public string sTID = "";
        public string sTName = "";
        public string sDesc = "";

        public bool bModify = false;

        private string sOldTID = "";

        public FrmMaterialTypeModify()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }


        private void FrmMaterialTypeModify_Load(object sender, EventArgs e)
        {
            tbTID.Text = sTID;
            tbTName.Text = sTName;
            tbDesc.Text = sDesc;

            sOldTID = sTID;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sTID = tbTID.Text.Trim();
            sTName = tbTName.Text.Trim();
            sDesc = tbDesc.Text.Trim();

            //对数据进行检查

            if (sTID.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "类型编码不可为空");
                return;
            }
           
            if (sTName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "类型名称不可为空");
                return;
            }

            if (sDesc.Length > 50)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "类型描述过长");
                return;
            }
            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Type_Code from Mixing_MaterialType where Type_Code = '{0}' or Type_Name = '{1}'", sTID, sTName);
                DataSet  ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "类型编号或类型名称重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Type_Code from Mixing_MaterialType where  (Type_Code = '{0}' or Type_Name = '{1}') and Type_Code != '{2}'", sTID, sTName, sOldTID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "类型编号或类型名称重复");
                    return;
                }
            }

            try
            {

                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO [Mixing_MaterialType]
                                                   ([Type_Code]
                                                    ,[Type_Name]
                                                    ,[Type_Desc]
                                                    ,[Create_User]
                                                    ,[Create_Time])
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,GETDATE())", sTID, sTName, sDesc, BaseSystemInfo.CurrentUserName);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE [Mixing_MaterialType] 
                                                    SET [Type_Code] = '{0}' ,
                                                    [Type_Name] = '{1}',
                                                    [Type_Desc] = '{2}',
                                                    [Modify_User] = '{3}' ,
                                                    [Modify_Time] = GETDATE() 
                                                    WHERE Type_Code = '{4}'", 
                                                    sTID, sTName, sDesc, BaseSystemInfo.CurrentUserName, sOldTID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }


            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("物料类型处理异常！"+ex.Message);
                //SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料信息存储失败.");
                MessageBox.Show("物料类型处理异常！");
            }


        }
    }
}
