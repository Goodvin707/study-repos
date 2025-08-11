/*Задание 1: Реализовать код в отдельных файлах: описание класса (*.h), реализацию методов класса (*.cpp), демонстрацию использования объектов класса (*.cpp)

Описание класса. 
Запишите описание класса с именем BOOK, содержащего следующие поля: 
•	регистрационный номер; 
•	автор; 
•	название книги; 
•	количество страниц. 
Скройте элементы-данные от пользователя, предоставив интерфейс доступа к полям посредством открытых методов (предусмотрите объявление двух методов, один из которых присваивает значения полям класса, а другой – выводит значения этих свойств на экран). Объявите массив объектов созданного класса. 

Задание 2: Реализация методов класса. 
Напишите реализацию методов, предоставляющих доступ к данным класса. Отобразите в программе работу этих методов для объявленного ранее массива объектов. 

Задание 3: Работа с объектами. 
Добавьте в программу метод, который выводит название книги, если номер, введенный с клавиатуры, совпал с регистрационным номером объекта. 

Задание 4: Указатель на объект.
Добавьте в программу объявление указателя на объект и продемонстрируйте для него вызовы методов.*/

#include "pch.h"
#include "BOOK.h"
#include <iostream>
#include <string>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	int col;
	cout << "Введите кол-во объектов: ";
	cin >> col;
	BOOK *arr = new BOOK[col];
	for (int i = 0; i < col; i++)
	{
		arr[i].setRegname();
		arr[i].setName();
		arr[i].setBook();
		arr[i].setPage();
		
	}

	cout << endl;
	cout << "Введите регистрационный номер: ";
	float regname;
	cin >> regname;
	for (int i = 0; i < col; i++)
	{
		arr[i].check(regname);
	}
	system("pause");
	return 0;
}



BOOK.cpp
#include "pch.h"
#include "BOOK.h"
#include <iostream>
#include <string>
using namespace std;

	void BOOK::setName()
	{
		string Name;
		cout << "Введите автора книги: ";
		cin >> Name;
		name = Name;
	}
	void BOOK::setRegname()
	{
		float Regname;
		cout << "Введите регистрационный номер: ";
		cin >> Regname;
		this->regname = Regname;
	}
	void BOOK::setBook()
	{
		string Book;
		cout << "Введите название книги: ";
		cin >> Book;
		this->book = Book;
	}
	void BOOK::setPage()
	{
		int Page;
		cout << "Введите количество страниц: ";
		cin >> Page;
		this->page = Page;
	}
	string BOOK::getName()
	{
		return this->name;
	}
	float BOOK::getRegname()
	{
		return this->regname;
	}
	string BOOK::getBook()
	{
		return this->book;
	}
	void BOOK::check(float num)
	{
		if (this->regname == num)
		{
			cout << "Книга с рег-ым номером " << this->regname << " называется " << this->book << endl;
		}
	}


BOOK.h
#pragma once
#include "pch.h"
#include <iostream>
#include <string>
using namespace std;
class BOOK
{
private:
	float regname;
	string name;
	string book;
	int page;
public:
	void setName();
	void setRegname();
	void setBook();
	void setPage();
	string getName();
	float getRegname();
	string getBook();
	void check(float num);
};