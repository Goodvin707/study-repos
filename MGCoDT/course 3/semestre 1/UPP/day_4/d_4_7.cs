// Задание 7: Написать программу 1, создающую файл 1.txt, содержащий значения х.
using System;
using System.IO;

namespace Praktice_Day_4
{
    class Program
    {
        static void Main()
        {
            string s;
            double x;
            StreamWriter f = new StreamWriter("1.txt");
            for (x = -3; x <= 3; x += 0.5)
                f.WriteLine($"{x:F3}");
            f.Close();
        }
    }
}