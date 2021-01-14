using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Setting
{
    public partial class FrmBarSetting : Form
    {
        private ArrayList BarFormList = new ArrayList(); //条码设备详细信息标签

        public FrmBarSetting()
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

        private void FrmBarSetting_Load(object sender, EventArgs e)
        {
            
            LoadMonitorForm();
        }

        private void LoadMonitorForm() //设置相关库存显示
        {
            //tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            panel1.Width = 631;
            panel2.Width = 631;
            panel3.Width = 631;
            for (int i = 0; i < 15; i++)
            {
                Application.DoEvents();
                #region 创建显示窗体
                //Panel TempPnl = new Panel();
                //TempPnl.BorderStyle = BorderStyle.FixedSingle;
                //TempPnl.Height = 142;
                //TempPnl.Width = 631;

                //TempPnl.Left = 0;
                FrmBarDetial PlanDetialForm = new FrmBarDetial();
                PlanDetialForm.TopLevel = false;

                PlanDetialForm.FormBorderStyle = FormBorderStyle.None;
                if ((i >= 0) && (i < 6))
                {                    
                    PlanDetialForm.Parent = panel1;                          
                }

                if ((i >= 6) && (i < 12))
                {
                    PlanDetialForm.Parent = panel2;

                }
                if ((i >= 12) && (i < 15))
                {
                    PlanDetialForm.Parent = panel3;
                   
                }
                PlanDetialForm.Left = 1;
                PlanDetialForm.Width = 629;
                PlanDetialForm.Top = (i % 6) * 148 + 3;
                PlanDetialForm.Height = 143;
                BarFormList.Add(PlanDetialForm);


             //   PlanDetialForm.Dock = DockStyle.Fill;
                PlanDetialForm.BarNo = i + 1;
                PlanDetialForm.Show();

                //SysBusinessFunction.BarInfoList[i].BarNo = (i + 1).ToString();
                //SysBusinessFunction.StoreInfoList[i].StoreQty = 20;
                //SysBusinessFunction.StoreInfoList[i].TransitQty = 0;
                //SysBusinessFunction.StoreInfoList[i].InFlag = true;
                //SysBusinessFunction.StoreInfoList[i].OutFlag = true;
                //SysBusinessFunction.StoreInfoList[i].AbNormal = false;
                //SysBusinessFunction.StoreInfoList[i].UseFlag = true;

                #endregion
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle rec = tabControl1.ClientRectangle;
           
            StringFormat StrFormat = new StringFormat();

            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中

            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中        
            Font font = new System.Drawing.Font("微软雅黑", 18F);//设置标签字体样式
            SolidBrush bruFont = new SolidBrush(Color.White);// 标签字体颜色
            SolidBrush bru = new SolidBrush(Color.FromArgb(33, 76, 111));
            e.Graphics.FillRectangle(bru, rec);
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //获取标签头的工作区域

                Rectangle recChild = tabControl1.GetTabRect(i);

                //绘制标签头背景颜色

                e.Graphics.FillRectangle(bru, recChild);

                //绘制标签头的文字

                e.Graphics.DrawString(tabControl1.TabPages[i].Text, font, bruFont, recChild, StrFormat);

            }
        }
    }
}
