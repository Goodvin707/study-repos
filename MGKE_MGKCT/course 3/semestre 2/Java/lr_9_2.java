// Задание 2: Решить задачи из ЛР №2 Второго уровня сложности с вводом и выводом массива и результатов из/в файл

package domain;
import java.io.*;
import java.util.Scanner;
 
public class Main {
 
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Введите число: ");
        int num = in.nextInt();
         
        int n = 3;
        int m = 4;
        int[][] Mas = new int[n][m];
        for (int i = 0; i < n; i++)
            Mas[i] = new int[m];
              
        System.out.println("Массив: ");
        try(BufferedReader br = new BufferedReader(new FileReader("input2.txt")))
        {
            String s;
            int gindI = 0;
            int gindJ = 0;
            while((s=br.readLine())!=null) {
                Mas[gindI][gindJ] = Integer.parseInt(s);
                System.out.print(Mas[gindI][gindJ] + " ");
                 
                gindJ++;
                if (gindJ >= m)
                {
                    gindJ = 0;
                    gindI++;
                }
                if (gindI >= n)
                    gindI--;
            }
        }
        catch(IOException ex) {
            System.out.println(ex.getMessage());
        }
        System.out.println();
         
        int count = 0;
        double aver = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                aver += Mas[i][j];
            aver /= n;
            if (aver < num)
                count++;
        }
         
        String text = "Количество строк, среднее арифметическое элементов которых меньше заданного: " + count;
        System.out.println(text);
        try(FileOutputStream fos=new FileOutputStream("output2.txt"))
        {
            byte[] buffer = text.getBytes();
            fos.write(buffer, 0, buffer.length);
        }
        catch(IOException ex){
            System.out.println(ex.getMessage());
        }
    }
}
