using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Authority
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using Sys.Config;
    public partial class FrmAuthority : Form
    {
        private DataSet UserDataSet = new DataSet();
        private DataSet MoudleDataSet = new DataSet();
        public FrmAuthority()
        {
            InitializeComponent();
        }

        private bool UpdateAuthorityData(string UserID)
        {
            string sqlQuery = string.Format(" Exec [UpdateUserAuthority]  '{0}','{1}','{2}','{3}','{4}','{5}',{6}", 
                                              BaseSystemInfo.CompanyCode,BaseSystemInfo.CompanyName,BaseSystemInfo.FactoryCode,BaseSystemInfo.FactoryName,BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,UserID);
            DataHelper.Fill(sqlQuery);
            return true;

        }

        private void GetUserData()//获取用户信息
        {
            try
            {
              //  DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"Select User_ID,User_Code,User_Name,Remark
                                                from Sys_User 
                                                Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                order by User_ID", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                UserDataSet = DataHelper.Fill(SqlStr);

                dgv_User.DataSource = UserDataSet.Tables[0];
                dgv_User.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_User.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取用户信息失败." + ex.ToString());
            }
        }

        private void GetUserAuthorityData(string UserID)//获取用户权限信息
        {
            try
            {
              //  DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"Select ID,Menu_Code,Menu_Name,Module_Code,Module_Name,Use_Flag,Add_Flag,Edit_Flag,Delete_Flag,Save_Flag,Export_Flag,Import_Flag
                                                from Sys_BaseUserAuthority
                                                Where User_ID = {0} and Company_Code = '{1}' and Factory_Code = '{2}' and Product_Line_Code = '{3}'
                                                Order By Menu_Code,Module_Code", UserID, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                MoudleDataSet = DataHelper.Fill(SqlStr);

                dgv_Module.DataSource = MoudleDataSet.Tables[0];
                dgv_Module.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_Module.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取用户权限信息失败." + ex.ToString());
            }
        }

        private void FrmAuthority_Load(object sender, EventArgs e)
        {
           // dgv_User.TopLeftHeaderCell.Value = "序号";
            GetUserData(); //获取用户信息
            dgv_User_CellClick(null,null);
        }

        private void dgv_User_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_User.CurrentRow == null || dgv_User.CurrentRow.Index == -1)
                {
                    return;
                }

                if (dgv_User.Rows.Count == 0)
                {
                    GetUserAuthorityData("0");
                    return;
                }

                string UserID = dgv_User.Rows[dgv_User.CurrentRow.Index].Cells["User_ID"].Value.ToString();
                UpdateAuthorityData(UserID);
                GetUserAuthorityData(UserID);
            }
            catch(Exception  ex)
            {
                return;
            }
        }

        private void btn_BatchSave_Click(object sender, EventArgs e)
        {
            try
            {
                AuthorityInfo FAuthorityInfo = new AuthorityInfo();
                for (int i = 0; i < dgv_Module.RowCount; i++)
                {
                    //取得当前权限数据
                    FAuthorityInfo.ID = int.Parse(dgv_Module.Rows[i].Cells["ID"].Value.ToString());
                    FAuthorityInfo.UseFlag = dgv_Module.Rows[i].Cells["Use_Flag"].Value.ToString() == "1";
                    FAuthorityInfo.AddFlag = dgv_Module.Rows[i].Cells["Add_Flag"].Value.ToString() == "1";
                    FAuthorityInfo.EditFlag = dgv_Module.Rows[i].Cells["Edit_Flag"].Value.ToString() == "1";
                    FAuthorityInfo.DeleteFlag = dgv_Module.Rows[i].Cells["Delete_Flag"].Value.ToString() == "1";

                    FAuthorityInfo.SaveFlag = dgv_Module.Rows[i].Cells["Save_Flag"].Value.ToString() == "1";
                    FAuthorityInfo.ExportFlag = dgv_Module.Rows[i].Cells["Export_Flag"].Value.ToString() == "1";
                    FAuthorityInfo.ImportFlag = dgv_Module.Rows[i].Cells["Import_Flag"].Value.ToString() == "1";

                    AuthorityManager.UpdateAuthority(FAuthorityInfo);
                   
                }
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "保存成功,重新打开模块可获取最新权限.");
            }
            catch(Exception  ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "权限数据存储异常.");
                SysBusinessFunction.WriteLog("权限数据存储异常.异常信息" + ex.ToString());
            }


        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
