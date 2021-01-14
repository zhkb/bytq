using System;
using System.IO;
using System.Collections.Generic;
using IPOS.Equips.Connection;

namespace IPOS.Equips.BaseInfo
{
    public class CaptionAttribute : Attribute
    {
        public CaptionAttribute(string ss)
        {
            this.Caption = ss;
        }
        public string Caption { get; set; }
    }
    /// <summary>
    /// 设置主信息
    /// </summary>
    public class Main
    {
        public Main()
        {
            this.Equip = null;
            this.Brand = string.Empty;
            this.Model = string.Empty;
            this.ReadHz = 1000;
            this.ConnType = new ConnType();
            this.UnitLen = 8;
        }
        /// <summary>
        /// 设备
        /// </summary>
        public BaseEquip Equip { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 连接方式
        /// </summary>
        public ConnType ConnType { get; set; }
        /// <summary>
        /// 读取频率
        /// </summary>
        public int ReadHz { get; set; }
        /// <summary>
        /// 字节长度
        /// </summary>
        public int UnitLen { get; set; }
    }
    /// <summary>
    /// 数据读取块
    /// </summary>
    public class Group
    {
        public Group()
        {
            this.Equip = null;
            this.Name = string.Empty;
            this.Remark = string.Empty;
            this.Block = string.Empty;
            this.Start = 0;
            this.Len = 0;
            this.Access = FileAccess.ReadWrite;
            this.IsAutoRead = true;
            this.Value = new string[0];
            this.Data = new Dictionary<string, Data>();
        }
        /// <summary>
        /// 设备
        /// </summary>
        public BaseEquip Equip { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 块地址
        /// </summary>
        public string Block { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Len { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public FileAccess Access { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object[] Value { get; set; }
        /// <summary>
        /// 是否自动读取
        /// </summary>
        public bool IsAutoRead { get; set; }
        /// <summary>
        /// 读取数据信息
        /// </summary>
        public Dictionary<string, Data> Data { get; set; }
    }
    /// <summary>
    /// 数据信息
    /// </summary>
    public class Data
    {
        public Data()
        {
            this.ReadTime = DateTime.MinValue;
            this.Group = null;
            this.Name = string.Empty;
            this.RunName = string.Empty;
            this.KeyName = string.Empty;
            this.Remark = string.Empty;
            this.Start = 0;
            this.Len = 0;
            this.Method = string.Empty;
            this.Max = string.Empty;
            this.Subtractor = string.Empty;
            this.LastBeforeMathValue = null;
            this.IsSave = true;
        }
        public Group Group { get; set; }
        /// <summary>
        /// 值读取时间
        /// </summary>
        public DateTime ReadTime { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 别名 系统中使用名称
        /// </summary>
        public string RunName { get; set; }
        /// <summary>
        /// 唯一主键
        /// </summary>
        public string KeyName { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Len { get; set; }
        /// <summary>
        /// 处理方法
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public string Max { get; set; }
        /// <summary>
        /// 是否进行保存
        /// </summary>
        public bool IsSave { get; set; }
        /// <summary>
        /// 被减数
        /// </summary>
        public string Subtractor { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
        private object value = null;

        public object[] LastBeforeMathValue { get; set; }
    }
}
