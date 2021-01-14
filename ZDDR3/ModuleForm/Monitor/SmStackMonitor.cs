using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Monitor
{
    public partial class SmStackMonitor : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        private bool rollDirectionFlag = true; //true向下滚动，false 向上滚动
        private int MaxButtonNum = 0;
        public System.Threading.Timer GetPlcDataTimer; //重新连接PLC
        private string NowBarCode = "";//正在码垛的产品条码
        private string OldBarCode = "";//旧码垛的产品条码

        public System.Threading.Timer GetMDStoreTimer;
        private string md1_Store;//码垛一正码库位号
        private string md2_Store; //码垛二正码库位号
        private string old_md1_Store;//码垛一码完库位号
        private string old_md2_Store; //码垛二码完库位号

        public SmStackMonitor()
        {
            InitializeComponent();
        }

        #region  定时刷新产量数据（轮播）
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (rollDirectionFlag)
                {
                    panel4.Top = panel4.Top - 240;
                }
                else
                {
                    panel4.Top = 0;
                }
                if (panel4.Top == MaxButtonNum || panel4.Top == 0)
                {
                    rollDirectionFlag = !rollDirectionFlag;
                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 界面加载
        private void StackMonitor_Load(object sender, EventArgs e)
        {

            LoadPanel();
            GetPlcDataTimer = new System.Threading.Timer(ReTry, null, 0, Timeout.Infinite);
            GetMDStoreTimer = new System.Threading.Timer(GetMDStore, null, 0, Timeout.Infinite); 
            panelGRIDL.Width = panelDOWN.Width / 2;
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Start();
        }

      
        #endregion

        #region 界面加载计划产量
        private void LoadPanel()
        {
            try
            {
                //获取今日计划数量-实际产量
                int num = 0;
                string sql = String.Format(@"SELECT prod_code,jihuashu,(case when isnull(wanchengshu) then 0 else wanchengshu end )as wanchengshu From view_15daysorderplancomplete WHERE  TO_DAYS(est) = TO_DAYS(NOW()) AND Production_Line_Code = '{0}' ", "3U");
                DataSet ds = DataHelper.MySqlFill(sql);
                if (ds != null)
                {
                    num = ds.Tables[0].Rows.Count;
                    if (num != -1)
                    {  
                        MaxButtonNum = (-1) * 240 * ((num - 1) / 8);
                        for (int i = 0; i < num; i++)
                        {
                            StackModify sm = new StackModify();
                            sm.TopLevel = false;
                            sm.Parent = panel4;
                            sm.Left = (i % 8) * 215;
                            sm.Top = (i / 8) * 240;
                            sm.MaterialCode = ds.Tables[0].Rows[i]["prod_code"].ToString();
                            sm.ActualNum = Convert.ToInt32(ds.Tables[0].Rows[i]["wanchengshu"]);
                            sm.PlanNum = Convert.ToInt32(ds.Tables[0].Rows[i]["jihuashu"]);
                            sm.Show();
                        }
                    }
                    if (num > 8)
                    {
                        timer1.Enabled = true;
                        timer1.Interval = 5000;
                        timer1.Start();
                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("加载计划数量出错！");
            }


        }
        #endregion

        #region 上传WMS
        private void sendWMS(string strBarcode, string strFactory)
        {
            try
            {

                string strInfo = "扫码:" + strBarcode;

                //定义传入参数
                Haier_WMS_Interface.mdjBhDTO F_mdjBhDTO = new Haier_WMS_Interface.mdjBhDTO();

                F_mdjBhDTO.barCode = strBarcode;
                F_mdjBhDTO.factoryCode = strFactory;

                //定义返回值参数
                Haier_WMS_Interface.transResult F_transResult = new Haier_WMS_Interface.transResult();
                Haier_WMS_Interface.RfWebServiceImplService F_RfWebServiceImplService = new Haier_WMS_Interface.RfWebServiceImplService();

                //设置webservice参数
                F_RfWebServiceImplService.Url = BaseSystemInfo.webServiceAddress;
                F_RfWebServiceImplService.Timeout = 5000;

                //调用接口函数       

                F_transResult = F_RfWebServiceImplService.StackerCraneBH(F_mdjBhDTO);
                //NowProductName = F_transResult.data.ToString();

                if (F_transResult.code == "1")
                {

                    //显示返回值,返回消息
                    strInfo = ", 下传库位号成功 ," + F_transResult.data;
                    lbl_WMSMsg.Text = "WMS下传成功";
                    lbl_WMSMsg.ForeColor = Color.Lime;
                    int storeno = GetStoreNo(F_transResult.data.ToString());
                    UpdateSql(1);//更新数据
                    DownPLC(storeno, F_transResult.data.ToString());//下传成功
                }
                else
                {
                    //显示返回值,返回消息
                    strInfo = ", 下传库位号失败 ," + F_transResult.data;

                    lbl_WMSMsg.Text = F_transResult.data.ToString();
                    lbl_WMSMsg.ForeColor = Color.Red;
                    UpdateSql(1);
                    
                    DownPLC(999, "BBBB");//下传失败
                }
                Pic_WMSStatus.Image = Monitor.Properties.Resources.Status_Green;
                SysBusinessFunction.WriteLog(strInfo);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("上传WMS失败！！");
                lbl_WMSMsg.Text = "WMS连接失败";
                lbl_WMSMsg.ForeColor = Color.Red;
                DownPLC(999, "AAAA");//下传失败
                Pic_WMSStatus.Image = Monitor.Properties.Resources.Status_Red;
            }
        }

        private int GetStoreNo(string scode)
        {
            try
            {
                int ino = 0;
                String sql = String.Format(@"if not exists (select 1 from IMOS_MD_Store where Store_Code ='{0}')
                                            begin
                                            INSERT INTO IMOS_MD_Store (Store_Code) VALUES ('{0}');
                                            end", scode);
                DataHelper.Fill(sql);
                String ssql = String.Format(@"select ID from IMOS_MD_Store where Store_Code ='{0}'", scode);
                DataSet ds = DataHelper.Fill(ssql);
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    SysBusinessFunction.WriteLog("查询库位编号【" + scode + "】成功!");
                    ino = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    return ino;
                }
                else
                {
                    SysBusinessFunction.WriteLog("查询库位编号【" + scode + "】出错!");
                    return 0;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region 记录表更新 

        private void UpdateSql(int v)
        {
            try
            {
                String sql = String.Format(@"Update maduo_record set Result_Flag = '{0}' where Prod_BarCode = '{1}'", v, NowBarCode);
                DataHelper.MySqlFill(sql);
            }
            catch
            {

            }

        }

        #endregion

        #region 库位下传

        private void DownPLC(int storeno, string storecode)//下传库位号
        {
            try
            {
                //应答字1位  下传库位号1位  
                int DataBlock = 0;
                int StartDataAddress = 1059;
                object[] WriteBuff = new object[2];
                object[] ReadBuff = new object[2];
                WriteBuff[0] = 1; //应答字                 
                WriteBuff[1] = storeno;
                bool PLCWriteFlag = ControlMaster.WriteData(DataBlock, StartDataAddress, WriteBuff);
                if (PLCWriteFlag)
                {
                    SysBusinessFunction.WriteLog("PLC 下传库位成功");
                    lbl_PLCResult.Text = "PLC 下传库位成功";
                    lbl_PLCResult.ForeColor = Color.Lime;
                }
                else
                {
                    SysBusinessFunction.WriteLog("PLC 下传库位失败");
                    lbl_PLCResult.Text = "PLC 下传库位失败";
                    lbl_PLCResult.ForeColor = Color.Red;
                }
                int CoamingTick = GetTickCount();
                while (true)
                {
                    Thread.Sleep(1);
                    if (GetTickCount() - CoamingTick < 5000) //超时退出 重新下传 超时时间为5秒
                    {
                        ControlMaster.ReadData(DataBlock, StartDataAddress, 2, out ReadBuff);
                        if ("2" == ReadBuff[0].ToString())//下位机接受数据
                        {
                            SysBusinessFunction.WriteLog("下位机接受库位【" + storecode + "】数据成功！");
                            object[] WBuff = new object[1];//置为0
                            WBuff[0] = 0;
                            ControlMaster.WriteData(0, StartDataAddress, WBuff);
                        }
                    }
                    else
                    {
                        SysBusinessFunction.WriteLog("机器人反馈换产信息超时！");
                        lbl_PLCResult.Text = "机器人响应超时！！";
                        lbl_PLCResult.ForeColor = Color.Red;
                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                lbl_PLCResult.Text = "PLC连接断开";
                lbl_PLCResult.ForeColor = Color.Red;
               
            }
        }
        #endregion

        #region  获取条码
        public void ReTry(object o)
        {
            try
            {
                Thread.Sleep(5);
                GetPLC();
            }
            catch
            {

            }
            finally
            {
                GetPlcDataTimer.Change(500, Timeout.Infinite);
            }
        }

        #endregion

        #region 上位机获取条码
        private void GetPLC()//从PLC获取产品条码
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    bool flag = false;
                    int Address = 1031;
                    int DataBlock = 0;
                    object[] readBuf = new object[10];
                    flag = ControlMaster.ReadData(DataBlock, Address, 10, out readBuf);
                    NowBarCode = "";
                    if (flag)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            NowBarCode = NowBarCode + SysBusinessFunction.BinaryToStr((int)readBuf[i]);
                        }
                        if (NowBarCode == OldBarCode)
                        {
                            return;
                        }
                        else
                        {
                            OldBarCode = NowBarCode;//产品码垛
                                                    // if (NowBarCode.Length == 20 && NowBarCode.Substring(0, 2) == "GA")
                                                    // {
                            SysBusinessFunction.WriteLog("产品条码【" + NowBarCode + "】");
                            lbl_BarCode.Text = NowBarCode;
                            lbl_ScanTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            InsertScan();
                            sendWMS(NowBarCode, BaseSystemInfo.FactoryNumber);//上传WMS
                            NowBarCode = "";
                            //  }
                            //else
                            //{
                            //    SysBusinessFunction.WriteLog("从PLC读取条码不正确！");
                            //}
                        }

                    }
                    else
                    {
                        SysBusinessFunction.WriteLog("PLC连接失败!!!");

                    }

                }
                catch (Exception ex)
                {

                }
            }));
        }
        #endregion

        #region 插入扫码记录
        private void InsertScan()
        {
            try
            {
                String sql = String.Format(@"Insert into  maduo_record (Prod_BarCode,Prod_Code,Prod_Name,Scan_Time,Result_Flag) values
                                                    ('{0}','{1}','{2}','{3}','{4}')", NowBarCode, NowBarCode, "", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0);
                DataHelper.MySqlFill(sql);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 获取码垛库位

        private void GetMDStore(object state)
        {
       
            try
            {
                int address = 1164;
                int len = 2;
                int DataBlock = 0;
                object[] ReadBuff = new object[len];

                bool PLCWriteFlag = ControlMaster.ReadData(DataBlock, address, len,out ReadBuff);

                if (PLCWriteFlag)
                {
                    md1_Store = SqlStoreCode(ReadBuff[0].ToString());//码垛一正在码的库位
                    md2_Store = SqlStoreCode(ReadBuff[1].ToString());//码垛二正在码的库位
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                GetMDStoreTimer.Change(1000, Timeout.Infinite);
            }
        }


        #endregion
        #region  获取库位号
        private String SqlStoreCode(string v)
        {
            try
            {
                String stcode = "";
                String ssql = String.Format(@"select Store_Code from IMOS_MD_Store where ID  = {0}", v);
                DataSet ds = DataHelper.Fill(ssql);
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    stcode = ds.Tables[0].Rows[0]["Store_Code"].ToString();
                    return stcode;
                }
                else
                {
                  
                    return "";

                }

            }
            catch(Exception ex)
            {
                return "";
            }
            
        }


        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ControlMaster.MasterPLCPLCConn)
            {
                pic_PlcState.Image = Monitor.Properties.Resources.Status_Green;
                if (md1_Store != old_md1_Store)
                {
                    
                    lbl_StoreCodeA.Text = old_md1_Store;
                    lbl_ANStoreCode.Text = md1_Store;
                    old_md1_Store = md1_Store;
                }
                if (md2_Store != old_md2_Store)
                {
                    
                    lbl_StoreCodeB.Text = old_md2_Store;
                    lbl_BNStoreCode.Text = md2_Store;
                    old_md2_Store = md2_Store;
                }
            }
            else
            {
                pic_PlcState.Image = Monitor.Properties.Resources.Status_Red;
            }
          



        }
    }
}
