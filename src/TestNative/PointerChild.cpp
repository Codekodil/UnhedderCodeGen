#include "pch.h"
#include "PointerChild.h"

using namespace TestNative;
using namespace std;

int PointerChild::SumCharacters(string text)
{
	int result = 0;
	for (char c : text)
		result += (int)c;
	return result;
}

void PointerChild::ScaleSpan(span<int> numbers, int scale)
{
	for (int& i : numbers)
		i *= scale;
}
