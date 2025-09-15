// Задание 4: Вывести на экран числа следующим образом:
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите кол-во рядов");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int c = i;
                while (c > 0)
                {
                    Console.Write($"{c--} ");
                }
                Console.WriteLine();
            }
        }
    }
}