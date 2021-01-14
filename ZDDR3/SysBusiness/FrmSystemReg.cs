using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.SysBusiness
{
    using Sys.Utilities;
    using Sys.DbUtilities;
    using Sys.Config;

    public partial class FrmSystemReg : BaseForm
    {
        private string SystemSeqMo = "";

        private int FormType = 0;

        public FrmSystemReg()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Create.Enabled = false;
                string RegInfo = SysBusinessFunction.Decrypt(txt_RegInfo.Text.Trim());

                string LimitDate = RegInfo.Substring(0, 8); //日期

                string ActualRegInfo = RegInfo.Substring(8, RegInfo.Length - 8);
                ActualRegInfo = ActualRegInfo.Replace("\0", ""); // 去除回车字符
                if (ActualRegInfo == txt_SysSeqNo.Text)
                {
                    LimitDate = SysBusinessFunction.Encrypt(LimitDate);
                    string DelSql = "";
                    DelSql = string.Format("Delete From Mixing_Register Where Reg_Seq = '{0}'", txt_SysSeqNo.Text);
                    DataHelper.Fill(DelSql);

                    string RegSql = "";
                    RegSql = string.Format(@"Insert Into Mixing_Register(Reg_Seq,Register_Flag,Register_Info,Register_Date,Limit_Date,OutTime_Flag) 
                                             Values ('{0}','{1}','{2}',CONVERT(varchar(10),Getdate(),120),'{3}',0)", txt_SysSeqNo.Text, 1, txt_RegInfo.Text.Trim(), LimitDate);
                    DataHelper.Fill(RegSql);

                    DataHelper.Fill(DelSql);

                    DataHelper.Fill(RegSql);

                    BaseSystemInfo.RegisterFlag = true;
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "系统注册成功.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "注册失败.请检查注册码信息.");
                    return;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "注册失败.请检查注册码信息或数据库连接.");
            }
            finally
            {
                btn_Create.Enabled = true;
            }
        }

        private void FrmSystemReg_Load(object sender, EventArgs e)
        {
            //int FStrIndex = 0;
            //string Reg1 = "";
            //string Reg2 = "";
            //string RegStr = BaseSystemInfo.RegSeq;

            //while (RegStr.Length > FStrIndex)
            //{
            //    if (FStrIndex % 2 == 0)
            //    {
            //        Reg1 = Reg1 + RegStr.Substring(FStrIndex, 1);
            //    }
            //    else
            //    {
            //        Reg2 = Reg2 + RegStr.Substring(FStrIndex, 1);
            //    }
            //    FStrIndex++;
            //}

            //txt_SysSeqNo.Text = Reg1 + Reg2;
            txt_SysSeqNo.Text =  BaseSystemInfo.RegSeq;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            if (FormType == 1) // 如 通过
            {
                Application.Exit();
            }
            else
            {
                Close();
            }



        }
    }
}
