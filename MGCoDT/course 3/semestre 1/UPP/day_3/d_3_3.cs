// Задание 3: Заполнить целочисленную матрицу размером 6x5 случайными числами из [-20; 20]. Переставить в обратном порядке в каждой строчке с нечетным номером все числа с S-го по последнее. Номер числа S ввести с клавиатуры.
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
            Random r = new Random();
            int[,] arr = new int[6, 5];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = r.Next(-20, 21);
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Введите S: ");
            int s = int.Parse(Console.ReadLine());
            int[] temp = new int[5];
            Console.WriteLine("--------------------------");
            for (int i = 0; i < 6; i += 2)
            {
                for (int j = 0; j < 5; j++)
                    temp[j] = arr[i, j];
                Array.Reverse(temp, s - 1, 6 - s);
                for (int j = 0; j < 5; j++)
                    arr[i, j] = temp[j];
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}