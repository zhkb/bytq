using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.DbUtilities;
using Sys.SysBusiness;
using Sys.Config;

namespace Material
{
    public partial class FrmLinerCoaming : Form
    {
        private DataSet MasterDataSet = new DataSet();
        public FrmLinerCoaming()
        {
            InitializeComponent();
            dgvCommon.TopLeftHeaderCell.Value = "No.";
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCommon_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void FrmLinerCoaming_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            GetLinerCoamingData("");
        }

        private void GetLinerCoamingData(string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"select c.ID,
                                     m.Material_Code as Liner_Code,
                                     m.Material_Name as Liner_Name,
                                     c.Coaming_Code,
                                     c.Coaming_Name,
                                    Convert(Varchar(100),c.Create_Time,120) Create_Time ,
                                    c.Create_User,
                                     Convert(Varchar(100),c.Modify_Time,120) Modify_Time, 
                                    c.Modify_User
                                   from [IMOS_TA_Material] m
                                  LEFT JOIN Base_Liner_Coaming c on m.Material_Code = c.Liner_Code 
                                  where  m.Material_Type_Code='MN003'
                               "
                               );
                string sOrder = " order by Create_Time desc ";
                SqlStr += sOrder;
                MasterDataSet = DataHelper.Fill(SqlStr);
                dgvCommon.DataSource = MasterDataSet.Tables[0];
                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }

        }

        private void dgvCommon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexNum = e.ColumnIndex;
            if (indexNum == 3 || indexNum == 4)
            {
                ////FrmSelectCoaming SelectCoaming = new FrmSelectCoaming();
                ////DialogResult r = SelectCoaming.ShowDialog();

                ////if (r == DialogResult.OK)
                ////{
                ////    int index = dgvCommon.CurrentRow.Index;
                ////    //dgvCommon.CurrentRow.Cells["Coaming_Code"].Value = SelectCoaming.MaterialCode;
                ////    //dgvCommon.CurrentRow.Cells["Coaming_Name"].Value = SelectCoaming.MaterialName;
                ////    string ID = dgvCommon.CurrentRow.Cells[0].Value.ToString();
                ////    string LinerCode = dgvCommon.CurrentRow.Cells[1].Value.ToString();
                ////    string LinerName = dgvCommon.CurrentRow.Cells[2].Value.ToString();
                ////    string CoamingCode = dgvCommon.CurrentRow.Cells[3].Value.ToString();
                ////    string CoamingName = dgvCommon.CurrentRow.Cells[4].Value.ToString();
                ////   // UpdateLinerCoaming(LinerCode, LinerName, CoamingCode, CoamingName);
                ////    GetLinerCoamingData("");
                ////    dgvCommon.Rows[index].Selected = true;//选中行
                ////}
                ////SelectCoaming.Dispose();

                FrmMaterialSelect SelectMaterial = new FrmMaterialSelect();
                SelectMaterial.MaterialType = "MN002";
                DialogResult r = SelectMaterial.ShowDialog();

                if (r == DialogResult.OK)
                {
                    string MaterialCode = SelectMaterial.MaterialCode;
                    string MaterialName = SelectMaterial.MaterialName;
                    int index = dgvCommon.CurrentRow.Index;
                    dgvCommon.CurrentRow.Cells["Coaming_Code"].Value = SelectMaterial.MaterialCode;
                    dgvCommon.CurrentRow.Cells["Coaming_Name"].Value = SelectMaterial.MaterialName;
                    string ID = dgvCommon.CurrentRow.Cells[0].Value.ToString();
                    string LinerCode = dgvCommon.CurrentRow.Cells[1].Value.ToString();
                    string LinerName = dgvCommon.CurrentRow.Cells[2].Value.ToString();
                    string CoamingCode = dgvCommon.CurrentRow.Cells[3].Value.ToString();
                    string CoamingName = dgvCommon.CurrentRow.Cells[4].Value.ToString();
                    UpdateLinerCoaming(LinerCode, LinerName, CoamingCode, CoamingName);
                    GetLinerCoamingData("");
                    dgvCommon.Rows[index].Selected = true;//选中行

                }
                SelectMaterial.Dispose();
            }

        }


        private static void UpdateLinerCoaming(string LinerCode, string LinerName, string CoamingCode, string CoamingName)
        {
            try
            {

                //通过RFID判断绑定关系表中又没有这条信息
                string sSQLCheck = string.Format(@"select ID from Base_Liner_Coaming 
                                                   where Liner_Code='{0}'"
                                                       , LinerCode.Trim());
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //有修改信息 预装线体是从配置文件中读取到的
                    string SqlStr = string.Format(@"UPDATE [Base_Liner_Coaming] 
                                                    SET [Coaming_Code] = '{0}' ,
                                                    [Coaming_Name] = '{1}',
                                                    [Modify_Time] =GETDATE(),
                                                    [Modify_User] = '{2}'
                                                    WHERE Liner_Code = '{3}'",
                                                  CoamingCode, CoamingName, BaseSystemInfo.CurrentUserName, LinerCode.Trim());
                    DataHelper.Fill(SqlStr);
                }
                else
                {
                    //没有插入信息
                    string SqlStr = string.Format(@"INSERT INTO [Base_Liner_Coaming]
                                                    ([Liner_Code]
                                                    ,[Liner_Name]
                                                    ,[Coaming_Code]
                                                    ,[Coaming_Name]
                                                    ,[Create_Time]
                                                    ,[Create_User]
                                                   )
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,GETDATE()
                                                     ,'{4}')", LinerCode, LinerName, CoamingCode, CoamingName, BaseSystemInfo.CurrentUserName);
                    DataHelper.Fill(SqlStr);

                }
            }
            catch (Exception ex)
            {

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

        private void dgvCommon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
