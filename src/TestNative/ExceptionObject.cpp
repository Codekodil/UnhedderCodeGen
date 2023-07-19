#include "pch.h"
#include "ExceptionObject.h"

using namespace TestNative;
using namespace std;

ExceptionObject::ExceptionObject(string message)
{
	throw exception(message.c_str());
}

void ExceptionObject::Throw(string message)
{
	throw exception(message.c_str());
}

void ExceptionObject::ThrowArgument()
{
	throw exception("ArgumentException");
}
