// Задание 5: Пусть имеется файл действительных чисел и некоторое число C. Используя очередь, напечатать сначала все элементы, меньшие числаC, а затем все остальные элементы.
using System;
using System.IO;
using System.Collections.Generic;

namespace Praktice_Day_5
{
    class Program
    {
        static void Main()
        {
            Stack<double> stack = new Stack<double>();
            StreamReader f = new StreamReader("file.txt");
            double c = 3.58;
            string s = "";
            while(s != null)
            {
                s = f.ReadLine();
                if (s != null)
                {
                    double d = Convert.ToDouble(s);
                    if (d > c)
                        stack.Push(d);
                    else
                        Console.Write(d + " ");
                }
            }
            Console.WriteLine();
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                Console.Write(stack.Pop() + " ");
            }
            f.Close();
        }
    }
}
