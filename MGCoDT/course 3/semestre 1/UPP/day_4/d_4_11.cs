// Задание 11: Дана строка, содержащая натуральное число. Вставить в эту строку знаки «пробел», чтобы этот знак разделял группы по три цифры. Например, для строки 12345678 получить строку 12345678.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "12345678";
            for (int i = 3; i < s.Length; i += 4)
                s = s.Insert(i, " ");
            Console.WriteLine(s);
        }
    }
}