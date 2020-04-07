using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_BlockBuffer_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = CopySpeedTest.GetEnumByName<City>("0");
            Console.WriteLine(city);
            Console.ReadKey();
        }


        enum City
        {
            HZ,
            SZ,
            WZ,
        }
    }
}
