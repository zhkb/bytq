using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarPrint
{
    using Sys.Utilities;
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using ControlLogic.Control;
    using PickingMonitor;

    public partial class MainForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadChildrenForm(string assemblyName, string formName)
        {
            if (formName.Length == 0)
            {
                return;
            }

            foreach (Form childrenForm in Application.OpenForms)
            {
                if (childrenForm.Name == formName)
                {
                    childrenForm.Visible = true;
                    childrenForm.WindowState = FormWindowState.Maximized;
                    childrenForm.Activate();
                    return;
                }
            }
            //// 一些特殊的页面处理。
            switch (formName)
            {
                case "FormLogOn":
                    // 关闭所有打开的窗口
                    foreach (Form childrenForm in Application.OpenForms)
                    {
                        childrenForm.Close();
                    }
                    this.ShowChildrenForm(assemblyName, formName);
                    break;
                case "FrmMessage":

                    foreach (Form childrenForm in Application.OpenForms)
                    {
                        if (childrenForm.Name == formName)
                        {
                            childrenForm.Visible = true;
                            childrenForm.Activate();
                            return;
                        }
                    }

                    ShowSDIForm(assemblyName, formName);
                    break;
                default:
                    this.ShowChildrenForm(assemblyName, formName);
                    return;
            }
        }

        private Form ShowSDIForm(string assemblyName, string formName)
        {
            Form childrenForm = (Form)CacheManager.Instance.CreateInstance(assemblyName, formName);

            if (childrenForm != null)
            {
                childrenForm.Name = formName;
                //childrenForm.MdiParent = this;
                childrenForm.ShowInTaskbar = true;
                childrenForm.WindowState = FormWindowState.Maximized;
                //if (childrenForm is IBaseForm)
                //{
                //    ((IBaseForm)childrenForm).OnButtonStateChange += new BaseForm.SetControlStateEventHandler(SetControlState);
                //}
                childrenForm.ShowIcon = false;
                childrenForm.Show();
                childrenForm.Activate();
            }
            return childrenForm;
        }

        private Form ShowChildrenForm(string assemblyName, string formName)
        {
            //TabPage MDIPage = new TabPage();
            //tabControl1.TabPages.Add(MDIPage);
            try
            {
                Form childrenForm = (Form)CacheManager.Instance.CreateInstance(assemblyName, formName);
                childrenForm.Name = formName;
                childrenForm.TopLevel = false;
                childrenForm.MdiParent = this;
                childrenForm.ShowIcon = true;
                //   childrenForm.FormBorderStyle = FormBorderStyle.no;
                childrenForm.ControlBox = true;
           //     childrenForm.Dock = DockStyle.Fill;

                childrenForm.Show();
                childrenForm.WindowState = FormWindowState.Maximized;
                return childrenForm;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private void BarPrintForm_Load(object sender, EventArgs e)
        {
            ControlMaster.SystemInitialization();
            //ControlInStore.SystemInitialization();
            ControlOutStore.SystemInitialization();
            //ControlBox = false;
            WindowState = FormWindowState.Maximized;
            SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态
            //ControlInStore.SystemInitialization();
            LoadChildrenForm("PickingMonitor", "FrmOperationMonitor");
            //LoadChildrenForm("PickingMonitor", "FrmStoreMonitor");
            lbl_SystemTitle.Text = "中德澳柯玛智能冷链立体库监控系统";
            FrmNewStoreMonitor fsm = new FrmNewStoreMonitor();
            fsm.Show();
            Application.DoEvents();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (OptionSetting.PLCStatus)
            {
                lbl_PLCStatus.ImageIndex = 11;
            }
            else
            {
                lbl_PLCStatus.ImageIndex = 12;
            }


            if (OptionSetting.ScanStatus)
            {
                lbl_ScanStatus.ImageIndex = 11;
            }
            else
            {
                lbl_ScanStatus.ImageIndex = 12;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确认退出系统？");

            if (r != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
