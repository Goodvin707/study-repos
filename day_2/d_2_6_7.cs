// Задание 6: Разработать метод f(x1, y1, x2, y2), который вычисляет длину отрезка по  координатам вершин (x1, y1) и (x2, y2), и метод max(a, b), который вычисляет максимальное из чисел a, b. С помощью данных методов определить, какая из трех точек на плоскости наиболее удалена от начала координат.
using System;

namespace Praktice
{
    class Program
    {
        static void f (int x1, int x2, int y1, int y2)
        {
            Console.WriteLine($"Длина отрезка: {Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))}");
        }
        static void f(double x, out double y)
        {
            y = x * x;
        }
        static double max (double a, double b)
        {
            return (a > b) ? a : b;
        }
        static double d (int x, int y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        static void Main()
        {
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double max1, max2, max3, max4, max5;
            double d1 = d(x1, y2);
            double d2 = d(x2, y2);
            double d3 = d(a, b);
            max1 = max(d1, d2);
            max2 = max(d2, d3);
            max3 = max(d1, d3);
            max4 = max(max1, max2);
            max5 = max(max4, max3);
            Console.WriteLine($"{max5:F0}");
        }
    }
}