#pragma once
#include <Windows.h>
#include <algorithm>
#include <iostream>
#include <string>
#include <cmath>
#include "Parser.h"
using namespace std;

const int supportedOperatorsCount = 6;
const int supportedConstraintsCount = 30;
const char supportedOperators[supportedOperatorsCount] = { '+', '-', '*', '/', '^', '%'};
const string supportedConstraints[supportedConstraintsCount] = { "opposite", "oppos", "op", "factorial", "factor", "fact", "sin", "sinus", "cos", "cosinus", "tg", "tan", "ctg", "ctan", "asin", "arcsin", "acos", "arccos", "atan", "arctg", "arctan", "actan", "arcctg", "arcctan", "abs", "sqrt", "exp", "ln", "log", "x"};

bool isEven(int a);
void validateInt(int& a, string varName, bool displayInput);
void validateInt(int& a, string varName, bool displayInput, string additionalCheck, int min, int max);
void validateDouble(double& a, string varName, bool displayInput);
void validateExpression(string& expression, tokens& texpr, tokens& pexpr);
