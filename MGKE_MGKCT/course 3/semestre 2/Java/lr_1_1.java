// Задание 1: Вычислить высоту треугольника, опущенную на сторону а, по известным значениям длин его сторон a, b, c.

package com.company;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.print("Введите a: ");
        int a = in.nextInt();
        System.out.print("Введите b: ");
        int b = in.nextInt();
        System.out.print("Введите c: ");
        int c = in.nextInt();
        in.close();
        int p = (a + b + c) / 2;
        System.out.print("H = " + (2 / (double)a) * Math.sqrt(p * (p - a) * (p - b) * (p - c)));
    }
}
