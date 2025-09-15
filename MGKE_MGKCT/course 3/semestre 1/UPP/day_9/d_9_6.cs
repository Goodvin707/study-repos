/*Задание 6: 
ДАН ЛИНЕЙНЫЙ МАССИВ ИЗ N ЦЕЛЫХ ЧИСЕЛ. УПОРЯДОЧИТЬ ЕГО:
Так, чтобы все положительные числа стояли в начале массива, а отрицательные в конце (порядок отрицательных [положительных] элементов между собой может быть произвольным)*/

using System;

namespace Praktice_Day_9
{
    class Program
    {
        static void Main()
        {
            int[] arr = { -1, 5, 5, 6, 8, 3, 2, -8, 0, -5, 7, 5, -3, -2, -8 };
            Array.Sort(arr);
            Array.Reverse(arr);
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.ReadLine();
        }
    }
}
