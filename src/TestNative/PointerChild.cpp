#include "pch.h"
#include "PointerChild.h"

using namespace TestNative;

PointerChild::PointerChild() {}

void PointerChild::Invoke()
{
	auto event = Event;
	if (event != nullptr)
		event();
}