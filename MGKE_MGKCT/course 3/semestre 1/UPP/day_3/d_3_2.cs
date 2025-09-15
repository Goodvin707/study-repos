// Задание 2: Заполнить целочисленную матрицу размером 5x6 случайными числами из [-20; 20]. Найти в каждом столбике сумму двухзначных чисел.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            int[,] arr = new int[5, 6];
            int[] sum = new int[6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    arr[i, j] = rand.Next(-20, 21);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Math.Abs(arr[j, i]) >= 10 && Math.Abs(arr[j, i]) < 100)
                        sum[i] += arr[j, i];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------");
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"{sum[i]} ");
            }
        }
    }
}