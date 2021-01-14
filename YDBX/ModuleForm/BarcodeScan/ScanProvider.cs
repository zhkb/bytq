using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarcodeScan
{
    /// <summary>  
    /// 串口 扫描枪  
    /// </summary>  
    public class ScanProvider
    {
        private SerialPort _serialPort;

        public ScanProvider(string portName, int baudRate)
        {
            _serialPort = new SerialPort();
            this.RegisterSerialPort(portName, baudRate);
            _serialPort.DataReceived += _serialPort_DataReceived;
        }

        #region Private Methods  

        /// <summary>  
        /// 注册串口  
        /// </summary>  
        /// <param name="portName">串口名</param>  
        /// <param name="baudRate">波特率</param>  
        private void RegisterSerialPort(string portName, int baudRate)
        {
            // 串口名  
            _serialPort.PortName = portName;
            // 波特率  
            _serialPort.BaudRate = baudRate;
            // 数据位  
            _serialPort.DataBits = 8;
            // 停止位  
            _serialPort.StopBits = System.IO.Ports.StopBits.One;
            // 无奇偶校验位  
            _serialPort.Parity = System.IO.Ports.Parity.None;
        }

        #endregion

        #region Public   

        /// <summary>  
        /// 是否处于打开状态  
        /// </summary>  
        public bool IsOpen
        {
            get
            {
                return _serialPort != null && _serialPort.IsOpen;
            }
        }

        /// <summary>  
        /// 打开串口  
        /// </summary>  
        /// <returns></returns>  
        public bool Open()
        {
            bool RFlag = false;
            try
            {
                if (_serialPort == null)
                    return this.IsOpen;

                if (_serialPort.IsOpen)
                    this.Close();

                _serialPort.Open();
                RFlag = true;
            }
            catch
            {
                RFlag = false;
            }
            return RFlag;

            //return this.IsOpen;
        }

        /// <summary>  
        /// 关闭串口  
        /// </summary>  
        public void Close()
        {
            if (this.IsOpen)
                _serialPort.Close();
        }

        /// <summary>  
        /// 向串口内写入  
        /// </summary>  
        /// <param name="send">写入数据</param>  
        /// <param name="offSet">偏移量</param>  
        /// <param name="count">写入数量</param>  
        public void Write(byte[] send, int offSet, int count)
        {
            if (this.IsOpen)
            {
                _serialPort.Write(send, offSet, count);
            }
        }

        public void Dispose()
        {
            if (this._serialPort == null)
                return;
            if (this._serialPort.IsOpen)
                this.Close();
            this._serialPort.Dispose();
            this._serialPort = null;
        }

        #endregion

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 等待100ms，防止读取不全的情况  
            Thread.Sleep(100);
            byte[] m_recvBytes = new byte[_serialPort.BytesToRead];//定义缓冲区大小  
            int result = _serialPort.Read(m_recvBytes, 0, m_recvBytes.Length);//从串口读取数据  
            if (result <= 0)
                return;
            string strResult = Encoding.ASCII.GetString(m_recvBytes, 0, m_recvBytes.Length);//对数据进行转换  
            _serialPort.DiscardInBuffer();

            if (this.DataReceived != null)
                this.DataReceived(this, new SerialSortEventArgs() { Code = strResult });
        }

        public event EventHandler<SerialSortEventArgs> DataReceived;

        #region Static  

        /// <summary>  
        /// 获取可用串口名称  
        /// </summary>  
        /// <returns></returns>  
        public static string[] GetComNames()
        {
            string[] names = null;
            try
            {
                names = SerialPort.GetPortNames();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return names;
        }

        #endregion
    }
    public class SerialSortEventArgs : EventArgs
    {
        public string Code { get; set; }
    }
}
