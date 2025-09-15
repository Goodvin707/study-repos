/*Задание 8:
ДАНА МАТРИЦА А(N X M). НАЙТИ:
Номера строк, элементы которых расположены в возрастающем порядке*/

using System;

namespace AnotherOneTest
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] mas = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    mas[i, j] = r.Next(1, 20);
            }
            int ii = r.Next(0, n);
            for (int j = 0; j < m; j++)
                mas[ii, j] = j + 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\n Результат");
            bool output = false;
            for (int i = 0; i < n; i++)
            {
                bool inOrder = true;
                for (int j = 1; j < m; j++)
                {
                    if (mas[i, j - 1] > mas[i, j])
                    {
                        inOrder = false;
                        break;
                    }
                }
                output |= inOrder;
                if (inOrder)
                    Console.WriteLine(i);
            }
            if (!output)
                Console.WriteLine("Нет строки отсортированной по возрастанию");
        }
    }
}
