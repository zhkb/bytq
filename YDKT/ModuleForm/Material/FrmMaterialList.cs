using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Material
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using ControlLogic;
    public partial class FrmMaterialList : Form
    {
        public string SourceType = ""; //物料类型
        public int MaterIndex = 0;
        public FrmMaterialList()
        {
            InitializeComponent();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GetMaterialList();
        }

        private void GetMaterialList() //取得物料列表数据
        {
            #region 查询物料数据
            try
            {
                string SqlStr = "";
                DataSet PartDataSet = new DataSet();

                SqlStr = string.Format(@"Select Material_Code,Material_Name
                                         From Mixing_Material
                                         Where Company_Code = '{0}' and Factory_Code = '{1}' and ProductLine_Code = '{2}'
                                         and Type_Code = '{3}'
                                         Order by Material_Name", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, SourceType);
                PartDataSet = DataHelper.Fill(SqlStr);

                PartGrid.DataSource = PartDataSet.Tables[0];

                PartGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                PartGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
            finally
            {
                btn_Down.Enabled = PartGrid.Rows.Count > 0;
            }
            #endregion
        }

        private void FrmMaterialList_Load(object sender, EventArgs e)
        {
            PartGrid.TopLeftHeaderCell.Value = "序号";
            PartGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GetMaterialList();
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Down.Enabled = false;
                if (PartGrid.Rows.Count == 0)
                {
                    return;
                }

                string MaterCode = PartGrid.Rows[PartGrid.CurrentRow.Index].Cells["Material_Code"].Value.ToString();

                bool DownResult = false;// ControlData.DownLoadMaterialCode(MaterCode, MaterIndex);

                if (DownResult)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("下传成功.物料编码【0】", MaterCode));
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("下传失败.物料编码【0】", MaterCode));
                }
            }
            catch
            {
            }
            finally
            {
                btn_Down.Enabled = true;
            }
        }

        private void PartGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
