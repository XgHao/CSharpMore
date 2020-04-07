using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    public static class MyEnum
    {
        /// <summary>
        /// ID获取对应枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="id"></param>
        /// <exception cref="ErrorMsgException"></exception>
        /// <returns></returns>
        public static T GetEnumByIDorName<T>(int id) where T : struct, Enum
        {
            if (Enum.TryParse(id.ToString(), out T type))
            {
                return type;
            }
            throw new Exception("获取枚举格式失败");
        }

        /// <summary>
        /// 名称获取对应枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <exception cref="ErrorMsgException"></exception>
        /// <returns></returns>
        public static T GetEnumByIDorName<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, out T type))
            {
                return type;
            }
            throw new Exception("获取枚举格式失败");
        }

        /// <summary>
        /// 去除末尾空值
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static byte[] RemoveNull(this byte[] arr)
        {
            //从末尾开始去除连续的空值
            int len;
            for (len = arr.Length - 1; len > 0; len--)
            {
                if (arr[len] == 0 && arr[len - 1] != 0)
                    break;
            }

            return arr.Take(len).ToArray();
        }
    }
}
