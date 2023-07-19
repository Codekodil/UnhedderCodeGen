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
					yield return $"({self.Parameter}){{try{{";
				}
				else
				{
					yield return $"({self.Parameter},";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? "" : ",");
					yield return "){try{";
				}

				yield return ExceptionTransfer.TestSelf;

				if (returnType.InverseFormat != null)
					yield return $"{returnType.BufferType} value_result;";

				foreach (var p in parameters)
					if (p.Alloc != null)
						yield return p.Alloc;

				yield return (returnType.InverseFormat == null ? "" : $"value_result=") + $"{self.Pointer}->{m.Name}(" + (parameters.Count == 0 ? ");" : "");
				for (int i = 0; i < parameters.Count; i++)
					yield return parameters[i].Argument + (i == parameters.Count - 1 ? ");" : ",");

				foreach (var p in parameters)
					if (p.Free != null)
						yield return p.Free;

				yield return $"return {string.Format(returnType.InverseFormat ?? "", "value_result")};}}";
				yield return @"catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage=""unknown"";throw;}}";
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
					yield return "(){try{";
				}
				else
				{
					yield return "(";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? "" : ",");
					yield return "){try{";
				}

				string self;
				if (c.ThreadSafe)
				{
					yield return $"using var selfLocker = _safeGuard.Lock(nameof({c.Name}));";
					self = "Native!.Value";
				}
				else
				{
					self = c.ToIntPtr();
				}

				foreach (var p in parameters)
					if (p.Alloc != null)
						yield return p.Alloc;

				var externFunction = $"Wrapper_Call_{c.UniqueName()}_{m.Name}_{index}";

				yield return (returnType.InverseFormat == null ? "" : $"var value_result=") + $"{externFunction}({self}" + (parameters.Count == 0 ? ");" : ",");
				for (int i = 0; i < parameters.Count; i++)
					yield return parameters[i].Argument + (i == parameters.Count - 1 ? ");" : ",");

				foreach (var p in parameters)
					if (p.Free != null)
						yield return p.Free;

				yield return $"return {string.Format(returnType.InverseFormat ?? "", "value_result")};}}";
				yield return "catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}";

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
