/*Задание 1: Написать программу по обработке файла, состоящего из структур, содержащих информацию ЛР6. Средний балл рассчитать программно по введенным оценкам. Массив структур не использовать.
В программе реализовать следующие действия по обработке файла:
– создание;
– просмотр;
– добавление нового элемента;
– удаление (редактирование);
– решение индивидуального задания (первый уровень сложности задания).
Результаты выполнения индивидуального задания записать в текстовый файл.*/
#include "pch.h"
#include <iostream>
#include <fstream>
#include <iomanip>
#include <windows.h>
#include <string>
using namespace std;
struct student 
{
	char fio[100];
	int year;
	int group;
	int ball[4];
	float s;
	float sr() 
	{
		return (ball[0] + ball[1] + ball[2] + ball[3]) / 4; 
	}
};
int main()
{
	setlocale(LC_ALL, "Rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	ifstream fin("struct.txt");
	ofstream fout("result.txt");
	fout << "Ученики:" << endl;
	student stud[3];
	for (int i = 0; i < 3; i++)
	{
		fin.getline(stud[i].fio, 100);
		fin >> stud[i].year;
		fin >> stud[i].group;
		for (int j = 0; j < 4; j++)
		{
			fin >> stud[i].ball[j];
		}
		stud[i].s = stud[i].sr();
		fin.get();
	}
	int buk;
	cout << "Введите № группы ";
	cin >> buk;
	cout << "Студенты с оценкой 9 по информатике " << endl;
	for (int i = 0; i < 4; i++)
		if (stud[i].group == buk && stud[i].ball[2]==9)
		{
			cout << " " << stud[i].fio << " " << stud[i].year << " " << stud[i].group << " " << fixed << setprecision(2) << stud[i].s << endl;
			fout << " ФИО: " << stud[i].fio << " | Год рождения: " << stud[i].year << " | Группа № " << stud[i].group << " | Средний балл: " << fixed << setprecision(2) << stud[i].s << endl;
		}
	fout.close();
	fin.close();
	system("result.txt");
	system("pause");
	return 0;
}