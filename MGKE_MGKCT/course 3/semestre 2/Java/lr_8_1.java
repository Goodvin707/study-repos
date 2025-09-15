// Задание 1: Реализовать вывод результатов в файл из ЛР №3 своего варианта

package domain;
import java.io.*;
import java.io.File;
import java.io.IOException;
 
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
        
    public String receivePerson(String name)
    {
        System.out.println("Учащийся " + name);
        return "Учащийся " + name;
    }
    public String receivePerson(String name, String date)
    {
        System.out.println("Учащийся " + name + "; Дата: " + date);
        return "Учащийся " + name + "; Дата: " + date;
    }
    public int getStudy()
    {
        return this.study;
    }
        
    public String sendMessage(String... names)
    {
        String s = "";
        System.out.println("Сообщение было отправлено");
        s += "Сообщение было отправлено\n";
        for (String name : names) {
            System.out.println(name);
            s += name + "\n";
        }
        return s;
    }
}
public class HelloWorld {
 
    public static void main(String[] args) {
        File newFile = new File("zxc.txt");
        try
        {
            boolean created = newFile.createNewFile();
            if(created)
            {
                System.out.println("File has been created");
                 
                String text = "";
                Person[] persons = new Person[5];
                System.out.println("---------Объекты---------");
                text += "---------Объекты---------\n";
                for (int i = 0; i < 5; i++)
                {
                    persons[i] = new Person("Учащийся " + (i + 1), i + 1, (i + 1) + "." + (i + 1)*2 + ".2022");
                    System.out.println(persons[i].name + "; Курс " + persons[i].study + "; Дата " + persons[i].data);
                    text += persons[i].name + "; Курс " + persons[i].study + "; Дата " + persons[i].data + "\n";
                }
                System.out.println("-------------------------");
                text += "-------------------------\n";
                System.out.println("---------Методы----------");
                text += "---------Методы----------\n";
                for (int i = 0; i < 5; i++)
                {
                    text += persons[i].receivePerson(persons[i].name) + "\n";
                    System.out.println(persons[i].getStudy());
                    text += persons[i].getStudy() + "\n";
                    text += persons[i].receivePerson(persons[i].name, "0" + (i + 1) +".0" + (i + 1) + ".202" + (i + 1)) + "\n";
                    System.out.println();
                    text += "\n";
                }
                text += persons[0].sendMessage(persons[0].name, persons[1].name, persons[2].name);
                System.out.println("--------------------------");
                text += "--------------------------\n";
                 
                try(FileOutputStream fos=new FileOutputStream("zxc.txt"))
                {
                    byte[] buffer = text.getBytes();
                    fos.write(buffer, 0, buffer.length);
                    System.out.println("The file has been written");
                }
                catch(IOException ex) {
                    System.out.println(ex.getMessage());
                }
            }
        }
        catch(IOException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
