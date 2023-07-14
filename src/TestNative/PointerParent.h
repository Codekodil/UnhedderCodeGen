#pragma once

#include "PointerChild.h"

namespace TestNative
{
	class Wrapper_Pointer PointerParent
	{
		PointerChild* _child;
	public:
		PointerParent(short a);
		PointerParent(PointerChild* child);

		int Double(int a);

		void SetChild(PointerChild* child);
		bool ChildEquals(std::shared_ptr<TestNative::PointerChild> child);

		void FillNewChildsShared(std::span<std::shared_ptr<TestNative::PointerChild>> children);
		void FillNewChildsPointer(std::span<TestNative::PointerChild*> children);
		void FillNewParents(std::span<TestNative::PointerParent*> parents);

		PointerChild* MaybeMakePointer(bool isNull);
		std::shared_ptr<PointerChild> MaybeMakeShared(bool isNull);
	};
}