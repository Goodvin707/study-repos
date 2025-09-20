#include <iostream>
#include <conio.h>
#include <math.h>
#include <string>
#include <Windows.h>
using namespace std;

void validateInt(int& a, string varName)
{
	string sA = "";
	do
	{
		try
		{
			if (varName != "")
				cout << "\tВведите " << varName << ": ";
			cin >> sA;
			a = stoi(sA);
			break;
		}
		catch (invalid_argument ex) {
			cout << "Введенные данные не являются числом" << endl;
		}
		catch (out_of_range ex) {
			cout << "Введено слишком большое число" << endl;
		}
	} while (true);
}

void validateDouble(double& a, string varName)
{
	string sA = "";
	do
	{
		try
		{
			cout << "\tВведите " << varName << ": ";
			cin >> sA;
			a = stod(sA);
			break;
		}
		catch (invalid_argument ex) {
			cout << "Введенные данные не являются числом" << endl;
		}
		catch (out_of_range ex) {
			cout << "Введено слишком большое число" << endl;
		}
	} while (true);
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

	double x = 6.251, y = 0.827, z = 25.001, a, b, c, rezult;
	cout << "Выберите пункт меню\n";
	cout << "1. Ввести x, y, z\n";
	cout << "2. Заполнить x, y, z значениями по умолчанию (x = 6.251, y = 0.827, z = 25.001)\n";
	int menu;
	validateInt(menu, "");
	if (menu == 1)
	{
		validateDouble(x, "x");
		validateDouble(y, "y");
		validateDouble(z, "z");
	}

	a = pow(2, pow(y, x));
	b = pow(pow(3, x), y);
	c = y * (atan(z) - 1 / 3) / abs(x) + 1 / (y * y + 1);
	rezult = a + b - c - 292.489;

	cout << "\n x = " << x << "\n y = " << y << "\n z = " << z << endl;
	cout << "Rezult = " << rezult << endl;
	cout << "\n\n\nНажмите любую клавишу для завершения программы.";

	_getch();
	return 0;
}