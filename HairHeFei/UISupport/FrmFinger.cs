using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Support
{
    public partial class FrmFinger : Form
    {
        private AppData Data;					// 保持应用范围的数据

        private EnrollmentForm Enroller;
        private VerificationForm Verifier;
        public string uloginname = "";
        public string ucname = "";
        public string upassword = "";
        public string userid = "0";
        public string userFingersMask = "0";

        public FrmFinger()
        {
            InitializeComponent();

            Data = new AppData();                               // 创建应用程序数据对象

            Data.OnChange += delegate { ExchangeData(false); }; // 跟踪数据更改以保持表单同步

            Enroller = new EnrollmentForm(Data);
            Verifier = new VerificationForm(Data);
            ExchangeData(false);                                // 用控件的默认值填充数据
        }


        private void ExchangeData(bool read)
        {
           
            if (read)
            {	// 从表单控件中读取值到数据对象
                //Data.EnrolledFingersMask = Mask.Text.Length == 0 ? 0 : (int)Mask.Value;
                Data.EnrolledFingersMask = Convert.ToInt32(userFingersMask);
                Data.MaxEnrollFingerCount = MaxFingers.Text.Length == 0 ? 0 : (int)MaxFingers.Value;
                Data.IsEventHandlerSucceeds = IsSuccess.Checked;
                Data.ID = Convert.ToInt32(userid);
                Data.Update();
                txt_name.Text = ucname;
            }
            else
            {   // 从数据对象读取VALUE到窗体控件

                Mask.Value = Data.EnrolledFingersMask;
                MaxFingers.Value = Data.MaxEnrollFingerCount;
                IsSuccess.Checked = Data.IsEventHandlerSucceeds;
                IsFailure.Checked = !IsSuccess.Checked;
                IsFeatureSetMatched.Checked = Data.IsFeatureSetMatched;
                FalseAcceptRate.Text = Data.FalseAcceptRate.ToString();
                VerifyButton.Enabled = Data.EnrolledFingersMask > 0;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnrollButton_Click(object sender, EventArgs e)
        {
            ExchangeData(true);     // 从主窗体向数据对象传递值

            Enroller.ShowDialog();	// 进程注册
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            ExchangeData(true);     // 从主窗体向数据对象传递值

            Verifier.ShowDialog();	// 过程验证
        }

        private void FrmFinger_Load(object sender, EventArgs e)
        {
            txt_name.Text = uloginname;
        }
    }
}
