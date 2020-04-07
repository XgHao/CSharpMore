using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortDemo.Common
{
    /// <summary>
    /// 十六进制
    /// </summary>
    public enum Enum16Hex
    {
        /// <summary>
        /// 无
        /// </summary>
        None,

        /// <summary>
        /// 空格
        /// </summary>
        Blank,

        /// <summary>
        /// OX
        /// </summary>
        OX,

        /// <summary>
        /// Ox
        /// </summary>
        Ox
    }

    /// <summary>
    /// 端口状态
    /// </summary>
    public enum SerialPortStatus
    {
        /// <summary>
        /// 打开
        /// </summary>
        Open = 0,

        /// <summary>
        /// 关闭
        /// </summary>
        Close = 1
    }

    /// <summary>
    /// 发送数据格式
    /// </summary>
    public enum SendFormat
    {
        /// <summary>
        /// String形式
        /// </summary>
        String=0,
        
        /// <summary>
        /// 十六进制
        /// </summary>
        Hex=1,
    }
}
