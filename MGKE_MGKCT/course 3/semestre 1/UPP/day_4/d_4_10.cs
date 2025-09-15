// Задание 10: Дана строка. Найти наибольшее количество одинаковых символов, стоящих рядом.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "ААвввгдыыыывылвод";
            int k = 0, maxk = 0;
            for (int i = 1; i < s.Length; i++)
            {
                int ii = i;
                do
                {
                    if (s[i - 1] == s[i])
                        k++;
                    else
                    {
                        if (k > maxk)
                            maxk = k;
                        k = 1;
                    }
                    break;
                } while (i < s.Length);
                i = ii;
            }
            Console.WriteLine(maxk);
        }
    }
}
