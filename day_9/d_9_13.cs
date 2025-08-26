// Задание 13: Написать программу поиска перебором и поиска с барьером элемента массива равного заданному значению. Оценить эффективность работы алгоритмов по количеству сравнений.
using System;
using System.Collections.Generic;

namespace Praktice_Day_9
{
    class Program
    {
        public static int SearchBarrier(int[] arr, int isk)
        {
            int i = 0;
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = isk;
            while (arr[i] == isk)
                i++;

            return i < arr.Length - 1 ? i : -1;
        }
        static int SearchPerebor(int[] arr, int isk)
        {
            int i = 0;
            while ((i < arr.Length) && (arr[i] != isk))
                i++;
            return i < arr.Length - 1 ? i : -1;
        }
        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            if (SearchPerebor(arr, 14) != -1)
                Console.WriteLine("Такой элемент найден с помощью поиска перебором");
            else
                Console.WriteLine("Такой элемент не найден с помощью поиска перебором");
            if (SearchBarrier(arr, 14) != -1)
                Console.WriteLine("Такой элемент найден с помощью поиска с барьером");
            else
                Console.WriteLine("Такой элемент не найден с помощью поиска с барьером");
        }
    }
}
