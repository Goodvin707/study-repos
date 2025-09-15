// Задание 2: Реализация методов класса. 
// Напишите реализацию методов, предоставляющих доступ к данным класса. Отобразите в программе работу этих методов для объявленного ранее массива объектов.

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
        Tovar[] tovars = new Tovar[3];
        for (int i = 0; i < tovars.length; i++)
        {
            tovars[i] = new Tovar();
            tovars[i].setTitle("Товар " + (i + 1));
            tovars[i].setCount(1 + i + i * i);
            tovars[i].setDate(i + 1, i + 1, i * i * i * i);
            System.out.println(tovars[i].getTitle() + "; " + tovars[i].getCount() + "; " + tovars[i].getDate()[0] + "." + tovars[i].getDate()[1] + "." + tovars[i].getDate()[2]);
        }
    }
}
