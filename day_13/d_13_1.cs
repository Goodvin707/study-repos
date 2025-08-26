/*Определить новые версии классов Edition и Magazine.  
В новой версии класса Magazine использовать типы 

System.Collections.Generic.List<Person> для списка редакторов журнала;
System.Collections.Generic.List<Article> для списка статей в журнале.
В новых версиях классов Edition и Magazine сохранить все остальные поля, свойства и методы из предыдущей версии класса, внести необходимые исправления в код свойств и методов из-за изменения типов полей для списка редакторов и списка статей.
В класс Edition добавить реализацию 

интерфейсa System.IComparable для сравнения объектов Edition по полю с названием издания;
интерфейсa System.Collections.Generic.IComparer<Edition> для сравнения объектов Edition по дате выхода издания.
Определить вспомогательный класс, реализующий интерфейс System.Collections.Generic.IComparer<Edition>, который можно использовать для сравнения объектов типа Edition по тиражу издания.
Определить класс MagazineCollection, который содержит

закрытое поле типа System.Collections.Generic.List<Magazine>;
метод void AddDefaults (), c помощью которого в список List<Magazine> можно добавить некоторое число элементов типа Magazine для инициализации коллекции по умолчанию;
метод void AddMagazines (params  Magazine [])  для добавления элементов в список List<Magazine>;
перегруженную версию виртуального метода string ToString() для формирования строки с информацией обо всех элементах списка List<Magazine>, в том числе значения всех полей, список редакторов журнала и список статей в журнале для каждого элемента Magazine;
виртуальный метод string ToShortString(), который формирует строку с информацией обо всех элементах списка List<Magazine>, содержащую значения всех полей, средний рейтинг статей, число редакторов журнала и число статей в журнале для каждого элемента Magazine, но без списков редакторов и статей.
В классе MagazineCollection определить свойства и методы, выполняющие сортировку списка List<Magazine> 

по названию издания с использованием интерфейса IComparable, реализованного в классе Edition;
по дате выхода издания с использованием интерфейса IComparer<Edition>, реализованного в классе Edition;
по тиражу издания с использованием интерфейса IComparer<Edition>, реализованного во вспомогательном классе.
В  классе MagazineCollection определить методы, выполняющие операции со списком List<Magazine> с использованием методов расширения класса System.Linq.Enumerable и статические методы-селекторы, которые необходимы для выполнения соответствующих операций с коллекциями: ? свойство типа double (только с методом get), возвращающее максимальное значение среднего рейтинга статей для элементов списка List<Magazine>;  если в коллекции нет элементов, свойство возвращает некоторое значение по умолчанию; для поиска максимального значения среднего рейтинга статей надо использовать метод Max класса  System.Linq.Enumerable;

свойство типа IEnumerable<Magazine> (только с методом get), возвращающее подмножество элементов списка List<Magazine> с  периодичностью выхода журнала Frequency.Monthly;  для формирования подмножества использовать метод Where класса  System.Linq.Enumerable;
метод List<Magazine> RatingGroup(double value), который возвращает список, содержащий элементы Magazine из List<Magazine> со средним рейтингом статей, который больше или равен value; для формирования списка использовать методы Group и ToList класса  System.Linq.Enumerable.
Определить класс TestCollections, в котором в качестве типа TKey используется класс Edition, а в качестве типа TValue - класс Magazine. Класс содержит закрытые поля с коллекциями типов

System.Collections.Generic.List<Edition>;
System.Collections.Generic.List<string>;
System.Collections.Generic.Dictionary <Edition, Magazine>;
System.Collections.Generic.Dictionary <string, Magazine>.
В классе TestCollection определить

статический метод с одним целочисленным параметром типа int, который возвращает ссылку на объект типа Magazine и используется для автоматической генерации элементов коллекций;
конструктор c параметром типа int (число элементов в коллекциях) для автоматического создания коллекций с заданным числом элементов;
метод, который вычисляет время поиска элемента в списках List<Edition> и List<string>, время поиска элемента по ключу и время поиска элемента по значению в коллекциях-словарях Dictionary< Edition, Magazine> и Dictionary<string, Magazine>.
В методе Main()

Создать объект типа MagazineCollection. Добавить в коллекцию несколько элементов типа Magazine с разными значениями полей и вывести объект MagazineCollection.
Для созданного объекта MagazineCollection вызвать методы, выполняющие сортировку списка List<Magazine> по разным критериям, и после каждой сортировки вывести данные объекта. Выполнить сортировку 
по названию издания;
по дате выхода издания;
по тиражу издания.
Вызвать методы класса MagazineCollection, выполняющие операции со списком List<Magazine>, и после каждой операции вывести результат операции. Выполнить 
вычисление максимального значения среднего рейтинга статей для элементов списка; вывести максимальное значение;
фильтрацию списка для отбора журналов с периодичностью выхода
Frequency.Monthly, вывести результат фильтрации;

группировку элементов списка по значению среднего рейтинга статей; вывести все группы элементов.
Создать объект типа TestCollections. Вызвать метод для поиска в коллекциях первого, центрального, последнего и элемента, не входящего в коллекции. Вывести значения времени поиска для всех четырех случаев. Вывод должен содержать информацию о том, к какой коллекции и к какому элементу относится данное значение.*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _13_1
{
    class MagazineCollection
    {
        List<Magazine> magazines;
        public double MaxAvgRate { get => magazines?.Max(n => n.Articles[0].Rating) ?? 0; }
        public IEnumerable<Magazine> FilterByMonth
        {
            get { return from i in magazines where i.Frequency == Frequency.Monthly select i; }
        }
        public MagazineCollection(List<Magazine> magazines)
        {
            this.magazines = magazines;
        }
        public void AddDefaults()
        {
            Random r = new Random();
            int rc = r.Next(2, 6);
            for (int i = 0; i < rc; i++)
                magazines.Add(new Magazine());
        }
        public void AddMagazines(Magazine magazine)
        {
            magazines.Add(magazine);
        }
        public List<Magazine> RatingGroup(double value)
        {
            var magazineGroups = from magazine in magazines
                   group magazine by Frequency.Monthly;
            List<Magazine> grouped = new List<Magazine>();
            foreach (IGrouping<Frequency, Magazine> g in magazineGroups)
            {
                Console.WriteLine("Key: " + g.Key);
                foreach (var t in g)
                {
                    Console.WriteLine(t.Name);
                    grouped.Add(t);
                }
                Console.WriteLine();
            }
            return grouped;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < magazines.Count; i++)
                res += magazines[i].ToString();
            return res;
        }
        public string ToShortString()
        {
            string res = "";
            for (int i = 0; i < magazines.Count; i++)
                res += magazines[i].ToShortString();
            return res;
        }
        public void SortByEdition()
        {
            Console.WriteLine("Сортировка по имени");
            magazines.Sort(new EditionHelper());
            for (int i = 0; i < magazines.Count; i++)
                Console.WriteLine(magazines[i].ToString());
            Console.WriteLine();
        }
        public void SortByPublishDate()
        {
            Console.WriteLine("Сортировка по дате публикации");
            magazines.Sort(new Edition());
            for (int i = 0; i < magazines.Count; i++)
                Console.WriteLine(magazines[i].ToString());
            Console.WriteLine();
        }
        public void SortByEditionCount()
        {
            Console.WriteLine("Сортировка по изданию");
            magazines.Sort(new Helper());
            for (int i = 0; i < magazines.Count; i++)
                Console.WriteLine(magazines[i].ToString());
            Console.WriteLine();
        }
    }
    class Helper : IComparer<Edition>
    {
        public int Compare(Edition ed1, Edition ed2)
        {
            if (ed1.GetSetEedition == ed2.GetSetEedition)
                return 0;
            else if (ed1.GetSetEedition > ed2.GetSetEedition)
                return 1;
            else
                return -1;
        }
    }
    class TestCollections<TKey, TValue>
    {
        List<TKey> keys;
        List<string> list;
        Dictionary<TKey, TValue> valuePairs;
        Dictionary<string, TValue> keyValuePairs;
    }
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
    class EditionHelper : IComparer<Edition>
    {
        string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Compare(Edition ed1, Edition ed2)
        {
            if (ed1.Name[0] == ed2.Name[0])
                return 0;
            else if (ed1.Name[0] > ed2.Name[0])
                return 1;
            else
                return -1;
        }
    }
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
        public object DeepCopy()
        {
            return new Edition(this.name, publishDate, this.edition);
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
        public static bool operator <(Edition left, Edition right) => left.CompareTo(right) < 0;
        public static bool operator <=(Edition left, Edition right) => left.CompareTo(right) <= 0;
        public static bool operator >(Edition left, Edition right) => left.CompareTo(right) > 0;
        public static bool operator >=(Edition left, Edition right) => left.CompareTo(right) >= 0;
    }
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
    class Magazine : Edition
    {
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
            List<Magazine> magazines = new List<Magazine>();
            for (int i = 0; i < 5; i++)
            {
                magazines.Add(new Magazine(StrGen(r.Next(5, 11)), (Frequency)r.Next(0, 3), new DateTime(r.Next(1990, 2022), r.Next(1, 13), r.Next(1, 29)), r.Next(100, 1000)));
                magazines[i].AddArticles(new Article(StrGen(r.Next(5, 11)), r.NextDouble(), new Person()));
                Console.WriteLine(magazines[i].ToString());
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            MagazineCollection magazineCollection = new MagazineCollection(magazines);
            magazineCollection.SortByPublishDate();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            magazineCollection.RatingGroup(5.7);
        }
    }
}
