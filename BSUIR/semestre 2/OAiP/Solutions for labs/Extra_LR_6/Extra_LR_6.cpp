#include <iostream>
#include <fstream>
#include <Windows.h>
#include <string>
#include <vector>

using namespace std;

void PrintVectorInColumn(vector<int> vec)
{
	for (int n : vec)
		cout << n << endl;
	cout << endl;
}

void PrintVectorInRow(vector<int> vec)
{
	for (int n : vec)
		cout << n << " ";
	cout << endl << endl;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

	vector<int> numbers;
	int count = 0;
	for (int i = -99; i <= 99; i++) {
		if (i != 0) {
			numbers.push_back(count < 10 ? 1 * i : -1 * i);
			count++;
			if (count >= 20)
				count = 0;
		}
	}

	ofstream fout; // поток вывода данных в файл
	fout.open("f.txt");
	for (int n : numbers)
		fout << n << endl;
	fout.close();

	vector<int> positiveNumbersFromFile;
	vector<int> negativeNumbersFromFile;
	string line = "";
	ifstream fin; // поток вывода данных из файла
	fin.open("f.txt");
	if (!fin.is_open())
		cout << "Ошибка открытия файла \"f.txt\"" << endl;
	else {
		int i = 0;
		while (getline(fin, line)) {
			if (!line.empty()) {
				int a = stoi(line);
				if (a > 0)
					positiveNumbersFromFile.push_back(a);
				else
					negativeNumbersFromFile.push_back(a);
			}
		}
	}
	fin.close();

	// PrintVectorInColumn(numbers);
	// PrintVectorInRow(positiveNumbersFromFile);
	// PrintVectorInRow(negativeNumbersFromFile);

	bool positive = true;
	fout;
	fout.open("g.txt");
	for (int i = 5; i < size(positiveNumbersFromFile); i += 5) {
		if (positive) {
			for (int j = i - 5; j < i; j++) {
				fout << positiveNumbersFromFile[j] << endl;
			}
			positive = false;
		}
		else {
			for (int j = i - 5; j < i; j++) {
				fout << negativeNumbersFromFile[j] << endl;
			}
			positive = true;
			i -= 5;
		}
	}
	fout.close();

	return 0;
}