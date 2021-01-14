using Sys.Config;
using Sys.DbUtilities;
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


    public partial class FrmItemDetail : Form
    {
        public string icode;
        private int num;
        public string iname;

        public FrmItemDetail()
        {
            InitializeComponent();
        }
        #region 界面加载
        private void FrmItemDetail_Load(object sender, EventArgs e)
        {
            try
            {
                OptionSetting.itemcode = icode;
                GetDetailList();
                timer1.Enabled = true;
                timer1.Interval = 200;
                timer1.Start();

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 获取缺陷列表

        private void GetDetailList()
        {
            try
            {
                String sql = String.Format(@"SELECT Check_Item_Detail_Code,Check_Item_Detail_Name,Check_Item_Detail_Name_EN FROM IMOS_PR_QualityItem_Detail where Check_Item_Code = '{0}'", icode);
                DataSet ds = DataHelper.Fill(sql);

                if (ds == null)
                {
                    return;
                }
                num = ds.Tables[0].Rows.Count;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AddDetail(ds.Tables[0].Rows[i]["Check_Item_Detail_Code"].ToString(), ds.Tables[0].Rows[i]["Check_Item_Detail_Name"].ToString(), ds.Tables[0].Rows[i]["Check_Item_Detail_Name_EN"].ToString(), i);
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 添加缺陷详细信息
        private void AddDetail(string code, string cnname, string enname, int count)
        {
            try
            {
                FrmDetailShow fds = new FrmDetailShow();
                fds.TopLevel = false;
                fds.Parent = panel1;
                fds.IName = iname;
                fds.ICode = icode;
                fds.DCode = code;
                fds.DCNName = cnname;
                fds.DENName = enname;
                int y = 20 + 159 * (count / 3);
                if (count % 3 == 0)
                {
                    fds.Location = new System.Drawing.Point(47, y);
                }
                else if (count % 3 == 1)
                {
                    fds.Location = new System.Drawing.Point(415, y);
                }
                else
                {
                    fds.Location = new System.Drawing.Point(781, y);
                }
                fds.Name = "fds" + count;
                fds.Show();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 关闭按钮事件
        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                //释放数据
                OptionSetting.itemcode = "";
                this.Close();
            }
            catch
            {
                SysBusinessFunction.WriteLog("关闭失败！");
            }

        }

        #endregion

        #region 定时刷新显示选择的缺陷项界面
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                #region 实时刷新添加数据
                //for (int i = 0; i < 10; i++)
                //{
                //    Label L = Controls.Find("label" + (i + 1), true)[0] as Label;
                //    if (i < OptionSetting.CheckDetailList.Count)
                //    {
                //        L.Text = OptionSetting.CheckDetailList[i].Detail_Code.ToString();
                //        L.Visible = true;
                //    }
                //    else
                //    {
                //        L.Text = "";
                //        L.Visible = false;
                //    }
                //}
                for (int j = 0; j < num; j++)
                {
                    FrmDetailShow fds = Controls.Find("fds" + j, true)[0] as FrmDetailShow;
                    bool flag = true;
                    for (int k = 0; k < OptionSetting.CheckDetailList.Count; k++)
                    {
                        if (fds.DCode.Equals(OptionSetting.CheckDetailList[k].Detail_Code.ToString()))
                        {
                            fds.btn_item.BackColor = Color.Red;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        fds.btn_item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
                    }
                }
                #endregion


            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 刷新按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < OptionSetting.CheckDetailList.Count; j++)
                    {
                        FrmDetailShow fds = Controls.Find("fds" + i, true)[0] as FrmDetailShow;
                        if (fds.DCode.Equals(OptionSetting.CheckDetailList[j].Detail_Code.ToString()))
                        {
                            OptionSetting.CheckDetailList.RemoveAt(j);
                        }

                    }
                }
                //清除缺陷表
                for (int i = 0; i < num; i++)
                {
                    FrmDetailShow fds = Controls.Find("fds" + i, true)[0] as FrmDetailShow;
                    fds.Dispose();
                }
                GetDetailList();
                OptionSetting.ReDeFlag = true;

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region OK按钮事件
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.QCProBarCode.Length != 0 && !OptionSetting.CheckResult)
                {
                    //for(int i = 0; i < num; i++)
                    //{
                    //    FrmDetailShow fds = Controls.Find("fds" + i, true)[0] as FrmDetailShow;
                    //    if (fds.Use_Flag)
                    //    {
                    //        CheckDetailData cdd = new CheckDetailData();
                    //        cdd.Detail_Code = fds.DCode;
                    //        cdd.Detail_Name_CN = fds.DCNName;
                    //        cdd.Detail_Name_EN = fds.DENName;
                    //        cdd.Item_Code = fds.ICode;
                    //        OptionSetting.CheckDetailList.Add(cdd);
                    //    }
                    //}
                    OptionSetting.itemcode = "";
                    OptionSetting.ReDeFlag = true;
                    this.Dispose();

                }
                else
                {
                    SysBusinessFunction.SystemDialog(2, "请扫描产品条码！");
                }





            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
