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

namespace Monitor
{
    public partial class FrmProductionMonitor : Form
    {
        public FrmProductionMonitor()
        {
            InitializeComponent();
        }

        #region  初始化加载界面
        private void FrmProductionMonitor_Load(object sender, EventArgs e)
        {
            //获取数据库数据
            GetData();
            RefreshData();//刷新数据
        }

        #endregion

        #region  获取数据库数据

        private void GetData()
        {
            try
            {
                //String sql = String.Format(@"SELECT FROM IMOS_TA_  ");

            }catch(Exception ex)
            {

            }
        }

        #endregion

        #region 刷新界面的数据
        private void RefreshData()
        {
            try
            {
                //刷新当班完成率
                int Plan_Class = int.Parse(lbl_Plan_Class.Text.ToString());
                int Complete_Class = int.Parse(lbl_Complete_Class.Text.ToString());
                lbl_FillRate_Class.Text = (((double)Complete_Class / (double)Plan_Class) * 100).ToString("#0.0") + "%";
                //刷新当天完成率
                int Plan_Day = int.Parse(lbl_Plan_Day.Text.ToString());
                int Complete_Day = int.Parse(lbl_Complete_Day.Text.ToString());
                lbl_FillRate_Day.Text = (((double)Complete_Day / (double)Plan_Day) * 100).ToString("#0.0") + "%";
                //刷新当周完成率
                int Plan_Week = int.Parse(lbl_Plan_Week.Text.ToString());
                int Complete_Week = int.Parse(lbl_Complete_Week.Text.ToString());
                lbl_FillRate_Week.Text = (((double)Complete_Week / (double)Plan_Week) * 100).ToString("#0.0") + "%";
                //刷新当月完成率
                int Plan_Month = int.Parse(lbl_Plan_Month.Text.ToString());
                int Complete_Month = int.Parse(lbl_Complete_Month.Text.ToString());
                lbl_FillRate_Month.Text = (((double)Complete_Month / (double)Plan_Month) * 100).ToString("#0.0") + "%";
                //刷新捡漏1不良率
                int Ins_Qty_LH1 = int.Parse(lbl_InsQty_LH1.Text.ToString());
                int Qua_Qty_LH1 = int.Parse(lbl_QuaQty_LH1.Text.ToString());
                int No_Qua_Qty_LH1 = Ins_Qty_LH1 - Qua_Qty_LH1;
                lbl_RR_LH1.Text = (((double)No_Qua_Qty_LH1 / (double)Ins_Qty_LH1) * 100).ToString("#0.0") + "%";
                //刷新捡漏2不良率
                int Ins_Qty_LH2 = int.Parse(lbl_InsQty_LH2.Text.ToString());
                int Qua_Qty_LH2 = int.Parse(lbl_QuaQty_LH2.Text.ToString());
                int No_Qua_Qty_LH2 = Ins_Qty_LH2 - Qua_Qty_LH2;
                lbl_RR_LH2.Text = (((double)No_Qua_Qty_LH2 / (double)Ins_Qty_LH2) * 100).ToString("#0.0") + "%";
                //刷新安检不良率
                int Ins_Qty_SC = int.Parse(lbl_InsQty_SC.Text.ToString());
                int Qua_Qty_SC = int.Parse(lbl_QuaQty_SC.Text.ToString());
                int No_Qua_Qty_SC = Ins_Qty_SC - Qua_Qty_SC;
                lbl_RR_SC.Text = (((double)No_Qua_Qty_SC / (double)Ins_Qty_SC) * 100).ToString("#0.0") + "%";
            }
            catch
            {
                SysBusinessFunction.WriteLog("刷新界面数据失败！");
            }
        }

        #endregion
    }
}
