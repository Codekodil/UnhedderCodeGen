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

		void ConnectToCallback(SafeObject* target);
		void ConnectAndWaitMultithread(std::span<SafeObject*> waiters);

		void WaitThenSend(int callback);
	};
}