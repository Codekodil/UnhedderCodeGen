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
		void T1(int& other) { other *= 2; }
		void t2(int* other) { *other = *other * 2; }
	};
}