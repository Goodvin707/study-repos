/*Задание 2: Составить программу для определения таблицы значений функции у в произвольном диапазоне [a, b] изменения аргумента х с произвольным шагом h. Значения a, b, h вводятся программно. Таблица должна содержать следующие столбцы: порядковый номер, значение аргумента x, значение функции, сообщение о возрастании или убывании функции. 
Определить максимальное и минимальное значения функции.*/
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
			double pi = 3.1415, a = -pi, b = pi, h = pi / 6, x, y = 0, temp, min, max;
			min = max = a;
			int i = 0;
			x = a;
			while (x <= b)
			{
				temp = y;
				y = x / 2 * Math.Cos(x) - Math.Sin(x);
				i++;
                Console.Write($"x = {x:F2} \t y = {y:F2}");
                if (y < temp) Console.Write(" function down\n");
                else Console.Write(" function up\n");
				x += h;
				if (min > y) min = y;
				if (max < y) max = y;
			}
            Console.WriteLine($"min = {min}\nmax = {max}");
		}
	}
}