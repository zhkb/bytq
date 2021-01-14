using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainFrame
{
    public class VoiceClass
    {

        /// <summary>
        /// 获取选择的速度
        /// </summary>
        /// <param name="num">123</param>
        /// <returns></returns>
        private int GetSpeedSelected(int num)
        {
            if (num == 1) { return -3; }
            if (num == 2) { return -2; }
            if (num == 3) { return -1; }
            if (num == 4) { return 0; }
            if (num == 5) { return 1; }
            if (num == 6) { return 2; }
            if (num == 7) { return 3; }
            if (num == 8) { return 4; }
            return 0;
        }
        /// <summary>
        /// 阅读函数
        /// </summary>
        /// <param name="text"></param>
        public void Read(string text,int Speed )
        {

        }
    }
}
