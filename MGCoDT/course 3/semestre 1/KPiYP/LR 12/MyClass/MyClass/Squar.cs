using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Squar : Shape
    {
        public Squar(double a)
        {
            this.a = a;
        }
        public override void Print()
        {
            Console.WriteLine("Сторона квадрата: " + a);
        }
        public override double Perimeter()
        {
            Console.WriteLine("Периметр: " + a * 4);
            return a * 4;
        }
        public override double Square()
        {
            Console.WriteLine("Площадь: " + a * a);
            return a * a;
        }
    }
}