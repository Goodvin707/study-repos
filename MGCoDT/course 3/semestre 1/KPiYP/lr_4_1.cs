/*Задание 1: Составить программу из ЛР №1 (второй уровень сложности), в которой для каждого x, изменяющегося от a до b с шагом h, вычисление значений Y(x) и S(x) оформить в виде функций пользователя. 
В основной функции реализовать следующие действия:
- ввод исходных значений a, b, h и n; 
- обращение к функциям расчета Y(x) и S(x);
- вывод результатов в виде таблицы. 
Если в задании используется значение факториала, его расчет также оформить функцией.*/
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
            Console.WriteLine("Введите значения a, b, h и n");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double s = 0, x = a, y;
            int k, n = int.Parse(Console.ReadLine());
            while (x <= b)
            {
                for (k = 0; k < n; k++)
                {
                    s += (((Math.Pow(k, 2) + 1)) / (Fact(k))) * Math.Pow(x / 2, k);
                }
                y = ((Math.Pow(x, 2) / 4) + (x / 2) + 1) * Math.Exp(x / 2);
                x += h;
                Console.WriteLine($"Y(x) = {y}\tS(x) = {s}\t|Y(x) - S(x)| = {Math.Abs(y - s)}");
                s = 0;
            }
            Console.ReadKey();
        }
    }
}