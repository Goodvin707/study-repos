// Задание 15: Написать программу поиска образа в строке по методу Кнута, Морриса и Пратта. Предусмотреть возможность существования в образе пробела. Ввести опцию чувствительности / нечувствительности к регистру.
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Praktice_Day_9
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
            while (i < s.Length)
            {
                for (i = i, j = 0; (i < s.Length) && (j < x.Length); i++, j++) while ((j >= 0) && (x[j] != s[i]))
                        j = d[j];
                if (j == x.Length)
                    nom = nom + Convert.ToString(i - j) + ", ";
            }
            if (nom != "")
                nom = nom.Substring(0, nom.Length - 2);
            return nom;
        }
        static void Main()
        {
            string asdf = "asdfasdfasdfsdfsdfsdfSsSsdfsdfsdfsd";
            //не чувствителен к регистру (во всех остальны случаях чувствителен)
            asdf = asdf.ToLower();
            string find = "sSss";
            find = find.ToLower();
            Console.WriteLine(KMP("ssss", asdf));
        }
    }
}
