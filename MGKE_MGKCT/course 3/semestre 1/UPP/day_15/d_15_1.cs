/*Задание 1: 
Определить новые версии классов Student (вариант 1), Magazine (вариант 2) и ResearchTeam (вариант 3), разработанные в предыдущих днях. В сформулированных ниже требованиях для этих классов использовано общее обозначение T.
В новые версии классов добавить экземплярные методы:
	•	T DeepCopy() для создания полной копии объекта с использованием сериализации;
	•	bool Save(string filename) для сохранения данных объекта в файле с помощью сериализации;
	•	bool Load(string filename) для инициализации объекта данными из файла с помощью десериализации;
	•	bool AddFromConsole() для добавления в один из списков класса нового элемента, данные для которого вводятся с консоли;
и статические методы:
	•	static bool Save(string filename, T obj) для сохранения объекта в файле с помощью сериализации;
	•	static bool Load(string filename, T obj) для восстановления объекта из файла с помощью десериализации.
В экземплярном методе T DeepCopy() вызывающий объект сериализуется в поток MemoryStream. Метод возвращает восстановленный при десериализации объект, который представляет собой полную копию исходного объекта.
Экземплярный  метод bool Save(string filename) сериализует все данные вызывающего объекта в файл с именем filename. Если файл с именем filename существует, приложение его перезаписывает. Если такого файла нет, приложение его создает. Метод возвращает значение true, если сериализация завершилась успешно, и значение false в противном случае.
Экземплярный  метод bool Load(string filename) десериализует данные из файла с именем filename и использует их для инициализации вызывающего объекта. Метод возвращает значение true, если инициализация завершилась успешно. Если полностью выполнить инициализацию объекта не удалось, исходные данные объекта должны остаться без изменения.  В этом случае метод  возвращает значение false.
Статические методы bool Save(string filename, T obj) и bool Load(string filename, T obj) получают через параметры имя файла и ссылку на объект, для которого выполняется сериализация или восстановление. Методы возвращают значение true, если сериализация/инициализация завершилась успешно, и значение false в противном случае. Если полностью выполнить инициализацию объекта не удалось, исходные данные объекта должны остаться без изменения.
Во всех реализациях методов сохранения/восстановления данных из файла операции открытия файла, сериализации и десериализации данных должны находиться в блоках try-catch-finally.
В методе bool AddFromConsole() для добавления нового элемента в один из списков класса T
	•	пользователь получает приглашение ввести данные в виде одной строки символов с разделителями; приглашение содержит описание формата строки ввода, в том числе информацию о том, какие символы можно использовать в качестве разделителей;
	•	выполняется разбор данных; операции преобразования данных, которые могут бросить исключение, должны находиться в блоке try-catch;
	•	если разбор введенных данных был завершен успешно, в список добавляется новый элемент и метод возвращает значение true; в противном случае пользователь получает сообщение о том, что при вводе были допущены ошибки и возвращаемое значение метода равно false.
В варианте 1 элементы, данные для которых вводятся с консоли, добавляются в список экзаменов System.Collections.Generic.List<Exam>. Вводятся название предмета, оценка и  дата экзамена.
В варианте 2 элементы добавляются в список статей в журнале System.Collections.Generic.List<Article>. Вводятся название статьи, данные автора статьи для объекта типа Person и рейтинг статьи.
В варианте 3 элементы добавляются в список публикаций System.Collections.Generic.List<Paper>. Вводятся название публикации, данные автора статьи для объекта типа Person и дата публикации.
В методе Main()
	•	Создать объект типа T с непустым списком элементов, для которого предусмотрен ввод данных с консоли. Создать полную копию объекта с помощью метода, использующего сериализацию, и вывести исходный объект и его копию.
	•	Предложить пользователю ввести имя файла:
	•	если файла с введенным именем нет, приложение должно сообщить об этом и создать файл;
	•	если файл существует, вызвать метод  Load(string filename)  для инициализации объекта T данными из файла.
	•	Вывести объект T.
	•	Для этого же объекта T сначала вызвать метод AddFromConsole(), затем метод Save(string filename). Вывести объект T.
	•	Вызвать последовательно
	•	статический метод Load( string filename, T obj), передав как параметры ссылку на тот же самый объект T и введенное ранее имя файла;
	•	метод AddFromConsole();
	•	статический метод Save (string filename, T obj).
	•	 Вывести объект T.*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
namespace _15_1
{
    class Person
    {
        string fname;
        string sname;
        DateTime birthDate;
        public string Fname { get { return fname; } }
        public string Sname { get { return sname; } }
        public DateTime BirthDate { get { return birthDate; } }
        public int Year { get { return birthDate.Year; } set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); } }
        public Person()
        {
            this.fname = "Иван";
            this.sname = "Иванов";
            this.birthDate = new DateTime(1996, 11, 10);
        }
        public Person(string fname, string sname, DateTime birthDate)
        {
            this.fname = fname;
            this.sname = sname;
            this.birthDate = birthDate;
        }
        public override string ToString()
        {
            return fname.ToString() + " " + sname.ToString() + " " + birthDate.ToString();
        }
        public string ToShortString()
        {
            return fname.ToString() + " " + sname.ToString();
        }
    }
    enum Frequency { Weekly, Monthly, Yearly }
    class Article
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public Person Author { get; set; }
        public Article() : this("Без названия", 0, new Person("Нет автора", "s", new DateTime())) { }
        public Article(string name, double rating, Person author)
        {
            Name = name;
            Rating = rating;
            Author = author;
        }
        public override string ToString() => $"{Name} с рейтингом {Rating} от {Author.ToString()}";
    }

    [Serializable]
    class Edition : IComparable<Edition>, IComparer<Edition>
    {
        protected string name;
        protected DateTime publishDate;
        protected int edition;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public DateTime PublishDate
        {
            get => publishDate;
            set => publishDate = value;
        }
        public int GetSetEedition
        {
            get { return edition; }
            set
            {
                try
                {
                    if (value <= 0)
                        throw new Exception("Допустимы только положительные значения");
                    edition = value;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public Edition()
        {
            this.name = "Ну тип издание";
            this.publishDate = DateTime.Today;
            this.edition = 1;
        }
        public Edition(string name, DateTime publishDate, int edition)
        {
            this.name = name;
            this.publishDate = publishDate;
            this.edition = edition;
        }
        public override bool Equals(object obj)
        {
            Edition pers = (Edition)obj;
            if (this.name == pers.name)
                if (this.publishDate == pers.publishDate)
                    if (this.edition == pers.edition)
                        return true;
            return false;
        }
        public override int GetHashCode()
        {
            int unitCode;
            if (name == "Нет издания")
                unitCode = 1;
            else unitCode = 2;
            return edition + unitCode;
        }
        public override string ToString()
        {
            return $"Name = {name}\nPuplish Date = {publishDate} Edition = {edition}";
        }
        public int CompareTo(Edition ed)
        {
            return this.Name[0].CompareTo(ed.Name[0]);
        }
        public int Compare(Edition ed1, Edition ed2)
        {
            return DateTime.Compare(ed1.PublishDate, ed2.PublishDate);
        }
    }

    [Serializable]
    class Magazine : Edition
    {
        public Magazine DeepCopy()
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, this);
            return bf.Deserialize(ms) as Magazine;
        }
        public bool Save(string filename)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(filename, json);
            return true;
        }

        public bool Load(string filename)
        {
            string json = File.ReadAllText(filename);
            Edition edition  = JsonSerializer.Deserialize<Edition>(json);
            Console.WriteLine(edition.ToString());
            return true;
        }
        public bool AddFromConsole()
        {
            string text;
            int count = 0;
            string part = "", one = "", two = "", three = "";
            Magazine res = new Magazine();
            Console.WriteLine("Input: Surname, Name, Patronymic, Age, Education, Number Of Group, Exams(data(dd.mm.yyyy)|name of exam|value)");
            Console.Write("Input: ");
            text = Console.ReadLine();
            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i] == ' ')
                    continue;
                else if (text[i] != ',')
                    part = part + text[i];
                else
                {
                    if (count == 0)
                    {
                        res.name = part;
                        count++;
                    }
                    else if (count == 1)
                    {
                        if (!int.TryParse(part, out res.edition))
                            return false;
                        else count++;
                    }
                    else if (count == 2)
                    {
                        if (part == "weekly")
                            res.frequency = Frequency.Weekly;
                        else if
                            (part == "yearly")
                            res.frequency = Frequency.Yearly;
                        else return false;
                        count++;
                    }
                    else
                    {
                        for (int flag = 0; i < part.Length; ++i)
                        {
                            if (char.IsLetterOrDigit(part[i]))
                            {
                                if (flag == 0) one += part[i];
                                else if (flag == 1) two += part[i];
                                else three += part[i];
                            }
                            else flag++;
                        }
                    }
                    part = "";
                }
            }
            name = res.Name;
            publishDate = res.PublishDate;
            edition = res.Edition;
            frequency = res.Frequency;
            articles = res.Articles;
            editors = res.editors;
            return true;
        }
        Frequency frequency;
        List<Article> articles = new List<Article>();
        List<Person> editors = new List<Person>();
        public Frequency Frequency
        {
            get => frequency;
            set => frequency = value;
        }
        public int Edition
        {
            get => edition;
            set => edition = value;
        }
        public List<Article> Articles
        {
            get => articles;
            set => articles = value;
        }
        public bool this[Frequency frequency]
        {
            get => Frequency == frequency;
        }
        public double GetAvgRating() => articles?.Average(x => x.Rating) ?? 0;
        public Magazine() { }
        public Magazine(string name, Frequency frequency, DateTime publishDate, int edition)
        {
            this.name = name;
            this.frequency = frequency;
            this.publishDate = publishDate;
            this.edition = edition;
        }
        public void AddArticles(Article newArticles)
        {
            articles.Add(newArticles);
        }
        public override string ToString()
            => $"Name = {Name}"
            + $"\nFrequency = {Frequency}"
            + $"\nPublishDate = {PublishDate}"
            + $"\nEdition = {Edition}"
            + $"\nArticles:\n {string.Join("\n ", Articles)}";

        public virtual string ToShortString()
            => $"Name = {Name}"
            + $"\nFrequency = {Frequency}"
            + $"\nPublishDate = {PublishDate}"
            + $"\nEdition = {Edition}";
    }
    class Program
    {
        static string StrGen(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
                s += Convert.ToChar(r.Next(65, 91));
            return s;
        }
        static void Main()
        {
            Random r = new Random();
            Magazine magazine = new Magazine();
            magazine.Save("output.dat");
            magazine.Load("output.dat");
        }
    }
}
