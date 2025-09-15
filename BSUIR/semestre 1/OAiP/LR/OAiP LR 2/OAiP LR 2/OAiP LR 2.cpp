#include <iostream>
#include <algorithm>
#include <cstring>
#include <Windows.h>
using namespace std;

// Функция для рандомизации целого числа в диапазоне
int randInt(int start, int end) {  return  rand() % (end - start + 1) + start; }

// Функция для проверки, является ли символ гласной
bool isVowel(char c)
{
	c = toupper(c);
	return (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' || c == 'Y'); // Символы 'a', 'e', 'i', 'o', 'u', 'y' являются гласными
}

// Функция сортировки отбором по убыванию длины строк
void selectionSortDescendingLength(string* arr, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		int maxIdx = i;
		for (int j = i + 1; j < n; j++)
			if (arr[j].length() > arr[maxIdx].length())
				maxIdx = j;
		std::swap(arr[i], arr[maxIdx]);
	}
}

// Функция сортировки отбором по возрастанию символов
void selectionSortAscending(char* arr, int n) {
	for (int i = 0; i < n - 1; i++)
	{
		int minIdx = i;
		for (int j = i + 1; j < n; j++)
			if (arr[j] < arr[minIdx])
				minIdx = j;
		std::swap(arr[i], arr[minIdx]);
	}
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

	const int n = 100;
    char letters[n];

	int menu;
	int ind = 0;
	cout << "Выберите пункт меню\n";
	cout << "1. Заполнить массив вручную\n";
	cout << "2. Сгенерировать массив\n";
	cin >> menu;
	switch (menu)
	{
	case 1:
		cout << "Введите массив символов\n";
		while (ind < n)
		{
			cout << "Введите " << ind + 1 << "-й элемент: ";
			cin >> letters[ind];
			if (letters[ind] < 65 || letters[ind] > 90)
			{
				cout << "Некорректный символ. Символы должны быть в верхнем регистре принадлежать латинскому алфвиту.\n";
				continue;
			}
			ind++;
		}
		break;
	default:
		cout << "Массив до сортировки: ";
		for (int i = 0; i < n; i++)
		{
			letters[i] = randInt(65, 90); // 65 - 90 -- диапазон латинских символов в кодировке UTF-8
			cout << letters[i];
		}
		break;
	}
	cout << endl;

	string vowels[100];
	char consonants[100];
	int vowels_count = 0;
	int consonants_count = 0;

	for (int i = 0; i < n; i++) {
		if (isVowel(letters[i])) {
			int newI = i;
			vowels[vowels_count] = "";
			while (letters[newI] < n && isVowel(letters[newI]))
			{
				vowels[vowels_count] += letters[newI];
				newI++;
			}
			vowels_count++;
			i = newI;
		}
		else {
			consonants[consonants_count] = letters[i];
			consonants_count++;
		}
	}
	cout << endl;
	
	selectionSortDescendingLength(vowels, vowels_count);
	selectionSortAscending(consonants, consonants_count);

	cout << "Самые длинные последовательности гласных букв: ";
	for (int i = 0; i < vowels_count; i++) {
		cout << vowels[i] << "|";
	}
	cout << endl;

	cout << "Сортированные согласные буквы: ";
	for (int i = 0; i < consonants_count; i++) {
		cout << consonants[i];
	}
	cout << endl;
	return 0;
}