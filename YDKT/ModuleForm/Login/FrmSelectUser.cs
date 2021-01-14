using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    using Sys.DbUtilities;
    using Sys.Utilities;
    using Sys.Config;
    public partial class FrmSelectUser : BaseForm
    {
        public string UserName = "";
        public string UserNo = "";
        public string UserID = "";
        public string UserPass = "";

        public bool OperFlag; //操作员权限
        public bool TechFlag;//工艺员权限
        public bool PlanFlag;//计划员权限
        public bool CheckFlag;//质检员权限
        public bool AdminFlag;//管理员权限

        public int FIndex;
        public Color[] ViewBackColor = { Color.White, Color.White }; //列表间隔颜色
        public FrmSelectUser()
        {
            InitializeComponent();
        }

        private void FrmSelectUser_Load(object sender, EventArgs e)
        {
            MasterGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MasterGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleTurquoise;
            GetUserListData();
        }

        public void GetUserListData()
        {
            DataSet DBDataSet = new DataSet();
            string SelectSql = string.Format(@"select User_ID,User_Code,User_Name,Operator_Flag,Tech_Flag,Check_Flag,Plan_Flag,Admin_Flag
                                               from Sys_User 
                                               Order by User_Name");
            DBDataSet = DataHelper.Fill(SelectSql);

            MasterGrid.DataSource = DBDataSet.Tables[0].DefaultView;

            MasterGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            MasterGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            DBDataSet.Dispose();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MasterGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void MasterGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MasterGrid.Rows.Count == 0)
                {
                    return;
                }

                UserName = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["User_Name"].Value.ToString();
                UserNo = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["User_Code"].Value.ToString();
                UserID = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["User_ID"].Value.ToString();

                OperFlag = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["Operator_Flag"].Value.ToString() == "1";
                TechFlag = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["Tech_Flag"].Value.ToString() == "1";
                PlanFlag = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["Plan_Flag"].Value.ToString() == "1";
                CheckFlag = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["Check_Flag"].Value.ToString() == "1";
                AdminFlag = MasterGrid.Rows[MasterGrid.CurrentRow.Index].Cells["Admin_Flag"].Value.ToString() == "1";

                DialogResult = DialogResult.OK;
            }
            catch
            {
                return;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                MasterGrid_CellDoubleClick(null, null);
            }
            catch
            {
            }
        }
    }
}
