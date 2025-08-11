// Задание 2: Известно, что X кг шоколадных конфет стоит A рублей, а Y кг ирисок стоит B рублей. Определить, сколько стоит 1 кг шоколадных конфет, 1 кг ирисок, а также во сколько раз шоколадные конфеты дороже ирисок.
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите значения");
            double sx, sy;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine($"{x} кг шоклоладных конфет стоят {a} рублей\n{y} кг ирисок стоят {b} рублей");
            sx = a / x;
            sy = b / y;
            Console.WriteLine($"Цена одного кг шоколадных конфет {sx:F2}");
            Console.WriteLine($"Цена одного кг ирисок {sx:F2}");
            Console.WriteLine($"Шоколадные конфеты доороже в {sx/sy:F2}");
        }
    }
}