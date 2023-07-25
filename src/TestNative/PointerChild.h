#pragma once

namespace TestNative
{
	class Wrapper_Shared PointerChild
	{
	public:
		PointerChild() {}

		int SumCharacters(std::string text);
		void ScaleSpan(std::span<int> numbers, int scale);
	};
}