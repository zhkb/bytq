using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BarPrint
{
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

                    ConfigHelper.GetConfig();

                    try
                    {
                        Application.Run(new MainForm());
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("系统已启动，请不要重复运行!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
