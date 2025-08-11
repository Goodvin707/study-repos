// Задание 1: Разработать программу, решающую СЛАУ методом Гаусса — Зейделя.
#include "pch.h"
#include "norm.h"
#include "iterat.h"

#include <iostream>
#include <cmath>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	double eps, A[10][10], B[10];
	int N, i, j;
	int method;
	cout << "Введите размер квадратной матрицы: ";
	cin >> N;
	cout << "Введите точность вычислений: ";
	cin >> eps;
	cout << "Заполните матрицу А: " << endl << endl;
	for (i = 0; i < N; i++)
		for (j = 0; j < N; j++)
		{
			cout << "A[" << i << "][" << j << "] = ";
			cin >> A[i][j];
		}
	cout << endl << endl;
	cout << "Ваша матрица А: " << endl << endl;
	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N; j++)
			cout << A[i][j] << " ";
		cout << endl;
	}

	cout << endl;

	cout << "Заполните столбец свободных членов: " << endl << endl;
	for (i = 0; i < N; i++)
	{
		cout << "В[" << i + 1 << "] = ";
		cin >> B[i];
	}
	cout << endl << endl;
	cout << "Выберите метод решения системы:" << endl << endl;
	cout << "1. Метод Гаусса\n2. Метод Зейделя" << endl << endl;
	cin >> method;
	cout << endl << endl;
	iterat(A, B, N, eps, method);
	system("pause");

	return 0;
}