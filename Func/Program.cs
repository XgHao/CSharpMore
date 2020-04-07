using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, double> funcAdd = (a, b) => a + b;

            funcAdd += (a, b) => a - b;
             
            Console.WriteLine(funcAdd?.Invoke(3, 4));


            int[] nums = { 1, 2, 3, 12, 2, 4, 8, 9, 6 };


            Console.WriteLine(CalcMethod((a, b) => a + b, nums, 1, 3));

            Console.WriteLine(CalcMethod((a, b) => a * b, nums, 1, 74));

            Console.ReadLine();
        }

        static int CalcMethod(Func<int,int,int> func,int[] nums,int a,int b)
        {
            int res = 0;
            try
            {
                res = nums[a - 1];
                for (int i = a; i < b; i++)
                {
                    res = func(res, nums[i]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"数组越界{e.Message}");
            }

            return res;

        }
    }
}
