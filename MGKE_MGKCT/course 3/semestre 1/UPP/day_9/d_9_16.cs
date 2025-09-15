// Задание 16: Написать программу поиска образа в строке по методу Боуера и Мура. Предусмотреть возможность существования в образе пробела. Ввести опцию чувствительности / нечувствительности к регистру.
using System;
using System.Collections.Generic;

namespace AnotherOneTest
{
    class Program
    {
        static int BMSearch(string str, string substring)
        {
            int sl, ssl;
            int res = -1;
            sl = str.Length;
            ssl = substring.Length;
            if (sl == 0)
                Console.WriteLine("Неверно задана строка");
            else if (ssl == 0)
                Console.WriteLine("Неверно задана подстрока");
            else
            {
                int i, Pos;
                int[] BMT = new int[256];
                for (i = 0; i < 256; i++)
                    BMT[i] = ssl;
                for (i = ssl - 1; i >= 0; i--)
                    if (BMT[(substring[i])] == ssl)
                        BMT[(substring[i])] = ssl - i - 1;
                Pos = ssl - 1;
                while (Pos < sl)
                {
                    if (substring[ssl - 1] != str[Pos])
                        Pos = Pos + BMT[(str[Pos])];
                    else
                        for (i = ssl - 2; i >= 0; i--)
                        {
                            if (substring[i] != str[Pos - ssl + i + 1])
                            {
                                Pos += BMT[(str[Pos - ssl + i + 1])] - 1;
                                break;
                            }
                            else
                              if (i == 0)
                                return Pos - ssl + 1;
                            Console.WriteLine(i);
                        }
                }
            }
            return res;
        }
        static void Main()
        {
            string iso = Console.ReadLine();
            string s = "Sjdksaldjsakdjs a.dz,mc,xzmcm,dmsaldmasihydquwhd iwq0s, dw9qdjkzsnd. DSdsadasdsfjoe?";
            Console.WriteLine("Учитывать регистр?");
            string daNet = Console.ReadLine();
            if (daNet == "Нет")
                s.ToLower();
            BMSearch(s, iso);
        }
    }
}
