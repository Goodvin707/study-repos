/*Задание 2: Для выполнения задания внесите изменения в предыдущую Лабораторную работу №5. Варианты заданий остаются прежними.
Простое наследование. 
Разработайте класс DATA – производный от класса BOOK. 
• дата, когда выдана книга. 
Методы: 
• конструктор без параметров (по умолчанию); 
• конструктор с параметрами; 
• метод, осуществляющий ввод значений полей класса с клавиатуры; 
• метод, осуществляющий вывод значений полей класса на экран. 
В определение конструкторов поместите идентифицирующую их работу информацию. 
Например, надпись “Вызван конструктор без параметров”;*/
using System;

namespace AnotherOneTest
{
    class Program
    {
        class BOOK
        {
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
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
                Console.WriteLine("Вызван конструктор без параметров");
                this.Id = 123;
                this.author = "Polejaykin";
                this.title = "Pole";
                this.pages = 200;
            }
            public BOOK(int id, string author, string name, int pages) // Конструктор с параметрами
            {
                Console.WriteLine("Вызван конструктор с параметрами");
                this.Id = id;
                this.Author = author;
                this.Title = name;
                this.Pages = pages;
            }
            public virtual void SetAll() // Метод ввода
            {
                Console.WriteLine("Введите ID книги");
                int id = int.Parse(Console.ReadLine());
                id = this.Id;
                Console.WriteLine("Введите название книги");
                string name = Console.ReadLine();
                name = this.Title;
                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                author = this.Author;
                Console.WriteLine("Введите количество страниц книги");
                int pages = int.Parse(Console.ReadLine());
                pages = this.Pages;
            }
            public virtual void PrintInfo() // Метод вывода
            {
                Console.WriteLine($"Book {Id}\tTitle {title}\tAuthor {author}\tPages {pages}");
            }
            public void SearchByID(int n) // Метод, который выводит название книги, если номер, введенный с клавиатуры, совпал с регистрационным номером объекта
            {
                if (n == this.Id)
                    Console.WriteLine(this.Title + " " + this.Author);
            }
        }
        class DATA : BOOK
        {
            private string issueDate;
            public string IssueDate
            {
                get { return issueDate; }
                set { issueDate = value; }
            }
            public DATA()   // Конструктор по умолчанию
            {
                Console.WriteLine("Вызван конструктор без параметров");
                this.Id = 123;
                this.Author = "Polejaykin";
                this.Title = "Pole";
                this.Pages = 200;
                this.IssueDate = "22.05.2021";
            }
            public DATA(int id, string author, string name, int pages, string issueDate) // Конструктор с параметрами
            {
                Console.WriteLine("Вызван конструктор с параметрами");
                this.Id = id;
                this.Author = author;
                this.Title = name;
                this.Pages = pages;
                this.IssueDate = issueDate;
            }
            public override void SetAll() // Метод ввода
            {
                Console.WriteLine("Введите ID книги");
                int id = int.Parse(Console.ReadLine());
                id = this.Id;
                Console.WriteLine("Введите название книги");
                string name = Console.ReadLine();
                name = this.Title;
                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                author = this.Author;
                Console.WriteLine("Введите количество страниц книги");
                int pages = int.Parse(Console.ReadLine());
                pages = this.Pages;
                Console.WriteLine("Введите дату выдачи");
                string issueDate = Console.ReadLine();
                issueDate = this.IssueDate;
            }
            public override void PrintInfo() // Метод вывода
            {
                Console.WriteLine($"Book: {Id}\tTitle: {Title}\tAuthor: {Author}\tPages: {Pages}\tDate the book was issued: {IssueDate}");
            }
        }
        static void Main()
        {
            DATA[] Ones = new DATA[2];
            for (int i = 0; i < 2; i++)
            {
                Ones[i] = new DATA();
                Console.WriteLine($"\nКнига {i + 1}");
                Ones[i].SetAll();
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