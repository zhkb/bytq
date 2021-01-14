using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Option
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using Sys.Config;
    

    public partial class FrmOptionModify : Form
    {
        public  string strCode ="";   //选项编码
        public  string strName="";    //选项名称
        public  string  strValue="";      //数值
        public  string strMark="";    //备注

        public int strId =0;

        public string oldStrCode = "";
        public string oldStrName = "";

        public  bool ModifyState = false;  //标志位，判断是添加,修改
        public FrmOptionModify()
        {
            InitializeComponent();
        }

        /*增加*/
        public void addOption(string code, string name, string Value, string mark)
        {
            DataSet DBDataSet = new DataSet();
            string SelectSql = string.Format(@"select * from Sys_Option 
                                                       where Option_Code = '{0}' and  Company_Code='{1}'and 
                                             Factory_Code='{2}' and ProductLine_Code='{3}'", code, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
            DBDataSet = DataHelper.Fill(SelectSql);
            if (DBDataSet.Tables[0].Rows.Count > 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项编号不能重复.");
                return;
            }

            string SelectSql2 = string.Format(@"select * from Sys_Option 
                                                       where Option_Name = '{0}' and  Company_Code='{1}'and 
                                             Factory_Code='{2}' and ProductLine_Code='{3}'",name, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
            DBDataSet = DataHelper.Fill(SelectSql2);
            if (DBDataSet.Tables[0].Rows.Count > 0)
            {
                 SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项名称不能重复.");
                return;
            }
            else
            {
                try
                {
                    string SqlStr = string.Format(@"insert into Sys_Option(Company_Code,Company_Name,Factory_Code,Factory_Name,ProductLine_Code,ProductLine_Name,
                                                            Option_Code,Option_Name,Option_Value,Remark)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", BaseSystemInfo.CompanyCode,
                                                        BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                                        BaseSystemInfo.ProductLineName, code, name, Value, mark);
                    DataHelper.Fill(SqlStr);
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "增加选项信息成功.");
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("增加选项信息异常！" + ex.Message);
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 /*&& m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012*/)
            {
                base.WndProc(ref m);
            }
        }
        private void FrmOptionModify_Load(object sender, EventArgs e)
        {
            if (!ModifyState) 
            {
                Loptnumber.Text = strCode;
                Loptname.Text = strName;
                LoptValue.Text = strValue.ToString();
                LoptMark.Text = strMark;
                oldStrCode = strCode;
                oldStrName = strName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            strCode = Loptnumber.Text;
            strName = Loptname.Text;
            strValue = LoptValue.Text;
            strMark = LoptMark.Text;

            //如果是新增
            if (ModifyState)
            {
                
                if (strCode.Trim()=="")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项编号设置不能为空.");
                    return;
                }
                if (strName.Trim()=="")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项名称设置不能为空.");
                    return;
                }

                addOption(strCode, strName, strValue, strMark);

            }
            else  //修改状态
            {
     
                DataSet DBDataSet = new DataSet();
                string SelectSqlname = string.Format(@"select * from Sys_Option 
                                                       where Option_ID <>'{0}' and Option_Name='{1}' and Company_Code='{2}' and  Factory_Code='{3}' and ProductLine_Code ='{4}'", strId, strName, 
                                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlname); 
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项名称不能重复.");
                    Loptname.Text = oldStrName;
                    return;
                }


                string SelectSqlcode = string.Format(@"select * from Sys_Option 
                                                       where Option_ID <>'{0}' and Option_Code='{1}' and Company_Code='{2}' and Factory_Code='{3}' and  ProductLine_Code='{4}'", strId, strCode,
                                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SelectSqlcode);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项编码不能重复.");
                    Loptnumber.Text = oldStrCode;
                    return;
                }
                else
                {
                    if (Loptnumber.Text.Trim() == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项编号设置不能为空.");
                        return;
                    }
                    if (Loptname.Text.Trim()== "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选项名称设置不能为空.");
                        return;
                    }

                    try
                    {
                        string SqlStr = string.Format(@"Update Sys_Option Set Option_Code = '{0}',Option_Name = '{1}',Option_Value='{2}',Remark='{3}'
                                                        Where Option_ID={4}", strCode, strName, strValue, strMark, strId);
                        DataHelper.Fill(SqlStr);
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改选项信息成功.");
                    }
                    catch (Exception ex)
                    {
                        SysBusinessFunction.WriteLog("修改选项信息异常！" + ex.Message);
                    }
                }

            }
            DialogResult = DialogResult.OK;


        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
