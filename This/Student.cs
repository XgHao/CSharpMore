using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This
{
    class Student
    {
        public Guid Guid { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }

        public Student()
        {
            Guid = Guid.NewGuid();
        }

        public Student(string _line1, string _line2) : this()
        {
            Line1 = _line1;
            Line2 = _line2;
        }


        public override string ToString()
        {
            return $"Guid:{Guid}\nLine1:{Line1}\nLine2:{Line2}\nLine3:{Line3}\nLine4:{Line4}";
        }
    }
}
