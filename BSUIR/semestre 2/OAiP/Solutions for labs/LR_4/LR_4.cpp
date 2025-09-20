#define CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string> 
#include <cstring> 
using namespace std;

/* функция ввода исходных данных */
void str_Input(char* s) {
    printf("Введите строку: ");
    scanf("%s", s);
}

/* функция вывода результата */
void str_Print(char* s) {
    printf("Вывод текущей строки: ");
    cout << s;
}

/* функция-имитатор возвращает указатель на последнее вхождение символа symbol в строке strptr */
char* func_strrchr(char* strptr, int symbol) {
    int i = 0;
    while(strptr[i] != '\0') {
        i++;
    }
    while (i >= 0) {
        if (strptr[i] == symbol)
            return strptr + i;
        i--;
    }
    return nullptr;
}

/* функция-оболочка для стандартной функции strrchr() */
char* orig_strrchr(char* strptr, int symbol) {
    return strrchr(strptr, symbol);
}

int main() {
    setlocale(0, "Rus");

    char str[] = "This is a sample string";
    char* pch;

    str_Input(str);

    str_Print(str);
    cout << "\n";

    char c = 's';
    cout << "Введите искомый символ: ";
    cin >> c;

    pch = orig_strrchr(str, c);
    printf("orig_strrchr: Последнее вхождение символа: %d \n", pch - str + 1);
    pch = func_strrchr(str, c);
    printf("custom_strrchr: Последнее вхождение символа: %d \n", pch - str + 1);

    system("pause");
    return 0;
}