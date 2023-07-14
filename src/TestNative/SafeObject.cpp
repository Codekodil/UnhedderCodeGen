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

void SafeObject::ConnectCallback(SafeObject* target)
{
	_connectedCallback = target->Callback;
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
