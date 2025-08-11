/*Задание 2: Написать программу по обработке двухмерного массива. Размеры массива n, m  и значения элементов массива вводятся с клавиатуры.
Найти количество строк, среднее арифметическое элементов меньше введенной с клавиатуры величины.*/
#include "pch.h"
#include <iostream>
#include <cstdlib>
using namespace std;

template <typename T1, typename T2, typename T3>
int Kolvo(T1 *Mas, T2 n, T2 m, T3 num)
{
	T3 aver = 0;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				cin >> Mas[i][j];
			}
		}
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				cout << Mas[i][j] << " ";
			}
		}
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				aver += Mas[i][j];
			}
			aver /= n;
			if (aver < num)
			{
				count++;
			}
		}
		return count;
};

int main()
{
	setlocale(LC_ALL, "Rus");
	float num;
	int n, m;
	int count;
	cout << "Введите размерность массива: " << endl;
	cin >> n >> m;
	double **Mas = new double *[n];
	for (int i = 0; i < n; i++)
	{
		Mas[i] = new double[m];
	}
	cout << "Введите элементы массива: " << endl;
	cout << "Количество строк, среднее арифметическое элементов которых меньше заданного: " << Kolvo(Mas, n, m, num) << endl;
}