using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Models
{
   public class Employee
    {
        private string name;

        public Employee(string _name)
        {
            name = _name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
