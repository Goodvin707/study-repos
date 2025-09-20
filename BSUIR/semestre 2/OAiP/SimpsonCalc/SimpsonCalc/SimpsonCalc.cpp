#include <Windows.h>
#include <iostream>
#include <cmath>
#include <iomanip>
#include <fstream>
#include "Parser.h"
#include "Validator.h"
#include "Visualizer.h"
#include "Randomizer.h"
#define _USE_MATH_DEFINES

// Вычисление разряда числа
int calcDigit(int a, int razr = 10, int count = 1) {
	a = abs(a);
	if (a >= razr)
		calcDigit(a, razr * 10, ++count);
	return count;
}

// Вычисление значения функции в точке
double Fx(double x,tokens &pexpr, Variables &expvars) {
	expvars["x"] = x;
	return ResultExpr(pexpr, expvars);
}

// Вычисление шага разбиения
double calcStep(double a, double b, int n2) { return (b - a) / n2; }

// Удаление пробелов из строки
string trim(string s) {
	string v;
	for (char c : s) if (c != ' ') v += c;
	return v;
}

// Вычисление определенного интеграла методом Симпсона
double calcOI(double a, double b, int n2, int precision, tokens& pexpr, Variables& expvars) {
	double h = calcStep(a, b, n2);
	double* arrX = new double[n2 + 1];
	double* arrFx = new double[n2 + 1];
	double integFx;
	
	cout << setw(3) << "i" << setw(3) << "|" << setw(16) << "Xi" << setw(18) << "|" << setw(16) << "F(Xi)" << setw(18) << "|\n";
	for (int i = 0; i < n2 + 1; i++)
	{
		if (i == 0) {
			arrX[0] = a;
		}
		else {
			arrX[i] = arrX[i - 1] + h;
		}
		expvars["x"] = arrX[i];
		arrFx[i] = ResultExpr(pexpr, expvars);

		cout << fixed << setprecision(precision);
		cout << i << setw(6 - calcDigit(i)) << "|" << showpos << arrX[i] << setw(16 * 2 - precision - calcDigit(arrX[i])) << "|" << arrFx[i] << setw(16 * 2 - precision - calcDigit(arrFx[i])) << "|\n";
		cout.unsetf(ios::showpos);
	}
	cout << endl << endl;

	double sum = arrFx[0] + arrFx[n2];
	double oddSum = 0, evenSum = 0;
	for (int i = 1; i < n2; i++)
	{
		if (i % 2 == 0) {
			evenSum += arrFx[i];
		}
		else {
			oddSum += arrFx[i];
		}
	}
	sum += 2 * evenSum + 4 * oddSum;
	integFx = (h / 3) * sum;
	return integFx;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

	tokens texpr, pexpr;
    Variables expvars;
    string expr, expression = "";
    ifstream file("expression.txt");
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	do
	{
		system("cls");
		system("color 07");
		int menu;
		string smenu;
		cout << "Выберите пункт меню\n";
		cout << "1. Ввести функцию\n";
		cout << "2. Список ранее использованных функций\n";
		cout << "3. Вычислить определенный интеграл\n";
		cout << "4. Вычислить производную\n";
		cout << "5. Выход\n";
		cin >> smenu;
		try { menu = stoi(smenu); }
		catch (const std::exception&) { continue; }
		switch (menu)
		{
		case 1: // Ввод функции
		{
			system("cls");
			displayHelp();
			
			validateExpression(expression, texpr, pexpr);

			// Перед добавлением функции в хранилище, проверка есть ли уже там такая функция
			bool isFuncInStorage = false;
			ifstream fin;
			string line;
			fin.open("funcStorage.txt");
			while (getline(fin, line)) {
				if (expression == line) {
					isFuncInStorage = true;
				}
			}
			fin.close();
			if (!isFuncInStorage) {
				ofstream fout;
				fout.open("funcStorage.txt", ios::app);
				fout << expression << endl;
				fout.close();
			}
			SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
			cout << "Функция введена корректно\n";
			system("pause");
		}
		break;
		case 2: // Список ранее использованных функций
		{
			system("cls");
			ifstream fin;
			string line;
			vector<string> lines;
			
			cout << "\tСписок ранее использованных функций\n";
			fin.open("funcStorage.txt");
			if (fin.peek() != EOF) {
				while (getline(fin, line)) {
					lines.push_back(line);
					cout << lines.size() << ". F(x): " << line << "\n";
				}
				fin.close();

				int menu12;
				cout << "\tВыберите пункт меню\n";
				cout << "\t1. Выбрать функцию для расчетов\n";
				cout << "\t2. Удалить функцию\n";
				cout << "\t3. Назад\n";
				validateInt(menu12, "пункт меню", false, "", 1, 3);

				switch (menu12)
				{
				case 1: // Выбор функции по номеру
				{
					int num;
					cout << "Введите номер функции: ";
					validateInt(num, "номер функции", false, "", 1, lines.size() + 1);

					ofstream fout;
					fout.open("expression.txt");
					fout << lines[num - 1] << endl;
					fout << "x=1" << endl;
					fout.close();

					expr = lines[num - 1];
					SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
					cout << "Выбрана функция: " << lines[num - 1] << endl;
					
					system("pause");
				}
				break;
				case 2: // Удаление функции по номеру
				{
					int num;
					cout << "Введите номер функции, которая будет удалена: ";
					validateInt(num, "", false, "", 1, lines.size() + 1);

					ofstream fout;
					fout.open("funcStorage.txt");
					for (int i = 0; i < lines.size(); i++)
					{
						if (i != num - 1) {
							fout << lines[i] << endl;
						}
					}
					fout.close();
				}
				break;
				case 3: // Назад
					break;
				}
			}
			else {
				cout << "Ранее использованных функций нет\n";
				system("pause");
			}
			system("cls");
		}
		break;
		case 3: // Вычисление ОИ
		{
			system("cls");
			ReadExpressionFromStream(file, expr, expvars);
			cout << "F(x): " << expr << "\n";

			int menu13;
			cout << "\tВыберите пункт меню\n";
			cout << "\t1. Ввести входные данные вручную\n";
			cout << "\t2. Сгенерировать входные данные\n";
			cout << "\t3. Назад\n";
			validateInt(menu13, "", false, "", 1, 3);
			switch (menu13)
			{
			case 1: // Ручной ввод входных данных
			{
				system("cls");
				double a, b, h;
				int n2, precision = 6;
				cout << "Введите нижний и верхний предел интегрирования (a, b): ";
				displayIntegForInputA();
				validateDouble(a, "a", true);
				
				system("cls");
				cout << "Введите нижний и верхний предел интегрирования (a, b): ";
				displayIntegForInputB(a);
				validateDouble(b, "b", true);

				system("cls");
				displayInteg(a, b, expr);
				cout << "Введите кол-во отрезков разбиения (четное число): ";
				validateInt(n2, "2n", false, "isEven", 1, INFINITY);

				cout << "Введите точность (от 1 до 16 знаков после запятой, по умолчанию -- 6): ";
				validateInt(precision, "", false, "", 1, 16);

				h = calcStep(a, b, n2);

				CreateTokensFromExpression(expr, texpr);
				CreatePostfixFromTokens(texpr, pexpr);

				cout << endl;
				double integFx = calcOI(a, b, n2, precision, pexpr, expvars);

				SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
				cout << "Результат: " << integFx << endl;
				cout.unsetf(ios::fixed);
				
				system("pause");
				system("cls");
			}
				break;
			case 2: // Генерация входных данных
			{
				system("cls");
				SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
				cout << "Генерация...\n";

				double a, b, h;
				int n2, precision = 6;
				a = randDouble(-5, 5);
				Sleep(1000);
				b = randDouble(a, 5);
				n2 = randEvenInt(2, 20);

				SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
				cout << "Генерация завершена\n";
				SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);

				displayInteg(a, b, expr);

				CreateTokensFromExpression(expr, texpr);
				CreatePostfixFromTokens(texpr, pexpr);

				double integFx = calcOI(a, b, n2, precision, pexpr, expvars);

				SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
				cout << "Результат: " << integFx << endl;
				cout.unsetf(ios::fixed);
				
				system("pause");
				system("cls");
			}
				break;
			case 3:
				break;
			}
			texpr.clear();
			pexpr.clear();
		}
		break;
		case 4: // Вычисление производной
		{
			system("cls");
			ReadExpressionFromStream(file, expr, expvars);
			CreateTokensFromExpression(expr, texpr);
			CreatePostfixFromTokens(texpr, pexpr);

			cout << "Fx: ";
			displayExpression(expr);
			cout << "\n";
			
			double x, h;
			cout << "Введите точку, в которой будет вычисляться производная: ";
			validateDouble(x, "x", true);

			cout << "Введите шаг вычисления: ";
			validateDouble(h, "h", true);

			double fc; // Центральная разностная производная
			fc = (Fx(x + h, pexpr, expvars) - Fx(x - h, pexpr, expvars)) / (2 * h);
			
			SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
			cout << "F(x)' = " << fc << "\n";
			
			system("pause");
			system("cls");
			texpr.clear();
			pexpr.clear();
		}
		break;
		case 5: // Выход
			exit(0);
		default: system("color 0C"); cout << "Выбран несуществующий пункт меню" << endl; Sleep(2000);
			break;
		}
	} while (true);

	return 0;
}