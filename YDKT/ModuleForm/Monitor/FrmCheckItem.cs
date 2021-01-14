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
    public partial class FrmCheckItem : Form
    {
        public string CNName = "";
        public string ENName = "";
        public string ICode = "";
        public string IName = "";
        public bool Show_Flag = false;//false 质检按钮 true 缺陷展示

        

        public FrmCheckItem()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmCheckItem_Load(object sender, EventArgs e)
        {
            try
            {

                if (Show_Flag)
                {
                    btn_item.Visible = !Show_Flag;
                    lbl_Detail.Visible = Show_Flag;
                    lbl_Detail.Text = String.Format(@"{0}
{1}", CNName, ENName);
                }
                else
                {
                    btn_item.Visible = !Show_Flag;
                    lbl_Detail.Visible = Show_Flag;
                    btn_item.Text = String.Format(@"{0}
{1}", CNName, ENName);
                }
              
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region  按钮事件
        private void btn_item_Click(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.CheckResult)
                {
                    return;
                }else
                {
                    FrmItemDetail fid = new FrmItemDetail();
                    fid.icode = ICode;
                    fid.iname = IName;
                    fid.ShowDialog();
                }
               
            }catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
