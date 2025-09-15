// Задание 6: Создать перечислимый тип данных, отображающий виды банковского счета (текущий и сберегательный). Создать переменную типа перечисления, присвоить ей значение и вывести это значение на печать.
enum TypesBankAccounts
{
    Current,
    Safer
}
static void Main()
{
    TypesBankAccounts sc;
    sc = (TypesBankAccounts)1;
    Console.WriteLine(sc);
}