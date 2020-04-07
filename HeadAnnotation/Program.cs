using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadAnnotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var pwd = Console.ReadLine();
            Console.WriteLine(Security.GetMD5PWD(pwd));
            Console.ReadLine();
        }
    }
}
