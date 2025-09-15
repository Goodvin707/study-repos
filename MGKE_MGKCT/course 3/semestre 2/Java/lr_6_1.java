/*Задание 1: Описание класса. 
Запишите описание класса с именем TOVAR, содержащего следующие поля: 
	• наименование товара; 
	• количество единиц товара; 
	• дата поступления товара (массив из трех чисел). 
Скройте элементы-данные от пользователя, предоставив интерфейс доступа к полям посредством открытых методов (предусмотрите объявление двух методов, один из которых присваивает значения полям класса, а другой – выводит значения этих свойств на экран). Объявите массив объектов созданного класса.*/

class Tovar
{
    private String title;
    private int count;
    private int[] date = new int[3];
     
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
}
 
public class Main
{
    public static void main(String[] args) {
        Tovar[] tovars = new tovars[3];
    }
}
