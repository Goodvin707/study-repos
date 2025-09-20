#pragma once
#include <algorithm>
#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <set>
#include <vector>
#include <stack>
#include <iterator>
#include <cmath>
using namespace std;

// Массив переменных
typedef map<string, double> Variables;

void ReadExpressionFromStream(ifstream& inp, string& expr, Variables& var);

// Типы токенов
enum tokentype {
    // Переменная, константа, (, ), функция, операция
    var, num, op_br, cl_br, func, op
};
// Структура токена
struct token {
    string name;
    tokentype type;

    // Конструкторы
    token(string str, tokentype typ) {
        name = str;
        type = typ;
    }
    token() {}
};

// Список токенов
typedef vector<token> tokens;

// Разделители
const string delimiters = " ()+/*-^&|!%[]";
void CreateSetOfDelimiters();
bool IsDelimiter(char sym);
void CreateTokensFromExpression(string& expr, tokens& texpr);

void CreatePrior();
void CreatePostfixFromTokens(tokens& texpr, tokens& pexpr);

// Указатель на функцию(для операций)
typedef double(*func_type)(stack<double>&);

// Массив операций
typedef map<string, func_type> Ops;
void CreateOps();
double ResultExpr(tokens& pexpr, Variables& expvars);
double fact(double n);
double op_plus(stack <double>& s);
double op_minus(stack <double>& s);
double op_mul(stack <double>& s);
double op_div(stack <double>& s);
double op_deg(stack <double>& s);
double op_opposite(stack <double>& s);
double op_factorial(stack <double>& s);
double op_odiv(stack <double>& s);
double op_sin(stack <double>& s);
double op_cos(stack <double>& s);
double op_tan(stack <double>& s);
double op_ctan(stack <double>& s);
double op_asin(stack <double>& s);
double op_acos(stack <double>& s);
double op_atan(stack <double>& s);
double op_actg(stack <double>& s);
double op_absolute(stack <double>& s);
double op_squareRoot(stack <double>& s);
double op_exponentialValue(stack <double>& s);
double op_naturalLog(stack <double>& s);
double op_logarithm10(stack <double>& s);