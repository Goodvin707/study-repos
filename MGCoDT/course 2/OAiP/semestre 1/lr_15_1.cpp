/*Задание 1: Используя лабораторную работу №4 "Разработка и отладка программ обработки массивов", сделайте массив разного типа, инициализируйте его через функцию, реализуйте перегрузку функций для своего варианта. Варианты заданий используйте прежние.*/
#include "pch.h"
#include <iostream>
#include <Windows.h>
using namespace std;
int f(int n, int m)
{
	int x(1), str(0), itog = 0;
	int sum = 0;
	int a;
	int **mass = new int *[n];

	for (int i = 0; i < n; i++)
	{
		mass[i] = new int[m];
		for (int j = 0; j < m; j++)
		{
			cin >> mass[i][j];
		}
	}

	for (int i = 0; i < n; i++)
	{
		cout << endl;
		for (int j = 0; j < m; j++)
		{
			cout << mass[i][j] << " ";
		}
	}
	
	cout << "\nВведите число: ";
	cin >> a;
	int *average = new int[a];
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			sum += mass[i][j];

		}
		average[i] = sum / m;
		if (average[i] < a)
		{
			itog++;
		}
	}
	cout << "Число строк, в которых среднее арифметическое элементов меньше введённого числа: ";
	cout << itog << endl;
	return 0;
}
double f(double n, double m, double c)
{
	int x(1), str(0), itog = 0;
	int sum = 0;
	double a;
	double **mass = new double *[n];

	for (int i = 0; i < n; i++)
	{
		mass[i] = new double[m];
		for (int j = 0; j < m; j++)
		{
			cin >> mass[i][j];
		}
	}

	for (int i = 0; i < n; i++)
	{
		cout << endl;
		for (int j = 0; j < m; j++)
		{
			cout << mass[i][j] << " ";
		}
	}

	cout << "\nВведите число: ";
	cin >> a;
	double *average = new double[a];
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			sum += mass[i][j];
		}
		average[i] = sum / m;
		if (average[i] < a)
		{
			itog++;
		}
	}
	cout << "Число строк, в которых среднее арифметическое элементов меньше введённого числа: ";
	cout << itog << endl;
	return 0;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	double c;
	int a = 0, n, m;
	cout << "Выберите тип массива\n1-- int\n2-- double" << endl;
	cin >> a;
	if (a == 1)
	{
		cout << "Введите размерность массива" << endl;
		cin >> n >> m;
		cout << "Введите элементы массива\n";
		f(n, m);
	}
	else if (a == 2)
	{
		cout << "Введите размерность массива" << endl;
		cin >> n >> m >> c;
		cout << "Введите элементы массива\n";
		f(n, m, c);
	}
	cout << endl;
	system("pause");
	return 0;	
}