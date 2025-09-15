// Задание 8: Написать программу 2, вычисляющую значения y и выводящую эти значения в файл 2.txt в виде таблицы (как в примере).
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s = "";
            double x;
            StreamReader f1 = new StreamReader("1.txt");
            StreamWriter f2 = new StreamWriter("2.txt");
            while (s != null)
            {
                s = f1.ReadLine();
                if (s != null)
                {
                    x = Convert.ToDouble(s);
                    if (x >= 1 && x <= 2)
                        f2.WriteLine($"x = {x, 6:F3}  y = {2*x:F3}");
                    else
                        f2.WriteLine($"x = {x,6:F3}  y = {(x * x) / (Math.Abs(2 * x + 9)):F3}");
                }
            }
            f1.Close();
            f2.Close();
        }
    }
}
