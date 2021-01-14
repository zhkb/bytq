//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DotNet.WinForm.LogOn
{
    using DotNet.Model;
    using DotNet.Service;
    using DotNet.Utilities;
    using DotNet.WinForm.Utilities;

    /// <summary>
    /// FrmLogOn
    /// 用户登录系统
    /// 
    /// 修改纪录
    /// 
    ///		2010.10.17 版本：2.1 JiRiGaLa 多次输入错误密码后，要求有提示信息再退出程序。
    ///		2010.09.19 版本：2.0 JiRiGaLa 完善记住密码功能，密码按加密方式保存。
    ///		2010.02.26 版本：1.6 JiRiGaLa 只有内部用户才能登录。
    ///		2009.01.19 版本：1.5 JiRiGaLa SAP登录问题解决。
    ///		2009.01.19 版本：1.4 JiRiGaLa 下拉框为用户的真实姓名问题解决。
    ///		2008.03.21 版本：1.3 JiRiGaLa 用户名密码不能记录的错误进行改进。
    ///		2007.09.17 版本：1.2 JiRiGaLa 窗体上按 ESC 按钮退不出的错误修正。
    ///		2007.08.05 版本：1.1 JiRiGaLa 用户名记录起来，提示信息显示，默认允许登录次数。
    ///		2007.06.12 版本：1.0 JiRiGaLa 整理文件。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmLogOn : BaseForm
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserTable.TableName);

        /// <summary>
        /// 允许错误登录次数
        /// </summary>
        private int AllowLogOnCount = 3; 

        /// <summary>
        /// 已登录次数
        /// </summary>
        private int LogOnCount = 0;
        
        public FrmLogOn()
        {
            InitializeComponent();
        }

        #region public override void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region public override void SetControlState() 设置按钮状态
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        public override void SetControlState()
        {
            if (BaseSystemInfo.LogOned)
            {
                this.Text = AppMessage.MSGReLogOn;
            }
            // 是否允许申请密码
            this.btnRequestAnAccount.Visible = BaseSystemInfo.AllowUserRegister;
            // 是否必须输入密码
            this.labPasswordReq.Visible = !BaseSystemInfo.AllowNullPassword;
            // 已登录了？还是未登录状态
            if (BaseSystemInfo.LogOned)
            {
                this.CancelButton = this.btnCancel;
                this.btnCancel.Show();
                this.btnExit.Hide();
            }
            else
            {
                this.CancelButton = this.btnExit;
                this.btnExit.Show();
                this.btnCancel.Hide();
            }
        }
        #endregion

        #region private void GetLogOnInfo() 获取现有的登录信息
        /// <summary>
        /// 获取现有的登录信息
        /// </summary>
        private void GetLogOnInfo()
        {
            if (this.chkRememberPassword.Checked)
            {
                string userName = BaseSystemInfo.CurrentUserName;
                DataRowView dataRowView = null;
                for (int i = 0; i < this.cmbUser.Items.Count; i++)
                {
                    dataRowView = (DataRowView)this.cmbUser.Items[i];
                    if (dataRowView[BaseUserTable.FieldUserName].ToString().Equals(userName))
                    {
                        this.cmbUser.SelectedIndex = i;
                        break;
                    }
                }
                // 对密码进行解密操作
                string password = BaseSystemInfo.CurrentPassword;
                password = SecretUtil.Decrypt(password);
                this.txtPassword.Text = password;
                
                // 写入注册表信息，这个往往是会遇到安全问题，出现异常等
                /*
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName, false);
                if (registryKey != null)
                {
                    // 这里是保存用户名的读取，对用户名进行解密操作
                    string userName = (string)registryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                    userName = SecretUtil.Decrypt(userName);
                    DataRowView dataRowView = null;
                    for (int i = 0; i < this.cmbUser.Items.Count; i++)
                    {
                        dataRowView = (DataRowView)this.cmbUser.Items[i];
                        if (dataRowView[BaseUserTable.FieldUserName].ToString().Equals(userName))
                        {
                            this.cmbUser.SelectedIndex = i;
                            // this.cmbUser.SelectedItem = this.cmbUser.Items[i];
                            // this.cmbUser.SelectedValue = userName;
                            break;
                        }
                    }
                    // 对密码进行解密操作
                    string password = (string)registryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    password = SecretUtil.Decrypt(password);
                    this.txtPassword.Text = password;
                }
                */
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 这里是按职员登录
            // this.DTUser = ServiceManager.Instance.LogOnService.GetStaffDT(UserInfo);
            // 这里是按用户登录
            this.DTUser = ServiceManager.Instance.LogOnService.GetUserDT(UserInfo);
            
            // 职员需要按用户名排序问题解决
            // this.DTUser.DefaultView.Sort = BaseUserTable.FieldSortCode;
            // 解决用户名密码记不住的问题
            // foreach (DataRowView dataRowView in this.DTUser.DefaultView)
            // {
            //     this.cmbUser.Items.Add(dataRowView[BaseUserTable.FieldUserName].ToString());
            // }
            // 显示用户真实姓名，保存用户名
            this.cmbUser.DataSource = this.DTUser.DefaultView;
            this.cmbUser.DisplayMember = BaseUserTable.FieldRealName;
            this.cmbUser.ValueMember = BaseUserTable.FieldUserName;

            // 保存密码
            this.chkRememberPassword.Checked = BaseSystemInfo.RememberPassword; 
            // 获取现有的登录信息
            this.GetLogOnInfo();
            // 默认焦点在用户名输入上
            this.cmbUser.Focus();
            
            // 当前的输入焦点停留在密码编辑框上，呵呵不错的改进。
            if (this.cmbUser.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
            this.Localization(this);
        }
        #endregion

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 是否没有输入用户名
            if (this.cmbUser.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbUser.Focus();
                return false;
            }
            if (!BaseSystemInfo.AllowNullPassword)
            {
                if (this.txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    return false;
                }
            }
            this.btnConfirm.Focus();
            return true;
        }
        #endregion

        #region private bool CheckAllowLogOnCount() 允许登录次数已经到了
        /// <summary>
        /// 允许登录次数已经到了
        /// </summary>
        /// <returns>继续允许输入</returns>
        private bool CheckAllowLogOnCount()
        {
            if (this.LogOnCount >= this.AllowLogOnCount)
            {
                // 控件重新设置状态
                this.txtPassword.Clear();
                this.cmbUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;

                // 进行提示信息，不能再输入了，已经错误N次了。
			     MessageBox.Show(AppMessage.Format(AppMessage.MSG0211, this.AllowLogOnCount.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				 return false;

            }
            return true;
        }
        #endregion

        #region private bool LogOn()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool LogOn()
        {
            // 忙状态
            this.Cursor = Cursors.WaitCursor;
            // 已经登录次数 ++
            this.LogOnCount++;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                string userName = this.cmbUser.SelectedValue.ToString();
                BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.UserLogOn(UserInfo, userName, this.txtPassword.Text, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OK.ToString())
                {
                    // 检查身份
                    if ((userInfo != null) && (userInfo.Id.Length > 0))
                    {
                        // 用户登录，保存登录信息
                        this.LogOn(userInfo);
                        // 保存登录信息
                        this.SaveLogOnInfo(userInfo);                        
                        // 这里是登录功能部分
                        if (this.Parent == null)
                        {
                            this.Hide();
                            if (!BaseSystemInfo.LogOned)
                            {
                                Form mainForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.MainForm);
                                ((IBaseMainForm)mainForm).InitService();
                                ((IBaseMainForm)mainForm).InitForm();
                                mainForm.Show();
                            }
                        }
                        // 这里表示已经登录系统了
                        BaseSystemInfo.LogOned = true;
                        // 登录次数归零，允许重新登录
                        this.LogOnCount = 0;
                        // 打开这个窗体的主窗口
                        if (this.Owner != null)
                        {
                            ((IBaseMainForm)this.Owner).InitForm();
                            ((IBaseMainForm)this.Owner).CheckMenu();                            
                            return true;
                        }
                        if (this.Parent != null)
                        {
                            // 重新获取登录状态信息
                            ((IBaseMainForm)this.Parent.Parent).InitService();
                            ((IBaseMainForm)this.Parent.Parent).InitForm();
                            ((IBaseMainForm)this.Parent.Parent).CheckMenu();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    this.txtPassword.SelectAll();
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 已经忙完了
                this.Cursor = Cursors.Default;
            }
            return true;
        }
        #endregion	

        #region private void LogOn(BaseUserInfo userInfo) 职员登录，保存登录信息
        /// <summary>
        /// 职员登录，保存登录信息
        /// </summary>
        /// <param name="userInfo">职员实体</param>
        private void LogOn(BaseUserInfo userInfo)
        {
            BaseSystemInfo.LogOn(userInfo);
        }
        #endregion

        #region private void SaveLogOnInfo(BaseUserInfo userInfo) 将登录信息保存到注册表中
        /// <summary>
        /// 将登录信息保存到注册表中。
        /// 若不保存用户名密码，那就应该删除掉。
        /// </summary>
        /// <param name="userInfo">登登录用户</param>
        private void SaveLogOnInfo(BaseUserInfo userInfo)
        {
            BaseSystemInfo.RememberPassword = this.chkRememberPassword.Checked;
            if (this.chkRememberPassword.Checked)
            {
                BaseSystemInfo.CurrentUserName = userInfo.UserName;
                // BaseSystemInfo.CurrentUserName = SecretUtil.Encrypt(userInfo.UserName);
                BaseSystemInfo.CurrentPassword = SecretUtil.Encrypt(this.txtPassword.Text);
            }
            else
            {
                BaseSystemInfo.CurrentUserName = string.Empty;
                BaseSystemInfo.CurrentPassword = string.Empty;
            }
            ConfigHelper.SaveConfig();
            
            /*
            // 写入注册表，有时候会没有权限，发生异常信息等，可以考虑写入XML文件
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName);
            if (this.chkRememberPassword.Checked)
            {
                // 默认的信息写入注册表,呵呵需要改进一下
                registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, SecretUtil.Encrypt(userInfo.UserName));
                registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, SecretUtil.Encrypt(this.txtPassword.Text));
            }
            else
            {
                registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, string.Empty);
                registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, string.Empty);
            }
            */
        }
        #endregion

        private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // 检查输入的有效性
                if (this.CheckInput())
                {
                    // 用户登录
                    this.LogOn();
                }
            }
        }

        private void btnRequestAnAccount_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm.User";
            string formName = "FrmRequestAnAccount";
            Form frmRequestAnAccount = CacheManager.Instance.GetForm(assemblyName, formName);
            if (frmRequestAnAccount.ShowDialog() == DialogResult.OK)
            {
                // 不能老申请账户吧，当作攻击的一种类型
                this.btnRequestAnAccount.Enabled = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 验证用户输入
            if (this.CheckInput())
            {
                // 用户登录
                this.LogOn();
                // 允许登录次数已经到了
                this.CheckAllowLogOnCount();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // 退出应用程序
            Application.Exit();
        }
    }
}