using Authority;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Quality
{
    public partial class FrmQualityItem : Form
    {

        public FrmQualityItem()
        {
            InitializeComponent();
            dgvCodeHead.TopLeftHeaderCell.Value = "序号";
            dgvCodeDetail.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmQualityItem_Load(object sender, EventArgs e)
        {
            AuthorityInfo FAuthorityInfo = AuthorityManager.GetAuthority(BaseSystemInfo.CurrentUserID, this.Tag.ToString());

            btn_Item_Add.Enabled = FAuthorityInfo.AddFlag;
            btn_Deatil_Add.Enabled = FAuthorityInfo.AddFlag;
            btn_Item_Edit.Enabled = FAuthorityInfo.EditFlag;
            btn_Detail_Edit.Enabled = FAuthorityInfo.EditFlag;
            btn_Item_Del.Enabled = FAuthorityInfo.DeleteFlag;
            btn_Detail_Del.Enabled = FAuthorityInfo.DeleteFlag;

            GetItemList();
            if (dgvCodeHead.RowCount > 0)
            {
                string sQualityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                //加载质检内容信息
                GetDetailList(sQualityCode);
            }
        }

        /// <summary>
        /// 添加质检项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Item_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQualityItemModify BaseModifyForm = new FrmQualityItemModify();
                BaseModifyForm.bModify = false;
                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetItemList();
                    //清空质检内容列表
                    ClearDetail();
                    if (dgvCodeHead.RowCount > 0)
                    {
                        string sQualityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                        //加载质检内容信息
                        GetDetailList(sQualityCode);
                    }
                }

                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加质检项异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加质检项异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 维护质检项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Item_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCodeHead.CurrentRow == null || dgvCodeHead.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmQualityItemModify BaseModifyForm = new FrmQualityItemModify();
                BaseModifyForm.bModify = true;

                BaseModifyForm.sItemID = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Item_ID"].Value.ToString();
                BaseModifyForm.sItemCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                BaseModifyForm.sItemName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemName"].Value.ToString();
                BaseModifyForm.sRemark = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Remark"].Value.ToString();

                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetItemList();
                    //清空质检内容列表
                    ClearDetail();
                    if (dgvCodeHead.RowCount > 0)
                    {
                        string sQualityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                        //加载质检内容信息
                        GetDetailList(sQualityCode);
                    }
                }
                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改质检项数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改质检项数据异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 删除质检项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Item_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCodeHead.CurrentRow == null || dgvCodeHead.CurrentRow.Index == -1)
                {
                    return;
                }
                
                string sItemCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();

                string sMessage = "是否删除编号为：" + sItemCode + " 的质检项数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM dbo.IMOS_QA_Quaility_Detail 
                                              where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' and Quality_ItemCode = '{3}'",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sItemCode);
                DataHelper.Fill(SqlStr);

                SqlStr = string.Format(@"DELETE FROM dbo.IMOS_QA_Quaility_Item 
                                         where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' and  Quality_ItemCode = {3}",
                                         BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sItemCode);
                DataHelper.Fill(SqlStr);

                GetItemList();
                //清空质检内容列表
                ClearDetail();
                if (dgvCodeHead.RowCount > 0)
                {
                    string sQualityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                    //加载质检内容信息
                    GetDetailList(sQualityCode);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("质检项信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检项信息删除失败.请检查数据库连接状态.");
            }
        }



        private void btn_Item_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 获取质检项列表数据
        /// </summary>
        private void GetItemList()
        {
            #region 查询数据
            string SqlStr = string.Format(@"SELECT A.Item_ID, A.Quality_ItemCode, A.Quality_ItemName, A.Remark, 
	                                            CONVERT(VARCHAR(20), A.Creation_Date, 120) AS Creation_Date, B.User_Name AS Create_User_Name, 
	                                            CONVERT(VARCHAR(20), A.Last_Update_Date, 120) AS Last_Update_Date, C.User_Name AS Edit_User_Name 
                                            FROM dbo.IMOS_QA_Quaility_Item AS A
	                                            LEFT JOIN dbo.Sys_BaseUser AS B ON (A.Company_Code = B.Company_Code AND A.Factory_Code = B.Factory_Code AND A.Product_Line_Code = B.Product_Line_Code AND A.Created_By = B.User_ID)
	                                            LEFT JOIN dbo.Sys_BaseUser AS C ON (A.Company_Code = C.Company_Code AND A.Factory_Code = C.Factory_Code AND A.Product_Line_Code = C.Product_Line_Code AND A.Last_Updated_By = C.User_ID)
                                            WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' 
                                            ORDER BY A.Quality_ItemCode", 
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

            DataSet ds = DataHelper.Fill(SqlStr);

            dgvCodeHead.DataSource = ds.Tables[0];

            dgvCodeHead.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvCodeHead.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            #endregion
        }

        /// <summary>
        /// 选中质检项获取相应的质检内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCodeHead_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string sQualityCode = dgvCodeHead.Rows[e.RowIndex].Cells["Quality_ItemCode"].Value.ToString();
            //加载质检内容信息
            GetDetailList(sQualityCode);
        }

        /// <summary>
        /// 获取质检内容列表数据
        /// </summary>
        private void GetDetailList(string sItemCode)
        {
            #region 查询数据
            string SqlStr = string.Format(@"SELECT A.Quality_DetailID, A.Quality_DetailCode, A.Quality_DetailName, A.Quaility_Standard, 
	                                            CONVERT(VARCHAR(20), A.Creation_Date, 120) AS Creation_Date, B.User_Name AS Create_User_Name, 
	                                            CONVERT(VARCHAR(20), A.Last_Update_Date, 120) AS Last_Update_Date, C.User_Name AS Edit_User_Name 
                                            FROM dbo.IMOS_QA_Quaility_Detail AS A 
	                                            LEFT JOIN dbo.Sys_BaseUser AS B ON (A.Company_Code = B.Company_Code AND A.Factory_Code = B.Factory_Code AND A.Product_Line_Code = B.Product_Line_Code AND A.Created_By = B.User_ID)
	                                            LEFT JOIN dbo.Sys_BaseUser AS C ON (A.Company_Code = C.Company_Code AND A.Factory_Code = C.Factory_Code AND A.Product_Line_Code = C.Product_Line_Code AND A.Last_Updated_By = C.User_ID)
                                            WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Quality_ItemCode = '{3}' 
                                            ORDER BY A.Quality_DetailCode", 
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sItemCode);

            DataSet ds = DataHelper.Fill(SqlStr);

            dgvCodeDetail.DataSource = ds.Tables[0];

            dgvCodeDetail.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvCodeDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            #endregion
        }

        private void dgvHead_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgvDetail_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 新增质检内容信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Detail_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQualityDetailModify DetailModifyForm = new FrmQualityDetailModify();
                DetailModifyForm.sQuailityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                DetailModifyForm.sQuailityName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemName"].Value.ToString();
                DetailModifyForm.bModify = false;
                DialogResult r = DetailModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    string sQuailityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                    GetDetailList(sQuailityCode);
                }

                DetailModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加质检内容异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加质检内容异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 修改质检内容信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Detail_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCodeDetail.CurrentRow == null || dgvCodeDetail.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmQualityDetailModify DetailModifyForm = new FrmQualityDetailModify();
                DetailModifyForm.bModify = true;

                DetailModifyForm.sDetailID = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Quality_DetailID"].Value.ToString();
                DetailModifyForm.sQuailityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                DetailModifyForm.sQuailityName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemName"].Value.ToString();
                DetailModifyForm.sDetailCode = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Quality_DetailCode"].Value.ToString();
                DetailModifyForm.sDetailName = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Quality_DetailName"].Value.ToString();
                DetailModifyForm.sStandard = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Quaility_Standard"].Value.ToString();

                DialogResult r = DetailModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    string sQuailityCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString();
                    GetDetailList(sQuailityCode);
                }
                DetailModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改质检内容数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改质检内容数据异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 删除质检内容信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Detail_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCodeDetail.CurrentRow == null || dgvCodeDetail.CurrentRow.Index == -1)
                {
                    return;
                }

                string sDetailID = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Quality_DetailID"].Value.ToString();

                string sMessage = "是否删除质检项：" + dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString() + "的编号为："
                    + dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Quality_DetailCode"].Value.ToString() + " 的质检内容数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM dbo.IMOS_QA_Quaility_Detail WHERE Quality_DetailID = {0}", sDetailID);
                DataHelper.Fill(SqlStr);

                GetDetailList(dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Quality_ItemCode"].Value.ToString());
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("质检内容信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检内容信息删除失败.请检查数据库连接状态.");
            }
        }

        /// <summary>
        /// 清空质检内容列表
        /// </summary>
        public void ClearDetail()
        {
            DataTable dt = (DataTable)dgvCodeDetail.DataSource;
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Clear();
            }
        }
    }
}
