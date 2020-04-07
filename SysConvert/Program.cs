using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            int d;
            while ((d = int.Parse(Console.ReadLine())) != 0) 
            {
                Console.WriteLine($"【十进制{d}】的十六进制为{Convert_DEC_into_HEX(d)}");
            }
        }

        #region 十进制=>十六进制
        /// <summary>
        /// 十进制=>十六进制
        /// </summary>
        /// <param name="srcDEC"></param>
        /// <returns></returns>
        public static string Convert_DEC_into_HEX(int srcDEC)
        {
            if (srcDEC < 16)
                return DEC_To_HEX(srcDEC);

            string tarHEX = string.Empty;
            int c;
            int len = 0;      //目标长度
            int n = srcDEC;
            int temp = srcDEC;
            while (n >= 16)
            {
                len++;
                n /= 16;
            }
            string[] m = new string[len];
            int i = 0;
            do
            {
                c = srcDEC / 16;
                m[i++] = DEC_To_HEX(srcDEC % 16);
                srcDEC = c;
            } while (c >= 16);
            tarHEX = DEC_To_HEX(srcDEC);
            for (int j = m.Length - 1; j >= 0; j--)
            {
                tarHEX += m[j];
            }
            return tarHEX;
        }

        /// <summary>
        /// 对应转换
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string DEC_To_HEX(int dec)
        {
            switch (dec)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return dec.ToString();
            }
        }
        #endregion
    }
}
