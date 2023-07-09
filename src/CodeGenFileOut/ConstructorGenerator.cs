using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ConstructorGenerator
	{
		public static IEnumerable<string> GenerateConstructorCpp(this ParserClass c)
		{
			return c.Constructors.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserConstructor con, int index)
			{
				yield return "__declspec(dllexport)";
				if (c.Shared)
					yield return $"std::shared_ptr<{c.FullNameCpp()}>*";
				else
					yield return $"{c.FullNameCpp()}*";
				yield return $"__stdcall Wrapper_New_{c.UniqueName()}_{index}";

				var parameters = con.Parameters.Select(ParameterGenerator.GenerateCpp).ToList();

				if (parameters.Count == 0)
				{
					yield return "(){";
				}
				else
				{
					yield return "(";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? "" : ",");
					yield return "){";
				}

				yield return $"auto pointer_result = new {c.FullNameCpp()}(" + (parameters.Count == 0 ? ");" : "");
				for (int i = 0; i < parameters.Count; i++)
					yield return parameters[i].Argument + (i == parameters.Count - 1 ? ");" : ",");

				if (c.Shared)
					yield return $"return new std::shared_ptr<{c.FullNameCpp()}>(pointer_result);}}";
				else
					yield return "return pointer_result;}";
			}
		}

		public static IEnumerable<string> GenerateConstructorCs(this ParserClass c, string dllImport)
		{
			return c.Constructors.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserConstructor con, int index)
			{
				yield return $"public {c.Name}";

				var parameters = con.Parameters.Select(ParameterGenerator.GenerateCs).ToList();

				if (parameters.Count == 0)
				{
					yield return "(){";
				}
				else
				{
					yield return "(";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? "" : ",");
					yield return "){";
				}

				foreach (var p in parameters)
					if (p.Alloc != null)
						yield return p.Alloc;

				yield return $"Native=Wrapper_New_{c.UniqueName()}_{index}(" + (parameters.Count == 0 ? ");}" : "");
				for (int i = 0; i < parameters.Count; i++)
					yield return parameters[i].Argument + (i == parameters.Count - 1 ? ");}" : ",");

				yield return dllImport;
				yield return $"private static extern IntPtr Wrapper_New_{c.UniqueName()}_{index}";

				if (parameters.Count == 0)
				{
					yield return "();";
				}
				else
				{
					yield return "(";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Native + (i == parameters.Count - 1 ? "" : ",");
					yield return ");";
				}
			}
		}
	}
}
