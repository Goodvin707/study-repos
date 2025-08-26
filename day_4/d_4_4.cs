// Задание 4: Дано предложение. Найдите в нем самое длинное слово. Если таких слов несколько, то найдите первое из них.
using System;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "Предложение, в котором надо найти самое длинное слово";
            string[] words = s.Split(new char[] { ' ' });
            int len = 0;
            string word = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > len)
                {
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (!char.IsLetter(words[i][j]))
                            len--;
                    }
                    len = words[i].Length;
                    word = words[i];
                }
            }
            Console.WriteLine(word + " " + word.Length);
        }
    }
}
