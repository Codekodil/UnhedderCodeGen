#pragma once

namespace TestNative
{
	class Wrapper_Shared PointerChild
	{
	public:
		PointerChild();

		void(__stdcall* Event)() = nullptr;

		void Invoke();
	};
}