/*Задание 5: Постройте таблицу значений функции y=f(x) для  х принадлежит [a, b]  с шагом h.
Замечание. Для решения задачи использовать вспомогательный метод.*/
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            int a = -15, b = 15, h = 1;
            for (int x = a; x <= b; x += h)
            {
                if (x <= 5)
                    Console.WriteLine($"y = {Math.Pow(x, 2) + 5}");
                if (x < 20 && x > 5)
                    Console.WriteLine($"y = {0}");
                if (x >= 20)
                    Console.WriteLine($"y = {1}");
            }
        }
    }
}