using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Book : Item
    {
        string author;
        string title;
        string publisher;
        int pages;
        int year;
        static double price = 0;
        private bool returnSrok = false;
        public bool ReturnSrok
        {
            get { return returnSrok; }
            set
            {
                returnSrok = value;
                if (ReturnSrok == true)
                    RetSrok(this);
            }
        }
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
        public void Return()
        {
            ReturnSrok = true;
        }
        public override void ReturnSrk()
        {
            if (ReturnSrok == true)
                taken = true;
            else
                taken = false;
        }
        public override string ToString()
        {
            string str = this.title + ", " + this.author + " Инв.номер " + this.invNumber;
            return str;
        }
        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            if (ReturnSrok)
                processBook(this);
        }
        public delegate void ProcessBookDelegate(Book book);
        public static event ProcessBookDelegate RetSrok;
    }
}