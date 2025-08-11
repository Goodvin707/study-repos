/*Задание 1: Описание класса. 
Запишите описание класса с именем BOOK, содержащего следующие поля: 
• регистрационный номер; 
• автор; 
• название книги; 
• количество страниц. 
Скройте элементы-данные от пользователя, предоставив интерфейс доступа к полям посредством открытых методов (предусмотрите объявление двух методов, один из которых присваивает значения полям класса, а другой – выводит значения этих свойств на экран). Объявите массив объектов созданного класса.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class BOOK
        {
            public int id { get; set; }
            internal string author { get; set; }
            internal string title { get; set; }
            internal int pages { get; set; }

            public BOOK()   // Конструктор по умолчанию
            {
                this.id = 123;
                this.author = "Polejaykin";
                this.title = "Pole";
                this.pages = 200;
            }
            public BOOK(int id, string author, string name, int pages) // Конструктор с параметрами
            {
                this.id = id;
                this.author = author;
                this.title = name;
                this.pages = pages;
            }
            public void SetAll() // Метод
            {
                Console.WriteLine("Введите ID книги");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите название книги");
                string name = Console.ReadLine();
                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                Console.WriteLine("Введите количество страниц книги");
                int pages = int.Parse(Console.ReadLine());
            }
            public void PrintInfo() // Метод
            {
                Console.WriteLine($"Book {id}\tTitle = {title}\tAuthor = {author}\nPages = {pages}");
            }
        }
        static void Main()
        {
            BOOK One = new BOOK();
            BOOK[] Ones = new BOOK[5];
            One.PrintInfo();
        }
    }
}