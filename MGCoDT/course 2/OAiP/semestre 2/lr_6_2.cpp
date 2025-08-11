/*Задание 2: Создать список из случайных целых чисел. Удалить из списка элементы с повторяющимися более одного раза значениями.*/
#include "pch.h"
#include <iostream>
#include<time.h>

using namespace std;

template<typename T>
class List
{
public:
	List();
	~List();
	//удаление первого элемента в списке
	void pop_front();
	//добавление элемента в конец списка
	void push_back(T data);
	// очистить список
	void clear();
	// получить количество елементов в списке
	int GetSize() { return Size; }
	// перегруженный оператор [] 
	T& operator[](const int index);
	//добавление элемента в начало списка
	void push_front(T data);
	//удаление элемента в списке по указанному индексу
	void removeAt(int index);
	//удаление последнего элемента в списке
	void pop_back();

private:

	template<typename T>
	class Node
	{
	public:
		Node* pPrev;
		Node* pNext;
		T data;

		Node(T data = T(), Node* pNext = nullptr, Node* pPrev = nullptr)
		{
			this->data = data;
			this->pNext = pNext;
			this->pPrev = pPrev;
		}
	};
	int Size;
	Node<T>* head;
	Node<T>* tail;
};

template<typename T>
List<T>::List()
{
	Size = 0;
	tail = nullptr;
	head = nullptr;
}

template<typename T>
List<T>::~List()
{
	clear();
}

template<typename T>
void List<T>::push_back(T data)
{
	if (head == nullptr)
	{
		head = tail = new Node<T>(data);
	}
	else
	{
		Node<T>* temp = tail->pNext;
		temp = new Node<T>(data, nullptr, tail);
		tail->pNext = temp;
		tail = temp;
	}
	Size++;
}

template<typename T>
T& List<T>::operator[](const int index)
{
	if (index == 0)
	{
		return head->data;
	}
	if (Size / 2 > index)
	{
		Node<T>* search = head;
		for (int i = 0; i < index; i++)
		{
			search = search->pNext;
		}
		return search->data;
	}
	else
	{
		Node<T>* search = tail;
		for (int i = Size - 1; i > index; i--)
		{
			search = search->pPrev;
		}
		return search->data;
	}
}

template<typename T>
void List<T>::push_front(T data)
{
	if (head == nullptr)
	{
		head = tail = new Node<T>(data);
	}
	else
	{
		Node<T>* temp = head->pPrev;
		temp = new Node<T>(data, head, nullptr);
		head->pPrev = temp;
		head = temp;
	}
	Size++;
}

template<typename T>
void List<T>::removeAt(const int index)
{
	if (index == 0)
	{
		pop_front();
	}
	else if (index == Size - 1)
	{
		pop_back();
	}
	else if (Size / 2 > index)
	{
		Node<T>* previosly = head;
		for (int i = 0; i < index - 1; i++)
		{
			previosly = previosly->pNext;
		}

		Node<T>* ToDelete = previosly->pNext;
		Node<T>* next = ToDelete->pNext;
		previosly->pNext = ToDelete->pNext;
		next->pPrev = ToDelete->pPrev;
		delete ToDelete;
		Size--;
	}
	else if (index < Size)
	{
		Node<T>* next = tail;
		for (int i = Size - 1; i > index + 1; i--)
		{
			next = next->pPrev;
		}
		Node<T>* ToDelete = next->pPrev;
		Node<T>* Previosly = ToDelete->pPrev;
		Previosly->pNext = ToDelete->pNext;
		next->pPrev = ToDelete->pPrev;
		delete ToDelete;
		Size--;
	}

}

template<typename T>
void List<T>::pop_back()
{
	if (Size == 1)
	{
		delete head;
	}
	else
	{
		Node<T>* temp = tail;
		tail = tail->pPrev;
		tail->pNext = nullptr;
		delete temp;
	}
	Size--;
}

template<typename T>
void List<T>::pop_front()
{
	if (head == tail)
	{
		delete head;
	}
	else
	{
		Node<T>* temp = head;
		head = head->pNext;
		head->pPrev = nullptr;
		delete temp;
	}
	Size--;
}

template<typename T>
void List<T>::clear()
{
	while (Size)
	{
		pop_back();
	}
}

int main()
{
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	List<int> a;
	int size;
	cout << "Введите кол-во эл-ов списка: ";
	cin >> size;
	cout << "Список до сортировки: " << endl;
	for (int i = 0; i < size; i++)
	{
		a.push_front(rand() % 100);
	}
	for (int i = 0; i < size; i++)
	{
		cout << a[i] << "  " << endl;
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (a[i] == a[j])
			{
				for (int k = j; k < size - 1; k++)
				{
					a[k] = a[k + 1];
				}
				size--;
			}
		}
	}

	cout << "Список после сортировки: " << endl;

	for (int i = 0; i < a.GetSize(); i++)
	{
		cout << a[i] << "  " << endl;
	}
	return 0;
}