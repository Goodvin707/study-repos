// Задание 1: Определить методы с параметром, выполняющие действия в соответствии с вариантом задания. Написать программу, осуществляющую вызов этих методов.
// Найти: y=max(a,b,c)+min(a,b,c).

import java.util.Scanner;
 
public class Main
{
    public static int max(int a, int b, int c) {
        if (a > b)
            return (a > c) ? a : c;
        else if (b > c)
            return (b > a) ? b : a;
        else if (a > c)
            return (a > b) ? a : b;
        return c;
    }
    public static int min(int a, int b, int c) {
        if (a < b)
            return (a < c) ? a : c;
        else if (b < c)
            return (b < a) ? b : a;
        else if (a < c)
            return (a < b) ? a : b;
        return c;
    }
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Введите три числа");
        int a = in.nextInt();
        int b = in.nextInt();
        int c = in.nextInt();
        System.out.println("y = " + (max(a, b, c) + min(a, b, c)));
    }
}
