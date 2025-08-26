// Задание 2: Написать программу по обработке двухмерного массива. Размеры массива n, m вводятся с клавиатуры, значения элементов массива генерируются случайным образом от -10 до 10.
// Найти количество строк, среднее арифметическое элементов, которых меньше введенной с клавиатуры величины.

import java.util.Scanner;
 
public class Main
{
    public static void main(String[] args) {
        int n, m;
        int count = 0;
        Scanner in = new Scanner(System.in);
         
        System.out.println("Введите число: ");
        double num = in.nextDouble();
         
        System.out.println("Введите размерность массива: ");
        n = in.nextInt();
        m = in.nextInt();
        int[][] Mas = new int[n][m];
        for (int i = 0; i < n; i++)
            Mas[i] = new int[m];
             
        System.out.println("Массив: ");
         
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Mas[i][j] = (int)(Math.random() * (10 - (-10)) + (-10));
                System.out.print(Mas[i][j] + " ");
            }
            System.out.println();
        }
         
        double aver = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                aver += Mas[i][j];
            aver /= n;
            if (aver < num)
                count++;
        }
        System.out.println("Количество строк, среднее арифметическое элементов которых меньше заданного: " + count);
    }
}
