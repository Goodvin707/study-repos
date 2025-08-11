// Задание 1: Вычислить высоту треугольника, опущенную на сторону а, по известным значениям длин его сторон a, b, c.
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            double a = 5;
            double b = 4;
            double c = 3;
            double s;
            double p = (a + b + c) / 2;
            s = 2 / a * (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            Console.WriteLine($"Площадь треугольника: {s:F2}");
        }
    }
}