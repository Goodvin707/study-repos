#define _USE_MATH_DEFINES
#include "Parser.h"

// Функция считывает выражение в строку "expr" и ищет переменные
void ReadExpressionFromStream(ifstream& inp, string& expr, Variables& var) {
    getline(inp, expr);
    string temp;
    int pos;

    while (!inp.eof()) {
        getline(inp, temp);
        // Если встретили '=', то это переменная, заносим ее имя и значение в массив
        pos = temp.find('=');
        if (pos > 0) {
            string name = temp.substr(0, pos);
            double value = atof(temp.substr(pos + 1).c_str());
            var[name] = value;
        }
    }
    return;
}

// Множество разделителей
set<char> DelimSet;

// Инициализирует множество разделителей
void CreateSetOfDelimiters() {
    for (int i = 0; i < delimiters.size(); i++)
        DelimSet.insert(delimiters[i]);
    return;
}

// Проверка, является ли символ разделителем
bool IsDelimiter(char sym) {
    return DelimSet.count(sym) > 0;
}

// Разбиваем выражение на токены
void CreateTokensFromExpression(string& expr, tokens& texpr) {
    CreateSetOfDelimiters();
    string ex = expr + " ";
    string name;

    // Получаем имя токена
    int i = 0;
    while (i < ex.size() - 1) {
        name = "";
        // Если текущий символ разделитель
        if (IsDelimiter(ex[i])) {
            if (ex[i] == ' ') { // Пробел просто перепрыгиваем
                i++;
                continue;
            }
            name = ex[i]; // Любой другой добавляем в имя токена
            i++;
        }
        else {
            while (!IsDelimiter(ex[i])) {
                // Если не разделитель например, переменная, считываем его польностью
                name += ex[i];
                i++;
            }
        }
        // Заносим получившийся токен в список токенов
        texpr.push_back(token(name, var));
    }

    // Раздаем получившимся токенам типы
    for (int j = 0; j < texpr.size(); j++) {
        if (texpr[j].name[0] == '(') {
            texpr[j].type = op_br;
            continue;
        }
        if (texpr[j].name[0] == ')') {
            texpr[j].type = cl_br;
            continue;
        }
        if (isdigit(texpr[j].name[0])) {
            texpr[j].type = num;
            continue;
        }
        if (isalpha(texpr[j].name[0])) {
            if (j < texpr.size() - 1 && texpr[j + 1].name[0] == '(')
                texpr[j].type = func;
            continue;
        }

        texpr[j].type = op;
    }

    // Проверяем минус и !, что это префиксные операции
    for (int j = 0; j < texpr.size(); j++) {
        if (texpr[j].name == "-" && (j == 0 || texpr[j - 1].type == op_br))
            texpr[j].name = "opposite";
        if (texpr[j].name == "!" && (j == texpr.size() - 1 || texpr[j + 1].type == cl_br || texpr[j + 1].type == op))
            texpr[j].name = "factorial";
    }

    return;
}

// Приоритеты операций
map <string, int> prior;
// Функция выставляет приоритеты операций
void CreatePrior() {
    prior["+"] = 10;
    prior["-"] = 10;
    prior["*"] = 20;
    prior["/"] = 20;
    prior["^"] = 30;
    prior["%"] = 20;
    prior["&"] = 5;
    prior["|"] = 5;
    prior["!"] = 40;
    prior["opposite"] = 10;
    prior["factorial"] = 30;
}

// Переводим выражение в постфиксную запись
void CreatePostfixFromTokens(tokens& texpr, tokens& pexpr) {
    // Задаем приоритеты операций
    CreatePrior();
    stack <token> TStack;

    // Ловим токены и работаем по алгоритму
    for (int i = 0; i < texpr.size(); i++) {
        switch (texpr[i].type) {
        case var:
        case num:
            pexpr.push_back(texpr[i]);
            break;

        case op_br:
            TStack.push(texpr[i]);
            break;

        case cl_br:
            while (TStack.top().type != op_br) {
                pexpr.push_back(TStack.top());
                TStack.pop();
            }
            TStack.pop();
            break;

        case op:
            if (TStack.size()) {
                while (TStack.size() && ((TStack.top().type == op && prior[texpr[i].name] <= prior[TStack.top().name]) ||
                    TStack.top().type == func)) {
                    pexpr.push_back(TStack.top());
                    TStack.pop();
                }
            }
            TStack.push(texpr[i]);
            break;

        case func:
            while (TStack.size() && TStack.top().type == func) {
                pexpr.push_back(TStack.top());
                TStack.pop();
            }
            TStack.push(texpr[i]);
            break;
        }
    }

    while (TStack.size()) {
        pexpr.push_back(TStack.top());
        TStack.pop();
    }

    return;
}

