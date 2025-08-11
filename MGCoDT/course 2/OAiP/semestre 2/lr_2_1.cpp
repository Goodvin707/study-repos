/*Задание 1: В одномерном массиве, состоящем из n (не более 10) вводимых с клавиатуры значений, вычислить заданное значение.
Сумму элементов массива, расположенных после минимального элемента.*/
#include "pch.h"
#include <iostream>
#include <cstdlib>
using namespace std;

template <typename T>
int Min(T *a, int n)
{
	T min = a[0];
	int ind = 0;
	for (int i = 0; i < n; i++)
	{
		if (a[i] < min)
		{
			min = a[i];
			ind = i;
		}
	}
	T sum = 0;
	if (ind + 1 != n)
	{
		for (int i = ind + 1; i < n; i++)
		{
			sum += a[i];
		}
		cout << endl << "Position min element= " << ind << endl;
		cout << "Min= " << min << endl;
		cout << "Sum= " << sum << endl;
	}
	else cout << "Min element in last position";
		return sum;
}

int main()
{
	const int iSize = 10,
		dSize = 7,
		fSize = 10,
		cSize = 5;

	int    iArray[iSize] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	double dArray[dSize] = { 1.2345, 2.234, 3.57, 4.67876, 5.346, 6.1545, 7.7682 };
	float  fArray[fSize] = { 1.34, 2.37, 3.23, 4.8, 5.879, 6.345, 73.434, 8.82, 9.33, 10.4 };
	char   cArray[cSize] = { "MARS" };
	cout << "\t\t Шаблон функции вывода массива на экран\n\n";
	cout << "\nМассив типа int:\n"; Min(iArray, iSize);
	cout << "\nМассив типа double:\n"; Min(dArray, dSize);
	cout << "\nМассив типа float:\n"; Min(fArray, fSize);
	cout << "\nМассив типа char:\n"; Min(cArray, cSize);
}