#include <iostream>
#include <queue>
using namespace std;

class TreeNode {
    int* keys;
    int t;
    TreeNode** C;
    int n;
    bool leaf;

public:
    TreeNode(int temp, bool bool_leaf);

    void insertNonFull(int k);
    void splitChild(int i, TreeNode* y);
    void traverse();
    TreeNode* search(int k);
    void deleteKey(int k);
    void removeFromLeaf(int idx);
    void removeFromNonLeaf(int idx);
    int getPred(int idx);
    int getSucc(int idx);
    void fill(int idx);
    void merge(int idx);
    friend class BTree;
};

class BTree {
    TreeNode* root;
    int t;

public:
    BTree(int temp) {
        root = NULL;
        t = temp;
    }

    void traverse() {
        if (root != NULL)
            root->traverse();
    }

    TreeNode* search(int k) {
        return (root == NULL) ? NULL : root->search(k);
    }

    void insert(int k);
    void deleteKey(int k);
    void printTreeByLevels();
};

//конструктор для TreeNode
TreeNode::TreeNode(int t1, bool leaf1) {
    t = t1;
    leaf = leaf1;
    keys = new int[2 * t - 1];
    C = new TreeNode * [2 * t];
    n = 0;
}

//обход узлов дерева
void TreeNode::traverse() {
    int i;
    for (i = 0; i < n; i++) {
        if (leaf == false)
            C[i]->traverse();
        cout << " " << keys[i];
    }
    if (leaf == false)
        C[i]->traverse();
}

//поиск ключа в дереве
TreeNode* TreeNode::search(int k) {
    int i = 0;
    while (i < n && k > keys[i]) {
        i++;
    }

    //выводим текущий ключ, через который мы проходим
    cout << "Проверяем ключи в узле: ";
    for (int j = 0; j < n; j++) {
        cout << keys[j] << " ";
    }
    cout << endl;

    if (i < n && keys[i] == k) {
        cout << "Ключ " << k << " найден!" << endl;
        return this;
    }

    if (leaf) {
        cout << "Ключ " << k << " не найден в дереве." << endl;
        return NULL;
    }

    return C[i]->search(k); //рекурсивный поиск в соответствующем дочернем узле
}

//вставка нового ключа в B-дерево
void BTree::insert(int k) {
    if (root == NULL) {
        root = new TreeNode(t, true);
        root->keys[0] = k;
        root->n = 1;
    }
    else {
        if (root->n == 2 * t - 1) {
            TreeNode* s = new TreeNode(t, false);
            s->C[0] = root;
            s->splitChild(0, root);

            int i = 0;
            if (s->keys[0] < k)
                i++;
            s->C[i]->insertNonFull(k);

            root = s;
        }
        else
            root->insertNonFull(k);
    }
}

//вставка ключа в неполный узел
void TreeNode::insertNonFull(int k) {
    int i = n - 1;
    if (leaf == true) {
        while (i >= 0 && keys[i] > k) {
            keys[i + 1] = keys[i];
            i--;
        }
        keys[i + 1] = k;
        n = n + 1;
    }
    else {
        while (i >= 0 && keys[i] > k)
            i--;
        if (C[i + 1]->n == 2 * t - 1) {
            splitChild(i + 1, C[i + 1]);
            if (keys[i + 1] < k)
                i++;
        }
        C[i + 1]->insertNonFull(k);
    }
}

//разбиение дочернего узла
void TreeNode::splitChild(int i, TreeNode* y) {
    TreeNode* z = new TreeNode(y->t, y->leaf);
    z->n = t - 1;
    for (int j = 0; j < t - 1; j++)
        z->keys[j] = y->keys[j + t];

    if (y->leaf == false) {
        for (int j = 0; j < t; j++)
            z->C[j] = y->C[j + t];
    }

    y->n = t - 1;
    for (int j = n; j >= i + 1; j--)
        C[j + 1] = C[j];

    C[i + 1] = z;
    for (int j = n - 1; j >= i; j--)
        keys[j + 1] = keys[j];

    keys[i] = y->keys[t - 1];
    n = n + 1;
}

//удаление ключа из B-дерева
void BTree::deleteKey(int k) {
    if (root == NULL) {
        cout << "Дерево пусто.\n";
        return;
    }
    root->deleteKey(k);

    //если корень не пустой, то делаем его корнем
    if (root->n == 0) {
        TreeNode* tmp = root;
        if (root->leaf) {
            root = NULL;
        }
        else {
            root = root->C[0];
        }
        delete tmp;
    }
}
//удаление ключа из узла
void TreeNode::deleteKey(int k) {
    int idx = 0;
    while (idx < n && keys[idx] < k) {
        idx++;
    }

    if (idx < n && keys[idx] == k) {
        if (leaf) {
            removeFromLeaf(idx);
        }
        else {
            removeFromNonLeaf(idx);
        }
    }
    else {
        if (leaf) {
            cout << "Ключ не найден!\n";
            return;
        }

        bool flag = ((idx == n) ? true : false);
        if (C[idx]->n < t) {
            fill(idx);
        }

        if (flag && idx > n) {
            C[idx - 1]->deleteKey(k);
        }
        else {
            C[idx]->deleteKey(k);
        }
    }
}

//удаление ключа из листа
void TreeNode::removeFromLeaf(int idx) {
    for (int i = idx + 1; i < n; i++) {
        keys[i - 1] = keys[i];
    }
    n--;
}

