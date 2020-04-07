using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("猫", "猫头", 4, true, Color.LightYellow);


            Dog dog = new Dog("狗", "狗头", 4, true, "骨头");

            Test(cat);
            Test(dog);

            Console.ReadLine();
        }

        static void Test(Animal animal)
        {
            animal.Displayinfo();
        }
    }
}
