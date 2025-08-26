/*Задание 1: Ввести с клавиатуры x и y. Вычислить z. Вывести z с тремя знаками после точки.
Ввод и вывод сделать разным цветом текста и на различных фонах.*/
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("x = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y = ");
            double y = double.Parse(Console.ReadLine());
            double z = Math.Sqrt(x + Math.Sqrt(Math.Abs(x)) + (6 * x) / (Math.Pow(y, 2) + 5));
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"z = {z:F3}");
        }
    }
}