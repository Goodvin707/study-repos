/*Задание 1: Написать программу по обработке массива структур, содержащего следующую информацию о студентах:
– фамилия и инициалы;
– год рождения;
– номер группы;
– оценки за семестр: физика, математика, информатика, химия;
– средний балл.
Организовать ввод исходных данных, средний балл рассчитать по введенным оценкам.
11. Распечатать анкетные данные студентов интересующей вас группы, имеющих оценку 9 по информатике.*/
#include "pch.h"
#include <iostream>
#include <iomanip>
using namespace std;
struct student
{
	char fio[20];
	int year;
	int group;
	int fizika[1];
	int matem[1];
	int infa[1];
	int himia[1];
	float sr()
	{
		return (fizika[0] + matem[0] + infa[0] + himia[0]) / 4.;
	}
};
int main() 
{
	setlocale(LC_ALL, "Russian");
	student stud[3];
	for (int i = 0; i < 3; i++)
	{
		cout << "Введите фамилию " << i + 1<< " студента ";
		cin >> stud[i].fio;
		cout << "Введите год рождения " << i + 1 << " студента ";
		cin >> stud[i].year;
		cout << "Введите № группы " << i + 1 << " студента ";
		cin >> stud[i].group;
		cout << "Введите оценку " << i + 1 << " студента по физике ";
		cin >> stud[i].fizika[0];
		cout << "Введите оценку " << i + 1 << " студента по математике ";
		cin >> stud[i].matem[0];
		cout << "Введите оценку " << i + 1 << " студента по информатике ";
		cin >> stud[i].infa[0];
		cout << "Введите оценку " << i + 1 << " студента по химии ";
		cin >> stud[i].himia[0];

		cout << "средняя оценка " << i + 1 << "студента =" << fixed << setprecision(2) << stud[i].sr() << "\n";
	}
	{
		cout << "Студенты с оценкой 9 по информатике " << endl;
		for (int i = 0; i < 3; i++)
			if (stud[i].infa[0] == 9)
				cout << stud[i].fio << " " << stud[i].year << endl;
	}
	system("pause");
	return 0;
}