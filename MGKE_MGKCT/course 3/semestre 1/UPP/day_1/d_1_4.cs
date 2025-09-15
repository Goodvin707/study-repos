// Задание 4: Составить программу, которая на 5 примерах проверяет умение вычитать однозначные числа. В ней случайным образом получить два числа (от 0 до 9), после чего на экран вывести пример в виде: "4 - 9 =". После ввода ответа должно выдаваться сообщение, или ответ верный.
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            int i = 1;
            do
            {
                int a = r.Next(1, 10);
                int b = r.Next(1, 10);
                Console.WriteLine($"{a} - {b} = ?");
                int answer = int.Parse(Console.ReadLine());
                if (answer == a - b)
                    Console.WriteLine("Ответ верный");
                else
                    Console.WriteLine($"Ваш ответ неверный\nПравильнй ответ: {a - b}");
                i++;
            } while (i <= 5);
        }
    }
}