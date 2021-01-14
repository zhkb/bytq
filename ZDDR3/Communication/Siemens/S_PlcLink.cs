using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Communication
{

    /// <summary>
    /// 西门子S7-300PLC串口通讯设备类
    /// </summary>
    public class SPlcLink
    {
        public string PLCConnectionIP = "";
        public short PLCConNo = 0;
        private bool _isOpen = false;   //是否打开连接
        private bool State = false;   //是否打开连接
        private IntPtr equipHandle = new IntPtr(Marshal.SizeOf(typeof(int)));
        private UInt16 UConNr = 0;
        private IntPtr structToIntPtr<T>(T s)
        {
            int nSizeOfT = Marshal.SizeOf(typeof(T));
            int nSizeOfIntPtr = Marshal.SizeOf(typeof(IntPtr));
            IntPtr Result = new IntPtr();
            Result = Marshal.AllocHGlobal(nSizeOfT);
            Marshal.StructureToPtr(s, (IntPtr)((UInt32)Result), true);
            return Result;
        }

        private T IntPtrTostruct<T>(IntPtr p)
        {
            return (T)Marshal.PtrToStructure(p, typeof(T));
        }
        private int Swap(int a)
        {
            return (a >> 8 & 0xFF) + (a << 8 & 0xFF00);
        }
        public bool Open()
        {
            try
            {

                lock (this)
                {
                    if (this._isOpen == true)
                    {
                        return true;
                    }
                    this.State = false;
                    /////////////////////////////////////////////////////////////////////////////////
                    short ConNr = PLCConNo; // First connection；(0  63)；(max. 64 connections).
                    string AccessPoint = "S7ONLINE"; // Default access point——S7ONLINE                  
                    Prodave6.CON_TABLE_TYPE ConTable;// Connection table
                    int ConTableLen = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Prodave6.CON_TABLE_TYPE));// Length of the connection table
                    int Result;

                    ConTable.Adr = this.ConvertIpToAddr();
                    ConTable.AdrType = 2; // Type of address: MPI/PB (1), IP (2), MAC (3)
                    ConTable.SlotNr = 2; // 插槽号
                    ConTable.RackNr = 0; // 机架号  

                    Result = Prodave6.LoadConnection_ex6(ConNr, AccessPoint, ConTableLen, ref ConTable);

                    //以下测试SetActiveConnection_ex6
                    //UInt16 UConNr = (UInt16)PLCConNo;
                    //Result = Prodave6.SetActiveConnection_ex6(UConNr);

                    ///////////////////////////////////////////////////////////////////
                    if ((Result != 0) && (Result != 39))  // 39已经初始化
                    {
                       // Console.WriteLine("PLC连接失败：" + this.GetErrInfo(Result));
                        this.State = false;
                        return this.State;
                    }
                    else
                    {
                        this.State = true;
                        this._isOpen = true;
                    }
                    return this.State;
                }
            }
            catch
            {
                this.State = false;
                return this.State;
            }
        }


        private byte[] ConvertIpToAddr()
        {
            string ip = PLCConnectionIP;
            string[] ips = ip.Split(new char[] { '.' });
            byte[] addr = new byte[6] { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < ips.Length; i++)
            {
                addr[i] = Convert.ToByte(ips[i]);
            }
            return addr;
        }

        /// <summary>
        /// PLC数据读取方法
        /// </summary>
        /// <param name="block">要读取的块号</param>
        /// <param name="start">要读取的起始字</param>
        /// <param name="len">要读取的长度，最大255，超过255则不读取</param>
        /// <param name="buff"></param>
        /// <returns></returns>
        public bool Read(string block, int start, int len, out object[] buff)
        {
            lock (this)
            {
                UInt16 UConNr = (UInt16)PLCConNo;
                int Result = Prodave6.SetActiveConnection_ex6(UConNr);

                buff = new object[len];
                try
                {
                    for (int i = 0; i < len; i++)
                    {
                        buff[i] = 0;
                    }
                    int maxOneLen = 100;                    //单次允许读取的最大长度，限制为100个字
                    int count = len / maxOneLen;            //要读取的次数
                    int mod = len % maxOneLen;              //剩余的长度
                    bool flag = true;                       //保存读取标志
                    for (int i = 0; i < count; i++)
                    {
                        object[] _buff = new object[maxOneLen];
                        flag = this.ReadByLen(block, start + i * maxOneLen, maxOneLen, out _buff);
                        if (flag == false)
                        {
                            this.State = flag;
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
                            this.State = flag;
                            return false;
                        }
                        for (int k = count * maxOneLen; k < count * maxOneLen + mod; k++)
                        {
                            buff[k] = _buff[k - count * maxOneLen];
                        }
                    }
                    this.State = flag;
                    return flag;
                }
                catch (Exception ex)
                {
                    //ICSharpCode.Core.LoggingService.Error(String.Format("读取PLC（AB500）设备失败-({0})!", ex.Message));
                    this.State = false;
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
        /// 
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
                ushort[] _buff = new ushort[len];
                ushort iblock = Convert.ToUInt16(block);
                UInt32 pAmount = Convert.ToUInt32(len * 2);
                UInt32 pDataLen = Convert.ToUInt32(len * 2);
                //int iResult = Prodave6.db_read_ex6(iblock, Prodave6.DatType.WORD, (ushort)start, ref pAmount, 1024, _buff, ref pDataLen);
                byte[] b_buff = new byte[len * 2];
                int iResult = Prodave6.field_read_ex6(Prodave6.FieldType.D, iblock, (ushort)(start * 2), pAmount, 1024, b_buff, ref pDataLen);
                if (iResult != 0)
                {
                    Console.WriteLine("块号:{0},起始字:{1},长度:{2};PLC读取失败:{3}", block, start, len, this.GetErrInfo(iResult));
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
                for (int i = 0; i < len; i++)
                {
                    //int value = (int)_buff[i];
                    //buff[i] = Swap(value);
                    //buff[i] = value;
                    //buff[i] = Prodave6.bytes_2_word(b_buff[i * 2 + 1], b_buff[i * 2]);
                    int value = Prodave6.bytes_2_word(b_buff[i * 2 + 1], b_buff[i * 2]);
                    buff[i] = Swap(value);
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
        public bool Write(int block, int start, object[] buff)
        {
            lock (this)
            {
                try
                {
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
                ushort[] _buff = new ushort[buff.Length];
                for (int i = 0; i < buff.Length; i++)
                {
                    int value = 0;
                    int.TryParse(buff[i].ToString(), out value);
                    value = Swap(value);
                    _buff[i] = (ushort)value;
                }
                //int iResult = W95_S7.db_write(iblock, start, ref state, _buff);

                ushort iblock = Convert.ToUInt16(block);
                UInt32 pAmount = Convert.ToUInt32(_buff.Length);

                //int iResult = Prodave6.db_write_ex6(iblock, Prodave6.DatType.WORD, (ushort)start, ref pAmount, 1024, _buff);
                //byte[] b = new byte[] { 1 };

                byte[] b_buff = new byte[_buff.Length * 2];
                for (int i = 0; i < _buff.Length; i++)
                {
                    byte[] bb = Prodave6.word_2_bytes(_buff[i]);
                    b_buff[i * 2] = bb[1];
                    b_buff[i * 2 + 1] = bb[0];
                }
                int iResult = Prodave6.field_write_ex6(Prodave6.FieldType.D, iblock, (ushort)(start * 2), pAmount * 2, (uint)b_buff.Length, b_buff);
                if (iResult != 0)
                {
                    Console.WriteLine("块号:{0},起始字:{1},PLC【西门子S7-300】写入失败:{2}", block, start, this.GetErrInfo(iResult));
                    return false;
                }

                return true;
            }
        }
        public void Close()
        {
            lock (this)
            {
                try
                {
                    //以下测试GetLoadedConnections_ex6
                    UInt32 BufLen = 64;
                    int[] pBufferI = new int[64];
                    Prodave6.GetLoadedConnections_ex6(BufLen, pBufferI);

                    //int result = W95_S7.unload_tool();
                    int result = Prodave6.UnloadConnection_ex6(UConNr);

                    //以下测试GetErrorMessage_ex6
                    int ErrorNr = 0x7040; // Block boundary exceeded, correct the number
                    StringBuilder Buffer = new StringBuilder(300); // Transfer buffer for error text
                    BufLen = (UInt32)Buffer.Capacity; // Buffer length     
                    result = Prodave6.GetErrorMessage_ex6(ErrorNr, BufLen, Buffer);

                    Console.WriteLine(Buffer);

                    if (result != 0)
                    {
                        Console.WriteLine("PLC【西门子S7-300】关闭失败：" + this.GetErrInfo(result));
                    }
                    else
                    {
                        //this.State = false;
                        //this._isOpen = false;
                    }

                    this.State = false;
                    this._isOpen = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PLC【西门子S7-300】关闭失败：" + ex.Message);
                }
            }
        }

        /// <summary>根据错误代码返回错误信息
        /// 例如int errCode=ActiveConn(1);  sring errInfo = GetErrInfo(err);
        /// </summary>
        /// <param name="errCode">错误码</param>
        /// <returns>错误信息</returns>
        public string GetErrInfo(int errCode)
        {
            switch (errCode)
            {
                case -1: return "User-Defined  Error!";  //自定义错误,主要是参数传递错误!
                case 0x0000: return "Success";
                case 0x0001: return "Load dll failed";
                case 0x00E1: return "User max";
                case 0x00E2: return "SCP entry";
                case 0x00E7: return "SCP board open";
                case 0x00E9: return "No Windows server";
                case 0x00EA: return "Protect";
                case 0x00CA: return "SCP no resources";
                case 0x00CB: return "SCP configuration";
                case 0x00CD: return "SCP illegal";
                case 0x00CE: return "SCP incorrect parameter";
                case 0x00CF: return "SCP open device";
                case 0x00D0: return "SCP board";
                case 0x00D1: return "SCP software";
                case 0x00D2: return "SCP memory";
                case 0x00D7: return "SCP no meas";
                case 0x00D8: return "SCP user mem";
                case 0x00DB: return "SCP timeout";
                case 0x00F0: return "SCP db file does not exist";
                case 0x00F1: return "SCP no global dos memory";
                case 0x00F2: return "SCP send not successful";
                case 0x00F3: return "SCP receive not successful";
                case 0x00F4: return "SCP no device available";
                case 0x00F5: return "SCP illegal subsystem";
                case 0x00F6: return "SCP illegal opcode";
                case 0x00F7: return "SCP buffer too short";
                case 0x00F8: return "SCP buffer1 too short";
                case 0x00F9: return "SCP illegal protocol sequence";
                case 0x00FA: return "SCP illegal PDU arrived";
                case 0x00FB: return "SCP request error";
                case 0x00FC: return "SCP no license";
                case 0x0101: return "Connection is not established / parameterized";
                case 0x010a: return "Negative Acknowledgment received / timeout errors";
                case 0x010c: return "Data not available or locked";
                case 0x012A: return "No system memory left";
                case 0x012E: return "Incorrect parameter";
                case 0x0132: return "No storage space in the DPRAM";
                case 0x0200: return "xx";
                case 0x0201: return "Falsche Schnittstelle angegeben";
                case 0x0202: return "Incorrect interface indicated";
                case 0x0203: return "Toolbox already installed";
                case 0x0204: return "Toolbox with other compounds already installed";
                case 0x0205: return "Toolbox is not installed";
                case 0x0206: return "Handle can not be set";
                case 0x0207: return "Data segment can not be blocked";
                case 0x0209: return "Erroneous data field";
                case 0x0300: return "Timer init error";
                case 0x0301: return "Com init error";
                case 0x0302: return "Module is too small, DW does not exist";
                case 0x0303: return "Block boundary erschritten, number correct";
                case 0x0310: return "Could not find any hardware";
                case 0x0311: return "Hardware defective";
                case 0x0312: return "Incorrect configuration parameters";
                case 0x0313: return "Incorrect baud rate/interrupt vector";
                case 0x0314: return "HSA incorrectly parameterized";
                case 0x0315: return "Address already assigned";
                case 0x0316: return "Device already assigned";
                case 0x0317: return "Interrupt not available";
                case 0x0318: return "Interrupt occupied";
                case 0x0319: return "SAP not occupied";
                case 0x031A: return "Could not find any remote station";
                case 0x031B: return "syni error";
                case 0x031C: return "System error";
                case 0x031D: return "Error in buffer size";
                case 0x0320: return "DLL/VxD not found";
                case 0x0321: return "DLL function error";
                case 0x0330: return "Version conflict";
                case 0x0331: return "Com config error";
                case 0x0332: return "smc timeout";
                case 0x0333: return "Com not configured";
                case 0x0334: return "Com not available";
                case 0x0335: return "Serial drive in use";
                case 0x0336: return "No connection";
                case 0x0337: return "Job rejected";
                case 0x0380: return "Internal error";
                case 0x0381: return "Device not in Registry";
                case 0x0382: return "L2 driver not in Registry";
                case 0x0384: return "L4 driver not in Registry";
                case 0x03FF: return "System error";
                case 0x4001: return "Connection is not known";
                case 0x4002: return "Connection is not established";
                case 0x4003: return "Connection is being established";
                case 0x4004: return "Connection is collapsed";
                case 0x0800: return "Toolbox occupied";
                case 0x8001: return "in this mode is not allowed";
                case 0x8101: return "Hardware error";
                case 0x8103: return "Object Access not allowed";
                case 0x8104: return "Context is not supported";
                case 0x8105: return "ungtige Address";
                case 0x8106: return "Type (data) is not supported";
                case 0x8107: return "Type (data) is not consistent";
                case 0x810A: return "Object does not exist";
                case 0x8301: return "Memory on CPU is not sufficient";
                case 0x8404: return "grave error";
                case 0x8500: return "Incorrect PDU Size";
                case 0x8702: return "Invalid address";
                case 0xA0CE: return "User occupied";
                case 0xA0CF: return "User does not pick up";
                case 0xA0D4: return "Connection not available because modem prevents immediate redial (waiting time before repeat dial not kept to) ";
                case 0xA0D5: return "No dial tone";
                case 0xD201: return "Syntax error module name";
                case 0xD202: return "Syntax error function parameter";
                case 0xD203: return "Syntax error Bausteshortyp";
                case 0xD204: return "no memory module in eingeketteter";
                case 0xD205: return "Object already exists";
                case 0xD206: return "Object already exists";
                case 0xD207: return "Module available in the EPROM";
                case 0xD209: return "Module does not exist";
                case 0xD20E: return "no module present";
                case 0xD210: return "Block number is too big";
                case 0xD241: return "Protection level of function is not sufficient";
                case 0xD406: return "Information not available";
                case 0xEF01: return "Wrong ID2";
                case 0xFFFE: return "unknown error FFFE hex";
                case 0xFFFF: return "Timeout error. Interface KVD";
                default: return "Unkonw error";
            }
        }

    }
}
