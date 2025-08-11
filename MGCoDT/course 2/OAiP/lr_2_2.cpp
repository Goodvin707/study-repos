/*Задание 2: Составить программу нахождения требуемого значения с исходными данными x, y, z. Обозначение: min и max – нахождение минимального и максимального из перечисленных в скобках значений элементов.*/
#include "pch.h"
#include <stdio.h>
#include <conio.h>
#include <math.h>
int main()
{
	float u, x, y, z, min, max, min1, min2;
	printf("vvod x, y, z\n");
	scanf_s("%f%f%f", &x, &y, &z);
	min = (y < z) ? z : y;
	min1 = (x < y) ? x : y;
	min2 = (y < z) ? y : z;
	max = (min1 > min2) ? min1 : min2;
	u = min / max;
	printf("result: %-8.4f\n", u);
}
