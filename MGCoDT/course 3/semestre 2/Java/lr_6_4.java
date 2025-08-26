/*Задание 4: Простое наследование. 
Разработайте класс TOVAR1 – производный от класса TOVAR. Элементы класса: 
	• цена при реализации; 
	• остаток товара. 
Методы: 
	• конструктор без параметров (по умолчанию); 
	• конструктор с параметрами; 
	• метод, осуществляющий ввод значений полей класса с клавиатуры; 
	• метод, осуществляющий вывод значений полей класса на экран.

import java.util.Scanner;
 
class Tovar
{
    String title;
    int count;
    int[] date = new int[3];
    public Tovar(String title, int count, int day, int month, int year)
    {
        this.title = title;
        this.count = count;
        this.date[0] = day;
        this.date[1] = month;
        this.date[2] = year;
    }
     
    public void setTitle(String title)
    {
        this.title = title;
    }
    public String getTitle()
    {
        return this.title;
    }
     
    public void setCount(int count)
    {
        this.count = count;
    }
    public int getCount()
    {
        return this.count;
    }
     
    public void setDate(int day, int month, int year)
    {
        this.date[0] = day;
        this.date[1] = month;
        this.date[2] = year;
    }
    public int[] getDate()
    {
        return this.date;
    }
     
    public void check(String title)
    {
        if (this.title == title)
            System.out.println(this.date[0] + "." + this.date[1] + "." + this.date[2]);
    }
}
 
class Tovar1 extends Tovar
{
    double price;
    int remainder;
    public Tovar1()
    {
        super("Title", 0, 0, 0, 0);
        this.price = 0.00;
        this.remainder = 0;
    }
    public Tovar1(String title, int count, int day, int month, int year, double price, int remainder)
    {
        super(title, count, day, month, year);
        this.price = price;
        this.remainder = remainder;
    }
     
    public void setAll()
    {
        Scanner in = new Scanner(System.in);
        System.out.print("Введите название: ");
        this.title = in.nextLine();
        System.out.print("Введите количество: ");
        this.count = in.nextInt();
        System.out.print("Введите день: ");
        this.date[0] = in.nextInt();
        System.out.print("Введите месяц: ");
        this.date[1] = in.nextInt();
        System.out.print("Введите год: ");
        this.date[2] = in.nextInt();
        System.out.print("Введите год: ");
        this.price = in.nextDouble();
        System.out.print("Введите год: ");
        this.remainder = in.nextInt();
    }
    public void printAll()
    {
        System.out.println(this.title + "; " + 
        this.count + "; " +
        this.date[0] + "; " +
        this.date[1] + "; " +
        this.date[2] + "; " +
        this.price + "; " +
        this.remainder
        );
    }
}
 
public class Main
{
    public static void main(String[] args) {
        Tovar1[] tovars = new Tovar1[3];
        for (int i = 0; i < tovars.length; i++)
        {
            tovars[i] = new Tovar1("Товар " + i, 1 + i + i * i, i + 1, i + 1, i * i * i * i, i + 1, i + 1);
            tovars[i].printAll();
        }
        tovars[0].check(tovars[0].getTitle());
        tovars[1].check("Товар -1");
        tovars[2].check(tovars[2].getTitle());
    }
}
