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

namespace Param
{

    public partial class FrmAlarm : Form
    {
        public int ParamaterType = 0; //参数类型
        private DataSet MasterDataSet4MaterialType = new DataSet();
        private DataSet ParamDataSet = new DataSet();

        public FrmAlarm()
        {
            InitializeComponent();

        }
        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void GetParamData()
        {
            try
            {
                string SqlMask = string.Format(@"SELECT ID,Equipment_Code,Equipment_Name,Alarm_Desc,Remark
                                   FROM Sys_Alarm 
                                   Order By ID");

                ParamDataSet = DataHelper.Fill(SqlMask);
                dgvAction.DataSource = ParamDataSet.Tables[0];
                dgvAction.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvAction.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("查询报警数据失败，" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询报警数据失败，请检查数据库连接.");
            }

        }

        private void FrmParam_Load(object sender, EventArgs e)
        {
            dgvAction.TopLeftHeaderCell.Value = "序号";
            GetParamData();
        }

        private void btn_Edit4Action_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAction.CurrentRow == null || dgvAction.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmAlarmModify ParamForm = new FrmAlarmModify();
                ParamForm.bModify = true;
//                ParamForm.paramType = ParamType.Action;

                ParamForm.sPID = dgvAction.Rows[dgvAction.CurrentRow.Index].Cells["ID"].Value.ToString();
                ParamForm.sPName = dgvAction.Rows[dgvAction.CurrentRow.Index].Cells["Alarm_Desc"].Value.ToString();
                ParamForm.sDesc = dgvAction.Rows[dgvAction.CurrentRow.Index].Cells["Remark"].Value.ToString();

                ParamForm.sECode = dgvAction.Rows[dgvAction.CurrentRow.Index].Cells["Equipment_Code"].Value.ToString();
                ParamForm.sEName = dgvAction.Rows[dgvAction.CurrentRow.Index].Cells["Equipment_Name"].Value.ToString();

                DialogResult r = ParamForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetParamData();
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警信息修改成功！");
                }
                ParamForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("报警信息修改异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警信息修改异常！，请检查数据库连接.");
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
