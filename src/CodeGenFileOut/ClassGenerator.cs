﻿using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ClassGenerator
	{
		public static string UniqueName(this ParserClass c) => string.Join("_", c.Namespaces.Concat(new[] { c.Name }));
		public static string FullNameCpp(this ParserClass c) => string.Join("::", c.Namespaces.Concat(new[] { c.Name }));
		public static (string Parameter, string Pointer) SelfNameCpp(this ParserClass c)
		{
			var typeInfo = new ParserType("", 0, false, true, false)
			{ CheckedType = new TypeChecker.MatchedParsed(c) }
			.GenerateCpp();

			return ($"{typeInfo.Generated} self", string.Format(typeInfo.TransformFormat, "self"));
		}

		public static string GenerateDeleteCpp(this ParserClass c)
		{
			return string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, GenerateSections());

			IEnumerable<string> GenerateSections()
			{
				yield return "__declspec(dllexport)";
				yield return "void ";
				yield return $"__stdcall Wrapper_Delete_{c.UniqueName()}";
				yield return $"({c.SelfNameCpp().Parameter}){{";
				yield return $"delete self;}}";
			}
		}
	}
}
