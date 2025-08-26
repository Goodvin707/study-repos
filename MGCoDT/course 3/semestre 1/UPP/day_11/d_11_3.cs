/*Задание 3: Написать программу по обработке двухмерного массива. Размеры массива n, m  и значения элементов массива вводятся с клавиатуры.
Найти сумму модулей элементов, расположенных выше главной диагонали.*/

using System;

namespace _10_3
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            Console.Write("Введите кол-во строк: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во столбцов: ");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine("Столбец " + i + ":");
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (i < j)
                        sum += Math.Abs(a[i, j]);
                }
            }
            Console.WriteLine("Сумма модулей элементов, расположенных выше главной диагонали: " + sum);
        }
    }
}
