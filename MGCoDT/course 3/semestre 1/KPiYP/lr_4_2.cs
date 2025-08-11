/*Задание 2: Решить поставленную задачу с использованием рекурсивной и обычной функций. Сравнить полученные результаты.
Найти максимальный элемент в массиве ai (i=1, ..., n), используя соотношение (деления пополам) max(a1, ..., an) = max[max(a1, ..., an/2), max(an/2+1, ..., an)].*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int Max(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }
            return max;
        }
        static int RecMax(int[] array, int n)
        {
            if (n == 1)
                return array[0];
            //max(a[1], ..., a[n]) = max[max(a1, ..., a[n / 2]), max(a[n / 2 + 1], ..., a[n])]
            return Math.Max(RecMax(array, n / 2), RecMax(array + n / 2 + 1, n));
        }
        static void Main()
        {
            int[] ar = { 2, 1, 5, 9, 3 };
            Console.Write("Array: ");
            for (int i = 0; i < ar.Length; i++)
                Console.Write(ar[i] + ' ');
            Console.WriteLine("Не рекурсия");
            Console.WriteLine("Max: " + Max(ar));
            Console.WriteLine("Рекурсия");
            Console.WriteLine("Max: " + RecMax(ar, ar.Length));
            Console.ReadKey();
        }
    }
}