// Задание 3: Даны два целых числа, координаты точки на плоскости A (x, y). Если точка является началом координат, то вывести на экран число 0. Если точка не является началом координат, но лежит на оси OX или OY, то вывести соответственно X или Y. Если точка не лежит на координатных осях, то вывести номер четверти, в которой находится точка.
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите координаты точки");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if (x == 0 && y == 0)
                Console.WriteLine(0);
            else
            {
                bool flag1 = true;
                bool flag2 = true;
                if (x == 0 && y != 0)
                {
                    flag1 = false;
                    Console.WriteLine(y);
                }
                if (x != 0 && y == 0)
                {
                    flag2 = false;
                    Console.WriteLine(x);
                }
                if (flag1 && flag2)
                {
                    if (x > 0 && y > 0)
                        Console.WriteLine("1-я четверть");
                    if (x < 0 && y > 0)
                        Console.WriteLine("2-я четверть");
                    if (x < 0 && y < 0)
                        Console.WriteLine("3-я четверть");
                    if (x > 0 && y < 0)
                        Console.WriteLine("4-я четверть");
                }
            }
        }
    }
}