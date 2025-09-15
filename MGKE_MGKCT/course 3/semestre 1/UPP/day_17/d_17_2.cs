// Задание 2: Реализуйте последовательную обработку элементов вектора, например, умножение элементов вектора на число. Число элементов вектора задается параметром N.
// Реализуйте многопоточную обработку элементов вектора, используя разделение вектора на равное число элементов. Число потоков задается параметром M.

using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _17_2
{
    class Program
    {
        static List<int> vs = new List<int>();
        static void Main()
        {
            Random r = new Random();
            Console.Write("Введите N: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Последовательная обработка");
            for (int i = 0; i < N; i++)
            {
                vs.Add(r.Next(10, 101));
                Console.Write(vs[i] + " ");
            }
            Console.WriteLine();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < N; i++)
            {
                vs[i] *= N;
                Console.Write(vs[i] + " ");
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"\nTotal time: {ts.TotalMilliseconds}");
            Console.WriteLine();
            
            Console.WriteLine("Многопоточная обработка");
            Console.Write("Введите M: ");
            int M = int.Parse(Console.ReadLine());
            sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, vs.Count, i => { vs[i] += M; });
            sw.Stop();
            ts = sw.Elapsed;
            Console.WriteLine($"Total time: {ts.TotalMilliseconds}");
            for (int i = 0; i < vs.Count; i++)
                Console.Write(vs[i] + " ");
        }
    }
}
