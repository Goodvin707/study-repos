/*Задание 2: Значение аргумента x изменяется от a до b с шагом h. Для каждого x найти значения функции Y(x), суммы S(x) и |Y(x)–S(x)| и вывести в виде таблицы. Значения a, b, h и n вводятся с клавиатуры. Так как значение S(x) является рядом разложения функции Y(x), значения S и Y для заданного аргумента x должны совпадать в целой части и в первых двух-четырех позициях после десятичной точки. 
Работу программы проверить для a = 0,1; b = 1,0; h = 0,1; значение параметра n выбрать в зависимости от задания.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int Fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        static void Main()
        {
            double a = 0.1, b = 1.0, h = 0.1, s = 0, x = a, y;
            int k, n = 5;
            while (x <= b)
            {
                for (k = 0; k < n; k++)
                {
                    s += (((Math.Pow(k, 2) + 1)) / (Fact(k))) * Math.Pow(x / 2, k);
                }
                y = ((Math.Pow(x, 2) / 4) + (x / 2) + 1) * Math.Exp(x / 2);
                x += h;
                //Console.WriteLine("Y(x) = " + y + "\t" + "S(x) = " + s + "\t" + "|Y(x) - S(x)| = " + Math.Abs(y - s));
                //Console.WriteLine("Y(x) = {0}\tS(x) = {1}\t|Y(x) - S(x)| = {2}", y, s, Math.Abs(y - s));
                Console.WriteLine($"Y(x) = {y}\tS(x) = {s}\t|Y(x) - S(x)| = {Math.Abs(y - s)}");
                s = 0;
            }
            Console.ReadKey();
        }
    }
}