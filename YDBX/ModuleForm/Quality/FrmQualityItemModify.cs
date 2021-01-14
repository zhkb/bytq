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

    public partial class FrmQualityItemModify : Form
    {
        public string sItemID = "";
        public string sItemCode = "";
        public string sItemName = "";
        public string sRemark = "";

        public bool bModify = false;

        public FrmQualityItemModify()
        {
            InitializeComponent();
        }

        private void FrmParamBase_Load(object sender, EventArgs e)
        {
            //初始化
            tbItemCode.Text = sItemCode;
            tbItemName.Text = sItemName;
            tbRemark.Text = sRemark;

            if (bModify)
            {
                tbItemCode.Enabled = false;
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
            sItemCode = tbItemCode.Text.Trim();
            sItemName = tbItemName.Text.Trim();
            sRemark = tbRemark.Text.Trim();

            //对数据进行检查

            if (sItemCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检项编号不可为空");
                return;
            }

            if (sItemName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检项名称不可为空");
                return;
            }

            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"SELECT * FROM IMOS_QA_Quaility_Item 
                                                   WHERE Company_Code = '{0}' AND Factory_Code = '{1}' AND Product_Line_Code = '{2}' 
                                                       AND (Quality_ItemCode = '{3}' OR Quality_ItemName = '{4}')", 
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,sItemCode, sItemName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检项编号或质检项名称重复");
                    return;
                }
            }
            //更新记录 名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"SELECT * FROM IMOS_QA_Quaility_Item 
                                                   WHERE Company_Code = '{0}' AND Factory_Code = '{1}' AND Product_Line_Code = '{2}' 
                                                        AND Quality_ItemName = '{4}' AND Item_ID != {5}",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sItemCode, sItemName, sItemID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检项名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO dbo.IMOS_QA_Quaility_Item (Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name, Quality_ItemCode, 
                                                    Quality_ItemName, Remark, Creation_Date, Created_By, Last_Update_Date, Last_Updated_By) 
                                                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE(),{9},GETDATE(),{9})",
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, 
                                                    BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, 
                                                    BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,
                                                    sItemCode, sItemName, sRemark, BaseSystemInfo.CurrentUserID);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE dbo.IMOS_QA_Quaility_Item 
                                                    SET Quality_ItemName = '{0}',Remark = '{1}',
	                                                    Last_Updated_By = '{2}',
	                                                    Last_Update_Date = GETDATE()
                                                    WHERE Item_ID = {3}", sItemName, sRemark, BaseSystemInfo.CurrentUserID, sItemID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("质检项数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "质检项数据处理异常！.");
            }

        }
    }

}


