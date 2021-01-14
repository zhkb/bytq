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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor.BoxBodyStore
{
    public partial class FrmManual : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        public static Color[] PortColor = { Color.Silver, Color.Lime };
        public FrmManual()
        {
            InitializeComponent();
        }

        private void lbl_A_Port_Click(object sender, EventArgs e)
        {
            Label lblPort = (Label)sender;
            lb_A_BinNo.Text = lblPort.Text;
            lbl_A_Port1.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "1")];
            lbl_A_Port2.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "2")];
            lbl_A_Port3.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "3")];
            lbl_A_Port4.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "4")];
            lbl_A_Port5.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "5")];
            lbl_A_Port6.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "6")];
            lbl_A_Port7.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "7")];
            lbl_A_Port8.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "8")];
            lbl_A_Port9.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "9")];
            lbl_A_Port10.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "10")];
            lbl_A_Port11.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "11")];
            lbl_A_Port12.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "12")];
            lbl_A_Port13.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "13")];
        }

        private void lbl_B_Port_Click(object sender, EventArgs e)
        {
            Label lblPort = (Label)sender;
            lb_B_BinNo.Text = lblPort.Text;
            lbl_B_Port1.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "1")];
            lbl_B_Port2.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "2")];
            lbl_B_Port3.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "3")];
            lbl_B_Port4.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "4")];
            lbl_B_Port5.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "5")];
            lbl_B_Port6.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "6")];
            lbl_B_Port7.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "7")];
            lbl_B_Port8.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "8")];
            lbl_B_Port9.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "9")];
            lbl_B_Port10.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "10")];
            lbl_B_Port11.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "11")];
            lbl_B_Port12.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "12")];
            lbl_B_Port13.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "13")];
        }

        private void btn_A_Clean_Click(object sender, EventArgs e)
        {
            lb_A_BinNo.Text = "";
            lbl_A_Port1.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "1")];
            lbl_A_Port2.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "2")];
            lbl_A_Port3.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "3")];
            lbl_A_Port4.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "4")];
            lbl_A_Port5.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "5")];
            lbl_A_Port6.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "6")];
            lbl_A_Port7.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "7")];
            lbl_A_Port8.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "8")];
            lbl_A_Port9.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "9")];
            lbl_A_Port10.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "10")];
            lbl_A_Port11.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "11")];
            lbl_A_Port12.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "12")];
            lbl_A_Port13.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "13")];


        }

        private void btn_B_Clean_Click(object sender, EventArgs e)
        {
            lb_B_BinNo.Text = "";
            lbl_B_Port1.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "1")];
            lbl_B_Port2.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "2")];
            lbl_B_Port3.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "3")];
            lbl_B_Port4.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "4")];
            lbl_B_Port5.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "5")];
            lbl_B_Port6.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "6")];
            lbl_B_Port7.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "7")];
            lbl_B_Port8.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "8")];
            lbl_B_Port9.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "9")];
            lbl_B_Port10.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "10")];
            lbl_B_Port11.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "11")];
            lbl_B_Port12.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "12")];
            lbl_B_Port13.BackColor = PortColor[Convert.ToInt32(lb_A_BinNo.Text == "13")];
        }

        private void btn_A_Ok_Click(object sender, EventArgs e)
        {
            string Store_Code = "2001";
            try
            {
                if (lb_A_BinNo.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请选择A货道号。" + Environment.NewLine + "Please select A goods lane number");
                    return;
                }
                int BinNo = int.Parse(lb_A_BinNo.Text.Trim());
                btn_A_Ok.Enabled = false;
                int DataAddress = 0;
                int DataLen = 0;
                DataAddress = int.Parse(BaseSystemInfo.AFDAddress);
                DataLen = int.Parse(BaseSystemInfo.AFDlength);
                object[] Buf = new object[DataLen];
                Buf[0] = 1;
                Buf[1] = BinNo;
                bool PLCWrite = ControlBoxBodyStoreData.MasterPLC.Write(0, DataAddress, Buf);

                if (!PLCWrite)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "PLC连接失败.");
                    return;
                }
                int AStackCount = GetTickCount();
                bool DownFlag = false;
                while (true)
                {
                    Thread.Sleep(5);
                    //下位机在收到货道信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                    if (Math.Abs(GetTickCount() - AStackCount) > 5000) //超时处理 5秒钟内没有回复则认为超时
                    {
                        break;
                    }

                    object[] StackBuff = new object[2];
                    ControlBoxBodyStoreData.MasterPLC.Read("0", DataAddress, DataLen, out StackBuff);

                    if (StackBuff[0].ToString() == "2")//下传PLC成功
                    {
                        AddInDetail(BinNo.ToString(),"1", Store_Code);
                        AddBinDetail( BinNo.ToString(), Store_Code);
                        DownFlag = true;

                        //清空PLC数据
                        StackBuff[0] = 0;
                        StackBuff[1] = 0;
                        ControlBoxBodyStoreData.MasterPLC.Write(0, DataAddress, StackBuff);

                        break;
                    }
                }

                if (DownFlag)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "A下传货道成功." + Environment.NewLine + "B Successful transmission");
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "A下传货道失败或未反馈." + Environment.NewLine + "B Failed transmission or failed to give feedback");
                }







            }
            catch (Exception ex)
            {

            }
            finally {
                btn_A_Ok.Enabled = true;

            }


        }

        private static void AddInDetail(string BinNo, string WorkstationNo, string Store_Code)
        {

            try
            {
                string sql = "";
                sql = string.Format(@" Insert Into IMOS_LIST_IN_Detail(Company_Code,Factory_Code,Product_Line_Code,Workstation_No,Bin_No,Creation_Date,Created_By,type,Process_Code) 
                                               Values ( '{0}','{1}','{2}','{3}',{4},GETDATE(),'{5}','{6}','{7}');"
                           , BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, WorkstationNo, BinNo, BaseSystemInfo.CurrentUserID,'2',BaseSystemInfo.CurrentProcessCode);

                DataHelper.Fill(sql);

            }
            catch
            {


            }

        }

        private static void AddBinDetail(string BinNo, string Store_Code)
        {

            try
            {
                string sql = "";
                sql = string.Format(@" Insert Into IMOS_Lo_Bin_Detail(Company_Code,Factory_Code,Product_Line_Code,Store_Code,Bin_No,Material_Status,Create_Time,Process_Code) 
                                               Values ( '{0}','{1}','{2}','{3}','{4}',{5},GETDATE(),'{6}');"
                           , BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Store_Code, BinNo, 0, BaseSystemInfo.CurrentProcessCode);

                DataHelper.Fill(sql);

            }
            catch(Exception ex)
            {


            }

        }



        private void btn_B_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string Store_Code = "2002";
                if (lb_B_BinNo.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请选择B货道号。" + Environment.NewLine + "Please select B goods lane number");
                    return;
                }
                int BinNo = int.Parse(lb_B_BinNo.Text.Trim());
                btn_B_Ok.Enabled = false;
                int DataAddress = 0;
                int DataLen = 0;
                DataAddress = int.Parse(BaseSystemInfo.BFDAddress);
                DataLen = int.Parse(BaseSystemInfo.BFDlength);
                object[] Buf = new object[DataLen];
                Buf[0] = 1;
                Buf[1] = BinNo;
                bool PLCWrite = ControlBoxBodyStoreData.MasterPLC.Write(0, DataAddress, Buf);

                if (!PLCWrite)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "PLC连接失败.");
                    return;
                }
                int BStackCount = GetTickCount();
                bool DownFlag = false;
                while (true)
                {
                    Thread.Sleep(5);
                    //下位机在收到货道信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                    if (Math.Abs(GetTickCount() - BStackCount) > 5000) //超时处理 5秒钟内没有回复则认为超时
                    {
                        break;
                    }

                    object[] StackBuff = new object[2];
                    ControlBoxBodyStoreData.MasterPLC.Read("0", DataAddress, DataLen, out StackBuff);

                    if (StackBuff[0].ToString() == "2")//下传PLC成功
                    {
                        AddInDetail(BinNo.ToString(), "2", Store_Code);
                        AddBinDetail(BinNo.ToString(), Store_Code);
                        DownFlag = true;

                        //清空PLC数据
                        StackBuff[0] = 0;
                        StackBuff[1] = 0;
                        ControlBoxBodyStoreData.MasterPLC.Write(0, DataAddress, StackBuff);

                        break;
                    }
                }


                if (DownFlag)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "B下传货道成功."+ Environment.NewLine+ "B Successful transmission");
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "B下传货道失败或未反馈." + Environment.NewLine + "B Failed transmission or failed to give feedback");
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                btn_A_Ok.Enabled = true;

            }
        }
    }
}
