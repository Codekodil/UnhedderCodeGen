#pragma once

#include "PointerChild.h"

namespace NotTestNative
{
	class Wrapper_Shared PointerParent
	{
		TestNative::PointerChild* _child;
	public:
		PointerParent();

		void SetChild(TestNative::PointerChild* child);
	};
}