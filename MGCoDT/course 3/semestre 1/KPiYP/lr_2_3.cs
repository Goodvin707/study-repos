using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // Найти площадь поверхности прямого кругового усеченного конуса с радиусом оснований R1, R2 и высотой h.
            double s, l, r1 = 3, r2 = 6, h = 3;
            l = Math.Sqrt(h * h + Math.Pow((r2 - r1), 2));
            s = Math.PI * l * (r2 + r1) + Math.PI * Math.Pow(r1, 2) + Math.PI + Math.Pow(r2, 2);
            Console.WriteLine("Площадь поверхности усеченной пирамиды: " + s);
        }
    }
}
