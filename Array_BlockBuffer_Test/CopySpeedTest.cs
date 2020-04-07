using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_BlockBuffer_Test
{
    public class CopySpeedTest
    {
        private byte[] Bytes = new byte[3 * 1024 * 1024];
        private int Len { get; set; }

        public CopySpeedTest()
        {
            //使用一个图片文件的流
            using (var fs = new FileStream(@"D:\temp\pic.jpg", FileMode.Open)) 
            {
               Len = fs.Read(Bytes, 0, (int)fs.Length);
            }
        }

        public void ArrayCopy()
        {
            byte[] arr = new byte[Len + 100];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 50000; i++)
            {
                Array.Copy(Bytes, 0, arr, 30, Len);
            }
            stopwatch.Stop();
            Console.WriteLine($"ArryCopy:{stopwatch.ElapsedMilliseconds}");
        }

        public void BlockBuffer()
        {
            byte[] arr = new byte[Len + 100];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 50000; i++)
            {
                Buffer.BlockCopy(Bytes, 0, arr, 30, Len);
            }
            stopwatch.Stop();
            Console.WriteLine($"BlockBuffer:{stopwatch.ElapsedMilliseconds}");
        }


        /// <summary>
        /// ID获取对应枚举
        /// 没有则返回null
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetEnumByID<T>(int id) where T : Enum
        {
            if (Enum.IsDefined(typeof(T), id))
            {
                return (T)Enum.ToObject(typeof(T), id);
            }
            throw new EnumTransFailedException("转换失败");
        }

        /// <summary>
        /// 名称获取对应枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <exception cref="ErrorMsgException"></exception>
        /// <returns></returns>
        public static T GetEnumByName<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, out T type))
            {
                return type;
            }
            throw new EnumTransFailedException("获取枚举格式失败");
        }
    }
}
