// Задание 1: Решить задачи из ЛР №2 Первого уровня сложности с вводом и выводом массива и результатов из/в файл

package domain;
import java.io.*;
import java.util.Scanner;
 
public class Main {
 
    public static void main(String[] args) {
        int min = 0, sum = 0;
        int[] ar = new int[5];
         
        try(BufferedReader br = new BufferedReader(new FileReader("input1.txt")))
        {
            int c;
            int gind = 0;
            while((c=br.read())!=-1) {
                if (Character.getNumericValue((char)c) != -1)
                {
                    ar[gind] = Character.getNumericValue((char)c);
                    gind++;
                    if (gind >= 5)
                        gind--;
                }
            }
        }
        catch(IOException ex) {
            System.out.println(ex.getMessage());
        }
         
        for (int i = 0; i < ar.length; i++)
            System.out.print(ar[i] + " ");
         
        for (int i = 0; i < ar.length; i++) {
            if (ar[i] < min)
                min = i;
        }
        for (int i = min; i < ar.length; i++)
            sum += ar[i];
        System.out.println("\nСумма элементов: " + sum);
         
        String text = "Сумма элементов: " + sum;
        try(FileOutputStream fos=new FileOutputStream("output1.txt"))
        {
            byte[] buffer = text.getBytes();
            fos.write(buffer, 0, buffer.length);
        }
        catch(IOException ex){
            System.out.println(ex.getMessage());
        }
    }
}
