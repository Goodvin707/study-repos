/*Задание 19: Багаж пассажира характеризуется количеством вещей и общим весом вещей. Сведения о багаже каждого пассажира - количество вещей и вес в килограммах. 
a) Найти багаж, средний вес одной вещи в котором отличается не более, чем на 0.3 кг от общего среднего веса одной вещи. 
b) Найти число пассажиров, имеющих более двух вещей и число пассажиров, количество вещей которых превосходит среднее число вещей. 
c) Определить, имеются ли два пассажира, багажи которых совпадают по числу вещей и различаются по весу не более чем на 0,5 кг. 
d) Выяснить, имеется ли пассажир, багаж которого превышает багаж каждого из остальных пассажиров и по числу вещей, и по весу. 
e) Выяснить, имеется ли пассажир, багаж которого состоит из одной вещи весом менее 30 кг.*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Praktice_Day_9
{
    class Program
    {
        class Luggage
        {
            int kol;
            double weight;

            public Luggage(int kol, double weight)
            {
                this.kol = kol;
                this.weight = weight;
            }

            public static void FuncB(Luggage[] arr)
            {
                double srkol = 0;
                double allkol = 0;
                int chislobolee2veshchei = 0;
                int chisloboleesrednego = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    allkol += arr[i].kol;
                    if (arr[i].kol > 2)
                        chislobolee2veshchei++;
                }
                srkol = allkol / arr.Length;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].kol > srkol)
                        chisloboleesrednego++;
                }
                Console.WriteLine($"Число пассажиров с числом вещей багажа более среднего = {chisloboleesrednego}");
                Console.WriteLine($"Число пассажиров, провозящих более 2х вещей = {chislobolee2veshchei}");
            }
            public static void FuncC(Luggage[] arr)
            {
                double[] arrkol = new double[arr.Length];
                double[] arrmass = new double[arr.Length];
                bool isTrue = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    arrkol[i] = arr[i].kol;
                    arrmass[i] = arr[i].weight;
                    if (arrkol.Contains(arr[i].kol) && arr[i].weight! < arrmass[i] + 0.5 && arr[i].weight! > arrmass[i] - 0.5)
                        isTrue = true;
                }
                if (isTrue)
                    Console.WriteLine("Два пассажира имеют одинаковое кол-во вещей с почти одинковым весом");
                else
                    Console.WriteLine("Два пассажира не имеют одинаковое кол-во вещей с почти одинковым весом");
            }
            public static void FuncD(Luggage[] arr)
            {
                int maxkol = 0;
                double maxweight = 0;
                int maxindex = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (maxkol < arr[i].kol && maxweight < arr[i].weight)
                    {
                        maxkol = arr[i].kol;
                        maxweight = arr[i].weight;
                        maxindex = i;
                    }
                }
                Console.WriteLine($"Багаж под номером {maxindex} максимально большой и тяжёлый");
            }
            public static void FuncE(Luggage[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].kol == 1 && arr[i].weight < 30)
                    {
                        Console.WriteLine("Пассажир с одной вещью весом до 30кг существует");
                        return;
                    }
                }
                Console.WriteLine("Пассажир с одной вещью весом до 30кг не существует");
            }
        }
        static void Main()
        {
            Luggage[] arr = new Luggage[3];
            arr[0] = new Luggage(1, 29);
            arr[1] = new Luggage(5, 105);
            arr[2] = new Luggage(5, 104.6);
            Luggage.FuncB(arr);
            Luggage.FuncC(arr);
            Luggage.FuncD(arr);
            Luggage.FuncE(arr);
        }
    }
}
