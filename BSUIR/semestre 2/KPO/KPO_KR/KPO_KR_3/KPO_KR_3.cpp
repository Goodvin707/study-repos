#include <Windows.h>
#include <iostream>
#include <conio.h>
#include <math.h>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

int randInt(int offset, int range) { return rand() % (range - offset + 1) + offset; }

void validateInt(int& a, string varName)
{
    HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
    string sA = "";
    do
    {
        SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
        try
        {
            if (varName != "")
                cout << "\tВведите " << varName << ": ";
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
    } while (true);
}

void initMatrix(vector<vector<int>>& matrix, bool fillRandomValues = false)
{
    int cols, rows;
    cout << "Введите M -- количество столбцов, N -- количество строк\n";
    validateInt(rows, "N");
    validateInt(cols, "M");

    if (fillRandomValues)
    {
        int min, max;
        validateInt(min, "минимальную границу");
        validateInt(max, "максимальную границу");
        for (int i = 0; i < rows; i++) {
            vector<int> row;
            for (int j = 0; j < cols; j++) {
                row.push_back(randInt(min, max));
            }
            matrix.push_back(row);
        }
    }
    else
    {
        for (int i = 0; i < rows; i++) {
            vector<int> row;
            for (int j = 0; j < cols; j++) {
                int num;
                cout << "Введите m[" << i << "][" << j << "]: ";
                validateInt(num, "");
                row.push_back(num);
            }
            matrix.push_back(row);
        }
    }
}

void printMatrix(vector<vector<int>>& matrix, bool ispainting = false)
{
    if (ispainting)
    {
        HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
        for (int i = 0; i < matrix.size(); i++) {
            for (int j = 0; j < matrix[i].size(); j++) {
                SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
                if (i == j)
                    SetConsoleTextAttribute(handle, FOREGROUND_GREEN);
                cout << "\t" << matrix[i][j];
            }
            cout << endl;
        }
    }
    else
    {
        for (int i = 0; i < matrix.size(); i++) {
            for (int j = 0; j < matrix[i].size(); j++) {
                cout << "\t" << matrix[i][j];
            }
            cout << endl;
        }
    }
    cout << "\n";
}

void sortDiagonalByRows(vector<vector<int>> & matrix)
{
    int cols = matrix[0].size(), rows = matrix.size();
    if (cols > rows)
        cols = rows;

    vector<vector<int>> newMatrix;
    for (int i = 0; i < rows; i++) {
        vector<int> row;
        newMatrix.push_back(row);
    }

    for (int i = 0; i < rows; i++) {
        int maxElemInRow = abs(matrix[0][0]);
        int colPosition = 0;
        for (int j = 0; j < cols; j++) {
            if (maxElemInRow < abs(matrix[i][j])) {
                maxElemInRow = abs(matrix[i][j]);
                colPosition = j;
            }
        }
        newMatrix[colPosition] = matrix[i];
    }

    bool flag = false;
    int kk;
    for (int i = 0; i < newMatrix.size(); i++) {
        if (newMatrix[i].empty()) {
            for (int j = 0; j < matrix.size(); j++) {
                flag = true;
                for (int k = 0; k < newMatrix.size(); k++) {
                    if (!newMatrix[k].empty() && matrix[j] == newMatrix[k]) {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    newMatrix[i] = matrix[j];
            }
        }
    }

    matrix = newMatrix;
}

int main()
{
    HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(handle, FOREGROUND_INTENSITY);
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "Rus");

    vector<vector<int>> matrix;
    cout << "Выберите пункт меню\n";
    cout << "1. Ввести элементы матрицы вручную\n";
    cout << "2. Заполнить элементы матрицы случайными числами\n";
    
    int menu = 2;
    validateInt(menu, "");
    switch (menu)
    {
    case 1:
        initMatrix(matrix);
        break;
    default:
        initMatrix(matrix, true);
        break;
    }
    printMatrix(matrix);
    sortDiagonalByRows(matrix);
    printMatrix(matrix, true);
    
    SetConsoleTextAttribute(handle, FOREGROUND_BLUE);
    cout << "\n\nНажмите любую клавишу для завершения программы.";
    _getch();
	return 0;
}