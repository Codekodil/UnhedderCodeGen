#pragma once

namespace TestNative
{
	class Wrapper_Shared Wrapper_ThreadSafe SafeObject
	{
		void(__stdcall* _connectedCallback)(int index) = nullptr;
	public:
		SafeObject() {}
		~SafeObject();

		void(__stdcall* Callback)(int index) = nullptr;
		void(__stdcall* Await)() = nullptr;

		void ConnectCallback(SafeObject* target);

		void WaitThenSend(int callback);
	};
}