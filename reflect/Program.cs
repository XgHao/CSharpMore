using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Interface;

namespace reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            if (int.TryParse(Console.ReadLine(), out int a) && int.TryParse(Console.ReadLine(), out int b)) 
            {
                ICalc calc = Assembly.Load("DLL").CreateInstance("DLL.XgHaoAddMethod") as ICalc;

                Console.WriteLine($"结果是：{calc.Add(a, b)}");
            }
            else
            {
                Console.WriteLine("请输入数字");
            }


            Console.ReadLine();

        }
    }
}
