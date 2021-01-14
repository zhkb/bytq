using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.DbUtilities;
using Sys.Config;
using Sys.SysBusiness;
using System.Threading;

namespace Monitor
{
    public partial class FrmStoreTask2 : Form
    {
        private delegate void ThreadWork1(object o);
        private delegate void ThreadWork2(object o);
        int iTask_StateIN0 = 0;
        int iTask_StateIN1 = 0;
        int iTask_StateIN2 = 0;

        int iTask_StateOut0 = 0;
        int iTask_StateOut1 = 0;
        int iTask_StateOut2 = 0;

        int m_iTabPage = 1;
        public static System.Threading.Timer GetDataTimer1;//检查西门子PLC 是否进来U壳

        public FrmStoreTask2()
        {
            InitializeComponent();
            dgv_Record.TopLeftHeaderCell.Value = "序号";
            dgv_Record2.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmStoreTask2_Load(object sender, EventArgs e)
        {
            try
            {

                GetDataTimer1 = new System.Threading.Timer(GetData, null, 0, Timeout.Infinite);//检查西门子PLC 是否进来U壳
                OptionSetting.StoreShowDataList = new List<OptionSetting.StoreBinData>();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("FrmStoreTask2_Load:" + ex.Message);
            }

            //this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            //this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
        }

        private void GetData(object sender)
        {
            try
            {
                Invoke(new ThreadWork1(GetStoreData1), sender); //获取数据库中[Task_Type] ='I'
                Invoke(new ThreadWork2(GetStoreData2), sender); //获取数据库中[Task_Type] ='O'
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("GetData:" + ex.Message);
            }
            finally
            {
                GetDataTimer1.Change(2000, Timeout.Infinite);
            }
        }


        public void GetStoreData1(object o) //刷新界面数据
        {
            try
            {
                DataSet DBDataSet = new DataSet();

                string SqlStr = string.Format(@"SELECT top 13 [Material_Name],[Bar_Code],[Task_From],[Task_To],[Task_State]=CASE WHEN [Task_State] = 0
                                            THEN '未执行'
                                            WHEN [Task_State] = 1
                                            THEN '执行中'
                                            WHEN [Task_State] = 2
                                            THEN '执行完'
                                            ELSE ' ' END 
                                           , Convert(Varchar(100),[Start_Time] ,120) as [Start_Time],[Store_Code] FROM [IMOS_Lo_Task]
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and   [Task_Type] ='I' and [Store_Code]='1001' 
                                          order by [Start_Time] desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);

                if (DBDataSet.Tables[0].Rows.Count < 13)
                {
                    int iRows = DBDataSet.Tables[0].Rows.Count;
                    for (int i = iRows + 1; i < 14; i++)
                    {
                        DataRow dr = DBDataSet.Tables[0].NewRow();
                        DBDataSet.Tables[0].Rows.Add(dr);
                    }
                }
                dgv_Record.DataSource = DBDataSet.Tables[0];



                iTask_StateIN0 = 0;
                iTask_StateIN1 = 0;
                iTask_StateIN2 = 0;
                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    if (DBDataSet.Tables[0].Rows[i]["Task_State"].ToString() == "未执行")
                    {
                        dgv_Record.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(56, 68, 92);
                        dgv_Record.Rows[i].Cells[5].Style.ForeColor = Color.Gold; 
                        iTask_StateIN0++;
                    }
                    else if (DBDataSet.Tables[0].Rows[i]["Task_State"].ToString() == "执行中")
                    {
                        dgv_Record.Rows[i].Cells[5].Style.BackColor = Color.Lime;
                        dgv_Record.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                        iTask_StateIN1++;
                    }
                    else if (DBDataSet.Tables[0].Rows[i]["Task_State"].ToString() == "执行完")
                    {
                        dgv_Record.Rows[i].Cells[5].Style.BackColor = Color.Gray;
                        dgv_Record.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        iTask_StateIN1++;
                    }
                    else
                    {
                        dgv_Record.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(56, 68, 92);
                        dgv_Record.Rows[i].Cells[5].Style.ForeColor = Color.Gold;
                        iTask_StateIN2++;
                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("GetStoreData1:" + ex.Message);
            }
        }


        public void GetStoreData2(object o) //刷新界面数据
        {
            try
            {
                DataSet DBDataSet = new DataSet();

                string SqlStr = string.Format(@"SELECT top 13 [Material_Name],[Bar_Code],[Task_From],[Task_To],[Task_State]=CASE WHEN [Task_State] = 0
                                            THEN '未执行'
                                            WHEN [Task_State] = 1
                                            THEN '执行中'
                                            WHEN [Task_State] = 2
                                            THEN '执行完'
                                            ELSE ' ' END 
                                          ,Convert(Varchar(100),[Start_Time] ,120) as [Start_Time],[Store_Code] FROM [IMOS_Lo_Task]
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and   [Task_Type] ='O' and [Store_Code]='1001' 
                                          order by [Start_Time] desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);
                if (DBDataSet.Tables[0].Rows.Count < 13)
                {
                    int iRows = DBDataSet.Tables[0].Rows.Count;
                    for (int i = iRows + 1; i < 14; i++)
                    {
                        DataRow dr = DBDataSet.Tables[0].NewRow();
                        DBDataSet.Tables[0].Rows.Add(dr);
                    }
                }
                dgv_Record2.DataSource = DBDataSet.Tables[0];


                // 初始化
                //OptionSetting.StoreShowDataList2 = new List<OptionSetting.StoreBinData>();

                iTask_StateOut0 = 0;
                iTask_StateOut1 = 0;
                iTask_StateOut2 = 0;
                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    

                    if (DBDataSet.Tables[0].Rows[i]["Task_State"].ToString() == "未执行")
                    {
                        dgv_Record2.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(56, 68, 92);
                        dgv_Record2.Rows[i].Cells[5].Style.ForeColor = Color.Gold;
                        iTask_StateOut0++;
                    }
                    else if (DBDataSet.Tables[0].Rows[i]["Task_State"].ToString() == "执行中")
                    {
                        dgv_Record2.Rows[i].Cells[5].Style.BackColor = Color.Lime;
                        dgv_Record2.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                        iTask_StateOut1++;
                    }
                    else if (DBDataSet.Tables[0].Rows[i]["Task_State"].ToString() == "执行完")
                    {
                        dgv_Record.Rows[i].Cells[5].Style.BackColor = Color.Gray;
                        dgv_Record.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        iTask_StateIN1++;
                    }
                    else
                    {
                        dgv_Record2.Rows[i].Cells[5].Style.BackColor = Color.FromArgb(56, 68, 92);
                        dgv_Record2.Rows[i].Cells[5].Style.ForeColor = Color.Gold;
                        iTask_StateOut2++;
                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("GetStoreData2:" + ex.Message);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //标签背景填充颜色
            SolidBrush BackBrush = new SolidBrush(Color.FromArgb(33, 76, 111));
            //标签文字填充颜色
            SolidBrush FrontBrush = new SolidBrush(Color.White);
            StringFormat StringF = new StringFormat();
            //设置文字对齐方式
            StringF.Alignment = StringAlignment.Center;
            StringF.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //获取标签头工作区域
                Rectangle Rec = tabControl1.GetTabRect(i);
                //绘制标签头背景颜色

                e.Graphics.FillRectangle(BackBrush, Rec);
                //绘制标签头文字
                e.Graphics.DrawString(tabControl1.TabPages[i].Text, new Font("微软雅黑", 18), FrontBrush, Rec, StringF);
            }

            Rectangle Rec2 = tabControl1.GetTabRect(1);
            Rec2.X = Rec2.X + Rec2.Width + 2;
            Rec2.Width = 1920 - Rec2.Width * 2 - 2;
            e.Graphics.FillRectangle(BackBrush, Rec2);
        }

        private void dgv_Record2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgv_Record_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
