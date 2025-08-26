/*Задание 2: 
ДАН ЛИНЕЙНЫЙ МАССИВ ИЗ N ЦЕЛЫХ ЧИСЕЛ. УПОРЯДОЧИТЬ ЕГО:
Сортировкой «пузырьком» в порядке возрастания модулей элементов*/

using System;

namespace Praktice_Day_9
{
    class Program
    {
        static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (Math.Abs(mas[i]) > Math.Abs(mas[j]))
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static void Main()
        {
            Random random = new Random();

            int[] array = new int[15];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 11);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            BubbleSort(array);
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
        }
    }
}
