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
    string search(const string& key) {
        int index = hashFunction(key, tableSize);
        for (auto& entry : table[index]) {
            if (entry.key == key) {
                return entry.value;
            }
        }
        return "";
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
    system("chcp 1251");
    system("cls");

    int tableSize = 10;
    string filename = "dictionary.dat";
    HashTable hashTable(tableSize);

    // Загрузка данных из файла
    hashTable.loadFromFile(filename);

    // Вставка данных в словарь
    hashTable.insert("apple", "яблыко");
    hashTable.insert("banana", "банан");
    hashTable.insert("orange", "апельсин");
    hashTable.insert("apple", "яблоко");
    hashTable.insert("bananad", "банан");
    hashTable.insert("oranged", "апельсин");
    hashTable.insert("pear", "груша");
    hashTable.insert("pomegranate", "гранат");
    hashTable.insert("bean", "боб");

    // Сохранение данных в файл
    hashTable.saveToFile(filename);

    // Вывод словаря
    cout << "Словарь:" << endl;
    hashTable.display();
    cout << endl;

    // Поиск элемента
    string search_el = "banana";
    string search_result = hashTable.search(search_el);
    if (search_result != "")
        cout << "Найдено: " << search_el << " -> " << search_result << endl;
    else
        cout << "Не найдено: " << search_el << endl;

    // Удаление элемента
    string rem_el = "apple";
    if (hashTable.remove(rem_el))
        cout << "Удалено: " << rem_el << endl;
    else
        cout << "Не найдено для удаления: " << rem_el << endl;

    cout << endl;

    // Сохранение изменений в файл
    hashTable.saveToFile(filename);

    // Вывод обновленного словаря
    cout << "Обновленный словарь:" << endl;
    hashTable.display();

    return 0;
}























//#include <iostream>
//#include <fstream>
//#include <vector>
//#include <list>
//#include <string>
//using namespace std;
//
//bool isFileEmpty(const string& filename) {
//    ifstream file(filename);
//    return file.peek() == ifstream::traits_type::eof();
//}
//
//void createStaticHashedFile(string filename = "", int segmentCount = 10)
//{
//    ofstream outFile(filename);
//    if (!outFile) {
//        cerr << "Не удалось создать файл!" << endl;
//        return;
//    }
//    for (int i = 0; i < segmentCount; i++)
//    {
//        outFile << "[SEGMENT]" << "\n" << i << endl;
//        outFile << "{}" << "\n" << endl;
//        outFile << "[S.END]" << "\n" << endl;
//    }
//    outFile.close();
//}
//
//struct DictionaryEntry {
//    int key;
//    string value;
//};
//
//// Класс для словаря
//class Dictionary {
//private:
//    string filename;
//    int segmentCount;
//
//    // Функция для получения сегмента на основе хеша
//    int getSegmentIndex(const int& key) {
//        return key % segmentCount;
//    }
//
//    // Функция для записи данных в файл
//    void writeSegmentToFile(int segmentIndex, const vector<DictionaryEntry>& entries) {
//        fstream file(filename);
//        if (!file) {
//            cerr << "Ошибка при открытии файла!" << endl;
//            return;
//        }
//        
//        for (const auto& entry : entries) {
//
//        }
//        file.close();
//    }
//
//    // Функция для чтения данных из файла
//    void readSegmentFromFile(int segmentIndex, vector<DictionaryEntry>& entries) {
//        ifstream readFile(filename);
//        if (!readFile) {
//            cerr << "Ошибка при открытии файла!" << endl;
//            return;
//        }
//        
//        string line;
//        while (getline(readFile, line)) {
//            cout << line << endl;
//
//
//        }
//        readFile.close();
//    }
//
//public:
//    // Конструктор
//    Dictionary(const string& filename, int segmentCount) : filename(filename), segmentCount(segmentCount) {
//        if (isFileEmpty(filename))
//            createStaticHashedFile(filename, segmentCount);
//    }
//
//    // Функция для добавления записи в словарь
//    void addEntry(const int& key, const string& value) {
//        int segmentIndex = getSegmentIndex(key);
//        vector<DictionaryEntry> entries;
//        readSegmentFromFile(segmentIndex, entries);
//        // Проверяем, есть ли уже такой ключ
//        for (auto& entry : entries) {
//            if (entry.key == key) {
//                entry.value = value; // Обновляем значение
//                writeSegmentToFile(segmentIndex, entries);
//                return;
//            }
//        }
//        // Добавляем новую запись
//        entries.push_back({ key, value });
//        writeSegmentToFile(segmentIndex, entries);
//    }
//
//    // Функция для получения значения по ключу
//    string getValue(const int& key) {
//        int segmentIndex = getSegmentIndex(key);
//        vector<DictionaryEntry> entries;
//        readSegmentFromFile(segmentIndex, entries);
//        for (const auto& entry : entries) {
//            if (entry.key == key) {
//                return entry.value;
//            }
//        }
//        return ""; // Если ключ не найден
//    }
//
//    // Функция для вывода всех записей в словарь
//    void displayAllEntries() {
//        for (int i = 0; i < segmentCount; ++i) {
//            vector<DictionaryEntry> entries;
//            readSegmentFromFile(i, entries);
//            for (const auto& entry : entries) {
//                cout << "Key: " << entry.key << ", Value: " << entry.value << endl;
//            }
//        }
//    }
//};
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//int main()
//{
//    Dictionary dict("StaticHashedFile.txt", 10);
//    dict.addEntry(1, "A fruit");
//    dict.addEntry(2, "A pet animal");
//    dict.addEntry(3, "A vehicle");
//    
//    cout << "Value for 'apple': " << dict.getValue(1) << endl;
//
//    dict.displayAllEntries();
//
//
//	return 0;
//}