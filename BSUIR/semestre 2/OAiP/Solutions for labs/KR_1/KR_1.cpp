#include <iostream>
#include <string>
#include <Windows.h>
using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

	int N;
	int countNumbersWithSameDigits = 0;

	do
	{
		cout << "Введите N: ";
		cin >> N;
	} while (N >= 1000);

	for (int i = 10; i < N; i++)
	{
		string number = to_string(i);
		if (number[0] == number[number.length() - 1])
			countNumbersWithSameDigits++;
	}
	cout << "Количество чисел, которые начинаются и заканчиваются на одинаковые цифры в диапазоне [1, " << N << "): " << countNumbersWithSameDigits;
	return 0;
}