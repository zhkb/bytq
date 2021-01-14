using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmEnErEdit : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        private bool closeFlag = false;
        public FrmEnErEdit()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEnErEdit_Load(object sender, EventArgs e)
        {
            lbl_EBinNo.Text = OptionSetting.Ebinno;
            lbl_Code.Text = OptionSetting.Ecode;
            lbl_Name.Text = OptionSetting.Ename;
            lbl_ENum.Text = OptionSetting.Eqty;
            timer1.Start();
            timer1.Interval = 500;

            //下传PLC 打开柜门
            DownAddPLC();

  
        }

        private void DownAddPLC()
        {
            try
            {
                int address = 167;
                object[] RBuff = new object[1];
                ControlMaster.ReadData(0, address, 1, out RBuff);
                //感应磁敏
                if((int)RBuff[0] == 0)//没有网格门开启
                {
                    int DownAddress = 160; //起始地址D5
                    object[] BackWBuff = new object[2];
                    BackWBuff[0] = OptionSetting.Ebinno;
                    BackWBuff[1] = 1;
                    bool result = ControlMaster.WriteData(0, DownAddress, BackWBuff);
                    int LinerCount = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(10);

                        //下位机在收到信息后需要将应答字修改为2 当下位机收到信息后将下传的信息清空
                        if (GetTickCount() - LinerCount > 1000) //超时处理1秒
                        {
                            SysBusinessFunction.WriteLog("下传取料信号成功，等待反馈信号超时");
                            break;
                        }
                        object[] RBuf1 = new object[1];
                        ControlMaster.ReadData(0, DownAddress+1, 1, out RBuf1);
                        if (RBuf1[0].ToString() == "2")
                        {
                            
                            SysBusinessFunction.WriteLog("下传取料信号成功，等待反馈信号成功");
                            RBuf1[0] = 0;
                            ControlMaster.WriteData(0, DownAddress+1, RBuf1);
                            break;
                        }
                    }
                }
                else
                {
                    OptionSetting.Eqty = "-1";
                    SysBusinessFunction.SystemDialog(2, "请关闭所有网格门后再扫码\n\rPlease close all grid doors before scanning");
                    closeFlag = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //判断数量是否为数字
            int pnum = 0;
            if(lbl_Number.Text.ToString().Trim().Length == 0)
            {
                SysBusinessFunction.SystemDialog(2, "输入的数量不是为空！");
                return;
            }
            try
            {
                pnum = Convert.ToInt32(lbl_Number.Text.ToString().Trim());
            }
            catch
            {
                SysBusinessFunction.SystemDialog(2, "输入的数量不是数字！");
                return;
            }
            if (pnum < 0)
            {
                SysBusinessFunction.SystemDialog(2, "输入的数量小于0！");
                return;
            }
            try
            {
                int address = 166;
                object[] RBuff = new object[1];
                ControlMaster.ReadData(0, address, 1, out RBuff);
                String ss = Convert.ToString((int)RBuff[0],2).PadLeft(16, '0');
                ArrayList list = new ArrayList();
                for (int i = 0; i < ss.Length; i++)
                {
                    if ('1' == ss[i])
                    {
                        list.Add(16-i);
                    }
                }
                if (list.Count == 0)//没有网格门打开
                {
                   SysBusinessFunction.WriteLog("网格门没有打开！！");

                }
                else//网格门开启
                {
                    //int Daddress = 166;
                    object[] Buff = new object[2];
                    Buff[1] = 1;
                    if (list.Count > 1)
                    {
                        SysBusinessFunction.WriteLog("打开多个网格门!!");
                        SysBusinessFunction.SystemDialog(1, "警告:打开多个网格门!\n\rWarning: open multiple mesh doors");
                    }
                    else
                    {
                        if (lbl_EBinNo.Text == list[0].ToString())
                        {
                            SysBusinessFunction.WriteLog("网格门打开正确!!");
                            SysBusinessFunction.WriteLog("网格号：【" + OptionSetting.Ebinno + "】放料成功！");
                            //修改数据
                            //实际数量总在不断地变化，所以修改实际数量时要获取当前最新的实际数量来修改
                            string gsql = String.Format(@"SELECT
	                                          Material_Actual_Qty
                                         FROM
	                                          IMOS_TA_Energy_List
                                        WHERE
	                                       Bin_No = {0} AND Company_Code = '{1}'  AND Factory_Code = '{2}'  AND Product_Line_Code ='{3}' ", OptionSetting.Ebinno,
                                                      BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,  BaseSystemInfo.ProductLineCode);
                            DataSet ds = DataHelper.Fill(gsql);
                            int NActual_Qty = int.Parse(ds.Tables[0].Rows[0]["Material_Actual_Qty"].ToString().Trim());
                            String sql = String.Format(@"UPDATE IMOS_TA_Energy_List SET Material_Actual_Qty = {0} where Bin_No = '{1}'",
                                                      NActual_Qty + pnum, lbl_EBinNo.Text.ToString().Trim());
                            DataHelper.Fill(sql);

                        }
                        else
                        {
                            SysBusinessFunction.WriteLog("网格门打开错误!!");
                            SysBusinessFunction.SystemDialog(1, "警告:网格门错误!\n\r Warning: mesh door opening error");                  
                        }

                    }
                    //清空
                    object[] WBuff = new object[1];
                    WBuff[0] = 0;
                    ControlMaster.WriteData(0, address, WBuff);
                    //int LinerCount = GetTickCount();
                    //while (true)
                    //{
                    //    Thread.Sleep(10);
                    //    //Application.DoEvents();
                    //    //下位机在收到信息后需要将应答字修改为2 当下位机收到信息后将下传的信息清空
                    //    if (GetTickCount() - LinerCount > 20000) //超时处理1秒
                    //    {
                    //        SysBusinessFunction.WriteLog("下传报警信号成功，等待反馈信号超时");
                    //        break;
                    //    }
                    //    object[] RBuf1 = new object[1];
                    //    ControlMaster.ReadData(0, Daddress, 1, out RBuf1);
                    //    if (RBuf1[0].ToString() == "2")
                    //    {
                    //        SysBusinessFunction.WriteLog("下传报警信号成功，接受反馈信号成功");
                    //        RBuf1[0] = 0;
                    //        ControlMaster.WriteData(0, address, RBuf1);
                    //        break;
                    //    }
                    //}

                    this.Close();
                }
             

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("增加能效贴数量出错！" + ex.Message);
            }
            finally
            {
                //this.Close();
            }


        }

        private void lbl_Number_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(@"C:\WINDOWS\system32\osk.exe");
        }

        private void timer1_Tick(object sender, EventArgs e)//不断更新实际数量
        {
            if (closeFlag)
            {
                this.Close();
            }
            string gsql = String.Format(@"SELECT
	                                          Material_Actual_Qty
                                         FROM
	                                          IMOS_TA_Energy_List
                                        WHERE
	                                       Bin_No = {0} AND Company_Code = '{1}' AND Company_Name = '{2}' AND Factory_Code = '{3}' AND Factory_Name='{4}' AND Product_Line_Code ='{5}' AND Product_Line_Name='{6}'", OptionSetting.Ebinno,
                                         BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);
            DataSet ds = DataHelper.Fill(gsql);
            lbl_ENum.Text = ds.Tables[0].Rows[0]["Material_Actual_Qty"].ToString().Trim();
            ////根据实际数量所占理论数量的比例来调整背景颜色
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
