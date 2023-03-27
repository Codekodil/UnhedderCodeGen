#pragma once

#include <glm.hpp>

namespace Example
{
	class __declspec(dllexport) GlmMapping
	{
	public:
		float Sum2(glm::vec2 vector);
		float Sum3(glm::vec3 vector);
		float Sum4(glm::vec4 vector);
		void Double(glm::vec2* vector);
		void Double(glm::vec3* vector);
		void Double(glm::vec4* vector);
	};
}