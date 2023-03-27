#include "GlmMapping.h"

using namespace Example;
using namespace glm;

float GlmMapping::Sum2(vec2 vector)
{
	return dot(vector, vec2(1.0f));
}

float GlmMapping::Sum3(vec3 vector)
{
	return dot(vector, vec3(1.0f));
}

float GlmMapping::Sum4(vec4 vector)
{
	return dot(vector, vec4(1.0f));
}

void GlmMapping::Double(vec2* vector)
{
	*vector = (*vector) * 2.0f;
}

void GlmMapping::Double(vec3* vector)
{
	*vector = (*vector) * 2.0f;
}

void GlmMapping::Double(vec4* vector)
{
	*vector = (*vector) * 2.0f;
}