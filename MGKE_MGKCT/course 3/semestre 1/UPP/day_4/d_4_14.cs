// Задание 14: Дана строка и буква. Сколько раз встречается эта буква между первой и последней запятыми?
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "Предложение, в котором надо предложения, которые не повторяются, сформировать новое предложение";
            char letter = 'о';
            int first = 0, second = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')  
                {
                    first = i;
                    break;
                }
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ',')
                {
                    second = i;
                    break;
                }
            }
            int count = 0;
            for (int i = first; i < second; i++)
            {
                if (s[i] == letter)
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
