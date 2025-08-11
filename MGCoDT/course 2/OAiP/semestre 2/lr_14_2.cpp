#include "pch.h"
#include <iostream>
#include <string>
using namespace std;

// модуль <fstream> необходим для работы с файлами
#include <fstream>

int CountLinesInFile(string filename)
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


int GetStringsFromFileC(string filename, char*** _lines = nullptr)
{
	// 1. Дополнительные переменные
	char** lines;
	int n = CountLinesInFile(filename); // получить количество строк в файле

	// 2. Проверка, известно ли количество строк
	if (n == -1) return -1;

	// 3. Объявить файловую переменную
	ifstream F(filename); // открыть файл для чтения

	// 4. Проверка, открылся ли файл
	if (!F) return -1;

	// 5. Попытка выделить память для n строк
	try
	{
		lines = new char*[n];
	}
	catch (bad_alloc e)
	{
		// если невозможно выделить память, то выход
		cout << e.what() << endl; // вывести сообщение об ошибке
		F.close(); // закрыть файл
		return -1;
	}

	// 6. Цикл чтения строк и выделения памяти для них
	int len; // длина одной строки
	char buffer[1000]; // память, куда записывается одна строка из файла

	for (int i = 0; i < n; i++)
	{
		// 6.1. Считать строку из файла
		F.getline(buffer, 1000);

		// 6.2. Определить длину прочитанной строки
		for (len = 0; buffer[len] != '\0'; len++);

		// 6.3. Выделить память для len+1 символов
		lines[i] = new char[len + 1];

		// 6.4. Скопировать данные из buffer в lines[i]
		for (int j = 0; j < len; j++)
			lines[i][j] = buffer[j];
		lines[i][len] = '\0'; // добавить символ конца строки
	}

	// 7. Закрыть файл
	F.close();

	// 8. Записать результат
	*_lines = lines;
	return n;
}
void main()
{
	// Вывод списка строк файла на екран
	// 1. Объявить внутренние переменные
	int count; // количество строк
	char** lines = nullptr; // список строк типа char*

	// 2. Получить список строк типа char**
	count = GetStringsFromFileC("TextFile1.txt", &lines);

	// 3. Проверка, получен ли список
	if (count < 0)
	{
		cout << "Error" << endl;
		return;
	}

	// 3. Вывести список строк на экран
	for (int i = 0; i < count; i++)
	{
		cout << lines[i] << endl;
	}

	// 4. Освободить память, выделенную для каждой строки lines
	if (lines != nullptr)
		for (int i = 0; i < count; i++)
			delete lines[i];

	// 5. Освободить память, выделенную для массива lines
	if (lines != nullptr)
		delete[] lines;
}