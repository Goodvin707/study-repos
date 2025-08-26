// Задание 5: Даны два предложения. Из этих слов двух предложений сформировать третье предложение, в которое сначала переписаны слова с нечетными номерами с первого предложения, а затем слова с четными номерами с другого предложения.
using System;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s1 = "Предложение, в котором надо найти нечётные слова";
            string s2 = "Предложение, в котором надо найти чётные слова";
            string itog = "";
            string[] words1 = s1.Split(new char[] { ' ' });
            string[] words2 = s2.Split(new char[] { ' ' });
            for (int i = 0; i < words1.Length; i += 2)
                itog += words1[i] + " ";
            for (int i = 1; i < words2.Length; i += 2)
                itog += words2[i] + " ";
            Console.WriteLine(itog);
        }
    }
}