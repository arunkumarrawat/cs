#include "stdafx.h"
#include "HashMapHelperTest.h"


HashMapHelperTest::HashMapHelperTest()
{
}


HashMapHelperTest::~HashMapHelperTest()
{
}

void HashMapHelperTest::Entry()
{
	HashMapHelper ht;
	ht.put("Bob", "Dylan");
	int one = 1;
	ht.put("one", &one);
	std::cout << (char *)ht.get("Bob") << "; " << *(int *)ht.get("one");
}
