using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Circle : Shape
    {
        public Circle(double a)
        {
            this.a = a;
        }
        public override void Print()
        {
            Console.WriteLine("Радиус: " + a);
        }
        public override double Perimeter()
        {
            Console.WriteLine("Длина окружности: " + 2 * Math.PI * a);
            return 2 * Math.PI * a;
        }
        public override double Square()
        {
            Console.WriteLine("Плошадь круга: " + Math.PI * (a * a));
            return Math.PI * (a * a);
        }
    }
}