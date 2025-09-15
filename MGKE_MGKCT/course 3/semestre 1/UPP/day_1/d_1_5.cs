// Задание 5: Гражданин 1 марта открыл в банке счет и положил на него А грн. Через каждый месяц размер вклада увеличивается на 2% от суммы, на счету. Через сколько месяцев величина вклада станет больше В грн?
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Сегодня 1-е марта\nСколько хотите положить на счёт?");
            double A = double.Parse(Console.ReadLine());
            Console.WriteLine($"Вы положили {A} грн.");
            double B = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите будущий размер вклада");
            int месяцев = 0;
            do
            {
                месяцев++;
                A = A + (A * 0.02);
            } while (A <= B);
            Console.WriteLine($"Через {месяцев} месяцев");
        }
    }
}