#include <iostream>
#include <new>
using namespace std;

// Динамическая структура данных "очередь"
template <typename T>
class Queue
{
private:
	T* p; // динамический массив
	int count; // количество элементов в очереди

public:
	// конструктор по умолчанию
	Queue()
	{
		count = 0; // очередь пустая
	}

	// конструктор копирования
	Queue(const Queue& obj)
	{
		// скопировать obj в текущий объект
		count = obj.count;

		try {
			// попытка выделить память для p
			p = new T[count];
			// заполнить значениями
			for (int i = 0; i < count; i++)
				p[i] = obj.p[i];
		}
		catch (bad_alloc e)
		{
			// если память не выделена, то вывести текст ошибки
			cout << e.what() << endl;
			count = 0; // создать пустую очередь
		}
	}

	// добавить элемент в очередь
	void push(T item)
	{
		T* p2; // объявить дополнительный указатель
		p2 = p; // перенаправить дополнительный указатель на p

		try {
			// попытка выделить новый фрагмент памяти для p, но на 1 больше
			p = new T[count + 1];

			// скопировать данные из участка на который указывает p2 (старые данные)
			// в участок, на который указывает p
			for (int i = 0; i < count; i++)
				p[i] = p2[i];

			// скопировать последний элемент
			p[count] = item;

			// увеличить количество элементов на 1
			count++;

			// освободить предварительно выделенную память
			if (count > 1)
				delete[] p2;
		}
		catch (bad_alloc e)
		{
			// если память не выделена
			cout << e.what() << endl; // вывести сообщение об ошибке

			// вернуть старый указатель на p
			p = p2;
		}
	}

	// вытянуть первый элемент из очереди
	T pop()
	{
		if (count == 0)
			return 0;

		// заполнить элемент, который вытягивается из очереди
		T item;

		item = p[0];

		// сформировать новый участок памяти, который на 1 меньше
		try {
			T* p2;

			// попытка выделить пам'ять
			p2 = new T[count - 1];

			count--; // уменьшить количество элементов в очереди

			// p=>p2
			for (int i = 0; i < count; i++)
				p2[i] = p[i + 1]; // копируются все кроме первого элемента

			  // освободить участок, на который указывает p
			if (count > 0)
				delete[] p;

			// перенаправить p на p2
			p = p2;

			// вернуть item
			return item;
		}
		catch (bad_alloc e)
		{
			// если память не выделилась, то вернуть 0
			cout << e.what() << endl;
			return 0;
		}
	}

	// операторная функция operator=(),
	// реализует присваивание объектов типа Queue
	Queue& operator=(const Queue& obj)
	{
		T* p2; // указатель на дополнительную память

		try {
			// попытка выделить новый участок памяти для p2
			p2 = new T[obj.count];

			// если память выделена успешно,
			// можно освобождать предварительно выделенную память для p
			if (count > 0)
				delete[] p;

			// скопировать obj в текущий объект
			p = p2; // перенаправить p на p2
			count = obj.count;

			// заполнить значениями
			for (int i = 0; i < count; i++)
				p[i] = obj.p[i];
		}
		catch (bad_alloc e)
		{
			// если память не выделилась, то вывести соответствующее сообщение
			cout << e.what() << endl;
		}
		return *this; // вернуть текущий объект
	}

	// деструктор
	~Queue()
	{
		if (count > 0)
			delete[] p;
	}

	// взять первый элемент из очереди не вытягивая его
	T GetItem()
	{
		if (count > 0)
			return p[0];
		else
			return 0;
	}

	// очистка очереди
	void clear()
	{
		if (count > 0)
		{
			delete[] p;
			count = 0;
		}
	}

	// проверка существования элементов в очереди
	bool IsEmpty()
	{
		return count == 0;
	}

	// количество элементов в очереди
	int GetN()
	{
		return count;
	}

	// метод, выводящий очередь
	void print(const char* objName)
	{
		cout << "Object: " << objName << endl;
		for (int i = 0; i < count; i++)
			cout << p[i] << "\t";
		cout << endl;
		cout << "---------------------" << endl;
	}
};

void main()
{
	Queue<int> Q1;
	Q1.print("Q1");

	Q1.push(5);
	Q1.print("Q1");

	Q1.push(8);
	Q1.push(11);
	Q1.push(17); // Q1 = {5,8,11,17}
	Q1.print("Q1");

	int d;
	d = Q1.GetItem();
	cout << "d = " << d << endl;

	Q1.print("Q1");

	Queue<int> Q2 = Q1;
	Q2.print("Q2");

	Queue<int> Q3;
	Q3 = Q1 = Q2;
	Q1.push(333);
	Q2.push(555);

	Q1.print("Q1");
	Q2.print("Q2");
	Q3.print("Q3");

	Q2.clear();
	if (Q2.IsEmpty())
		cout << "OK" << endl;
	else
		cout << "NO" << endl;

	cout << "n = " << Q3.GetN() << endl;
}