using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public class Dog : Animal
    {
        public string Favorite { get; set; }
        public Dog(string _name, string _head, int _foots, bool _tail, string _favorite) : base(_name, _head, _foots, _tail)
        {
            Favorite = _favorite;
        }

        public override void Displayinfo()
        {
            base.Displayinfo();
            Console.WriteLine($"Favorite:{Favorite}");
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
