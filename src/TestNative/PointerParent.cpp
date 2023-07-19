#include "pch.h"
#include "PointerParent.h"

using namespace TestNative;
using namespace std;

PointerParent::PointerParent(short a)
{
	SetChild(nullptr);
}

PointerParent::PointerParent(PointerChild* child)
{
	SetChild(child);
}

int PointerParent::Double(int a)
{
	return a * 2;
}

void PointerParent::Double(int* a)
{
	*a *= 2;
}

void PointerParent::SetChild(PointerChild* child)
{
	_child = child;
}

bool PointerParent::ChildEquals(shared_ptr<PointerChild> child)
{
	return child.get() == _child;
}

void PointerParent::FillNewChildren(span<shared_ptr<PointerChild>> children)
{
	for (auto& child : children)
		if (child == nullptr)
			child = make_shared<PointerChild>();
}

void PointerParent::FillNewParents(span<PointerParent*> parents)
{
	for (auto& parent : parents)
		if (parent == nullptr)
			parent = new PointerParent(_child);
}

shared_ptr<PointerChild> PointerParent::MaybeMake(bool isNull)
{
	return isNull ? nullptr : make_shared<PointerChild>();
}
