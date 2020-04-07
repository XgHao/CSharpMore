using ListTReadonly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTReadonly
{
    class Program
    {
        public static readonly List<Student> students = new List<Student>
            {
                new Student{ ID=1,Name="aa" },
                new Student{ ID=2,Name="bb" },
                new Student{ ID=3,Name="cc" },
            };

        static void Main(string[] args)
        {
            foreach (var item in students)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*********************************");
            students.Add(new Student { ID = 4, Name = "dd" });
            foreach (var item in students)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*********************************");
            students.RemoveAt(1);
            foreach (var item in students)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
}
