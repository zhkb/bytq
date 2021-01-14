using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Param
{
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;

    public partial class FrmParamBase : Form
    {

        public FrmParamBase()
        {
            InitializeComponent();
            dgvCodeHead.TopLeftHeaderCell.Value = "序号";
            dgvCodeDetail.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmParamBase_Load(object sender, EventArgs e)
        {
            SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态
            SysBusinessFunction.ServerDBConn = DataHelper.DBServerConnection();//数据库连接状态
            SysBusinessFunction.CreateCheckDBConnection();
            GetHeadList();
            //if (dgvCodeHead.CurrentRow.Index >= 0)
            //{
            //    string sMasterCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();
            //    //加载参数内容信息
            //    GetDetailList(sMasterCode);
            //}
        }

        /// <summary>
        /// 添加参数项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Head_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmParamBaseModify BaseModifyForm = new FrmParamBaseModify();
                BaseModifyForm.bModify = false;
                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetHeadList();
                    //清空参数内容列表
                    ClearDetail();
                }

                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加参数项异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加参数项异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 维护参数项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Head_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCodeHead.CurrentRow == null || dgvCodeHead.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmParamBaseModify BaseModifyForm = new FrmParamBaseModify();
                BaseModifyForm.bModify = true;

                BaseModifyForm.sHeadID = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_ID"].Value.ToString();
                BaseModifyForm.sCodeNo = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();
                BaseModifyForm.sCodeName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Name"].Value.ToString();
                BaseModifyForm.sRemark = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Remark"].Value.ToString();

                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetHeadList();
                    //清空参数内容列表
                    // ClearDetail();
                }
                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改参数项数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改参数项数据异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 删除参数项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Head_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCodeHead.CurrentRow == null || dgvCodeHead.CurrentRow.Index == -1)
                {
                    return;
                }

                string sHeadID = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_ID"].Value.ToString();
                string sCodeNo = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();

                string sMessage = "是否删除编号为：" + sCodeNo + " 的参数项数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM dbo.Sys_Parameters_Detail 
                                              where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' and Parameter_Master_Code = '{3}'",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sCodeNo);
                DataHelper.Fill(SqlStr);

                SqlStr = string.Format(@"DELETE FROM dbo.Sys_Parameters_Master 
                                         where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' and  Parameter_Master_Code = '{3}'",
                                         BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sCodeNo);
                DataHelper.Fill(SqlStr);

                GetHeadList();
                //清空参数内容列表
                ClearDetail();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("参数项信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数项信息删除失败.请检查数据库连接状态.");
            }
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
        /// 获取参数项列表数据
        /// </summary>
        private void GetHeadList()
        {
            #region 查询数据
            string SqlStr = string.Format(@"select a.Parameter_Master_ID, a.Parameter_Master_Code, a.Parameter_Master_Name, a.Remark,
                                            Convert(varchar(20),a.Creation_Date,120)Creation_Date, b.User_Name Create_User_Name, 
                                            Convert(varchar(20),a.Last_Update_Date,120)Last_Update_Date, c.User_Name Edit_User_Name
                                            from Sys_Parameters_Master a left join Sys_BaseUser b on (a.Company_Code = b.Company_Code and a.Factory_Code = b.Factory_Code and a.product_line_code = b.Product_Line_Code and  a.Created_By = b.User_ID)
                                            left join Sys_BaseUser c on (a.Company_Code = c.Company_Code and a.Factory_Code = c.Factory_Code and a.product_line_code = c.Product_Line_Code and  a.Last_Updated_By = c.User_ID)
                                            where a.Company_Code='{0}'and a.Factory_Code='{1}' and a.product_line_code='{2}'
                                            ORDER BY Last_Update_Date desc,a.Parameter_Master_Code", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

            DataSet ds = DataHelper.Fill(SqlStr);

            dgvCodeHead.DataSource = ds.Tables[0];

            dgvCodeHead.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvCodeHead.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            #endregion
        }

        /// <summary>
        /// 选中参数项获取相应的参数内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCodeHead_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string sMasterCode = dgvCodeHead.Rows[e.RowIndex].Cells["Parameter_Master_Code"].Value.ToString();
            //加载参数内容信息
            GetDetailList(sMasterCode);
        }

        /// <summary>
        /// 获取参数内容列表数据
        /// </summary>
        private void GetDetailList(string sCodeNo)
        {
            #region 查询数据
            string SqlStr = string.Format(@"select a.Parameter_Detail_ID, a.Parameter_Detail_Code, a.Parameter_Detail_Name, a.Remark,
                                          Convert(varchar(20),a.Creation_Date,120)Creation_Date, b.User_Name Create_User_Name, 
                                          Convert(varchar(20),a.Last_Update_Date,120)Last_Update_Date, c.User_Name Edit_User_Name
                                          from Sys_Parameters_Detail a left join Sys_BaseUser b on (a.Company_Code = b.Company_Code and a.Factory_Code = b.Factory_Code and a.product_line_code = b.Product_Line_Code and  a.Created_By = b.User_ID)
                                          left join Sys_BaseUser c on (a.Company_Code = c.Company_Code and a.Factory_Code = c.Factory_Code and a.product_line_code = c.Product_Line_Code and  a.Last_Updated_By = c.User_ID)
                                          where a.Company_Code='{0}'and a.Factory_Code='{1}' and a.product_line_code='{2}' and Parameter_Master_Code='{3}'
                                          ORDER BY a.Parameter_Master_Code", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sCodeNo);

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
        /// 新增参数内容信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Detail_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmParamBaseDetailModify BaseDetailModifyForm = new FrmParamBaseDetailModify();
                BaseDetailModifyForm.sMasterCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();
                BaseDetailModifyForm.sMasterName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Name"].Value.ToString();
                BaseDetailModifyForm.bModify = false;
                DialogResult r = BaseDetailModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    string sMasterCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();
                    GetDetailList(sMasterCode);
                }

                BaseDetailModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加参数内容异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "添加参数内容异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 修改参数内容信息
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

                FrmParamBaseDetailModify BaseModifyForm = new FrmParamBaseDetailModify();
                BaseModifyForm.bModify = true;

                BaseModifyForm.sDetailID = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Parameter_Detail_ID"].Value.ToString();
                BaseModifyForm.sMasterCode = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();
                BaseModifyForm.sMasterName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Name"].Value.ToString();
                BaseModifyForm.sDetailCode = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Parameter_Detail_Code"].Value.ToString();
                BaseModifyForm.sDetailName = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Parameter_Detail_Name"].Value.ToString();
                BaseModifyForm.sRemark = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Detail_Remark"].Value.ToString();

                DialogResult r = BaseModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    string sMasterName = dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString();
                    GetDetailList(sMasterName);
                }
                BaseModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改参数内容数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改参数内容数据异常！，请检查数据库连接.");
            }
        }

        /// <summary>
        /// 删除参数内容信息
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

                string sDetailID = dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Parameter_Detail_ID"].Value.ToString();

                string sMessage = "是否删除参数项：" + dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString() + "的编号为："
                    + dgvCodeDetail.Rows[dgvCodeDetail.CurrentRow.Index].Cells["Parameter_Detail_Code"].Value.ToString() + " 的参数内容数据？";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                string SqlStr = string.Format(@"DELETE FROM dbo.Sys_Parameters_Detail WHERE Parameter_Detail_ID = {0}", sDetailID);
                DataHelper.Fill(SqlStr);

                GetDetailList(dgvCodeHead.Rows[dgvCodeHead.CurrentRow.Index].Cells["Parameter_Master_Code"].Value.ToString());
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("参数内容信息删除失败." + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数内容信息删除失败.请检查数据库连接状态.");
            }
        }

        /// <summary>
        /// 清空参数内容列表
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
