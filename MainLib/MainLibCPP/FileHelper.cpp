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

int FileHelper::CopyW(string input, string output)
{
	StringHelper helper;

	HANDLE hIn, hOut;
	DWORD nIn, nOut;
	CHAR buffer[BUF_SIZE];

	hIn = CreateFile(helper.s2ws(input), GENERIC_READ, FILE_SHARE_READ, NULL,
		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hIn == INVALID_HANDLE_VALUE) {
		cout << "Can not open input file. Error: " << GetLastError() << endl;
		return 2;
	}

	hOut = CreateFile(helper.s2ws(output), GENERIC_WRITE, 0, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hIn == INVALID_HANDLE_VALUE) {
		cout << "Can not open output file. Error: " << GetLastError() << endl;
		return 2;
	}

	while (ReadFile(hIn, buffer, BUF_SIZE, &nIn, NULL) && nIn > 0) {
		WriteFile(hOut, buffer, nIn, &nOut, NULL);

		if (nIn != nOut) {
			cout << "Fatal Write Error" << GetLastError() << endl;
			return 4;
		}
	}

	CloseHandle(hIn);
	CloseHandle(hOut);

	return 0;
}

int FileHelper::CatW(string input)
{
	HANDLE hInFile, hStdIn = GetStdHandle(STD_INPUT_HANDLE);
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

	StringHelper helper;
	hInFile = CreateFile(helper.s2ws(input), GENERIC_READ, FILE_SHARE_READ, NULL,
		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

	DWORD nIn, nOut;
	BYTE buffer[BUF_SIZE];
	while (ReadFile(hInFile, buffer, BUF_SIZE, &nIn, NULL) && nIn > 0) {
		WriteFile(hStdOut, buffer, nIn, &nOut, NULL);

		if (nIn != nOut) {
			cout << "Fatal Write Error" << GetLastError() << endl;
			return 4;
		}
	}
	CloseHandle(hInFile);
	CloseHandle(hStdIn);
	CloseHandle(hStdOut);
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