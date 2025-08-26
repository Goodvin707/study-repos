/*Задание 1: Составить программу, в которой для каждого x, изменяющегося от a до b с шагом h, вычисление значений Y(x) и S(x) оформить в виде функций пользователя. 
В основной функции реализовать следующие действия:
		ввод исходных значений a, b, h и n; 
		обращение к функциям расчета Y(x) и S(x);
		вывод результатов в виде таблицы.
Если в задании используется значение факториала, его расчет также оформить функцией.
Работу программы проверить для a = 0,1; b = 1,0; h = 0,1; n=10.*/
 
public class Main
{
    public static int Fact(int n)
    {
        if (n == 0)
            return 1;
        return n * Fact(n - 1);
    }
     
    public static double Y(double x)
    {
        return (Math.exp(x) + Math.exp(-x)) / 2;
    }
     
    public static double S(double x, int n)
    {
        double s = 0;
        for (int k = 0; k < n; k++)
            s += Math.pow(x, 2 * k) / Fact(2 * k);
        return s;
    }
         
    public static void main(String[] args) {
        double a = 0.1, b = 1.0, h = 0.1, s = 0, x = a, y;
        int n = 10;
        while (x <= b)
        {
            s = S(x, n);
            y = Y(x);
            x += h;
            System.out.println("Y(x) = " + y + "\t" + "S(x) = " + s + "\t");
        }
    }
}
