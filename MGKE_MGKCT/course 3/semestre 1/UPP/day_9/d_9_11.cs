/*Задание 11: 
Задан числовой вектор из n элементов. Требуется получить в порядке возрастания все различные числа-элементы вектора.*/

using System;
using System.Collections.Generic;

namespace AnotherOneTest
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            List<int> vs = new List<int>();
            Console.Write("Введите количество элементов: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                vs.Add(r.Next(1, 21));
                Console.Write(vs[i] + " ");
            }
            Console.WriteLine();
            int temp;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (vs[i] > vs[j])
                    {
                        temp = vs[i];
                        vs[i] = vs[j];
                        vs[j] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
                Console.Write(vs[i] + " ");
        }
    }
}
