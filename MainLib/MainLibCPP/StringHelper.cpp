#include "stdafx.h"
#include "StringHelper.h"


StringHelper::StringHelper()
{
}


StringHelper::~StringHelper()
{
}

string StringHelper::charToString(char *input) {
	string s(input);
	return s;
}

int StringHelper::size(string s) {
	if (s.empty()) return 0;
	return s.size();
}
