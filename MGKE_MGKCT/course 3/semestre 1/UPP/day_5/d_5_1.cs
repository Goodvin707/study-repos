/*Задание 1: Описать класс для работы с одномерным массивом в соответствии с вариантом. Описать классы для необходимых исключений (например, контроль ввода данных, выход за границу массива).
Конструктор с одним параметром (имя файла с числами для заполнения массива), вычисляющий n - количество чисел в файле, создающий массив из n элементов и заполняющий его из файла с заданным именем;
Конструктор c одним параметрами (n), создающий массив из n элементов и заполняющий его кубами натурального ряда чисел (1,4,9…n3), знак числа задается случайным образом;
свойство, доступное только для чтения, для получения количества элементов массива, больших 50;
метод, выводящий содержимое массива на экран;
метод, вычисляющий сумму модулей элементов, расположенных до (левее) первого положительного элемента.*/
using System;
using System.IO;

namespace Praktice_Day_5
{
    class Program
    {
        class Arr
        {
            readonly private int k = 0;
            public int K
            {
                get { return k; }
            }
            double[] arr;
            public Arr(string fileName)
            {
                int n = 0, i = 0, x;
                string s = "";
                StreamReader f = new StreamReader(fileName);
                while (s != null)
                {
                    s = f.ReadLine();
                    if (s != null)
                        n++;
                }
                f.Close();
                Console.WriteLine("Количество элементов: " + n);
                arr = new double[n];
                f = new StreamReader(fileName);
                s = "";
                while (s != null)
                {
                    s = f.ReadLine();
                    if (s != null)
                    {
                        try
                        {
                            x = Convert.ToInt32(s);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("В файле указаны числа неверного формата\nМассив будет заполнен нулями");
                            break;
                        }
                        arr[i] = x;
                        if (arr[i] > 50)
                            k++;
                        i++;
                    }
                }
                Print();
                f.Close();
            }
            public Arr(int n)
            {
                Random r = new Random();
                arr = new double[n];
                for (int i = 0; i < n; i++)
                {
                    int rr = r.Next(0, 2);
                    switch (rr)
                    {
                        case 0:
                            arr[i] = Math.Pow(i + 1, 3);
                            break;
                        case 1:
                            double neg = Math.Pow(i + 1, 3);
                            arr[i] = neg - neg - neg;
                            break;
                        default: break;
                    }
                    if (arr[i] > 50)
                        k++;
                }
                Print();
            }
            public void Print()
            {
                Console.Write("Элементы:");
                for (int i = 0; i < arr.Length; i++)
                    Console.Write(" " + arr[i]);
                Console.WriteLine("\nКоличество элементов, больших 50: " + k);
            }
            public double SumModule()
            {
                double sum = 0;
                int ii = 0;
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] > 0)
                        ii = i;
                for (int i = ii; i >= 0; i--)
                    sum += Math.Abs(arr[i]);
                Console.WriteLine("Сумма: " + sum);
                return sum;
            }
        }
        static void Main()
        {
            Arr a = new Arr("file.txt");
            a.SumModule();
            Arr b = new Arr(8);
            b.SumModule();
        }
    }
}
