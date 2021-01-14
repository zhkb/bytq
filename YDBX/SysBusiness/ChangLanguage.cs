using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Sys.Language
{
    public class ChangLanguage
    {
        #region SetAllLang
        /// <summary>
        /// �������д���Ľ�������
        /// </summary>
        /// <param name="lang">language:zh-CN, en-US</param>
        public static void SetAllLang(string lang)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            Form frm = null;
            //string path = AssemblyName.GetAssemblyName("PMISServer").ToString();//��Ŀ��Assemblyѡ������
            //Assembly asm = Assembly.Load("PMISServer");//������
            //        object frmObj = asm.CreateInstance("Fastyou.BookShop.Win." + formName);//����+form��������
            string name = "MainForm"; //�������

            frm = (Form)Assembly.Load("PMISServer").CreateInstance(name);

            //Type formType = null;
            //formType = typeof(frm);

            if (frm != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager();
                resources.ApplyResources(frm, "$this");
                AppLang(frm, resources);
            }
        }
        #endregion

        #region SetLang
        /// <summary>
        /// ���õ�ǰ����Ľ�������
        /// </summary>
        /// <param name="lang">language:zh-CN, en-US</param>
        /// <param name="form">����ʵ��</param>
        /// <param name="formType">��������</param>
        public static void SetLang(string lang, Form form, Type formType)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            if (form != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                AppLang(form, resources);
            }
        }
        #endregion

        #region AppLang for control
        /// <summary>
        /// �����������пؼ�����������õ�ǰ��������
        /// </summary>
        /// <param name="control"></param>
        /// <param name="resources"></param>
        private static void AppLang(Control control, System.ComponentModel.ComponentResourceManager resources)
        {
            if (control is MenuStrip)
            {
                //����ԴӦ�����Ӧ������
                resources.ApplyResources(control, control.Name);
                MenuStrip ms = (MenuStrip)control;
                if (ms.Items.Count > 0)
                {
                    foreach (ToolStripMenuItem c in ms.Items)
                    {
                        //���� �����˵� ��������
                        AppLang(c, resources);
                    }
                }
            }

            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                AppLang(c, resources);
            }
        }
        #endregion

        #region AppLang for menuitem
        /// <summary>
        /// �����˵�
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resources"></param>
        private static void AppLang(ToolStripMenuItem item, System.ComponentModel.ComponentResourceManager resources)
        {
            if (item is ToolStripMenuItem)
            {
                resources.ApplyResources(item, item.Name);
                ToolStripMenuItem tsmi = (ToolStripMenuItem)item;
                if (tsmi.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem c in tsmi.DropDownItems)
                    {
                        //if (tsmi != ToolStripSeparator)
                        //{ }
                        AppLang(c, resources);
                    }
                }
            }
        }
        #endregion
    }
}