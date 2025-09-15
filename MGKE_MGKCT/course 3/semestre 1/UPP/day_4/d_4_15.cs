// Задание 15: Дано предложение, содержащее слова и любое количество пробелов между словами. Преобразовать строку так, чтобы пробелы остались по одному только между словами.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "Предложение, содержащее слова и    любое     количество пробелов    между      словами.";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (s[i + 1] == ' ')
                    {
                        s = s.Remove(i + 1, 1);
                        i--;
                    }
                }
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (s[i - 1] == ' ')
                        s = s.Remove(i - 1, 1);
                }
            }
            Console.WriteLine(s);
        }
    }
}
