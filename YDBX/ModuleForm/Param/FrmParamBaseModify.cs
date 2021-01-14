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

    public partial class FrmParamBaseModify : Form
    {
        public string sHeadID = "";
        public string sCodeNo = "";
        public string sCodeName = "";
        public string sRemark = "";

        public bool bModify = false;

        public FrmParamBaseModify()
        {
            InitializeComponent();
        }

        private void FrmParamBase_Load(object sender, EventArgs e)
        {
            //初始化
            tbCodeNo.Text = sCodeNo;
            tbCodeName.Text = sCodeName;
            tbRemark.Text = sRemark;

            if (bModify)
            {
                tbCodeNo.Enabled = false;
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
            sCodeNo = tbCodeNo.Text.Trim();
            sCodeName = tbCodeName.Text.Trim();
            sRemark = tbRemark.Text.Trim();

            //对数据进行检查

            if (sCodeNo.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数项编号不可为空");
                return;
            }

            if (sCodeName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数项名称不可为空");
                return;
            }

            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select * from Sys_Parameters_Master 
                                                   where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' 
                                                   and (Parameter_Master_Code = '{3}' or Parameter_Master_Name = '{4}')", 
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,sCodeNo, sCodeName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数项编号或参数项名称重复");
                    return;
                }
            }
            //更新记录 名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select * from Sys_Parameters_Master 
                                                   where Company_Code='{0}'and Factory_Code='{1}' and product_line_code='{2}' 
                                                   and  Parameter_Master_Name = '{4}' and Parameter_Master_ID != '{5}'",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sCodeNo, sCodeName,sCodeNo, sCodeName, sHeadID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数项名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO dbo.Sys_Parameters_Master (Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name, Parameter_Master_Code, 
                                                    Parameter_Master_Name, Remark, Creation_Date, Created_By, Last_Update_Date, Last_Updated_By) 
                                                    select '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE(),'{9}',GETDATE(),'{10}'",
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,
                                                    sCodeNo, sCodeName, sRemark, BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE dbo.Sys_Parameters_Master 
                                                    SET Parameter_Master_Name = '{0}',Remark = '{1}',
	                                                    Last_Updated_By = '{2}',
	                                                    Last_Update_Date = GETDATE()
                                                    WHERE Parameter_Master_ID = {3}", sCodeName, sRemark, BaseSystemInfo.CurrentUserID, sHeadID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("参数项数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "参数项数据处理异常！.");
            }

        }
    }
    public class GroupInfo
    {
        private string sGroupName;
        private string sGroupID;

        public GroupInfo(string sName, string sID)
        {
            this.sGroupID = sID;
            this.sGroupName = sName;
        }

        public string ID
        {
            get
            {
                return sGroupID;
            }
        }

        public string Name
        {

            get
            {
                return sGroupName;
            }
        }

    }

}


