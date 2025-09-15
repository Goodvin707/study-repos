/*Задание 7: 
ДАН ЛИНЕЙНЫЙ МАССИВ ИЗ N ЦЕЛЫХ ЧИСЕЛ. УПОРЯДОЧИТЬ ЕГО:
Чтобы все положительные числа стояли в начале массива, а отрицательные в конце (порядок следования элементов должен сохраниться).*/

using System;
using System.Collections.Generic;

namespace Praktice_Day_9
{
    class Program
    {
        public static void Foo(ref int[] arr)
        {
            List<int> plus = new List<int>();
            List<int> minus = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                    plus.Add(arr[i]);
                else
                    minus.Add(arr[i]);
            }
            int count1 = 0;
            for (int i = 0; i < plus.Count; i++)
            {
                arr[count1] = plus[i];
                count1++;
            }
            for (int i = 0; i < minus.Count; i++)
            {
                arr[count1] = minus[i];
                count1++;
            }
        }
        static void Main()
        {
            int[] arr = { -1, 5, 6, 8, 3, 2, -8, -5, 7, 5, -3, -2, -8 };
            Foo(ref arr);
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.ReadLine();
        }
    }
}
