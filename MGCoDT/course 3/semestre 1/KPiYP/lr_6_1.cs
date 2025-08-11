/*Задание 1: Составить программу, решающую указанную ниже задачу. 
В одномерном массиве, состоящем из n (не более 10) вводимых с клавиатуры значений, вычислить заданное значение.
Сумму модулей элементов массива, расположенных после минимального по модулю элемента.*/
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
            Random rnd = new Random();
            int min = 10, sum = 0;
            int n;
            do
            {
                Console.Write("Введите значение <= 10: ");
                n = int.Parse(Console.ReadLine());
            } while (n >= 10);
            int[] ar = new int[n];
            Console.Write("Array: ");
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = rnd.Next(-10, 10);
                Console.Write(ar[i] + " ");
            }
            for (int i = 0; i < ar.Length; i++)
                ar[i] = Math.Abs(ar[i]);
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] < min)
                    min = ar[i];
            }
            for (int i = min; i < ar.Length; i++)
            {
                sum += ar[i];
            }
            Console.WriteLine("\n" + min + "\n" + sum);
            Console.ReadKey();
        }
    }
}