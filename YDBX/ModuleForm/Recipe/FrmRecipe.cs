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

namespace Recipe
{
    using Sys.DbUtilities;
    using Sys.Config;
    using Sys.SysBusiness;
    public partial class FrmRecipe : Form
    {
        private string CurrentRecipeID = "";
        private bool NewFlag = false; //是否新增
        private DataGridViewRowStateChangedEventArgs MaterialArgs;
        TextBox control;

        public FrmRecipe()
        {
            InitializeComponent();
        }

        private void FrmRecipe_Load(object sender, EventArgs e)
        {
            dgv_Recipe.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_Recipe.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgv_Material.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv_Material.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            RecipeDataList("");

            dgv_Recipe_CellClick(null, null);
            try
            {
                ArrayList ClassGroups = new ArrayList();
                string sSQL = string.Format(@"SELECT [Parameter_Detail_Code],[Parameter_Detail_Name] 
                            FROM [Sys_Parameters_Detail] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                            and Parameter_Master_Name = '{3}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, "配方类型");

                DataSet ds = DataHelper.Fill(sSQL);
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ClassGroups.Add(new Sys.SysBusiness.GroupInfo(dr["Parameter_Detail_Code"].ToString(), dr["Parameter_Detail_Name"].ToString()));
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        com_RecipeType.DataSource = ClassGroups;
                        com_RecipeType.DisplayMember = "Name";
                        com_RecipeType.ValueMember = "ID";
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void RecipeDataList(string sKey)
        {
            try
            {
                string SqlStr = string.Format(@"select a.Recipe_ID,a.Recipe_Code,a.Recipe_Name,b.Parameter_Detail_Name Recipe_TypeName,a.Recipe_Version,Total_Weight,Mixing_StartTime,Mixing_Time,ISNULL(a.Use_Flag,0) Use_Flag,ISNULL(a.Verify_Status,0) Verify_Status,
                                                Case when ISNULL(a.Use_Flag,0) = 1 then '启用' else '禁用' end Use_FlagName,Case when ISNULL(a.Verify_Status,0) = 0 then '未审核' else '已审核' end Verify_Name,
                                                c.User_Name Create_UserName ,Convert(varchar(20),a.Creation_Date,120) Create_Time,Convert(varchar(20),a.Last_Update_Date,120) Update_Time,d.User_Name Update_UserName
                                                from IMOS_TE_Recipe a 
                                                left join Sys_Parameters_Detail b on (a.Company_Code = b.Company_Code and a.Factory_Code=b.Factory_Code and a.Product_Line_Code = b.Product_Line_Code and a.Recipe_Type =b.Parameter_Detail_Code and b.Parameter_Master_Name = '配方类型')
                                                left join Sys_BaseUser c on (a.Company_Code = c.Company_Code and a.Factory_Code=c.Factory_Code and a.Product_Line_Code = c.Product_Line_Code and a.Created_By =c.User_ID)
                                                left join Sys_BaseUser d on (a.Company_Code = d.Company_Code and a.Factory_Code=d.Factory_Code and a.Product_Line_Code = d.Product_Line_Code and a.Last_Updated_By =d.User_ID)
                                                Where  a.Company_Code = '{0}' and a.Factory_Code = '{1}' and a.Product_Line_Code = '{2}'
                                                and (a.Recipe_Code like '%{3}%' or a.Recipe_Name like '%{3}%' or a.Remark like '%{3}%')
                                                order by a.Last_Update_Date desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sKey);

                DataSet RecipeDataSet = new DataSet();
                RecipeDataSet = DataHelper.Fill(SqlStr);

                dgv_Recipe.DataSource = RecipeDataSet.Tables[0];


            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

        private void dgv_Recipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Recipe.CurrentRow == null || dgv_Recipe.CurrentRow.Index == -1)
                {
                    return;
                }

                CurrentRecipeID = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_ID"].Value.ToString();
                txt_RecipeCode.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_Code"].Value.ToString();
                txt_RecipeName.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_Name"].Value.ToString();
                com_RecipeType.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_TypeName"].Value.ToString();
                txt_RecipeVersion.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_Version"].Value.ToString();
                txt_RecipeWeight.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Total_Weight"].Value.ToString();
                txt_MixingTime.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Mixing_Time"].Value.ToString();
                txt_StartTime.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Mixing_StartTime"].Value.ToString();
                chk_Use.Checked = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Use_Flag"].Value.ToString() == "1";

                txt_CreateUser.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Create_UserName"].Value.ToString();
                txt_CreateTime.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Create_Time"].Value.ToString();
                txt_UpdateUser.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Update_UserName"].Value.ToString();
                txt_UpdateTime.Text = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Update_Time"].Value.ToString();

                GetRecipeDetail(txt_RecipeCode.Text, txt_RecipeVersion.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void GetRecipeDetail(string Recipe_Code,string RecipeVersion)
        {
            try
            {
                string SqlStr = string.Format(@"select a.Material_Code, a.Material_Name, a.Material_Type_Code, a.Material_Type_Name, a.Weight, a.Tolerance
                                                from IMOS_TE_Recipe_Detail a 
                                                Where  a.Company_Code = '{0}' and a.Factory_Code = '{1}' and a.Product_Line_Code = '{2}'
                                                and a.Recipe_Code = '{3}' and a.Recipe_Version ='{4}'
                                                order by a.ID", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Recipe_Code, RecipeVersion);

                DataSet MaterialDataSet = new DataSet();
                MaterialDataSet = DataHelper.Fill(SqlStr);

                dgv_Material.Rows.Clear();
                for (int i = 0; i < MaterialDataSet.Tables[0].Rows.Count; i++)
                {
                    dgv_Material.Rows.Add();

                    int FIndex = dgv_Material.Rows.Count - 1;

                    dgv_Material.Rows[FIndex].Cells["Material_Code"].Value = MaterialDataSet.Tables[0].Rows[i]["Material_Code"].ToString();
                    dgv_Material.Rows[FIndex].Cells["Material_Name"].Value = MaterialDataSet.Tables[0].Rows[i]["Material_Name"].ToString();

                    dgv_Material.Rows[FIndex].Cells["Material_Type_Code"].Value = MaterialDataSet.Tables[0].Rows[i]["Material_Type_Code"].ToString();
                    dgv_Material.Rows[FIndex].Cells["Material_Type_Name"].Value = MaterialDataSet.Tables[0].Rows[i]["Material_Type_Name"].ToString();

                    dgv_Material.Rows[FIndex].Cells["Material_Spec"].Value = MaterialDataSet.Tables[0].Rows[i]["Material_Code"].ToString();

                    dgv_Material.Rows[FIndex].Cells["Weight"].Value = MaterialDataSet.Tables[0].Rows[i]["Weight"].ToString();

                    dgv_Material.Rows[FIndex].Cells["Tolerance"].Value = MaterialDataSet.Tables[0].Rows[i]["Tolerance"].ToString();
                }

               // dgv_Material.DataSource = MaterialDataSet.Tables[0];


            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {

                string RecipeCode = txt_RecipeCode.Text;
                string RecipeName = txt_RecipeName.Text;
                string RecipeVersion = txt_RecipeVersion.Text;
                string TotalWeight = txt_RecipeWeight.Text;
                string MixingTime = txt_MixingTime.Text;
                string StartTime = txt_StartTime.Text;

                if (NewFlag)
                {
                    string CheckSql = string.Format(@"select * from IMOS_TE_Recipe a 
                                                      Where  a.Company_Code = '{0}' and a.Factory_Code = '{1}' and a.Product_Line_Code = '{2}'
                                                      and a.Recipe_Code = '{3}' and a.Recipe_Version  ='{4}'",
                                                      BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, RecipeCode, RecipeVersion);

                    DataSet MasterDataSet = new DataSet();
                    MasterDataSet = DataHelper.Fill(CheckSql);

                    if (MasterDataSet.Tables[0].Rows.Count > 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "配方编号及版本号重复，请重新编辑!");
                        return;
                    }

                    string SqlStr = string.Format(@"INSERT INTO IMOS_TE_Recipe(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                Recipe_Code,Recipe_Name, Recipe_Type,Recipe_Version,Total_Weight,Mixing_StartTime,Mixing_Time,Use_Flag,Created_By,Last_Updated_By)
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')",
                                BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                RecipeCode, RecipeName, com_RecipeType.SelectedValue.ToString(), RecipeVersion, TotalWeight, StartTime, MixingTime, Convert.ToInt32(chk_Use.Checked), BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID);

                    DataHelper.Fill(SqlStr);

                }
                else
                {
                    string SqlStr = string.Format(@"Update IMOS_TE_Recipe
                                                    Set Recipe_Name = '{0}',Recipe_Type= '{1}',Total_Weight= '{2}',Mixing_StartTime= '{3}',Mixing_Time= '{4}',Use_Flag= '{5}',Last_Updated_By= '{6}',Last_Update_Date = Getdate()
                                                    Where Recipe_ID = '{7}'", RecipeName, com_RecipeType.SelectedValue.ToString(), TotalWeight, StartTime, MixingTime, Convert.ToInt32(chk_Use.Checked), BaseSystemInfo.CurrentUserID, CurrentRecipeID);

                    DataHelper.Fill(SqlStr);
                }

                //删除配方明细数据
                string DelStr = string.Format(@"Delete From IMOS_TE_Recipe_Detail 
                                                Where  Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and Recipe_Code = '{3}' and Recipe_Version = '{4}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, RecipeCode, RecipeVersion); 

                DataHelper.Fill(DelStr);
                for (int i = 0; i < dgv_Material.Rows.Count; i++)
                {
                    string MaterialCode = dgv_Material.Rows[i].Cells["Material_Code"].Value.ToString();
                    string MaterialName = dgv_Material.Rows[i].Cells["Material_Name"].Value.ToString();
                    string MaterialTypeCode = dgv_Material.Rows[i].Cells["Material_Type_Code"].Value.ToString();
                    string MaterialTypeName = dgv_Material.Rows[i].Cells["Material_Type_Name"].Value.ToString();

                    string MaterialWeight = "0";
                    if ( dgv_Material.Rows[i].Cells["Weight"].Value != null)
                    {
                         MaterialWeight = dgv_Material.Rows[i].Cells["Weight"].Value.ToString();
                    }

                    string MaterialTolerance = "0";
                    if (dgv_Material.Rows[i].Cells["Tolerance"].Value != null)
                    {
                        MaterialTolerance = dgv_Material.Rows[i].Cells["Tolerance"].Value.ToString();
                    }


                    string MaterialUnit = "Kg";
                    string DetailStr = string.Format(@"INSERT INTO IMOS_TE_Recipe_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                Recipe_Code,Recipe_Name, Recipe_Type,Recipe_Version,Material_Code, Material_Name, Material_Type_Code, Material_Type_Name, Weight, Tolerance, Unit,Created_By,Last_Updated_By)
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                RecipeCode, RecipeName, com_RecipeType.SelectedValue.ToString(), RecipeVersion, MaterialCode, MaterialName, MaterialTypeCode, MaterialTypeName, MaterialWeight, MaterialTolerance, MaterialUnit,
                                                BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID);

                    DataHelper.Fill(DetailStr);
                }


                RecipeDataList("");
                dgv_Recipe_CellClick(null, null);

                txt_RecipeCode.Enabled = false;
                txt_RecipeVersion.Enabled = false;
                SetModifyStatus(false);
            }
            catch (Exception ex)
            {


            }


        }

        private void btn_Del_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgv_Recipe.CurrentRow == null || dgv_Recipe.CurrentRow.Index == -1)
                {
                    return;
                }

                string RCode = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_Code"].Value.ToString();
                string RName = dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Recipe_Name"].Value.ToString();

                string sMessage = string.Format(@"是否确认删除配方数据：【{0}】【{1}】？", RCode, RName);
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }


                string SqlStr = string.Format(@"Delete From IMOS_TE_Recipe 
                                                Where Company_Code = '{0}' and Factory_Code = '{1}'and Product_Line_Code = '{2}'and Recipe_ID = '{3}'",
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, CurrentRecipeID);

                DataHelper.Fill(SqlStr);
                RecipeDataList("");
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                SetModifyStatus(true);
            }
            catch
            {

            }
        }

        private void SetModifyStatus(bool StatusFlag)
        {

            txt_RecipeName.Enabled = StatusFlag;
            com_RecipeType.Enabled = StatusFlag;
            txt_RecipeWeight.Enabled = StatusFlag;
            txt_MixingTime.Enabled = StatusFlag;
            txt_StartTime.Enabled = StatusFlag;
            chk_Use.Enabled = StatusFlag;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                txt_RecipeCode.Text = "";
                txt_RecipeName.Text = "";
                txt_RecipeVersion.Text = "";
                com_RecipeType.Text = "";
                txt_RecipeWeight.Text = "";
                txt_MixingTime.Text = "";
                txt_StartTime.Text = "";
                chk_Use.Checked = false;

                txt_CreateUser.Text = "";
                txt_CreateTime.Text = "";
                txt_UpdateUser.Text = "";
                txt_UpdateTime.Text = "";

                txt_RecipeCode.Enabled = true;
                txt_RecipeVersion.Enabled = true;
                SetModifyStatus(true);
                NewFlag = true;
            }
            catch
            {

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menu_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaterialList FrmItem = new FrmMaterialList();
                FrmItem.ShowDialog();

                dgv_Material.Rows.Add();

                int FIndex = dgv_Material.Rows.Count - 1;

                dgv_Material.Rows[FIndex].Cells["Material_Code"].Value = FrmItem.MaterialCode;
                dgv_Material.Rows[FIndex].Cells["Material_Name"].Value = FrmItem.MaterialName;

                dgv_Material.Rows[FIndex].Cells["Material_Type_Code"].Value = FrmItem.MaterialTypeCode;
                dgv_Material.Rows[FIndex].Cells["Material_Type_Name"].Value = FrmItem.MaterialTypeName;

                dgv_Material.Rows[FIndex].Cells["Material_Spec"].Value = FrmItem.MaterialSpec;
                FrmItem.Dispose();


            }
            catch(Exception  ex)
            {

            }

        }

        private void dgv_Material_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Material_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Material.CurrentCell == null)
            {
                return;
            }
            if (dgv_Material.Columns[dgv_Material.CurrentCell.ColumnIndex].Name == "Weight")
            {
                //      MessageBox.Show(dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Weight"].Value.ToString());
            }
        }

        private void dgv_Material_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //MaterialArgs = e;
            //e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_Recipe_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_Material_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgv_Material_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


            if (e.Control.GetType().BaseType.Name == "TextBox")

            {

                control = new TextBox();

                control = (TextBox)e.Control;

                control.KeyPress += new KeyPressEventHandler(control_KeyPress);

            }
        }


