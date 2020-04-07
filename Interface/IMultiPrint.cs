using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface IMultiPrint
    {
        int NO { get; set; }
        string Name { get; set; }

        int PrintCnt();

        void Print();
    }
}
