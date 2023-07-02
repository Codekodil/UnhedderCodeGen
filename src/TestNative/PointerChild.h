#pragma once

namespace TestNative
{
	class Wrapper_Pointer PointerChild
	{
	public:
		void(__stdcall* Event)() = nullptr;

		void Invoke();
	};
}