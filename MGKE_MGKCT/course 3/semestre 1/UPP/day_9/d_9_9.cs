/*Задание 9:
ДАНА МАТРИЦА А(N X M). НАЙТИ:
Номера столбцов, элементы которых расположены в убывающем порядке*/

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
                    mas[i, j] = r.Next(1, 21);
            }
            int jj = r.Next(0, m);
            Console.WriteLine(jj);
            for (int i = 0; i < n; i++)
                mas[i, jj] = 10 - i;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\n Результат");
            bool output = false;
            for (int j = 0; j < m; j++)
            {
                bool inOrder = true;
                for (int i = 1; i < n; i++)
                {
                    if (mas[i - 1, j] < mas[i, j])
                    {
                        inOrder = false;
                        break;
                    }
                }
                output |= inOrder;
                if (inOrder)
                    Console.WriteLine(j);
            }
            if (!output)
                Console.WriteLine("Нет столбца отсортированнго по убыванию");
        }
    }
}
