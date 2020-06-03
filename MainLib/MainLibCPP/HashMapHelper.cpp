#include "stdafx.h"
#include "HashMapHelper.h"


HashMapHelper::HashMapHelper()
{
}


HashMapHelper::~HashMapHelper()
{
}

void HashMapHelper::put(const void *key, const void *value) {
	htmap[key] = value;
}

const void * HashMapHelper::get(const void * key)
{
	return htmap[key];
}
