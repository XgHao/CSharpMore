using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            HP_Print obj = new HP_Print(614, "惠普614号打印机");
            obj.Print();
            Console.WriteLine(obj.PrintCnt());

            Console.ReadLine();
        }
    }
}
