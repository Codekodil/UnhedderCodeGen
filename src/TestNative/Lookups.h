#pragma once

namespace TestNative
{
	class LookupShared;

	class Wrapper_Pointer Wrapper_Lookup LookupPointer
	{
		std::shared_ptr<LookupShared> _ptr;
	public:
		LookupPointer() {}
		LookupPointer(std::shared_ptr<LookupShared> ptr);

		std::shared_ptr<LookupShared> GetPtr();
	};

	class Wrapper_Shared Wrapper_Lookup LookupShared
	{
		LookupPointer* _ptr = nullptr;
	public:
		LookupShared() {}
		LookupShared(LookupPointer* ptr);

		LookupPointer* GetPtr();
	};
}