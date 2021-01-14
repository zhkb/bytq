using Sys.Config;
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
    public partial class FrmQualityItem : Form
    {
        private string Item_Code = "";
        public FrmQualityItem()
        {
            InitializeComponent();
            dgvCommonDetail.TopLeftHeaderCell.Value = "序号";
            dgvCommonMaster.TopLeftHeaderCell.Value = "序号";
        }

        #region  界面加载

        private void FrmQualityItem_Load(object sender, EventArgs e)
        {
            try
            {
                //刷新质检项目
                GetCheckItem();
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("加载界面发生异常！"+ex.Message);
            }
        }

        #endregion

        #region  查询质检项目并显示
        private void GetCheckItem()
        {
            try
            {

                String sql = String.Format(@"SELECT ID,Check_Item_Code,Check_Item_Name,Check_Item_Name_EN FROM  IMOS_PR_QualityItem_Master  where  Company_Code = '{0}'
                                             and Factory_Code = '{1}' and Product_Line_Code = '{2}'",BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("查询IMOS_PR_QualityItem_Master数据库表失败！");
                    return;
                }
                dgvCommonMaster.DataSource = ds.Tables[0];
                dgvCommonMaster.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommonMaster.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("查询IMOS_PR_QualityItem_Master数据库表失败！");
            }
        }
        #endregion

        #region 查询质检缺陷并显示
        private void GetCheckDetail()
        {
            try
            {
                String sql = String.Format(@"SELECT  
                                                  ID,
                                                  Check_Item_Detail_Code,
                                                  Check_Item_Detail_Name,
                                                  Check_Item_Detail_Name_EN
                                             From IMOS_PR_QualityItem_Detail
                                             Where 
                                                   Check_Item_Code = '{0}' and
                                                   Company_Code = '{1}' and
                                                   Factory_Code = '{2}' and 
                                                   Product_Line_Code = '{3}'",
                                            Item_Code,BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);
                DataSet ds = DataHelper.Fill(sql);
                if(ds == null)
                {
                    SysBusinessFunction.WriteLog("查询IMOS_PR_QualityItem_Detail数据库表失败！");
                    return;
                }
                dgvCommonDetail.DataSource = ds.Tables[0];
                dgvCommonDetail.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommonDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("查询IMOS_PR_QualityItem_Detail数据库表失败！");
            }
        }
        #endregion

        #region 质检按钮事件

        //质检添加按钮事件
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQualityItemModify fqim = new FrmQualityItemModify();
                fqim.Flag = false;
                DialogResult r = fqim.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetCheckItem();
                }

                fqim.Dispose();
            }
            catch(Exception ex)
            {

            }
        }

        //质检编辑按钮事件
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try{
                if (dgvCommonMaster.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(2, "请选择一条质检项！");
                    return;
                }
                FrmQualityItemModify fqim = new FrmQualityItemModify();
                fqim.id = dgvCommonMaster.SelectedRows[0].Cells["ID"].Value.ToString();
                fqim.code = dgvCommonMaster.SelectedRows[0].Cells["Check_Item_Code"].Value.ToString();
                fqim.cnname = dgvCommonMaster.SelectedRows[0].Cells["Check_Item_Name"].Value.ToString();
                fqim.enname = dgvCommonMaster.SelectedRows[0].Cells["Check_Item_Name_EN"].Value.ToString();
                fqim.Flag = true;
                DialogResult r = fqim.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetCheckItem();
                }

                fqim.Dispose();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("质检编辑异常" + ex.Message);
            }
        }

        //质检删除按钮事件
        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCommonMaster.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(2, "请选择一条质检项！");
                    return;
                }
                string message = String.Format(@"确定删除编号为【{0}】的质检项数据吗？", dgvCommonMaster.SelectedRows[0].Cells["Check_Item_Code"].Value.ToString());
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, message) == DialogResult.No)
                {
                    return;
                }
                //删除Master表
                string SqlStr = string.Format(@"DELETE FROM [IMOS_PR_QualityItem_Master] WHERE ID = '{0}'", dgvCommonMaster.SelectedRows[0].Cells["ID"].Value.ToString());
                DataHelper.Fill(SqlStr);
                //删除Detail表
                string SqlStr2 = string.Format(@"DELETE FROM [IMOS_PR_QualityItem_Detail] WHERE Check_Item_Code = '{0}'", dgvCommonMaster.SelectedRows[0].Cells["Check_Item_Code"].Value.ToString());
                DataHelper.Fill(SqlStr2);
                GetCheckItem();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("删除质检项列表数据失败！" + ex.Message);
            }
        }
        #endregion

        #region  DataGridView排序

        //质检项列表排序
        private void dgvCommonMaster_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvCommonMaster.Rows)
                {
                    r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    r.HeaderCell.Value = r.Index + 1+"";
                }
                dgvCommonMaster.ClearSelection();
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("质检项排序失败！"+ex.Message);
            }
        }

        //质检缺陷列表排序
        private void dgvCommonDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvCommonDetail.Rows)
                {
                    r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    r.HeaderCell.Value = r.Index + 1+"";
                }
                dgvCommonDetail.ClearSelection();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("质检缺陷列表排序失败！" + ex.Message);
            }
        }



        #endregion

        #region 缺陷按钮事件

        //缺陷列表增加事件
        private void btn_Detail_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (Item_Code.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2,"请选择要查看的质检项！");
                    return;
                }
                FrmQualityDetailModify fqdm = new FrmQualityDetailModify();
                fqdm.itemcode = Item_Code;
                fqdm.Flag = false;
                DialogResult r = fqdm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetCheckDetail();
                }
                fqdm.Dispose();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("缺陷列表增加事件异常！");
            }
        }

        //缺陷列表编辑事件
        private void btn_Detail_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCommonDetail.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(2, "请选择一条质检缺陷数据！");
                    return;
                }
                FrmQualityDetailModify fqdm = new FrmQualityDetailModify();
                fqdm.itemcode = Item_Code;
                fqdm.id = dgvCommonDetail.SelectedRows[0].Cells["Detail_ID"].Value.ToString();
                fqdm.detailcode = dgvCommonDetail.SelectedRows[0].Cells["Check_Item_Detail_Code"].Value.ToString();
                fqdm.cnname = dgvCommonDetail.SelectedRows[0].Cells["Check_Item_Detail_Name"].Value.ToString();
                fqdm.enname = dgvCommonDetail.SelectedRows[0].Cells["Check_Item_Detail_Name_EN"].Value.ToString();
                fqdm.Flag = true;
                DialogResult r = fqdm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetCheckDetail();
                }

                fqdm.Dispose();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("缺陷列表编辑事件异常！");
            }
        }

        //缺陷列表删除事件
        private void btn_Detail_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCommonDetail.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(2, "请选择一条质检缺陷数据！");
                    return;
                }
                string message = String.Format(@"确定删除编号为【{0}】的质检项数据吗？", dgvCommonDetail.SelectedRows[0].Cells["Check_Item_Detail_Code"].Value.ToString());
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, message) == DialogResult.No)
                {
                    return;
                }
                string SqlStr = string.Format(@"DELETE FROM [IMOS_PR_QualityItem_Detail] WHERE Check_Item_Code = '{0}' and Check_Item_Detail_Code  = '{1}'", Item_Code,
                                                    dgvCommonDetail.SelectedRows[0].Cells["Check_Item_Detail_Code"].Value.ToString());
                DataHelper.Fill(SqlStr);
                GetCheckDetail();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("缺陷列表删除事件异常！");
            }
        }

        //缺陷列表关闭窗体
        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("窗体关闭失败！");
            }
        }


        #endregion

        #region 单元格点击事件
        private void dgvCommonMaster_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCommonMaster.SelectedRows.Count == 0)
                {
                    return;
                }
                Item_Code = dgvCommonMaster.SelectedRows[0].Cells["Check_Item_Code"].Value.ToString();
                GetCheckDetail();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("查看缺陷失败！");
            }
        }
        #endregion

    }
}
