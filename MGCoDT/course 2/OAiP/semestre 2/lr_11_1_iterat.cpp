#include "pch.h"
#include <iostream>
#include <cmath>
#include "norm.h"
#include "okr.h"
using namespace std;
double iterat(double A[10][10], double B[10], int N, double eps, int method)
{
	if (thirdNorm(A, N, N) < 1)
	{
		int k = 0, i, j;
		double X[10], Y[10], s, g;
		for (i = 0; i < N; i++)
			X[i] = B[i];
		do
		{
			s = 0;
			k++;
			if (method != 1 && method != 2)
			{
				while (method != 1 && method != 2)
				{
					cout << "Неверное значение!" << endl;
					cout << "Выберите метод решения системы:" << endl << endl;
					cout << "1. Метод Гаусса\n2. Метод Зейделя" << endl << endl;
					cin >> method;
					cout << endl << endl;
				}
			}
			if (method == 1) // Решаем систему методом Гаусса.
			{
				for (i = 0; i < N; i++)
				{
					Y[i] = B[i];
					for (j = 0; j < N; j++)
						Y[i] = Y[i] + A[i][j] * X[j];
					s += (X[i] - Y[i]) * (X[i] - Y[i]);
				}
				for (i = 0; i < N; i++)
					X[i] = Y[i];
			}
			else if (method == 2) // Решаем систему методом Зейделя.
			{
				for (i = 0; i < N; i++)
				{
					g = B[i];
					for (j = 0; j < N; j++)
						g = g + A[i][j] * X[j];
					s += (X[i] - g) * (X[i] - g);
					X[i] = g;
				}

			}
		} while (sqrt(s) >= eps * (1 - thirdNorm(A, N, N)) / thirdNorm(A, N, N));
		if (method == 1 || method == 2)
		{
			cout << "Решение системы:" << endl << endl;
			for (i = 0; i < N; i++)
				cout << "X" << i << " = " << okr(X[i], eps) << "" << endl;
			cout << "Число итераций: " << k - 1 << "" << endl << endl;
			cout << "Первая норма матрицы A: " << firstNorm(A, N, N) << "" << endl;
			cout << "Вторая норма матрицы A: " << secondNorm(A, N, N) << "" << endl;
			cout << "Третья норма матрицы A: " << thirdNorm(A, N, N) << "" << endl;
			cout << endl << endl;
		}
	}

	else
		cout << "Условие сходимости по евклидовой метрике не выполняется!" << endl << endl;

	return 0;
}
