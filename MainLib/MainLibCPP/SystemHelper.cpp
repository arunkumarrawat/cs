#include "stdafx.h"
#include "SystemHelper.h"


SystemHelper::SystemHelper()
{
}


SystemHelper::~SystemHelper()
{
}

bool SystemHelper::lock()
{
	return LockWorkStation();
}
