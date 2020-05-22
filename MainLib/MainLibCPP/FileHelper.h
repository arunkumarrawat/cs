#include <stdio.h>
#include <string>
#include <windows.h>
#include "StringHelper.h"
using namespace std;
#define BUF_SIZE 256

class FileHelper
{
public:
	FileHelper();
	~FileHelper();
	int Copy(char *input, char* output);
	void info(string fileName);
	int fileExists(string fileName);
};

