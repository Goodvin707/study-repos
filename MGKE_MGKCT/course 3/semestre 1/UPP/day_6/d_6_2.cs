// Задание 2: Определить комбинированный (структурный) тип для представления анкеты жителя, состоящей из его фамилии, названия города, где он проживает, и городского адреса. Адрес состоит из полей: «улица», «дом», «квартира». Ввести информацию по 10 жителям. Вывести фамилии жителей, которые живут в Минске на улице Асаналиева.
using System;

namespace Practice_Day_6
{
    class Program
    {
        struct Adress
        {
            string street;
            public string Street
            {
                get { return street; }
                set { street = value; }
            }
            string house;
            public string House
            {
                get { return house; }
                set { house = value; }
            }
            string room;
            public string Room
            {
                get { return room; }
                set { room = value; }
            }
            public Adress(string street, string house, string room)
            {
                this.street = street;
                this.house = house;
                this.room = room;
            }
        }
        struct Citizen
        {
            string secName;
            public string SecName
            {
                get { return secName; }
                set { secName = value; }
            }
            string city;
            public string City
            {
                get { return city; }
                set { city = value; }
            }
            Adress adress;
            public Adress Adr
            {
                get { return adress; }
                set { adress = value; }
            }
            public Citizen(string secName, string city, string street, string house, string room)
            {
                this.secName = secName;
                this.city = city;
                adress = new Adress(street, house, room);
            }
            public void Print()
            {
                Console.WriteLine("Фамилия: " + secName + " Город: " + city);
                Console.WriteLine("Адрес\n Улица: " + adress.Street + " Дом: " + adress.House + " Квартира: " + adress.Room);
            }
        }
        static string NameGenerator(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
                s += (char)r.Next(65, 91);
            return s;
        }
        static void Main()
        {
            Random r = new Random();
            Citizen[] citizens = new Citizen[10];
            for (int i = 0; i < citizens.Length; i++)
            {
                citizens[i] = new Citizen(NameGenerator(r.Next(4, 12)), NameGenerator(r.Next(4, 12)), NameGenerator(r.Next(4, 12)), NameGenerator(r.Next(4, 12)), NameGenerator(r.Next(4, 12)));
                citizens[i].Print();
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < citizens.Length; i++)
                if (citizens[i].City == "Минск" && citizens[i].Adr.Street == "Асаналиева")
                    Console.WriteLine(citizens[i].SecName);
        }
    }
}
