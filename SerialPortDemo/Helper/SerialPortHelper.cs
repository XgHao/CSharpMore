using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using SerialPortDemo.Common;

namespace SerialPortDemo.Helper
{
    public class SerialPortHelper
    {
        /// <summary>
        /// 串口操作对象
        /// </summary>
        public SerialPort SerialPortObj { get; set; }

        /// <summary>
        /// 获取当前计算机的可用端口列表
        /// </summary>
        public string[] PortNameList { get; } = SerialPort.GetPortNames();

        /// <summary>
        /// 进制转换类
        /// </summary>
        public SysConvertHelper SysconvertHelper { get; } = new SysConvertHelper();

        /// <summary>
        /// 初始化
        /// </summary>
        public SerialPortHelper()
        {
            RefreshSerialPort();
        }


        /// <summary>
        /// 根据端口名称操作
        /// </summary>
        /// <param name="portName">端口名</param>
        /// <param name="serialPortStatus">具体操作</param>
        /// <returns></returns>
        public bool OpenSerialPort(string portName,SerialPortStatus serialPortStatus)
        {
            switch (serialPortStatus)
            {
                //打开
                case SerialPortStatus.Open:
                    SerialPortObj.PortName = portName;
                    SerialPortObj.Open();
                    break;
                //关闭
                case SerialPortStatus.Close:
                    SerialPortObj.Close();
                    break;
                default:
                    break;
            }

            //返回串口打开的状态
            return SerialPortObj.IsOpen;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="sendFormat">数据格式</param>
        public void SendData(string data,SendFormat sendFormat)
        {
            if (!SerialPortObj.IsOpen)
            {
                throw new Exception("端口未打开，请打开相关端口");
            }

            byte[] byteData = null;

            switch (sendFormat)
            {
                case SendFormat.String:
                    byteData = SysconvertHelper.StringToBytes(data, false);
                    break;
                case SendFormat.Hex:
                    if (!data.Valid_IsHex())
                        throw new Exception("数据不是十六进制");
                    //将16进制转换为byte[]数组
                    byteData = SysconvertHelper.From16ToBtyes(data);
                    break;
                default:
                    break;
            }

            //发送数据
            SerialPortObj.Write(byteData, 0, byteData.Length);
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        public byte[] ReceiveData()
        {
            //定义一个接收数组，获取接收缓冲区数据的字节数
            byte[] byteData = new byte[SerialPortObj.BytesToRead];
            //读取数据
            SerialPortObj.Read(byteData, 0, SerialPortObj.BytesToRead);

            return byteData;
        }

        /// <summary>
        /// 刷新串口
        /// </summary>
        public void RefreshSerialPort()
        {
            SerialPortObj = null;
            SerialPortObj = new SerialPort
            {
                BaudRate = 9600,    //波特率
                Parity = Parity.None, //奇偶校验
                DataBits = 8,         //数据位
                StopBits = StopBits.One,  //使用一个停止位
            };
        }
    }
}
