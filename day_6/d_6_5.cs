// Задание 5: Описать рекурсивную функцию для вычисления n –го члена ряда 3, 3.3, 3.6, 3.9, 4.2, ….6
static double RecFunc(double b, int n)
{
    if (n <= 0)
        return b;
    return RecFunc(Math.Round(b + 0.3, 2), --n);
}
static void Main()
{
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine(RecFunc(3, --n));
}