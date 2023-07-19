#include "pch.h"
#include "Lookups.h"

using namespace TestNative;
using namespace std;

LookupPointer::LookupPointer(shared_ptr<LookupShared> ptr)
{
	_ptr = ptr;
}

shared_ptr<LookupShared> LookupPointer::GetPtr()
{
	return _ptr;
}

LookupShared::LookupShared(LookupPointer* ptr)
{
	_ptr = ptr;
}

LookupPointer* LookupShared::GetPtr()
{
	return _ptr;
}
