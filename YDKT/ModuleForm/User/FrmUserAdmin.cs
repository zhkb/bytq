using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User
{
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;

    public partial class FrmUserAdmin : Form
    {
        public string uloginname = "";
        public string ucname = "";
        public string upassword = "";
        public string udeptname = "";
        public string utelno = "";
        public string umail = "";
        public string uremark = "";
        public string userid = "";
        public string uloginImage = "";

        public FrmUserAdmin()
        {
            InitializeComponent();
        }

        private void FrmUserAdmin_Load(object sender, EventArgs e)
        {
            UserGrid.TopLeftHeaderCell.Value = "序号";
            GetUserData(); //获取用户信息
        }

        private void GetUserData()//获取用户信息
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"Select User_ID,User_Code,User_Name,User_PassWord,Dept_Name,User_TelNo,User_EMail,Remark,User_Image
                                                from Sys_BaseUser 
                                                Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                order by User_ID", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);

                UserGrid.DataSource = DBDataSet.Tables[0];
                UserGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                UserGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取用户信息失败." + ex.ToString());
            }
        }


        private void UserGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//序号列
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmUserModify UserForm = new FrmUserModify();
            UserForm.ModifyState = true;
            DialogResult r = UserForm.ShowDialog();
            if (r == DialogResult.OK)
            {
                GetUserData(); //获取用户信息
            }
            UserForm.Dispose();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (UserGrid.Rows.Count == 0)
            {
                return;
            }

            userid = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_ID"].Value.ToString();
            uloginname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Code"].Value.ToString();
            ucname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Name"].Value.ToString();
            upassword = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_PassWord"].Value.ToString();
            udeptname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Dept_Name"].Value.ToString();
            utelno = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_TelNo"].Value.ToString();
            umail = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_EMail"].Value.ToString();
            uremark = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Remark"].Value.ToString();
            uloginImage = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Image"].Value.ToString();

            FrmUserModify UserForm = new FrmUserModify();
            UserForm.userid = userid;
            UserForm.uloginname = uloginname;
            UserForm.ucname = ucname;
            UserForm.upassword = upassword;
            UserForm.udeptname = udeptname;
            UserForm.utelno = utelno;
            UserForm.umail = umail;
            UserForm.uremark = uremark;
            UserForm.uloginImage = uloginImage;

            UserForm.ModifyState = false;
            DialogResult r = UserForm.ShowDialog();

            if (r == DialogResult.OK)
            {
                GetUserData(); //获取用户信息
            }

            UserForm.Dispose();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                userid = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_ID"].Value.ToString();
                uloginname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Code"].Value.ToString();
                ucname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Name"].Value.ToString();

                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认删除[{0}]的用户信息？", uloginname)) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"Delete From Sys_BaseUser 
                                                Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and User_ID = {3}",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,userid);
                DataHelper.Fill(SqlStr);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除用户信息成功.");

                uloginname = "";
                ucname = "";
                upassword = "";
                udeptname = "";
                utelno = "";
                umail = "";
                uremark = "";
                userid = "";
                GetUserData(); //获取用户信息
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("用户信息删除失败." + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "用户信息删除失败.请检查数据库连接状态.");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUserAdmin_Activated(object sender, EventArgs e)
        {
            OptionSetting.MenuTitle = "用户管理";
        }
    }
}
