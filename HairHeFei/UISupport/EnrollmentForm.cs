using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Sys.DbUtilities;

namespace UI_Support
{
    public partial class EnrollmentForm : Form
    {
        // 构造函数
        private AppData Data;	// 引用应用数据对象
        public EnrollmentForm(AppData data)
        {
            InitializeComponent();
			Data = data;                                        // 保持对数据的引用
            ExchangeData(true);                                 // 具有默认控制值的初始化数据;
            Data.OnChange += delegate { ExchangeData(false); };	// 跟踪数据更改以保持表单同步
        }

        // 简单对话数据交换（DDX）实现。

        public void ExchangeData(bool read)
        {
            if (read)
            {	// 从表单控件中读取值到数据对象

                Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount;
				Data.Update();
			}
            else
            {	// 从数据对象读取值到窗体的控件

                EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }

        public void OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
			if (Data.IsEventHandlerSucceeds)
			{
				Data.Templates[Finger-1] = Template;            // 存储手指模板

                ExchangeData(true);                             // 更新其他数据

                //增加指纹
                DbParameter[] param = new DbParameter[]
               {
                     new SqlParameter("@Doflag","Y"),
                     new SqlParameter("@User_Id",Data.ID),
                     new SqlParameter("@Fingers_Mask",Data.EnrolledFingersMask),
                     new SqlParameter("@Column","FINGERPRINT"+Finger),
                     new SqlParameter("@Value",Template.Bytes)
               };
                DataHelper.ExecStoredProcedure("up_Imos_Ta_Fingerprint_List", param);

            }
            else
				Status = DPFP.Gui.EventHandlerStatus.Failure;   // 强制“失败”状态

        }

        public void OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds) {
                Data.Templates[Finger-1] = null;                // 清除手指模板

                ExchangeData(true);                             // 更新其他数据

                //删除指纹
                DbParameter[] param = new DbParameter[]
               {
                     new SqlParameter("@Doflag","N"),
                     new SqlParameter("@User_Id",Data.ID),
                     new SqlParameter("@Fingers_Mask",Data.EnrolledFingersMask),
                     new SqlParameter("@Column","FINGERPRINT"+Finger),
                     new SqlParameter("@Value",Convert.ToByte("1"))
               };
                DataHelper.ExecStoredProcedure("up_Imos_Ta_Fingerprint_List", param);
            }
			else
				Status = DPFP.Gui.EventHandlerStatus.Failure;   // 强制“失败”状态
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}