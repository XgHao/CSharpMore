using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goto
{
    class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                goto Label_02D0;
            }

        Label_02D0:
            Console.WriteLine("Label_02D0");
        Label_02D1:
            Console.WriteLine("Label_02D1");
        Label_02D2:
            Console.WriteLine("Label_02D2");
        Label_02D3:
            Console.WriteLine("Label_02D3");
        }
    }
}
