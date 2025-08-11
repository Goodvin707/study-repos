/*Задание 1: Составить программу из ЛР №3 (второй уровень сложности), в которой для каждого x, изменяющегося от a до b с шагом h, вычисление значений Y(x) и S(x) оформить в виде функций пользователя. 
В основной функции реализовать следующие действия:
- ввод исходных значений a, b, h и n; 
- обращение к функциям расчета Y(x) и S(x);
- вывод результатов в виде таблицы. 
Если в задании используется значение факториала, его расчет также оформить функцией.*/
#include"pch.h"
#include<iostream>
#include<stdio.h>
#include<conio.h>
#include<math.h>
using namespace std;
int fact(int a)
{
	int f(1);
	for (int i = 1; i <= a; i++) f *= i;
	return (f);
}
double fY(double x)
{
	return (pow(x, 2) / 4 + x / 2 + 1) * exp(x / 2);
}
double fS(int k, double x)
{
	return ((pow(k, 2) + 1) / fact(k)) * pow(x / 2, k);
}
int main()
{
	setlocale(LC_ALL, "Rus");
	double a = 0.1, b = 1.0, h = 0.1, s, y, x;
	int k, n;
	cout << "Введите n ";
	cin >> n;
	cout << "\tS(x)\t|\tY(x)\t|\tY(x)-S(x)\t|\n";
	for (x = a; x <= b;)
	{
		k = 0;
		while (k <= n)
		{
			s = fS(k, x);
			k++;
		}
		y = fY(x);
		cout << "\t" << s << "\t|     " << y << "\t|    " << s - y << "\t|" << endl;
		x += h;
	}
	system("pause");
	return 0;
}