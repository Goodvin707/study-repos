// Задание 3: Оформить функцию поиска произведения положительных элементов массива. В главной программе дано 4 одномерных массива a, b, c, d длиной 10 элементов каждый. Применить функцию для каждого из 4-х заданных массивов (в функции не должно быть операторов ввода или вывода).
using System;

namespace Test
{
    class Program
    {
        static int PositiveComp(int[] n)
        {
            int c = 1;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] > 0)
                    c *= n[i];
            }
            return c;
        }
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Random r = new Random();
            int[] a = new int[10];
            int[] b = new int[10];
            int[] c = new int[10];
            int[] d = new int[10];
            for (int i = 0; i < 10; i++)
            {
                a[i] = r.Next(-10, 10);
                b[i] = r.Next(-10, 10);
                c[i] = r.Next(-10, 10);
                d[i] = r.Next(-10, 10);
            }
            for (int i = 0; i < 10; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write($"{b[i]} ");
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write($"{c[i]} ");
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write($"{d[i]} ");
            Console.WriteLine();
            Console.WriteLine("Произведение положительных элементов массива: " + PositiveComp(a));
            Console.WriteLine("Произведение положительных элементов массива: " + PositiveComp(b));
            Console.WriteLine("Произведение положительных элементов массива: " + PositiveComp(c));
            Console.WriteLine("Произведение положительных элементов массива: " + PositiveComp(d));
        }
    }
}