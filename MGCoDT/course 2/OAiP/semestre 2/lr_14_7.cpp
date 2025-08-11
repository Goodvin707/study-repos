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

bool RemoveStringFromFileByIndex(string filename, int position)
{
	// 1. Проверка, правильно ли указана строка
	if (position < 0) return false;

	// 2. Дополнительные переменные
	string* lines; // список строк
	int n; // количество строк в списке (файле)

	// 3. Прочитать количество строк в файле
	n = CountLinesInFile(filename); // вызов функции из пункта 2

	// 4. Проверка, прочитался ли файл filename
	if (n == -1) return false;

	// 5. Проверка, корректно ли значение position
	if (position >= n) return false;

	// 6. Получить список строк lines типа string*
	n = GetStringsFromFileS(filename, &lines); // функция из пункта 4

	// 7. Удалить строку в позиции position
	for (int i = position; i < n - 1; i++)
		lines[i] = lines[i + 1];

	// 8. Уменьшить общее количество строк
	n--;

	// 9. Записать список в файл - использовать функцию SetStringsToFileS()
	bool res = SetStringsToFileS(filename, lines, n); // запись списка

	// 10. Освободить массив lines
	if (n > 0) delete[] lines;

	// 11. Вернуть результат
	return res;
}

bool InsertStringToFile(string filename, string str, int position)
{
	// 1. Объявить дополнительные переменные
	int count;
	string* lines = nullptr; // список строк файла

	// 2. Получить список строк из файла - вызов функции, описанной в п.4
	count = GetStringsFromFileS(filename, &lines);

	// 3. Проверка, происходит ли нормально процесс чтения строк
	if ((count < 0)) return false;

	// 4. Проверка, корректно ли значение position.
	// Если positon==count, то строка добавляется в конец файла.
	if ((position < 0) || (position > count)) return false;

	// 5. Создать новый список lines2, в котором на 1 элемент больше
	string* lines2 = nullptr;
	try
	{
		// попытка выделить память для массива lines2
		lines2 = new string[count + 1];
	}
	catch (bad_alloc e)
	{
		// если попытка выделения памяти неудачна, то завершить программу
		cout << e.what() << endl;
		if (lines != nullptr) // освободить память
			delete[] lines;
		return false;
	}

	// 6. Скопировать lines=>lines2
	// 6.1. Сначала скопировать до позиции position
	for (int i = 0; i < position; i++)
		lines2[i] = lines[i];

	// 6.2. Добавить к lines2[position] строку str
	lines2[position] = str;

	// 6.3. Скопировать следующие строки
	for (int i = position; i < count; i++)
		lines2[i + 1] = lines[i];

	// 7. Увеличить общее количество строк на 1
	count++;

	// 8. Записать строки lines в файл
	bool res = SetStringsToFileS(filename, lines2, count);

	// 9. Освободить память, выделенную для строк lines, lines2
	if (lines != nullptr) delete[] lines;
	if (lines2 != nullptr) delete[] lines2;

	// 10. Вернуть результат
	return res;
}

bool SwapStringsInFile(string filename, int pos1, int pos2)
{
	// 1. Проверка, корректны ли значения pos1, pos2
	if ((pos1 < 0) || (pos2 < 0)) return false;

	// 2. Объявить дополнительные переменные
	int count;
	string* lines = nullptr; // массив строк файла
	string s;

	// 3. Получить массив строк файла
	count = GetStringsFromFileS(filename, &lines); // функция из п.4

	// 4. Проверка, произошло ли успешно чтение из файла
	if (count < 0) return false;

	// 5. Проверка, лежат ли значения pos1, pos2 в пределах count
	if (pos1 >= count) return false;
	if (pos2 >= count) return false;

	// 6. Поменять местами строки lines[pos1] и lines[pos2]
	s = lines[pos1];
	lines[pos1] = lines[pos2];
	lines[pos2] = s;

	// 7. Записать массив lines обратно в файл
	bool res = SetStringsToFileS(filename, lines, count);

	// 8. Освободить память, выделенную для массива lines
	if (lines != nullptr)
		delete[] lines;

	// 9. Вернуть результат
	return res;
}

bool ReverseStringsInFile(string filename)
{
	// 1. Объявить дополнительные переменные
	int count;
	string* lines = nullptr;
	string s;

	// 2. Считать строки из файла
	count = GetStringsFromFileS(filename, &lines);

	// 3. Проверка, считались ли строки корректно
	if (count <= 0) return false;

	// 4. Реверсирование массива lines
	for (int i = 0; i < count / 2; i++)
	{
		s = lines[i];
		lines[i] = lines[count - i - 1];
		lines[count - i - 1] = s;
	}

	// 5. Запись массива lines в файл
	bool res = SetStringsToFileS(filename, lines, count);

	// 6. Освободить память, выделенную для массива lines
	if (lines != nullptr) delete[] lines;

	// 7. Вернуть результат
	return res;
}

bool SortStringsInFile(string filename)
{
	// 1. Объявить дополнительные переменные
	int count;
	string* lines = nullptr;
	string s;

	// 2. Считать строки из файла в масив lines
	count = GetStringsFromFileS(filename, &lines); // функция описана в п.4

	// 3. Проверка, корректно ли считались строки
	if (count < 0) return false;

	// 4. Сортировка строк в файле по возрастанию методом вставки
	for (int i = 0; i < count - 1; i++)
		for (int j = i; j >= 0; j--)
			if (lines[j] > lines[j + 1])
			{
				s = lines[j];
				lines[j] = lines[j + 1];
				lines[j + 1] = s;
			}

	// 5. Записать отсортированный массив lines в файл
	bool res = SetStringsToFileS(filename, lines, count);

	// 6. Освободить память, выделенную для массива lines
	if (lines != nullptr) delete[] lines;

	// 7. Вернуть результат
	return res;
}

void main()
{
	// Сортировка строк в файле
	string filename = "TextFile4.txt"; // исходный файл

	if (SortStringsInFile(filename))
	{
		cout << "OK!!!";
	}
	else
	{
		cout << "Error";
	}
}