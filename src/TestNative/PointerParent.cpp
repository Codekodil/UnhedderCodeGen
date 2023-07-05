#include "pch.h"
#include "PointerParent.h"

using namespace TestNative;

PointerParent::PointerParent(short a) {}

PointerParent::PointerParent(PointerChild* child)
{
	SetChild(child);
}

int PointerParent::Double(int a)
{
	return a * 2;
}

void PointerParent::SetChild(PointerChild* child)
{
	_child = child;
}

bool PointerParent::ChildEquals(PointerChild* child)
{
	return child == _child;
}