        void control_KeyPress(object sender, KeyPressEventArgs e)

        {

            //限制只能输入-9的数字，退格键，小数点和回车

            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || e.KeyChar == 13 || e.KeyChar == 8 || e.KeyChar == 46)

            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("只能输入数字！");
            }

        }



        void control_Leave(object sender, EventArgs e)

        {

            //如果需要限制字符串输入长度

            //if (control.Text.Length != 11)

            //{

            //    MessageBox.Show("只能为位！");

            //    control.Focus();

            //}

        }

        private void menu_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Material.CurrentRow == null || dgv_Material.CurrentRow.Index == -1)
                {
                    return;
                }

                string MCode = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Code"].Value.ToString();
                string MName = dgv_Material.Rows[dgv_Material.CurrentRow.Index].Cells["Material_Name"].Value.ToString();

                string sMessage = string.Format(@"是否确认删除物料数据：【{0}】【{1}】？", MCode, MName);
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                dgv_Material.Rows.Remove(dgv_Material.CurrentRow);//


            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_Material_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //    dgv_Material_RowStateChanged(null, MaterialArgs);
        }

        private void dgv_Material_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView CurrentGrid = (DataGridView)sender;

            System.Drawing.Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Y, CurrentGrid.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                CurrentGrid.RowHeadersDefaultCellStyle.Font, rectangle,
                CurrentGrid.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);//
        }

        private void dgv_Material_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Recipe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView CurrentGrid = (DataGridView)sender;

            System.Drawing.Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Y, CurrentGrid.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                CurrentGrid.RowHeadersDefaultCellStyle.Font, rectangle,
                CurrentGrid.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);//
        }
    }
}
