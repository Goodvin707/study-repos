// Задание 1: В одномерном массиве, состоящем из n (не более 10) вводимых с клавиатуры значений, вычислить заданное значение.
// Сумму элементов массива, расположенных после минимального элемента.

import java.util.Scanner;
 
public class Main {
    public static void main(String[] args) {
        /*В одномерном массиве, состоящем из n (не более 10) вводимых с клавиатуры значений,
        вычислить сумму элементов массива, расположенных после минимального элемента.*/
        Scanner in =new Scanner(System. in );
        int min = 0,
        sum = 0;
        int n;
        do {
            System.out.print("Введите количество элементов (<= 10): ");
            n = in.nextInt();
        } while ( n > 10 );
 
        int[] ar = new int[n];
        System.out.println("Введите значения массива: ");
        for (int i = 0; i < ar.length; i++)
        ar[i] = in.nextInt();
 
        System.out.print("Массив: ");
        for (int i = 0; i < ar.length; i++)
        System.out.print(ar[i] + " ");
 
        for (int i = 0; i < ar.length; i++) {
            if (ar[i] < min) min = i;
        }
        for (int i = min; i < ar.length; i++)
        sum += ar[i];
 
        System.out.println("\nСумма элементов:" + sum);
    }
}
