/*Задание 4: Коэффициенты многочлена хранятся в массиве a: array [0..n]  of  integer (n - натуральное число, степень многочлена). Вычислить значение этого многочлена в точке x (т. е.  a[n]*(x  в степени n)+...+a[1]*x+a[0]).
Подсказка: Описываемый алгоритм называется схемой Горнера.*/

using System;

namespace _11_5
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            int n = 2;
            double y = 0;
            int x = 2;
            int k;
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(1, 11);
                Console.Write(a[i] + "x^" + (a.Length - i) + " ");
            }
            Console.WriteLine("= 0");
            n--;
            for (k = 0; k <= n; k++)
                y += a[n - k] * Math.Pow(x, k - k);
            n++;
            Console.WriteLine(y);
            k = 0;
            while (k != n)
            {
                k++;
                y = y * x + a[n - k];
            }
            Console.WriteLine(y);
        }
    }
}
