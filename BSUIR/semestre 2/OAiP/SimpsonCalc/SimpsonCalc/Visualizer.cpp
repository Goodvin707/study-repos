#include "Visualizer.h"

// Вывод справки для мат. выражений
void displayHelp() {
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	cout << "\t\tИнформация\n";
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << "______________________________________________________________________\n";
	SetConsoleTextAttribute(handle, FOREGROUND_RED);
	cout << "Список математических функций и констант:\n";

	cout << "\t--> a + b\n";
	cout << "\t--> a - b\n";
	cout << "\t--> a * b\n";
	cout << "\t--> a / b\n";
	cout << "\t--> a % b\n";
	cout << "\t--> a ^ b\n\n";
	cout << "\t--> factorial(a) -- факториал числа\n";
	cout << "\t--> opposite(a) -- число с противоположным знаком\n\n";

	cout << "\t--> abs(x) -- |x|, модуль\n";
	cout << "\t--> sqrt(x) -- квадратный корень\n";
	cout << "\t--> exp(x) -- экспонента\n";
	cout << "\t--> ln(x) -- натуральный логарифм\n";
	cout << "\t--> log10(x) -- десятичный логарифм\n\n";

	cout << "\t--> sin(x) -- синус\n";
	cout << "\t--> cos(x) -- косинус\n";
	cout << "\t--> tg(x) -- тангенс\n";
	cout << "\t--> ctg(x) -- котангенс\n";
	cout << "\t--> arcsin(x) -- арксинус\n";
	cout << "\t--> arccos(x) -- арккосинус\n";
	cout << "\t--> arctg(x) -- арктангенс\n";
	cout << "\t--> arcctg(x) -- арккотангенс\n";

	cout << "\t--> x\n";
	cout << "Ввод распознает различные синонимы функций, таких как asin и arcsin.\nВ выражении должна присутствовать переменная x.\n";
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << "______________________________________________________________________\n";
}

// Вывести выражение
void displayExpression(string expr)
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	for (int i = 0; i < expr.length(); i++)
	{
		if (expr[i] == 'x') {
			SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
			cout << expr[i];
		}
		else if (expr[i] == '+' || expr[i] == '-' || expr[i] == '*' || expr[i] == '/' || expr[i] == '^' || expr[i] == '&' || expr[i] == '%' || expr[i] == '|' || expr[i] == '!') {
			SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
			cout << expr[i];
		}
		else {
			SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
			cout << expr[i];
		}
	}
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
}

// Вывести ОИ
void displayInteg(double a, double b, string expr)
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	cout << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << "     " << b << endl;
	cout << "    --\n";
	cout << "  /  ";
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	displayExpression(expr);
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << " dx" << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << "--\n";
	cout << a << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	cout << endl;
}

// Вывети ОИ для ввода нижней границы
void displayIntegForInputA()
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	cout << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	cout << "     " << "b" << endl;
	cout << "    --\n";
	cout << "  /  ";
	cout << "F(x)";
	cout << " dx" << endl;
	cout << "--\n";
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << "?" << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	cout << endl;
}

// Вывети ОИ для ввода верхней границы
void displayIntegForInputB(double a)
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	cout << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
	cout << "     " << "?" << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	cout << "    --\n";
	cout << "  /  ";
	cout << "F(x)";
	cout << " dx" << endl;
	cout << "--\n";
	cout << a << endl;
	SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	cout << endl;
}