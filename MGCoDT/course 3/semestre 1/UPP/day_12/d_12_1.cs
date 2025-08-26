/*Задание 1: Определить класс Person, который имеет  
	•	закрытое поле типа string, в котором хранится имя;
	•	закрытое поле типа string, в котором хранится фамилия;
	•	закрытое поле типа System.DateTime для даты рождения.
В классе Person определить конструкторы:
	•	конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса; 
	•	конструктор без параметров, инициализирующий все поля класса некоторыми значениями по умолчанию.
В классе Person определить свойства c методами get и set:
	•	свойство типа string для доступа к полю с именем; 
	•	свойство типа string для доступа к полю с фамилией;
	•	свойство типа DateTime для доступа к полю с датой рождения;
	•	свойство типа int c методами get и set для получения информации(get) и изменения (set) года рождения в закрытом поле типа DateTime, в котором хранится дата рождения.
В классе Person определить
	•	перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса;
	•	виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию.
Cравнить время, необходимое для выполнения операций с элементами одномерного, двумерного прямоугольного и двумерного ступенчатого массивов с одинаковым числом элементов.
Для этого в методе Main() создать 
	•	одномерный массив; 
	•	двумерный прямоугольный массив;
	•	двумерный ступенчатый массив.
Тип элементов массивов зависит от варианта. Массивы должны иметь одинаковое число элементов. Если число строк в двумерном прямоугольном массиве равно nrow, а число столбцов ncolumn, то одномерный массив должен содержать nrow*ncolumn элементов, в двумерном ступенчатом массиве общее число элементов также должно быть равно nrow*ncolumn.
Значения nrow и ncolumn вводятся в процессе работы приложения в виде одной строки с разделителями. В приглашении, которое получает пользователь, должна быть информация о том, какие символы можно использовать как разделители, число разделителей должно быть больше 1. С помощью метода Split класса System.String приложение разбирает введенную пользователем текстовую строку с информацией о числе строк и числе столбцов двумерного массива и присваивает значения переменным, которые содержат значения nrow и ncolumn. В первой лабораторной работе не требуется обрабатывать ошибки ввода, предполагается, что пользователь правильно ввел данные. 
Приложение распределяет память для всех массивов и инициализирует элементы массивов. Для инициализации элементов можно использовать конструктор без параметров.
Для всех элементов массивов выполняется одна и та же операция, например, присваивается значение одному из свойств, определенных для элементов массива. В лабораторной работе требуется сравнить время выполнения этой операции для одномерного, двумерного прямоугольного и двумерного ступенчатого массивов с одинаковым числом элементов.
Для измерения времени выполнения операций можно использовать свойство Environment.TickCount. Cтатическое свойство TickCount класса Environment имеет тип int, использует информацию системного таймера и содержит время в миллисекундах, которое прошло с момента перезагрузки компьютера. 
Чтобы получить время выполнения некоторого блока кода, необходимо вызвать Environment.TickCount непосредственно перед блоком и сразу же после последнего оператора блока и взять разность значений.
В блоке кода, для которого измеряется время, не должно быть операций распределения памяти для массивов, инициализации элементов массивов и операций вывода данных на консоль. Блоки кода должны содержать только операции с элементами массива.
Вычисленные значения времени выполнения операций для трех типов массивов, а также число строк nrow и столбцов ncolumn выводятся на консоль. Вывод должен быть подписан, т.е. вывод должен содержать информацию о том, какому типу массива отвечает выведенное значение.

Определить тип Frequency - перечисление(enum) со значениями Weekly, Monthly, Yearly.
Определить класс Article, который имеет три открытых автореализуемых свойства, доступных для чтения и записи:
	•	свойство типа Person, в котором хранятся данные автора статьи;
	•	свойство типа string для названия статьи; 
	•	свойство типа double для рейтинга статьи.
В классе Article определить:
	•	конструктор c параметрами типа Person, string, double для инициализации всех свойств класса; 
	•	конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию;
	•	перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех свойств класса.
Определить класс Magazine, который имеет 
	•	закрытое поле типа string c названием журнала;
	•	закрытое поле типа Frequency с информацией о периодичности выхода журнала;
	•	закрытое поле типа DateTime c датой выхода журнала;
	•	закрытое поле типа int с тиражом журнала;
	•	закрытое поле типа Article*+ со списком статей в журнале.
В классе Magazine определить конструкторы:
	•	конструктор с параметрами типа string, Frequency, DateTime, int для
инициализации соответствующих полей класса; 
	•	конструктор без параметров, инициализирующий поля класса значениями по умолчанию.
В классе Magazine определить свойства c методами get и set:
	•	свойство типа string для доступа к полю с названием журнала; 
	•	свойство типа Frequency для доступа к полю с информацией о периодичности выхода журнала;
	•	свойство типа DateTime для доступа к полю c датой выхода журнала;
	•	свойство типа int для доступа к полю с тиражом журнала;
	•	свойство типа Article*+ для доступа к полю со списком статей.
В классе Magazine определить 
	•	свойство типа double (только с методом get), в котором вычисляется среднее значение рейтинга в списке статей;
	•	индексатор булевского типа (только с методом get) с одним параметром типа Frequency; значение индексатора равно true, если значение поля типа Frequency совпадает со значением индекса, и false в противном случае; ? метод  void AddArticles (params Article[]) для добавления элементов в список статей в журнале;
	•	перегруженную версию виртуального метода string ToString() для формирования строки со значениями всех полей класса, включая список статей;
	•	виртуальный метод string ToShortString(), который формирует строку со значениями всех полей класса без списка статей, но со значением среднего рейтинга статей.
В методе Main()
	•	Создать один объект типа Magazine, преобразовать данные в текстовый вид с помощью метода ToShortString() и вывести данные.
	•	Вывести значения индексатора для значений индекса Frequency.Weekly, Frequency.Monthly и Frequency.Yearly.
	•	Присвоить значения всем определенным в типе Magazine свойствам, преобразовать данные в текстовый вид с помощью метода ToString() и вывести данные.
	•	C помощью метода AddArticles( params Article*+ )  добавить элементы в список статей и вывести данные объекта Magazine, используя метод
ToString().
	•	Сравнить время выполнения операций с элементами одномерного, двумерного прямоугольного и двумерного ступенчатого массивов с одинаковым числом элементов типа Article.*/

