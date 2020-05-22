#pragma once

#include <iostream>
#include <string>
#include <vector>
#include <Windows.h>
#include "atlbase.h"
#include "atlstr.h"
#include "comutil.h"

using namespace std;
class StringHelper
{
public:
	StringHelper();
	~StringHelper();

	string charToString(char *input);
	int size(string s);
	vector<string> splitString(string s, char c);
	LPCWSTR s2ws(string s);
};

