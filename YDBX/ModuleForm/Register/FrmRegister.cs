using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    using Sys.Utilities;
    using Sys.SysBusiness;

    public partial class FrmRegister : BaseForm
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                string SeqNo = txt_SysSeqNo.Text.Trim();
                string LimitDate = dt_LimintDate.Text.Replace("-","");

                if (chk_Forever.Checked)  //永久激活
                {
                    txt_RegInfo.Text = SysBusinessFunction.Encrypt("20501231" + SeqNo);
                }
                else
                {
                    txt_RegInfo.Text = SysBusinessFunction.Encrypt(LimitDate + SeqNo);
                }

                //LimitDate = SysBusinessFunction.Encrypt(LimitDate);
                //string RegSql = "";
                //RegSql = string.Format("Delete From Wms_Product_Register Where Reg_Seq = '{0}'", SeqNo);

                //DataHelper.ServerFill(RegSql);

                //RegSql = string.Format(@"Insert Into Wms_Product_Register(Reg_Seq,Register_Flag,Register_Info,Register_Date,Limit_Date) 
                //                         Values '{0}','{1}','{2}',CONVERT(varchar(10),Getdate(),120),'{3}'", SeqNo,1, RegInfo, LimitDate);

                //DataHelper.ServerFill(RegSql);
            }
            catch(Exception ex)
            {
            }
            finally
            {

            }
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
