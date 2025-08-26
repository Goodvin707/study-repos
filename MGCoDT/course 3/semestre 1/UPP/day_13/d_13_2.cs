/*Определить новые версии классов Article, Edition и Magazine.
В класс Article добавить реализации интерфейсов

System.IComparable для сравнения объектов типа Article по названию статьи;
System.Collections.Generic.IComparer<Article> для сравнения объектов типа Article по фамилии автора.
Определить вспомогательный класс, реализующий интерфейс System.Collections.Generic.IComparer<Article>, который можно использовать для сравнения объектов типа Article по рейтингу статьи.
В новой версии класса Magazine использовать типы 

System.Collections.Generic.List<Person>  для списка редакторов журнала;
System.Collections.Generic.List<Article> для списка статей в журнале.
В новых версиях Edition и Magazine сохранить все остальные поля, свойства и методы из предыдущей версии класса, внести необходимые исправления в код свойств и методов из-за изменения типов полей для списка редакторов журнала и списка статей.
В классе Magazine определить методы для сортировки списка статей 

по названию статьи;
по фамилии автора;
по рейтингу статьи.
Определить универсальный делегат 
 delegate TKey KeySelector<TKey>(Magazine mg);
Определить универсальный класс MagazineCollection<TKey>, содержащий коллекцию объектов типа Magazine, в котором для хранения коллекции используется  тип System.Collections.Generic.Dictionary<TKey, Magazine>. Типовой параметр TKey универсального класса MagazineCollection<TKey> определяет тип ключа в коллекции Dictionary<TKey, Magazine>. 
Метод, который используется для вычисления ключа при добавлении элемента
Magazine в коллекцию класса MagazineCollection<TKey>, отвечает делегату KeySelector<TKey> и передается MagazineCollection<TKey> через параметр единственного конструктора класса.  
Класс MagazineCollection<TKey> содержит

закрытое поле типа System.Collections.Generic.Dictionary<TKey, Magazine>;
закрытое поле типа KeySelector<TKey> для хранения экземпляра делегата с
методом, вычисляющим ключ для объекта Magazine; конструктор c одним параметром типа KeySelector<TKey> ;

метод void AddDefaults(), c помощью которого можно добавить некоторое число элементов типа Magazine для инициализации коллекции по умолчанию;
метод void AddMagazines ( params  Magazine[] )  для добавления элементов в коллекцию Dictionary<TKey, Magazine>;
перегруженную версию виртуального метода string ToString() для формирования строки, содержащей информацию обо всех элементах коллекции Dictionary<TKey, Magazine>, в том числе значения всех полей, включая список редакторов издания и список статей в журнале для каждого элемента Magazine;
метод string ToShortString(), который формирует строку с  информацией обо всех элементах коллекции Dictionary<TKey, Magazine>, содержащую  значения всех полей, значение среднего рейтинга статей, число редакторов издания и число статей в журнале для каждого элемента Magazine, но без списков редакторов и статей.
В классе MagazineCollection<TKey> определить свойства и методы, выполняющие операции со словарем Dictionary<TKey, Magazine> с использованием методов расширения класса System.Linq.Enumerable и статические методы-селекторы, которые необходимы для выполнения соответствующих операций с коллекцией:

свойство типа double (только с методом get), возвращающее максимальное значение среднего рейтинга статей для элементов коллекции; если в коллекции нет элементов, свойство возвращает некоторое значение по умолчанию; для поиска максимального значения среднего рейтинга статей надо использовать метод Max класса System.Linq.Enumerable;
метод
IEnumerable<KeyValuePair<TKey,Magazine>>FrequencyGroup(Frequency value), возвращающий подмножество элементов коллекции
Dictionary<TKey,Magazine>  с заданной периодичностью выхода журнала;  для формирования подмножества использовать метод Where класса  System.Linq.Enumerable;

свойство типа
IEnumerable<IGrouping<Frequency,KeyValuePair<TKey,Magazine >>> (только с методом get), выполняющее группировку элементов коллекции Dictionary<TKey, Magazine> в зависимости от периодичности выхода журнала с помощью метода Group класса  System.Linq.Enumerable.
В методе Main()

Создать объект Magazine и вызвать методы, выполняющие сортировку списка List<Article> статей в журнале по разным критериям, после каждой сортировки вывести данные объекта. Выполнить сортировку 
по названию статьи;
по фамилии автора;
по рейтингу статьи.
Создать объект MagazineCollection<string>. Добавить в коллекцию несколько разных элементов типа Magazine и вывести объект
MagazineCollection<string>.

Вызвать методы класса MagazineCollection<string>, выполняющие операции с коллекцией-словарем Dictionary<TKey, Magazine>, и после каждой операции вывести результат операции. Выполнить 
вычисление максимального значения среднего рейтинга статей для элементов коллекции;
вызвать метод FrequencyGroup для выбора журналов с заданной периодичностью выхода;
вызвать свойство класса, выполняющее группировку элементов коллекции по периодичности выхода; вывести все группы элементов.
Создать объект типа TestCollection<Edition, Magazine>. Ввести число элементов в коллекциях и вызвать метод для поиска первого, центрального, последнего и элемента, не входящего в коллекции. Вывести значения времени поиска для всех четырех случаев.*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _13_2
{
    class MagazineCollection<Tkey>
    {
        Tkey key;
        Dictionary<Tkey, Magazine> magazines;
        public double MaxAvgRate { get => magazines?.Max(n => n.Value.Articles[0].Rating) ?? 0; }
        public IEnumerable<Magazine> FilterByMonth
        {
            get { return from i in magazines.Values where i.Frequency == Frequency.Monthly select i; }
        }
        public MagazineCollection(Dictionary<Tkey, Magazine> magazines)
        {
            this.magazines = magazines;
        }
        public void AddDefaults()
        {
            Random r = new Random();
            int rc = r.Next(2, 6);
            for (int i = 0; i < rc; i++)
                magazines.Add(key, new Magazine());
        }
        public void AddMagazines(Magazine magazine)
        {
            magazines.Add(key, magazine);
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
                res += magazines[key].ToString();
            return res;
        }
        public string ToShortString()
        {
            string res = "";
            for (int i = 0; i < magazines.Count; i++)
                res += magazines[key].ToShortString();
            return res;
        }
        public void SortByEdition()
        {
            Console.WriteLine("Сортировка по имени");
            var sortedMagazines = from entry in magazines orderby entry.Value.Name ascending select entry;
        }
        public void SortByPublishDate()
        {
            Console.WriteLine("Сортировка по дате публикации");
            var sortedMagazines = from entry in magazines orderby entry.Value.PublishDate ascending select entry;
        }
        public void SortByEditionCount()
        {
            Console.WriteLine("Сортировка по изданию");
            var sortedMagazines = from entry in magazines orderby entry.Value.Edition ascending select entry;
        }
        delegate TKey KeySelector<TKey>(Magazine mg);
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
    class Article : IComparable<Article>, IComparer<Article>
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
        public int CompareTo(Article article)
        {
            return this.Name[0].CompareTo(article.Name[0]);
        }
        public int Compare(Article art1, Article art2)
        {
            if (art1.Author.Sname[0] > art2.Author.Sname[0])
                return 1;
            else if (art1.Author.Sname[0] < art2.Author.Sname[0])
                return -1;
            else
                return 0;
        }
    }
    class Magazine : Edition
    {
        Frequency frequency;
        List<Article> articles = new List<Article>();
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
            Dictionary<string, Magazine> magazines = new Dictionary<string, Magazine>();
            for (int i = 0; i < 5; i++)
            {
                magazines.Add(i.ToString(),new Magazine(StrGen(r.Next(5, 11)), (Frequency)r.Next(0, 3), new DateTime(r.Next(1990, 2022), r.Next(1, 13), r.Next(1, 29)), r.Next(100, 1000)));
                magazines[i.ToString()].AddArticles(new Article(StrGen(r.Next(5, 11)), r.NextDouble(), new Person()));
                Console.WriteLine(magazines[i.ToString()].ToString());
                Console.WriteLine();
            }
            Console.WriteLine();

            MagazineCollection<string> magazineCollection = new MagazineCollection<string>(magazines);
            magazineCollection.SortByPublishDate();

            Console.WriteLine();
            Console.WriteLine();

            magazineCollection.RatingGroup(5.7);
        }
    }
}
