using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Book : Item
    {
        string author;      // автор
        string title;   // название
        string publisher; // издательство
        int pages;      // кол-во страниц
        int year; 	 	// год издания
        static double price = 0;
        bool returnSrok;
        public Book() { }
        public Book(string author, string title, string publisher, int pages, int year, long invNumber, bool taken) : base(invNumber, taken)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.pages = pages;
            this.year = year;
        }
        public void SetBook(string author, string title, string publisher, int pages, int year)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.pages = pages;
            this.year = year;
        }
        public static void SetPrice(double price)
        {
            Book.price = price;
        }
        new public void Show()
        {
            Console.WriteLine($"\nКнига:\n Автор: {author}\n Название: {title}\n Год издания: {year}\n {pages} стр.\n Стоимость аренды: {Book.price} р. в сутки");
            base.Show();
        }
        public double PriceBook(int s)
        {
            double cust = s * price;
            return cust;
        }
        public void ReturnSrok()
        {
            returnSrok = true;
        }
        public override void Return()    // операция "вернуть" 
        {
            if (returnSrok == true)
                taken = true;
            else
                taken = false;
        }
    }
}