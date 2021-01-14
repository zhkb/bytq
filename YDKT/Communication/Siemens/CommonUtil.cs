using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//add
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Communication
{
    public class CommonUtil
    {
        public static string _Msg;

        #region 读写配置文件
        /// <summary>
        /// 修改配置文件中某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <param name="value">appSettings的Value</param>
        public static void SetConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
                config.AppSettings.Settings[key].Value = value;
            else
                config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 读取配置文件某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <returns>appSettings的Value</returns>
        public static string GetConfig(string key)
        {
            string _value = string.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                _value = config.AppSettings.Settings[key].Value;
            }
            return _value;
        }
        #endregion

        #region 随机获取验证码

        //随机获取4位验证码（包含0-9）

        public static string RandomNum(int n)
        {
            //定义一个包括0-9数字的字符串
            string strchar = "0,1,2,3,4,5,6,7,8,9";
            //将strchar字符串转化为数组
            //String.Split 方法返回包含此实例中的子字符串（由指定Char数组的元素分隔）的 String 数组。
            string[] VcArray = strchar.Split(',');
            string VNum = "";
            //记录上次随机数值，尽量避免产生几个一样的随机数           
            int temp = -1;
            //采用一个简单的算法以保证生成随机数的不同
            Random rd = new Random(Guid.NewGuid().GetHashCode());//保证生成的随机字符永远不重复 
            // Random rd= new Random(); //不能写成这样，数目小的60条左右没问题，多了就会有很多重复
            for (int i = 1; i < n + 1; i++)
            {
                if (temp != -1)
                {
                    //unchecked 关键字用于取消整型算术运算和转换的溢出检查。
                    //DateTime.Ticks 属性获取表示此实例的日期和时间的刻度数。
                    rd = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                //Random.Next 方法返回一个小于所指定最大值的非负随机数。
                int t = rd.Next(9);
                if (temp != -1 && temp == t)
                {
                    return RandomNum(n);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;//返回生成的随机数
        }

        #endregion       

        #region MD5　32位加密 大写

        // MD5　32位加密 大写
        public static string StringToMD5HashS(string inputString)
        {
            byte[] result = Encoding.Default.GetBytes(inputString);    //tbPass为输入密码的文本框
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        }

        #endregion

        #region 记录日志

        public static void getLog(string logMsg, string logType)
        {
            //如果是同一天的话，则打开文件在末尾写入。如果不是同一天，则创建文件写入文件
            //判断是否存在文件
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "logs";
            if (!Directory.Exists(filePath + "\\" + DateTime.Today.ToString("yyyyMMdd")))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(filePath + "\\" + DateTime.Today.ToString("yyyyMMdd")); //新建文件夹   
            }
            string newfilePath = filePath + "\\" + DateTime.Today.ToString("yyyyMMdd");
            string fileName = logType + "_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            string newFileName = newfilePath + "//" + fileName;
            if (File.Exists(newFileName))
            {
                //如果存在文件，则向文件添加日志
                StreamWriter sw = new StreamWriter(newFileName, true);

                sw.WriteLine("============================================================================");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":");
                sw.WriteLine(logMsg);
                sw.Close();
                return;

            }
            //如果文件不存在，则创建文件后向文件添加日志
            StreamWriter sw2 = new StreamWriter(newFileName, true);
            sw2.WriteLine("============================================================================");
            sw2.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":");
            sw2.WriteLine(logMsg);
            sw2.Close();
        }

        #endregion


        //获取主机信息
        public static string DeviceID = CommonUtil.GetConfig("DeviceID");

        //读PLC_IP
        public static string PLC_IP = "";// = CommonUtil.GetConfig("PLC_IP");

 

    }
}
