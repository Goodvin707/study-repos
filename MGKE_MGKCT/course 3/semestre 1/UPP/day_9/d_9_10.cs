/*Задание 10:
Дан одномерный массив из n целых чисел, упорядоченных в порядке возрастания. Необходимо некоторое число М вставить в данный массив, не нарушая его упорядоченность.*/

using System;

namespace AnotherOneTest
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите длину массива: ");
            int n = int.Parse(Console.ReadLine());
            int[] m = new int[n];
            for (int i = 0; i < n; i++)
            {
                m[i] = i * 2;
                Console.Write(m[i] + " ");
            }
            Console.Write("\nЧисло, которое будет вставлено: ");
            int M = int.Parse(Console.ReadLine());
            int ii = 0;
            int[] newM = new int[n + 1];
            while (m[ii] < M)
            {
                newM[ii] = m[ii];
                ii++;
            }
            newM[ii] = M; ii++;
            for (int i = ii; i < n + 1; i++)
                newM[i] = m[i - 1];
            for (int i = 0; i < n + 1; i++)
                Console.Write(newM[i] + " ");
        }
    }
}
