// Задание 5: Заполнить целочисленный jagged-массив, в котором количество строк случайное число из [1; 10], а в каждой строке количество столбцов задано числом из [1; 15] случайными числами из [-20;20]. Найти в каждой строчке сумму двухзначный чисел.
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
            Random r = new Random();
            int[][] arr = new int[r.Next(1, 11)][];
            int[] sum = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[r.Next(1, 16)];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = r.Next(-20, 21);
                    if (Math.Abs(arr[i][j]) >= 10 && Math.Abs(arr[i][j]) < 100)
                        sum[i] += arr[i][j];
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    Console.Write($"{arr[i][j]} ");
                Console.WriteLine($" | {sum[i]}");
            }
        }
    }
}