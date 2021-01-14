using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPOS.Equips;
using ACTMULTILib;

namespace Communication
{
    /// <summary>
    /// 三菱通讯封装设备类
    /// </summary>
    public class MPlcLink : BaseEquip
    {
        public int ActLogicalStationNumber;    //MX Component控件管理中定义的逻辑站号 liucb 2016.04.11
        
        private ACTMULTILib.ActEasyIFClass com_ReferencesEasyIF = null;   //定义三菱PLC通讯控件对象

        private bool _isOpen = false;   //是否打开连接

        public override bool Open()
        {
            lock (this)
            {
                try
                {
                    if (this._isOpen == true)
                    {
                        return true;
                    }
                    this.State = false;
                    if (this.com_ReferencesEasyIF == null)
                    {
                        this.com_ReferencesEasyIF = new ACTMULTILib.ActEasyIFClass();
                        this.com_ReferencesEasyIF.ActLogicalStationNumber = this.ActLogicalStationNumber;
                    }
                    int Result = this.com_ReferencesEasyIF.Open();  //打开
                    if (Result != 0)
                    {
                        Console.WriteLine("PLC连接失败：" + this.GetErrInfo((uint)Result));
                        this.State = false;
                        this._isOpen = false;
                        return this.State;
                    }
                    else
                    {
                        this.State = true;
                        this._isOpen = true;
                        Console.WriteLine("连接成功!");
                        return this.State;
                    }

                }
                catch (Exception ex)
                {
                    this.State = false;
                    this._isOpen = false;
                    Console.WriteLine(ex.Message);
                    return this.State;
                }
            }
        }
        /// <summary>
        /// PLC数据读取方法
        /// </summary>
        /// <param name="block">要读取的块号</param>
        /// <param name="start">要读取的起始字</param>
        /// <param name="len">要读取的长度，最大255，超过255则不读取</param>
        /// <param name="buff"></param>
        /// <returns></returns>
        public override bool Read(string block, int start, int len, out object[] buff)
        {
            lock (this)
            {
                buff = new object[len];
                try
                {
                    if (len > 256)
                    {
                        for (int i = 0; i < len; i++)
                        {
                            buff[i] = 0;
                        }
                        base.State = false;
                        return false;
                    }
                    int maxOneLen = 100;                    //单次允许读取的最大长度，AB500限制为100个字
                    int count = len / maxOneLen;            //要读取的次数
                    
                    int mod = len % maxOneLen;              //剩余的长度
                    bool flag = true;                       //保存读取标志
                    for (int i = 0; i < count; i++)
                    {
                        object[] _buff = new object[maxOneLen];
                        flag = this.ReadByLen(block, start + i * maxOneLen, maxOneLen, out _buff);
                        if (flag == false)
                        {
                            base.State = flag;
                            return false;
                        }
                        for (int k = i * maxOneLen; k < (i + 1) * maxOneLen; k++)
                        {
                            buff[k] = _buff[k - i * maxOneLen];
                        }
                    }
                    if (mod > 0)
                    {
                        object[] _buff = new object[mod];
                        flag = this.ReadByLen(block, start + count * maxOneLen, mod, out _buff);
                        if (flag == false)
                        {
                            base.State = flag;
                            return false;
                        }
                        for (int k = count * maxOneLen; k < count * maxOneLen + mod; k++)
                        {
                            buff[k] = _buff[k - count * maxOneLen];
                        }
                    }
                    base.State = flag;
                    return flag;
                }
                catch (Exception ex)
                {
                    //ICSharpCode.Core.LoggingService.Error(String.Format("读取PLC（AB500）设备失败-({0})!", ex.Message));
                    Console.WriteLine(ex.Message);
                    base.State = false;
                    return false;
                }
            }
        }
        /// <summary>
        /// 单次读取最长100个字的方法
        /// </summary>
        /// <param name="block">块号</param>
        /// <param name="start">起始字</param>
        /// <param name="len">长度，最长不超过100</param>
        /// <param name="buff">数据缓冲区，存放读取的数据</param>
        /// <returns>读取成功返回true，读取失败返回false</returns>
        private bool ReadByLen(string block, int start, int len, out object[] buff)
        {
            lock (this)
            {
                buff = new object[len];
                if (!this.Open())
                {
                    return false;
                }
                int state = len;
                int[] _buff = new int[len];
                int iblock = Convert.ToInt32(block);
                iblock = iblock + start;
                int iResult = this.com_ReferencesEasyIF.ReadDeviceBlock("D" + iblock, _buff.Length, out _buff[0]);
                if (iResult != 0)
                {
                    Console.WriteLine("PLC读取失败：" + this.GetErrInfo((uint)iResult));
                    this.State = false;
                    return false;
                }
                else
                {
                    this.State = true;
                }
                int iReadLen = len;
                if (iReadLen > state)
                {
                    iReadLen = state;
                }
                for (int i = 0; i < iReadLen; i++)
                {
                    int value = _buff[i];
                    if (value > ushort.MaxValue)
                    {
                        value = ushort.MaxValue - value;
                    }
                    buff[i] = value;
                }
                return true;
            }
        }

