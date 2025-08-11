/*Задание 2: Решить поставленную задачу с использованием рекурсивной и обычной функций. Сравнить полученные результаты.*/
#include "pch.h"
#include <iostream>
#include <cmath>
using namespace std;
double del(double n)
{
	double x = 0;
	double y = 0;
	for (double i = n; i >= 2; i--)
	{
		x += i + 1;
		y = 1 / x;
	}
	return y;
}
double recdel(int);
int main()
{
	setlocale(LC_ALL, "Rus");
	double f;
	int n;
	cout << "Введите n ";
	cin >> n;
	f = recdel(n + 1);
	cout << "Ответ: " << f << endl;
	cout << del(n);
	return 0;
}
double recdel(int n)
{
	if (n - 1 == 1)
	{
		return 0.666;
	}
	else
	{
		return 1 / ((n - 1) + (1 / (recdel(n - 1))));
	}
}