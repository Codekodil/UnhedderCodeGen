#include "pch.h"
#include "SafeObject.h"

using namespace TestNative;
using namespace std;

SafeObject::~SafeObject()
{
	auto call = _connectedCallback;
	if (call)
		call(-1);
}

void SafeObject::ConnectToCallback(SafeObject* target)
{
	_connectedCallback = target->Callback;
}

struct threadMemory
{
	SafeObject* SafeObject;
	int Index;
};

void threadAction(threadMemory memory)
{
	memory.SafeObject->WaitThenSend(memory.Index);
}

void SafeObject::ConnectAndWaitMultithread(span<shared_ptr<SafeObject>> waiters)
{
	vector<jthread> threads(waiters.size());

	for (int i = 0; i < waiters.size(); i++)
	{
		auto& waiter = waiters[i];
		if (waiter)
		{
			waiter->ConnectToCallback(this);
			threads[i] = jthread(threadAction, threadMemory{ .SafeObject = waiter.get(), .Index = i});
		}
	}
}

void SafeObject::WaitThenSend(int callback)
{
	auto await = Await;
	if (await)
		await();

	auto call = _connectedCallback;
	if (call)
		call(callback);
}
