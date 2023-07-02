#include "pch.h"
#include "PointerChild.h"

using namespace TestNative;

void PointerChild::Invoke()
{
	auto event = Event;
	if (event != nullptr)
		event();
}