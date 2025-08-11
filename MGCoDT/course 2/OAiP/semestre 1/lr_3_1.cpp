/*Задание 1: Составить программу для определения таблицы значений функции у в произвольном диапазоне [a, b] изменения аргумента х с произвольным шагом h. Значения a, b, h вводятся с клавиатуры. Таблица должна содержать следующие столбцы: порядковый номер, значение аргумента x, значение функции, сообщение о возрастании или убывании функции. 
Определить максимальное и минимальное значения функции.*/
#include <stdio.h>
#include <conio.h>
#include <math.h>
int main()
{
	double pi = 3.1415, a = -pi, b = pi, h = pi / 6, x, y(0), temp, min, max;
	min = max = a;
	int i(0);
	x = a;
	while (x <= b)
	{
		temp = y;
		y = x / 2 * cos(x) - sin(x);
		i++;
		printf("#  % 3d pri x = % 6.2f  y = % 6.2f   ", i, x, y);
		if (y < temp) printf("function down\n");
		else printf("function up\n");
		x += h;
		if (min > y) min = y;
		if (max < y) max = y;
	}
	printf("min=%6.2f, max=%6.2f \n",min,max);
	_getch(); 
	return 0;
}
