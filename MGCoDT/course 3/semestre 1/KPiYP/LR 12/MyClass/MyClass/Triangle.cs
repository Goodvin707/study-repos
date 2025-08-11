using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Triangle : Shape
    {
        int b;
        int c;
        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override void Print()
        {
            Console.WriteLine($"Стороны:\na = {a}\nb = {b}\nc = {c}");
        }
        public override double Perimeter()
        {
            if (IsExist())
            {
                Console.WriteLine("Периметр: " + (a + b + c));
                return a + b + c;
            }
            return 0;
        }
        public override double Square()
        {
            if (IsExist())
            {
                double p = (a + b + c) / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("Плошадь: " + s);
                return s;
            }
            return 0;
        }
        public bool IsExist()
        {
            if (a >= b + c || b >= a + c || c >= a + b)
            {
                Console.WriteLine("Такой треугольник не существует");
                return false;
            }
            Console.WriteLine("Такой треугольник существует");
            return true;
        }
    }
}