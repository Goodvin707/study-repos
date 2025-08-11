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

bool ChangeStringInFileC(string filename, int position, string str)
{
	// 1. Получить строки файла в виде списка
	char** lines; // список строк файла
	int count; // количество строк файла
	count = GetStringsFromFileC(filename, &lines); // получить список lines

	// 2. Проверка, корректно ли прочитан файл
	if (count < 0) return false;

	// 3. Проверка, корректна ли позиция 0 <= position < count
	if ((position < 0) || (position >= count)) return false;

	// 4. Запись строк lines в файл до позиции position
	ofstream F(filename); // открыть файл для записи

	// 5. Проверка, открылся ли файл корректно - функция is_open()
	if (!F.is_open()) return false;

	for (int i = 0; i < position; i++)
		F << lines[i] << endl; // вывести строку в файл

	  // 6. Запись строки с позиции position
	F << str.c_str() << endl; // здесь пишется строка str

	// 7. Запись строк после позиции position
	for (int i = position + 1; i < count - 1; i++)
		F << lines[i] << endl;

	// 8. Записать последнюю строку без символа '\n'
	F << lines[count - 1];

	// 9. Закрыть файл
	F.close();

	// 10. Освободить память, выделенную для строк
	for (int i = 0; i < count; i++)
		delete lines[i];

	// 11. Освободить указатели на строки
	delete[] lines;
}

bool SetStringsToFileS(string filename, string* lines, int count)
{
	// 1. Объявить дополнительные переменные
	ofstream F(filename); // открыть файл для записи

	// 2. Проверка, успешно ли открылся файл
	if (!F) return false;

	// 3. Запись строк в файл кроме последней строки
	for (int i = 0; i < count - 1; i++)
		F << lines[i] << endl;

	// 4. Последнюю строку записать как есть (без символа '\n')
	F << lines[count - 1];

	// 5. Закрыть файл
	F.close();

	// 6. Вернуть результат
	return true;
}

int GetStringsFromFileS(string filename, string** _lines)
{
	// 1. Дополнительные переменные
	string* lines; // временный список строк
	int n = CountLinesInFile(filename); // Получить количество строк в файле

	// 2. Проверка, правильно ли прочитаны строки из файла
	if (n == -1) return -1;

	// 3. Объявить файловую переменную и открыть файл filename для чтения
	ifstream F(filename);

	// 4. Проверка, открыт ли файл
	if (!F) return -1;

	// 5. Попытка выделить память для n строк типа string
	try
	{
		lines = new string[n];
	}
	catch (bad_alloc e)
	{
		cout << e.what() << endl; // вывести сообщение об ошибке
		F.close();
		return -2; // возврат с кодом -2
	}

	// 6. Чтение строк из файла и запись строк в список lines
	char buffer[1000]; // буфер для чтения строки

	for (int i = 0; i < n; i++)
	{
		// 6.1. Прочитать строку из файла в буфер buffer
		F.getline(buffer, 1000);

		// 6.2. Вычислить длину прочитанной строки
		int len;
		for (len = 0; buffer[len] != '\0'; len++);

		// 6.3. Записать buffer => lines[i], использовать метод assign().
		// Скопировать len байт из buffer в lines[i].
		lines[i].assign(buffer, len);
	}

	// 7. Закрыть файл
	F.close();

	// 8. Вернуть результат
	*_lines = lines;
	return n;
}

int main()
{
	// Запись массива строк в файл
	// 1. Объявить внутренние переменные
	int count; // количество строк
	string* lines = nullptr; // список строк типа string

	// 2. Сформировать строки
	try
	{
		// попытка выделить память для 5 строк
		lines = new string[5];
	}
	catch (bad_alloc e)
	{
		cout << e.what() << endl;
		return 0;
	}

	// записать в строки некоторый текст
	lines[0] = "#include <stdio.h>";
	lines[1] = "using namespace std";
	lines[2] = "void main()";
	lines[3] = "{";
	lines[4] = "}";

	// 3. Записать строки в файл TextFile2.txt
	if (SetStringsToFileS("TextFile2.txt", lines, 5))
		cout << "OK!" << endl;
	else
		cout << "Error." << endl;

	// 4. Освободить память, выделенную для массива lines
	if (lines != nullptr)
		delete[] lines;
}