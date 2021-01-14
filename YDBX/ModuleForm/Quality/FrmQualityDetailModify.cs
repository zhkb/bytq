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


namespace Quality
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using System.Text.RegularExpressions;

    public partial class FrmQualityDetailModify : Form
    {
        public string sDetailID = "";
        public string sQuailityCode = "";
        public string sQuailityName = "";
        public string sDetailCode = "";
        public string sDetailName = "";
        public string sStandard = "";

        public bool bModify = false;

        public FrmQualityDetailModify()
        {
            InitializeComponent();
        }

        private void FrmQualityDetailModify_Load(object sender, EventArgs e)
        {
            //初始化
            tbDetailCode.Text = sDetailCode;
            tbDetailName.Text = sDetailName;
            tbStandard.Text = sStandard;

            if (bModify)
            {
                tbDetailCode.Enabled = false;
            }
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
            sDetailCode = tbDetailCode.Text.Trim();
            sDetailName = tbDetailName.Text.Trim();
            sStandard = tbStandard.Text.Trim();

            //对数据进行检查
            if (sDetailCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检内容编号不可为空");
                return;
            }

            if (sDetailName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检内容名称不可为空");
                return;
            }

            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"SELECT Quality_DetailID FROM IMOS_QA_Quaility_Detail 
                                                   WHERE (Quality_DetailCode = '{0}' OR Quality_DetailName = '{1}') AND Quality_ItemCode = '{2}'", sDetailCode, sDetailName, sQuailityCode);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检内容编号或质检内容名称重复");
                    return;
                }
            }
            //更新记录 名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"SELECT Quality_DetailID FROM IMOS_QA_Quaility_Detail 
                                                   WHERE Quality_ItemCode = '{0}' AND Quality_DetailName = '{1}' AND Quality_DetailID != {2}", sQuailityCode, sDetailName, sDetailID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检内容名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO dbo.IMOS_QA_Quaility_Detail (Company_Code,
											Company_Name, 
											Factory_Code, 
											Factory_Name, 
											Product_Line_Code, 
											Product_Line_Name, 
											Quality_ItemCode, 
											Quality_ItemName, 
											Quality_DetailCode, 
											Quality_DetailName, 
											Quaility_Standard, 
											Creation_Date, 
											Created_By, 
											Last_Update_Date, 
											Last_Updated_By) VALUES ('{0}', 
											'{1}', 
											'{2}', 
											'{3}', 
											'{4}', 
											'{5}', 
											'{6}', 
											'{7}', 
											'{8}', 
											'{9}', 
											'{10}', 
											GETDATE(), 
											{11}, 
											GETDATE(), 
											{11})", BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, 
                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, 
                                            BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, 
                                            sQuailityCode, sQuailityName, sDetailCode, sDetailName, sStandard, BaseSystemInfo.CurrentUserID);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE dbo.IMOS_QA_Quaility_Detail SET Quality_DetailName = '{0}',
	                                                    Quaility_Standard = '{1}',
	                                                    Last_Updated_By = {2},
	                                                    Last_Update_Date = GETDATE()
                                                    WHERE Quality_DetailID = {3}", sDetailName, sStandard, BaseSystemInfo.CurrentUserID, sDetailID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("质检内容数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检内容数据处理异常！.");
            }

        }
    }

}


