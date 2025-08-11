/*Задание 1: Разработать класс Random, который содержит средства для генерирования последовательностей случайных чисел. Продемонстрировать работу класса. Программу разработать как Console Application.*/
#include "pch.h"
#include <iostream>
#include <cstdlib> // нужен для вызова функции rand(), srand()
#include <ctime> // нужен для вызова функции time()
using namespace std;

// Класс Random
class Random
{
private:
	double min, max; // Диапазон генерирования

public:
// Конструкторы класса

// Конструктор с двумя параметрами, которые устанавливают диапазон
// генерирование случайных чисел
Random (double min, double max)
{
	srand(time(NULL));
	this->min = min;
	this->max = max;
}


// Функция генерирования случайного целого числа в указанных границах.
// Диапазон чисел: [min, max]
int NextInt(int min, int max)
{
	// Получить случайное число - формула
	int num = min + rand() % (max - min + 1);
	return num;
}

// Функция генерирования случайного целого числа на основании
// данных текущего экземпляра.
int NextInt()
{
	return NextInt((int)this->min, (int)this->max);
}

// Функция, которая генерирует случайное число с плавающей запятой и заданной точностью.
// Функция получает 3 параметра:
// - min - нижняя граница;
// - max - верхняя граница;
// - precision - точность, количество знаков после запятой.
double NextFloat(double min, double max, int precision = 2)
{
	double value;

	// получить случайное число как целое число с порядком precision
	value = rand() % (int)pow(10, precision);

	// получить вещественное число
	value = min + (value / pow(10, precision)) * (max - min);

	return value;
}

// Перегруженный вариант NextFloat(), функция получает параметр - точность.
// Диапазон определяется на основании заданного экземпляра.
double NextFloat(int precision = 2)
{
	double value;
	// получить случайное число как целое число с порядком precision
	value = rand() % (int)pow(10, precision);

	// получить вещественное число
	value = min + (value / pow(10, precision)) * (max - min);

	return value;
}
// Метод, который возвращает массив целых чисел в диапазоне,
// который установлен значениями min, max текущего экземпляра.
// Входной параметр count - количество чисел в массиве
int* GetArrayInt(int count)
{
	int* A = new int[count];
	for (int i = 0; i < count; i++)
		A[i] = NextInt();
	return A;
}

// Метод, который возвращает массив вещественных чисел в диапазоне,
// который установлен в заданном экземпляре.
// Входные параметры:
// - count - количество чисел в массиве;
// - precision - точность (количество знаков после запятой).
double* GetArrayFloat(int count, int precision = 2)
{
	double* A = new double[count];
	for (int i = 0; i < count; i++)
		A[i] = NextFloat(precision);
	return A;
}

// ----------- Методы доступа к внутренним переменным -------------
void SetMinMax(double min, double max)
{
	this->min = min;
	this->max = max;
}

double GetMin()
{
	return min;
}

double GetMax()
{
	return max;
}
};

int main()
{
	// 1. Объявить экземпляры класса
	Random R1(0, 5); // вызывается конструктор с 2 параметрами

	// 2. Проверка метода NextInt()
	int d1 = R1.NextInt();
	int d2 = R1.NextInt();

	cout << "d1 = " << d1 << endl;
	cout << "d2 = " << d2 << endl;

	// 3. Демонстрация метода GetArrayInt()
	int* D = R1.GetArrayInt(20); // выделяется память для массива D

	cout << "Array D: ";
	for (int i = 0; i < 20; i++)
		cout << D[i] << " ";
	cout << endl;

	delete[] D; // не забыть освободить память

	// 4. Инициализация другим экземпляром класса
	Random R3 = R1;
	double* X = R3.GetArrayFloat(10, 4); // выделяется память

	cout << "Array X: ";
	for (int i = 0; i < 10; i++)
		cout << X[i] << " ";
	cout << endl;

	delete[] X; // освободить память

	// 5. Установить новые пределы в экземпляре R1
	R1.SetMinMax(19, 13); // числа в диапазоне [13; 19]

	// Сгенерировать новую последовательность в R1
	double* X2 = R1.GetArrayFloat(10, 3);

	cout << "Array X2: ";
	for (int i = 0; i < 10; i++)
		cout << X2[i] << " ";
	cout << endl;

	delete[] X2;
}