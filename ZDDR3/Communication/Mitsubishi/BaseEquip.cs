using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using IPOS.Equips.BaseInfo;

namespace IPOS.Equips
{
    /// <summary>
    /// 数据读取事件参数
    /// </summary>
    public class ReadEventArgs
    {
        public ReadEventArgs()
        {
            this.Data = new Dictionary<string, object>();
        }
        /// <summary>
        /// 读取数据信息
        /// </summary>
        public Dictionary<string, object> Data { get; set; }
    }
    /// <summary>
    /// 设备信息
    /// </summary>
    public abstract class BaseEquip
    {
        public BaseEquip()
        {
            this.Name = string.Empty;
            this.Project = string.Empty;
            this.Main = new Main();
            this.Group = new Dictionary<string, Group>();
            this.State = false;
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        [Caption("")]
        public string Name { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// 设备主信息
        /// </summary>
        public Main Main { get; set; }
        /// <summary>
        /// 设备数据块信息
        /// </summary>
        public Dictionary<string, Group> Group { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public bool State { get; protected set; }
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <returns></returns>
        public abstract bool Open();
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="block">数据块</param>
        /// <param name="start">起始地址</param>
        /// <param name="len">长度</param>
        /// <param name="buff">读取返回信息</param>
        /// <returns></returns>
        public abstract bool Read(string block, int start, int len, out object[] buff);
        /// <summary>
        /// 写入信息
        /// </summary>
        /// <param name="block">数据块</param>
        /// <param name="start">起始地址</param>
        /// <param name="buff">长度</param>
        /// <returns></returns>
        public abstract bool Write(int block, int start, object[] buff);
        /// <summary>
        /// 关闭设备
        /// </summary>
        public abstract void Close();
        /// <summary>
        /// 读取信息委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ReadDataHandler(object sender, ReadEventArgs e);
        /// <summary>
        /// 读取信息事件
        /// </summary>
        public event ReadDataHandler EquipReadData;
        /// <summary>
        /// 异常委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ExceptHandler(object sender, Exception e);
        /// <summary>
        /// 异常事件
        /// </summary>
        public event ExceptHandler OnExcept;
        /// <summary>
        /// 异常时调用
        /// </summary>
        /// <param name="ex"></param>
        private void RunOnExcept(Exception ex)
        {
            if (OnExcept != null)
            {
                OnExcept(this, ex);
            }
        }

        private object[] GetRowValue(string key, object[] buff)
        {
            foreach (DataRow dr in buff)
            {
                if (dr["ssKey"].ToString().Equals(key))
                {
                    return new object[] { dr["ssValue"] };
                }
            }
            return null;
        }
        private object[] GetDataValue(Data d, object[] buff)
        {
            object[] Result = new object[d.Len];
            for (int i = 0; i < d.Len; i++)
            {
                int index = d.Start + i;
                Result[i] = buff[index];
            }
            return Result;
        }
        private bool BuffEqual(object[] obj1, object[] obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                if (obj1 == null && obj2 == null)
                {
                    return true;
                }
                if (obj1 != null || obj2 != null)
                {
                    return false;
                }
            }
            if (obj1.Length != obj2.Length)
            {
                return false;
            }
            for (int i = 0; i < obj1.Length; i++)
            {
                if (obj1[i] == null || obj2[i] == null)
                {
                    if (obj1[i] != null || obj2[i] != null)
                    {
                        return false;
                    }
                    continue;
                }
                if (obj1[i].GetType() != obj2[i].GetType())
                {
                    return false;
                }
                if (!obj1[i].Equals(obj2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private object getRowValue(DataTable dt, string key)
        {
            object Result = null;
            foreach (DataRow row in dt.Rows)
            {
                if (row["ssKey"].ToString() == key)
                {
                    return row["ssValue"];
                }
            }
            return Result;
        }

        /// <summary>
        /// 线程状态
        /// </summary>
        private enum threadState
        {
            none = 0,
            runing = 1,
            stoping = 2,
        }
        /// <summary>
        /// 线程状态
        /// </summary>
        private threadState threadstate = threadState.none;
        private void Delay()
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                if (this.Main.ReadHz != int.MaxValue)
                {
                    break;
                }
                Thread.Sleep(10);
            }
            while (now.AddMilliseconds(this.Main.ReadHz) >= DateTime.Now)
            {
                Thread.Sleep(10);
            }
            return;
        }
        
        /// <summary>
        /// 线程结束
        /// </summary>
        public void Stop()
        {

        }
    }



}
