/*Задание 1: Добавить в свой проект стандартные интерфейсы ICloneable и IComparable.Необходимо дать возможность сортировать один из объектов, а также дать возможность создавать копии другого объекта (по выбору).
В методе Main:
Описать переменную типа интерфейс.
Создать объекты каждого дочернего класса.
В зависимости от условия задачи присвоить описанной переменной объект одного из дочерних классов.
Применить к созданному объекту реализованные методы интерфейса.

Создать интерфейс ITax (налогоплательщик) содержащий:
Свойства:
	идентификационный код (четыре цифры);
	год рождения;
	доход;
	налог.
Методы:
	Метод CalculateTax, вычисления налога. Метод заполняет поле налог. В параметре метода текущий год.
	Метод Info - информация (без параметров), который возвращает строку, содержащую информацию об объекте.
Создать классы:
	Ordinary, обычный налогоплательщик, реализует интерфейс ITax
	Privilege, имеющий льготы по налогам,является дочерним классом Ordinary.

Класс Ordinary содержит:
Конструктор, с тремя параметрами, присваивающий значения первым трем полям.
Реализовать методы:
	CalculateTax: Налог вычисляется так:
	Если возраст меньше 17 лет, то налог=0;
	Если доход меньше 1000, то налог=0;
	Если доход работы от 1000 до 10000 (включительно), то налог=20% от дохода;
	Если доход больше 10000, то налог=25% от дохода.
	Info формирует строку с значениями полей.

Класс Privilege содержит:
	Содержит логическое поле, указывающее, что это льготник.
В конструкторе класса использовать четыре параметра – три поля родительского класса и логическое поле дочернего.
Переопределить методы:
	CalculateTax: Налог вычисляется так:
	Если возраст меньше 17 лет, то налог=0;
	Если доход меньше 10000, то налог=0;
	Если доход работы от 10000 до 50000 (включительно), то налог=10% от дохода;
	Если доход больше 50000, то налог=20% от дохода.
	Info формирует строку со значениями полей.*/

using System;
using System.Collections.Generic;

namespace AnotherOneTest
{
    class Program
    {
        interface ITax
        {
            int Id { get; set; }
            int Year { get; set; }
            int Income { get; set; }
            int Tax { get; set; }
            void CalculateTax(DateTime dateTime);
            string Info();
        }
        class Ordinary : ITax
        {
            protected int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            protected int year;
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            protected int income;
            public int Income
            {
                get { return income; }
                set { income = value; }
            }
            protected int tax;
            public int Tax
            {
                get { return tax; }
                set { tax = value; }
            }
            public Ordinary(int id, int year, int income)
            {
                this.id = id;
                this.year = year;
                this.income = income;
            }
            public virtual void CalculateTax(DateTime todayTime)
            {
                int age = todayTime.Year - year;
                if (age < 17 || income < 1000)
                    tax = 0;
                if (income >= 1000 && income <= 10000)
                    tax = income / 20; // налог = 20% от дохода
                if (income > 10000)
                    tax = income / 25; // налог = 25% от дохода
            }
            public virtual string Info()
            {
                return $"ID: {id}  г.р.: {year}  Доход: {income}  Налог: {tax}";
            }
        }
        class Privilege : Ordinary, IComparable, ICloneable
        {
            bool privil;
            public Privilege(bool privil, int id, int year, int income) : base(id, year, income)
            {
                this.privil = privil;
            }
            public override void CalculateTax(DateTime todayTime)
            {
                int age = todayTime.Year - year;
                if (age < 17 || income < 10000)
                    tax = 0;
                if (income >= 10000 && income <= 50000)
                    tax = income / 10; // налог = 10% от дохода
                if (income > 50000)
                    tax = income / 20; // налог = 20% от дохода
            }
            public override string Info()
            {
                return $"Льготный: ID: {id}  г. р.: {year}  Доход: {income}  Налог: {tax}";
            }
            int IComparable.CompareTo(object obj)
            {
                Privilege it = (Privilege)obj;
                if (year == it.year)
                    return 0;
                else if (year> it.year)
                    return 1;
                else
                    return -1;
            }
            public object Clone()
            {
                return new Privilege (privil, id, year, income);
            }
        }
        static void Main()
        {
            DateTime dateTime = DateTime.Today;
            Ordinary obj1 = new Ordinary(5435, 1993, 1200);
            Ordinary obj2 = new Ordinary(5325, 1980, 900);
            Privilege obj3 = new Privilege(true, 5335, 1993, 12000);
            Privilege obj4 = new Privilege(true, 5135, 1993, 8000);
            Console.WriteLine(obj1.Info());
            Console.WriteLine(obj2.Info());
            Console.WriteLine(obj3.Info());
            Console.WriteLine(obj4.Info());
        }
    }
}