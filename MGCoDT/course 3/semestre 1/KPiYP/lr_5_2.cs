/*Задание 2: Реализация методов класса. 
Напишите реализацию методов, предоставляющих доступ к данным класса. Отобразите в программе работу этих методов для объявленного ранее массива объектов.
Добавьте в программу метод, который выводит название книги, если номер, введенный с клавиатуры, совпал с регистрационным номером объекта.*/
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
            private int id;
            public int Id
            {
                get { return Id; }
                set { Id = value; }
            }
            private string author;
            public string Author
            {
                get { return author; }
                set { author = value; }
            }
            private string title;
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            private int pages;
            public int Pages
            {
                get { return pages; }
                set { pages = value; }
            }
            public BOOK()   // Конструктор по умолчанию
            {
                this.Id = 123;
                this.author = "Polejaykin";
                this.title = "Pole";
                this.pages = 200;
            }
            public BOOK(int id, string author, string name, int pages) // Конструктор с параметрами
            {
                this.Id = id;
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
                Console.WriteLine($"Book {Id}\tTitle {title}\tAuthor {author}\tPages {pages}");
            }
            public void SearchByID(int n) // Метод, который выводит название книги, если номер, введенный с клавиатуры, совпал с регистрационным номером объекта
            {
                if (n == this.Id)
                    Console.WriteLine(this.title + " " + this.author);
            }
        }
        static void Main()
        {
            BOOK One = new BOOK();
            BOOK[] Ones = new BOOK[2];
            for (int i = 0; i < 2; i++)
            {
                Ones[i] = new BOOK();
                Console.WriteLine($"Книга {i + 1}");
                Console.Write("Введите ID книги: ");
                Ones[i].Id = int.Parse(Console.ReadLine());
                Console.Write("Введите название книги: ");
                Ones[i].Title = Console.ReadLine();
                Console.Write("Введите автора книги: ");
                Ones[i].Author = Console.ReadLine();
                Console.Write("Введите количество страниц книги: ");
                Ones[i].Pages= int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 2; i++)
                Ones[i].PrintInfo();
            Console.Write("Введите ID книги: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2; i++)
                Ones[i].SearchByID(n);
        }
    }
}