#include "Supplier.h"

void Supplier::SetAll(string postavshik, string product1, string product2, string product3, string stoimost1, string stoimost2, string stoimost3)
{
	this->postavshik = postavshik;
	this->product1 = product1;
	this->stoimost1 = stoimost1;
	this->product2 = product2;
	this->stoimost2 = stoimost2;
	this->product3 = product3;
	this->stoimost3 = stoimost3;
}

void Supplier::setPostavshik()
{
	cin.ignore();
	getline(cin, this->postavshik);
}

void Supplier::setProduct1()
{
	cin >> this->product1;
}

void Supplier::setProduct2()
{
	cin >> this->product2;
}

void Supplier::setProduct3()
{
	cin >> this->product3;
}

void Supplier::setStoimost1()
{
	cin >> this->stoimost1;
}

void Supplier::setStoimost2()
{
	cin >> this->stoimost2;
}

void Supplier::setStoimost3()
{
	cin >> this->stoimost3;
}

string Supplier::getPostavshik()
{
	return this->postavshik;
}

string Supplier::getProduct1()
{
	return this->product1;
}

string Supplier::getProduct2()
{
	return this->product2;
}

string Supplier::getProduct3()
{
	return this->product3;
}

string Supplier::getStoimost1()
{
	return this->stoimost1;
}

string Supplier::getStoimost2()
{
	return this->stoimost2;
}

string Supplier::getStoimost3()
{
	return this->stoimost3;
}

void Supplier::PrintInfo()
{
	cout << getPostavshik() << endl;
	cout << getProduct1() << " " << getStoimost1() << endl;
	cout << getProduct2() << " " << getStoimost2() << endl;
	cout << getProduct3() << " " << getStoimost3() << endl;
}