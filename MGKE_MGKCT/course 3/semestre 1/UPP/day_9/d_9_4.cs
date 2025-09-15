/*Задание 4: 
ДАН ЛИНЕЙНЫЙ МАССИВ ИЗ N ЦЕЛЫХ ЧИСЕЛ. УПОРЯДОЧИТЬ ЕГО:
Так, чтобы все четные числа стояли в начале массива, а нечетные в конце (порядок четных [нечетных] элементов между собой может быть произвольным)*/

using System;
using System.Collections.Generic;

namespace Praktice_Day_9
{
    class Program
    {
        static void Sort(ref int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] % 2 != 0)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        static void Main()
        {
            Random random = new Random();
            int[] array = new int[15];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 7);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Sort(ref array);
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
        }
    }
}
