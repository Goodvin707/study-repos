/*Задание 2: В классе Person из задания 12.1 и в классах, дополнительно указанных в  вариантах,  надо 
	•	переопределить (override) виртуальный метод bool Equals (object obj);
	•	определить операции  ==  и  != ;
	•	переопределить виртуальный метод int GetHashCode();
Реализация виртуального метода bool Equals (object obj) в классе System.Object определяет равенство объектов как равенство ссылок на объекты. Некоторые классы из базовой библиотеки BCL переопределяют метод Equals(). В классе System.String этот метод переопределен так, что равными считаются строки, которые совпадают посимвольно. Реализация метода Equals() в структурном типе DateTime равенство объектов DateTime определяет как равенство значений. 
В лабораторной работе требуется переопределить метод Equals так, чтобы объекты  считались равными, если равны все данные объектов. Для класса Person это означает, что равны даты рождения и посимвольно совпадают строки с именем и фамилией.  
Определение операций == и != должно быть согласовано с переопределенным методом Equals, т.е. критерии, по которым проверяется равенство объектов в методе Equals, должны использоваться и при проверке равенства объектов в операциях == и !=. 
Переопределение виртуального метода int GetHashCode() также должно быть согласовано с операциями == и !=. Виртуальный метод  GetHashCode() используется некоторыми классами базовой библиотеки, например, коллекциями-словарями. Классы базовой библиотеки, вызывающие метод GetHashCode() из пользовательского типа, предполагают, что равным объектам отвечают равные значения хэш-кодов. Поэтому в случае, когда под равенством объектов понимается совпадение данных (а не ссылок), реализация метода GetHashCode() должна для объектов с совпадающими данными возвращать  равные значения хэш-кодов.
В классах, указанных в вариантах лабораторной работы, требуется определить метод object DeepCopy() для создания полной копии объекта. Определенные в некоторых классах базовой библиотеки методы Clone() и Copy() создают ограниченную (shallow) копию объекта – при копировании объекта копии создаются только для полей структурных типов, для полей ссылочных типов копируются только ссылки. В результате в ограниченной копии объекта поля-ссылки указывают на те же объекты, что и в исходном объекте. 
Метод DeepCopy() должен создать полные копии всех объектов, ссылки на которые содержат поля типа.  После создания полная копия не зависит от исходного объекта - изменение любого поля или свойства исходного объекта не должно приводить к изменению копии.
При реализации метода DeepCopy() в классе, который имеет поле типа System.Collections.ArrayList, следует иметь в виду, что определенные в классе ArrayList конструктор ArrayList(ICollection) и метод Clone() при создании копии коллекции, состоящей из элементов ссылочных типов, копируют только ссылки.
Метод DeepCopy() должен создать как копии элементов коллекции ArrayList, так и полные копии объектов, на которые ссылаются элементы коллекции.  Для типов, содержащих коллекции, реализация метода DeepCopy() упрощается, если в типах элементов коллекций также определить метод DeepCopy(). 
Определить интерфейс 
 
interface IRateAndCopy     { double Rating { get;} object DeepCopy();
    }
Определить новые версии классов Person, Article и Magazine из лабораторной работы 1. Класс Magazine определить как производный от класса Edition. В классы Article и Magazine добавить реализацию интерфейса IRateAndCopy.
В новой версии класса Person дополнительно
	•	переопределить метод virtial bool Equals (object obj) и определить операции == и != так, чтобы равенство объектов типа Person трактовалось как совпадение всех данных объектов, а не ссылок на объекты Person; 
	•	переопределить виртуальный метод int GetHashCode();
	•	определить виртуальный метод object DeepCopy().
В новой версии класса Article дополнительно
	•	определить виртуальный метод object DeepCopy();
	•	реализовать интерфейс IRateAndCopy.
Определить класс Edition. Класс Edition имеет 
	•	защищенное(protected) поле типа string c названием издания;
	•	защищенное поле типа DateTime c датой выхода издания;
	•	защищенное поле типа int с тиражом издания;
В классе Edition определить:
	•	конструктор с параметрами типа string, DateTime, int для инициализации соответствующих полей класса; 
	•	конструктор без параметров для инициализации по умолчанию;
	•	свойства c методами get и set для доступа к полям типа;
	•	виртуальный метод object DeepCopy();
	•	свойство типа int с методами get и set для доступа к полю с тиражом издания; в методе set свойства бросить исключение, если присваиваемое значение отрицательно. При создании объекта-исключения использовать один из определенных в библиотеке CLR классов-исключений, инициализировать объект-исключение с помощью конструктора с параметром типа string, в сообщении передать информацию о допустимых значениях свойства.
В классе Edition переопределить (override):
	•	виртуальный метод virtial bool Equals (object obj) и определить операции == и != так, чтобы равенство объектов типа Edition трактовалось как совпадение всех данных объектов, а не ссылок на объекты Edition; 
	•	виртуальный метод int GetHashCode();
	•	перегруженную версию виртуального метода string ToString() для
формирования строки со значениями всех полей класса.
Новая версия класса Magazine имеет базовый класс Edition и следующие поля:
	•	закрытое поле типа Frequency с информацией о периодичности выхода журнала;
	•	закрытое поле типа System.Collections.ArrayList со списком редакторов журнала (объектов типа Person). 
	•	закрытое поле типа System.Collections.ArrayList, в котором хранится список статей в журнале (объектов типа Article).
Код следующих конструкторов, методов и свойств из старой версии класса Magazine необходимо изменить с учетом того, что часть полей класса перемещена в базовый класс Edition, и в новой версии класса Magazine для списка статей используется тип System.Collections.ArrayList:
	•	конструктор с параметрами типа string, Frequency, DateTime, int для инициализации соответствующих полей класса; 
	•	конструктор без параметров для инициализации по умолчанию;
	•	свойство типа double (только с методом get), в котором вычисляется среднее значение рейтинга статей в журнале;
	•	свойство типа System.Collections.ArrayList для доступа к полю со списком статей в журнале;
	•	метод  void AddArticles (params Article[]) для добавления элементов в список статей в журнале;
	•	перегруженная версия виртуального метода string ToString() для формирования строки со значениями всех полей класса, включая список статей и список редакторов;
	•	виртуальный метод string ToShortString(), который формирует строку со значениями всех полей класса без списка статей и списка редакторов, но со значением среднего рейтинга статей в журнале.
Дополнительно в новой версии класса Magazine реализовать
	•	свойство типа System.Collections.ArrayList  для доступа к списку редакторов журнала;
	•	метод  void AddEditors (params Person[]) для добавления элементов в список редакторов;
	•	перегруженную (override) версию виртуального метода object DeepCopy();
	•	интерфейс IRateAndCopy;
	•	свойство типа Edition; метод  get свойства возвращает объект типа Edition, данные которого совпадают с данными подобъекта базового класса, метод set присваивает значения полям из подобъекта базового класса. 
В новой версии класса Magazine определить
	•	итератор с параметром типа double для перебора статей с рейтингом  больше некоторого заданного значения; 
	•	итератор с параметром типа string для перебора статей, в названии которых есть заданная строка. 
В методе Main()
	•	Создать два объекта типа Edition с совпадающими данными и проверить, что ссылки на объекты не равны, а объекты равны, вывести значения хэшкодов для объектов.
	•	В блоке try/catch присвоить свойству с тиражом издания некорректное значение, в обработчике исключения вывести сообщение, переданное через объект-исключение. 
	•	Создать объект типа Magazine, добавить элементы в списки статей и редакторов журнала и вывести данные объекта Magazine. 
	•	Вывести значение свойства типа Edition для объекта типа Magazine.
	•	С помощью метода DeepCopy() создать полную копию объекта Magazine. Изменить данные в исходном объекте Magazine и вывести копию и исходный объект, полная копия исходного объекта должна остаться без изменений.
	•	С помощью оператора foreach для итератора с параметром типа double вывести список всех статей с рейтингом  больше некоторого заданного значения. 
	•	С помощью оператора foreach для итератора с параметром типа string вывести список статей, в названии которых есть заданная строка. 
Дополнительное задание:
В классе Magazine  
	•	реализовать интерфейс System.Collections.IEnumerable для перебора статей (объектов типа Article), авторы которых не входят в список редакторов журнала; для этого определить вспомогательный класс MagazineEnumerator, реализующий интерфейс System.Collections.IEnumerator.
	•	определить итератор для перебора статей (объектов типа Article), авторы которых являются редакторами журнала, для этого определить метод, содержащий блок итератора и использующий оператор yield. 
определить итератор для перебора редакторов журнала (объектов типа Person), у которых нет статей в журнале, для этого определить метод, содержащий блок итератора и использующий оператор yield. 
В методе Main()
	•	С помощью оператора foreach для объекта типа Magazine вывести список статей, авторы которых не являются редакторами журнала.
	•	С помощью оператора foreach для итератора, определенного в классе Magazine, вывести список статей, авторы которых являются редакторами журнала.
	•	С помощью оператора foreach для итератора, определенного в классе Magazine, вывести список редакторов, у которых нет статей в журнале.*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12_2
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
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
        public override bool Equals(object obj)
        {
            Person pers = (Person)obj;
            if (this.birthDate ==  pers.birthDate)
                if (this.sname == pers.sname)
                    if (this.fname == pers.fname)
                        return true;
            return false;
        }
        public override int GetHashCode()
        {
            int unitCode;
            if (fname == "Нет автора")
                unitCode = 1;
            else unitCode = 2;
            return birthDate.Year + unitCode;
        }
        public object DeepCopy()
        {
            return new Person(this.fname, this.sname, this.birthDate);
        }
        public static bool operator ==(Person person1, Person person2)
        {
            if (person1.Equals(person2))
                return true;
            return false;
        }
        public static bool operator !=(Person person1, Person person2)
        {
            if (!person1.Equals(person2))
                return true;
            return false;
        }
    }
    enum Frequency { Weekly, Monthly, Yearly }
    class Article : IRateAndCopy
    {
        public string Name { get; set; }
        public double Rating { get;  }
        public Person Author { get; set; }
        public Article() : this("Без названия", 0, new Person("Нет автора", "s", new DateTime())) { }
        public Article(string name, double rating, Person author)
        {
            Name = name;
            Rating = rating;
            Author = author;
        }
        public override string ToString() => $"{Name} с рейтингом {Rating} от {Author.ToString()}";
        public object DeepCopy()
        {
            return new Article(this.Name, this.Rating, this.Author);
        }
    }
    class Edition
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
        public int Eedition
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
        public Edition (string name, DateTime publishDate, int edition)
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
    }
    class Magazine : Edition, IRateAndCopy
    {
        Frequency frequency;
        ArrayList articles = new ArrayList();
        Person[] editors;
        public Frequency Frequency
        {
            get => frequency;
            set => frequency = value;
        }
        public ArrayList Articles
        {
            get => articles;
            set => articles = value;
        }
        public double Rating { get; }
        public bool this[Frequency frequency] { get => Frequency == frequency; }
        public Magazine() { }
        public Magazine(string name, Frequency frequency, DateTime publishDate, int edition)
        {
            this.name = name;
            this.frequency = frequency;
            this.publishDate = publishDate;
            this.edition = edition;
        }
        public void AddArticles(params Article[] newArticles)
        {
            articles.Add(newArticles);
        }
        public override string ToString()
        {
            string ret = $"Name = {Name}\nFrequency = {Frequency}\nPublishDate = {PublishDate}\nEdition = {Eedition}";
            for (int i = 0; i < articles.Count; i++)
                ret += $"\n{articles[i]}";
            return ret;
        }
        public virtual string ToShortString()
            => $"Name = {Name}"
            + $"\nFrequency = {Frequency}"
            + $"\nPublishDate = {PublishDate}"
            + $"\nEdition = {Eedition}";
        public new object DeepCopy()
        {
            return new Magazine(this.name, this.frequency, publishDate, this.edition);
        }
    }
    static class Program
    {
        public static IEnumerable<Article> ByRating(this IEnumerable<Article> List, double Rating)
        {
            foreach (var a in List)
            {
                if (a.Rating >= Rating)
                    yield return a;
            }
        }
        public static IEnumerable<Article> ByNameSubstring(this IEnumerable<Article> List, string SubString)
        {
            foreach (var a in List)
            {
                if (a.Name.IndexOf(SubString) > -1)
                    yield return a;
            }
        }
        static void Main()
        {
            Magazine magazine = new Magazine("Forbes", Frequency.Monthly, DateTime.Today, 500);
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine(magazine[Frequency.Weekly] + " " + magazine[Frequency.Monthly] + " " + magazine[Frequency.Yearly]);
            Console.WriteLine();
            magazine.Name = "Игромания";
            magazine.Frequency = Frequency.Weekly;
            magazine.PublishDate = DateTime.Today;
            magazine.Eedition = 500;
            magazine.AddArticles(new Article("«Слышь, купи» — как Bethesda и Тодд Говард Skyrim продавали", 7.3, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))), new Article("18 ноября состоится кроссовер между Don't Starve Together и Terraria", 8.4, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))));
            Console.WriteLine(magazine.ToString());


            List<Article> list = new List<Article>();
            list.Add(new Article("a1", 1, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))));
            list.Add(new Article("a2", 2, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))));
            list.Add(new Article("a3", 3, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))));

            Console.WriteLine("По рейтингу");
            foreach (var a in list.ByRating(2))
                Console.WriteLine(a);

            Console.WriteLine("По части имени");
            foreach (var a in list.ByNameSubstring("a1"))
                Console.WriteLine(a);

            Console.WriteLine("По рейтингу и по части имени");
            foreach (var a in list.ByNameSubstring("a1").ByRating(2))
                Console.WriteLine(a);
        }
    }
}
