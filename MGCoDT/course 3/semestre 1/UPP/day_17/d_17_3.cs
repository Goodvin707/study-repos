// Задание 3: Создать приложение выполняющее сортировку массива данных и визуального отображения процесса сортировки на экране. Первый поток производит сортировку по возрастанию, второй по убыванию. После каждого перемещения элемента результирующий производится вывод текущего состояния сортировки. Каждый поток работает с отдельным экземпляром массива данных. Состояние сортировки выводится в двух элементах.

using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _17_3
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            Console.Write("Введите кол-во элементов массива: ");
            int n = int.Parse(Console.ReadLine());
            int[] arrUp = new int[n];
            int[] arrDown = new int[n];
            for (int i = 0; i < arrUp.Length; i++)
            {
                int m = r.Next(10, 51);
                arrUp[i] = m;
                arrDown[i] = m;
                Console.Write(arrUp[i] + " ");
            }
            Console.WriteLine("\n");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Thread thread1 = new Thread(() => SortUp(arrUp));
            thread1.Start();
            Thread thread2 = new Thread(() => SortDown(arrDown));
            thread2.Start();

            thread1.Join();
            thread2.Join();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            PrintArr(arrUp);
            PrintArr(arrDown);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"\nС момента начала сортировки прошло: {ts.Minutes} минут(а/ы) {ts.Seconds} секунд(а/ы)");
        }
        static void PrintArr(int[] arr)
        {
            string s = "";
            for (int i = 0; i < arr.Length; i++)
                s += arr[i] + " ";
            Console.WriteLine(s);
        }
        static void SortUp(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("По возрастанию");
                        PrintArr(arr);
                    }
                }
            }
        }
        static void SortDown(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        Thread.Sleep(400);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("По убыванию");
                        PrintArr(arr);
                    }
                }
            }
        }
    }
}
