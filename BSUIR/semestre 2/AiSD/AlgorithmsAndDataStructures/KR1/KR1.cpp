#include <iostream>
#include <iomanip>
#include <vector>
#include <string>
#include <stdio.h>
#include <stdlib.h>
using namespace std;

struct treeNode // Структура дерева
{
    int field; // поле данных
    bool ltag, rtag; // теги прошивочных нитей
    struct treeNode* left; // указатель на левое поддерево
    struct treeNode* right; // указатель на правое поддерево
};
treeNode* HEAD = new treeNode;
treeNode* x = HEAD; // указатель на предыдущий узел
treeNode* y = HEAD; // указатель на предыдущий узел

// Вывод дерева (в инфиксной форме)
void displaySortedTree(treeNode* tree)
{
    if (tree != NULL)
    {
        displaySortedTree(tree->left);
        cout << tree->field;
        displaySortedTree(tree->right);
    }
}

// Добавление узла
struct treeNode* addNode(int x, treeNode* tree)
{
    if (tree == NULL)
    {
        tree = new treeNode;
        tree->field = x;
        tree->left = NULL;
        tree->right = NULL;
    }
    else
    {
        if (x < tree->field)
            tree->left = addNode(x, tree->left);
        if (x > tree->field)
            tree->right = addNode(x, tree->right);
    }
    return(tree);
}

// Левая прошивка дерева
void leftsew(treeNode* p) {
    if (x != nullptr) {
        if (x->left == nullptr) {
            x->ltag = false;
            x->left = p;
        }
        else
            x->ltag = true;
    }
    x = p;
}

// Правая прошивка дерева
void rightsew(treeNode* p) {
    if (y != nullptr) {
        if (y->right == nullptr) {
            y->rtag = false;
            y->right = p;
        }
        else
            y->rtag = true;
    }
    y = p;
}

// Добавление узла с поддержанием нитей
struct treeNode* addSimNode(int x, treeNode* tree)
{
    if (tree == NULL)
    {
        tree = new treeNode;
        tree->field = x;
        tree->left = NULL;
        tree->right = NULL;
    }
    else
    {
        if (x < tree->field && tree->ltag == true)
            tree->left = addSimNode(x, tree->left);
        if (x > tree->field && tree->rtag == true)
            tree->right = addSimNode(x, tree->right);
    }
    return(tree);
}

// Симметричная прошивка дерева
void simThreading(treeNode* tree) {
    if (tree != nullptr) {
        simThreading(tree->left);
        leftsew(tree);
        x = tree;

        rightsew(tree);
        y = tree;
        cout << tree->field << " ";
        simThreading(tree->right);
    }
}

bool isElemInList(vector<int> list, int elem) {
    for (int i = 0; i < list.size(); i++)
    {
        if (list[i] == elem)
            return true;
    }
    return false;
}

// Поиск узла в дереве
treeNode* findNode(int x,treeNode* tree, vector<int> list = {})
{
    if (tree == NULL)
        return NULL;
    if (tree->field == x)
        return tree;

    list.push_back(tree->field);
    if (x < tree->field)
    {
        if (tree->left != NULL) {
            if (isElemInList(list, tree->left->field))
                return NULL;
            return findNode(x, tree->left, list);
        }
        else
            return NULL;
    }
    if (x > tree->field)
    {
        if (tree->right != NULL) {
            if (isElemInList(list, tree->right->field))
                return NULL;
            return findNode(x, tree->right, list);
        }
        else
            return NULL;
    }
}

// Генерация случайного целого числа в диапазоне
int randInt(int min, int max) { return rand() % (max - min + 1) + min; }

// Валидация ввода целого числа
void validateInt(int& a, string varName)
{
    string sA = "";
    do
    {
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

int main()
{
    system("chcp 1251");
    system("cls");

    // Инициализация корня
    struct treeNode* root = 0; 
    HEAD->left = root;
    HEAD->right = HEAD;

    cout << "Выберите пункт меню\n1. Ввести узлы вручную\n2. Заполнить случайными числами в диапазоне\n3. Заполнить заготовленными числами\n";
    int menu;
    validateInt(menu, "");
    switch (menu)
    {
    case 1:
    {
        int a, n;
        cout << "Сколько чисел будет вводиться? [10, 15]\n";
        do
        {
            validateInt(n, "n");
        } while (n < 10 || n > 15);

        for (int i = 0; i < n; i++)
        {
            cout << "Введите узел " << i + 1 << ": ";
            validateInt(a, "");
            root = addNode(a, root);
        }
    }
        break;
    case 2:
        int min, max;
        cout << "Введите минимальное генерируемое число: \n";
        validateInt(min, "");
        cout << "Введите максимальное генерируемое число: \n";
        validateInt(max, "");
        for (int i = 0; i < 15; i++)
            root = addNode(randInt(min, max), root);
        break;
    default:
        root = addNode(4, root);
        root = addNode(3, root);
        root = addNode(5, root);
        root = addNode(1, root);
        root = addNode(7, root);
        root = addNode(8, root);
        root = addNode(6, root);
        root = addNode(2, root);
        break;
    }

    simThreading(root);
    cout << endl << endl;

    int num;
    validateInt(num, "искомое число");
    struct treeNode* tn1 = findNode(num, root);
    if (tn1)
        cout << tn1->field << endl;
    else
        cout << "Числа " << num << " в дереве нет" << endl;

    cout << "\n";
    system("pause");
    return 0;
}