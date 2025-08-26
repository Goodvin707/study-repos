/*Задание 2: Определить новые версии классов Edition, Magazine и MagazineCollection<TKey> из дня 13.
Новая версия класса Edition реализует интерфейс System.ComponentModel.INotifyPropertyChanged. Событие PropertyChanged из интерфейса System.ComponentModel.INotifyPropertyChanged происходит при изменении значений свойств класса Edition, связанных с тиражом и датой выхода издания. Название свойства, значение которого изменилось, событие PropertyChanged передает своим обработчикам через свойство PropertyName класса PropertyChangedEventArgs.
Для информации о типе изменений, которые произошли в коллекциях, определить перечисление (enum) Update со значениями Add, Replace и Property.
Для события, которое бросают методы новой версии класса MagazineCollection<TKey>, определить универсальный делегат MagazinesChangedHandler<TKey>  с сигнатурой:
void MagazinesChangedHandler<TKey> (object source, MagazinesChangedEventArgs<TKey> args);
Класс MagazinesChangedEventArgs<TKey>, производный от класса System.EventArgs, содержит
	•	открытое автореализуемое свойство типа string с названием коллекции;
	•	открытое автореализуемое свойство типа Update с информацией о том, чем вызвано событие,  – добавлением нового элемента в коллекцию, заменой элемента в коллекции или изменением данных элемента;
	•	открытое автореализуемое свойство типа string с названием свойства класса Magazine, которое является источником изменения данных элемента; для событий, порожденных добавлением или заменой элемента, значение свойства – пустая строка;
	•	открытое автореализуемое свойство типа TKey с ключом элемента, который был добавлен в коллекцию, заменил один из элементов коллекции  или элемента, у которого были изменены данные;
	•	конструктор c параметрами типа string, Update, string и TKey для инициализации значений всех свойств класса;
	•	перегруженную версию метода string ToString().
В новую версию класса MagazineCollection<TKey> добавить
	•	открытое автореализуемое свойство типа string с названием коллекции;
	•	метод bool Replace(Magazine mold, Magazine mnew) для замены в словаре Dictionary<TKey, Magazine> элемента со значением mold на элемент со значением  mnew; если в словаре нет элемента со значением mold, метод возвращает значение false;
	•	событие MagazinesChanged типа MagazinesChangedHandler<TKey>, которое происходит при добавлении нового элемента в коллекцию, замене элемента в коллекции или при изменении данных одного из ее элементов.
Определить класс Listener, собирающий информацию об изменениях в классе MagazineCollection<TKey>. Класс Listener содержит список из элементов типа ListEntry. Каждый элемент ListEntry содержит информацию об отдельном изменении объекта MagazineCollection<TKey>, в результате которого произошло событие MagazinesChanged.
Класс ListEntry содержит автореализуемые свойства
	•	типа string с названием коллекции;
	•	типа Update c информацией о типе события;
	•	типа string с названием свойства класса Magazine, которое явилось причиной изменения данных элемента;
	•	типа string с текстовым представлением ключа добавленного, удаленного или измененного элемента;
	•	конструктор для инициализации всех свойств класса;
	•	перегруженную версию метода string ToString().
Класс Listener содержит
	•	закрытое поле типа System.Collections.Generics.List<ListEntry>;
	•	обработчик события MagazinesChanged, который на основе информации из объекта MagazinesChangedEventArgs, создает элемент ListEntry и добавляет его к списку;
	•	перегруженную версию метода string ToString() для формирования строки с информацией обо всех элементах списка List<ListEntry>.
В методе Main()
	•	Создать два объекта MagazineCollection<string> с разными названиями.
	•	Создать объект типа Listener и подписать его на события MagazinesChanged из обоих объектов MagazineCollection<string>.
	•	Внести изменения в MagazineCollection<string>:
	•	добавить элементы в коллекции;
	•	изменить значения разных свойств элементов, входящих в коллекцию;
	•	заменить один из элементов коллекции;
	•	изменить данные в элементе, который был удален из коллекции при замене элемента.
	•	Вывести данные объекта Listener.*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace _14_2
{
    class Listener
    {
        private List<ListEntry> ListOfChanges = new List<ListEntry>();
        public void EventHandler<TKey>(object o, MagazineListHandlerEventArgs<TKey> args)
        {
            ListOfChanges.Add(new ListEntry(args.CollectionName, args.UpdateType, args.Changes, args.NumberOfEnement));
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
        public Update UpdateType { get; set; }
        public string CollectionEvent { get; set; }
        public int NumberOfEl;
        public ListEntry(string Name, Update update, string Ev, int numOfEl)
        {
            CollectionName = Name;
            UpdateType = update;
            CollectionEvent = Ev;
            NumberOfEl = numOfEl;
        }
        public override string ToString() => string.Format($"Collection name: {CollectionName}\nUpdate Type {UpdateType}\n Event: {CollectionEvent}\n Number of el {NumberOfEl}\n");
    }
    class MagazineListHandlerEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }
        public Update UpdateType { get; set; }
        public string Changes { get; set; }
        public int NumberOfEnement { get; set; }
        public MagazineListHandlerEventArgs(string Colname, Update update, string Ch, int numOfEl)
        {
            CollectionName = Colname;
            UpdateType = update;
            Changes = Ch;
            NumberOfEnement = numOfEl;
        }
        public MagazineListHandlerEventArgs() : this("Some Collection", 0, "Some changes", 0) { }
        public override string ToString() => string.Format($"Name of collection {CollectionName}\nUpdate Type {UpdateType}\n Changes {Changes}\n Number of new element {NumberOfEnement}\n");
    }
    class MagazineCollection<TKey>
    {
        TKey key;
        Dictionary<TKey, Magazine> magazines;
        public string CollectionName { get; set; }
        public delegate void MagazinesChangedHandler<Tkey>(object source, MagazineListHandlerEventArgs<TKey> args);
        public event MagazinesChangedHandler<TKey> MagazinesAdded;
        public event MagazinesChangedHandler<TKey> MagazinesChanged;
        public double MaxAvgRate { get => magazines?.Max(n => n.Value.Articles[0].Rating) ?? 0; }
        public IEnumerable<Magazine> FilterByMonth
        {
            get { return from i in magazines.Values where i.Frequency == Frequency.Monthly select i; }
        }
        public MagazineCollection(Dictionary<TKey, Magazine> magazines)
        {
            CollectionName = magazines.ToString();
            this.magazines = magazines;
        }
        public void AddDefaults()
        {
            Random r = new Random();
            int rc = r.Next(2, 6);
            for (int i = 0; i < rc; i++)
                magazines.Add(key, new Magazine());
            MagazinesAdded(this, new MagazineListHandlerEventArgs<TKey>(CollectionName, Update.Add, $"new element was added", magazines.Count - 1));
        }
        public void AddMagazines(Magazine magazine)
        {
            magazines.Add(key, magazine);
            MagazinesAdded(this, new MagazineListHandlerEventArgs<TKey>(CollectionName, Update.Add, $"new element was added", magazines.Count - 1));
        }
        public bool Replace(Magazine mold, Magazine mnew)
        {
            magazines = new Dictionary<TKey, Magazine>();

            if (magazines.ContainsValue(mold))
            {
                mold = mnew;
                MagazinesChanged(this, new MagazineListHandlerEventArgs<TKey>(CollectionName, Update.Replace, $"{mold} was replaced on {mnew}", 2));
                return true;
            }
            else
            {
                return false;
            }
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
            if (ed1.GetSetEdition == ed2.GetSetEdition)
                return 0;
            else if (ed1.GetSetEdition > ed2.GetSetEdition)
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
    enum Update { Add, Replace, Property }
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
    class Edition : IComparable<Edition>, IComparer<Edition>, INotifyPropertyChanged
    {
        protected string name;
        protected DateTime publishDate;
        protected int edition;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public DateTime PublishDate
        {
            get => publishDate;
            set
            {
                publishDate = value;
                OnPropertyChanged(PublishDate.ToString());
            }
        }
        public int GetSetEdition
        {
            get { return edition; }
            set
            {
                try
                {
                    if (value <= 0)
                        throw new Exception("Допустимы только положительные значения");
                    edition = value;
                    OnPropertyChanged(GetSetEdition.ToString());
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
            MagazineCollection<string> magazineCollection = new MagazineCollection<string>(new Dictionary<string, Magazine>());
            for (int i = 0; i < 5; i++)
            {
                magazineCollection.AddMagazines(new Magazine(StrGen(r.Next(5, 11)), (Frequency)r.Next(0, 3), new DateTime(r.Next(1990, 2022), r.Next(1, 13), r.Next(1, 29)), r.Next(100, 1000)));
                // magazineCollection.AddArticles(new Article(StrGen(r.Next(5, 11)), r.NextDouble(), new Person()));
            }
            Console.WriteLine(magazineCollection.ToString());
        }
    }
}
