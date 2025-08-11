#include "pch.h"
#include <iostream>
#include <fstream>
using namespace std;
int main()
{
	ifstream f;
	float a; int n = 0;
	f.open("abc.txt");
	if (f)
	{
		while (!f.eof())
        	{
			f >> a;
			cout << a << "\t";
			n++;
		}
		f.close();
		cout << "n = " << n << endl;
	}
	
	else cout << "File not found" << endl;
	system("pause");
	return 0;
}