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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmShowBoxBodyMonitor : Form
    {
        private int count = 0;
        public FrmShowBoxBodyMonitor()
        {
            InitializeComponent();
        }

        #region  界面加载
        private void FrmShowBoxBodyMonitor_Load(object sender, EventArgs e)
        {
            //Refresh();
            RefreshDataA();
            RefreshDataB();
            timer1.Interval = 2000;
            timer1.Start();
        }
        #endregion

        #region 时间事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Thread.Sleep(100000);
                RefreshDataA();
                RefreshDataB();
                if (count == 0)
                {
                    pictureBox2.Image = global::Monitor.Properties.Resources.XT2;
                    pictureBox3.Image = global::Monitor.Properties.Resources.XT;
                    count++;
                }
                else
                {
                    pictureBox2.Image = global::Monitor.Properties.Resources.XT;
                    pictureBox3.Image = global::Monitor.Properties.Resources.XT2;
                    count--;
                }
            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog("");
            }
        }

        #endregion

        #region 刷新A线
        private void RefreshDataA()
        {
            try
            {

                String sql = String.Format(@"SELECT
	                                            Box_Name,
                                                Convert(varchar(50),Create_Time,120) Create_Time
                                            FROM
	                                            IMOS_TA_BoxDoor_Record
                                            WHERE
	                                            Scan_Flag = 1
                                            AND Company_Code = '{0}'
                                            AND Company_Name = '{1}'
                                            AND Factory_Code = '{2}'
                                            AND Factory_Name = '{3}'
                                            AND Product_Line_Code = '{4}'
                                            AND Product_Line_Name = '{5}'
                                            ORDER BY
	                                            Create_time ",
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName,
                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, "L001", "印度NOIDA冰箱生产A线");
                DataSet ds = DataHelper.Fill(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int j = 1; j <= 20; j++)
                    {
                        RefreshBoxA(1, j, "", j);
                    }
                    for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                    {
                        if (i <= 20)
                        {
                            //获取现在的时间
                            DateTime ndt = DateTime.Now;
                            //获取数据库的时间数据
                            DateTime odt = Convert.ToDateTime(ds.Tables[0].Rows[i - 1]["Create_Time"]);
                            TimeSpan ts = ndt - odt;
                            if (Math.Abs(ts.TotalSeconds) >= 2*(21 - i))
                            {
                                RefreshBoxA(2, i, ds.Tables[0].Rows[i - 1]["Box_Name"].ToString(), i);
                            }
                            else
                            {
                                RefreshBoxA(2, 21 - (int)(ts.TotalSeconds/2), ds.Tables[0].Rows[i - 1]["Box_Name"].ToString(), i);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                else
                {
                    for (int j = 1; j <= 20; j++)
                    {
                        RefreshBoxA(1, j, "", j);
                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新A线线体失败！");
            }
        }
        #endregion

        #region 刷新A线箱体
        private void RefreshBoxA(int m, int n, string name, int count)
        {
            try
            {
                if (m == 1)
                {
                    Label MlblA = Controls.Find("lbl_LineA_" + n, true)[0] as Label;
                    MlblA.Text = "";
                    //MlblA.Visible = false;
                    Label NlblA = Controls.Find("lbl_LineAN_" + n, true)[0] as Label;
                    NlblA.Text = "";
                    //NlblA.Visible = false;
                    //从数据库中取出箱体图片
                    PictureBox pbLineA = Controls.Find("pic_LineA_" + n, true)[0] as PictureBox;
                    pbLineA.Image = global::Monitor.Properties.Resources.BG;
                    //pbLineA.Visible = false;

                }
                else
                {
                    Label MlblA = Controls.Find("lbl_LineA_" + n, true)[0] as Label;
                    MlblA.Text = name;
                    //MlblA.Visible = true;
                    Label NlblA = Controls.Find("lbl_LineAN_" + n, true)[0] as Label;
                    NlblA.Text = count + "";
                    //NlblA.Visible = true;
                    PictureBox pbLineA = Controls.Find("pic_LineA_" + n, true)[0] as PictureBox;
                    pbLineA.Image = global::Monitor.Properties.Resources.bx;
                    //pbLineA.Visible = true;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新A线箱体失败！");
            }
        }

        #endregion

        #region 刷新B线
        private void RefreshDataB()
        {
            try
            {

                String sql = String.Format(@"SELECT
	                                            Box_Name,
                                                Convert(varchar(50),Create_Time,120) Create_Time
                                            FROM
	                                            IMOS_TA_BoxDoor_Record
                                            WHERE
	                                            Scan_Flag = 1
                                            AND Company_Code = '{0}'
                                            AND Company_Name = '{1}'
                                            AND Factory_Code = '{2}'
                                            AND Factory_Name = '{3}'
                                            AND Product_Line_Code = '{4}'
                                            AND Product_Line_Name = '{5}'
                                            ORDER BY
	                                            Create_time ",
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName,
                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, "L002", "印度NOIDA冰箱生产B线");
                DataSet ds = DataHelper.Fill(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int j = 1; j <= 20; j++)
                    {
                        RefreshBoxB(1, j, "", j);
                    }
                    for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                    {
                        if (i <= 20)
                        {
                            //获取现在的时间
                            DateTime ndt = DateTime.Now;
                            DateTime odt = Convert.ToDateTime(ds.Tables[0].Rows[i - 1]["Create_Time"]);
                            TimeSpan ts = ndt - odt;
                            if (Math.Abs(ts.TotalSeconds) >= (21 - i))
                            {
                                RefreshBoxB(2, i, ds.Tables[0].Rows[i - 1]["Box_Name"].ToString(), i);
                            }
                            else
                            {
                                RefreshBoxB(2, 21 - (int)ts.TotalSeconds, ds.Tables[0].Rows[i - 1]["Box_Name"].ToString(), i);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                else
                {
                    for (int j = 1; j <= 20; j++)
                    {
                        RefreshBoxB(1, j, "", j);
                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新B线线体失败！");
            }
        }
        #endregion

        #region 刷新B线箱体
        private void RefreshBoxB(int m, int n, string name, int count)
        {
            try
            {
                if (m == 1)
                {
                    Label MlblB = Controls.Find("lbl_LineB_" + n, true)[0] as Label;
                    MlblB.Text = "";
                    //MlblB.Visible = false;
                    Label NlblB = Controls.Find("lbl_LineBN_" + n, true)[0] as Label;
                    NlblB.Text = "";
                    //从数据库中取出箱体图片
                    PictureBox pbLineB = Controls.Find("pic_LineB_" + n, true)[0] as PictureBox;
                    pbLineB.Image = global::Monitor.Properties.Resources.BG;

                }
                else
                {
                    Label MlblB = Controls.Find("lbl_LineB_" + n, true)[0] as Label;
                    MlblB.Text = name;
                    Label NlblB = Controls.Find("lbl_LineBN_" + n, true)[0] as Label;
                    NlblB.Text = count + "";
                    PictureBox pbLineB = Controls.Find("pic_LineB_" + n, true)[0] as PictureBox;
                    pbLineB.Image = global::Monitor.Properties.Resources.bx;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新B线线体失败！");
            }
        }

        #endregion
    }
}
