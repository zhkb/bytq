using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Support
{
    public partial class VerificationForm : Form
    {
        private AppData Data;   // 引用应用数据对象
        public VerificationForm(AppData data)
        {
            InitializeComponent();
			Data = data;
			Data.OnChange += delegate { ExchangeData(false); };     // 处理数据更改以保持同步

        }

        private void ExchangeData(bool read)
        {
        }

		public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status)
        {
			DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
			DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();
            // 将特征集与所有存储的模板进行比较。

            foreach (DPFP.Template template in Data.Templates) {
                // 从存储中获取模板。

                if (template != null) {
                    // 将特征集与特定模板进行比较。

                    ver.Verify(FeatureSet, template, ref res);
                    Data.IsFeatureSetMatched = res.Verified;
                    Data.FalseAcceptRate = res.FARAchieved;
                    if (res.Verified)
                        break; // 成功
                }
            }
			if (!res.Verified)
				Status = DPFP.Gui.EventHandlerStatus.Failure;
			Data.Update();
        }



    }
}