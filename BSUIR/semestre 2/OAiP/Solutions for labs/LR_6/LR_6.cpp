#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <fstream>
#include <map>
using namespace std;

struct Date {
    int day;
    int month;
    int year;
};

struct Project {
    string name;
    vector<string> developers;
    Date startDate;
    string status;
};

vector<Project> projects;

void addProject() {
    Project project;
    string developer;
    int numDevelopers;

    cout << "Введите название проекта: ";
    cin.ignore();
    getline(cin, project.name);

    cout << "Введите количество разработчиков: ";
    cin >> numDevelopers;
    cin.ignore();

    for (int i = 0; i < numDevelopers; ++i) {
        cout << "Введите имя разработчика " << i + 1 << ": ";
        getline(cin, developer);
        project.developers.push_back(developer);
    }

    cout << "Введите дату начала (день месяц год): ";
    cin >> project.startDate.day >> project.startDate.month >> project.startDate.year;

    cout << "Введите статус проекта (укажите \"completed\" для завершённого проекта!): ";
    cin.ignore();
    getline(cin, project.status);

    projects.push_back(project);
}

void clearProjects() {
    projects.clear();
    cout << "Массив проектов очищен.\n";
}

void displayProjects() {
    for (const auto& project : projects) {
        cout << "Название: " << project.name << '\n';
        cout << "Разработчики: ";
        for (const auto& developer : project.developers) {
            cout << developer << ' ';
        }
        cout << "\nДата начала: " << project.startDate.day << '.' << project.startDate.month << '.' << project.startDate.year << '\n';
        cout << "Статус: " << project.status << "\n\n";
    }
}

void displayProjectsByStatus(const string& status) {
    vector<Project> filteredProjects;

    for (const auto& project : projects) {
        if (project.status == status) {
            filteredProjects.push_back(project);
        }
    }

    sort(filteredProjects.begin(), filteredProjects.end(), [](const Project& a, const Project& b) {
        if (a.startDate.year != b.startDate.year)
            return a.startDate.year < b.startDate.year;
        if (a.startDate.month != b.startDate.month)
            return a.startDate.month < b.startDate.month;
        return a.startDate.day < b.startDate.day;
        });

    for (const auto& project : filteredProjects) {
        cout << "Название: " << project.name << '\n';
        cout << "Разработчики: ";
        for (const auto& developer : project.developers) {
            cout << developer << ' ';
        }
        cout << "\nДата начала: " << project.startDate.day << '.' << project.startDate.month << '.' << project.startDate.year << '\n';
        cout << "Статус: " << project.status << "\n";
    }
}

void displayTopDeveloper() {
    map<string, int> developerProjectCount;

    for (const auto& project : projects) {
        if (project.status == "completed") {
            for (const auto& developer : project.developers) {
                developerProjectCount[developer]++;
            }
        }
    }

    auto topDeveloper = max_element(developerProjectCount.begin(), developerProjectCount.end(),
        [](const pair<string, int>& a, const pair<string, int>& b) {
            return a.second < b.second;
        });

    if (topDeveloper != developerProjectCount.end()) {
        cout << "Разработчик с наибольшим количеством завершённых проектов: " << topDeveloper->first
            << " (" << topDeveloper->second << " проектов)\n";
    }
    else {
        cout << "\nНет завершённых проектов.\n";
    }
}

int main() {
    setlocale(LC_ALL, "Russian");
    int choice;
    do {
        cout << "Выберите пункт меню\n";
        cout << "1. Добавить новый проект\n";
        cout << "2. Очистить массив проектов\n";
        cout << "3. Вывести все проекты\n";
        cout << "4. Вывести проекты по статусу\n";
        cout << "5. Вывести разработчика с наибольшим количеством завершённых проектов\n";
        cout << "6. Завершить работу\n";
        cin >> choice;
        cout << "\n";

        switch (choice) {
        case 1:
            addProject();
            break;
        case 2:
            clearProjects();
            break;
        case 3:
            displayProjects();
            break;
        case 4:
        {
            string status;
            cout << "Введите статус: ";
            cin.ignore();
            getline(cin, status);
            displayProjectsByStatus(status);
        }
            break;
        case 5:
            displayTopDeveloper();
            break;
        case 6: {
            cout << "Завершение работы программы.\n";
            exit(0);
            break;
        }
        default:
            cout << "\nНеверный пункт меню.\n\n";
            break;
        }
    } while (choice != 6);
    return 0;
}