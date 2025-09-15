/*Задание 3: 
ДАН ЛИНЕЙНЫЙ МАССИВ ИЗ N ЦЕЛЫХ ЧИСЕЛ. УПОРЯДОЧИТЬ ЕГО:
Переставив все нулевые элементы в конец массива (порядок ненулевых элементов может быть произвольным)*/

using System;

namespace Praktice_Day_9
{
    class Program
    {
        public static int[] Foo(int[] arr)
        {
            int zerocounter = 0;
            int count = 0;
            int[] newarr = new int[arr.Length];
            foreach (var item in arr)
            {
                if (item != 0)
                {
                    newarr[count] = item;
                    count++;
                }
                else if (item == 0)
                    zerocounter++;
            }
            for (int i = 0; i < zerocounter; i++)
            {
                newarr[count] = 0;
                count++;
            }
            return newarr;
        }

        static void Main()
        {
            int[] arr = { 1, 2, 3, 0, 0, 4, 0, 5, 6, 0, 0, 0, 4, 3 };
            arr = Foo(arr);
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.ReadLine();
        }
    }
}
