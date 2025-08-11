using System;

namespace StudyCenter
{
    class Program
    {
        abstract class Person
        {
            protected string secName;
            protected DateTime birthDate;
            public Person (string secName, DateTime birthDate)
            {
                this.secName = secName;
                this.birthDate = birthDate;
            }
            public abstract void Print();
            public virtual void Age()
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Today;
                Console.WriteLine(dateTime.Year - birthDate.Year);
            }
        }
        class Admin : Person
        {
            string laboratory;
            public Admin(string laboratory, string secName, DateTime birthDate) : base(secName, birthDate)
            {
                this.laboratory = laboratory;
            }
            public override void Print()
            {
                Console.WriteLine("Фамилия: " + secName);
                Console.WriteLine("Дата рождения: " + birthDate);
                Console.WriteLine("Лаборатория: " + laboratory);
            }
        }
        class Student : Person
        {
            string facult;
            byte curse;
            public Student(string facult, byte curse, string secName, DateTime birthDate) : base(secName, birthDate)
            {
                this.facult = facult;
                this.curse = curse;
            }
            public override void Print()
            {
                Console.WriteLine("Фамилия: " + secName);
                Console.WriteLine("Дата рождения: " + birthDate);
                Console.WriteLine("Факультет: " + facult);
                Console.WriteLine("Курс: " + curse);
            }
        }
        class Teacher : Person
        {
            string facult;
            string job;
            byte experience;
            public Teacher(string facult, string job, byte experience, string secName, DateTime birthDate) : base(secName, birthDate)
            {
                this.facult = facult;
                this.job = job;
                this.experience = experience;
            }
            public override void Print()
            {
                Console.WriteLine("Фамилия: " + secName);
                Console.WriteLine("Дата рождения: " + birthDate);
                Console.WriteLine("Факультет: " + facult);
                Console.WriteLine("Должность: " + job);
                Console.WriteLine("Стаж: " + experience);
            }
        }
        class Manager : Person
        {
            string facult;
            string job;
            public Manager(string facult, string job, string secName, DateTime birthDate) : base(secName, birthDate)
            {
                this.facult = facult;
                this.job = job;
            }
            public override void Print()
            {
                Console.WriteLine("Фамилия: " + secName);
                Console.WriteLine("Дата рождения: " + birthDate);
                Console.WriteLine("Факультет: " + facult);
                Console.WriteLine("Должность: " + job);
            }
        }
        static string StringGenerator(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
            {
                s += Convert.ToChar(r.Next(65, 91));
            }
            return s;
        }
        static void Main()
        {
            Random r = new Random();
            int n = int.Parse(Console.ReadLine());
            Person[] persons = new Person[n];
            for (int i = 0; i < persons.Length; i++)
            {
                switch (r.Next(1, 5))
                {
                    case 1:
                        persons[i] = new Admin(StringGenerator(r.Next(5, 15)), StringGenerator(r.Next(5, 15)), new DateTime(r.Next(1990, 2012), r.Next(0, 13), r.Next(1, 29)));
                        break;
                    case 2:
                        persons[i] = new Student(StringGenerator(r.Next(5, 15)), (byte)r.Next(1, 7), StringGenerator(r.Next(5, 15)), new DateTime(r.Next(1990, 2012), r.Next(0, 13), r.Next(1, 29)));
                        break;
                    case 3:
                        persons[i] = new Teacher(StringGenerator(r.Next(5, 15)), StringGenerator(r.Next(5, 15)), (byte)r.Next(1, 61), StringGenerator(r.Next(5, 15)), new DateTime(r.Next(1990, 2012), r.Next(0, 13), r.Next(1, 29)));
                        break;
                    case 4:
                        persons[i] = new Manager(StringGenerator(r.Next(5, 15)), StringGenerator(r.Next(5, 15)), StringGenerator(r.Next(5, 15)), new DateTime(r.Next(1990, 2012), r.Next(0, 13), r.Next(1, 29)));
                        break;
                }
                persons[i].Print();
            }
        }
    }
}