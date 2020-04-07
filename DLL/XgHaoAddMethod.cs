using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    class XgHaoAddMethod : ICalc
    {
        public int Add(int a, int b)
        {
            return a + b * 2;
        }
    }
}
