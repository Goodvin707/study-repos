/*Задание 1: Задачи шифровки. Составить программу, которая вводит строку с клавиатуры; признак окончания ввода – нажатие клавиши Enter, шифрует введенный текст в файл на диске по определенному алгоритму. Программа должна считывать эту строку из файла и далее дешифровать текст, выводя его на экран и записывая в выходной файл.
В программе реализовать следующие действия:
– ввод с клавиатуры исходной строки текста и запись в файл a.txt;
– считывание строки из файла и вывод на экран;
– шифровка текста;
– расшифровка.

Алгоритм шифровки:
Каждая буква заменяется на следующую в алфавите против часовой стрелки.*/
#include "pch.h"
#include <iostream>
#include <fstream>
#include <Windows.h>
#include <string>
using namespace std;
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");
	ofstream fout;
	string txt2;
	string txt;
	string alphabet = "яабвгдеёжзиклмнопрстуфхцчшщьыъэюяаЯАБВГДЕЁЖЗИКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯА";
	cout << "Введите текст для шифровки" << endl;
	getline(cin, txt);
	for (int i = 0; i < txt.length(); i++)
	{
		for (int j = 0; j < alphabet.length(); j++)
		{
			if (txt[i] == alphabet[j])
			{
				txt[i] = alphabet[j - 1];
				break;
			}
		}
	}
	fout.open("shifr.txt");
		for (int i = 0; i < txt.length(); i++)
		{
			fout << txt[i];
		}
	fout.close();
	cout << "Зашифрованный текст: " << endl;
	cout << txt << endl;
	ifstream fin;
	fin.open("shifr.txt");
	if (!fin.is_open())
	{
		cout << "АЩИБОЧКА!" << endl;
	}
	else
	{
		getline(fin, txt2);
	}
	fin.close();
	for (int i = 0; i < txt2.length(); i++)
	{
		for (int j = 0; j < alphabet.length(); j++)
		{
			if (txt2[i] == alphabet[j])
			{
				txt2[i] = alphabet[j + 1];
				break;
			}
		}
	}
	cout << "Текст после шифровки: " << endl;
	cout << txt2 << endl;
}