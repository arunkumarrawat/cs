#include <stdio.h>
#include <string>
#include <windows.h>
#include <sstream>
#include <iomanip>

#include "StringHelper.h"
using namespace std;
#define BUF_SIZE 256

class FileHelper
{
public:
	FileHelper();
	~FileHelper();
	int Copy(char *input, char* output);
	int CopyW(string input, string output);
	void info(string fileName);
	bool fileExists(string fileName);
	string fileTimeToString(FILETIME time);
};

