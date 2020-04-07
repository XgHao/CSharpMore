using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public class Cat : Animal
    {
        public Color Color { get; set; }

        public Cat(string _name, string _head, int _foots, bool _tail, Color _color) : base(_name, _head, _foots, _tail)
        {
            Color = _color;
        }

        public override void Displayinfo()
        {
            base.Displayinfo();
            Console.WriteLine($"颜色：{Color}");
        }

        public override void Eat()
        {
        }
    }
}
