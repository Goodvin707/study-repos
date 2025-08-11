/*Задание 1: Использовать данные Лабораторной работы №3: предусмотреть ввод данных из файла. Полученные данные также вывести в файл.*/
#include "pch.h"
#include <iostream>
#include <string>
#include <fstream>
using namespace std;

class Word
{
	string Word;
	int Pages[10];
	int Mxpage;
public:
	void setWord(string word)
	{
		this->Word = word;
	}
	string getWord()
	{
		return Word;
	}

	void setPages(int i, int str)
	{
		this->Pages[i] = str;
	}
	int *getPages()
	{
		return Pages;
	}

	void setMxpage(int page)
	{
		this->Mxpage = page;
	}
	int getMxpage()
	{
		return Mxpage;
	}
};

int main()
{
	ofstream fout;
	fout.open("result.txt");
	ifstream fin;
	fin.open("read.txt");
	setlocale(LC_ALL, "ru");
	int countWords;
	fin >> countWords;
	Word *words = new Word[countWords];
	for (int i = 0; i < countWords; i++)
	{
		string word;
		getline(fin, word);
		fin >> word;
		words[i].setWord(word);
		int arr;
		for (int j = 0; j < 10; j++)
		{			
			fin >> arr;
			words[i].setPages(j,arr);
		}
		int page;
		fin >> page;
		words[i].setMxpage(page);
	}
	cout << "Введите предельную станицу: ";
	int pge;
	cin >> pge;
	for (int j = 0; j < countWords; j++)
	{
		int count = 0;
		for (int i = 0; i < 10; i++)
		{
			if (i >= pge) {
				fout << "слово: " << words[j].getWord() << " встречается более чем на " << pge << " страниц" << endl;
				break;
			}
		}
	}

	string str;
	cin >> str;
	for (int j = 0; j < countWords; j++)
	{
		int *array = words[j].getPages();
		fout << "слово: " << words[j].getWord() << " встречается  на стр. ";
		if (words[j].getWord() == str)
		{
			for (int i = 0; i < 10; i++)
			{
				fout << array[i] << " ";
			}
			fout << endl;
		}
	}
}