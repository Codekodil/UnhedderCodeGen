using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ConstructorGenerator
	{
		public static IEnumerable<string> GenerateConstructorCpp(this ParserClass @class)
		{
			return @class.Constructors.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserConstructor c, int index)
			{
				yield return "__declspec(dllexport)";
				if (@class.Shared)
					yield return $"std::shared_ptr<{@class.FullNameCpp()}>*";
				else
					yield return $"{@class.FullNameCpp()}*";
				yield return $"__stdcall Wrapper_New_{@class.UniqueName()}_{index}";

				var parameter = c.Parameters.Select(ParameterGenerator.GenerateCpp).ToList();

				if (parameter.Count == 0)
				{
					yield return "(){";
				}
				else
				{
					yield return "(";
					for (int i = 0; i < parameter.Count; i++)
						yield return parameter[i].Parameter + (i == parameter.Count - 1 ? "" : ",");
					yield return "){";
				}

				yield return $"auto pointer_result = new {@class.FullNameCpp()}(" + (parameter.Count == 0 ? ");" : "");
				for (int i = 0; i < parameter.Count; i++)
					yield return parameter[i].Argument + (i == parameter.Count - 1 ? ");" : ",");

				if (@class.Shared)
					yield return $"return new std::shared_ptr<{@class.FullNameCpp()}>(pointer_result);}}";
				else
					yield return "return pointer_result;}";
			}
		}
	}
}
