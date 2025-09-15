// Задание 2: С 1 января 1990 года по некоторый день прошло m месяцев и n дней, определить название текущего месяца.
using System;

namespace Praktice
{
    class Program
    {
        static void Main()
        {
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            for (int year = 1990; year <= 2021; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    
                    if (month == 10 && year == 1991)
                        Console.WriteLine(months[month - 1]);
                }
            }
        }
    }
}