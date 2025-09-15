/*Задание 1: Создайте класс Person, который содержит переменные name, study и data. 
Создайте три экземпляра этого класса. Выведите на консоль значения их переменных.
Добавить в класс Person методы:
receivePerson, имеет один параметр – имя учащегося. Выводит на консоль сообщение “Учащийся {name}”. 
Метод getStudy – возвращает курс учащегося. Вызвать эти методы для каждого из объектов.
Добавить конструктор в класс Person, который принимает на вход три параметра для инициализации переменных класса - name, study и data. 
Добавить конструктор, который принимает на вход два параметра для инициализации переменных класса - name, study. Добавить конструктор без параметров и инициализаторы. Вызвать из конструктора с тремя параметрами конструктор с двумя.
Добавьте перегруженный метод receivePerson, который принимает два параметра - имя учащегося и его дату рождения. Вызвать этот метод.
Создать метод sendMessage с аргументами переменной длины. Данный метод принимает на вход имя учащегося, которым будет отправлено сообщение. Метод выводит на консоль имена и курс учащихся.*/

class Person
{
    String name;
    int study;
    String data;
       
    public Person()
    {
        this.name = "Name";
        this.study = 1;
        this.data = "01.01.2020";
    }
    public Person(String name, int study)
    {
        this.name = name;
        this.study = study;
    }
    public Person(String name, int study, String data)
    {
        this(name, study);
        this.data = data;
    }
       
    public void receivePerson(String name)
    {
        System.out.println("Учащийся " + name);
    }
    public void receivePerson(String name, String date)
    {
        System.out.println("Учащийся " + name + "; Дата: " + date);
    }
    public int getStudy()
    {
        return this.study;
    }
       
    public void sendMessage(String... names)
    {
        System.out.println("Сообщение было отправлено");
        for (String name : names) {
            System.out.println(name);
        }
    }
}
   
public class Main
{
    public static void main(String[] args) {
           
        Person[] persons = new Person[5];
        System.out.println("---------Объекты---------");
        for (int i = 0; i < 5; i++)
        {
            persons[i] = new Person("Учащийся " + (i + 1), i + 1, i + "." + i*2 + ".2022");
            System.out.println(persons[i].name + "; Курс " + persons[i].study + "; Дата " + persons[i].data);
        }
        System.out.println("-------------------------");
        System.out.println("---------Методы---------");
        for (int i = 0; i < 5; i++)
        {
            persons[i].receivePerson(persons[i].name);
            System.out.println(persons[i].getStudy());
            persons[i].receivePerson(persons[i].name, "0" + (i + 1) +".0" + (i + 1) + ".202" + (i + 1));
            System.out.println();
        }
        persons[0].sendMessage(persons[0].name, persons[1].name, persons[2].name);
        System.out.println("------------------------");
    }
}
