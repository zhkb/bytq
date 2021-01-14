using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Support
{
	public delegate void OnChangeHandler();

    // Keeps application-wide data shared among forms and provides notifications about changes
    // Everywhere in this application a "document-view" model is used, and this class provides
    // a "document" part, whereas forms implement a "view" parts.
    // Each form interested in this data keeps a reference to it and synchronizes it with own 
    // controls using the OnChange() event and the Update() notificator method.
    // 在表单中保持应用程序范围内的数据共享，并提供有关更改的通知
    //在这个应用程序中的每一个地方都使用了“文档视图”模型，这个类提供了一个“文档”部分，而表单实现了一个“视图”部分。
    //对该数据相关的每一个窗体都保持对它的引用，并使用OnCube（）事件和UpDebug（）NOTIFICCAR方法将其与自己的控件同步。

    public class AppData
    {
		public const int MaxFingers = 10;
        // 共享数据
        public int EnrolledFingersMask = 0;
		public int MaxEnrollFingerCount = MaxFingers;
        public bool IsEventHandlerSucceeds = true;
        public bool IsFeatureSetMatched = false;
        public int FalseAcceptRate = 0;
		public DPFP.Template[] Templates = new DPFP.Template[MaxFingers];
        public string Name;
        public int ID;

        // 数据更改通知

        public void Update() { OnChange(); }        // 只触发OnCube（）事件

        public event OnChangeHandler OnChange;
	}
}
