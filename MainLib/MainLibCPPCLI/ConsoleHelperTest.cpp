#include "stdafx.h"
#include "ConsoleHelperTest.h"


ConsoleHelperTest::ConsoleHelperTest()
{
}


ConsoleHelperTest::~ConsoleHelperTest()
{
}

void ConsoleHelperTest::Entry()
{
	ConsoleHelper consoleHelper;
	consoleHelper.printLine("print message using stdHandler");
}
