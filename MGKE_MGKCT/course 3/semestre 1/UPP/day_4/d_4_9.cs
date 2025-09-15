// Задание 9: Найдите все нечетные двухзначные числа, начинающиеся с парной цифры. Вывести эти числа в текстовый файл 1.txt, по 4 числа в строке.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            int k = 0;
            StreamWriter f = new StreamWriter("1.txt");
            for (int i = 11; i <= 99; i += 2)
            {
                string si = i.ToString();
                if (si[0] == '2' || si[0] == '4' || si[0] == '6' || si[0] == '8')
                {
                    if (k < 3)
                    {
                        f.Write(i + " ");
                        k++;
                    }
                    else
                    {
                        f.WriteLine(i + " ");
                        k = 0;
                    }
                }
            }
            f.Close();
        }
    }
}
