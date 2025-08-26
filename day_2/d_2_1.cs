// Задание 1: Дана точка на плоскости с координатами (х, у). Составить программу, которая выдает одно из сообщений «Да», «Нет», «На границе» в зависимости от того, лежит ли точка внутри заштрихованной области, вне заштрихованной области или на ее границе.
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.Write("x = ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("y = ");
            float y = float.Parse(Console.ReadLine());
            if (x > 40 || y > 40 || x < -40 || y < -40)
                Console.WriteLine("Внутри");
            else if (x < 40 && x > -40 && y < 40 && y > -40)
                Console.WriteLine("Вне");
            else Console.WriteLine("На границе");
        }
    }
}