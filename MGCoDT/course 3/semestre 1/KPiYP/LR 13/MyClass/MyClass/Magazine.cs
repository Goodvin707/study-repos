using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Magazine : Item, IPubs
    {
        string volume;    // том
        int number;        // номер 
        string title;       // название 
        int year;      // год выпуска 
        public Magazine() { }
        public Magazine(String volume, int number, String title, int year, long invNumber, bool taken) : base(invNumber, taken)
        {
            this.volume = volume;
            this.number = number;
            this.title = title;
            this.year = year;
        }
        new public void Show()
        {
            Console.WriteLine($"\nЖурнал:\n Том: {volume}\n Номер: {number}\n Название: {title}\n {year} \n Год выпуска: {4}");
            base.Show();
        }
        public override void ReturnSrk()    // операция "вернуть" 
        {
            taken = true;
        }
        public bool IfSubs { get; set; }
        public void Subs()
        {
            Console.WriteLine("Подписка на журнал \"{0}\": {1}.", title, IfSubs);
        }
    }
}