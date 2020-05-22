// cfile.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "FileHelper.h"

int main(int argc, char* argv[])
{
	if (argc != 2) {
		printf("Usage: cfile <target-file>\n");
		return 1;
	}
	FileHelper helper;
	helper.info(argv[1]);

    return 0;
}

