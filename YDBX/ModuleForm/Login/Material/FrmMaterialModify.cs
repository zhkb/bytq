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

    public partial class FrmMaterialModify : Form
    {
        public string sMID = "";
        public string sMName = "";
        public string sTName = "";
        public string sBatch = "";
        public string sDesc = "";

        public bool bModify = false;

        private string sOldMID = "";

        public FrmMaterialModify()
        {
            InitializeComponent();
        }

        private void FrmMaterialModify_Load(object sender, EventArgs e)
        {
            //初始化
            ArrayList Groups = new ArrayList();

            string sSQL = @"SELECT [Type_Code],[Type_Name] FROM [Mixing_MaterialType]";

            DataSet ds = DataHelper.Fill(sSQL);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Groups.Add(new GroupInfo(dr["Type_Name"].ToString(), dr["Type_Code"].ToString()));
                }
            }

            cbbMaterialType.DataSource = Groups;
            cbbMaterialType.DisplayMember = "Name";
            cbbMaterialType.ValueMember = "ID";

            tbMID.Text = sMID;
            tbMName.Text = sMName;
            cbbMaterialType.Text = sTName;
            tbBatch.Text = sBatch;
            tbDesc.Text = sDesc;

            sOldMID = sMID;
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
            sMID = tbMID.Text.Trim();
            sMName = tbMName.Text.Trim();
            sBatch = tbBatch.Text.Trim();
            sDesc = tbDesc.Text.Trim();

            //对数据进行检查

            if (sMID.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编码不可为空");
                return;
            }

            if (sMName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料名称不可为空");
                return;
            }
            if (sBatch.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "批次不可为空");
                return;
            }

            if (sDesc.Length > 50)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料描述过长");
                return;
            }
            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Material_Code from Mixing_Material where Material_Code = '{0}' or Material_Name = '{1}'", sMID, sMName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编号或物料名称重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Material_Code from Mixing_Material where  (Material_Code = '{0}' or Material_Name = '{1}') and Material_Code != '{2}'", sMID, sMName, sOldMID);
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
                    string SqlStr = string.Format(@"INSERT INTO [Mixing_Material]
                                                   ([Material_Code]
                                                    ,[Material_Name]
                                                    ,[Type_Code]
                                                    ,[Batch_No]
                                                    ,[Material_Desc]
                                                    ,[Create_User]
                                                    ,[Create_Time])
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,'{4}'
                                                    ,'{5}'
                                                    ,GETDATE())", sMID, sMName, cbbMaterialType.SelectedValue.ToString(),sBatch, sDesc, BaseSystemInfo.CurrentUserName);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE [Mixing_Material] 
                                                    SET [Material_Code] = '{0}' ,
                                                    [Material_Name] = '{1}',
                                                    [Type_Code] = '{2}',
                                                    [Batch_No] = '{3}',
                                                    [Material_Desc] = '{4}',
                                                    [Modify_User] = '{5}' ,
                                                    [Modify_Time] = GETDATE() 
                                                    WHERE Material_Code = '{6}'",
                                                    sMID, sMName,cbbMaterialType.SelectedValue.ToString(),sBatch, sDesc, BaseSystemInfo.CurrentUserName, sOldMID);
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

        private void tbMID_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class GroupInfo
    {
        private string sGroupName;
        private string sGroupID;

        public GroupInfo(string sName, string sID)
        {
            this.sGroupID = sID;
            this.sGroupName = sName;
        }

        public string ID
        {
            get
            {
                return sGroupID;
            }
        }

        public string Name
        {

            get
            {
                return sGroupName;
            }
        }

    }

}


