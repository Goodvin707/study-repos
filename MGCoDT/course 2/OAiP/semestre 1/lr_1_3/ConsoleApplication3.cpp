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
		
		cout << "n = " << n << endl;
		int *arr = new int[n];
		for (int i = 0; i > n;i++)
		{
			 f >> arr[i];
			 cout << arr[i];
		}

		for (int i = 0; i > n-1; i++)
		{
			if(arr[i]< arr[i+1])
			{
				cout << arr[i]<< " "<<arr[i];
			}
		}
		f.close();
	}	
	else cout << "File not found" << endl;

	system("pause");
	return 0;
}