﻿using System.Windows.Forms;

namespace Sys.Utilities
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public virtual void SetTitleVisible(bool ShowTitle, string FormName)
        {
            lbl_SystemTitle.Visible = ShowTitle;
            if (ShowTitle)
            {

                lbl_SystemTitle.Text = FormName;
                //lbl_SystemTitle.ForeColor = Color.Green;
            }
            else
            {
                lbl_SystemTitle.Text = "";
            }


        }
    }
}
