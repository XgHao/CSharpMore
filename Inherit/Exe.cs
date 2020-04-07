using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public static class Exe
    {
        public static string FromParent(this string _str)
        {
            return $"{_str} From Parent";
        }

        public static string FromChild(this string _str)
        {
            return $"{_str} From Child";
        }

        public static string ToWord(this bool _bool)
        {
            return _bool ? "是" : "否";
        }
    }
}
