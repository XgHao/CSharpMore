using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    /// <summary>
    /// 动物类-父类
    /// </summary>
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Head { get; set; }
        public int Foots { get; set; }
        public bool Tail { get; set; }

        public Animal(string _name,string _head,int _foots,bool _tail)
        {
            Name = _name.FromParent();
            Head = _head.FromParent();
            Foots = _foots;
            Tail = _tail;
        }

        public virtual void Displayinfo()
        {
            Console.WriteLine($"Name:{Name}\tHead:{Head}\tFoots:{Foots}\tTail:{Tail.ToWord()}");
        }

        public abstract void Eat();
    }
}
