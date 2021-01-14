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
    public partial class FrmDetailShow : Form
    {
        public string ICode = "";
        public string DCode = "";
        public string DCNName = "";
        public string DENName = "";
        public bool Use_Flag = true;//false 加入缺陷  true删除缺陷

        public string IName = "";
        public FrmDetailShow()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmDetailShow_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = SysBusinessFunction.CreateBarCode(DCode,190,50);
                btn_item.Text = String.Format(@"{0}
{1}",DCNName,DENName);
            }catch(Exception ex)
            {
                
            }
        }
        #endregion

        #region 点击事件
        private void btn_item_Click(object sender, EventArgs e)
        {
            try
            {
                #region  实时刷新添加数据事件
                CheckDetailData cdd = new CheckDetailData();
                cdd.Detail_Code = DCode;
                cdd.Detail_Name_CN = DCNName;
                cdd.Detail_Name_EN = DENName;
                cdd.Item_Code = ICode;
                cdd.Item_Name = IName;
                Use_Flag = true;
                //判断有没有
                for (int i = 0; i < OptionSetting.CheckDetailList.Count; i++)
                {
                    if (cdd.Equals(OptionSetting.CheckDetailList[i]))
                    {
                        OptionSetting.CheckDetailList.Remove(cdd);
                        Use_Flag = false;
                        break;
                    }
                }
                if (Use_Flag)
                {
                    OptionSetting.CheckDetailList.Add(cdd);
                    btn_item.BackColor = Color.Red;
                }
                OptionSetting.ReDeFlag = true;
                #endregion


            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("点击事件发生异常"+ex.Message);
            }
        }
        #endregion


    }
}
