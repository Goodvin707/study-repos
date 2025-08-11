// Задание 2: Полученные данные предыдущего задания упорядочить: для символьных данных – по алфавиту (выбрав нужное поле), для числовых данных – по возрастанию (убыванию).
using System;

namespace ConsoleApp2
{
    class Program
    {
        enum Marks
        {
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten
        }
        struct Student
        {
            private string fio;
            public string FIO
            {
                get { return fio; }
                set { fio = value; }
            }
            private int year;
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            private string group;
            public string Group
            {
                get { return group; }
                set { group = value; }
            }
            private int phizics;
            public int Phizics
            {
                get { return phizics; }
                set { phizics = value; }
            }
            private int math;
            public int Math
            {
                get { return math; }
                set { math = value; }
            }
            private int computerScience;
            public int ComputerScience
            {
                get { return computerScience; }
                set { computerScience = value; }
            }
            private int chemistry;
            public int Chemistry
            {
                get { return chemistry; }
                set { chemistry = value; }
            }
            private double averMark;
            public double AverMark
            {
                get { return averMark; }
                set { averMark = value; }
            }
            public Student(string fio, int year, string group, int phizics, int math, int computerScience, int chemistry)
            {
                this.fio = fio;
                this.year = year;
                this.group = group;
                this.phizics = phizics;
                this.math = math;
                this.computerScience = computerScience;
                this.chemistry = chemistry;
                averMark = (phizics + math + computerScience + chemistry) / 4;
            }
            static void Grades(Marks m)
            {
                switch (m)
                {
                    case Marks.Zero:
                        break;
                    case Marks.One:
                        break;
                    case Marks.Two:
                        break;
                    case Marks.Three:
                        break;
                    case Marks.Four:
                        break;
                    case Marks.Five:
                        break;
                    case Marks.Six:
                        break;
                    case Marks.Seven:
                        break;
                    case Marks.Eight:
                        break;
                    case Marks.Nine:
                        break;
                    case Marks.Ten:
                        break;
                    default:
                        break;
                }
            }
            interface IComparer
            {
                int Compare(object o1, object o2);
            }
            struct PeopleComparer : IComparer
            {
                public int Compare(Student p1, Student p2)
                {
                    if (p1.FIO.Length > p2.FIO.Length)
                        return 1;
                    else if (p1.FIO.Length < p2.FIO.Length)
                        return -1;
                    else
                        return 0;
                }
                public int Compare(object o1, object o2)
                {
                    throw new NotImplementedException();
                }
            }
            public void PrintAll()
            {
                Console.WriteLine("ФИО: " + FIO);
                Console.WriteLine("Год рождения" + Year);
                Console.WriteLine("Группа" + Group);
                Console.WriteLine("Оценки");
                Console.WriteLine("Физика: " + phizics + "\t" + "Математика: " + math);
                Console.WriteLine("Информатика: " + computerScience + "\t" + "Химия: " + chemistry);
                Console.WriteLine("Средний балл: " + averMark);
            }
        }
        static void Main()
        {
            string fio, group;
            int year;
            int Phizics, Math, ComputerScience, Chemistry;
            Console.Write("Укажите кол-во студентов: ");
            int n = int.Parse(Console.ReadLine());
            Student[] stud = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите фамилию и инициалы: ");
                fio = Console.ReadLine();
                Console.Write("Введите год рождения: ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Введите номер группы: ");
                group = Console.ReadLine();
                Console.WriteLine("Введите оценки за семестр");
                Console.Write("Физика: ");
                Phizics = int.Parse(Console.ReadLine());
                Console.Write("Математика: ");
                Math = int.Parse(Console.ReadLine());
                Console.Write("Информатика: ");
                ComputerScience = int.Parse(Console.ReadLine());
                Console.Write("Химия: ");
                Chemistry = int.Parse(Console.ReadLine());
                stud[i] = new Student(fio, year, group, Phizics, Math, ComputerScience, Chemistry);
            }
            Console.Write("Введите интересующую вас группу: ");
            group = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                if (stud[i].Group == group)
                {
                    if (stud[i].Phizics == (int)Marks.Three || stud[i].Phizics == (int) Marks.Four ||
                        stud[i].Math == (int)Marks.Three || stud[i].Math == (int)Marks.Four ||
                        stud[i].ComputerScience == (int)Marks.Three || stud[i].ComputerScience == (int)Marks.Four ||
                        stud[i].Chemistry == (int)Marks.Three || stud[i].Chemistry == (int)Marks.Four)
                        stud[i].PrintAll();
                }
            }
            Array.Sort(stud, new PeopleComparer());
            foreach (Student p in stud)
            {
                Console.WriteLine($"{p.FIO} - {p.Year}");
            }
        }
    }
}