#pragma once

#include "PointerChild.h"

namespace NotTestNative
{
	class Wrapper_Pointer PointerParent
	{
		TestNative::PointerChild* _child;
	public:
		void SetChild(TestNative::PointerChild* child);
	};
}