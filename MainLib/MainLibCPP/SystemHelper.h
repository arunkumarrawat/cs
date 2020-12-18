#pragma once
#include <windows.h>
#include <stdio.h>

#pragma comment( lib, "user32.lib" )

class SystemHelper
{
public:
	SystemHelper();
	~SystemHelper();

	bool lock();
};

