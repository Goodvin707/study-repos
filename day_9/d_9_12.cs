// Задание 12: Написать программу поиска с барьером и бинарного поиска элемента массива равного заданному значению. Провести анализ эффективности алгоритмов поиска.
using System;
using System.Collections.Generic;

namespace Praktice_Day_9
{
    class Program
    {
        public static int BinSearch(int[] arr, int isk)
        {
            int start = 0, finish = arr.Length - 1, mid = (start + finish) / 2;
            while (start <= finish)
            {
                if (mid == isk)
                    return mid;
                if (arr[mid] > isk)
                    finish = mid - 1;
                else
                    start = mid + 1;
                mid = (start + finish) / 2;
            }
            return -1;
        }
        public static int SearchBarrier(int[] arr, int isk)
        {

            int i = 0;
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = isk;
            while (arr[i] == isk)
                i++;
            return i < arr.Length - 1 ? i : -1;

        }
        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            if (BinSearch(arr, 14) != -1)
                Console.WriteLine("Такой элемент найден с помощью бинарного поиска");
            else
                Console.WriteLine("Такой элемент не найден с помощью бинарного поиска");
            if (SearchBarrier(arr, 14) != -1)
                Console.WriteLine("Такой элемент найден с помощью поиска с барьером");
            else
                Console.WriteLine("Такой элемент не найден с помощью поиска с барьером");
        }
    }
}
