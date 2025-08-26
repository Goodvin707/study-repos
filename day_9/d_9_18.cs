// Задание 18: Реализовать в программе алгоритм прямого поиска строки и БМ-алгоритм. Сравнить эффективность поиска образа в строке обоими алгоритмами по количеству итераций.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Praktice_Day_9
{
    public static class BMAlgorithm
    {
        static void generateBadChar(char[] b, int m, int[] badchar, int[] num)
        {
            int i, ascii;
            badchar = num;
            for (i = 0; i < m; ++i)
            {
                ascii = (int)b[i];
                badchar[ascii] = i;
            }
        }
        static void generateGS(char[] b, int m, int[] suffix, bool[] prefix)
        {
            int i, j, k;
            for (i = 0; i < m; ++i)
            {
                suffix[i] = -1;
                prefix[i] = false;
            }
            for (i = 0; i < m - 1; ++i)
            {
                j = i;
                k = 0;
                while (j >= 0 && b[j] == b[m - 1 - k])
                {
                    --j;
                    ++k;
                    suffix[k] = j + 1;
                }
                if (j == -1)
                    prefix[k] = true;
            }
        }
        static int moveByGS(int j, int m, int[] suffix, bool[] prefix)
        {
            int k = m - 1 - j;
            if (suffix[k] != -1)
                return j - suffix[k] + 1;
            for (int i = j + 2; i < m; ++i)
            {
                if (prefix[m - i] == true)
                    return i;
            }
            return m;
        }
        public static int str_bm(char[] a, int n, char[] b, int m, int[] num)
        {
            int[] badchar = num;
            generateBadChar(b, m, badchar, num);
            int[] suffix = new int[m];
            bool[] prefix = new bool[m];
            generateGS(b, m, suffix, prefix);
            int i = 0, j, movelen1, movelen2;
            while (i < n - m + 1)
            {
                for (j = m - 1; j >= 0; --j)
                {
                    if (a[i + j] != b[j])
                        break;
                }
                if (j < 0)
                    return i;
                movelen1 = j - badchar[(int)a[i + j]];
                movelen2 = 0;
                if (j < m - 1)
                    movelen2 = moveByGS(j, m, suffix, prefix);
                i = i + (movelen2 > movelen1 ? movelen2 : movelen1);
            }
            return -1;
        }
    }
    class Program
    {
        public static int[] Nums
        {
            get
            {
                int[] arr = new int[100000];
                for (int i = 0; i < 100000; i++)
                    arr[i] = -1;
                return arr;
            }
        }
        static void Main(string[] args)
        {
            char[] a = "abcsdsdadads".ToCharArray();
            char[] b = "dsd".ToCharArray();
            Console.WriteLine(BMAlgorithm.str_bm(a, a.Length, b, b.Length, Nums));
            char[] c = "How are you".ToCharArray();
            char[] d = "it is good".ToCharArray();
            Console.WriteLine(BMAlgorithm.str_bm(c, c.Length, d, d.Length, Nums));
        }
    }
}
