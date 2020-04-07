using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Models
{
    public class EmployeeNode
    {
        Employee employeedata;
        EmployeeNode employeeNext;

        public EmployeeNode(Employee _date)
        {
            employeedata = _date;
            employeeNext = null;
        }

        public void Append(EmployeeNode newEmployeeNode)
        {
            if (employeeNext == null) 
            {
                employeeNext = newEmployeeNode;
            }
            else
            {
                employeeNext.Append(newEmployeeNode);
            }
        }

        public override string ToString()
        {
            string output = employeedata.ToString();
            if (employeeNext != null) 
            {
                output += ", " + employeeNext.ToString();
            }
            return output;
        }
    }
}
