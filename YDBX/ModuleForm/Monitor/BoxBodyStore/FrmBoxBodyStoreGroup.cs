using Monitor.BoxBodyStore;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmBoxBodyStoreGroup : Form
    {

        private System.Timers.Timer RefreshStoreBinDataTimer = new System.Timers.Timer(1000); //刷新库存数据Timer 
        private ArrayList BinFormList = new ArrayList(); //库位详细信息
        private ArrayList BinFormList2 = new ArrayList(); //库位详细信息
        private DataTable dtProd;
        private Boolean blnUp = true;
        public int StoreBinCount = 0; //货道数量
        public FrmBoxBodyStoreGroup()
        {
            InitializeComponent();
        }

        private void FrmBoxBodyStoreGroup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            StoreBinCount = 13;
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
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
            dgvPlan.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlan.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPlan.ClearSelection();

            panel7.Width = 1020;
            pnl_Store1.Width = 950;
            Application.DoEvents();
            for (int i = 0; i < 13; i++)
            {
                Application.DoEvents();
                FrmStoreBin TempForm = new FrmStoreBin();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.BinNo = i + 1;//货道号
                TempForm.MaxBinNo = 20;//货道数量
                TempForm.TopLevel = false;
                TempForm.Parent = pnl_Store1;
                TempForm.Width = 900;
                if (i == 0)
                {
                    TempForm.Height = 136;

                }
                else
                {
                    TempForm.Height = 68;
                    TempForm.Top = i * 68 + 68;
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

                SqlParameter[] values = {
                        new SqlParameter("UserNo",BaseSystemInfo.CurrentUserID)
                    };
                DBDataSet = DataHelper.ExecuteProcedure("up_IMOS_Lo_Bin_Group", new String[] { "StockData1", "StockData2", "StockData3" }, values);




                // 初始化
                OptionSetting.StoreBinDataList = new List<StoreBinData>();

                ////获取在库，在途数量

                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = DBDataSet.Tables[0].Rows[i];
                    int StoreBin = int.Parse(dr["Bin_No"].ToString());
                    StoreBinData StoreInfo = new StoreBinData();//
                    StoreInfo.Bin_ID = dr["Bin_No"].ToString();
                    StoreInfo.BinNo = int.Parse(StoreBin.ToString());//货道名称
                    StoreInfo.Material_Code = dr["Material_Code"].ToString();//产品编码
                    StoreInfo.MaterialName = dr["Material_Name"].ToString();//产品名称
                    StoreInfo.TransitQty = int.Parse(dr["Transit_Qty"].ToString()); ;//货道在途
                    StoreInfo.ActualQty = int.Parse(dr["Actual_Qty"].ToString());//货道实际库存
                    StoreInfo.BinFlag = int.Parse(dr["Bin_Flag"].ToString());//货道状态
                    OptionSetting.StoreBinDataList.Add(StoreInfo);

                }
                

                if(this.blnUp==true)
                {
                    dtProd = DBDataSet.Tables["StockData2"];
                    dgvPlan.DataSource = dtProd;
                    this.blnUp = false;

                    foreach (DataColumn C2 in dtProd.Columns)
                        C2.ReadOnly = false;
                }
                else
                {
                    for(int R2= 0;R2 < dtProd.Rows.Count;R2++)
                    {
                        dtProd.Rows[R2][0] = DBDataSet.Tables["StockData2"].Rows[R2][0];
                        dtProd.Rows[R2][1] = DBDataSet.Tables["StockData2"].Rows[R2][1];
                        dtProd.Rows[R2][2] = DBDataSet.Tables["StockData2"].Rows[R2][2];
                        dtProd.Rows[R2][3] = DBDataSet.Tables["StockData2"].Rows[R2][3];
                    }
                }
                    

                DataTable dt3 = DBDataSet.Tables["StockData3"];
                if(dt3!=null && dt3.Rows.Count>0)
                {
                    lblSpectionQty.Text = dt3.Rows[0]["Transit_Qty"].ToString();
                    lblStockQty.Text = dt3.Rows[0]["Actual_Qty"].ToString();
                    lblStockRate.Text = dt3.Rows[0]["Z_Rate"].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }


        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblSpectionQty.Text = OptionSetting.XTBarCodeA;
            //lblStockQty.Text = OptionSetting.XTBarCodeB;
            //lblStockRate.Text = OptionSetting.XTBinNoA;

        }

        private void dgvPlan_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
