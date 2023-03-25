#include "BasicStorage.h"

using namespace Example;

BasicStorage::BasicStorage()
{
	_number = 0;
}

BasicStorage::BasicStorage(int number)
{
	_number = number;
}

int BasicStorage::GetNumber()
{
	return _number;
}

void BasicStorage::SetNumber(int number)
{
	_number = number;
}

int BasicStorage::Multiply(int other)
{
	return _number * other;
}
