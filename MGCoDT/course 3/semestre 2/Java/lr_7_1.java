/*Задание 1:
Реализовать приложение, вычисляющее для последовательности чисел, представляющих величины углов, следующие тригонометрические функции: 
• сумма синусов/косинусов значений, 
• разность синусов/косинусов значений, 
• произведение синусов/косинусов введенных значений. 
Единица измерения углов должна указываться как параметр командной строки. Для представления единиц измерения используйте константы с типом int. Для хранения значений, необходимо использовать массив с типом double. Объявления методов должны выглядеть следующим образом:
angles – массив значений углов
type -единица измерения, имеющее значение одной из констант
return сумму синусов значений углов;

public static double getSumSinuses(double[] angles, int type);
2. С помощью перегрузки реализуйте методы, позволяющие указывать количество значащих знаков для результатов выполнения операций.
3. Дополнить приложение, таким образом, чтобы имелась возможность формирования исходной числовой последовательности числами, сформированными генератором случайных чисел;
4. Реализовать класс, в котором будут содержаться все описанные выше функциональные возможности.*/

class A
{
    public static double sum_first(int[] mass)
    {
        double sum = 0;
        for(int i = 0;i<mass.length-1;i++)
        {
            sum+=Math.sin(mass[i]);
        }
        return sum;
    }
 
    public static double minus_first(int[] mass)
    {
        double minus_first = 0;
        for(int i = 0;i<mass.length-1;i++)
        {
            minus_first -= Math.sin(mass[i]);
        }
        return minus_first;
    }
 
    public static double mul_first(int[] mass)
    {
        double mul_first = 1;
        for(int i = 0;i<mass.length-1;i++)
        {
            mul_first *= Math.sin(mass[i]);
        }
        return mul_first;
    }
 
    public static int random()
    {
        return (int)(Math.random() * 51);
    }
 
    public static double round(double value,int kolznak)
    {
        return (int)(value * Math.pow(10,kolznak)) / Math.pow(10,kolznak);
    }
}
 
public class Main {
 
    public static void main(String[] args) {
        int mass[] = new int [5];
        for (int i = 0; i < mass.length-1; i++) {
            mass[i] = A.random();
        }
        System.out.println(A.round(A.sum_first(mass),2));
        System.out.println(A.round(A.minus_first(mass),3));
        System.out.println(A.mul_first(mass));
    }
}
