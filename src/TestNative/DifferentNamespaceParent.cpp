#include "pch.h"
#include "DifferentNamespaceParent.h"

using namespace NotTestNative;

void PointerParent::SetChild(TestNative::PointerChild* child)
{
	_child = child;
}
