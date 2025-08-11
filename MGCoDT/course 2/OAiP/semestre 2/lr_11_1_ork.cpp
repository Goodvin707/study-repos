#include "pch.h"
#include <cmath>
#include <iostream>
using namespace std;
double okr(double X, double eps)
{
	int i = 0;
	while (eps != 1)
	{
		i++;
		eps *= 10;
	}
	double okr = pow(double(10), i);
	X = int(X * okr + 0.5) / okr;

	return X;
}
