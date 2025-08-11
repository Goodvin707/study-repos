BOOK.h
#pragma once
#include "pch.h"
#include <iostream>
#include <string>
using namespace std;
class BOOK
{
private:
	float regname;
	string name;
	string book;
	int page;
public:
	void setName();
	void setRegname();
	void setBook();
	void setPage();
	string getName();
	float getRegname();
	string getBook();
	void check(float num);
};