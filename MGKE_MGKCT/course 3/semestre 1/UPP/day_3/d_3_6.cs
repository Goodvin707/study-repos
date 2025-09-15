/*Задание 6: Создать класс Time описывающий время.
Закрытые поля класса – hour, min, sec –часы, минуты и секунды.
Реализовать методы:
1.	Конструктор с параметрами, присваивающий значения его полям;
2.	Метод без параметров IsValid, который проверяет, возможно ли такое время.
3.	Метод без параметров Plus1, который увеличивает время на 1 секунду.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Praktice
{
    class Program
    {
        class Time
        {
            private int hour;
            private int min;
            private int sec;
            public int Hour
            {
                get { return hour; }
                set
                {
                    Console.WriteLine("Час изменен");
                    hour = value;
                }
            }
            public int Min
            {
                get { return min; }
                set
                {
                    Console.WriteLine("Минута изменена");
                    min = value;
                }
            }
            public int Sec
            {
                get { return sec; }
                set
                {
                    Console.WriteLine("Секунда изменена");
                    sec = value;
                }
            }
            public Time(int hour, int min, int sec)
            {
                this.hour = hour;
                this.min = min;
                this.sec = sec;
            }
            public void isValid()
            {
                try
                {
                    if (this.hour < 0 || this.hour >= 24)
                        throw new Exception("Такого времени не может быть");
                    if (this.min < 0 || this.min > 60)
                        throw new Exception("Такого времени не может быть");
                    if (this.sec < 0 || this.sec > 60)
                        throw new Exception("Такого времени не может быть");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("Время верное");
            }
            public void Print()
            {
                Console.WriteLine("Часов: " +  this.hour);
                Console.WriteLine("Минут: " + this.min);
                Console.WriteLine("Секунд: " + this.sec);
            }
            public void Plus1()
            {
                this.sec++;
            }
        }
        static void Main()
        {
            Time time = new Time(24, 2, 3);
            time.Print();
            time.isValid();
            Console.WriteLine();
            time.Hour = 22;
            time.isValid();
            time.Plus1();
            time.Print();
        }
    }
}