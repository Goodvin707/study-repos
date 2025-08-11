#include "pch.h"
#include <iostream>
using namespace std;

// Шаблонный класс реализующий линейный поиск в одномерном массиве
template <class T>
class LSearch
{
private:
	// Внутренние переменные
	T* A; // массив
	int count; // количество элементов в массиве
public:
	// Конструктор без параметров
	LSearch()
	{
		A = nullptr;
		count = 0;
	}
	// Конструктор, получающий входной массив,
// которым инициализируются элементы внутреннего массива
	LSearch(T* _A, int _count)
	{
		// 1. Проверка, корректно ли значение _count
		if (_count <= 0)
		{
			A = nullptr;
			count = 0;
			return;
		}
		// 2. Установить новое количество элементов
		count = _count;

		// 3. Выделить память для массива A
		try
		{
			A = new T[count];
		}
		catch (bad_alloc e)
		{
			cout << e.what() << endl;
			return;
		}
		// 4. Скопировать A = _A
		for (int i = 0; i < count; i++)
			A[i] = _A[i];
	}
	// Конструктор копирования - перенаправление на конструктор с двумя параметрами
	LSearch(const LSearch& _A) :LSearch(_A.A, _A.count)
	{

	}
	T* Get(int* _count)
	{
		*_count = count;
		return A;
	}
	// Метод изменения массива в текущем экземпляре
	void Set(T* _A, int _count)
	{
		// 1. Проверка, корректно ли значение _count
		if (_count <= 0)
		{
			A = nullptr;
			count = 0;
			return;
		}

		// 2. Освободить память, выделенную для массива A текущего экземпляра
		if (count > 0)
			delete[] A;

		// 3. Установить новое количество элементов
		count = _count;

		// 4. Выделить новый фрагмент памяти для A
		try
		{
			A = new T[count];
		}
		catch (bad_alloc e)
		{
			cout << e.what() << endl;
			return;
		}

		// 5. Присвоить A = _A
		for (int i = 0; i < count; i++)
			A[i] = _A[i];
	}
	// Деструктор
	~LSearch()
	{
		if (count > 0)
		{
			delete[] A;
		}
	}
	// Переопределенный оператор присвоения
	LSearch& operator=(LSearch& _A)
	{
		// Вызвать метод Set() класса
		Set(_A.A, _A.count);

		// Возвратить текущий экземпляр
		return *this;
	}
	// Перегруженный метод IsItem()
// Определение, есть ли элемент key в массиве, который задан входным параметром
	bool IsItem(T* _A, int _count, T key)
	{
		for (int i = 0; i < _count; i++)
			if (_A[i] == key) // как только элемент найден, то выход из функции
				return true;
		return false;
	}

	// Определение, есть ли элемент key в массиве, который задан в экземпляре класса
	bool IsItem(T key)
	{
		// вызвать обобщенный метод с данными текущего экземпляра
		return IsItem(this->A, this->count, key);
	}
	// 2. Перегруженный метод NumOccurs()
// Вычислить количество вхождений элемента в массив, который задан входным параметром
	int NumOccurs(T* _A, int _count, T key)
	{
		int num = 0;
		for (int i = 0; i < _count; i++)
			if (_A[i] == key)
				num++;
		return num;
	}

	// Вычислить количество вхождений элемента в массив, который задан
	// в текущем экземпляре класса
	int NumOccurs(T key)
	{
		// Вызвать одноименный метод с текущими данными
		return NumOccurs(A, count, key);
	}
	// 3. Перегруженный метод GetPos()
// Вернуть массив позиций вхождения заданного элемента во входном массиве
	int* GetPos(T* _A, int _count, T key, int& nPos)
	{
		// 1. Проверка, корректно ли значение count
		if (_count <= 0)
		{
			return nullptr;
		}

		// 2. Объявить внутренние переменные
		int* P = nullptr; // Результирующий массив

		// 3. Вычислить количество вхождений nPos
		nPos = NumOccurs(_A, _count, key);

		// 4. Выделить память для результирующего массива P
		try
		{
			P = new T[nPos];
		}
		catch (bad_alloc e)
		{
			cout << e.what() << endl;
			return nullptr;
		}

		// 5. Цикл вычисления номеров позиций
		//    и формирования массива P
		int t = 0;
		for (int i = 0; i < _count; i++)
			if (_A[i] == key)
				P[t++] = i;

		// 6. Вернуть указатель на массив позиций
		return P;
	}

	// Вернуть массив позиций в массиве текущего экземпляра
	int* GetPos(T key, int& nPos)
	{
		// Вызвать одноименную функцию
		return GetPos(A, count, key, nPos);
	}
	// Метод, который выводит данные массива экземпляра на экран с комментарием text
	void Print(const char* text)
	{
		cout << text << endl;
		cout << "count = " << count << endl;
		for (int i = 0; i < count; i++)
			cout << A[i] << " ";
		cout << endl;
	}

};
int main()
{
	// Продемонстрировать работу класса LSearch
  // Экземпляр массива типа int - вызывается конструктор без параметров
	LSearch<int> L1;

	// Исследуемый массив чисел типа int
	int A[] = { 0, 2, 3, 5, 7, 3, 4, 8, 4, 0, 0, 2 };
	int count = 12; // количество элементов в массиве A

	// Добавить массив A к экземпляру L1
	L1.Set(A, count); // проверка метода Set

	// Определить, есть ли вобще элемент 3
	if (L1.IsItem(3))
	{
		// Если есть, то вывести количество вхождений элемента 3 в массиве A
		int k = L1.NumOccurs(3);
		cout << "k = " << k << endl;
	}
	L1.Print("L1:");

	// Проверка конструктора копирования
	LSearch<int> L2 = L1;
	L2.Print("L2:");

	// Проверка оператора присваивания
	LSearch<int> L3;
	L3 = L1;
	L3.Print("L3:");

	// Проверка метода Get() - заполнить новый массив значениями
	int* A2;
	int count2;
	A2 = L3.Get(&count2);

	// Вывести массив A2
	cout << "A2.count = " << count2 << endl;
	for (int i = 0; i < count2; i++)
		cout << A2[i] << " ";
	cout << endl;

	// Проверка метода GetPos() - получить массив позиций вхождения
	int nPos;
	int* P = L1.GetPos(0, nPos);
	cout << "nPos = " << nPos << endl;

	for (int i = 0; i < nPos; i++)
		cout << P[i] << " ";
	cout << endl;

	// После использования, нужно освободить память выделенную под массив P
	if (P != nullptr)
		delete[] P;

	// Проверка конструктора, получающего параметром входящий массив типа double
	double B[] = { 3.1, 2.8, 0.85, -10.5 }; // массив данных
	LSearch<double> L4(B, 4); // вызывается конструктор с двумя параметрами
	L4.Print("L4");

	// Определить количество вхождений числа 0.85 в массиве
	int k = L4.NumOccurs(0.85);
	cout << "k = " << k << endl;
}