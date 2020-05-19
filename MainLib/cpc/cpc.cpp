// cpc.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "FileHelper.h"

int main(int argc, char* argv[])
{
	if (argc != 3) {
		printf("Usage: cpc file1 file2\n");
		return 1;
	}

	FileHelper helper;
	helper.Copy(argv[1], argv[2]);
    return 0;
}

