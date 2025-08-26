/*Задание 2: Для одномерного массива размерностью 15 элементов (для двумерного массива 5х7), заполненного случайными числами в диапазоне, определяемом пользователем, решить следующие задания:
Вывести на экран элементы с четными индексами (для двумерного массива - сумма индексов должна быть четной).
Подсчитать количество элементов, значения которых больше значения предыдущего элемента.
Найти количество пар соседних элементов, в которых предыдущий элемент кратен последующему.
Найти количество пар соседних элементов, разность между которыми равна заданному числу.
Определить, является ли произведение элементов трехзначным числом.
Данный массив отсортировать по убыванию.*/

using System;

namespace _11_2
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            Console.WriteLine("Укажите диапазон случайных значений");
            Console.Write("От: ");
            int from = int.Parse(Console.ReadLine());
            Console.Write("До: ");
            int to = int.Parse(Console.ReadLine());
            to++;
            /*Вывести на экран элементы с четными индексами
             *(для двумерного массива - сумма индексов должна быть четной).*/
            int[] a = new int[15];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(from, to);
                if (i % 2 == 0)
                    Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            int[,] b = new int[5, 7];
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = r.Next(from, to);
                    if (i + j % 2 == 0)
                        Console.Write(b[i, j] + " ");
                }
            }
            Console.WriteLine();
            /*Подсчитать количество элементов, значения которых больше значения предыдущего элемента.*/
            int count = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > a[i - 1])
                    count++;
            }
            Console.WriteLine(count);
            count = 0;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 1; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == b[i, j - 1])
                        count++;
                }
            }
            Console.WriteLine(count);
            count = 0;
            /*Найти количество пар соседних элементов, в которых предыдущий элемент кратен последующему.*/
            for (int i = 1; i < a.Length; i += 2)
            {
                if (a[i] % a[i - 1] == 0)
                    count++;
            }
            Console.WriteLine(count);
            count = 0;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 1; j < b.GetLength(1); j += 2)
                {
                    if (b[i, j] % b[i, j - 1] == 0)
                        count++;
                }
            }
            Console.WriteLine(count);
            count = 0;
            /*Найти количество пар соседних элементов, разность между которыми равна заданному числу.*/
            int x = int.Parse(Console.ReadLine());
            for (int i = 1; i < a.Length; i += 2)
            {
                if (a[i] - a[i - 1] == x)
                    count++;
            }
            Console.WriteLine(count);
            count = 0;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 1; j < b.GetLength(1); j += 2)
                {
                    if (b[i, j] - b[i, j - 1] == x)
                        count++;
                }
            }
            Console.WriteLine(count);
            count = 0;
            /*Определить, является ли произведение элементов трехзначным числом.*/
            int p = 1;
            for (int i = 0; i < a.Length; i++)
                p *= a[i];
            if (p >= 100 && p < 1000)
                Console.WriteLine("да");
            else
                Console.WriteLine("нет");
            p = 1;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                    p *= b[i, j];
            }
            if (p >= 100 && p < 1000)
                Console.WriteLine("да");
            else
                Console.WriteLine("нет");
            /*Данный массив отсортировать по убыванию.*/
            int temp;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
        }
    }
}
