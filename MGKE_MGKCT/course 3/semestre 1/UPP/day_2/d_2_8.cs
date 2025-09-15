// Задание 8: Написать программу, вычисляющую первые n элементов заданной последовательности:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.Write("Выберите задание: ");
            int menu = int.Parse(Console.ReadLine());
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    {
                        double b = 9, bn;
                        for (int i = 0; i < n; i++)
                        {
                            bn = 0.1 * b + 10;
                            b = bn;
                            Console.WriteLine(bn);
                        }
                        break;
                    }
                case 2:
                    {
                        double b = 5, bn;
                        for (int i = 0; i < n; i++)
                        {
                            bn = b / (n * n + n + 1);
                            b = bn;
                            Console.WriteLine(bn);
                        }
                        break;
                    }
                case 3:
                    {
                        double b1 = -1, b2 = 1, bn;
                        for (int i = 0; i < n; i++)
                        {
                            bn = 3 * b2 - 2 * b1;
                            b1 = b2;
                            b2 = bn;
                            Console.WriteLine(bn);
                        }
                        break;
                    }
                case 4:
                    {
                        double b1 = 1, b2 = 2, bn;
                        for (int i = 0; i < n; i++)
                        {
                            bn = (n * b1 - b2) / (n + 1);
                            b1 = b2;
                            b2 = bn;
                            Console.WriteLine(bn);
                        }
                        break;
                    }
            }
        }
    }
}