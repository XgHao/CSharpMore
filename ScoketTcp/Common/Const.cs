using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoketTcp.Common
{
    public static class Const
    {
        /// <summary>
        /// 缓存区字节区的长度
        /// </summary>
        public static readonly long BufferByteSize = int.Parse(ConfigurationManager.AppSettings["BufferByteSize"]) * 1024 * 1024;

    }
}
