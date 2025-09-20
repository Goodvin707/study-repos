#include "Validator.h"

// Проверка числа на четность
bool isEven(int a) { return a % 2 == 0; }

// Приведение символа в нижний регистр
char to_lowercase(char c) {
	if (c >= 'A' && c <= 'Z')
		return c + 32;
}

// Обработчик потока для перекраски текста в консоли
HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);

// Стандартная валидация для целого числа
void validateInt(int& a, string varName, bool displayInput)
{
	string sA = "";
	do
	{
		SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
		try
		{
			if (displayInput)
				cout << "\n\tВведите " << varName << ": ";
			cin >> sA;
			a = stoi(sA);

			break;
		}
		catch (invalid_argument ex) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			cout << "Введенные данные не являются числом" << endl;
		}
		catch (out_of_range ex) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			cout << "Введено слишком большое число" << endl;
		}
		displayInput = true;
	} while (true);
}

// Валидация для целого числа с доп. проверками
void validateInt(int& a, string varName, bool displayInput, string additionalCheck, int min, int max)
{
	string sA = "";
	do
	{
		SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
		try
		{
			if (displayInput)
				cout << "\n\tВведите " << varName << ": ";
			cin >> sA;
			a = stoi(sA);
			
			if (additionalCheck == "isEven" && !isEven(a))
			{
				throw 228;
			}
			if (additionalCheck == "isOdd" && isEven(a))
			{
				throw 229;
			}

			if (max != NULL && a > max)
			{
				throw 336;
			}
			if (min != NULL && a < min)
			{
				throw 337;
			}
			break;
		}
		catch (invalid_argument ex) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			cout << "Введенные данные не являются числом" << endl;
		}
		catch (out_of_range ex) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			cout << "Введено слишком большое число" << endl;
		}
		catch (int exNum) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			if (varName != "")
				varName += " ";
			if (exNum == 228)
				cout << "Число "<< varName <<"должно быть четным\n";
			if (exNum == 229)
				cout << "Число " << varName << "должно быть нечетным\n";
			if (exNum == 336)
				cout << "Число " << varName << "должно быть меньше или равно " << max << "\n";
			if (exNum == 337)
				cout << "Число " << varName << "должно быть больше "<< min << "\n";
			if (varName != "")
				varName.replace(varName.length() - 1, 1, "");
		}
		displayInput = true;
	} while (true);
}

// Стандартная валидация для дробного числа
void validateDouble(double& a, string varName, bool displayInput)
{
	string sA = "";
	do
	{
		SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
		try
		{
			if (displayInput)
				cout << "\n\tВведите " << varName << ": ";
			cin >> sA;

			for (char& c : sA) {
				if (c  == '.')
					c = ',';
			}
			stoi(sA);
			a = stod(sA);

			break;
		}
		catch (invalid_argument ex) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			cout << "Введенные данные не являются числом" << endl;
		}
		catch (out_of_range ex) {
			SetConsoleTextAttribute(handle, FOREGROUND_RED);
			cout << "Введено слишком большое число" << endl;
		}
		displayInput = true;
	} while (true);
}

