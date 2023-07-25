#include "pch.h"
#include "EventContainer.h"

using namespace TestNative;
using namespace std;

void EventContainer::Invoke()
{
	auto event = Event;
	if (event != nullptr)
		event();
}

int EventContainer::GetHash(int n)
{
	auto hash = Hash;
	if (hash != nullptr)
		return hash(n);
	throw exception("no hash");
}

int TestNative::EventContainer::PtrValue()
{
	auto ptrGet = Ptr;
	if (ptrGet != nullptr)
	{
		auto ptr = ptrGet();
		if (ptr)
			return *ptr;
		throw exception("null ptr");
	}
	throw exception("no ptr");
}

void EventContainer::SendSelf(int* index)
{
	auto receive = Receive;
	if (receive != nullptr)
		return receive(this, index);
	throw exception("no receive");
}
