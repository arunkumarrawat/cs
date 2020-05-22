#include "stdafx.h"
#include "FileHelper.h"


FileHelper::FileHelper()
{
}


FileHelper::~FileHelper()
{
}

int FileHelper::Copy(char *input, char* output) {

	// @todo: 1. show copy speed 
	// 2. if output is folder, then split string and get original file name

#pragma warning(disable:4996)
	FILE *inFile, *outFile;
	char rec[BUF_SIZE];

	size_t bytesIn, bytesOut;

	inFile = fopen(input, "rb");
	if (inFile == NULL) {
		perror(input);
		return 2;
	}

	outFile = fopen(output, "wb");

	if (outFile == NULL) {
		perror(output);
		return 3;
	}

	while ((bytesIn = fread(rec, 1, BUF_SIZE, inFile)) > 0) {
		bytesOut = fwrite(rec, 1, bytesIn, outFile);

		if (bytesOut != bytesIn) {
			perror("Fatal write error");
			return 4;
		}
	}

	fclose(inFile);
	fclose(outFile);

	return 0;
}

void FileHelper::info(string fileName)
{

	StringHelper helper;
	WIN32_FILE_ATTRIBUTE_DATA fInfo;

	GetFileAttributesEx(helper.stringToLPCWSTR(fileName), GetFileExInfoStandard, &fInfo);
}

int FileHelper::fileExists(string fileName)
{
	WIN32_FIND_DATA FindFileData;
	StringHelper helper;
	HANDLE handle = FindFirstFile(helper.stringToLPCWSTR(fileName), &FindFileData);
	int found = handle != INVALID_HANDLE_VALUE;
	if (found)
	{
		FindClose(handle);
	}
	return found;
}
