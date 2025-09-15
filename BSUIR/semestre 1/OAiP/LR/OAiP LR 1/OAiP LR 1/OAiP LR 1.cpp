#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <iomanip>
#include <Windows.h>
using namespace std;

// Вычисление факториала через цикл for
int factorial(int a)
{
	if (a != 0)
	{
		int b = 1;
		for (int i = 1; i <= a; i++)
			b *= i;
		return b;
	}
	return 1;
}

// Перегрузка вычисления факториала через цикл for для действительных чисел
double factorial(double a)
{
	if (a != 0)
	{
		double b = 1;
		for (int i = 1; i <= a; i++)
			b *= i;
		return b;
	}
	return 1;
}

// Функция возведения в степень
int pow(int& a, int& n)
{
	for (int i = 0; i < n; i++)
		a *= a;
	return a;
}

// Перегрузка функции возведения в степень для действительных чисел
double pow(double a, int n)
{
	for (int i = 0; i < n; i++)
		a *= a;
	return a;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

	cout << fixed;
	cout.precision(8);
	int a = 2;								// |a| < 10^6
	double x = 1, e = 2;					// x != 0, e > 0
	double b = e < 1 ? 1 / a : factorial(a);

	double S = 0;
	double Sk = 0;

	int menu;
	cout << "Выберите пункт меню\n";
	cout << "1. Задать значения переменных a,x,e вручную\n";
	cout << "2. Использовать значения переменных по умолчанию {a = 2, x = 1, e = 2}\n";
	cin >> menu;
	switch (menu)
	{
	case 1:
		do
		{
			cout << "[a -- целое, |a| < 10^6] a = ";
			cin >> a;
			cout << "[x -- действительное, x != 0] x = ";
			cin >> x;
			cout << "[e -- действительное, e > 0] e = ";
			cin >> e;
			cout << "a = " << a << "; x = " << x << "; e = " << e << endl;
		} while (a > pow(10, 6) || x == 0 || e < 0);
	default:
		break;
	}

	for (int k = 1; Sk < e; k++) // Подсчет суммы
	{
		double delimoe = factorial(abs(a - k) + 1) * pow(x, k);
		double delitel = (factorial(k) * 2 * k);
		if (delitel != 0)
			Sk += delimoe / delitel;
		else
		{
			cout << "Деление на ноль, выход из цикла\n";
			break;
		}
		cout << "S[" << k << "]:\t" << Sk << endl;
	}
	if (Sk == 0)
		cout << "Ни одно из слагаемых не было учтено\n";
	S = b + Sk;
	cout << "S = \t" << S << endl;

	return 0;
}