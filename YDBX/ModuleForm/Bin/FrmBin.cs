using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bin
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using System.Data.Common;
    using System.Data.SqlClient;

    public partial class FrmBin : Form
    {

        public string sBinID = "";
        public string sMaterialCode = "";
        public string sMaterialName = "";

        public FrmBin()
        {
            InitializeComponent();
        }

        private void FrmBin_Load(object sender, EventArgs e)
        {
            BinGrid.TopLeftHeaderCell.Value = "序号";
            GetBinData(); //获取料仓信息
        }

        private void GetBinData()//获取料仓信息
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"SELECT Bin_ID, Bin_No, Bin_Name, Material_Code, Material_Name 
                                                FROM dbo.IMOS_TE_Bin
                                                WHERE Company_Code = '{0}' AND Factory_Code = '{1}' AND Product_Line_Code = '{2}'", 
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);

                BinGrid.DataSource = DBDataSet.Tables[0];
                BinGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                BinGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取料仓信息失败." + ex.ToString());
            }
        }

        private void BinGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BinGrid.Rows.Count == 0)
            {
                return;
            }
            DbParameter[] param = new DbParameter[]
            {
                new SqlParameter("@Parm","")
            };
            string title = "物料选择";
            FrmCommSelect csFrm = new FrmCommSelect(title, "up_IMOS_TA_MATERIAL_Bin", param);
            csFrm.sBinId = BinGrid.Rows[BinGrid.CurrentRow.Index].Cells["Bin_ID"].Value.ToString();
            csFrm.getValueHandler = GetProcessValue;//将方法赋给委托对象
            csFrm.ShowDialog();

            if (sMaterialCode != "")
            {
                sBinID = BinGrid.Rows[BinGrid.CurrentRow.Index].Cells["Bin_ID"].Value.ToString();
                string SqlStr = string.Format(@"UPDATE dbo.IMOS_TE_Bin 
                                                SET Material_Code = '{0}', Material_Name = '{1}', 
                                                    Last_Update_Date = GETDATE(), Last_Updated_By = {2}
                                            WHERE Bin_ID = {3}", sMaterialCode, sMaterialName, BaseSystemInfo.CurrentUserID, sBinID);
                DataHelper.Fill(SqlStr);
                GetBinData();
                sMaterialCode = "";
                sMaterialName = "";
            }
        }

        public void GetProcessValue(DataGridViewRow dgvr)
        {
            sMaterialCode = dgvr.Cells[1].Value.ToString();
            sMaterialName = dgvr.Cells[2].Value.ToString();
        }

        private void UserGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//序号列
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUserAdmin_Activated(object sender, EventArgs e)
        {
            OptionSetting.MenuTitle = "料仓管理";
        }
    }
}
