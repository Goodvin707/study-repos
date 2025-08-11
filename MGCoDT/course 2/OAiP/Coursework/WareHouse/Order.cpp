#include "Order.h"

void Product::setName()
{
	cin >> this->name;
}

void Product::setKolvo()
{
	cin >> this->kolvo;
}

void Product::setStoimost()
{
	cin >> this->stoimost;
}

void Product::setPostavshik()
{
	cin >> this->postavshik;
}

string Product::getName()
{
	return this->name;
}

string Product::getKolvo()
{
	return this->kolvo;
}

string Product::getStoimost()
{
	return this->stoimost;
}

string Product::getPostavshik()
{
	return this->postavshik;
}

void Product::PrintInfo()
{
	cout << getName() << endl;
	cout << getKolvo() << endl;
	cout << getStoimost() << endl;
}