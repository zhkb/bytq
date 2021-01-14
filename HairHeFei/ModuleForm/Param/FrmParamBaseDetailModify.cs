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


namespace Param
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using System.Text.RegularExpressions;

    public partial class FrmParamBaseDetailModify : Form
    {
        public string sDetailID = "";
        public string sMasterCode = "";
        public string sMasterName = "";
        public string sDetailCode = "";
        public string sDetailName = "";
        public string sRemark = "";

        public bool bModify = false;

        public FrmParamBaseDetailModify()
        {
            InitializeComponent();
        }

        private void FrmParamBaseDetailModify_Load(object sender, EventArgs e)
        {
            //初始化
            tbDetailCode.Text = sDetailCode;
            tbDetailName.Text = sDetailName;
            tbRemark.Text = sRemark;

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
            sRemark = tbRemark.Text.Trim();

            //对数据进行检查
            if (sDetailCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数内容编号不可为空");
                return;
            }

            if (sDetailName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数内容名称不可为空");
                return;
            }

            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Parameter_Detail_ID from Sys_Parameters_Detail 
                                                   where (Parameter_Detail_Code = '{0}' or Parameter_Detail_Name = '{1}') AND Parameter_Master_Code = '{2}'", sDetailCode, sDetailName, sMasterCode);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数内容编号或参数内容名称重复");
                    return;
                }
            }
            //更新记录 名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Parameter_Detail_ID from Sys_Parameters_Detail 
                                                   where Parameter_Detail_Name = '{0}' AND Parameter_Master_Code = '{1}' AND Parameter_Detail_ID != {2}", sDetailName, sMasterCode, sDetailID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数内容名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO dbo.Sys_Parameters_Detail (Company_Code,
											Company_Name, 
											Factory_Code, 
											Factory_Name, 
											Product_Line_Code, 
											Product_Line_Name, 
											Parameter_Master_Code, 
											Parameter_Master_Name, 
											Parameter_Detail_Code, 
											Parameter_Detail_Name, 
											Remark, 
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
                                            sMasterCode, sMasterName, sDetailCode, sDetailName, sRemark, BaseSystemInfo.CurrentUserID);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE dbo.Sys_Parameters_Detail SET Parameter_Detail_Name = '{0}',
	                                                    Remark = '{1}',
	                                                    Last_Updated_By = {2},
	                                                    Last_Update_Date = GETDATE()
                                                    WHERE Parameter_Detail_ID = {3}", sDetailName, sRemark, BaseSystemInfo.CurrentUserID, sDetailID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("参数内容数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数内容数据处理异常！.");
            }

        }
    }

}


