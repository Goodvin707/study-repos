/*Задание 1:
• Ознакомиться с теоретическим материалом, ответьте на контрольные вопросы
• Реализовать класс объявляемой исключительной ситуации, для проверки корректности вводимых данных. Объект данной исключительной ситуации содержать в себе информацию о значении, обработка которого вызвала данную исключительную ситуацию.*/

import java.util.Scanner;
 
class CustomEx extends Exception
{
    int data;
    public CustomEx(int data) {
        this.data = data;
    }
}
 
public class Main {
    public static void main(String[] args) {
        boolean verno = true;
        do
        {
            System.out.println("Введите положительное число");
            Scanner scanner = new Scanner(System.in);
            try
            {
                int data = scanner.nextInt();
                if(data < 0)
                {
                    System.out.println("Введено отрицательное число!");
                    throw new CustomEx(data);
                }
                verno = true;
            }
            catch (Exception ex)
            {
                System.out.println("Вы ввели неправильно");
                verno = false;
            }
        }while(!verno);
    }
}
