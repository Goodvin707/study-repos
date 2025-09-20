#include <iostream>
#include <fstream>
#include <vector>
#include <list>
#include <string>

using namespace std;

// Функция хеширования
int hashFunction(const string& key, int tableSize) {
    int hash = 0;
    for (char ch : key) {
        hash = (hash * 31 + ch) % tableSize;
    }
    return hash;
}

// Класс записи словаря
class DictionaryEntry {
public:
    string key;
    string value;

    DictionaryEntry(const string& k, const string& v) : key(k), value(v) {}
};

// Класс хеш-таблицы с использованием цепочек (списков)
class HashTable {
    vector<list<DictionaryEntry>> table;
    int tableSize;
public:
    HashTable(int size) : tableSize(size) {
        table.resize(size);
    }

    // Вставка элемента в хеш-таблицу
    void insert(const string& key, const string& value) {
        int index = hashFunction(key, tableSize);
        for (auto& entry : table[index]) {
            if (entry.key == key) {
                entry.value = value; // Обновление значения, если ключ уже существует
                return;
            }
        }
        table[index].emplace_back(key, value);
    }

    // Поиск элемента в хеш-таблице
    bool search(const string& key, string& value) {
        int index = hashFunction(key, tableSize);
        for (auto& entry : table[index]) {
            if (entry.key == key) {
                value = entry.value;
                return true;
            }
        }
        return false;
    }

    // Удаление элемента из хеш-таблицы
    bool remove(const string& key) {
        int index = hashFunction(key, tableSize);
        for (auto it = table[index].begin(); it != table[index].end(); ++it) {
            if (it->key == key) {
                table[index].erase(it);
                return true;
            }
        }
        return false;
    }

    // Сохранение хеш-таблицы во внешний файл
    void saveToFile(const string& filename) {
        ofstream file(filename, ios::binary);
        if (file.is_open()) {
            for (int i = 0; i < tableSize; ++i) {
                for (const auto& entry : table[i]) {
                    int keyLen = entry.key.length();
                    int valueLen = entry.value.length();
                    file.write(reinterpret_cast<const char*>(&keyLen), sizeof(keyLen));
                    file.write(entry.key.c_str(), keyLen);
                    file.write(reinterpret_cast<const char*>(&valueLen), sizeof(valueLen));
                    file.write(entry.value.c_str(), valueLen);
                }
            }
            file.close();
        }
        else {
            cerr << "Ошибка открытия файла для записи." << endl;
        }
    }

    // Загрузка хеш-таблицы из внешнего файла
    void loadFromFile(const string& filename) {
        ifstream file(filename, ios::binary);
        if (file.is_open()) {
            table.clear();
            table.resize(tableSize);
            while (!file.eof()) {
                int keyLen, valueLen;
                file.read(reinterpret_cast<char*>(&keyLen), sizeof(keyLen));
                if (file.eof()) break;
                string key(keyLen, ' ');
                file.read(&key[0], keyLen);
                file.read(reinterpret_cast<char*>(&valueLen), sizeof(valueLen));
                string value(valueLen, ' ');
                file.read(&value[0], valueLen);
                insert(key, value);
            }
            file.close();
        }
        else {
            cerr << "Ошибка открытия файла для чтения." << endl;
        }
    }

    // Вывод хеш-таблицы
    void display() {
        for (int i = 0; i < tableSize; i++) {
            cout << i << ": ";
            for (const auto& entry : table[i]) {
                cout << "[" << entry.key << ": " << entry.value << "] -> ";
            }
            cout << "NULL" << endl;
        }
    }
};

int main() {
    int tableSize = 10;
    string filename = "dictionary.dat";
    HashTable hashTable(tableSize);

    // Загрузка данных из файла
    hashTable.loadFromFile(filename);

    // Вставка данных в словарь
    hashTable.insert("apple", "яблоко");
    hashTable.insert("banana", "банан");
    hashTable.insert("orange", "апельсин");

    // Сохранение данных в файл
    hashTable.saveToFile(filename);

    // Вывод словаря
    cout << "Словарь:" << endl;
    hashTable.display();

    // Поиск элемента
    string value;
    if (hashTable.search("banana", value)) {
        cout << "Найдено: banana -> " << value << endl;
    }
    else {
        cout << "Не найдено: banana" << endl;
    }

    // Удаление элемента
    if (hashTable.remove("apple")) {
        cout << "Удалено: apple" << endl;
    }
    else {
        cout << "Не найдено для удаления: apple" << endl;
    }

    // Сохранение изменений в файл
    hashTable.saveToFile(filename);

    // Вывод обновленного словаря
    cout << "Обновленный словарь:" << endl;
    hashTable.display();

    return 0;
}