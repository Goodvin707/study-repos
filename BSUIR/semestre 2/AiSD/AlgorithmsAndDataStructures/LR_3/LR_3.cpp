#include <iostream>
#include <vector>
#include <list>
#include <string>
using namespace std;

// Функция хеширования
int hashFunction(int key, int tableSize) {
    return key % tableSize;
}

// Класс Хеш-таблицы на основе цепочек
class HashTable {
    vector<list<int>> table;
    int tableSize;
public:
    HashTable(int size) : tableSize(size) {
        table.resize(size);
    }

    // Вставка элемента в хеш-таблицу
    void insert(int key) {
        int index = hashFunction(key, tableSize);
        table[index].push_back(key);
    }

    // Поиск элемента в хеш-таблице
    bool search(int key) {
        int index = hashFunction(key, tableSize);        
        for (int element : table[index]) {
            if (element == key) {
                return true;
            }
        }
        return false;
    }

    // Вывод хеш-таблицы
    void display() {
        for (int i = 0; i < tableSize; i++) {
            cout << " " << i << ": ";
            for (int element : table[i]) {
                cout << element << " ";
            }
            cout << endl;
        }
    }
};

// Валидация ввода целого числа
void validateInt(int& a, string varName)
{
    string sA = "";
    do {
        try
        {
            if (varName != "")
                cout << "Введите " << varName << ": ";
            cin >> sA;
            a = stoi(sA);
            break;
        }
        catch (invalid_argument ex) {
            cout << "Введенные данные не являются числом" << endl;
        }
        catch (out_of_range ex) {
            cout << "Введено слишком большое число" << endl;
        }
    } while (true);
}

// Генерация случайного целого числа в диапазоне
int randInt(int min, int max) { return rand() % (max - min + 1) + min; }

int main() {
    system("chcp 1251");
    system("cls");

    
    int n = 7, M = 10; // Вариант: 12
    // int n = 9, M = 10; // Вариант: 4
    
    // validateInt(n, "количество элементов массива");
    // validateInt(M, "размер хеш-таблицы");

    vector<int> arr(n);
    for (int i = 0; i < n; i++) {
        arr[i] = randInt(47000, 89000); // Вариант 12
        // arr[i] = randInt(11000, 53000); // Вариант 4
    }

    cout << endl << "Исходный массив: ";
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl << endl;

    HashTable hashTable(M);

    // Вставка элементов массива в хеш-таблицу
    for (int i = 0; i < n; i++) {
        hashTable.insert(arr[i]);
    }

    cout << "Хеш-таблица" << endl;
    hashTable.display();
    cout << endl;

    int key;
    cout << "Введите элемент для поиска: ";
    cin >> key;

    // Поиск элемента в хеш-таблице
    if (hashTable.search(key)) {
        cout << "Элемент " << key << " найден в хеш-таблице." << endl;
    }
    else {
        cout << "Элемент " << key << " не найден в хеш-таблице." << endl;
    }

    system("pause");
    return 0;
}