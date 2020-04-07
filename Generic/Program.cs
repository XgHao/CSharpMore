using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Models;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                ll.Add(i);
            }

            ll.Add(new Employee("John"));
            ll.Add(new Employee("Pual"));
            ll.Add(new Employee("George"));
            ll.Add(new Employee("Ringo"));

            Console.WriteLine(ll);
            Console.WriteLine("Done,Adding employees...");
            
            
            Console.ReadLine();
        }
    }
}
