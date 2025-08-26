/*Задание 4: Использовать методы класса Array.
  f(x) = 3*x^2-x^3;
Вычислить сумму элементов массива выше главной диагонали. Определить индексы минимального элемента.*/
using System;

namespace _11_4
{
    class Program
    {
        static int f(int x)
        {
            return 3 * x * x - x * x * x;
        }
        static void Main()
        {
            Random r = new Random();
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            double[,] arr = new double[n, n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = Math.Round((j + 1) * f(i + 1) + Math.Sin(i) * f(j + 1), 2);
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            double sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i < j)
                        sum += arr[i, j];
                }
            }
            Console.WriteLine("Сумма элементов выше главной диагонали: " + Math.Round(sum, 2));
        }
    }
}
