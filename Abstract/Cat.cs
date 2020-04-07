using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Cat : Animal
    {
        public Cat(string _name) : base(_name)
        {

        }

        public override void Walk()
        {
            Console.WriteLine("跑");
        }
    }
}
