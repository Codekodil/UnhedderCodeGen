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

				var parameters = m.Parameters.Select(ParameterGenerator.GenerateCpp).ToList();
				var self = c.SelfNameCpp();

				if (parameters.Count == 0)
				{
					yield return $"({self.Parameter}){{";
				}
				else
				{
					yield return $"({self.Parameter},";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? "" : ",");
					yield return "){";
				}

				yield return (returnType.InverseFormat == null ? "" : $"auto value_result=") + $"{self.Pointer}->{m.Name}(" + (parameters.Count == 0 ? ");" : "");
				for (int i = 0; i < parameters.Count; i++)
					yield return parameters[i].Argument + (i == parameters.Count - 1 ? ");" : ",");

				yield return $"return {string.Format(returnType.InverseFormat ?? "", "value_result")};}}";
			}
		}

		public static IEnumerable<string> GenerateMethodCs(this ParserClass c, string dllImport)
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
				var returnType = m.Result.GenerateCs();

				yield return $"public unsafe {returnType.Generated} ";

				yield return m.Name;

				var parameters = m.Parameters.Select(ParameterGenerator.GenerateCs).ToList();

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

				var externFunction = $"Wrapper_Call_{c.UniqueName()}_{m.Name}_{index}";

				yield return (returnType.InverseFormat == null ? "" : $"var value_result=") + $"{externFunction}({c.NativeWithCheckCs()}" + (parameters.Count == 0 ? ");" : ",");
				for (int i = 0; i < parameters.Count; i++)
					yield return parameters[i].Argument + (i == parameters.Count - 1 ? ");" : ",");

				foreach (var p in parameters)
					if (p.Free != null)
						yield return p.Free;

				yield return $"return {string.Format(returnType.InverseFormat ?? "", "value_result")};}}";

				yield return dllImport;
				yield return $"private static extern {returnType.Native} {externFunction}";

				if (parameters.Count == 0)
				{
					yield return "(IntPtr self);";
				}
				else
				{
					yield return "(IntPtr self,";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Native + (i == parameters.Count - 1 ? "" : ",");
					yield return ");";
				}
			}
		}
	}
}
