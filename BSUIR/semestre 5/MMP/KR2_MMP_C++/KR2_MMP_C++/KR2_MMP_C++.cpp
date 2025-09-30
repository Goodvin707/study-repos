#include <iostream>
#include <vector>
#include <iomanip>
#include <cmath>
#include <limits>
#include <algorithm>

using namespace std;

class BellmanSolver {
private:
    int N;
    double delta_t;
    double x_final;
    vector<double> x_states;

    struct State {
        double cost;
        double next_x;
    };

    vector<vector<State>> dp;

public:
    BellmanSolver(int steps, double dt, double x_end, vector<double> x_list)
        : N(steps), delta_t(dt), x_final(x_end), x_states(x_list)
    {
        reverse(x_states.begin(), x_states.end());
        dp.resize(N, vector<State>(x_states.size()));
    }

    void solve() {
        // Инициализация последнего шага (k=N-1)
        int last_k = N - 1;
        for (int i = 0; i < x_states.size(); ++i) {
            double x_k = x_states[i];
            double u = (x_final - x_k) / delta_t + x_k;
            double J = (pow(x_k, 2) + pow(u, 2)) * delta_t;
            dp[last_k][i] = {J, x_final};
        }

        // Обратный проход
        for (int k = N-2; k >= 0; --k) {
            for (int i = 0; i < x_states.size(); ++i) {
                double x_k = x_states[i];
                double min_cost = numeric_limits<double>::max();
                double best_next_x = x_states[0];

                for (int j = 0; j < x_states.size(); ++j) {
                    double x_next = x_states[j];
                    if (x_next < x_k) continue;  // Только переходы в будущее
                    double u = (x_next - x_k) / delta_t + x_k;
                    double J_step = (pow(x_k, 2) + pow(u, 2)) * delta_t;
                    double total_cost = J_step + dp[k+1][j].cost;

                    if (total_cost < min_cost) {
                        min_cost = total_cost;
                        best_next_x = x_next;
                    }
                }
                dp[k][i] = {min_cost, best_next_x};
            }
        }
    }

    void printTables() {
        cout << fixed << setprecision(3);
        for (int k = N-1; k >= 0; --k) {
            cout << "======== Шаг k = " << k << " (t = " << k*delta_t << ") ========" << endl;

            if (k != 0) 
            {
                // Таблица 1: Общие результаты
                cout << "\nТаблица общих результатов:\n";
                cout << "-------------------------------------\n";
                cout << "x(k)    x(k+1)  Δx      S(k, x(k))\n";
                cout << "-------------------------------------\n";

                for (int i = 0; i < x_states.size(); ++i) {
                    double x_k = x_states[i];
                    double x_next = dp[k][i].next_x;
                    double delta_x = x_next - x_k;
                    cout << x_k << "    " << x_next << "    " << delta_x << "    " << dp[k][i].cost << endl;
                }
            }

            // Таблица 2: Подробные расчеты (Начиная со второго шага)
            if (k < N-1) { // Выводим для k = N-2 до 0
                cout << "\nПодробные расчеты:\n";
                for (int i = 0; i < x_states.size(); ++i) {
                    double x_k = x_states[i];
                    
                    // Для k=0, рассматриваем только x(0)=0
                    if (k == 0 && x_k != 0.0) continue;

                    cout << "\nДля x(" << k << ") = " << x_k << ":\n";
                    cout << "--------------------------------------------------------\n";
                    cout << "x(k)    x(k+1)  Δx      ΔJ_k + S(k+1)\n";
                    cout << "--------------------------------------------------------\n";
                    for (int j = 0; j < x_states.size(); ++j) {
                        double x_next = x_states[j];
                        if (x_next < x_k) continue;
                        double u = (x_next - x_k) / delta_t + x_k;
                        double J_step = (pow(x_k, 2) + pow(u, 2)) * delta_t;
                        double S_next = dp[k+1][j].cost;

                        cout << x_k << "    " << x_next << "    " << (x_next - x_k) << "    "
                             << J_step << " + " << S_next << " = " << J_step + S_next << endl;
                    }
                }
            }
        }
    }
};

int main() {
    setlocale(LC_ALL, "ru");
    int N = 10;
    double delta_t = 0.5;
    double x_final = 5.0;
    vector<double> x_states;
    for (double x = 0.0; x <= x_final; x += delta_t) {
        x_states.push_back(x);
    }

    BellmanSolver solver(N, delta_t, x_final, x_states);
    solver.solve();
    solver.printTables();

    system("pause");
    return 0;
}