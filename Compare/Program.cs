using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = Student.GetStudentList();
            students.Sort(new StuSexAES());

            foreach (var stu in students)
            {
                Console.WriteLine(stu.ToString());
            }

            Console.ReadLine();
        }

        
    }
}
