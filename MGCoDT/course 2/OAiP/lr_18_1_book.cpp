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