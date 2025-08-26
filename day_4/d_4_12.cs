// Задание 12: Дано предложение из латинских букв. Найдите в нем слово, которое содержит наибольшее количество гласных букв.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "Latin letter sentence";
            string vowels = "AEIOUY";
            vowels += vowels.ToLower();
            string[] words = s.Split(new char[] { ' ' });
            string word = "";
            int kolvo = 0, maxkolvo = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    for (int k = 0; k < vowels.Length; k++)
                    {
                        if (words[i][j] == vowels[k])
                            kolvo++;
                    }
                    if (kolvo > maxkolvo)
                    {
                        maxkolvo = kolvo;
                        word = words[i];
                    }
                }
            }
            Console.WriteLine(word);
        }
    }
}
