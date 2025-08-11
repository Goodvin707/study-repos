/*Задание 1: Динамические данные. 
Задайте динамический массив экземпляров класса в ЛР №11.

Задание 2: Инициализация массива объектов. 
Добавьте в разработанный класс три конструктора: 
• конструктор по умолчанию; 
• конструктор с параметрами; 
• конструктор копирования; и деструктор. 
Продемонстрируйте работоспособность изменённого класса.*/
#include "pch.h"
#include <iostream>
#include <math.h>
#include <string>
#include <Windows.h>
using namespace std;
class TOVAR
{
private:
	string Name;
	float Cena;
	int day;
	int month;
	int year;
public:
	TOVAR()
	{
		this->Name = "Яблоко";
		this->Cena = 50;
		this->day = 10;
		this->month = 11;
		this->year = 2002;
	}
	TOVAR(string name, float cena, int day,int month,int year)
	{
		this->Name = name;
		this->Cena = cena;
		this->day = day;
		this->month = month;
		this->year = year;
	}
	TOVAR(const TOVAR &tov) 
	{
		this->Name = tov.Name;
		this->Cena = tov.Cena;
		this->day = tov.day;
		this->month = tov.month;
		this->year = tov.year;
	}

	~TOVAR()
	{
		cout << "\nДеcтруктор сработал!\n";
	}
	void setName(string Name)
	{
		this->Name = Name;
	}
	void setCena(float Cena)
	{
		this->Cena = Cena;
	}
	void setData(int day, int month, int year)
	{
		this->day = day;
		this->month = month;
		this->year = year;
	}
	string getName()
	{
		return this->Name;
	}
	float getCena()
	{
		return this->Cena;
	}
	void getData()
	{
		cout << this->day << "." << this->month << "." << this->year << "." << endl;
	}
	int getday() 
	{
		return this->day;
	}
	int getmonth()
	{
		return this->month;
	}
	int getyear()
	{
		return this->year;
	}
};
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	int n;
	cout << "Введите количество товаров: ";
	cin >> n;
	TOVAR *arr = new TOVAR[n];
	for (int i = 0; i < n; i++)
	{
		string name;
		float koltov;
		int day, month, year;
		cout << "Введите наименование товара: ";
		cin >> name;
		cout << "Количество товара: ";
		cin >> koltov;
		cout << "Дата поступления товара: ";
		cin >> day >> month >> year;
		TOVAR testov(name, koltov, day, month, year);
		arr[i] = testov;
	}
	cout << endl;
	cout << "Введите наименование товара из списка: ";
	string tovar;
	cin >> tovar;
	for (int i = 0; i < n; i++)
	{
		if (tovar == arr[i].getName())
		{
			TOVAR tov(arr[i]);
			tov.getData();
		}
	}
	system("pause");
	return 0;
}