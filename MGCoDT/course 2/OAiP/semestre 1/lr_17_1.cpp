/*Задание 1: Добавьте в класс, разработанный на предыдущих занятиях (ЛР №11 «Разработка и отладка алгоритмов и программ с применением декларирования классов, прямого и косвенного вызова методов»), возможность генерировать исключения в тех ситуациях, когда это целесообразно.*/
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
	int Data[3];
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
		bool ok1 = true;
		do
		{
			ok1 = true;
		try
		{
			cin >> tempFloat;
			if (tempFloat < 0)
			{
				ok1 = false;
				throw 124;
			}
		}
		catch (int m)
		{
			cout << "Неправильно!" << endl << "Введите правильные значения" << endl;
		}
		} while (!ok1);
		arr[i]->setCena(tempFloat);
		cout << "Дата поступления товара: ";
		bool ok = true;
		do {
			ok = true;
			try
			{
				cin >> temporaryInt[0] >> temporaryInt[1] >> temporaryInt[2];

				if (temporaryInt[0] > 31 || temporaryInt[1] > 12 || temporaryInt[2] < 0)
				{
					ok = false;
					throw 123;
				}
			}
			catch (int n)
			{
				cout << "Неправильно!" << endl << "Введите правильные значения" << endl;
			}
		} while (!ok);
		arr[i]->setData(temporaryInt[0], temporaryInt[1], temporaryInt[2]);
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