// Задание 4: Даны две строки текста. Определить сколько раз встречается каждый символ первой строки во второй строке. Например: Пусть исходная строка Str1: “xyz”; Str2: “x a d c x y x w”. Тогда “х” – встречается 3 раза “y” - встречается 1 раз, “z” - встречается 0 раз. Далее удалить все слова «кризис».
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int n = 0;
            string s1 = "Говорят, новый кризис вышел", s2 = "Ну кризис, канешна серьёзный";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                        n++;
                }
                Console.WriteLine($"Символ {s1[i]} встречается {n} раз");
                n = 0;
            }
            Console.WriteLine(s1.Replace("кризис", ""));
            Console.WriteLine(s2.Replace("кризис", ""));
            Console.ReadKey();
        }
    }
}