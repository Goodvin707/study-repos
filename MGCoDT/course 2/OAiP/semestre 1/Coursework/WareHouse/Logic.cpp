#include "Logic.h"

Supplier CreateSupplier(Supplier S) // ���������� ����������
{
	cout << "������� �������� �����: ";
	S.setPostavshik();
	cout << "������� 1-� �������: ";
	S.setProduct1();
	cout << "������� ��� ����: ";
	do
	{
		try
		{
			S.setStoimost1();
			if (stoi(S.getStoimost1()) < 0 || stoi(S.getStoimost1()) > 10000)
				throw 1;
			break;
		}
		catch (invalid_argument) { cout << "������!" << endl; }
		catch (out_of_range) { cout << "������!" << endl; }
		catch (int a) { cout << "������!" << endl; }
	} while (true);
	cout << "������� 2-� �������: ";
	S.setProduct2();
	cout << "������� ��� ����: ";
	do
	{
		try
		{
			S.setStoimost2();
			if (stoi(S.getStoimost2()) < 0 || stoi(S.getStoimost2()) > 10000)
				throw 1;
			break;
		}
		catch (invalid_argument) { cout << "������!" << endl; }
		catch (out_of_range) { cout << "������!" << endl; }
		catch (int a) { cout << "������!" << endl; }
	} while (true);
	cout << "������� 3-� �������: ";
	S.setProduct3();
	cout << "������� ��� ����: ";
	do
	{
		try
		{
			S.setStoimost3();
			if (stoi(S.getStoimost3()) < 0 || stoi(S.getStoimost3()) > 10000)
				throw 1;
			break;
		}
		catch (invalid_argument) { cout << "������!" << endl; }
		catch (out_of_range) { cout << "������!" << endl; }
		catch (int a) { cout << "������!" << endl; }
	} while (true);
	return S;
}

string PrintSuppliers(Supplier S, string tname, string tstoimost) // ������ ����������� �� ���������
{
	if (S.getProduct1() == tname && stoi(S.getStoimost1()) <= stoi(tstoimost))
	{
		S.PrintInfo();
		return S.getPostavshik();
	}
	if (S.getProduct2() == tname && stoi(S.getStoimost2()) <= stoi(tstoimost))
	{
		S.PrintInfo();
		return S.getPostavshik();
	}
	if (S.getProduct3() == tname && stoi(S.getStoimost3()) <= stoi(tstoimost))
	{
		S.PrintInfo();
		return S.getPostavshik();
	}
	return "";
}


string CreateOrder(vector<string> vv, Supplier S, string tname, string postavshik) // ������ ��������
{
	bool flag = false;
	do {
		for (int i = 0; i < vv.size(); i++)
		{
			if (postavshik == vv[i])
			{
				flag = false;
				break;
			}
			else
			{
				flag = true;
			}
		}
	} while (flag);
	string tstoimost;
	if (tname == S.getProduct1())
	{
		tstoimost = S.getStoimost1();
	}
	if (tname == S.getProduct2())
	{
		tstoimost = S.getStoimost2();
	}
	if (tname == S.getProduct3())
	{
		tstoimost = S.getStoimost3();
	}
	return postavshik + ": ������� " + tname + " �� ����������: " + tstoimost;
}

void PrintOrders(vector<string> vv) // ����� ��������
{
	cout << "������: " << endl;
	for (int i = 0; i < vv.size(); i++)
	{
		cout << vv[i] << endl;
	}
}