        private ushort ToValue(object obj, ushort defaultValue)
        {
            ushort result = 0;
            if (obj != null
                && obj != DBNull.Value
                && ushort.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// PLC数据写入方法
        /// </summary>
        /// <param name="block">要写入的块号</param>
        /// <param name="start">起始字</param>
        /// <param name="buff">要写入PLC的数据</param>
        /// <returns>写入成功返回true，失败返回false</returns>
        public override bool Write(int block, int start, object[] buff)
        {
            lock (this)
            {
                try
                {
                    if (buff.Length > 1000)
                    {
                        return false;
                    }
                    int len = buff.Length;
                    int maxOneLen = 100;                    //单次允许读取的最大长度，AB500限制为100个字
                    int count = len / maxOneLen;            //要读取的次数
                    int mod = len % maxOneLen;              //剩余的长度
                    bool flag = true;                       //保存写入标志
                    for (int i = 0; i < count; i++)
                    {
                        object[] _buff = new object[maxOneLen];
                        for (int k = i * maxOneLen; k < (i + 1) * maxOneLen; k++)
                        {
                            _buff[k - i * maxOneLen] = buff[k];
                        }
                        flag = this.WriteMax100(block, start + i * maxOneLen, _buff);
                        if (flag == false)
                        {
                            return false;
                        }
                    }
                    if (mod > 0)
                    {
                        object[] _buff = new object[mod];
                        for (int k = count * maxOneLen; k < count * maxOneLen + mod; k++)
                        {
                            _buff[k - count * maxOneLen] = buff[k];
                        }
                        flag = this.WriteMax100(block, start + count * maxOneLen, _buff);

                    }
                    return flag;
                }
                catch (Exception ex)
                {
                    //ICSharpCode.Core.LoggingService.Error(String.Format("写入PLC（AB500）设备失败-({0})!", ex.Message));
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// 单次写入最多100个字至PLC
        /// </summary>
        /// <param name="block">要写入的块号</param>
        /// <param name="start">要写入的起始字</param>
        /// <param name="buff">要写入的数据</param>
        /// <returns>写入成功返回true，失败返回false</returns>
        private bool WriteMax100(int block, int start, object[] buff)
        {
            lock (this)
            {
                if (!this.Open())
                {
                    return false;
                }
                int state = buff.Length;
                int[] _buff = new int[buff.Length];
                for (int i = 0; i < buff.Length; i++)
                {
                    int value = 0;
                    int.TryParse(buff[i].ToString(), out value);
                    _buff[i] = value;
                }
                int iblock = Convert.ToInt32(block);
                iblock = iblock + start;
                int iResult = this.com_ReferencesEasyIF.WriteDeviceBlock("D" + iblock, _buff.Length, ref _buff[0]);
                if (iResult != 0)
                {
                    Console.WriteLine("PLC【三菱】写入失败：" + this.GetErrInfo((uint)iResult));
                    return false;
                }
                return true;
            }
        }
        public override void Close()
        {
            lock (this)
            {
                try
                {
                    int result = this.com_ReferencesEasyIF.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("PLC【三菱】关闭失败：" + this.GetErrInfo((uint)result));
                    }
                    else
                    {
                        this.State = false;
                        this._isOpen = false;
                        Console.WriteLine("关闭成功!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PLC【三菱】关闭失败：" + ex.Message);
                }
            }
        }

        /// <summary>根据错误代码返回错误信息
        /// 例如int errCode=ActiveConn(1);  sring errInfo = GetErrInfo(err);
        /// </summary>
        /// <param name="errCode">错误码</param>
        /// <returns>错误信息</returns>
        public string GetErrInfo(uint errCode)
        {
            switch (errCode)
            {
                case 0x0000: return "Success";
                case 0x01010002: return "超时出错。";
                case 0x01010005: return "信息出错。";
                case 0x01010010: return "PLC 站号出错，无法与指定站号正常通讯。";
                case 0x01010011: return "模式出错不支持命令。";
                case 0x01010012: return "特殊单元配置出错。";
                case 0x01010013: return "其它数据出错某些原因而导致无法通讯。";
                case 0x01010018: return "远程请求出错在非通讯路径执行远程操作。";
                case 0x01010020: return "链接出错无法执行链接通讯。";
                case 0x01010021: return "特殊单元总线出错。特殊单元无反应。";
                case 0x01800001: return "无指令出错函数不支持。";
                case 0x01800002: return "存储锁定出错。";
                case 0x01800003: return "存储安全出错。";
                case 0x01800004: return "DLL 加载出错。";
                case 0x01800005: return "资源安全出错";
                case 0x01801001: return "资源超时出错。在指定时间内未检索到资源。";
                case 0x01801002: return "在指定时间内未检索到资源。";
                case 0x01801003: return "未执行打开命令。";
                case 0x01801004: return "打开类型出错。";
                case 0x01801005: return "指定端口出错。";
                case 0x01801006: return "指定模块出错。";
                case 0x01801007: return "指定CPU 出错。";
                case 0x01801008: return "访问目标站出错。";
                case 0x01801009: return "注册失败。打开注册数据失败。";
                case 0x0180100A: return "数据包类型出错。指定数据包类型不正确。";
                case 0x0180100B: return "协议类型出错。指定协议不正确。";
                case 0x0180100C: return "搜索注册失败。";
                case 0x0180100D: return "GetProcAddress 失败。";
                case 0x0180100E: return "DLL 未加载出错。";
                case 0x0180100F: return "另一个对象在执行中，由于专用控制正在运行因而无法执行函数。";
                case 0x01802001: return "软元件出错，函数中指定的软元件字符串未经批准。";
                case 0x01802002: return "软元件号出错，函数中指定的软元件字符串号未经批准。";
                case 0x01802003: return "程序类型出错。";
                case 0x01802004: return "和检验出错，接收到数据的和检验值异常。";
                case 0x01802005: return "大小出错，函数中指定的点数未经批准。";
                case 0x01802006: return "批号出错，函数的软元件字符串中指定的批号未经批准。";
                case 0x01802007: return "接收数据出错，接收到的数据异常。";
                case 0x01802008: return "写保护出错。";
                case 0x01802009: return "读参数出错。";
                case 0x0180200A: return "写参数出错。";
                case 0x0180200B: return "PLC类型不匹配，属性中设置的CPU型号和communication，settings utility中设置的CPU型号与另一通讯端不匹配。";
                case 0x0180200C: return "取消请求出错，处理进行中取消请求。";
                case 0x0180200D: return "驱动器名出错，指定驱动器名不正确。";
                case 0x0180200E: return "开始步骤出错，指定开始步骤不正确。";
                case 0x0180200F: return "参数类型出错，参数类型不正确。";
                case 0x01802010: return "文件名出错，文件名不正确。";
                case 0x01802011: return "状态出错，注册/取消/设置的状态不正确。";
                case 0x01802012: return "详细条件域出错。";
                case 0x01802013: return "步条件出错。";
                case 0x01802014: return "位软元件出错。";
                case 0x01802015: return "参数设置出错。";
                case 0x01802016: return "指定电话局号出错，函数不支持指定电话局号的通讯操作。";
                case 0x01802017: return "关键字出错。";
                case 0x01802018: return "读/写出错。";
                case 0x01802019: return "刷新函数出错。";
                case 0x0180201A: return "缓冲器存取函数出错。";
                case 0x0180201B: return "启动模式/结束模式出错。";
                case 0x0180201C: return "时钟数据写入出错，由于数据错误，指定的时钟数据无法正确写入。";
                case 0x0180201D: return "联机时钟数据写入出错，时钟数据写入失败。由于PLC CPU 处于RUN状态时钟数据无法写入。";
                case 0x0180201E: return "ROM驱动器出错。";
                case 0x0180201F: return "记录过程中出错，在记录中执行了无效操作。";
                case 0x01802020: return "起始I/O编号出错，函数中指定的起始I/O编号值未经批准。";
                case 0x01802021: return "首地址出错，函数中指定的缓冲器地址未经批准。";
                case 0x01802022: return "模式出错。";
                case 0x01802023: return "SFC 块号出错。";
                case 0x01802024: return "SFC 步号出错。";
                case 0x01802025: return "步号出错。";
                case 0x01802026: return "数据出错。";
                case 0x01802027: return "系统数据出错。";
                case 0x01802028: return "TC 设置数值出错。";
                case 0x01802029: return "清除模式出错。";
                case 0x0180202A: return "信号流程出错。";
                case 0x0180202B: return "版本控制出错。";
                case 0x0180202C: return "未注册监视出错。";
                case 0x0180202D: return "PI 类型出错。";
                case 0x0180202E: return "PI 号出错。";
                case 0x0180202F: return "PI 数目出错。";
                case 0x01802030: return "移位出错。";
                case 0x01802031: return "文件类型出错。";
                case 0x01802032: return "指定单元出错。";
                case 0x01802033: return "出错检查标志符出错。";
                case 0x01802034: return "分步RUN 操作出错。";
                case 0x01802035: return "分步RUN 数据出错。";
                case 0x01802036: return "分步RUN 过程中出错。";
                case 0x01802037: return "运行程序执行通讯过程中写入错误至E2PROM。";
                case 0x01802038: return "时钟数据读/写出错，无时钟软元件的PLC CPU执行时钟数据读/写函数。";
                case 0x01802039: return "记录未完成出错。";
                case 0x0180203A: return "注册清除标志符出错。";
                case 0x0180203B: return "操作出错。";
                case 0x0180203C: return "交换次数出错。";
                case 0x0180203D: return "指定循环数出错。";
                case 0x0180203E: return "重获选定数据。";
                case 0x0180203F: return "SFC 循环次数出错。";
                case 0x01802040: return "Motion PLC 出错。";
                case 0x01802041: return "Motion PLC 通讯出错。";
                case 0x01802042: return "固定执行时间设置出错。";
                case 0x01802043: return "各函数编号出错。";
                case 0x01802044: return "系统信息说明出错。";
                case 0x01802045: return "未确定注册条件出错。";
                case 0x01802046: return "函数号出错。";
                case 0x01802047: return "RAM驱动器出错。";
                case 0x01802048: return "引导程序端ROM驱动器出错。";
                case 0x01802049: return "引导程序端传输模式规格出错。";
                case 0x0180204A: return "内存不足出错。";
                case 0x0180204B: return "备份驱动器ROM 出错。";
                case 0x0180204C: return "块大小出错。";
                case 0x0180204D: return "在RUN状态下分离出错。";
                case 0x0180204E: return "单元已经注册出错。";
                case 0x0180204F: return "密码注册数据已满出错。";
                case 0x01802050: return "未注册密码出错。";
                case 0x01802051: return "远程密码出错。";
                case 0x01802052: return "IP 地址出错。";
                case 0x01802053: return "超时值超超越范围出错。";
                case 0x01802054: return "未检索到命令出错。";
                case 0x01802055: return "执行记录类型出错";
                case 0x01802056: return "版本出错";
                case 0x01802057: return "跟踪电缆出错，跟踪电缆有故障。PLC CPU处于error 状态。";
                case 0x01808001: return "多次打开出错，打开之后再次执行打开函数。";
                case 0x01808002: return "通道号指定出错，属性中及communication settings utility中设置的端口号数值未经批准。";
                case 0x01808003: return "驱动程序没有运行，网络板驱动程序没有运行。";
                case 0x01808004: return "生成重叠事件出错。";
                case 0x01808005: return "生成MUTEX 出错创建MUTEX进行专用控制失败。";
                case 0x01808006: return "生成网络界面程序错误，无法创建网络界面程序";
                case 0x01808007: return "生成网络界面程序出错，创建网络界面程序失败。";
                case 0x01808008: return "端口连接出错，建立连接失败。另一端无反应。";
                case 0x01808009: return "COM 端口控制关闭出错，无法操作COM 端口。无法复制COM 端口号。无法复制SOCKET 端口号。";
                case 0x0180800A: return "缓冲器大小设置出错，设置COM端口缓冲器大小失败。";
                case 0x0180800B: return "获得DCB 值出错，获得COM端口DCB 值失败。";
                case 0x0180800C: return "DCB 设置出错设置COM端口DCB 值失败。";
                case 0x0180800D: return "超时值设置出错，设置COM 端口超时值失败。";
                case 0x0180800E: return "打开共享存储器出错，打开共享存储器失败。";
                case 0x01808101: return "重复关闭出错。";
                case 0x01808102: return "关闭控制出错，关闭COM 端口控制失败。";
                case 0x01808103: return "驱动程序关闭出错，关闭驱动程序控制失败。";
                case 0x01808104: return "重叠事件关闭出错。";
                case 0x01808105: return "Mutex 控制关闭出错。";
                case 0x01808106: return "COM 端口控制关闭出错。";
                case 0x01808201: return "发送出错，发送数据失败。";
                case 0x01808202: return "发送数据大小出错，数据发送失败。";
                case 0x01808203: return "清除队列出错，清除COM端口队列失败。";
                case 0x01808301: return "接收出错，接收数据失败。";
                case 0x01808302: return "未发送错误。";
                case 0x01808303: return "重获重叠事件中错误。";
                case 0x01808304: return "接收缓冲器容量不足，收到的数据超过系统准备的接收缓冲器容量。";
                case 0x01808401: return "控制出错，COM端口通讯控制更改失败。";
                case 0x01808402: return "信号线控制出错。";
                case 0x01808403: return "信号线指定出错，COM端口通讯控制更改失败。";
                case 0x01808404: return "打开命令未执行。";
                case 0x01808405: return "通讯参数出错，属性中数据位和停止位结合未经批准。";
                case 0x01808406: return "指定传输速率值出错，属性中传输速率未经批准。";
                case 0x01808407: return "数据长度出错，属性中数据位值未经批准。";
                case 0x01808408: return "指定奇偶校验出错，属性中奇偶校验值未经批准。";
                case 0x01808409: return "指定停止位出错，属性中停止位数值未经批准。";
                case 0x0180840A: return "通讯控制设置出错，属性中控制值未经批准。";
                case 0x0180840B: return "超时出错，经过超时期间之后，数据仍未接收到。";
                case 0x0180840C: return "连接出错。";
                case 0x0180840D: return "重复连接出错。";
                case 0x0180840E: return "连接失败，网络界面程序连接失败。";
                case 0x0180840F: return "获得信号线状态失败，获得COM 端口信号线状态失败。";
                case 0x01808410: return "CD信号线OFF，CD信号在另一通讯端处于OFF 状态。";
                case 0x01808411: return "密码不匹配出错。";
                case 0x01808412: return "TEL 通讯出错。";
                case 0x01808501: return "USB驱动程序加载出错，加载USB 驱动程序失败。";
                case 0x01808502: return "USB驱动程序连接出错，连接USB 驱动程序失败。";
                case 0x01808503: return "USB驱动程序发送出错，数据发送失败";
                case 0x01808504: return "USB驱动程序接收出错，数据接收失败。";
                case 0x01808505: return "USB 驱动程序超时出错。";
                case 0x01808506: return "USB驱动程序初始化出错，USB驱动程序初始化失败。";
                case 0x01808507: return "USB 其它出错，有关数据发送/接收发生的错误。";
                case 0x02000001: return "点数超越范围出错，注册在监视服务器中的点数太高。";
                case 0x02000002: return "创建共享内存出错，创建共享内存失败。";
                case 0x02000003: return "访问共享内存出错。";
                case 0x02000004: return "保护内存出错，保护监视服务器内存失败。";
                case 0x02000005: return "设备未注册出错，监视器未注册。";
                case 0x02000006: return "监视服务器启动出错，监视服务器未启动。";
                case 0x02000010: return "检索设备值出错，监视未完成。";
                case 0x03000001: return "不支持命令出错，不支持命令。";
                case 0x03000002: return "锁定内存出错，锁定内存失败。";
                case 0x03000003: return "保护内存出错，保护内存失败。";
                case 0x03000004: return "读取DLL 出错，读取DLL 时失败。";
                case 0x03000005: return "保护资源出错，保护资源时失败。";
                case 0x03010001: return "创建文件出错，创建文件失败。";
                case 0x03010002: return "打开文件出错，打开文件失败。";
                case 0x03010003: return "缓冲器大小出错，指定缓冲器大小不正确或不够大。";
                case 0x03010004: return "SIL语句格式出错，SIL语句格式不正确。";
                case 0x03010005: return "文件名出错，指定文件名太长。";
                case 0x03010006: return "文件不存在出错，指定的文件不存在。";
                case 0x03010007: return "文件结构出错，指定文件中的数据结构不正确。";
                case 0x03010008: return "文件已存在出错，指定文件已经存在。";
                case 0x03010009: return "文件不存在出错，指定的文件不存在。";
                case 0x0301000A: return "文件删除出错，指定文件无法删除。";
                case 0x0301000B: return "重复打开出错，指定工程已经打开两次。";
                case 0x0301000C: return "文件名出错，指定文件名不正确。";
                case 0x0301000D: return "读取文件出错，读取文件失败。";
                case 0x0301000E: return "写入文件出错，写入文件失败。";
                case 0x0301000F: return "查找文件出错，查找文件失败。";
                case 0x03010010: return "关闭文件出错，关闭文件失败。";
                case 0x03010011: return "创建文件夹出错，创建文件夹失败。";
                case 0x03010012: return "复制文件出错，复制文件失败。";
                case 0x03010013: return "工程路径出错，工程路径长度不正确。";
                case 0x03010014: return "工程类型出错，工程类型不正确。";
                case 0x03010015: return "文件类型出错，文件类型不正确。";
                case 0x03010016: return "子文件类型出错，子文件类型不正确。";
                case 0x03010017: return "磁盘空间不足出错，磁盘空间不足。";
                case 0x03020002: return "重复打开出错，多次打开数据库产品。";
                case 0x03020003: return "未打开出错，数据库产品未打开。";
                case 0x03020004: return "解压缩出错，数据库产品不能解压缩。";
                case 0x03020010: return "参数出错，数据库产品的参数不正确。";
                case 0x03020011: return "代码出错，代码参数不正确。";
                case 0x03020012: return "指定制造商出错，制造商参数不正确。";
                case 0x03020013: return "指定单元出错，单元参数不正确。";
                case 0x03020014: return "SQL 参数出错，数据库产品的SIL、SQL 参数不正确。";
                case 0x03020015: return "SIL语句格式出错，SIL语句格式不正确。";
                case 0x03020016: return "输入字段出错，输入字段不正确。";
                case 0x03020050: return "建立记录数据出错，重建数据库产品记录数据失败。";
                case 0x03020060: return "检索记录数据出错，检索数据库产品记录数据失败。";
                case 0x03020061: return "末尾记录出错，当前记录为末尾记录时，无法检索到下一条。";
                case 0x03FF0000: return "初始化出错。";
                case 0x03FF0001: return "未初始化出错。";
                case 0x03FF0002: return "重复初始化出错。";
                case 0x03FF0003: return "工作空间初始化出错。";
                case 0x03FF0004: return "数据库初始化出错。";
                case 0x03FF0005: return "记录装置初始化出错。";
                case 0x03FF0006: return "关闭数据库出错。";
                case 0x03FF0007: return "关闭记录装置出错";
                case 0x03FF0008: return "未打开数据库出错，数据库没有打开。";
                case 0x03FF0009: return "未打开记录装置出错，记录装置没有打开。";
                case 0x03FF000A: return "初始化表出错，初始化TtableInformation 表失败。";
                case 0x03FF000B: return "初始化表出错，初始化TfieldInformation 表失败。";
                case 0x03FF000C: return "初始化表出错，初始化TrelationInformation 表失败。";
                case 0x03FF000D: return "初始化表出错，初始化Tlanguage 表失败。";
                case 0x03FF000E: return "初始化表出错，初始化Tmaker表失败。";
                case 0x03FF000F: return "初始化表出错，初始化TOpenDatabase 表失败。";
                case 0x03FF0010: return "区段值出错。";
                case 0x03FF0011: return "区段值出错。";
                case 0x03FF0012: return "退出出错，退出数据库失败。";
                case 0x03FF0100: return "移动记录出错，移动记录失败。";
                case 0x03FF0101: return "检索记录数出错，检索记录数失败。";
                case 0x03FF0110: return "检索区段值出错，检索区段值失败";
                case 0x03FF0111: return "设置区段值出错，设置区段值失败。";
                case 0x03FFFFFF: return "其它出错。";
                case 0x04000001: return "无命令出错，指定的CPU型号不能用于处理。";
                case 0x04000002: return "锁定内存出错，锁定内存失败。";
                case 0x04000003: return "保护内存出错，保护内存失败。";
                case 0x04000004: return "内部服务器加载DLL 出错启动内部服务器失败。";
                case 0x04000005: return "保护资源出错，保护资源失败。";
                case 0x04000006: return "加载主对象出错，读取文件失败。";
                case 0x04000007: return "加载换算表出错，读取表格数据失败。";
                case 0x04000100: return "不正确的中间码大小出错。";
                case 0x04010001: return "中间码未转换出错，转换一命令为机器代码超过256字节。";
                case 0x04010002: return "中间码完成出错，代码的中间码转换突然终止。";
                case 0x04010003: return "中间码不充分出错，代码的中间码转换不充分。";
                case 0x04010004: return "中间码数据出错，中间码转换不正确。";
                case 0x04010005: return "中间码结构出错，中间码中的步骤数不正确。";
                case 0x04010006: return "步骤数出错，说明中间码的步骤数不正确。";
                case 0x04010007: return "机器代码的存储空间不足出错，机器代码的存储空间不足。";
                case 0x04010008: return "其它出错，(由中间码转换成机器代码时产生的其它错误。)";
                case 0x04011001: return "机器代码未转换出错，转换一命令为中间码超过256字节。";
                case 0x04011002: return "机器代码完成出错，机器代码转换突然终止。";
                case 0x04011003: return "异常机器代码出错，转换机器代码异常，不能转换。";
                case 0x04011004: return "中间码存储空间不足出错，中间码存储区域不足出错";
                case 0x04011005: return "其它出错，机器代码转换成中间码产生的其它错误。";
                case 0x04020001: return "机器代码转换成中间码产生的其它错误。转换一命令为中间码超过256字节。";
                case 0x04020002: return "无输入出错，输入代码列表不足。";
                case 0x04020003: return "命令出错，转换代码列表的命令名不正确。";
                case 0x04020004: return "软元件出错，转换代码列表的软元件名不正确。";
                case 0x04020005: return "软元件号出错，转换代码列表的软元件号超越范围。";
                case 0x04020006: return "转换出错，不可识别转换的代码列表。";
                case 0x04020007: return "文本数据出错，代码列表转换不正确。";
                case 0x04020008: return "SFC输出操作出错，操作SFC的输出命令不正确。";
                case 0x04020009: return "SFC移位条件出错，SFC移动条件命令不正确。";
                case 0x0402000A: return "行间语句出错，程序行之间输入的语句不正确。";
                case 0x0402000B: return "P.I语句出错，输入的P.I语句不正确。";
                case 0x0402000C: return "注释出错，输入的注释不正确。";
                case 0x0402000D: return "注释出错，输入的注释不正确。";
                case 0x0402000E: return "其它出错，(列表转换成中间码时产生的其它错误。)";
                case 0x04021001: return "中间码未转换出错，转换一命令为代码列表超过256字节。";
                case 0x04021002: return "中间码区域已满出错，转换的中间码区域已满。";
                case 0x04021003: return "命令出错，通过转换的中间码指定的命令不正确。";
                case 0x04021004: return "软元件出错，转换的中间码中指定的软元件不正确。";
                case 0x04021005: return "中间码出错，转换的中间码结构不正确。";
                case 0x04021006: return "列表存储空间不足出错，存储转换代码列表的空间不足。";
                case 0x04021007: return "其它出错，(中间码转换为列表成时产生的其它错误。)";
                case 0x04030001: return "未转换出错，转换中间码的存储空间不足。";
                case 0x04030002: return "创建错误电路出错，在一顺控程序中未完成字符存储器电路。";
                case 0x04030003: return "指定电路大小超出范围，指定电路大小太大。";
                case 0x04030004: return "不正确返回电路出错，在返回电路前后无一致性。设置的返回电路太高。";
                case 0x04030005: return "其它出错，(字符存储器转换成中间码时产生的其它错误。)";
                case 0x04031001: return "未转换出错，指定字符存储器大小(纵向/横向)不正确。";
                case 0x04031002: return "异常命令码出错，转换的命令中间码不正确。";
                case 0x04031003: return "创建错误电路出错，无法转换成顺控程序电路。没有END 命令。";
                case 0x04031004: return "指定电路大小超出范围出错，指定电路大小太大。";
                case 0x04031005: return "重大出错，发生重大出错。";
                case 0x04031006: return "存储块数目不足出错，存储转换字符存储器电路块的空间不足。";
                case 0x04031007: return "查找电路块出错，电路块中数据中断。";
                case 0x04031008: return "其它出错，(中间码转换成字符存储器时产生的其它错误。)";
                case 0x04040001: return "CAD 数据出错没有CAD数据要转换。CAD数据格式不正确。";
                case 0x04040002: return "输出数据出错，输入CAD数据和输出CAD数据类型不匹配。";
                case 0x04040003: return "加载库差错，加载程序库失败。";
                case 0x04040004: return "存储空间保护差错，存储转换数据的受保护空间不足。";
                case 0x04040005: return "无END 命令出错，在CAD数据转换时无END 命令。";
                case 0x04040006: return "异常命令代码出错，在CAD数据转换中命令代码异常。";
                ////////////////////////////////////////////////////////////////////////////////
                case 0x04040007: return "软元件号出错，软元件号超出范围。";
                case 0x04040008: return "步骤号出错，步骤号超出范围。";
                case 0x04040009: return "指定电路大小超出范围出错，一个电路块太大。";
                case 0x0404000A: return "返回电路出错，返回电路不正确。";
                case 0x0404000: return "b创建错误电路出错，电路数据不正确。";
                case 0x0404000C: return "SFC 数据出错，转换SFC 数据不正确。";
                case 0x0404000D: return "列表数据出错，转换列表数据不正确。";
                case 0x0404000E: return "注释数据出错，转换注释数据不正确。";
                case 0x0404000F: return "声明出错，转换声明数据不正确。";
                case 0x04040010: return "其它出错，(CAD代码转换成中间码时产生的其它错误。)";
                case 0x04041001: return "中间码数据出错，没有中间码要转换。";
                case 0x04041002: return "CAD 数据类型出错，输入CAD数据和输出CAD数据类型不匹配。";
                case 0x04041003: return "库出错，加载程序库失败。";
                case 0x04041004: return "输入数据不足出错，转换的数据不足。";
                case 0x04041005: return "存储空间不足出错，没有足够的空间存储要转换的CAD 数据。";
                case 0x04041006: return "无END 命令出错，在要转换的CAD数据中没有END 命令。";
                case 0x04041007: return "异常命令代码出错，在要转换的CAD数据中存在异常命令代码。";
                case 0x04041008: return "软元件号出错，软元件号超出范围。";
                case 0x04041009: return "步号出错，步号超出范围。";
                case 0x0404100A: return "指定电路大小超出范围出错，1电路块太大。";
                case 0x0404100: return "b返回电路出错，返回电路不正确。";
                case 0x0404100C: return "创建错误电路出错，电路数据不正确。";
                case 0x0404100D: return "SFC 数据出错，要转换的SFC 数据不正确。";
                case 0x0404100E: return "列表数据出错，要转换的列表数据不正确。";
                case 0x0404100F: return "注释数据出错，转换注释数据不正确。";
                case 0x04041010: return "声明出错，转换声明数据不正确。";
                case 0x04041011: return "其它出错，(CAD代码转换成中间码时产生的其它错误。)";
                case 0x040A0001: return "中间码存储空间不足出错，存储转换后的数据空间不足。";
                case 0x040A0002: return "存储补充的SFC信息空间不足";
                case 0x040A0003: return "转换出错";
                case 0x040A0004: return "无SFC 程序出错";
                case 0x040A1001: return "未使用步/无输出出错";
                case 0x040A1002: return "步号超出范围出错";
                case 0x040A1003: return "未使用步/无输出出错";
                case 0x040A1004: return "传输号超出范围";
                case 0x040A1005: return "超出最大号出错";
                case 0x040A1006: return "宏控制器程序空间出错";
                case 0x040A1007: return "无SFC 程序出错";
                case 0x040B0001: return "中间码存储空间不足出错，存储转换后的数据空间不足。";
                case 0x040B0002: return "转换出错";
                case 0x040B1001: return "创建步启始位表失败";
                case 0x040B1002: return "读取步信息出错";
                case 0x040B1003: return "步号出错";
                case 0x040B1004: return "读取操作输出失败/传输中间码状态出错";
                case 0x040B1005: return "保护内部工作区域失败出错";
                case 0x040B1006: return "设定字符存储器中X方向最大值出错";
                case 0x040B1007: return "内部工作区域不足出错";
                case 0x040B1008: return "堆栈溢出、异常字符存储器";
                case 0x040B1009: return "存储块数不足出错";
                case 0x040B100A: return "无SFC 程序出错";
                case 0x04050001: return "指定字符串异常出错，指定软元件字符串不正确。";
                case 0x04050002: return "软元件点数出错，软元件点数超出范围。";
                case 0x04050003: return "其它出错，(软元件字符串转换成软元件中间码时产生的其";
                case 0x04051001: return "软元件名出错，指定的软元件中间码分类不正确。";
                case 0x04051002: return "软元件名出错，指定的扩展规格软元件中间码分类不正确。";
                case 0x04051003: return "其它出错，(软元件中间码转换成软元件字符串时产生的其";
                case 0x04052001: return "指定字符串异常出错，指定软元件字符串不正确。";
                case 0x04052002: return "软元件点数出错，软元件点数超出范围。";
                case 0x04052003: return "其它出错，(软元件字符串转换成软元件继承码时产生的其";
                case 0x04053001: return "软元件继承出错，指定的软元件中间码分类不正确。";
                case 0x04053002: return "软元件继承出错，指定的扩展规格软元件中间码分类不正确。";
                case 0x04053003: return "软元件继承出错，设备指定部件整流不正确。";
                case 0x04053004: return "软元件继承出错，补充设备指定部件整流不正确。";
                case 0x04053005: return "其它出错，(软元件继承码转换成软元件字符串时产生的其";
                case 0x04064001: return "软元件中间码异常出错，软元件的中间码不正确。";
                case 0x04064002: return "其它出错，(软元件中间码转换成软元件名时产生的其它错";
                case 0x04065001: return "软元件名异常出错，指定的软元件中间码分类不正确。";
                case 0x04065002: return "软元件名异常出错，指定的扩展规格软元件中间码分类不正确。";
                case 0x04065003: return "其它出错，(软元件名转换成中间码时产生的其它错误。)";
                case 0x04066001: return "软元件中间码出错，软元件的中间码不正确。";
                case 0x04066002: return "其它出错，(软元件中间码转换成软元件继承码时产生的其";
                case 0x04067001: return "软元件继承出错，指定的软元件中间码分类不正确。";
                case 0x04067002: return "软元件继承出错，指定的扩展规格软元件中间码分类不正确。";
                case 0x04067003: return "软元件继承出错，指定软元件的校正部分不正确。";
                case 0x04067004: return "软元件继承出错，指定扩展软元件的校正部分不正确。";
                case 0x04067005: return "其它出错，(设备表现码转换成设备中间码时产生其它错";
                case 0x04070001: return "公共数据转换出错，输入的软元件注释数据不正确。";
                case 0x04070002: return "公共数据不足，转换数据不充分。";
                case 0x04070003: return "存储区域不足，转换数据存储区域不足。";
                case 0x04071001: return "转换PLC 数据出错，输入的软元件注释数据不正确。";
                case 0x04071002: return "PLC数据不足出错，要转换的数据不足。";
                case 0x04071003: return "存储区域不足，转换数据存储区域不足。";
                case 0x04072001: return "打开出错，创建转换目标失败。";
                case 0x04072002: return "PLC 类型出错，指定的PLC 类型不存在。";
                case 0x04072003: return "未转换出错，转换目标不存在。";
                case 0x04072004: return "输入数据出错，输入数据不正确。";
                case 0x04073001: return "公共程序数据转换出错";
                case 0x04073002: return "公共程序数据转换出错";
                case 0x04073101: return "PLC程序数据转换出错";
                case 0x04074001: return "公共数据参数出错";
                case 0x04074002: return "公共网络参数数据出错，参数块存在，但其内部数据未设置。";
                case 0x04074101: return "PLC 参数数据出错";
                case 0x04074102: return "PLC 网络参数数据出错，参数块存在，但其内部数据未设置。";
                case 0x04074103: return "误差出错";
                case 0x04074201: return "指定网络类型出错，指定的PLC不支持该网络类型。";
                case 0x04074202: return "参数块号出错，与指定参数块号相应的块不存在。";
                case 0x04074203: return "参数块内容出错，与指定获支持的内容不同。";
                case 0x04074204: return "参数块信息出错，指定块号不存在。";
                case 0x04074205: return "默认参数块异常，指定块号不存在。";
                case 0x04074301: return "转换公共参数块时出错";
                case 0x04074302: return "1001号公共参数块中出错，RUN-PAUSE设置值存在标记不正确。";
                case 0x04074303: return "1003号公共参数块中出错";
                case 0x04074304: return "1008号公共参数块中出错";
                case 0x04074305: return "1100号公共参数块中出错";
                case 0x04074306: return "2001号公共参数块中出错，指定设备中间码不存在。";
                case 0x04074307: return "3000号公共参数块中出错";
                case 0x04074308: return "3002号公共参数块中出错";
                case 0x04074309: return "3004号公共参数块中出错，报警器显示模式设置不正确。";
                case 0x0407430A: return "4000号公共参数块中出错，未创建I/O分配数据。";
                case 0x0407430: return "b5000号公共参数块中出错，不支持指定网络。";
                case 0x0407430C: return "5001号公共参数块中出错，访问其它交换时，有效单元编号未设置。";
                case 0x0407430D: return "5002号公共参数块中出错";
                case 0x0407430E: return "5003号公共参数块中出错";
                case 0x0407430F: return "5NM0号公共参数块中出错";
                case 0x04074310: return "5NM1号公共参数块中出错";
                case 0x04074311: return "5NM2号公共参数块中出错";
                case 0x04074312: return "5NM3号公共参数块中出错";
                case 0x04074313: return "6000号公共参数块中出错";
                case 0x04074314: return "FF18号公共参数块中出错，链接参数容量未设置。";
                case 0x04074315: return "FF25号公共参数块中出错，计算检查电路未设置。";
                case 0x04074316: return "FF30号公共参数块中出错，范例数据路径未创建。";
                case 0x04074317: return "FF31号公共参数块中出错，状态锁存数据未创建。";
                case 0x04074318: return "FF42号公共参数块中出错，计时器处理点数未设置。";
                case 0x04074319: return "FF30号公共参数块中出错，为指定的扩展计时器设置的软元件值不存在。";
                case 0x0407431A: return "FF44号公共参数块中出错";
                case 0x0407431: return "bFF45号公共参数块中出错";
                case 0x0407431C: return "FF60号公共参数块中出错，未设置终端设置。";
                case 0x0407431D: return "FF70号公共参数块中出错，用户释放区域未设置。";
                case 0x04074401: return "转换PLC 参数块出错";
                case 0x04074402: return "1001号PLC 参数块中出错";
                case 0x04074403: return "1003号PLC 参数块中出错";
                case 0x04074404: return "1008号PLC 参数块中出错";
                case 0x04074405: return "1100号PLC 参数块中出错";
                case 0x04074406: return "2001号PLC 参数块中出错";
                case 0x04074407: return "3000号PLC 参数块中出错";
                case 0x04074408: return "3002号PLC 参数块中出错";
                case 0x04074409: return "3004号PLC 参数块中出错";
                case 0x0407440A: return "4000号PLC 参数块中出错";
                case 0x0407440: return "b5000号PLC 参数块中出错，不支持指定的网络类型。";
                case 0x0407440C: return "5001号PLC 参数块中出错";
                case 0x0407440D: return "5002号PLC 参数块中出错";
                case 0x0407440E: return "5003号PLC 参数块中出错";
                case 0x0407440F: return "5NM0号PLC 参数块中出错，不支持指定的网络类型。";
                case 0x04074410: return "5NM1号PLC 参数块中出错";
                case 0x04074411: return "5NM2号PLC 参数块中出错，不支持指定的网络类型。";
                case 0x04074412: return "5NM3号PLC 参数块中出错";
                case 0x04074413: return "6000号PLC 参数块中出错";
                case 0x04074414: return "FF18号PLC 参数块中出错";
                case 0x04074415: return "FF25号PLC 参数块中出错";
                case 0x04074416: return "FF30号PLC 参数块中出错";
                case 0x04074417: return "FF31号PLC 参数块中出错";
                case 0x04074418: return "FF42号PLC 参数块中出错";
                case 0x04074419: return "FF43号PLC 参数块中出错";
                case 0x0407441A: return "FF44号PLC 参数块中出错";
                case 0x0407441: return "bFF45号PLC 参数块中出错";
                case 0x0407441C: return "FF60号PLC 参数块中出错";
                case 0x0407441D: return "FF70号PLC 参数块中出错";
                case 0x04075001: return "公共数据转换出错，转换软元件存储器的设置部分时失败。";
                case 0x04075002: return "公共数据转换出错，转换软元件存储器的数据部分时失败。";
                case 0x04075003: return "公共数据转换出错，软元件存储器的数据部分不存在。";
                case 0x04075101: return "PLC数据转换出错，转换软元件存储器的设置部分时失败。";
                case 0x04075102: return "PLC数据转换出错，转换软元件存储器的数据部分时失败。";
                case 0x04076001: return "公共数据转换出错，转换软元件注释的设置部分时失败。";
                case 0x04076002: return "公共数据转换出错，转换软元件注释的数据部分时失败。";
                case 0x04076101: return "PLC数据转换出错，转换软元件注释的设置部分时失败。";
                case 0x04076102: return "PLC数据转换出错，转换软元件注释的设置部分时失败。";
                case 0x04077001: return "公共数据转换出错，转换范例路径的设置部分时失败。";
                case 0x04077002: return "公共数据转换出错，转换范例路径的数据部分时失败。";
                case 0x04077101: return "PLC数据转换出错，转换范例路径的设置部分时失败。";
                case 0x04077102: return "PLC数据转换出错，转换范例路径的数据部分时失败。";
                case 0x04078001: return "公共数据转换出错，转换状态锁存的设置部分时失败。";
                case 0x04078002: return "公共数据转换出错，转换状态锁存的数据部分时失败。";
                case 0x04078101: return "PLC数据转换出错，转换状态锁存的设置部分时失败。";
                case 0x04078102: return "PLC数据转换出错，转换状态锁存的数据部分时失败。";
                case 0x04079101: return "PLC数据转换失败历史记录出错";
                case 0x0407A101: return "PLC 文件列表数据转换出错";
                case 0x0407B101: return "PLC数据转换信息出错";
                case 0x0407C001: return "间接地址转换为软元件名出错，软元件名存储区未保护。";
                case 0x0407C002: return "软元件名转换为间接地址出错，间接地址存储区未保护。";
                case 0x0407C003: return "间接地址转换为软元件请求出错，没有保护设备显示存储区。";
                case 0x0407C004: return "软元件请求转换为间接地址出错，间接地址存储区未保护。";
                case 0x0407C005: return "间接地址转换为软元件字符串出错，软元件字符串存储区未保护。";
                case 0x0407C006: return "软元件字符串转换为中间码出错，间接地址存储区未保护。";
                case 0x0407C007: return "中间码转换为软元件名出错，软元件名存储区未保护。";
                case 0x0407C008: return "软元件名转换为中间码出错，中间码存储区未保护。";
                case 0x0407C009: return "中间码转换为软元件请求时出错，未保护软元件请求存储区。";
                case 0x0407C00A: return "Device Representation 转换为中间码出错，中间码存储区未保护。";
                case 0x0407C00: return "b中间码转换为间接地址出错，间接地址存储区未保护。";
                case 0x0407C00C: return "间接地址转换为中间码出错，中间码存储区未保护。";
                case 0x0407C00D: return "PLC 类型出错，不支持指定的PLC 类型。";
                case 0x0407C00E: return "软元件字符串出错，不支持指定的软元件。";
                case 0x0407C00F: return "软元件字符串出错，指定软元件字符串、类型不正确。";
                case 0x0407C010: return "软元件出错，指定PLC 不支持指定软元件。";
                case 0x0407C011: return "PLC 类型出错，不支持指定的PLC 类型。";
                case 0x0407C012: return "软元件超出范围出错，对于AnA系统，指定的软元件超出AnA系统范";
                case 0x0407D001: return "公共数据转换出错，转换SFC路径条件设置部分出错。";
                case 0x0407D002: return "公共数据转换出错，转换SFC路径条件数据部分出错。";
                case 0x0407D101: return "PLC数据转换出错，转换SFC路径条件设置部分出错。";
                case 0x0407D102: return "PLC数据转换出错，转换SFC路径条件数据部分出错。";
                case 0x04080001: return "中间码分类超出范围出错，指定中间码分类超出范围。";
                case 0x04080002: return "扩展规格中间码分类超出范围出错，指定的扩展规格中间码超出范围。";
                case 0x04080003: return "缺少检查软元件点数出错，未检查软元件点数。";
                case 0x04090001: return "GPP工程出错，指定的PLC类型与GPP 工程类型不匹配。";
                case 0x04090002: return "文件类型出错，指定的GPP 工程类型与文件类型不匹配。";
                case 0x04090010: return "转换的GPP数据不足，没有数据可以转换。指定数据大小不正确。";
                case 0x04090011: return "存储转换数据的空间不足，存储转换数据的空间不足。";
                case 0x04090012: return "转换GPP 数据出错，转换的GPP 数据不正确。";
                case 0x04090110: return "转换的GPP数据不足，没有数据可以转换。指定数据大小不正确。";
                case 0x04090111: return "存储转换数据的空间不足，存储转换数据的空间不足。";
                case 0x04090112: return "转换数据出错，要转换的数据不正确。";
                case 0x04FFFFFF: return "其它出错";
                case 0x10000001: return "无命令出错";
                case 0x10000002: return "运行MX Component的DLL 通讯失败";
                case 0x10000003: return "打开失败(DiskDrive)";
                case 0x10000004: return "重复打开出错 退出程序并重启IBM-PC/AT 兼容计算机。";
                case 0x10000005: return "存取文件出错";
                case 0x10000006: return "文件夹名出错";
                case 0x10000007: return "拒绝存取文件出错";
                case 0x10000008: return "磁盘已满出错";
                case 0x10000009: return "删除文件出错";
                case 0x1000000A: return "文件名出错";
                case 0x1000000C: return "由于另一个程序或线程在发送请求导致运行失，败。";
                case 0x1000000D: return "创建文件夹出错";
                case 0x1000000E: return "文件夹/文件类型出错";
                case 0x1000000F: return "地址偏移量出错";
                case 0x10000010: return "取消请求，发生取消处理。";
                case 0x10000011: return "保护存储器出错";
                case 0x10000012: return "未执行打开 退出程序并重启IBM-PC/AT 兼容计算机。";
                case 0x10000013: return "未执行连接出错";
                case 0x10000014: return "无效目标出错";
                case 0x10000015: return "取消请求失败出错";
                case 0x10000016: return "读取状态失败出错";
                case 0x10000017: return "指定大小(软元件数目)未经批准。";
                case 0x10000018: return "没有注册的软元件 退出程序并重启IBM-PC/AT 兼容计算机。";
                case 0x10000019: return "未执行数组";
                case 0x1000001A: return "未执行读取出错";
                case 0x1000001: return "b创建标记出错";
                case 0x1000001C: return "访问操作结束";
                case 0x1000001D: return "冗余软元件出错";
                case 0x1000001E: return "检索注册失败";
                case 0x1000001F: return "文件类型出错";
                case 0x10000020: return "软元件存储器类型出错";
                case 0x10000021: return "程序范围出错";
                case 0x10000022: return "TEL 类型出错";
                case 0x10000023: return "访问TEL 出错";
                case 0x10000024: return "取消标记类型出错";
                case 0x10000030: return "软元件重复注册出错";
                case 0x10000031: return "未注册软元件出错";
                case 0x10000032: return "指定软元件出错";
                case 0x10000033: return "指定软元件范围出错";
                case 0x10000034: return "写入文件出错";
                case 0x10000040: return "启动服务器失败";
                case 0x10000041: return "停止服务器出错，停止服务器失败。";
                case 0x10000042: return "服务器启动两次出错";
                case 0x10000043: return "未启动服务器出错";
                case 0x10000044: return "源文件超时出错";
                case 0x10000045: return "服务器类型出错";
                case 0x10000046: return "访问服务器失败出错";
                case 0x10000047: return "已访问服务器出错";
                case 0x10000048: return "启动模拟器失败";
                case 0x10000049: return "退出模拟器失败";
                case 0x1000004A: return "未启动模拟器出错";
                case 0x1000004: return "b模拟器类型出错";
                case 0x1000004C: return "不支持模拟器出错";
                case 0x1000004D: return "模拟器启动两次出错";
                case 0x1000004E: return "未启动共享存储器出错";
                case 0xF0000001: return "无许可证出错，IBM-PC/AT兼容计算机未获得许可证。";
                case 0xF0000002: return "读取设置数据出错，读取逻辑站号设置数据失败。";
                case 0xF0000003: return "已经打开出错，在打开状态下执行打开函数。";
                case 0xF0000004: return "未打开出错，未执行打开函数。";
                case 0xF0000005: return "初始化出错，MX Component内部程序初始化失败。";
                case 0xF0000006: return "保护存储器出错，保护MX Component内部存储器失败。";
                case 0xF0000007: return "不支持函数出错，函数不支持。";
                case 0xF1000001: return "字符代码转换出错，字符代码转换(UNICODE ASCII码或ASCII码";
                case 0xF1000002: return "第一个I/O编号出错，指定的第一个I/O编号值未经批准。";
                case 0xF1000003: return "缓冲器地址出错，指定的缓冲器地址数值未经批准。";
                case 0xF1000004: return "读取缓冲区大小出错，读取缓冲器，不能获得指定大小。";
                case 0xF1000005: return "大小出错，读/写函数中指定大小异常。";
                case 0xF1000006: return "操作出错，指定的远程操作为一异常值。";
                case 0xF1000007: return "时钟数据出错，时钟数据异常。";
                case 0xF1000008: return "M监控器的注册点数超额。，EntryDeviceStatus函数中注册的软元件点数为";
                case 0xF1000009: return "注册的软元件监视数据出错";
                case 0xF1000010: return "启动软元件状态监视器处理失败。，结束软元件状态监视器处理失败。";
                case 0xF1000011: return "变量数据类型出错。";
                case 0xF1000012: return "软元件状态监视的时间间隔值超出1 秒至1小时，范围(1至3600)。";
                case 0xF1000013: return "已经连接出错，程序运行后重复执行连接。";
                case 0xF1000014: return "程序运行后重复执行连接。，电话号码含有“0123456789-*#”以外的字符。";
                case 0xF1000015: return "专用控制失败出错，在执行连接和断开函数时专用控制失败。";
                case 0xF1000016: return "连接电话线出错，除了用于MX Comonent，电话线正连接其它应用";
                case 0xF1000017: return "电话线未连接出错。，电话线未连接。";
                case 0xF1000018: return "无电话号码出错。，电话号码未设定。";
                case 0xF1000019: return "无关闭出错，在打开状态时执行断开。";
                case 0xF100001A: return "连接目标电话线不匹配出错。，对于已经连接上电话线的端口使用不同的电话号";
                case 0xF100001: return "b控制类型不匹配出错，对于控制类型不同于已经连接电话线的一个对";
                case 0xF100001C: return "未断开出错。，当对连接上电话线的对象执行断开函数时，发现";
                case 0xF100001D: return "未连接出错，在连接或者断开执行之前执行打开。";
                case 0xF100001E: return "严重出错";
                case 0xF100001F: return "设置打开时间出错，用于连接和打开的电话号码和端口号码的设定有";
                case 0xF2000002: return "来自目标电话的出错响应。，可能为以下原因：";
                case 0xF2000003: return "收到无效数据。，可能为以下原因：";
                case 0xF2000004: return "调制解调器无反应。，可能为以下原因：";
                case 0xF2000005: return "可能没有断开线路。 检查线路。";
                case 0xF2000006: return "个人计算机调制解调器没有收到AT 命令。，可能为以下原因：";
                case 0xF2000007: return "调制解调器对于标准出口命令没有正确响应。";
                case 0xF2000009: return "调制解调器对于断开线路命令没有正确响应。 检查调制解调器。";
                case 0xF200000A: return "对象没有接收信号。，* 另一端调制解调器的接收设置可能不正确。";
                case 0xF200000: return "b接收回呼的等待时间超时。";
                case 0xF200000C: return "无法分辨A6TEL、Q6TEL、QJ71C24单元的口令。";
                case 0xF2010001: return "断开回呼线路的等待时间不在0 至180秒之间。，执行回呼的延迟时间不在0 至1800秒之间。";
                case 0xF2010002: return "QJ71C24未收到指定的连接函数。，可能为以下原因：";
                case 0xF2010003: return "QJ71C24不允许自动连接(在固定回呼或指定号码，时)。";
                case 0xF2100005: return "可能线路没有断开。";
                case 0xF2100008: return "调制解调器对于从个人计算机发送的数据无反，应。";
                case 0xF2100006: return "调制解调器没有收到AT启动命令。";
                case 0xF2100007: return "个人计算机调制解调器对出口命令无反应。";
                //case 0xF21000**: return "调制解调器没有反应。，可能为以下原因：";
                //case 0xF21001**: return "A(Q)6TEL/C24没有反应。，可能为以下原因：";
                //case 0xF202****: return "有通讯失败。，下面的原因可以根据情况而定。";
                default: return "Unkonw error";
            }
        }
    }
}
