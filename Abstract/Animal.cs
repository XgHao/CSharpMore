using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string _name)
        {
            Name = _name;
        }

        public abstract void Walk();
            
        public virtual void Eat()
        {
            Console.WriteLine("吃");
        }

        public void Breath() { Console.WriteLine("呼吸"); }
    }
}
