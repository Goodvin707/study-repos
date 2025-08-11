/*Задание 1: Написать программу по обработке двухмерного динамического массива. Размеры массива n, m вводятся с клавиатуры, значения элементов массива – случайные числа от -13 до 13).
1. Определить количество столбцов, содержащих хотя бы один нулевой элемент.*/
#include "pch.h"
#include <iostream>
#include <vector>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	int x, y;
	int stolb(0);
	int itog = 0;
	cout << "Введите размеры вектора: " << endl;
	cin >> x >> y;
	vector<vector <int>> vec1(x, vector <int>(y));

	for (int i = 0; i < x; i++)
	{
		for (int j = 0; j < y; j++)
		{
			vec1[i][j] = rand() % 26 - 13;
			cout << vec1[i][j] << " ";
		}
		cout << endl;
	}

	for (int i = 0; i < x; i++)
	{
		cout << endl;
		for (int j = 0; i < y; i++)
		{
			cout << vec1[i][j] << " ";
		}
	}

	for (int j = 0; j < y; j++)
	{
		for (int i = 0; i < x; i++)
		{
			if (vec1[i][j] == 0)
			{
				itog++;
				break;
			}
		}
	}
	cout << endl;
	cout << itog << endl;
	system("pause");
}