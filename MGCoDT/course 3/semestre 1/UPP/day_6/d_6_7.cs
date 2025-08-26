// Задание 7: Создать структуру данных, которая хранит информацию о банковском счете – его номер, тип и баланс. Создать переменную такого типа, заполнить структуру значениями и напечатать результат.
enum TypesBankAccounts { Current, Safer }
struct BankAccount
{
    int number;
    TypesBankAccounts tps;
    double balance;
    public BankAccount(int number, int tps, double balance)
    {
        this.number = number;
        this.tps = (TypesBankAccounts)tps;
        this.balance = balance;
    }
    public void Print()
    {
        Console.WriteLine("Номер счёта: " + this.number + "\nТип счёта: " + "\nБаланс: " + this.balance + " BYN");
    }
}
static void Main()
{
    BankAccount obj = new BankAccount(12021, 0, Math.Round(414.23132, 2));
    obj.Print();
}
