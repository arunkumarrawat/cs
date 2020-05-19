#include "stdafx.h"
#include "FileHelper.h"


FileHelper::FileHelper()
{
}


FileHelper::~FileHelper()
{
}

int FileHelper::Copy(char *input, char* output) {
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
