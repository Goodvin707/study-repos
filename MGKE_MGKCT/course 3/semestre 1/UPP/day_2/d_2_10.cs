/*Задание 10: Разработать рекурсивный метод для вывода на экран всех возможных разложений натурального числа n на множители (без повторений). Например, для n=12 на экран должно быть выведено:
2*2*3=12
2*6=12
3*4=12*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Praktice
{
    class Program
    {
        static void F(int delitel, int n, int j, int m, int[] a)
        {
            if (n == 1)
            {
                for (int i = 0; i < j - 1; i++)
                    Console.Write(a[i] + "*");
                if (j > 0 && a[j - 1] != m)
                    Console.WriteLine(a[j - 1] + "=" + m);
                return;
            }
            for (a[j] = delitel; a[j] <= n; a[j]++)
            {
                if ((n % a[j]) == 0)
                    F(a[j], n / a[j], j + 1, m, a);
            }
        }
        static void Main()
        {
            int[] a = new int[100];
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            int m = n;
            F(2, n, 0, m, a);
        }
    }
}