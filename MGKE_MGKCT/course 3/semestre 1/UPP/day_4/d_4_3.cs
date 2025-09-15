// Задание 3: Дана строка. Замените в нем все вхождения последнего символа в «!!». Например, строка «абпаваа» должен стать таким «!! бп !! в !!!!».
using System;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "абпаваа";
            s = s.Replace(s[s.Length - 1].ToString(), "!!");
            Console.WriteLine(s);
        }
    }
}
