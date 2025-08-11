/*Задание 1: Написать программу по обработке двухмерного массива. Размеры массива n, m  и значения элементов массива вводятся с клавиатуры.
Найти количество строк, среднее арифметическое элементов которых меньше введенной с клавиатуры величины.*/
#include "pch.h"
#include <iostream>
#include <conio.h>
#include <stdio.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	int n, m, sum = 0, a, itog = 0;
	cout << "Введите размерность массива" << endl;
	cin >> n >> m;
	int **arr = new int*[n];
	
	cout << "Введите элементы массива \n";
	for (int i = 0; i < n; i++)
	{
		arr[i] = new int[m];
		for (int j = 0; j < m; j++)
		{
			cin >> arr[i][j];
		}
	}
	for (int i = 0; i < n; i++)
	{
		cout << endl;
		for (int j = 0; j < m; j++)
		{
	
			cout << arr[i][j] << " ";
		}
	}
	cout << endl;
	cout << "Введите число: ";
	cin >> a;
	int *average = new int[a];
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			sum += arr[i][j];
		}
		average[i] = sum / m;
		if (average[i] < a)
		{
			itog++;
		}
	}
	cout << "Число строк, в которых среднее арифметическое элементов меньше введённого числа: ";
	cout << itog << endl;
}