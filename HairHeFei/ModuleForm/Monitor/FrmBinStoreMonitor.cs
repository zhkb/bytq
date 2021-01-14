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
    public partial class FrmBinStoreMonitor : Form
    {
        private int count = 0;
        private DataSet storeds;
        public FrmBinStoreMonitor()
        {
            InitializeComponent();
        }

        private void tab_Area_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush Background = new SolidBrush(Color.FromArgb(16,16,16));
            Rectangle RecUp = tab_Area.GetTabRect(0);
            e.Graphics.FillRectangle(Background, RecUp);
            Rectangle RecDown = tab_Area.GetTabRect(1);
            e.Graphics.FillRectangle(Background, RecDown);
            //getBinStoreInfo();
        }

        //获取任务队列
        private void getTaskInfoList()
        {
            String sql = String.Format(@"SELECT
	                                        Bar_Code,
	                                        Material_Code,
	                                        Material_Name,
	                                        RFID_BarCode
                                        FROM
	                                        IMOS_Lo_Task
                                        WHERE
	                                        Task_State = '{0}'
                                        AND Task_Type = '{1}'
                                        AND CurrentProcessCode = '{2}'
                                        AND CurrentProcessName = '{3}'
                                        ORDER BY
	                                        Create_Time","1","1", "GW001", "绑定入库");
            DataSet ds = DataHelper.Fill(sql);
            if (ds != null)
            {
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TaskInfo ti = new TaskInfo();
                    ti.MaterialBarCode = ds.Tables[0].Rows[i]["Bar_Code"].ToString();
                    ti.MaterialCode = ds.Tables[0].Rows[i]["Material_Code"].ToString();
                    ti.MaterialName = ds.Tables[0].Rows[i]["Material_Name"].ToString();
                    ti.RFIDBarCode = ds.Tables[0].Rows[i]["RFID_BarCode"].ToString();
                    OptionSetting.InTaskList.Add(ti);
                }
            }
        }

        private void getBinStoreInfo()
        {
            String sql = String.Format(@"SELECT
                                          Store_Qty,
                                          Store_Code,
                                          Material_Name,
                                          Max_Qty

                                       FROM
                                          IMOS_Lo_Bin
                                       WHERE
                                        Area_Code = '{0}'", "A001");
            storeds = DataHelper.Fill(sql);
            if (storeds != null)
            {
                for(int i = 0; i < storeds.Tables[0].Rows.Count; i++)
                {
                    if ("1".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin1Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin1Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB1M", i);
                        //ShowButton("btn_AB1M", i);
                    }
                    if ("2".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin2Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin2Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB2M", i);
                        //ShowButton("btn_AB2M", i);
                    }
                    if ("3".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin3Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin3Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB3M", i);
                        //ShowButton("btn_AB3M", i);
                    }
                    if ("4".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin4Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin4Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB4M", i);
                        //ShowButton("btn_AB4M", i);
                    }
                    if ("5".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin5Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin5Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB5M", i);
                        //ShowButton("btn_AB5M", i);
                    }
                    if ("6".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin6Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin6Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB6M", i);
                        //ShowButton("btn_AB6M", i);
                    }
                    if ("7".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin7Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin7Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB7M", i);
                        //ShowButton("btn_AB7M", i);
                    }
                    if ("8".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_ABin8Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_ABin8Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetailInfo("btn_AB8M", i);
                        //ShowButton("btn_AB8M", i);
                    }
                   
                }
            }
        }
        private void ShowButton(String str,int m)
        {
            for (int j = 1; j <= 7; j++)
            {
                Button btn = Controls.Find(str + j, true)[0] as Button;
                if (j <= (int)storeds.Tables[0].Rows[m]["Store_Qty"])
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }
        }

        private void FrmBinStoreMonitor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 300;
            timer1.Start();
            timer2.Enabled = true;
            timer2.Interval = 300;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getBinStoreInfo();
            for(int i = 1; i <= 8; i++)
            {
                getIntTaskData(i.ToString());
            }
            for (int i = 1; i <= 8; i++)
            {
                getOutTaskData(i.ToString());
            }
        }

        private void getBinDetailInfo(String str, int m)
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                        Bar_Code,
	                                        RFID_Code,
                                            Material_State
                                        FROM
	                                        IMOS_Lo_Bin_Detial
                                        WHERE
	                                        Store_Code = '{0}'
                                        AND Area_Code = '{1}'
                                        AND (Material_State = '{2}' OR
                                        Material_State = '{3}')
                                        ORDER BY
	                                        Create_Time", storeds.Tables[0].Rows[m]["Store_Code"].ToString(), "A001","1","2");
                DataSet ds = DataHelper.Fill(sql);

                for (int j = 1; j <= 7; j++)
                {
                    Button btn = Controls.Find(str + j, true)[0] as Button;
                
                    if (j <= (int)storeds.Tables[0].Rows[m]["Store_Qty"])
                    {
                        if (ds != null && (j-1)<ds.Tables[0].Rows.Count)
                        {
                            btn.Text = ds.Tables[0].Rows[j - 1]["Bar_Code"].ToString();
                            if(ds.Tables[0].Rows[j - 1]["Material_State"].ToString() == "2")
                            {
                                btn.BackColor = Color.Red;
                            }else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        btn.Visible = true;
                    }
                    else
                    {
                        btn.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            getBinStore2Info();
        }

        private void getBinStore2Info()
        {
            String sql = String.Format(@"SELECT
                                          Store_Qty,
                                          Store_Code,
                                          Material_Name,
                                          Max_Qty

                                       FROM
                                          IMOS_Lo_Bin
                                       WHERE
                                        Area_Code = '{0}'", "B001");
            storeds = DataHelper.Fill(sql);
            if (storeds != null)
            {
                for (int i = 0; i < storeds.Tables[0].Rows.Count; i++)
                {
                    if ("1".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin1Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin1Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB1M", i);
                        //ShowButton("btn_AB1M", i);
                    }
                    if ("2".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin2Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin2Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB2M", i);
                        //ShowButton("btn_AB2M", i);
                    }
                    if ("3".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin3Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin3Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB3M", i);
                        //ShowButton("btn_AB3M", i);
                    }
                    if ("4".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin4Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin4Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB4M", i);
                        //ShowButton("btn_AB4M", i);
                    }
                    if ("5".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin5Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin5Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB5M", i);
                        //ShowButton("btn_AB5M", i);
                    }
                    if ("6".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin6Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin6Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB6M", i);
                        //ShowButton("btn_AB6M", i);
                    }
                    if ("7".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin7Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin7Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB7M", i);
                        //ShowButton("btn_AB7M", i);
                    }
                    if ("8".Equals(storeds.Tables[0].Rows[i]["Store_Code"].ToString()))
                    {
                        lbl_BBin8Matedrial.Text = storeds.Tables[0].Rows[i]["Material_Name"].ToString();
                        lbl_BBin8Count.Text = storeds.Tables[0].Rows[i]["Store_Qty"].ToString();
                        getBinDetail2Info("btn_BB8M", i);
                        //ShowButton("btn_AB8M", i);
                    }

                }
            }
        }


        private void getBinDetail2Info(String str, int m)
        {
            try
            {
                String sql = String.Format(@"SELECT
	                                            Bar_Code,
	                                            RFID_Code,
                                                Material_State
                                            FROM
	                                            IMOS_Lo_Bin_Detial
                                            WHERE
	                                            Store_Code = '{0}'
                                            AND Area_Code = '{1}'
                                            AND (Material_State = '{2}' OR
                                            Material_State = '{3}')
                                            ORDER BY
	                                            Create_Time ", storeds.Tables[0].Rows[m]["Store_Code"].ToString(), "B001", "1", "2");
                DataSet ds = DataHelper.Fill(sql);

                for (int j = 1; j <= 7; j++)
                {
                    Button btn = Controls.Find(str + j, true)[0] as Button;

                    if (j <= (int)storeds.Tables[0].Rows[m]["Store_Qty"])
                    {
                        if (ds != null && (j - 1) < ds.Tables[0].Rows.Count)
                        {
                            btn.Text = ds.Tables[0].Rows[j - 1]["Bar_Code"].ToString();
                            if (ds.Tables[0].Rows[j - 1]["Material_State"].ToString() == "2")
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        btn.Visible = true;
                    }
                    else
                    {
                        btn.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void getIntTaskData(String storecode)
        {
            try
            {
                String sql = String.Format(@"SELECT                                            
	                                            Bar_Code	                                           
                                            FROM
	                                            IMOS_Lo_Task
                                            WHERE
	                                            Task_Type = '{0}'  and Store_Code = '{1}' and Task_State = '{2}'
                                             Order By Create_Time ", "1",storecode,"1");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    Button btn = Controls.Find("btn_AA0M" + storecode, true)[0] as Button;
                    btn.Text = ds.Tables[0].Rows[0]["Bar_Code"].ToString();
                    btn.Visible = true;
                }
                
                
            }
            catch (Exception)
            {

            }
        }
        private void getOutTaskData(String storecode)
        {
            try
            {
                String sql = String.Format(@"SELECT                                            
	                                            Bar_Code	                                           
                                            FROM
	                                            IMOS_Lo_Task
                                            WHERE
	                                            Task_Type = '{0}'  and Store_Code = '{1}' and Task_State = '{2}'
                                            Order by Create_Time DESC", "2", storecode, "2");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    Button btn = Controls.Find("btn_AB0M" + storecode, true)[0] as Button;
                    btn.Text = ds.Tables[0].Rows[0]["Bar_Code"].ToString();
                    btn.Visible = true;
                }


            }
            catch (Exception)
            {

            }
        }
    }
    
}
