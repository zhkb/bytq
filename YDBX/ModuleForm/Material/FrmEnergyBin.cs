using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material
{
    public partial class FrmEnergyBin : Form
    {
        public FrmEnergyBin()
        {
            InitializeComponent();
        }
        #region 界面加载
        private void FrmEnergyBin_Load(object sender, EventArgs e)
        {
            GetEnergyLabel();
        }

        #endregion

        #region 获取能效贴信息
        private void GetEnergyLabel()//获取能效贴信息
        {
            try
            {
                String sql = String.Format(@"SELECT  Bin_No,Energy_Label_Code,Energy_Label_Name,Material_Actual_Qty,Material_Theory_Qty FROM IMOS_TA_Energy_List WHERE 1=1 ORDER BY ID");
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("获取能耗贴-网格信息失败！");
                    return;
                }
                dgvCommon.DataSource = ds.Tables[0];
                dgvCommon.ClearSelection();
                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("获取能耗贴-网格信息失败！"+ex.Message);
            }
        }
        #endregion

        #region 能耗贴列表点击事件
        private void dgvCommon_CellClick(object sender, DataGridViewCellEventArgs e)//点击dgvCommon单元格
        {
            try
            {
                if (e.RowIndex >= 0) //判断选中的行是不是表头
                {
                  if(e.ColumnIndex == 0)
                    {
                        string  BinNo = dgvCommon.Rows[e.RowIndex].Cells["Bin_No"].Value.ToString();
                        FrmEnergyImage fei = new FrmEnergyImage();
                        fei.BinNo = BinNo;
                        fei.Show();
                    }                  
                }    
            }
            catch(Exception ex)
            {

            }

        }
        #endregion

        #region 编辑按钮点击事件
        private void btn_Edit_Click(object sender, EventArgs e)//编辑按钮单击事件
        {
            try
            {
                if(dgvCommon.SelectedRows.Count != 1)
                {
                    return;
                }
                FrmEnergyBinModify feb = new FrmEnergyBinModify();
                feb.binno = dgvCommon.SelectedRows[0].Cells["Bin_No"].Value.ToString();
                DialogResult r = feb.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetEnergyLabel();
                }
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑冰箱和能耗贴的关系信息发生错误！");
            }
        }
        #endregion

        #region 关闭按钮点击事件
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
