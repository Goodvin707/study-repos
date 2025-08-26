// Задание 14: Написать программу бинарного поиска и поиска перебором элемента массива равного заданному значению. Провести анализ эффективности алгоритмов поиска.
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Praktice_Day_9
{
    class Program
    {
        static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (Math.Abs(mas[i]) > Math.Abs(mas[j]))
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static void Main()
        {
            int[] arr = new int[10]; // создали массив на 10 элементов
            int key; // создали переменную в которой будет находиться ключ
            Console.WriteLine("Введите 10 чисел для заполнения массива: ");
            for (int i = 0; i < 10; i++)
                arr[i] = i + 1;
            arr = BubbleSort(arr);
            Console.WriteLine("Введите ключ: ");
            key = Convert.ToInt32(Console.ReadLine());
            bool flag = false;
            int l = 0; // левая граница
            int r = 9; // правая граница
            int mid = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((l <= r) && (flag != true))
            {
                mid = (l + r) / 2; // считываем срединный индекс отрезка [l,r]

                if (arr[mid] == key) flag = true; //проверяем ключ со серединным элементом
                if (arr[mid] > key) r = mid - 1; // проверяем, какую часть нужно отбросить
                else l = mid + 1;
            }
            Console.WriteLine("время выполнения " + stopwatch.ElapsedMilliseconds + "ms");
            if (flag)
                Console.WriteLine("Индекс элемента " + key + " в массиве равен: " + mid);
            else
                Console.WriteLine("Извините, но такого элемента в массиве нет");
            Console.WriteLine("Введите ключ: ");
            key = Convert.ToInt32(Console.ReadLine());
            stopwatch.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                mid = i;
                if (key == arr[i])
                    break;
            }
            stopwatch.Stop();
            Console.WriteLine("время выполнения " + stopwatch.ElapsedMilliseconds + "ms");
            if (flag) Console.WriteLine("Индекс элемента " + key + " в массиве равен: " + mid);
            else Console.WriteLine("Извините, но такого элемента в массиве нет");
        }
    }
}
