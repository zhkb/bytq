using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    using Sys.SysBusiness;
    using Sys.Config;

    public partial class FrmWeighReport : Form
    {
        public FrmWeighReport()
        {
            InitializeComponent();
        }

        private void FrmWeighReport_Load(object sender, EventArgs e)
        {
            //搅拌配方
            FrmWeigh StirWeighForm = new FrmWeigh(this);
            StirWeighForm.FormBorderStyle = FormBorderStyle.None;
            StirWeighForm.TopLevel = false;
            StirWeighForm.Parent = tabPage3;
            StirWeighForm.PlanType = (int)OptionSetting.PlanType.StirPlan;
            StirWeighForm.Dock = DockStyle.Fill;
            StirWeighForm.Show();

            //制胶配方
            FrmWeigh RubberRecipeForm = new FrmWeigh(this);
            RubberRecipeForm.FormBorderStyle = FormBorderStyle.None;
            RubberRecipeForm.TopLevel = false;
            RubberRecipeForm.Parent = tabPage4;
            RubberRecipeForm.PlanType = (int)OptionSetting.PlanType.RubberPlan;
            RubberRecipeForm.Dock = DockStyle.Fill;
            RubberRecipeForm.Show();

            //制陶配方
            // tabControl1.TabPages[2].ScrollControlIntoView

            if (BaseSystemInfo.SystemType == 2)
            {
                tabPage5.Parent = null;

            }
            else
            {
                FrmWeigh TerrineRecipeForm = new FrmWeigh(this);
                TerrineRecipeForm.FormBorderStyle = FormBorderStyle.None;
                TerrineRecipeForm.TopLevel = false;
                TerrineRecipeForm.Parent = tabPage5;
                TerrineRecipeForm.PlanType = (int)OptionSetting.PlanType.TerrinePlan;
                TerrineRecipeForm.Dock = DockStyle.Fill;
                TerrineRecipeForm.Show();
            }


        }
    }
}
