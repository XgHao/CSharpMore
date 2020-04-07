using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyEnum.CRUD> values = new List<MyEnum.CRUD> 
            { 
                MyEnum.CRUD.Create, 
                MyEnum.CRUD.Delete, 
                MyEnum.CRUD.Retrieve, 
                MyEnum.CRUD.Update 
            };

            foreach (var item in values)
            {
                Console.WriteLine(item.GetChinese());
            }

            Console.Read();
        }
    }
}
