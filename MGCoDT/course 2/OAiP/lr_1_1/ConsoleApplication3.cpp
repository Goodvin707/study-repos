#include "pch.h"
#include <iostream>
#include <fstream>
using namespace std;
int main() {
	int a[20], x, y;
	ifstream fin("input.txt");
	ofstream fout("output.txt");
	if (!fin.is_open())
		cout << "Файл не может быть открыт!\n";
	else
	{
		for (int i = 0; i < 20; i++) {
			fin >> a[i];
		}
		cin >> x >> y;
		for (int i = 0; i < 20; i++) {
			if (a[i] < y && a[i] > x) {
				a[i] = 0;
			}
		}
		for (int i = 0; i < 20; i++) {
			cout << a[i]<<" ";
			fout << a[i]<<" ";
		}
		fin.close();
		fout.close();

	}
}