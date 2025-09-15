// Задание 4: Заполнить целочисленную матрицу размером 5x6 случайными числами из [-20; 20]. Отсортировать по убыванию в каждом столбике все числа со второго по четвертое.
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
            int[,] arr = new int[5, 6];
            int[] temp = new int[5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    arr[i, j] = r.Next(-20, 21);
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                    temp[j] = arr[j, i];
                Array.Sort(temp, 1, 3);
                Array.Reverse(temp, 1, 3);
                for (int j = 0; j < 5; j++)
                    arr[j, i] = temp[j];
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                    Console.Write($"{arr[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}