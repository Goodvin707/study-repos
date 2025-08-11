#include "pch.h"
#include <iostream>
using namespace std;

// модуль <fstream> необходим для работы с файлами
#include <fstream>

// Функция, определяющая количество строк в файле.
// Имя файла задается входным параметром
int CountLinesInFile(char* filename)
{
	// 1. Объявить экземпляр F, который связан с файлом filename.
	// Файл открывается для чтения в текстовом формате.
	ifstream F(filename, ios::in);

	// 2. Проверка, существует ли файл
	if (!F)
	{
		return -1;
	}

	// 3. Вычислить количество строк в файле
	// 3.1. Объявить дополнительные переменные
	int count = 0;
	char buffer[1000]; // буфер для сохранения одной строки

	// 3.2. Цикл чтения строк.
	// Каждая строка файла читается функцией getline().
	// Проверка конца файла осуществляется функцией eof().
	while (!F.eof())
	{
		// Увеличить счетчик строк
		count++;

		// Считать одну строку в буфер
		F.getline(buffer, 1000);
	}

	// 4. Закрыть файл F
	F.close();

	// 5. Вернуть результат
	return count;
}

void main()
{
	// Определение количества строк в файле "TextFile1.txt"
	int nLines = CountLinesInFile((char*)"TextFile1.txt");

	// Вывод результата
	if (nLines == -1)
		cout << "Error opening file";
	else
		cout << "nLines = " << nLines << endl;
}