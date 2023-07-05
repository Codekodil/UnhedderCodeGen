using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class MethodGenerator
	{
		public static IEnumerable<string> GenerateMethodCpp(this ParserClass c)
		{
			return c.Methods.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserMethod m, int index)
			{
				yield return "__declspec(dllexport)";

				var returnType = m.Result.GenerateCpp();

				yield return returnType.Generated + " ";

				yield return $"__stdcall Wrapper_Call_{c.UniqueName()}_{m.Name}_{index}";

				var parameter = m.Parameters.Select(ParameterGenerator.GenerateCpp).ToList();
				var self = c.SelfNameCpp();

				if (parameter.Count == 0)
				{
					yield return $"({self.Parameter}){{";
				}
				else
				{
					yield return $"({self.Parameter},";
					for (int i = 0; i < parameter.Count; i++)
						yield return parameter[i].Parameter + (i == parameter.Count - 1 ? "" : ",");
					yield return "){";
				}

				yield return (returnType.InverseFormat == null ? "" : $"auto value_result = ") + $"{self.Pointer}->{m.Name}(" + (parameter.Count == 0 ? ");" : "");
				for (int i = 0; i < parameter.Count; i++)
					yield return parameter[i].Argument + (i == parameter.Count - 1 ? ");" : ",");

				yield return $"return {string.Format(returnType.InverseFormat ?? "", "value_result")};}}";
			}
		}
	}
}
