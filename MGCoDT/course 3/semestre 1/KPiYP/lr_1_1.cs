/*Задание 1: Вычислить значение y в зависимости от выбранной функции  (x), аргумент которой определяется из поставленного условия. 
Возможные значения функции  (x): 2x, x2, х/3. Предусмотреть вывод сообщений, показывающих, при каком условии и с какой функцией производились вычисления у.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            double x, y;
            double fi;
            double a = 0.3, b = 0.4;
            double z = 1.4;
            Console.WriteLine("Выберите значение функции fi\nfi = 2x\nfi = x^2\nfi = x/3");
            string menu = Console.ReadLine();
            if (z > 0)
            {
                x = 1 / (Math.Pow(z, 2) + 2 * z);
            }
            else
            {
                x = 1 - Math.Pow(z, 3);
            }
            switch (menu)
            {
                case "2x": fi = 2 * x; Console.WriteLine("Выбрано значение 2x\nfi = " + fi); break;
                case "x^2": fi = x * x; Console.WriteLine("Выбрано значение x^2\nfi = " + x * x + fi); break;
                case "x/3": fi = x / 3; Console.WriteLine("Выбрано значение x/3\nfi = " + x / 3 + fi); break;
                default: Console.WriteLine("Не найдено такого значения"); fi = 0; break;
            }
            if (fi != 0)
            {
                y = (2.5 * a * Math.Exp(-3 * x) - 4 * b * Math.Pow(x, 2)) / (Math.Log(Math.Abs(x)) + fi);
                Console.WriteLine("y = " + y);
                Console.WriteLine("y = {0}", y);
                Console.WriteLine($"y = {y}");
            }
            Console.ReadKey();
        }
    }
}