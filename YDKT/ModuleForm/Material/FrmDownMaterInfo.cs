using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Material
{
    using Sys.Config;
    public partial class FrmDownMaterInfo : Form
    {
        public FrmDownMaterInfo()
        {
            InitializeComponent();
        }

        private void FrmDownMaterInfo_Load(object sender, EventArgs e)
        {
            int WidthValue = 410;
            groupBox1.Width = WidthValue;
            groupBox2.Width = WidthValue;
            groupBox3.Width = WidthValue;
            groupBox4.Width = WidthValue;

            if (BaseSystemInfo.SystemType == 1)
            {
                groupBox1.Text = "PVDF";
                groupBox2.Text = "SP";
                groupBox3.Text = "碳酸锂";
                groupBox4.Text = "CNT";
                
            }

            if (BaseSystemInfo.SystemType == 2)
            {
                groupBox1.Text = "CMC";
                groupBox2.Text = "SP";
                groupBox3.Text = "";
                groupBox3.Visible = false;
                groupBox4.Text = "SBR";
            }

            FrmMaterialList MaterialForm1 = new FrmMaterialList();
            MaterialForm1.FormBorderStyle = FormBorderStyle.None;
            MaterialForm1.TopLevel = false;
            MaterialForm1.Parent = groupBox1;
            MaterialForm1.MaterIndex = 0;
            if (BaseSystemInfo.SystemType == 1)
            {
                MaterialForm1.SourceType = "MT002"; //取得PVDF物料信息
            }

            if (BaseSystemInfo.SystemType == 2)
            {
                MaterialForm1.SourceType = "MT007";//取得CMC物料信息
            }

            MaterialForm1.Dock = DockStyle.Top;
            MaterialForm1.Show();

            FrmMaterialList MaterialForm2 = new FrmMaterialList();
            MaterialForm2.FormBorderStyle = FormBorderStyle.None;
            MaterialForm2.TopLevel = false;
            MaterialForm2.Parent = groupBox2;
            MaterialForm2.MaterIndex = 1;
            MaterialForm2.SourceType = "MT003";
            MaterialForm2.Dock = DockStyle.Top;
            MaterialForm2.Show();

            if (BaseSystemInfo.SystemType == 1)
            {
                FrmMaterialList MaterialForm3 = new FrmMaterialList();
                MaterialForm3.FormBorderStyle = FormBorderStyle.None;
                MaterialForm3.TopLevel = false;
                MaterialForm3.Parent = groupBox3;
                MaterialForm3.MaterIndex = 2;
                MaterialForm3.SourceType = "MT004";
                MaterialForm3.Dock = DockStyle.Top;
                MaterialForm3.Show();
            }

            FrmMaterialList MaterialForm4 = new FrmMaterialList();
            MaterialForm4.FormBorderStyle = FormBorderStyle.None;
            MaterialForm4.TopLevel = false;
            MaterialForm4.Parent = groupBox4;
            MaterialForm4.MaterIndex = 3;
            if (BaseSystemInfo.SystemType == 1)
            {
                MaterialForm4.SourceType = "MT006"; //取得CNT物料信息
            }

            if (BaseSystemInfo.SystemType == 2)
            {
                MaterialForm4.SourceType = "MT008";//取得 去离子水 物料信息
            }
            MaterialForm4.Dock = DockStyle.Top;
            MaterialForm4.Show();
        }
    }
}