Ops ops;
// Инициализация массива операций
void CreateOps() {
    ops["+"] = op_plus;
    ops["-"] = op_minus;
    ops["*"] = op_mul;
    ops["/"] = op_div;
    ops["^"] = op_deg;
    ops["%"] = op_odiv;
    ops["opposite"] = op_opposite;
    ops["oppos"] = op_opposite;
    ops["op"] = op_opposite;
    ops["factorial"] = op_factorial;
    ops["factor"] = op_factorial;
    ops["fact"] = op_factorial;

    ops["sin"] = op_sin;
    ops["sinus"] = op_sin;
    
    ops["cos"] = op_cos;
    ops["cosinus"] = op_cos;
    
    ops["tg"] = op_tan;
    ops["tan"] = op_tan;
    
    ops["ctg"] = op_ctan;
    ops["ctan"] = op_ctan;
    
    ops["asin"] = op_asin;
    ops["arcsin"] = op_asin;
    
    ops["acos"] = op_acos;
    ops["arccos"] = op_acos;
    
    ops["atan"] = op_atan;
    ops["arctg"] = op_atan;
    ops["arctan"] = op_atan;

    ops["actan"] = op_actg;
    ops["arcctg"] = op_actg;
    ops["arcctan"] = op_actg;

    ops["abs"] = op_absolute;
    ops["sqrt"] = op_squareRoot;
    ops["exp"] = op_exponentialValue;
    ops["ln"] = op_naturalLog;
    ops["log10"] = op_logarithm10;

    return;
}

// Вычисление результата выражения
double ResultExpr(tokens& pexpr, Variables& expvars) {
    CreateOps();
    stack <double> s;

    for (int i = 0; i < pexpr.size(); i++) {
        switch (pexpr[i].type) {
        case num: {
            s.push(atoi(pexpr[i].name.c_str()));
        }
                break;

        case var: {
            Variables::iterator Vit;
            for (Vit = expvars.begin(); Vit != expvars.end(); Vit++) { // Итерация по словарю переменных
                if (Vit->first == pexpr[i].name) {
                    s.push(Vit->second); // Добавление значения переменной в стек операций
                    break;
                }
            }
        }
                break;

        case func:
        case op: {
            Ops::iterator Oit;
            for (Oit = ops.begin(); Oit != ops.end(); Oit++) { // Итерация по словарю операций
                if (Oit->first == pexpr[i].name) {
                    s.push(Oit->second(s)); // Добавление значения переменной в стек операций
                    break;
                }
            }
        }
               break;
        }
    }
    return s.top();
}

// Реализация доступных операций
double fact(double n) {
    if (n == 0)
        return 1;
    return n * fact(n - 1);
}
double op_plus(stack <double>& s) {
    double a, b;
    a = s.top();
    s.pop();
    b = s.top();
    s.pop();
    return a + b;
}
double op_minus(stack <double>& s) {
    double a, b;
    a = s.top();
    s.pop();
    b = s.top();
    s.pop();
    return b - a;
}
double op_mul(stack <double>& s) {
    double a, b;
    a = s.top();
    s.pop();
    b = s.top();
    s.pop();
    return a * b;
}
double op_div(stack <double>& s) {
    double a, b;
    a = s.top();
    s.pop();
    b = s.top();
    s.pop();
    return b / a;
}
double op_deg(stack <double>& s) {
    double a, b;
    a = s.top();
    s.pop();
    b = s.top();
    s.pop();
    return pow(b, a);
}
double op_opposite(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return -a;
}
double op_factorial(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return fact(a);
}
double op_odiv(stack <double>& s) {
    long long a, b;
    a = s.top();
    s.pop();
    b = s.top();
    s.pop();
    return b % a;
}
double op_sin(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return sin(a);
}
double op_cos(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return cos(a);
}
double op_tan(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return tan(a);
}
double op_ctan(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return cos(a)/sin(a);
}
double op_asin(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return asin(a);
}
double op_acos(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return acos(a);
}
double op_atan(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return atan(a);
}
double op_actg(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return M_PI / 2 - atan(a);
}
double op_absolute(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return abs(a);
}
double op_squareRoot(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return sqrt(a);
}
double op_exponentialValue(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return exp(a);
}
double op_naturalLog(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return log(a);
}
double op_logarithm10(stack <double>& s) {
    double a;
    a = s.top();
    s.pop();
    return log10(a);
}