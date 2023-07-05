#include "pch.h"
#include "DifferentNamespaceParent.h"

using namespace NotTestNative;

PointerParent::PointerParent() { _child = nullptr; }

void PointerParent::SetChild(TestNative::PointerChild* child)
{
	_child = child;
}
