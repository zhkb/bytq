using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoamingMaterial
{
    using Sys.Utilities;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    public partial class FrmFoaming : Form
    {

       private string MasterTypeCode = "1002";
        private string DetialTypeCode = "1001";

        public FrmFoaming()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btn_OK.Enabled = false;
                if (MaterialGrid.Rows.Count == 0)
                {
                    return;
                }

                string MaterCode = MaterialGrid.Rows[MaterialGrid.CurrentRow.Index].Cells["Material_Code"].Value.ToString();

                string SqlStr = string.Format(@"Update imos_ta_material
                                                Set Display_Flag = 1,Plan_Qty = 0
                                                where Factory_Code = '{0}'
                                                and Master_type_code = '{1}'
                                                and detial_type_code = '{2}'
                                                and Material_Code = '{3}'",BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode, MaterCode);

                DataHelper.Fill(SqlStr);

                GetFoamingMaterialData();
            }
            catch
            {

            }
            finally
            {
                btn_OK.Enabled = true;
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Select.Enabled = false;
                GetMaterialData(txt_SearchText.Text.Trim());
                GetFoamingMaterialData();
            }
            catch
            {

            }
            finally
            {
                btn_Select.Enabled = true;

                txt_SearchText.Focus();
            }
        }

        private void GetMaterialData(string SerchTxt)//按照条件进行组盘数据查询
        {
            DataSet MaterialDataSet = new DataSet();

            try
            {
                string SqlStr = string.Format(@"select Material_Code,Material_Name 
                                                from imos_ta_material
                                                where Factory_Code = '{0}'
                                                and Master_type_code = '{1}'
                                                and detial_type_code = '{2}'
                                                and (Material_Code like '%{3}%' or Material_Name like '%{3}%')
                                                and Display_Flag <> 1
                                                Order By Material_Code",
                                                BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode, SerchTxt);

                MaterialDataSet = DataHelper.Fill(SqlStr);

                MaterialGrid.DataSource = MaterialDataSet.Tables[0];

                MaterialGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                MaterialGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
            catch
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询条码数据异常，请检查数据库连接.");
            }
            finally
            {
                MaterialDataSet.Dispose();
            }
        }

        private void GetFoamingMaterialData()//按照条件进行组盘数据查询
        {
            DataSet FoamingBarDataSet = new DataSet();

            try
            {
                string SqlStr = string.Format(@"select Material_Code,Material_Name,Plan_Qty, Display_Flag
                                                from imos_ta_material
                                                where Factory_Code = '{0}'
                                                and Master_type_code = '{1}'
                                                and detial_type_code = '{2}'
                                                and Display_Flag = 1
                                                Order By Display_Flag Desc,Material_Code",
                                                BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode);

                FoamingBarDataSet = DataHelper.Fill(SqlStr);

                FoamingGrid.DataSource = FoamingBarDataSet.Tables[0];

                FoamingGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                FoamingGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
            catch(Exception  ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询条码数据异常，请检查数据库连接.");
                SysBusinessFunction.WriteLog("删除物料异常." + ex.Message);
            }
            finally
            {
                FoamingBarDataSet.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmFoaming_Load(object sender, EventArgs e)
        {

        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Del.Enabled = false;
                if (FoamingGrid.Rows.Count == 0)
                {
                    return;
                }

                string MasterTypeCode = "1002";
                string DetialTypeCode = "1001";

                string MaterCode = FoamingGrid.Rows[FoamingGrid.CurrentRow.Index].Cells["Foaming_Code"].Value.ToString();

                string SqlStr = string.Format(@"Update imos_ta_material
                                                Set Display_Flag = 0
                                                where Factory_Code = '{0}'
                                                and Master_type_code = '{1}'
                                                and detial_type_code = '{2}'
                                                and Material_Code = '{3}'",BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode, MaterCode);

                DataHelper.Fill(SqlStr);

                GetFoamingMaterialData();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除物料异常.");
                SysBusinessFunction.WriteLog("删除物料异常." + ex.Message);
            }
            finally
            {
                btn_Del.Enabled = true;
            }
        }

        private void btn_AllDel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_AllDel.Enabled = false;
                if (FoamingGrid.Rows.Count == 0)
                {
                    return;
                }

                string MasterTypeCode = "1002";
                string DetialTypeCode = "1001";

                string SqlStr = string.Format(@"Update imos_ta_material
                                                Set Display_Flag = 0
                                                where Factory_Code = '{0}'
                                                and Master_type_code = '{1}'
                                                and detial_type_code = '{2}'
                                                and Display_Flag = 1", BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode);

                DataHelper.Fill(SqlStr);

                GetFoamingMaterialData();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除物料异常.");
                SysBusinessFunction.WriteLog("删除物料异常." + ex.Message);
            }
            finally
            {
                btn_AllDel.Enabled = true;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                btn_OK.Enabled = false;
                if (MaterialGrid.Rows.Count == 0)
                {
                    return;
                }

                string MasterTypeCode = "1002";
                string DetialTypeCode = "1001";

                string MaterCode = MaterialGrid.Rows[MaterialGrid.CurrentRow.Index].Cells["Material_Code"].Value.ToString();

                string SqlStr = string.Format(@"Update imos_ta_material
                                                Set Display_Flag = 1,Plan_Qty = 0
                                                where Factory_Code = '{0}'
                                                and Master_type_code = '{1}'
                                                and detial_type_code = '{2}'
                                                and Material_Code = '{3}'", BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode, MaterCode);

                DataHelper.Fill(SqlStr);

                GetFoamingMaterialData();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加物料异常.");
                SysBusinessFunction.WriteLog("添加物料异常." + ex.Message);
            }
            finally
            {
                btn_OK.Enabled = true;
            }
        }

        private void MaterialGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_OK_Click(null,null);
        }

        private void FoamingGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Del_Click(null, null);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save.Enabled = false;
                if (FoamingGrid.Rows.Count == 0)
                {
                    return;
                }


                int DataCount = 0;
                for (int i = 0; i < FoamingGrid.Rows.Count; i++)
                {
                    int PlanQty = 0;
                    if (FoamingGrid.Rows[i].Cells["Plan_Qty"].Value.ToString().Trim() != "")
                    {
                        PlanQty = Convert.ToInt32(FoamingGrid.Rows[i].Cells["Plan_Qty"].Value.ToString());
                    }
        
                        string MaterCode = FoamingGrid.Rows[i].Cells["Foaming_Code"].Value.ToString();
                        string SqlStr = string.Format(@"Update imos_ta_material
                                                Set Plan_Qty = {0}
                                                where Factory_Code = '{1}'
                                                and Master_type_code = '{2}'
                                                and detial_type_code = '{3}'
                                                and Material_Code = '{4}'", PlanQty,BaseSystemInfo.FactoryCode, MasterTypeCode, DetialTypeCode, MaterCode);

                        DataHelper.Fill(SqlStr);
                    
                }


                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "发泡计划数据保存成功.");
                
            }
            catch(Exception  ex )
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "保存数据异常.");
                SysBusinessFunction.WriteLog("保存数据异常." + ex.Message);
            }
            finally
            {
                btn_Save.Enabled = true;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_SearchText.Text = "";
            btn_Select_Click(null, null);
        }
    }
}
