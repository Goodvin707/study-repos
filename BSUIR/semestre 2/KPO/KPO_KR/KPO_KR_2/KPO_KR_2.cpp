#include <iostream>
#include <conio.h>
#include <math.h>
#include <string>
#include <Windows.h>
using namespace std;

void validateDouble(double& a, string varName)
{
	string sA = "";
	do
	{
		try
		{
			if (varName == "")
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

	double x = 1, y = 1, fx = 1, rez;
	validateDouble(x, "x");
	validateDouble(y, "y");
	cout << "Выберите пункт меню\n";
	cout << "f(x):\n1. x^2\n2. exp\n";
	
	int menu = 0;
	cin >> menu;
	switch (menu)
	{
	case 2:
		fx = exp(1);
		break;
	default:
		fx = x * x;
		break;
	}

	if (x / y > 0) {
		rez = pow(fx + log(y), 3);
		cout << "(f(x) + ln(y))^3\tx/y > 0";
	}
	else if (x / y < 0) {
		rez = 2 / 3 + log(abs(sin(y)));
		cout << "2/3 + ln(|sin(y)|)\tx/y < 0";
	}
	else {
		rez = pow(pow(fx, 2), 1 / 3) + y;
		cout << "sqrt(f(x)^2) + y\tx/y = 0";
	}

	cout << "\nrez = " << rez << endl;
	cout << "\n\n\nНажмите любую клавишу для завершения программы.";
	_getch();
	return 0;
}