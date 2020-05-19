#include <stdio.h>

#define BUF_SIZE 256

class FileHelper
{
public:
	FileHelper();
	~FileHelper();
	int Copy(char *input, char* output);
};

