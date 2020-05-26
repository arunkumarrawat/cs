#include "stdafx.h"
#include "StringHelperTest.h"


StringHelperTest::StringHelperTest()
{
}


StringHelperTest::~StringHelperTest()
{
}

void StringHelperTest::Entry() {
	char * input = "this is char array";
	StringHelper helper;
	string output = helper.charToString(input);
	cout << output << endl;

	vector<string> v = helper.splitString(input, ' ');

	for (string s : v) {
		cout << s << endl;
	}
}
