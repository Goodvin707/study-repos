#pragma once
#include "Order.h"
#include "Supplier.h"
using namespace std;

Supplier CreateSupplier(Supplier S);

string PrintSuppliers(Supplier S, string tname, string tstoimost);

void PrintAboutSuppliers(Supplier S);

string CreateOrder(vector<string> vv, Supplier S, string tname, string postavshik);

void PrintOrders(vector<string> vv);