// Задание 3: Вывести на экран все четные числа из диапазона от А до В, кратные трем (А£В);
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите диапазон значений\nA = ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("B = ");
            int B = int.Parse(Console.ReadLine());
            Console.Write("Числа, кратные трём: ");
            do
            {
                if (A % 3 == 0)
                    Console.Write($"{A} ");
                A++;
            } while (A <= B);
        }
    }
}