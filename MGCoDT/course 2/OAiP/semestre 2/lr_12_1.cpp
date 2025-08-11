#include "pch.h"
#include <iostream>
#include <fstream>
using namespace std;

// Открыть/закрыть файл - класс ofstream
void OpenCloseFileOutput()
{
	ofstream outFile;
	outFile.open("myfile3.txt", ios::out);

	if (outFile)
	{
		// Работа с файлом
		// ...

		outFile.close();
	}
}
// Открыть, закрыть файл - класс ifstream
void OpenCloseFileInput()
{
	// открытие файла с помощью конструктора
	ifstream inFile("myfile6.txt", ios::in);

	if (inFile)
	{
		// Работа с файлом
		// ...
		inFile.close();
	}
}
// функция is_open(), открытие файла для записb в него
void DemoIsFileOpenOutput()
{
	ofstream os; // объявить объект класса ofstream
	string filename = "myfile6.txt";

	// попытка открыть файл
	os.open(filename);

	if (!os.is_open())
	{
		// файл не открыт
		cout << "File is not opened." << endl;
	}
	else
	{
		// Вывести сообщение
		cout << "File is opened. Working with file." << endl;
		cout << "Close the file. " << endl;

		// Работа с файлом
		// ...

		// закрыть файл
		os.close();
	}
}
// открытие файла для ввода из него
void DemoIsFileOpenInput()
{
	ifstream is; // объявить объект класса ifstream
	string filename = "myfile6.txt";

	// попытка открытия файла
	is.open(filename);

	if (!is.is_open())
	{
		cout << "File is not opened." << endl;
	}
	else
	{
		// вывести сообщение
		cout << "File is opened. Working with file" << endl;
		cout << "Close the file." << endl;
		is.close();
	}
}
void main()
{
	OpenCloseFileOutput();
	OpenCloseFileInput();
	DemoIsFileOpenOutput();
	DemoIsFileOpenInput();
}