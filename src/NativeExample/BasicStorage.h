#pragma once

namespace Example
{
	class __declspec(dllexport) BasicStorage
	{
		int _number;
	public:
		BasicStorage();
		BasicStorage(int number);
		int GetNumber();
		void SetNumber(int number);
		int Multiply(int other);
	};
}