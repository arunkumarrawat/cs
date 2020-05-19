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
}
