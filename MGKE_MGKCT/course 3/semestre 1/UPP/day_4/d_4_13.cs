// Задание 13: Дано предложение. Со слов этого предложения, которые не повторяются, сформировать новое предложение. Повторяющиеся слова в первом предложении, в новое предложение не выводить.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        { 
            string s = "Предложение, в котором надо этого предложения, которые не повторяются, сформировать новое предложение";
            string itog = "";
            string[] words = s.Split(new char[] { ' ' });
            for (int i = 0; i < words.Length; i++)
                if(!itog.ToLower().Contains(words[i].ToLower()))
                    itog += words[i] + " ";
            Console.WriteLine(itog);
        }
    }
}