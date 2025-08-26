// Задание 2: Дана строка. Проверить, является ли она палиндромом (например, шалаш).
using System;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "Шалаш";
            s = s.ToLower();
            string revs = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                revs += s[i];
            }
            if (revs == s)
                Console.WriteLine($"Строка {s} палиндром");
            else
                Console.WriteLine($"Строка {s} не палиндром");
        }
    }
}
