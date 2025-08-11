/*Задание 1: Описание класса. 
Запишите описание класса с именем TOVAR, содержащего следующие поля: 
• наименование товара; 
• количество единиц товара; 
• дата поступления товара (массив из трех чисел). 
Скройте элементы-данные от пользователя, предоставив интерфейс доступа к полям посредством открытых методов (предусмотрите объявление двух методов, один из которых присваивает значения полям класса, а другой – выводит значения этих свойств на экран). Объявите массив объектов созданного класса.

Задание 2: Реализация методов класса. 
Напишите реализацию методов, предоставляющих доступ к данным класса. Отобразите в программе работу этих методов для объявленного ранее массива объектов. 

Задание 3: Работа с объектами. 
Добавьте в программу метод, который выводит дату поступления товара, если наименование товара, введенное с клавиатуры, совпало с наименованием товара объекта. 

Задание 4: Указатель на объект.
Добавьте в программу объявление указателя на объект и продемонстрируйте для него вызовы методов.*/
#include "pch.h"
#include <iostream>
#include <math.h>
#include <string>
using namespace std;
class TOVAR
{
private:
	string name;
	float cena;
	int Data[2];
public:
	void setName(string textToSet)
	{
		this->name = textToSet;
	}
	void setCena(float textCena)
	{
		this->cena = textCena;
	}
	void setData(int day, int month, int year)
	{
		this->Data[0] = day;
		this->Data[1] = month;
		this->Data[2] = year;
	}
	string getName()
	{
		return this->name;
	}
	float setCena()
	{
		return this->cena;
	}
	void getData()
	{
		cout << this->Data[0] << "." << this->Data[1] << "." << this->Data[2] << "." << endl;
	}
	void check(string textCheck)
	{
		if (this->name == textCheck)
		{
			cout << this->Data[0] << "." << this->Data[1] << "." << this->Data[2] << "." << endl;
		}
	}
};
int main()
{
	TOVAR *arr[3];
	for (int i = 0; i < 3; i++)
	{
		setlocale(LC_ALL, "Rus");
		string temporaryString;
		float tempFloat;
		int temporaryInt[3];
		arr[i] = new TOVAR;
		cout << "Введите наименование товара: ";
		cin >> temporaryString;
		arr[i]->setName(temporaryString);
		cout << "Количество товара: ";
		cin >> tempFloat;
		arr[i]->setCena(tempFloat);
		cout << "Дата поступления товара: ";
		cin >> temporaryInt[0] >> temporaryInt[1]>> temporaryInt[2];
		arr[i]->setData(temporaryInt[0], temporaryInt[1],temporaryInt[2]);
	}
	cout << endl;
	cout << "Введите наименование товара: ";
	string name;
	cin >> name;
	for (int i = 0; i < 3; i++)
	{
		arr[i]->check(name);
	}
	system("pause");
	return 0;
}