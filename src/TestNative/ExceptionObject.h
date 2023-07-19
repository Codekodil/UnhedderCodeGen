#pragma once

namespace TestNative
{
	class Wrapper_Pointer ExceptionObject
	{
	public:
		ExceptionObject() {}
		ExceptionObject(std::string message);

		void Throw(std::string message);
		void ThrowArgument();
	};
}