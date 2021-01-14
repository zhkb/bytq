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
    public partial class FrmStoreTask : Form
    {

        int m_iTabPage = 1;
        public static System.Threading.Timer GetDataTimer1;//检查西门子PLC 是否进来U壳

        public FrmStoreTask()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FrmStoreTask_Load(object sender, EventArgs e)
        {
            try
            {
                m_iTabPage = 1;

                ShowStoreBinInfo1();
                ShowStoreBinInfo2();

                GetDataTimer1 = new System.Threading.Timer(GetData, null, 0, Timeout.Infinite);//检查西门子PLC 是否进来U壳
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("FrmStoreTask_Load:" + ex.Message);
            }

            //this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            //this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
        }

        private void GetData(object o)
        {
            try
            {
                GetStoreData1(); //获取数据库中[Task_Type] ='I'
                GetStoreData2(); //获取数据库中[Task_Type] ='O'
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


        private void ShowStoreBinInfo1()
        {
            Application.DoEvents();
            for (int i = 0; i < 13; i++)
            {
                Application.DoEvents();
                FrmTaskModel TempForm = new FrmTaskModel();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.iXH = i + 1;//序号
                TempForm.strTask_Type = "1";
                TempForm.strStore_Code = "1001";
                TempForm.TopLevel = false;


                TempForm.Parent = tabPage1;
                if (i == 0)
                {
                    TempForm.Height = 130;
                    TempForm.Top = 0;
                }
                else
                {
                    TempForm.Height = 130;
                    TempForm.Top = i * 64 + 0;
                }

                TempForm.Show();
                //BinFormList.Insert(0, TempForm);
            }
            Application.DoEvents();
        }
        private void ShowStoreBinInfo2()
        {
            Application.DoEvents();
            for (int i = 0; i < 13; i++)
            {
                Application.DoEvents();
                FrmTaskModel2 TempForm = new FrmTaskModel2();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.iXH = i + 1;//序号
                TempForm.TopLevel = false;


                TempForm.Parent = tabPage2;
                if (i == 0)
                {
                    TempForm.Height = 130;
                    TempForm.Top = 0;
                }
                else
                {
                    TempForm.Height = 130;
                    TempForm.Top = i * 64 + 0;
                }

                TempForm.Show();
                //BinFormList.Insert(0, TempForm);
            }
            Application.DoEvents();
        }


        public void GetStoreData1() //刷新界面数据
        {
            try
            {
                DataSet DBDataSet = new DataSet();

                string SqlStr = string.Format(@"SELECT
	                                            TOP 13 [Material_Name],
	                                            [Bar_Code],
	                                            [Store_Code],
	                                            [RFID_BarCode],
	                                            (
		                                            CASE [Task_State]
		                                            WHEN '0' THEN'等待入库'
		                                            WHEN '1' THEN'正在入库'
		                                            ELSE'入库'
		                                            END
	                                            ) Task_State,
	                                            CONVERT (
		                                            VARCHAR (100),
		                                            [Create_Time],
		                                            120
	                                            ) AS [Create_Time]
                                                FROM
	                                                [IMOS_Lo_Task]
                                                WHERE
	                                                Company_Code = '{0}'
                                                AND Factory_Code = '{1}'
                                                AND Product_Line_Code = '{2}'
                                                AND [Task_Type] = '1'
                                                AND [Task_State] <= 2
                                                ORDER BY
	                                                [Create_Time] DESC", 
                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);



                //// 初始化
                OptionSetting.StoreShowDataList.Clear();
                ////foreach(OptionSetting.StoreBinData item   in OptionSetting.StoreShowDataList)
                ////{
                ////    if (item.Store_Code == "1001" && item.Task_Type == "I")
                ////        OptionSetting.StoreShowDataList.Remove(item);
                ////}

             
                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = DBDataSet.Tables[0].Rows[i];
                    OptionSetting.StoreBinData StoreInfo = new OptionSetting.StoreBinData();//
                    StoreInfo.ID = (i + 1).ToString();
                    StoreInfo.Material_Name = dr["Material_Name"].ToString();//物料名称
                    StoreInfo.Bar_Code = dr["Bar_Code"].ToString();//条码
                    StoreInfo.Store_Code = dr["Store_Code"].ToString();//库位号
                    StoreInfo.RFID_BarCode = dr["RFID_BarCode"].ToString(); ;//RFID编号
                    StoreInfo.Task_State = dr["Task_State"].ToString();//状态
                    StoreInfo.Start_Time = dr["Create_Time"].ToString();//开始时间
                    StoreInfo.Task_Type = "1";
                    
                    OptionSetting.StoreShowDataList.Add(StoreInfo);
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("GetStoreData1:" + ex.Message);
            }
        }


        public void GetStoreData2() //刷新界面数据
        {
            try
            {
                DataSet DBDataSet = new DataSet();

                string SqlStr = string.Format(@"SELECT
	                                            TOP 13 [Material_Name],
	                                            [Bar_Code],
	                                            [Store_Code],
	                                            [RFID_BarCode],
	                                            (
		                                            CASE [Task_State]
		                                            WHEN '0' THEN'等待出库'
		                                            WHEN '1' THEN'正在出库'
		                                            ELSE'出库'
		                                            END
	                                            ) Task_State,
	                                            CONVERT (
		                                            VARCHAR (100),
		                                            [Create_Time],
		                                            120
	                                            ) AS [Create_Time]
                                            FROM
	                                            [IMOS_Lo_Task]
                                            WHERE
	                                            Company_Code = '{0}'
                                            AND Factory_Code = '{1}'
                                            AND Product_Line_Code = '{2}'
                                            AND [Task_Type] = '2'
                                            AND [Task_State] <= 2
                                            ORDER BY
	                                            [Create_Time] DESC", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);



                // 初始化
                ////foreach (OptionSetting.StoreBinData item in OptionSetting.StoreShowDataList)
                ////{
                ////    if (item.Store_Code == "1001" && item.Task_Type == "O")
                ////        OptionSetting.StoreShowDataList.Remove(item);
                ////}

    
                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = DBDataSet.Tables[0].Rows[i];
                    OptionSetting.StoreBinData StoreInfo = new OptionSetting.StoreBinData();//
                    StoreInfo.ID = (i + 1).ToString();
                    StoreInfo.Material_Name = dr["Material_Name"].ToString();//物料名称
                    StoreInfo.Bar_Code = dr["Bar_Code"].ToString();//条码
                    StoreInfo.Store_Code = dr["Store_Code"].ToString();
                    StoreInfo.RFID_BarCode = dr["RFID_BarCode"].ToString(); 
                    StoreInfo.Task_State = dr["Task_State"].ToString();//状态
                    StoreInfo.Start_Time = dr["Create_Time"].ToString();//开始时间
                    StoreInfo.Task_Type = "2";
                    OptionSetting.StoreShowDataList2.Add(StoreInfo);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTask_StateIN0.Text = iTask_StateIN0.ToString();
            //lblTask_StateIN1.Text = iTask_StateIN1.ToString();
            //lblTask_StateOUT0.Text = iTask_StateOut0.ToString(); 
            //lblTask_StateOUT1.Text = iTask_StateOut1.ToString(); 
           
        }
    }
}
