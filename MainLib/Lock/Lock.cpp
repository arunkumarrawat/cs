// Lock.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "SystemHelper.h"

int main()
{
	// Lock the workstation.
	SystemHelper system;
	if (!system.lock())
		printf("LockWorkStation failed with %d\n", GetLastError());
    return 0;
}

