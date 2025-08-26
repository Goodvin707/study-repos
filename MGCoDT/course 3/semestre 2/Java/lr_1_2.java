// Задание 2: Известно, что X кг шоколадных конфет стоит A рублей, а Y кг ирисок стоит B рублей. Определить, сколько стоит 1 кг шоколадных конфет, 1 кг ирисок, а также во сколько раз шоколадные конфеты дороже ирисок.
package com.company;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Введите значения");
        double a = in.nextDouble();
        double b = in.nextDouble();
        double x = in.nextDouble();
        double y = in.nextDouble();
        System.out.println(x + " кг шоклоладных конфет стоят " + a + " рублей\n" + y + " кг ирисок стоят " + b +" рублей");
        double sx = a / x;
        double sy = b / y;
        System.out.println("Цена одного кг шоколадных конфет " + sx);
        System.out.println("Цена одного кг ирисок " + sy);
        System.out.println("Шоколадные конфеты доороже в " + (sx / sy));
    }
}
