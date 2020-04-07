using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SerialPortDemo.Common
{
    /// <summary>
    /// 验证文本
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// 是否是十六进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Valid_IsHex(this string str)
        {
            return Regex.IsMatch(str, @"([^A-Fa-f0-9]|\s+?)+");
        }
    }
}
