/*Выполните приведенные ниже задания (для всех вариантов!).
1.	Реализуйте программу, в которой выполняется алгоритм обхода графа на основе поиска в глубину.
2.	Реализуйте программу, в которой выполняется алгоритм обхода графа на основе поиска в ширину.
3.	Используйте обход графа в ширину для определения всех вершин графа, находящихся на фиксированном расстоянии d от данной вершины.
4.	Перенумеруйте вершины графа в порядке обхода в глубину и вычислите среднюю плотность графа как частное от деления количества его ребер на число вершин. Можно ли оба эти действия выполнить за один обход графа?
5.	В вершинах неориентированного графа хранятся положительные целые числа. Подсчитайте количество пар дружественных чисел в вершинах графа, которые соединены ребрами.*/
#include <iostream>
#include<queue>
using namespace std;
void searchdeep(int *vertex, int st,int **mass,int n) {
    int r;
    cout << st + 1 << " ";
    vertex[st] = 1;
    for (r = 0; r < n; r++) {
        if (mass[st][r] != 0 && vertex[r] == 0) {
            searchdeep(vertex, r, mass,n);
        }
    }
}
void searchwidth(int* vertex, int st, int** mass, int n) {
    for (int i = 0; i < n; i++) {
        vertex[i] = 0;
    }
    queue<int> Q;
    vertex[2] = 1;
    Q.push(2);
    while (!Q.empty()) {
        int node = Q.front();
        cout << node + 1 << "\n";
        
        Q.pop();
        vertex[node] = 2;
        for (int i = 0; i < n; i++) {
            if (mass[node][i]==1 && vertex[i]==0) {
                Q.push(i);
                vertex[i] = 1;
            }
        }
    }
}
void searchwidthnum(int* vertex, int st, int** mass, int n) {
    for (int i = 0; i < n; i++) {
        vertex[i] = 0;
    }
    int k = 0,kolreber=0,kolvertex=0;
    queue<int> Q;
    vertex[2] = 1;
    Q.push(2);
    while (!Q.empty()) {
        k++;
        int node = Q.front();
        cout << node + 1 << "\n";
        Q.pop();
        vertex[node] = 2;
        for (int i = 0; i < n; i++) {
            if (mass[node][i] == 1 && vertex[i] == 0 && k==1) {
                Q.push(i);
                vertex[i] = 1;
            }
        }
    }
}
void sredplot(int** mass, int vertex,int n) {
    int kolreb = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (mass[i][j] == 1) {
                kolreb++;
            }
        }
    }
    cout << kolreb / vertex << "\n";
}
int main()
{
    queue<int>Queue;
    int** mass = new int*[6];
    for (int i = 0; i < 6; i++) {
        mass[i] = new int[6];
        for (int j = 0; j < 6; j++) {
            mass[i][j] = rand() % 2;
            cout << mass[i][j] << " ";
        }
        cout << endl;
    }
    int* vertex = new int[6];
    for (int i = 0; i < 6; i++) {
        vertex[i] = 0; 
    }
   Queue.push(0);
    while (!Queue.empty()) {
        int node = Queue.front();
        Queue.pop();
        vertex[node] = 2;
        for (int j=0; j < 6; j++) {
            if (mass[node][j] == 1 && vertex[j] == 0) {
                Queue.push(j);
                vertex[j] = 1;
            }
        }
        cout << node + 1<<endl;
    }
    cout << "\n---------\n";
    for (int i = 0; i < 6; i++) {
        vertex[i] = 0;
    }
    searchdeep(vertex, 0, mass,6);
    cout << "\n---------\n";
    searchwidth(vertex, 0, mass,6);
    cout << "\n---------\n";
    searchwidthnum(vertex, 0, mass, 6);
    cout << "\n---------\n";
    sredplot(mass, 6, 6);
    system("pause");
    return 0;   
}