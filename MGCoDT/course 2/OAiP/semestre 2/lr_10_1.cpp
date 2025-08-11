/*Задание 1: Разработать обобщенный класс, содержащий средства, которые реализуют алгоритм сортировки выбором. Продемонстрировать работу класса в функции main().*/
#include "pch.h"
#include <iostream>
#include <string>
using namespace std;

// Шаблонный класс, реализующий алгоритм сортировки выбором в одномерном массиве
template <class T>
class SortSelection
{
private:
	T* A; // внутренний одномерный массив
	int count; // количество элементов в массиве
	// Внутренний метод копирования внешнего массива во внутренний массив A
	void Copy(T* _A, int _count)
	{
		// 1. Проверить, коректно ли _count
		if (_count <= 0)
		{
			A = nullptr;
			count = 0;
			return;
		}

		try
		{
			// 2. Установить новое количество элементов
			count = _count;

			// 3. Выделить память для внутреннего массива A
			A = new T[count];
		}
		catch (bad_alloc e)
		{
			cout << e.what() << endl;
			return;
		}

		// 4. Скопировать элементы A = _A
		for (int i = 0; i < count; i++)
			A[i] = _A[i];
	}
public:
// Конструкторы класса
// Конструктор без параметров
	SortSelection()
	{
		A = nullptr;
		count = 0;
	}

	// Конструктор, который инициализирует внутренние данные внешним массивом
	SortSelection(T* _A, int _count)
	{
		Copy(_A, _count); // скопировать данные во внутренний массив
	}

	// Конструктор копирования - перенаправить на конструктор с 2 параметрами
	SortSelection(const SortSelection& obj) :SortSelection(obj.A, obj.count)
	{
	}
	// Методы доступа к внутреннему массиву класса SortSelection
// Получить количество элементов массива A и указатель на массив A
	T* Get(int* _count)
	{
		*_count = count;
		return A;
	}

	// Установить новый массив в экземпляре класса
	void Set(T* _A, int _count)
	{
		// Освободить память, предварительно выделенную под массив A
		if (count > 0)
		{
			delete[] A;
			count = 0;
		}

		// Скопировать A = _A
		Copy(_A, _count);
	}
	// Деструктор
	~SortSelection()
	{
		
	}
	// Операторная функция operator=() - необходима для присваивания массивов
	SortSelection& operator=(SortSelection& obj)
	{
		// Вызвать метод Set() класса
		Set(obj.A, obj.count);

		// Вернуть текущий экземпляр
		return *this;
	}
	// Метод сортировки Sort
// Метод получает параметр order,
// - если order=true - сортировка по возрастанию,
// - если order=false - сортировка по убыванию.
	void Sort(bool order)
	{
		int i, j, k;
		T x;

		for (i = 0; i < count; i++) // i - номер шага
		{
			k = i;
			x = A[i];

			for (j = i + 1; j < count; j++)
				if (order)
				{
					if (A[j] < x) // поиск наименьшего элемента
					{
						k = j; // k - позиция наименьшего элемента в массиве A
						x = A[j];
					}
				}
				else
				{
					if (A[j] > x) // поиск наибольшего элемента
					{
						k = j; // k - позиция наибольшего элемента в массиве A
						x = A[j];
					}
				}

			A[k] = A[i];
			A[i] = x;
		}
	}
	// Метод, который выводит внутренний массив на экран
	void Print(string comment)
	{
		cout << comment << endl;
		for (int i = 0; i < count; i++)
			cout << A[i] << " ";
		cout << endl;
	}

};

int main()
{
	// Тестирование класса SortSelection()
// 1. Для массива типа int
// 1.1. Объявить переменные
	int AI[] = { 2, 5, 1, 8, 3, 5, 4, 3, 7 };
	SortSelection<int> objInt(AI, 9);
	objInt.Print("objInt:");

	// Отсортировать массив в порядке убывания
	objInt.Sort(false);
	objInt.Print("objInt after sorting:"); // вывести массив

	// 1.2. Тест конструктора копирования
	SortSelection<int> objInt2 = objInt;
	objInt2.Print("objInt2:");

	// 1.3. Тест операторной функции operator=()
	SortSelection<int> objInt3;
	objInt3 = objInt;
	objInt3.Print("objInt3:");

	// 1.4. Тест метода Set()
	int AI2[] = { 0,5,2,3,3,4,5 };
	objInt2.Set(AI2, 7);
	objInt2.Print("objInt2:");

	// 1.5. Тест метода Get()
	int* AI3;
	int count3;
	AI3 = objInt3.Get(&count3);
	cout << "Array AI3:" << endl;
	for (int i = 0; i < count3; i++)
		cout << AI3[i] << " ";
	cout << endl;

	// 2. Тестирование для массива типа char
	char AC[] = { 'a', 'f', 'c', 'x', 'w', 'p' };
	SortSelection<char> objChar;
	objChar.Set(AC, 6); // метод Set()
	objChar.Print("objChar before sorting:");

	// отсортировать массив objChar
	objChar.Sort(false);
	objChar.Print("objChar after sorting:");
}