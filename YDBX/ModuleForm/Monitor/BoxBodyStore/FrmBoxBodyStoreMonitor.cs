using Monitor.BoxBodyStore;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
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
    public partial class FrmBoxBodyStoreMonitor : Form
    {

        private System.Timers.Timer RefreshStoreBinDataTimer = new System.Timers.Timer(1000); //刷新库存数据Timer 
        private ArrayList BinFormList = new ArrayList(); //库位详细信息

        public int StoreBinCount = 0; //货道数量
        public FrmBoxBodyStoreMonitor()
        {
            InitializeComponent();
        }

        private void FrmBoxBodyStoreMonitor_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            StoreBinCount = 13;
            ControlBox = false;
            WindowState = FormWindowState.Maximized;

            int width = this.Width / 2;
            this.pl_left.Width = width-6;


            SetStoreBinForm();//设置货道数据
            GetStoreBinData(null);
            RefreshStoreBinDataTimer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshStoreBinEvent);
            RefreshStoreBinDataTimer.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            RefreshStoreBinDataTimer.Enabled = true; //是否触发Elapsed事件
            RefreshStoreBinDataTimer.Start();

        }



        private void RefreshStoreBinEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetStoreBinData(null);
        }


        private void SetStoreBinForm()
        {
          //  panel5.Width = 630;
          //  pnl_Store1.Width = 680;
            Application.DoEvents();
            for (int i = 0; i < 13; i++)
            {
                Application.DoEvents();
                FrmBoxBodyStoreDetail TempForm = new FrmBoxBodyStoreDetail();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.BinNo = i + 1;//货道号
                TempForm.MaxBinNo = 13;//货道数量
                TempForm.TopLevel = false;

                if (i < 7)
                {
                    TempForm.Parent = pnl_Store1;


                    if (i == 0)
                    {
                        TempForm.Height = 180;
                        TempForm.Top = i * 100;
                    }
                    else
                    {
                        TempForm.Height = 100;
                        TempForm.Top = i * 100 + 70;
                    }


                }
                else
                {
                    TempForm.Parent = pnl_Store2;

                    if (i == 7)
                    {
                        TempForm.Height = 180;
                    }
                    else
                    {
                        TempForm.Height = 100;
                        TempForm.Top = (i - 7) * 100 + 70;
                    }

                }



                TempForm.Show();
                BinFormList.Insert(0, TempForm);
            }
            Application.DoEvents();
        }


        #region 刷新库存

        private void GetStoreBinData(object o)
        {
            try
            {
                string SqlStr = "";
                Thread.Sleep(10);

                if (!SysBusinessFunction.DBConn) //数据库连接失败时不再进行数据查询
                {
                    return;
                }
                //获取货道信息及货道状态
                DataSet DBDataSet = new DataSet();
                SqlStr = string.Format(@" select * from IMOS_LO_BIN a
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Process_Code = '{3}'
                                          order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,BaseSystemInfo.CurrentProcessCode);
                DBDataSet = DataHelper.Fill(SqlStr);




                // 初始化
                OptionSetting.StoreBinDataList = new List<StoreBinData>();

                ////获取在库，在途数量

                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = DBDataSet.Tables[0].Rows[i];
                    int StoreBin = int.Parse(dr["Bin_No"].ToString());
                    StoreBinData StoreInfo = new StoreBinData();//
                    StoreInfo.Bin_ID = dr["Bin_ID"].ToString();
                    StoreInfo.BinNo = int.Parse(StoreBin.ToString());//货道名称
                    StoreInfo.Material_Code = dr["Material_Code"].ToString();//产品编码
                    StoreInfo.MaterialName = dr["Material_Name"].ToString();//产品名称
                    StoreInfo.TransitQty = int.Parse(dr["Transit_Qty"].ToString()); ;//货道在途
                    StoreInfo.ActualQty = int.Parse(dr["Actual_Qty"].ToString());//货道实际库存
                    StoreInfo.BinFlag = int.Parse(dr["Bin_Flag"].ToString());//货道状态
                    OptionSetting.StoreBinDataList.Add(StoreInfo);

                }

            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_A_barCode.Text = OptionSetting.XTBarCodeA;
            lb_A_BinNo.Text = OptionSetting.XTBinNoA;
            lb_A_Msg.Text = OptionSetting.XTMsgA;
            lb_B_barCode.Text = OptionSetting.XTBarCodeB;
            lb_B_BinNo.Text = OptionSetting.XTBinNoB;
          
            lb_B_Msg.Text = OptionSetting.XTMsgB;

        }

        private void lb_A_BinNo_DoubleClick(object sender, EventArgs e)
        {
            FrmManual ModifyForm = new FrmManual();
            DialogResult r = ModifyForm.ShowDialog();
            ModifyForm.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmManual ModifyForm = new FrmManual();
            DialogResult r = ModifyForm.ShowDialog();
            ModifyForm.Dispose();
        }
    }
}
