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
	if (!fileExists(fileName)) {
		cout << "file didn't existed" << endl;
		return;
	}
	GetFileAttributesEx(helper.s2ws(fileName), GetFileExInfoStandard, &fInfo);
	bool isDirectory = (fInfo.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) == 0 ? false: true;
	if (isDirectory) {
		cout << "is file: false" << endl;
	}
	else {
		cout << "is file: true" << endl;
	}

	cout << "File Created Time: " << fileTimeToString(fInfo.ftCreationTime) << endl;
	cout << "File Last Access Time: " << fileTimeToString(fInfo.ftLastAccessTime) << endl;
	cout << "File Last Write Time: " << fileTimeToString(fInfo.ftLastWriteTime) << endl;
}

bool FileHelper::fileExists(string fileName)
{
	WIN32_FIND_DATA FindFileData;
	StringHelper helper;
	HANDLE handle = FindFirstFile(helper.s2ws(fileName), &FindFileData);
	bool found = handle != INVALID_HANDLE_VALUE;
	if (found)
	{
		FindClose(handle);
	}
	return found;
}

string FileHelper::fileTimeToString(FILETIME time) {
	SYSTEMTIME utc;
	::FileTimeToSystemTime(std::addressof(time), std::addressof(utc));

	std::ostringstream stm;
	const auto w2 = std::setw(2);
	stm << std::setfill('0') << std::setw(4) << utc.wYear << '-' << w2 << utc.wMonth
		<< '-' << w2 << utc.wDay << ' ' << w2 << utc.wYear << ' ' << w2 << utc.wHour
		<< ':' << w2 << utc.wMinute << ':' << w2 << utc.wSecond << 'Z';

	return stm.str();
}