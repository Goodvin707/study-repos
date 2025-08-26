// Задание 1: Базовый класс – оргтехника. Производные – принтер и сканер. Создать класс Офис, который может содержать оба вида объектов. Предусмотреть метод подсчета отдельно принтеров и сканеров с помощью интерфейса.

package com.company;
 
import java.util.AbstractList;
import java.util.ArrayList;
import java.util.List;

class Orgtech {}
class Printer extends Orgtech {}
class Scaner extends Orgtech {}
class Office implements ICounter
{
    public ArrayList<Orgtech> orgtech;
 
    public Office() {
        this.orgtech = new ArrayList<Orgtech>();
    }
 
    @Override
    public void count() {
        System.out.println(this.orgtech.size());
    }
}
 
interface ICounter
{
    public void count();
}
 
public class Main {
 
    public static void main(String[] args) {
 
        Office office = new Office();
 
        Scaner scaner = new Scaner();
        Printer printer = new Printer();
 
        office.orgtech.add(scaner);
        office.orgtech.add(printer);
 
        office.count();
    }
}
