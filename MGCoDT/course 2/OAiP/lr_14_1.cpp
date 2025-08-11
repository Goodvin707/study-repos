/*Задание 1: Множественное наследование. 
Разработайте базовый класс POSTAVKA. Элемент класса: 
• название фирмы-поставщика; 
• цена поставщика. 
Методы: 
• метод, осуществляющий ввод значений полей класса с клавиатуры;
• метод, осуществляющий вывод значений полей класса на экран. 
Разработайте класс NAVAR – производный от класса TOVAR1 и POSTAVKA. В этот класс добавьте метод, который рассчитывает прибыль и выводит на экран информацию о товаре. */
#include "pch.h"
#include <iostream>
#include <string>
using namespace std;

class TOVAR
{
protected:
	string name;
	int count;
	int date[3];
public:
	string getName()
	{
		return this->name;
	}
	TOVAR()
	{
		name = "-";
		count = 0;
		date[0] = 0;
		date[1] = 0;
		date[2] = 0;
	}
	TOVAR(string Nameitem, int Count, int Date1, int Date2, int Date3)
	{
		name = Nameitem;
		count = Count;
		date[0] = Date1;
		date[1] = Date2;
		date[2] = Date3;
	}
	TOVAR(const TOVAR &price)
	{
		this->name = price.name;
		this->count = price.count;
		this->date[0] = price.date[0];
		this->date[1] = price.date[1];
		this->date[2] = price.date[2];
	}
	~TOVAR()
	{
		cout << "<--деструктор-->" << endl;
	}
};

class POSTAVKA
{
protected:
	string firma;
	int cost;
public:
	POSTAVKA()
	{
		firma = "-";
		cost = 0;
	}
	POSTAVKA(string Firma, int Cost)
	{
		firma = Firma;
		cost = Cost;
	}
	POSTAVKA(const POSTAVKA &rise)
	{
		this->firma = rise.firma;
		this->cost = rise.cost;
	}
	string getFirma()
	{
		return this->firma;
	}
	int getCost()
	{
		return this->cost;
	}
	~POSTAVKA()
	{
		cout << "<--деструктор-->" << endl;
	}
};

class NAVAR : public TOVAR, public POSTAVKA
{
protected:
	int profit;
	int prodano;
	int price;
	int rem;
public:
	NAVAR() { }
	NAVAR(string Nameitem, int Count, int Date1, int Date2, int Date3, int Rem, int Price)
	{
		name = Nameitem;
		count = Count;
		date[0] = Date1;
		date[1] = Date2;
		date[2] = Date3;
		rem = Rem;
		price = Price;
	}
	void getProfit()
	{
		cout << "Продано: " << count - rem << endl;
		prodano += count - rem;
		cout << "Прибыль: " << prodano * price << endl;
	}
};


class TOVAR1 : public TOVAR
{
public:
	int price;
	int rem;
	TOVAR1()
	{
		name = "-";
		count = 0;
		date[0] = 0;
		date[1] = 0;
		date[2] = 0;
	}
	TOVAR1(string Nameitem, int Count, int Date1, int Date2, int Date3, int Price, int Remainder)
	{
		name = Nameitem;
		count = Count;
		date[0] = Date1;
		date[1] = Date2;
		date[2] = Date3;
		price = Price;
		rem = Remainder;
	}
	void getInform()
	{
		cout << "Дата поступления товара: " << this->date[0] << "." << date[1] << "." << date[2] << "." << endl;
		cout << "Цена при реализации товара: " << this->price << endl;
		cout << "Остаток товара: " << this->rem << endl;
	}
};

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите количество объектов: " << endl;
	int n;
	cin >> n;
	string NamE;
	int CounT;
	int DatE[3];
	int CosT;
	int ReM;
	string firma;
	int cost;

	NAVAR*obj = new NAVAR[n];
	for (int i = 0; i < n; i++)
	{
		cout << "Введите информацию о продукте: " << endl;
		cout << "Наименование товара: " << endl;
		cin >> NamE;
		cout << "Количество товара: " << endl;
		cin >> CounT;
		cout << "Дата поступления товара (день, месяц, год): " << endl;
		cin >> DatE[0];
		cin >> DatE[1];
		cin >> DatE[2];
		cout << "Цена при реализации: " << endl;
		cin >> CosT;
		cout << "Остаток товара: " << endl;
		cin >> ReM;
		cout << "Фирма: " << endl;
		cin >> firma;
		cout << "Цена поставщика: " << endl;
		cin >> cost;
		NAVAR obj1(NamE, CounT, DatE[0], DatE[1], DatE[2], ReM, CosT);
		POSTAVKA obj2(firma, cost);
		cout << "<--конструктор-->" << endl;
		obj[i] = obj1;
	}
	cout << endl;
	cout << "Введите название товара: " << endl;
	string name;
	cin >> name;
	for (int i = 0; i < n; i++)
	{
		if (name == obj[i].getName())
		{
			NAVAR date(obj[i]);
			cout << "<--конструктор копирования-->" << endl;
			date.getProfit();
		}
	}
	system("pause");
	return 0;
}