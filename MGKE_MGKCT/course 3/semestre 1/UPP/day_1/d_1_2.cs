/*Задание 2: Дано целое пятизначное число. Найдите произведение второй, третьей и четвертой цифр этого числа. Экран должен иметь вид:
Введите число 34256
4х2х5 = 40*/
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("Введите число: ");
            string s = Console.ReadLine();
            int c1 = int.Parse(s[1].ToString());
            int c2 = int.Parse(s[2].ToString());
            int c3 = int.Parse(s[3].ToString());
            Console.WriteLine($"{c1} * {c2} * {c3} = {c1 * c2 * c3}");
        }
    }
}