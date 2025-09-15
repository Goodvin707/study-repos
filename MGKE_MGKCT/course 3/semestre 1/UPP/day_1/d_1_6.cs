// Задание 6: Найдите все палиндромы из интервала [10000, 100000] последняя цифра которых совпадает с последней цифрой цифрового корня. Выводить число и его цифровой корень.
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            for (int x = 10000; x < 100000; x++) // Ищем палиндром
            {
                string s = x.ToString();
                string reverseS = "";
                for (int i = s.Length - 1; i >= 0; i--)
                    reverseS += s[i];
                if (reverseS == s) // Нашли палиндром
                {
                    int sum = 0;
                    for (int i = 0; i < s.Length; i++) // Считаем цифровой корень
                    {
                        sum += int.Parse(s[i].ToString());
                    }
                    if (sum > 9)
                    {
                        string ssum = sum.ToString();
                        int ЦифрКорень = 0;
                        for (int i = 0; i < ssum.Length; i++)
                        {
                            ЦифрКорень += int.Parse(ssum[i].ToString());
                        }
                        // Посчитали
                        if (Convert.ToInt32(Convert.ToString(s[^1])) == ЦифрКорень) // Сравнили
                            Console.WriteLine($"Число {x}; цифровой корень {ЦифрКорень}");
                    }
                }
            }
        }
    }
}