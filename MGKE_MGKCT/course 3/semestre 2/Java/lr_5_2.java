/*Задание 2: Решить поставленную задачу с использованием рекурсивной и обычной функций. Сравнить полученные результаты.
Числа Фибоначчи определяются следующим образом: Fb(0) = 0; Fb(1) = 1; Fb(n) = Fb(n-1) + Fb(n-2). Определить Fb(n).*/

public class Main
{
    public static int[] Fibon(int n)
    {
        int[] f = new int[n];
        f[0] = 0;
        f[1] = 1;
        for (int i = 2; i < n; ++i) {
            f[i] = f[i - 1] + f[i - 2];
        }
        return f;
    }
     
    public int FibonRecur(int n) {
        if (n == 0)
            return 0;
        else if (n == 1)
            return 1;
        else
            return FibonRecur(n - 1) + FibonRecur(n - 2);
}
     
    public static void main(String[] args) {
        int[] f = Fibon(4);
        System.out.println(f[f.length - 1]);
        f = Fibon(5);
        System.out.println(f[f.length - 1]);
        f = Fibon(8);
        System.out.println(f[f.length - 1]);
    }
}
