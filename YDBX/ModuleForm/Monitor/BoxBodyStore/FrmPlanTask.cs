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

namespace Monitor.BoxBodyStore
{
    public partial class FrmPlanTask : Form
    {
       
        public FrmPlanTask()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPlanTask_Load(object sender, EventArgs e)
        {
            GetTask();
        }
        #region  加载任务
        private void GetTask()
        {
            try
            {
                string SqlStr = string.Format(@"  select T.ID,T.Material_Code,T.Material_Name,T.SortNum,Flag=CASE WHEN T.Flag = 0 THEN '未执行'   WHEN T.Flag = 1  THEN '取消'  WHEN T.Flag = 2  THEN '完成'
                                            ELSE ' ' END,CONVERT(varchar(100), T.Creation_Date, 120)  as Creation_Date,'取消Cancel' as Cancel  
                                           from IMOS_BA_TRK T
                                         LEFT JOIN  IMOS_LIST_OUT L ON T.LIST_ID = L.ID      where T.Company_Code = '{0}' and T.Factory_Code = '{1}' and T.Product_Line_Code = '{2}' and T.Workstation_No='{3}'  and T.IO='I'   and T.Flag <2   AND L.Flag<2   and T.Process_Code='{4}'      ORDER BY   T.Creation_Date ,T.ID",
                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.StationCode,BaseSystemInfo.CurrentProcessCode);

                DataSet ds = DataHelper.Fill(SqlStr);

                 dgvTask.DataSource = ds.Tables[0];
            }
            catch
            {

            }

        }
        #endregion

        private void dgvTask_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GetTask();
        }

        private void dgvTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTask.Columns[e.ColumnIndex].Name == "Cancel")
                {
                    int index = dgvTask.CurrentRow.Index;
                    string Id = dgvTask.CurrentRow.Cells["ID"].Value.ToString();
                    string SortNum = dgvTask.CurrentRow.Cells["SortNum"].Value.ToString();
                    string sMessage = "是否取消排序为：" + SortNum + " 的任务？";
                    if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                    {
                        return;
                    }
                    EditTask(Id);
                    GetTask();
                    //  dgvTask.Rows[index].Selected = true;//选中行

                }


            }
            catch (Exception ex) {


            }
        }

        private void EditTask(string id)
        {
            try
            {
              
                string CheckStr = string.Format(@"Update IMOS_BA_TRK Set Flag = {0}
                                                  Where ID = {1} ", "1",id );
                DataHelper.Fill(CheckStr);
            }
            catch
            {

            }
            finally
            {

            }
        }
    }
}
