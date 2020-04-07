using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HeadAnnotation
{
    public static class Security
    {
        public static string GetMD5PWD(string pwd)
        {
            //新建对象
            MD5 mD5 = new MD5CryptoServiceProvider();
            //字符转字节组，计算HASH值
            byte[] date = mD5.ComputeHash(Encoding.Default.GetBytes(pwd));
            mD5.Dispose();
            return Convert.ToBase64String(date);
        }
    }
}
