// Задание 1: Однорукий бандит - 3 потока, генерирующие числа от 0 до 9. По  нажатию на 0 потоки останавливаются и результат анализируется. При анализе использовать следующие комбинации (три одинаковых числа, два одинаковых числа, три единицы, три семерки, две единицы, имеется четверка)


using System;
using System.Linq;
using System.Threading;

namespace _17_1
{
    class Program
    {
        static int[] shots = new int[3];
        static void Main()
        {
            Thread t1;
            Thread t2;
            Thread t3;
            while (true)
            {
                Console.Clear();
                t1 = new Thread(() => NumGen(0));
                t1.Start();
                Thread.Sleep(100);
                t2 = new Thread(() => NumGen(1));
                t2.Start();
                Thread.Sleep(100);
                t3 = new Thread(() => NumGen(2));
                t3.Start();
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Нажмите любою клавишу для продолжения");
                Console.WriteLine("Нажмите 0 для остановки");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.D0)
                    break;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (shots[0] == shots[1] || shots[1] == shots[2])
            {
                if (shots[0] == shots[2])
                {
                    if (shots[0] == 1)
                        Console.WriteLine("Выпало три единицы");
                    else
                        Console.WriteLine("Выпало три одинаковых числа");
                }
                else
                {
                    if (shots[0] == 1 && shots[2] == 1)
                        Console.WriteLine("Выпало две единицы");
                    else
                        Console.WriteLine("Выпало два одинаковых числа");
                }
            }
            if (shots[0] == shots[2])
                Console.WriteLine("Выпало два одинаковых числа");
            if (shots[0] == 1 && shots[1] == 0 && shots[2] == 1)
                Console.WriteLine("Выпало две единицы");
            if (shots[0] == 7 && shots[1] == 7 && shots[2] == 7)
                Console.WriteLine("Выпало три топора");
            if (shots[0] == 4 || shots[1] == 4 || shots[2] == 4)
                Console.WriteLine("Выпала четверка");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void NumGen(int i)
        {
            Random r = new Random();
            shots[i] = r.Next(0, 10);
            if (i == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            if (i == 1)
                Console.ForegroundColor = ConsoleColor.Blue;
            if (i == 2)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(shots[i]);
        }
    }
}
