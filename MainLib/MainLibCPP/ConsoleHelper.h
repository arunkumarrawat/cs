#pragma once
#include <string>
#include <windows.h>
#include <stdarg.h>
#include <tchar.h>
#include "StringHelper.h"
using namespace std;

class ConsoleHelper
{
public:
	ConsoleHelper();
	~ConsoleHelper();
	BOOL PrintStrings(HANDLE hOut, ...);
	BOOL PrintMsg(LPCTSTR pMsg);
	void print(string s);
	void printLine(string s);

	void ReportError(LPCTSTR userMessage, DWORD exitCode, BOOL printErrorMessage);
};

