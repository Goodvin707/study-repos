/*Задание 1: 
РЕАЛИЗОВАТЬ В ПРОГРАММЕ ВСЕ АЛГОРИТМЫ СОРТИРОВКИ:
1. сортировка с помощью прямого включения,
2. сортировка с помощью прямого выбора при помощи поиска минимального элемента,
3. сортировка с помощью прямого выбора при помощи поиска одновременно минимального и максимального элементов,
4. сортировка «пузырьком»,
5. шейкерная сортировка,
6. сортировка Шелла.*/

using System;

namespace Praktice_Day_9
{
    class Program
    {
        static void Print(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
                Console.Write(mass[i] + " ");
            Console.WriteLine();
        }
        static void SortВirectInclusion(int[] mass)
        {
            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i] < mass[i - 1])
                {
                    while (i >= 1)
                    {
                        if (mass[i] < mass[i - 1])
                        {
                            int temp = mass[i];
                            mass[i] = mass[i - 1];
                            mass[i - 1] = temp;
                        }
                        i--;
                    }
                    i = 1;
                }
            }
            Print(mass);
        }
        static void SortMin(int[] mass)
        {
            int min = int.MaxValue;
            int IndexMin = -1;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = i; j < mass.Length; j++)
                {
                    if (min > mass[j])
                    {
                        min = mass[j];
                        IndexMin = j;
                    }
                }
                int temp = mass[i];
                mass[i] = mass[IndexMin];
                mass[IndexMin] = temp;
                min = int.MaxValue;
            }
            Print(mass);
        }
        static void Swap(ref int[]mass,int IndexI,int IndexChenge)
        {
            int temp = mass[IndexI];
            mass[IndexI] = mass[IndexChenge];
            mass[IndexChenge] = temp;
        }
        static void SortMinAndMaxAtTheSameTime(int[]mass)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int IndexMax = -1;
            int IndexMin = -1;
            for (int i = 0; i < mass.Length/2; i++)
            {
                for(int j = 0 + i; j < mass.Length - i; j++)
                {
                    if (min > mass[j])
                    {
                        min = mass[j];
                        IndexMin = j;
                    }
                }
                min = int.MaxValue;
                Swap(ref mass, i, IndexMin);
                for(int g = 0 + i; g < mass.Length-i; g++)
                {
                    if (max < mass[g])
                    {
                        max = mass[g];
                        IndexMax = g;
                    }
                }
                max = int.MinValue;
                Swap(ref mass, (mass.Length - (i + 1)), IndexMax);
            }
            Print(mass);
        }
        static void BubbleSort(int[] mass)
        {
            bool itemMoved;
            do
            {
                itemMoved = false;
                for (int i = 0; i < mass.Length - 1; i++)
                {
                    if (mass[i] > mass[i + 1])
                    {
                        int temp = mass[i];
                        mass[i] = mass[i + 1];
                        mass[i + 1] = temp;
                        itemMoved = true;
                    }
                }
            }
            while (itemMoved);
            Print(mass);
        }
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        static void ShakerSorting(int[] mass)
        {
            for (int i = 0; i < mass.Length / 2; i++)
            {
                bool swapFlag = false;
                for (int j = i; j < mass.Length - i - 1; j++)
                {
                    if (mass[j] > mass[j + 1])
                    {
                        Swap(ref mass[j], ref mass[j + 1]);
                        swapFlag = true;
                    }
                }
                for (int j = (mass.Length - 2 - i); j > i; j--)
                {
                    if (mass[j - 1] > mass[j])
                    {
                        Swap(ref mass[j - 1], ref mass[j]);
                        swapFlag = true;
                    }
                }
                if (!swapFlag) break;
            }
            Print(mass);
        }
        static void ShellSort(int[] mass)
        {
            int d = mass.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < mass.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (mass[j - d] > mass[j]))
                    {
                        Swap(ref mass[j], ref mass[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            Print(mass);
        }
        static void Main()
        {
            int[] mass = { 100, 5, 1, 34, 5, 78, 12, 9, 100 };
            SortВirectInclusion(mass);
            SortMin(mass);
            SortMinAndMaxAtTheSameTime(mass);
            BubbleSort(mass);
            ShakerSorting(mass);
            ShellSort(mass);
        }
    }
}
