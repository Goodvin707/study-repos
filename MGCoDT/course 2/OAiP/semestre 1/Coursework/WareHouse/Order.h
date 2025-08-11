#pragma once
#include <iostream>
#include <string>
#include <cstring>
#include <vector>
using namespace std;

class Product
{
	string name;
	string kolvo;
	string stoimost;
	string postavshik;
public:
	void setName();
	void setKolvo();
	void setStoimost();
	void setPostavshik();
	string getName();
	string getKolvo();
	string getStoimost();
	string getPostavshik();
	void PrintInfo();
};