// Валидация мат. выражения
void validateExpression(string& expression, tokens& texpr, tokens& pexpr)
{
	bool isFirstRun = true;
	bool isXinFormulae = false;
	bool isFormulaeCorrect = false;
	bool isOperatorRepeats = false;
	string errF = "";
	do
	{
		SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
		if (!isFirstRun)
			cout << "\nF(x) = ";
		getline(cin, expression);

		if (!isFirstRun) {
			for (char& c : expression) {
				c = to_lowercase(c);
			}

			for (int i = 0; i < expression.length(); i++)
			{
				if (expression[i] == 'x')
					isXinFormulae = true;
			}
			if (!isXinFormulae) {
				SetConsoleTextAttribute(handle, FOREGROUND_RED);
				cout << "\tНет переменной x\n";
			}

			string trimmedExpr = "";
			for (char& c : expression) {
				if (c != ' ')
					trimmedExpr += c;
			}

			// Проверка, есть ли несколько операторов подряд без операндов. Например: " + - + - * / / /"
			for (int i = 0; i < trimmedExpr.size(); i++) {
				for (int j = 0; j < supportedOperatorsCount; j++) {
					if (trimmedExpr[i] == supportedOperators[j]) {
						isOperatorRepeats = false;
						if (i + 1 < trimmedExpr.size()) {
							for (int k = 0; k < supportedOperatorsCount; k++) {
								if (trimmedExpr[i + 1] == supportedOperators[k]) {
									isOperatorRepeats = true;
									errF = trimmedExpr[i + 1];
									break;
								}
							}
						}
						else {
							isOperatorRepeats = true;
							errF = trimmedExpr[i];
							break;
						}
						if (i - 1 >= 0) {
							for (int k = 0; k < supportedOperatorsCount; k++) {
								if (trimmedExpr[i - 1] == supportedOperators[k]) {
									isOperatorRepeats = true;
									errF = trimmedExpr[i - 1];
									break;
								}
							}
						}
						else {
							isOperatorRepeats = true;
							errF = trimmedExpr[i];
							break;
						}
					}
				}
			}
			if (isOperatorRepeats) {
				string errCursor = "";
				for (int i = 0; i < 7 + expression.find(errF); i++)
					errCursor += "-";
				errCursor += "^";

				SetConsoleTextAttribute(handle, FOREGROUND_RED);
				cout << "y(x) = " << expression << "\n";
				cout << errCursor << "\n";
				cout << "\tУ оператора " << errF << " пропущен операнд\n";
			}

			CreateTokensFromExpression(expression, texpr);
			CreatePostfixFromTokens(texpr, pexpr);

			// Проверка на отсутствие несуществующих символов. Например: "> < ? [ ] { } @ $"
			bool isUnnableOperator = false;
			string unnableOpName = "";
			for (int i = 0; i < pexpr.size(); i++)
			{
				if (pexpr[i].type == op) {
					isUnnableOperator = true;
					for (int j = 0; j < supportedOperatorsCount; j++) {
						string s(1, supportedOperators[j]);
						if (pexpr[i].name == s) {
							isUnnableOperator = false;
							break;
						}
					}
					if (isUnnableOperator) {
						unnableOpName = pexpr[i].name;
						break;
					}
				}
			}
			if (isUnnableOperator)
			{
				SetConsoleTextAttribute(handle, FOREGROUND_RED);
				cout << "\tНе существующй оператор " << unnableOpName << "\n";
				texpr.clear();
				pexpr.clear();
				continue;
			}
			
			// Проверка на то что количество левых скобок совпадает с правыми
			int op_br_count = 0, cl_br_count = 0;
			for (int i = 0; i < pexpr.size(); i++)
			{
				if (pexpr[i].type == op_br)
					op_br_count++;
				if (pexpr[i].type == cl_br)
					cl_br_count++;
			}
			if (op_br_count != cl_br_count)
			{
				SetConsoleTextAttribute(handle, FOREGROUND_RED);
				cout << "\tНе хватает скобок\n";
				texpr.clear();
				pexpr.clear();
				continue;
			}

			// Проверка на отстутствие несуществующих функций
			for (int i = 0; i < pexpr.size(); i++)
			{
				if (pexpr[i].type == func || pexpr[i].type == var) {
					isFormulaeCorrect = false;
					for (int j = 0; j < supportedConstraintsCount; j++)
					{
						if (pexpr[i].name == supportedConstraints[j]) {
							isFormulaeCorrect = true;
							break;
						}
						else
							errF = pexpr[i].name;
					}
				}
			}
			if (!isFormulaeCorrect) {
				string errCursor = "";
				for (int i = 0; i < 7 + expression.find(errF); i++)
					errCursor += "-";
				errCursor += "^";

				SetConsoleTextAttribute(handle, FOREGROUND_RED);
				cout << "y(x) = " << expression << "\n";
				cout << errCursor << "\n";
				cout << "\tФункция " << errF << " не поддерживается\n";
			}
		}
		isFirstRun = false;
		texpr.clear();
		pexpr.clear();
	} while (!isXinFormulae || !isFormulaeCorrect || isOperatorRepeats);
}