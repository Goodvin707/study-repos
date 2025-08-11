#include <windows.h>
#include <winnt.h>
#include <iostream>
#include <stdio.h>
#include <cstdlib>
#include <conio.h>
#include <string>
#include <cstring>
#include <math.h>
#include <time.h>
#include <fstream>
#include <vector>
#include "Order.h"
#include "Supplier.h"
#include "Logic.h"
using namespace std;

void goToXY(int x, int y) {
	COORD coord = { x, y };
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

const int hurdleCount = 4;

class Flappy_Bird {
	int hurdlePos[hurdleCount][2];
	int screenWidth = 120;
	int screenHeight = 25;
	int hurdleGap = 8;
	int betweenHurdleGap;

	int birdX = 17;
	int birdY = 15;

	int jump = 3;
	int score = 0;
public:
	Flappy_Bird() {
		srand(time(NULL));

		betweenHurdleGap = (screenWidth / hurdleCount) + 10;
		for (int i = 0; i < hurdleCount; i++) {
			hurdlePos[i][0] = betweenHurdleGap * (i + 1);

			int breakPos = rand() % (screenHeight / 3) + hurdleGap;
			hurdlePos[i][1] = breakPos;
		}
	}

	void printHurdle() {
		int count = 0;
		for (int i = 0; i < hurdleCount; i++) {
			for (int j = 0; j < screenHeight; j++) {

				if (hurdlePos[i][1] == j) count = hurdleGap;

				if (count == 0) {
					if (hurdlePos[i][0] < screenWidth) {
						goToXY(hurdlePos[i][0] + 1, j);
						cout << " ";

						goToXY(hurdlePos[i][0], j);
						cout << i;
					}
				}
				else {
					if ((count == 1 || count == hurdleGap) && hurdlePos[i][0] < screenWidth) {
						if (hurdlePos[i][0] + 1 > 0) {
							goToXY(hurdlePos[i][0] + 1, j);
							cout << "   ";
						}

						if (hurdlePos[i][0] - 1 > 0) {
							goToXY(hurdlePos[i][0] - 1, j);
							cout << "===";
						}
					}

					count--;
				}
			}

			hurdlePos[i][0]--;

			if (hurdlePos[i][0] == -1) {
				int prev;
				if (i == 0)
					prev = hurdleCount - 1;
				else
					prev = i - 1;

				hurdlePos[i][0] = hurdlePos[prev][0] + betweenHurdleGap;

				int breakPos = rand() % (screenHeight / 3) + hurdleGap;
				hurdlePos[i][1] = breakPos;

				for (int i = 0; i < screenHeight; i++) {
					goToXY(0, i);
					cout << " ";
				}
			}
		}
	}

	bool collisionCheck() {
		if (birdY == 0 || birdY + 3 == screenHeight) return true;

		for (int i = 0; i < hurdleCount; i++) {
			if (
				hurdlePos[i][0] == birdX &&
				(
					birdY >= hurdlePos[i][1] ||
					birdY + 3 <= (hurdlePos[i][1] + hurdleGap)
					)
				) {
				score++;
			}

			if (hurdlePos[i][0] >= birdX - 5 &&
				hurdlePos[i][0] <= birdX &&
				(
					birdY <= hurdlePos[i][1] ||
					birdY + 3 >= (hurdlePos[i][1] + hurdleGap)
					)
				) {
				return true;
			}
		}
		return false;
	}

	void clearBird() {
		goToXY(birdX - 5, birdY);
		cout << "   ";
		goToXY(birdX - 5, birdY + 1);
		cout << "      ";
		goToXY(birdX - 5, birdY + 2);
		cout << "       ";
	}

	void printScore() {
		goToXY(0, screenHeight + 4);
		cout << "Score: " << score;
	}

	void printBird() {
		goToXY(birdX - 5, birdY);		cout << " __";
		goToXY(birdX - 5, birdY + 1);	cout << "/-/o\\";
		goToXY(birdX - 5, birdY + 2);		cout << "\\_\\-/";
	}

	void printRoad() {
		for (int i = 0; i <= screenWidth; i++) {
			goToXY(i, screenHeight);		cout << "_";
			goToXY(i, screenHeight + 1);	cout << "/";
			goToXY(i, screenHeight + 2);	cout << "=";
		}
	}

	void play() {
		printRoad();
		int someDelay = 0;
		while (true) {
			if (GetAsyncKeyState(VK_SPACE)) {
				birdY -= jump;
			}

			printHurdle();
			printBird();
			printScore();

			if (collisionCheck()) break;

			Sleep(100);
			clearBird();
			birdY += 1;
		}
	}
};

int main()
{
	setlocale(LC_ALL, "Rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	ofstream fout;
	ifstream fin;
	vector<Supplier> SupplierList;
	vector<Product> ProductList;
	Supplier S;
	Product P;
	vector<string> Order;
	vector<string> SortSup;
	string postavshik;
	string postavshikk;
	string product1;
	string product2;
	string product3;
	string stoimost1;
	string stoimost2;
	string stoimost3;
	string menus;
	string menus1;
	int msi;
	int msi1;
	fin.open("DatabaseOfSuppliers.txt");
	do
	{
		system("cls");
		getline(fin, postavshik);
		getline(fin, product1);
		getline(fin, stoimost1);
		getline(fin, product2);
		getline(fin, stoimost2);
		getline(fin, product3);
		getline(fin, stoimost3);
		S.SetAll(postavshik, product1, product2, product3, stoimost1, stoimost2, stoimost3);
		SupplierList.push_back(S);
	} while (!fin.eof());
	fin.close();
	do {
		cout << "\t\t Menu" << endl;
		cout << "\t\t 1. Добавить поставщика" << endl;
		cout << "\t\t 2. Запросить поставку" << endl;
		cout << "\t\t 3. Посмотреть поставки" << endl;
		cout << "\t\t 4. Flapply Bird" << endl;
		cout << "\t\t 5. Настройки" << endl;
		cout << "\t\t 6. Справка" << endl;
		cout << "\t\t 7. Выход" << endl;
		do
		{
			try
			{
				cin >> menus;
				msi = stoi(menus);
				if (msi < 1 || msi > 7)
					throw 1;
				break;
			}
			catch (invalid_argument)
			{
				cout << "Ошибка!" << endl;
			}
			catch (int a)
			{
				cout << "Ошибка!" << endl;
			}
		} while (true);
		string tname;
		string tstoimost;
		int index = 0;
		string temp;
		switch (msi)
		{
		case 1:
			// Добавить поставщика
			system("cls");
			S = CreateSupplier(S);
			fout.open("DatabaseOfSuppliers.txt", ios::out | ios::app);

			fout << endl;
			fout << S.getPostavshik() << endl;
			fout << S.getProduct1() << endl;
			fout << S.getStoimost1() << endl;
			fout << S.getProduct2() << endl;
			fout << S.getStoimost2() << endl;
			fout << S.getProduct3() << endl;
			fout << S.getStoimost3();

			fout.close();
			fin.open("DatabaseOfSuppliers.txt");
			SupplierList.clear();
			do
			{
				system("cls");
				getline(fin, postavshik);
				getline(fin, product1);
				getline(fin, stoimost1);
				getline(fin, product2);
				getline(fin, stoimost2);
				getline(fin, product3);
				getline(fin, stoimost3);
				S.SetAll(postavshik, product1, product2, product3, stoimost1, stoimost2, stoimost3);
				SupplierList.push_back(S);
			} while (!fin.eof());
			fin.close();
			break;
		case 2:
			// Запросить поставку
			system("cls");
			for (int i = 0; i < SupplierList.size(); i++)
			{
				SupplierList[i].PrintInfo();
				cout << "---------------------------" << endl;
			}
			cout << "Введите продукт: ";
			cin.ignore();
			getline(cin, tname);
			cout << "Введите цену: ";
			do
			{
				try
				{
					getline(cin, tstoimost);
					if (stoi(tstoimost) < 0 || stoi(tstoimost) > 10000)
						throw 1;
					break;
				}
				catch (invalid_argument) { cout << "Ошибка!" << endl; }
				catch (out_of_range) { cout << "Ошибка!" << endl; }
				catch (int a) { cout << "Ошибка!" << endl; }
			} while (true);
			cout << endl;
			for (int i = 0; i < SupplierList.size(); i++)
			{
				SortSup.push_back(PrintSuppliers(SupplierList[i], tname, tstoimost));
			}
			cout << "Совершить заказ у фирмы: ";
			getline(cin, postavshikk);
			for (int i = 0; i < SupplierList.size(); i++)
			{
				if (tname == SupplierList[i].getProduct1())
				{
					if (tstoimost < SupplierList[i].getStoimost1())
					{
						cout << "Ошибка!" << endl;
						Sleep(2000);
						break;
					}
				}
				if (tname == SupplierList[i].getProduct2())
				{
					if (tstoimost < SupplierList[i].getStoimost2())
					{
						cout << "Ошибка!" << endl;
						Sleep(2000);
						break;
					}
				}
				if (tname == SupplierList[i].getProduct3())
				{
					if (tstoimost < SupplierList[i].getStoimost3())
					{
						cout << "Ошибка!" << endl;
						Sleep(2000);
						break;
					}
				}
				if (postavshikk == SupplierList[i].getPostavshik())
				{
					Order.push_back(CreateOrder(SortSup, SupplierList[i], tname, postavshikk));
					break;
				}
			}
			
			fout.open("OrderDataBase.txt", ios::out | ios::app);
			fout << Order[Order.size() - 1] << endl;
			fout.close();
			
			SupplierList.clear();
			fin.open("DatabaseOfSuppliers.txt");
			do
			{
				system("cls");
				getline(fin, postavshik);
				getline(fin, product1);
				getline(fin, stoimost1);
				getline(fin, product2);
				getline(fin, stoimost2);
				getline(fin, product3);
				getline(fin, stoimost3);
				S.SetAll(postavshik, product1, product2, product3, stoimost1, stoimost2, stoimost3);
				SupplierList.push_back(S);
			} while (!fin.eof());
			fin.close();
			break;
		case 3:
			// Посмотреть поставки
			system("cls");
			fin.open("OrderDataBase.txt");
			Order.clear();
			do
			{
				getline(fin, temp);
				Order.push_back(temp);
				index++;
			} while (!fin.eof());
			PrintOrders(Order);
			fin.close();
			system("pause");
			system("cls");
			break;
		case 4:
			// Flappy Bird
			COORD coord;
			SetConsoleDisplayMode(GetStdHandle(STD_OUTPUT_HANDLE), CONSOLE_FULLSCREEN_MODE, &coord);
			while (true) {
				Flappy_Bird fb;
				fb.play();
				goToXY(30, 30);
				cout << "Начать заново? (Y/N)";
				char ch;
				cin >> ch;
				if (ch == 'N' || ch == 'n') {
					system("cls");
					break;
				}
				system("cls");
			}
			break;
		case 5:
			// Настройки
			system("cls");
			do
			{
				cout << "\t Выберите цвет консоли" << endl;
				cout << "\t 1. Стандарт" << endl;
				cout << "\t 2. Чёрное по белому" << endl;
				cout << "\t 3. Матрица" << endl;
				cout << "\t 4. Буйство красок" << endl;
				cout << "\t 5. Bloodlust" << endl;
				cout << "\t 0. Выход" << endl;
				do
				{
					try
					{
						cin >> menus1;
						msi1 = stoi(menus1);
						if (msi1 < 0 || msi1 > 5)
							throw "1";
						break;
					}
					catch (invalid_argument) { cout << "Ошибка!" << endl; }
					catch (string a) { cout << "Ошибка!" << endl; }
				} while (true);
				switch (msi1)
				{
				case 1:
					system("cls");
					system("color 07");
					break;
				case 2:
					system("cls");
					system("color F0");
					break;
				case 3:
					system("cls");
					system("color 0A");
					break;
				case 4:
					system("cls");
					system("color AE");
					break;
				case 5:
					system("cls");
					system("color CB");
					break;
				}
			} while (msi1 != 0);
			system("cls");
			break;
		case 6:
			// Справка
			cout << "-------------------------------------\n© УО «Минский государственный колледж электроники»\nРазработчик: Сушко Алексей Юльевич\n2021 год\n-------------------------------------" << endl;
			system("pause");
			system("cls");
			break;
		case 7:
			// Выход
			exit(0);
		default: cout << "Выбран несуществующий пункт меню" << endl; Sleep(2000); system("cls");
			break;
		}
	} while (msi != 0 || msi == 0);
	return 0;
}