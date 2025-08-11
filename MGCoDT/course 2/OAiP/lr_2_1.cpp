/*Задание 1: Вычислить значение y в зависимости от выбранной функции (x), аргумент которой определяется из поставленного условия. 
Возможные значения функции (x): 2x, x2, х/3. Предусмотреть вывод сообщений, показывающих, при каком условии и с какой функцией производились вычисления у.*/
#include "pch.h"
#include <stdio.h>
#include <conio.h>
#include <math.h>
int main()
{
	double x, y, z, fi, a, b;
	int op; bool f = true;
	printf("vvedi a,x,b,z\n");
	scanf_s("%f%f%f%f", &a, &x, &b, &z);
	if (z > 0) x = 1/pow(z,2)+2*z;
	else 1 - pow(z, 3);
	printf("vyberi fi\n");
	printf("1. fi=2*x\n");
	printf("2. fi=pow(x,2)\n");
	printf("3. fi=x/3\n");
	scanf_s("%d", &op);
	switch (op)
	{
	case    1: fi = 2 * x; break;
	case	2: fi = pow(x, 2); break;
	case	3: fi = x / 3; break;
	default: printf("\nERROR\n"); f = false;
	}
	if (f) 
	{
		y = 2, 5 * a*exp(-3 * x) - 4 * b*pow(x, 2) / log(fabs(x)) + fi;
		printf("rezultat=%6.2f\n", y);
	}
	_getch();
	return 0;
}