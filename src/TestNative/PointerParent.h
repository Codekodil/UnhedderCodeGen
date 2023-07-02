#pragma once

#include "PointerChild.h"

namespace TestNative
{
	class Wrapper_Pointer PointerParent
	{
		PointerChild* _child;
	public:
		PointerParent(short a);

		int Double(int a);

		void SetChild(PointerChild* child);
		bool ChildEquals(TestNative::PointerChild* child);
	};
}