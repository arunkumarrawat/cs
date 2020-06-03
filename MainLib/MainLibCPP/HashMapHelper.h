#pragma once
#include <iostream>
#include <unordered_map>

class HashMapHelper
{
	std::unordered_map<const void *, const void *> htmap;

public:
	HashMapHelper();
	~HashMapHelper();
	void put(const void *key, const void *value);
	const void *get(const void *key);
};

