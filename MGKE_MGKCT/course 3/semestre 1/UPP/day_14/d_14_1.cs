/*Задание 1: 
Определить новую версию класса MagazineCollection из дня 13, которая  с помощью событий сообщает об изменениях в коллекции.
Для событий  определить делегат MagazineListHandler с сигнатурой:
void MagazineListHandler (object source, MagazineListHandlerEventArgs args);
Класс MagazineListHandlerEventArgs, производный от класса System.EventArgs, содержит
	•	открытое автореализуемое свойство типа string с названием коллекции, в которой произошло событие;
	•	открытое автореализуемое свойство типа string с информацией о типе изменений в коллекции;
	•	открытое автореализуемое свойство типа int с номером элемента, который был изменен;
	•	конструкторы для инициализации класса;
	•	перегруженную версию метода string ToString() для формирования строки с информацией обо всех полях класса.
В новую версию класса MagazineCollection добавить
	•	открытое автореализуемое свойство типа string с названием коллекции;
	•	метод bool Replace (int j, Magazine mg) для замены элемента с номером j из списка List<Magazine> на элемент mg; если в списке нет элемента с номером j, метод возвращает значение false;
	•	индексатор типа Magazine (с методами get и set) с целочисленным индексом  для доступа к элементу списка List<Magazine> с заданным номером.
В новую версию класса MagazineCollection добавить два события типа MagazineListHandler
	•	MagazineAdded, которое происходит при добавлении элемента в коллекциию; cобытие  передает через объект MagazineListHandlerEventArgs  имя коллекции, строку с информацией о том, что в коллекцию был добавлен элемент, и номер добавленного элемента в списке List<Magazine>;
	•	MagazineReplaced, которое происходит, когда одной из ссылок, входящих в коллекцию, присваивается новое значение; событие передает через объект MagazineListHandlerEventArgs  имя коллекции, строку с информацией о том, что в коллекции был заменен элемент, и номер замененного элемента.
Событие MagazineAdded бросают методы класса MagazineCollection
	•	AddDefaults();
	•	AddMagazines (params  Magazine[] ) ;
Событие MagazineReplaced бросают
	•	метод Replace (int j, Magazine mg);
	•	метод set индексатора, определенного в классе MagazineCollection.
Определить класс Listener для накопления информации об изменениях в коллекциях MagazineCollection. В классе Listener информация хранится в списке из элементов типа ListEntry, каждый элемент списка содержит информацию об отдельном изменении в коллекции MagazineCollection.
Класс ListEntry содержит
	•	открытое автореализуемое свойство типа string с названием коллекции, в которой произошло событие;
	•	открытое автореализуемое свойство типа string с информацией о том, какое событие произошло в коллекции;
	•	номер добавленного или измененного элемента;
	•	конструктор для инициализации полей класса;
	•	перегруженную версию метода string ToString().
Класс Listener содержит
	•	список изменений System.Collections.Generics.List<ListEntry>;
	•	обработчик событий MagazineAdded и MagazineReplaced, который на основе информации из объекта MagazineListHandlerEventArgs, создает элемент ListEntry и добавляет его в список изменений;
	•	перегруженную версию метода string ToString() для формирования строки с информацией обо всех элементах списка List<ListEntry>.
В методе Main()
	•	Создать две коллекции MagazineCollection.
	•	Создать два объекта типа Listener, один объект Listener подписать на события MagazineAdded и MagazineReplaced из первой коллекции MagazineCollection, другой объект Listener подписать на события MagazineAdded из обеих коллекций MagazineCollection.
	•	Внести изменения в коллекции MagazineCollection
	•	добавить элементы в коллекции;
	•	заменить некоторые элементы из коллекций с помощью метода Replасе класса MagazineCollection;
	•	присвоить некоторым элементам коллекций новые значения c помощью индексатора класса MagazineCollection.*/
	•	Вывести данные обоих объектов Listener.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace _14_1
{
    class Listener
    {
        private List<ListEntry> ListOfChanges = new List<ListEntry>();
        public void EventHandler(object o, MagazineListHandlerEventArgs args)
        {
            ListOfChanges.Add(new ListEntry(args.CollectionName, args.Changes, args.NumberOfEnement));
        }
        public override string ToString()
        {
            string str = "";
            foreach (ListEntry en in ListOfChanges)
                str += en.ToString() + "\n";
            return str;
        }
    }
    class ListEntry
    {
        public string CollectionName { get; set; }
        public string CollectionEvent { get; set; }
        public int NumberOfEl;
        public ListEntry(string Name, string Ev, int numOfEl)
        {
            CollectionName = Name;
            CollectionEvent = Ev;
            NumberOfEl = numOfEl;
        }
        public override string ToString() => string.Format($"Collection name: {CollectionName} \n Event: {CollectionEvent} \n Number of el {NumberOfEl} \n");
    }
    class MagazineListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string Changes { get; set; }
        public int NumberOfEnement { get; set; }
        public MagazineListHandlerEventArgs(string Colname, string Ch, int numOfEl)
        {
            CollectionName = Colname;
            Changes = Ch;
            NumberOfEnement = numOfEl;
        }
        public MagazineListHandlerEventArgs() : this("Some Collection", "Some changes", 0) { }
        public override string ToString() => string.Format($"Name of collection {CollectionName} \n Changes {Changes} \n Number of new element {NumberOfEnement} \n");
    }
    class MagazineCollection : IEnumerable
    {
        List<Magazine> magazines;
        public string CollectionName => magazines.ToString();
        public Magazine this[int index]
        {
            get => magazines[index];
            set => magazines[index] = value;
        }
        public MagazineCollection(List<Magazine> magazines)
        {
            this.magazines = magazines;
        }
        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);
        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;
        public double MaxAvgRate { get => magazines?.Max(n => n.Articles[0].Rating) ?? 0; }

        public void AddDefaults()
        {
            Random r = new Random();
            int rc = r.Next(2, 6);
            for (int i = 0; i < rc; i++)
                magazines.Add(new Magazine());
            MagazineAdded(magazines[magazines.Count - 1], new MagazineListHandlerEventArgs(this.CollectionName, "Last element added", magazines.Count - 1));
        }
        public void AddMagazines(params Magazine[] manyMagazines)
        {
            magazines.AddRange(manyMagazines);
            MagazineAdded(magazines[magazines.Count - 1], new MagazineListHandlerEventArgs(this.CollectionName, "Last element added", magazines.Count - 1));
        }
        public bool Replace(int j, Magazine mg)
        {
            if (magazines.Contains(magazines[j]))
            {
                magazines[j] = mg;
                MagazineReplaced(mg, new MagazineListHandlerEventArgs(CollectionName, $"{j}-й элемент изменен", magazines.Count - 1));
                return true;
            }
            else
                return false;
        }
        public List<Magazine> RatingGroup(double value)
        {
            IEnumerable<IGrouping<int, Magazine>> someGroup = magazines.GroupBy(team => team.Articles.Count);
            foreach (IGrouping<int, Magazine> teams in someGroup)
            {
                if (teams.Key == value)
                    return teams.ToList();
                else
                    throw new ArgumentNullException("There are no such number!");
            }
            return null;
        }
        public List<Magazine> RateGroup(double value)
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
        public IEnumerable<Magazine> FilterByMonth
        {
            get { return from i in magazines where i.Frequency == Frequency.Monthly select i; }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < magazines.Count; i++)
                yield return magazines[i];
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
        public override int GetHashCode() => HashCode.Combine(name, publishDate, edition, Name, PublishDate, GetSetEedition);
        public override string ToString() => $"Name = {name}\nPuplish Date = {publishDate} Edition = {edition}";
        public int CompareTo(Edition ed) => this.Name[0].CompareTo(ed.Name[0]);
        public int Compare(Edition ed1, Edition ed2) => DateTime.Compare(ed1.PublishDate, ed2.PublishDate);
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
        public void AddArticles(Article newArticles) => articles.Add(newArticles);
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
            MagazineCollection mgs1 = new MagazineCollection(magazines);
            Listener listener = new Listener();
            mgs1.MagazineAdded += listener.EventHandler;
            mgs1.MagazineReplaced += listener.EventHandler;
            for (int i = 0; i < 5; i++)
            {
                mgs1.AddMagazines(new Magazine(StrGen(r.Next(5, 11)), (Frequency)r.Next(0, 3), new DateTime(r.Next(1990, 2022), r.Next(1, 13), r.Next(1, 29)), r.Next(100, 1000)));
                magazines[i].AddArticles(new Article(StrGen(r.Next(5, 11)), r.NextDouble(), new Person()));
                Console.WriteLine(magazines[i].ToString());
                Console.WriteLine();
            }
            mgs1.Replace(1, new Magazine());
            mgs1[0] = new Magazine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(listener.ToString());
        }
    }
}
