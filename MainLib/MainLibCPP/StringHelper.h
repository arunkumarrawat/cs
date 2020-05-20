#pragma once

#include <iostream>
#include <string>
using namespace std;
class StringHelper
{
public:
	StringHelper();
	~StringHelper();

	string charToString(char *input);
	int size(string s);
};

