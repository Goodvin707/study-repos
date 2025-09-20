#include <iostream>
#include <Windows.h>
#include <string>
using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Rus");

    int a, b;
    string sA, sB;
    do
    {
        try
        {
            cout << "Введите A (-inf, 0): ";
            cin >> sA;
            if (stoi(sA) > 0)
                throw 228;
            break;
        }
        catch (exception ex) {
            cout << ex.what() << endl;
        }
        catch (int) {
            cout << "Число A должно быть меньше нуля\n";
        }
    } while (true);
    a = stoi(sA);

    do
    {
        try
        {
            cout << "Введите B (-inf, 1 000 000): ";
            cin >> sB;
            if (stoi(sB) > 1000000)
                throw 228;
            break;
        }
        catch (exception ex) {
            cout << ex.what() << endl;
        }
        catch (int) {
            cout << "Число B должно быть меньше 1 000 000\n";
        }
    } while (true);
    b = stoi(sB);


    int S1 = a + b;

    string sAx = a >= 0 ? "" : "-", sBx = b >= 0 ? "" : "-";
    for (int i = sA.length() - 1; i >= 0; i--)
        sAx += sA[i];

    for (int i = sB.length() - 1; i >= 0; i--)
        sBx += sB[i];

    int ax = stoi(sAx), bx = stoi(sBx);
    int S2 = ax + bx;
    double division = 0.0;
    if (S2 == 0)
        cout << "Деление на ноль\n";
    else
    {
        division = (double)S1 / (double)S2;
        if (!isnan(division))
            cout << "(A + B) / (Ax + Bx) = " << division << endl;
        else
            cout << "В результате вычиcлений получилось иррациональное число" << endl;
    }
    system("pause");
}