/*Задание 7:	Создать класс Date описывающий дату. Закрытые поля класса – year, month, day–год, месяц и число. Реализовать методы:
1. Конструктор с параметрами, присваивающий значения его полям; 
2. Метод без параметров IsValid, который проверяет, возможна ли такая дата. 
3. Метод без параметров Plus1, который увеличивает дату на 1 день.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Praktice
{
    class Program
    {
        class Date
        {
            private int year;
            private int month;
            private int day;
            public Date(int year, int month, int day)
            {
                this.year = year;
                this.month = month;
                this.day = day;
            }
            public void isValid()
            {
                try
                {
                    if (this.year < 0)
                        throw new Exception("Такой даты быть не может");
                    if (this.month < 0 || this.month > 12)
                        throw new Exception("Такой даты быть не может");
                    if (this.day < 0 || this.day > 31)
                        throw new Exception("Такой даты быть не может");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("Дата верная");
            }
            public void Print()
            {
                Console.WriteLine("Год: " + this.year);
                Console.WriteLine("Месяц: " + this.month);
                Console.WriteLine("День: " + this.day);
            }
            public void Plus1()
            {
                this.day++;
            }
        }
        static void Main()
        {
            Date date = new Date(2020, 11, 3);
            date.isValid();
            date.Print();
            date.Plus1();
            date.Print();
        }
    }
}