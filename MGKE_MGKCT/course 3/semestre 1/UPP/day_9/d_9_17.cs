// Задание 17: Реализовать в программе алгоритм прямого поиска строки и КМП-алгоритм. Сравнить эффективность поиска образа в строке обоими алгоритмами по количеству итераций.
using System;
using System.Collections.Generic;

namespace AnotherOneTest
{
    class Program
    {
        public static int[] PrefFunc(string x)
        {
            int[] res = new int[x.Length];
            int i = 0;
            int j = -1;
            res[0] = -1;
            while (i < x.Length - 1)
            {
                while ((j >= 0) && (x[j] != x[i]))
                    j = res[j];
                i++;
                j++;
                if (x[i] == x[j])
                    res[i] = res[j];
                else
                    res[i] = j;
            }
            return res;
        }
        public static string KMP(string x, string s)
        {
            string nom = "";
            if (x.Length > s.Length) return nom;
            int[] d = PrefFunc(x);
            int i = 0, j;
            int gind = 0;
            while (i < s.Length)
            {
                for (j = 0; (i < s.Length) && (j < x.Length); i++, j++)
                {
                    while ((j >= 0) && (x[j] != s[i]))
                    {
                        j = d[j];
                        gind++;
                    }
                }
                if (j == x.Length)
                    nom = nom + (i - j).ToString() + ", ";
            }
            if (nom != "")
                nom = nom.Substring(0, nom.Length - 2);
            return nom + "\nКоличество итераций: " + gind.ToString();
        }
        static void Main()
        {
            string s = "Asdasdjasljdklas jsadkl sadjsalkjd kaskl djasklj dlkasdkl askd jaskljd lkasj, sakdajsdjaslkd jaslsd sadsa dsadas d am,pue89120734 dajsk laod  lashdjs";
            string findMe = "sad";
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int j = 0;
                while (s[i] == findMe[j])
                {
                    if (j == findMe.Length - 1)
                    {
                        Console.WriteLine($"Слово нашлось {++count}-й раз");
                        Console.WriteLine(" " + (i - findMe.Length + 1) + " -- индекс вхождения первой буквы слова");
                        Console.WriteLine(" " + i + " -- индекс вхождения последней буквы слова\n");
                        break;
                    }
                    if (i < s.Length - 1)
                        i++;
                    j++;
                }
            }
            Console.WriteLine("Количество итераций: " + s.Length + "\n");

            Console.WriteLine(KMP(findMe, s));
        }
    }
}