//удаление ключа из неполного внутреннего узла
void TreeNode::removeFromNonLeaf(int idx) {
    int k = keys[idx];

    if (C[idx]->n >= t) {
        int pred = getPred(idx);
        keys[idx] = pred;
        C[idx]->deleteKey(pred);
    }
    else if (C[idx + 1]->n >= t) {
        int succ = getSucc(idx);
        keys[idx] = succ;
        C[idx + 1]->deleteKey(succ);
    }
    else {
        merge(idx);
        C[idx]->deleteKey(k);
    }
}

//получение предшествующего ключа
int TreeNode::getPred(int idx) {
    TreeNode* cur = C[idx];
    while (!cur->leaf) {
        cur = cur->C[cur->n];
    }
    return cur->keys[cur->n - 1];
}

//получение следующего ключа
int TreeNode::getSucc(int idx) {
    TreeNode* cur = C[idx + 1];
    while (!cur->leaf) {
        cur = cur->C[0];
    }
    return cur->keys[0];
}

//заполнение дочернего узла
void TreeNode::fill(int idx) {
    if (idx > 0 && C[idx - 1]->n >= t) {
        merge(idx - 1);
    }
    else if (idx < n && C[idx + 1]->n >= t) {
        merge(idx);
    }
    else {
        if (idx < n) {
            merge(idx);
        }
        else {
            merge(idx - 1);
        }
    }
}

//слияние двух дочерних узлов
void TreeNode::merge(int idx) {
    TreeNode* child = C[idx];
    TreeNode* sibling = C[idx + 1];

    child->keys[t - 1] = keys[idx];

    for (int i = 0; i < sibling->n; i++) {
        child->keys[i + t] = sibling->keys[i];
    }

    if (!child->leaf) {
        for (int i = 0; i <= sibling->n; i++) {
            child->C[i + t] = sibling->C[i];
        }
    }

    for (int i = idx + 1; i < n; i++) {
        keys[i - 1] = keys[i];
    }

    for (int i = idx + 2; i <= n; i++) {
        C[i - 1] = C[i];
    }

    child->n += sibling->n + 1;
    n--;

    delete sibling;
}


//функция для автоматического заполнения дерева
void autoFill(BTree& tree) {
    int keys[] = { 8, 9, 10, 11, 15, 16, 17, 18, 20, 23 };
    for (int key : keys) {
        tree.insert(key);
    }
}

//функция для ручного заполнения дерева
void manualFill(BTree& tree) {
    int n, key;
    cout << "Сколько ключей вы хотите вставить? ";
    cin >> n;
    for (int i = 0; i < n; i++) {
        cout << "Введите ключ " << i + 1 << ": ";
        cin >> key;
        tree.insert(key);
    }
}

//метод для вывода дерева по уровням
void BTree::printTreeByLevels() {
    if (root == NULL) {
        cout << "Дерево пусто.\n";
        return;
    }

    queue<TreeNode*> nodesQueue;
    nodesQueue.push(root);

    int level = 0;
    while (!nodesQueue.empty()) {
        int nodeCount = nodesQueue.size();
        cout << "Уровень " << level << ": ";

        while (nodeCount > 0) {
            TreeNode* node = nodesQueue.front();
            nodesQueue.pop();

            //выводим ключи текущего узла
            cout << "{";
            for (int i = 0; i < node->n; i++) {
                cout << node->keys[i];
                if (i < node->n - 1)
                    cout << " ";
            }
            cout << "} ";

            //если это не лист, добавляем детей в очередь
            if (!node->leaf) {
                for (int i = 0; i <= node->n; i++) {
                    nodesQueue.push(node->C[i]);
                }
            }
            nodeCount--;
        }
        cout << endl;
        level++;
    }
}



int main() {
    setlocale(LC_ALL, "RU");

    int choice;
    BTree t(3);

    cout << "Выберите способ заполнения дерева:\n";
    cout << "1. Вручную\n";
    cout << "2. Автоматически\n";
    cout << "Ваш выбор: ";
    cin >> choice;

    if (choice == 1) {
        manualFill(t);
    }
    else if (choice == 2) {
        autoFill(t);
    }
    else {
        cout << "Неправильный выбор!";
        return 0;
    }

    int option;
    do {
        cout << "\nМеню:\n";
        cout << "1. Вставить новый ключ\n";
        cout << "2. Вывести дерево по уровням\n";
        cout << "3. Поиск ключа\n";
        cout << "4. Удалить ключ\n";
        cout << "5. Выйти\n";
        cout << "Ваш выбор: ";
        cin >> option;

        switch (option) {
        case 1: {
            int key;
            cout << "Введите ключ для вставки: ";
            cin >> key;
            t.insert(key);
            cout << "Ключ " << key << " вставлен.\n";
            break;
        }
        case 2:
            cout << "B-дерево (по уровням):" << endl;
            t.printTreeByLevels();
            break;
        case 3: {
            int key;
            cout << "Введите ключ для поиска: ";
            cin >> key;
            TreeNode* result = t.search(key);
            if (result == NULL)
                cout << "Ключ " << key << " не найден.\n";
            break;
        }
        case 4: {
            int key;
            cout << "Введите ключ для удаления: ";
            cin >> key;
            t.deleteKey(key);
            break;
        }
        case 5:
            cout << "Выход из программы.\n";
            break;
        default:
            cout << "Неправильный выбор! Попробуйте снова.\n";
        }
    } while (option != 5);

    return 0;
}