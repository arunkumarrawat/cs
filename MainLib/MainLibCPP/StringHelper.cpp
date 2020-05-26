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

	char *array = new char[s.size()];


	int start = 0;

	int counter = 0;
	for (int i = 0; i < s.size(); i++) {
		if (s[i] != c) {
			array[counter++] = s[i];
			continue;
		}
		else {
			array[counter] = '\0';
			output.push_back(array);
			memset(array, 0, s.size() * sizeof(char));
			counter = 0;
		}
	}

	if (counter > 0) {
		array[counter] = '\0';
		output.push_back(array);
		memset(array, 0, s.size() * sizeof(char));
		counter = 0;
	}

	return output;
}

LPCWSTR StringHelper::s2ws(string s)
{
	size_t convertedChars = 0;
	const size_t newsizew = strlen(s.c_str()) + 1;
	wchar_t *wcstring = new wchar_t[newsizew];
	mbstowcs_s(&convertedChars, wcstring, newsizew, s.c_str(), _TRUNCATE);
	return wcstring;
}
