using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Monitor
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using System.Text.RegularExpressions;

    public partial class FrmPlanNumModify : Form
    {
        public string sPlanID = "";
        public string sPlanNum = "";

        public FrmPlanNumModify()
        {
            InitializeComponent();
        }

        private void FrmPlanNumModify_Load(object sender, EventArgs e)
        {
            //初始化
            tbPlanNum.Text = sPlanNum;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// 点击确认按钮保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sPlanNum = tbPlanNum.Text.Trim();

            //对数据进行检查
            if (sPlanNum.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "计划数量不可为空");
                return;
            }

            try
            {
                string sSQL = string.Format(@"UPDATE Sys_Parameters_Detail SET Remark = '{0}'
                                        WHERE Parameter_Detail_ID = {1}", sPlanNum, sPlanID);

                DataHelper.Fill(sSQL);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("计划数量数据处理异常！" + ex.Message);
            }

        }
    }

}


