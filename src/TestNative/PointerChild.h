#pragma once

namespace TestNative
{
	class Wrapper_Shared PointerChild
	{
	public:
		PointerChild();

		void(__stdcall* Event)() = nullptr;

		void Invoke();

		int SumCharacters(std::string text);
		void ScaleSpan(std::span<int> numbers, int scale);
	};
}