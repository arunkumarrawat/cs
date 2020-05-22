#pragma once

#include <iostream>
#include <string>
#include <vector>
#include <Windows.h>
using namespace std;
class StringHelper
{
public:
	StringHelper();
	~StringHelper();

	string charToString(char *input);
	int size(string s);
	vector<string> splitString(string s, char c);
	wstring s2ws(const string &s);
	LPCWSTR stringToLPCWSTR(string &s);
};

