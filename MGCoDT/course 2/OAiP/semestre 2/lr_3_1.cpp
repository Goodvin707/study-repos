/*Задание 1: Разработать классы для описанных ниже объектов. Включить в класс методы set (…), get (…), show (…). Определить другие методы.

Word: Слово, Номера страниц, на которых слово встречается (от 1 до 10), Число страниц. Создать массив объектов.
Вывести: 
а) слова, которые встречаются более чем на N страницах; 
б) слова в алфавитном порядке; 
в) для заданного слова номера страниц, на которых оно встречается.*/

#include <iostream>
#include <string>
using namespace std;

class Word
{
	string Word;
	int Pages[10];
	int Mxpage;
public:
	void setWord()
	{
		cout << "Введите слово: ";
		string word;
		cin >> word;
		this->Word = word;
	}
	string getWord()
	{
		return Word;
	}

	void setPages()
	{

		int arr[10];
		for (int i = 0; i < 10; i++)
		{
			cout << "Введите страницу: ";
			cin >> arr[i];
			this->Pages[i] = arr[i];
		}
	}
	int *getPages()
	{
		return Pages;
	}

	void setMxpage()
	{
		cout << "Введите кол-во страниц: ";
		int page;
		cin >> page;
		this->Mxpage = page;
	}
	int getMxpage()
	{
		return Mxpage;
	}
};

int main()
{
	setlocale(LC_ALL, "ru");
	int countWords;
	cin >> countWords;
	Word *words = new Word[countWords];
	for (int i = 0; i < countWords; i++)
	{
		words[i].setWord();
		words[i].setPages();
		words[i].setMxpage();
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
				cout << "слово: " << words[j].getWord() << " встречается более чем на " << pge << " страниц" << endl;
				break;
			}
		}
	}

	string str;
	cin >> str;
	for (int j = 0; j < countWords; j++)
	{
		int *array = words[j].getPages();
		cout << "слово: " << words[j].getWord() << " встречается  на стр. ";
		if (words[j].getWord() == str)
		{
			for (int i = 0; i < 10; i++)
			{
				cout << array[i] << " ";
			}
			cout << endl;
		}
	}
}