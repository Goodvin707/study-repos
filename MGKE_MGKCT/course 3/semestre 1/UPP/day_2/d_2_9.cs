/*Задание 9: Вычислить и вывести на экран значение n члена последовательности для каждого x, принадлежащего промежутку [a,b] c шагом h=0.1 Результат работы программы представить в виде следующей таблицы:
Замечание. Для решения задачи разработать метод, в который передаются значения х и n, и которым возвращается значение bn.*/
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
            int a = -10, b = 20;
            Console.WriteLine("| № | x | b[n](x) |");
            int i = 0;
            for (int x = 0; x <= b; x++)
            {
                double b1 = x;
                double bn = x + 2 * b1;
                Console.WriteLine($"| {++i} | {x} |   {bn}   |");
            }
            for (int x = 0; x <= b; x++)
            {
                double b1 = x;
                double bn = Math.Sin(b1) + Math.PI;
                Console.WriteLine($"| {++i} | {x} |  {bn:F2}  |");
            }
            for (int x = 0; x <= b; x++)
            {
                double b1 = x;
                double bn = b1 + x + 2 * b1;
                Console.WriteLine($"| {++i} | {x} |  {bn:F2}  |");
            }
            for (int x = 0; x <= b; x++)
            {
                double b1 = x, b2 = 2 * x;
                double bn = (b1 / 4) + (5 / (b2 * b2));
                Console.WriteLine($"| {++i} | {x} |  {bn:F2}  |");
            }
        }
    }
}