// Задание 1: Ввести з клавиатуры n любых символов. Сколько среди них символов в нижнем регистре?
using System;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i]))
                    count++;
            }
            Console.WriteLine($"Всего {count} симолов в нижнем регистре");
        }
    }
}