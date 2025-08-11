// Задание 1: Составить программу нахождения требуемого значения с исходными данными x, y, z. Обозначение: min и max – нахождение минимального и максимального из перечисленных в скобках значений элементов.

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            double u, min, min2, max;
            Console.WriteLine("Введите x, y, z");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());
            min = (y > z) ? z : y;
            min2 = (x > y) ? y : x;
            max = (min2 > min) ? min2 : min;
            u = min / max;
            Console.WriteLine(u);
        }
    }
}