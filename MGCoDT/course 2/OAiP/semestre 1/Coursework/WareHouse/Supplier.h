#pragma once
#include <iostream>
#include <string>
#include <cstring>
#include <vector>
using namespace std;

class Supplier
{
	string postavshik;
	string product1;
	string product2;
	string product3;
	string stoimost1;
	string stoimost2;
	string stoimost3;
public:
	void SetAll(string postavshik, string product1, string product2, string product3, string stoimost1, string stoimost2, string stoimost3);
	void setPostavshik();
	void setProduct1();
	void setProduct2();
	void setProduct3();
	void setStoimost1();
	void setStoimost2();
	void setStoimost3();
	string getPostavshik();
	string getProduct1();
	string getProduct2();
	string getProduct3();
	string getStoimost1();
	string getStoimost2();
	string getStoimost3();
	void PrintInfo();
};