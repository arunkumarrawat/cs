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

vector<string> StringHelper::splitString(string s, char c)
{
	vector<string> output;


	int start = 0;

	for (int i = 0; i < s.size(); i++) {
		if (s[i] != c) {
			continue;
		}
		else {
			int* temp = new int[i - start];
		}
	}
	return output;
}

wstring StringHelper::s2ws(const string & s)
{
	int len;
	int slength = (int)s.length() + 1;
	len = MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, 0, 0);
	wchar_t* buf = new wchar_t[len];
	MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, buf, len);
	std::wstring r(buf);
	delete[] buf;
	return r;
}

LPCWSTR StringHelper::stringToLPCWSTR(string & s)
{
	std::wstring stemp = s2ws(s);
	LPCWSTR result = stemp.c_str();
	return result;
}
