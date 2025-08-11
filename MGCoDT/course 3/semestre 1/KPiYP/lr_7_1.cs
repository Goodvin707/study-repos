// Задание 1: Пользователь вводит текст. Вывести исходный текст, заменив в нем слово «три» на «удовлетворительно». Вычислить количество слов начинающихся на «к».
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int k = 0;
            string s = Console.ReadLine();
            s = s.Replace("три", "удовлетворительно");
            if (s[0] == 'К')
                k++;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (s[i + 1] == 'к')
                        k++;
                }
            }
            Console.WriteLine(s);
            Console.WriteLine("Количество слов на букву к: " + k);
            Console.ReadKey();
        }
    }
}