using System;
using System.Linq;

namespace _12_1
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
            return fname.ToString() + " " + sname.ToString()  + " " + birthDate.ToString();
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
    class Magazine
    {
        string name;
        Frequency frequency;
        DateTime publishDate;
        int edition;
        Article[] articles;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public Frequency Frequency
        {
            get => frequency;
            set => frequency = value;
        }
        public DateTime PublishDate
        {
            get => publishDate;
            set => publishDate = value;
        }
        public int Edition
        {
            get => edition;
            set => edition = value;
        }
        public Article[] Articles
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
        public void AddArticles(params Article[] newArticles)
        {
            if (newArticles?.Length == 0)
                return;
            if (articles == null)
                articles = Array.Empty<Article>();
            int oldLength = articles.Length;
            Array.Resize(ref articles, articles.Length + newArticles.Length);
            Array.Copy(newArticles, 0, articles, oldLength, newArticles.Length);
        }
        public override string ToString()
            => $"Name = {Name}"
            + $"\nFrequency = {Frequency}"
            + $"\nPublishDate = {PublishDate}"
            + $"\nEdition = {Edition}"
            + $"\nArticles:\n {string.Join<Article>("\n ", Articles)}";

        public virtual string ToShortString()
            => $"Name = {Name}"
            + $"\nFrequency = {Frequency}"
            + $"\nPublishDate = {PublishDate}"
            + $"\nEdition = {Edition}";
    }
    class Program
    {
        static void Main()
        {
            Magazine magazine = new Magazine("Forbes", Frequency.Monthly, DateTime.Today, 500);
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine(magazine[Frequency.Weekly] + " " + magazine[Frequency.Monthly] + " " + magazine[Frequency.Yearly]);
            Console.WriteLine();
            magazine.Name = "Игромания";
            magazine.Frequency = Frequency.Weekly;
            magazine.PublishDate = DateTime.Today;
            magazine.Edition = 500;
            magazine.AddArticles(new Article("«Слышь, купи» — как Bethesda и Тодд Говард Skyrim продавали", 7.3, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))), new Article("18 ноября состоится кроссовер между Don't Starve Together и Terraria", 8.4, new Person("Дмитрий", "Сироватко", new DateTime(1989, 10, 1))));
            Console.WriteLine(magazine.ToString());
        }
    }
}
