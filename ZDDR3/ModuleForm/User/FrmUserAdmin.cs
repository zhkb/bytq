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

    public partial class FrmUserAdmin : Form
    {
        public string uloginname = "";
        public string ucname = "";
        public string upassword = "";
        public string userid = "";
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
                string SqlStr = string.Format(@"Select User_ID,User_Code,User_Name,User_PassWord,Operator_Flag,Tech_Flag,Check_Flag,Plan_Flag,Admin_Flag
                                                from Sys_User order by User_ID");
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

            userid = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_ID"].Value.ToString();
            uloginname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Code"].Value.ToString();
            ucname = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_Name"].Value.ToString();


            upassword = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["User_PassWord"].Value.ToString();

            bool OperFlag = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Operator_Flag"].Value.ToString() == "1";
            bool TechFlag = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Tech_Flag"].Value.ToString() == "1";
            bool PlanFlag = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Plan_Flag"].Value.ToString() == "1";
            bool CheckFlag = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Check_Flag"].Value.ToString() == "1";
            bool AdminFlag = UserGrid.Rows[UserGrid.CurrentRow.Index].Cells["Admin_Flag"].Value.ToString() == "1";

            FrmUserModify UserForm = new FrmUserModify();
            UserForm.userid = userid;
            UserForm.uloginname = uloginname;
            UserForm.ucname = ucname;
            UserForm.upassword = upassword;

            UserForm.OperFlag = OperFlag;
            UserForm.TechFlag = TechFlag;
            UserForm.PlanFlag = PlanFlag;
            UserForm.CheckFlag = CheckFlag;
            UserForm.AdminFlag = AdminFlag;

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

                string SqlStr = string.Format(@"Delete From Sys_User Where User_ID = '{0}'", userid);
                //string SqlStr = string.Format(@"exec Del_User {0}", userid);


                DataHelper.Fill(SqlStr);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除用户信息成功.");

                uloginname = "";
                ucname = "";
                upassword = "";
                userid = "";
                GetUserData(); //获取用户信息
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("物料信息删除失败." + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料信息删除失败.请检查数据库连接状态.");
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
