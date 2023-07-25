#pragma once

namespace TestNative
{
	class Wrapper_Pointer EventContainer
	{
	public:
		EventContainer() {}

		void(__stdcall* Event)() = nullptr;
		void Invoke();

		int(__stdcall* Hash)(int n) = nullptr;
		int GetHash(int n);

		int* (__stdcall* Ptr)() = nullptr;
		int PtrValue();

		void(__stdcall* Receive)(void* ptr, int* index) = nullptr;
		void SendSelf(int* index);
	};
}
