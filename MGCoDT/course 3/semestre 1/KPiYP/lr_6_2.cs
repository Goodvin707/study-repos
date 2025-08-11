// Задание 2: Написать программу по обработке двухмерного массива. Размеры массива n, m  и значения элементов массива вводятся с клавиатуры. Найти сумму модулей элементов, расположенных выше главной диагонали.
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
            Random rnd = new Random();
            int sum = 0;
            Console.Write("Введите кол-во столбцов массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во строк массива: ");
            int m = int.Parse(Console.ReadLine());
            int[,] ar = new int[n, m];
            for (int i = 0; i < n; i++) // столбцы
            {
                for (int j = 0; j < m; j++) // строки
                {
                    ar[i, j] = rnd.Next(-10, 10);
                    Console.Write($"{ar[i, j]} ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++) // столбцы
            {
                for (int j = 0; j < m; j++) // строки
                {
                    if (i < j)
                        sum += ar[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма: " + sum);
            Console.ReadKey();
        }
    }
}