#pragma once

#include "PointerChild.h"

namespace TestNative
{
	class Wrapper_Generate PointerParent
	{
		PointerChild* _child;
	public:
		PointerParent(short a);
		PointerParent(PointerChild* child);

		int Double(int a);
		void Double(int* a);

		void SetChild(PointerChild* child);
		bool ChildEquals(std::shared_ptr<TestNative::PointerChild> child);

		void FillNewChildren(std::span<std::shared_ptr<TestNative::PointerChild>> children);
		void FillNewParents(std::span<TestNative::PointerParent*> parents);

		std::shared_ptr<PointerChild> MaybeMake(bool isNull);
	};
}