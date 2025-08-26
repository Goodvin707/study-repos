/*Задание 1: Массивы вводятся из файла input.txt, результат выводится в файл output.txt. Сделать каждое задание для одномерного (10 элементов )и двумерного (4 на 6 элементов) массивов
Вывести на экран номера всех элементов, которые не делятся на 7 и найти их сумму.*/

using System;
using System.IO;

namespace _11_1
{
    class Program
    {
        static void Main()
        {
            int[] a = new int[10];
            int sum = 0;
            StreamReader f = new StreamReader("input.txt");
            StreamWriter streamWriter = new StreamWriter("output.txt");
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = Convert.ToInt32(f.ReadLine());
                if (a[i] % 7 != 0)
                {
                    Console.Write(i + " "); // номер элемента
                    streamWriter.Write(i + " ");
                    sum += a[i];
                }
            }
            Console.WriteLine("\n" + sum);
            streamWriter.WriteLine("\n" + sum);
            f.Close();
            int[,] b = new int[4, 6];
            int gind = 0;
            sum = 0;
            f = new StreamReader("input.txt");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = Convert.ToInt32(f.ReadLine());
                    if (b[i, j] % 7 != 0)
                    {
                        Console.Write(gind + " "); // номер элемента
                        streamWriter.Write(gind + " ");
                        sum += b[i, j];
                    }
                    gind++;
                }
            }
            Console.WriteLine("\n" + sum);
            streamWriter.WriteLine("\n" + sum);
            streamWriter.Close();
            f.Close();
        }
    }
}
