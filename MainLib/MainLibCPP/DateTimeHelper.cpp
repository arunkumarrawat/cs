#include "stdafx.h"
#include "DateTimeHelper.h"


DateTimeHelper::DateTimeHelper()
{
}


DateTimeHelper::~DateTimeHelper()
{
}

void DateTimeHelper::CurrentTime()
{
	SYSTEMTIME time;
	::GetLocalTime(&time);
	string monthName[] = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", 
		"Aug", "Sep","Oct", "Nov", "Dec"};
	cout << time.wYear << "-" << monthName[time.wMonth - 1] << "-" << time.wDay << " "
		 << time.wHour << ":" << time.wMinute << ":" << time.wSecond
		 << endl;
}
