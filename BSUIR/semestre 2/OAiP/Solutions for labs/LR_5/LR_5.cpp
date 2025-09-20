#include <Windows.h>
#include <iostream>
#include <vector>
#include <string>
using namespace std;
HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);

// Факториал
uint64_t fact(uint64_t n) {
    if (n == 0)
        return 1;
    return n * fact(n - 1);
}

// Рекурсивное решение задачи.
// Прямая рекурсия
uint64_t recursionSolve(uint16_t n, uint16_t k) {
    if (n == k)
        return 1;
    if (n <= 0 || k <= 0 || n < k)
        return 0;
    return recursionSolve(n - 1, k - 1) + k * recursionSolve(n - 1, k);
}

// Итеграционное решение задачи
uint64_t iterationSolve(uint16_t n, uint16_t k) {
    vector<vector<int>> dp(n + 1, vector<int>(k + 1, 0));
    dp[0][0] = 1;

    for (int i = 1; i <= n; ++i) {
        for (int j = 1; j <= k; ++j) {
            dp[i][j] = dp[i - 1][j - 1] + j * dp[i - 1][j];
        }
    }

    return dp[n][k];
}

// Проверка ввода на корректность
void validate_uint16_t(uint16_t& a, string varName)
{
    string sA = "";
    do
    {
        try
        {
            if (varName != "")
                cout << "\nВведите " << varName << ": ";
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

int main()
{
    system("chcp 1251");
    system("cls");
    uint16_t n, k;
    
    // Ввод s(n, k)
    validate_uint16_t(n, "n");
    validate_uint16_t(k, "k");
    system("color 07");
    cout << "\n\n";
    
    // Вызов подпрограммы решения и вывод ответа на экран
    cout << "Ответ (итерационное решение): " << iterationSolve(n, k) << endl;
    cout << "Ответ (рекурсивное решение): " << recursionSolve(n, k) << endl;
    system("pause");
    return 0;
}