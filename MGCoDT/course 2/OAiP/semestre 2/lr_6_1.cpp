/*Задание 1: Написать программу по созданию, просмотру, добавлению и решению поставленной задачи для однонаправленного линейного списка (стек и/или очередь).
Создать список из случайных чисел, вычислить среднее арифметическое и заменить им первый элемент.*/
#include "pch.h"
#include <iostream>
#include<Windows.h>
#include<time.h>
using namespace std;

template<class T>
class List
{
public:
	List();
	~List();
	void insert(T value, int index);
	void push_front(T data);
	void pop_front();
	void push_back(T data);
	void clear();
	int GetSize() { return Size; }
	T& operator[](const int index);
	void addToFront(List *Head, const T value);
private:
	template<class T>
	class Node
	{
	public:
		Node* pNext;
		T data;
		Node(T data = T(), Node *pNext = nullptr)
		{
			this->data = data;
			this->pNext = pNext;
		}
	};
	int Size;
	Node<T>* Head;
};

template<class T>
List<T>::List()
{
	Size = 0;
	Head = nullptr;
}
template<class T>
List<T>::~List()
{
	clear();
}
template<class T>
void List<T>::insert(T value, int index)
{
	if (index == 0)
	{
		push_front(value);
	}
	else
	{
		Node<T>* previous = this->Head;
		for (int i = 0; i < index - 1; i++)
		{
			previous = previous->pNext;
		}
		Node<T>* newNode = new Node<T>(value, previous->pNext);
		previous->pNext = newNode;
		Size++;
	}
}
template<class T>
void List<T>::push_front(T data)
{
	Head = new Node<T>(data, Head);
	Size++;
}
template<class T>
void List<T>::pop_front()
{
	Node<T>* temp = Head;
	Head = Head->pNext;
	delete temp;
	Size--;
}
template<class T>
void List<T>::push_back(T data)
{
	if (Head == nullptr)
	{
		Head = new Node<T>(data);
	}
	else
	{
		Node<T>* current = this->Head;
		while (current->pNext != nullptr)
		{
			current = current->pNext;
		}
		current->pNext = new Node<T>(data);
	}


	Size++;
}
template<class T>
void List<T>::clear()
{
	while (Size)
	{
		pop_front();
	}
}
template<class T>
T& List<T>::operator[](const int index)
{
	int count = 0;
	Node<T>* current = this->Head;
	while (current != nullptr)
	{
		if (count == index)
		{
			return current->data;
		}
		current = current->pNext;
		count++;
	}
}
template <typename T>
void List<T>:: addToFront(List *Head, const T value)
{
	List *Ptr = new List;
	Ptr->data = value;
	Ptr->next = Head;
	Head = Ptr;
	return Head;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	List<int> a;
	for (int i = 0; i < 15; i++)
	{
		a.push_back(rand() % 100);
	}

	for (int i = 0; i < a.GetSize(); i++)
	{
		cout << a[i] << "\n";
	}
	cout << endl;

	int sum = 0;
	for (int i = 0; i < a.GetSize(); i++)
	{
		sum += a[i];
	}
	cout << endl;

	int aver = 0;
	for (int i = 0; i < a.GetSize(); i++)
	{
		aver = sum / a.GetSize();
		sum += a[i];
	}

	cout << endl;
	cout <<"Ср. арифм."<< aver << endl;
	a[0] = aver;

	for (int i = 0; i < a.GetSize(); i++)
	{
		cout << a[i] << "\n";
	}
	cout << endl;
	return 0;
}