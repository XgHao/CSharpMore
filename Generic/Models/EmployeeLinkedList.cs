using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Models
{
    public class EmployeeLinkedList
    {
        EmployeeNode headNode = null;

        public void Add(Employee data)
        {
            if (headNode != null) 
            {
                headNode = new EmployeeNode(data);
            }
            else
            {
            }
        }
    }
}
