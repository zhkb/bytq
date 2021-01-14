using Sys.Config;
using Sys.DbUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PickingMonitor
{
    public partial class FrmTaskMonitor : Form
    {
        public FrmTaskMonitor()
        {
            InitializeComponent();
            dgvInStoreTask.TopLeftHeaderCell.Value = "序号";
            dgvOutStoreTask.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmTaskMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Interval = 3000;
                timer1.Start();
            }catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                getData("I");
                getData("O");
                
            }
            catch(Exception ex)
            {

            }
        }
        private void getData(String strtype)
        {
            String sql = String.Format(@"SELECT
	                                            MATERIAL_CODE,
	                                            MATERIAL_NAME,
	                                            TASK_FROM,
	                                            TASK_END,
	                                            (
		                                            CASE TASK_STATE
		                                            WHEN '0' THEN
			                                            '未执行'
		                                            WHEN '1' THEN
			                                            '执行中'
		                                            WHEN '2' THEN
			                                            '入库完成'
		                                            WHEN '3' THEN
			                                            '任务结束'
		                                            ELSE
			                                            '强制结束'
		                                            END
	                                            ) TASK_STATE,
                                                TO_CHAR(START_TIME,'yyyy-MM-dd hh24:mm:ss') START_TIME                                  
                                            FROM
	                                            IMOS_LO_TEMPORARY_TASK
                                            WHERE
	                                            (AUTO_FLAG = '{0}' OR DEVICE_CODE='{1}')
                                            AND TASK_TYPE = '{2}'
                                            ORDER BY 
                                                  START_TIME  DESC", "2", BaseSystemInfo.Device_Code,strtype);
            DataSet ds = DataHelper.Fill(sql);
            if (ds != null)
            {
                if("I" == strtype)
                {
                    dgvInStoreTask.DataSource = ds.Tables[0];

                }
                else
                {
                    dgvOutStoreTask.DataSource = ds.Tables[0];
                }
            }
        }

        private void dgvInStoreTask_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
                if (e.Row.Index >= 0)
                {
                    if ("未执行" == e.Row.Cells["TASK_STATE"].Value.ToString())
                    {
                        e.Row.Cells["TASK_STATE"].Style.ForeColor = Color.DarkOrange;
                    }
                    else if ("执行中" == e.Row.Cells["TASK_STATE"].Value.ToString())
                    {
                        e.Row.Cells["TASK_STATE"].Style.ForeColor = Color.Lime;
                    }
                    else if ("强制结束" == e.Row.Cells["TASK_STATE"].Value.ToString())
                    {
                        e.Row.Cells["TASK_STATE"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Row.Cells["TASK_STATE"].Style.ForeColor = Color.DimGray;
                    }
                }
               
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvOutStoreTask_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
                if (e.Row.Index >= 0)
                {
                    if ("未执行" == e.Row.Cells["TASK_STATE2"].Value.ToString())
                    {
                        e.Row.Cells["TASK_STATE2"].Style.ForeColor = Color.DarkOrange;
                    }
                    else if ("执行中" == e.Row.Cells["TASK_STATE2"].Value.ToString())
                    {
                        e.Row.Cells["TASK_STATE2"].Style.ForeColor = Color.Lime;
                    }
                    else if ("强制结束" == e.Row.Cells["TASK_STATE2"].Value.ToString())
                    {
                        e.Row.Cells["TASK_STATE2"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Row.Cells["TASK_STATE2"].Style.ForeColor = Color.DimGray;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInStoreTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
