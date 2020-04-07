using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class Student : IComparable<Student>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(Line(100));
            stringBuilder.Append($"Guid:{Guid}\tName:{Name}\tAge:{Age}\tSex:{Sex}\n");
            stringBuilder.Append(Line(100));
            return stringBuilder.ToString();
        }

        public static List<Student> GetStudentList()
        {
            return new List<Student>
            {
                new Student{ Guid=Guid.NewGuid(),Name="Stu_1",Age=11,Sex=Gender.男  },
                new Student{ Guid=Guid.NewGuid(),Name="Stu_2",Age=12,Sex=Gender.女  },
                new Student{ Guid=Guid.NewGuid(),Name="Stu_3",Age=13,Sex=Gender.男  },
                new Student{ Guid=Guid.NewGuid(),Name="Stu_4",Age=14,Sex=Gender.女  },
                new Student{ Guid=Guid.NewGuid(),Name="Stu_5",Age=15,Sex=Gender.男  }
            };
        }

        private string Line(int cnt)
        {
            StringBuilder stringBuilder = new StringBuilder("\n");
            for (int i = 0; i < cnt; i++)
            {
                stringBuilder.Append("*");
            }
            return stringBuilder.Append("\n").ToString();
        }

        public int CompareTo(Student other)
        {
            return Guid.CompareTo(other.Guid);
        }
    }


    public class StuGuidASE : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x.Guid.CompareTo(y.Guid);
    }

    public class StuNameDESC : IComparer<Student>
    {
        public int Compare(Student x, Student y) => y.Name.CompareTo(x.Name);
    }

    public class StuAgeAES : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x.Age.CompareTo(y.Age);
    }

    public class StuSexAES : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x.Sex.CompareTo(y.Sex);
    }

    public enum Gender
    {
        男 = 0, 女 = 1
    }
}
