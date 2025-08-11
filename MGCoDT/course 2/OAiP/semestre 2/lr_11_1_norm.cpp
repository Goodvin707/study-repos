#include "pch.h"
#include <cmath>
double firstNorm(double  A[10][10], int n, int m)
{
	int i, j;
	double sum = 0, subSum;
	for (i = 0; i < n; i++)
	{
		subSum = 0;
		for (j = 0; j < m; j++)
			subSum += abs(A[i][j]);
		if (subSum > sum)
			sum = subSum;

	}
	return sum;
}

double secondNorm(double  A[10][10], int n, int m)
{
	int i, j;
	double sum = 0, subSum;
	for (j = 0; j < n; j++)
	{
		subSum = 0;
		for (i = 0; i < m; i++)
			subSum += abs(A[i][j]);
		if (subSum > sum)
			sum = subSum;

	}
	return sum;
}

double thirdNorm(double A[10][10], int n, int m)
{
	int i, j;
	double sum = 0;
	for (i = 0; i < n; i++)
		for (j = 0; j < m; j++)
			sum += (A[i][j] * A[i][j]);
	sum = sqrt(sum);
	return sum;
}
