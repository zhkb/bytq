using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace MainFrame
{
    using Monitor;
    using Sys.Config;
    using Sys.SysBusiness;
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // 主应用程序集名
                    BaseSystemInfo.MainAssembly = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

                    ConfigHelper.GetConfig();

                    bool UpdateFlag = SysBusinessFunction.CheckUpdateInfo(); 

                    // 按配置的登录页面进行登录，这里需要运行的是主程序才可以

                    Application.Run(new MainForm());

                }
                else
                {
                    MessageBox.Show("程序已启动，请勿重复运行!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
