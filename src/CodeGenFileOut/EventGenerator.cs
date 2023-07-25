using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class EventGenerator
	{
		public static IEnumerable<string> GenerateEventCpp(this ParserClass c)
		{
			return c.Events.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserEvent e)
			{
				yield return "__declspec(dllexport)";
				yield return "void ";
				yield return $"__stdcall Wrapper_Event_{c.UniqueName()}_{e.Name}";

				var returnType = e.Result.GenerateCpp();
				var parameters = e.Parameters.Select(ParameterGenerator.GenerateCpp).ToList();
				var self = c.SelfNameCpp();

				yield return $"({self.Parameter},";
				yield return returnType.Generated;

				if (parameters.Count == 0)
				{
					yield return "(__stdcall*event)()){try{";
				}
				else
				{
					yield return "(__stdcall*event)(";
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? "" : ",");
					yield return ")){try{";
				}

				yield return ExceptionTransfer.TestSelf;

				yield return $"{self.Pointer}->{e.Name}=event;}}";
				yield return @"catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage=""unknown"";throw;}}";
			}
		}

		public static string NativeDelegateCs(this ParserEvent e) => $"{e.Name}_Delegate_Native";
		public static string NativeSetterCs(this ParserEvent e, ParserClass c) => $"Wrapper_Event_{c.UniqueName()}_{e.Name}";

		public static IEnumerable<string> GenerateEventCs(this ParserClass c, string dllImport)
		{
			return c.Events.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserEvent e, int index)
			{
				var nativeDelegate = e.NativeDelegateCs();
				var managedDelegate = $"{e.Name}Delegate";

				var returnType = e.Result.GenerateCs();
				var parameters = e.Parameters.Select(ParameterGenerator.GenerateCs).ToList();

				yield return $"private delegate {returnType.Native} {nativeDelegate}(";
				if (parameters.Count == 0)
				{
					yield return ");";
				}
				else
				{
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Native + (i == parameters.Count - 1 ? ");" : ",");
				}

				yield return $"private {nativeDelegate}? {nativeDelegate}_Object;";

				var dllImportEnd = dllImport.IndexOf(')');
				yield return $"{dllImport[..dllImportEnd]},CallingConvention=System.Runtime.InteropServices.CallingConvention.StdCall{dllImport[dllImportEnd..]}";

				var externFunction = e.NativeSetterCs(c);

				yield return $"private static extern void {externFunction}";
				yield return $"(IntPtr self, {nativeDelegate}? action);";

				yield return $"public delegate {returnType.Native} {managedDelegate}(";
				if (parameters.Count == 0)
				{
					yield return ");";
				}
				else
				{
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Parameter + (i == parameters.Count - 1 ? ");" : ",");
				}

				yield return $"private {managedDelegate}? {managedDelegate}_Object;";

				yield return $"public event {managedDelegate} {e.Name}{{add{{try{{";
				yield return $"{managedDelegate}_Object+=value;";
				yield return $"if({nativeDelegate}_Object==null){{";
				yield return $"{nativeDelegate}_Object=Delegate;unsafe {returnType.Native} Delegate(";
				if (parameters.Count == 0)
				{
					yield return ")=>";
				}
				else
				{
					for (int i = 0; i < parameters.Count; i++)
						yield return parameters[i].Native + (i == parameters.Count - 1 ? ")=>" : ",");
				}
				yield return $"{managedDelegate}_Object?.Invoke(";
				if (parameters.Count == 0)
				{
					yield return ")";
				}
				else
				{
					for (int i = 0; i < parameters.Count; i++)
						yield return (parameters[i].InverseArgument ?? throw new Exception($"Parameter {e.Parameters[i].Name} was not correctly type checked")) + (i == parameters.Count - 1 ? ")" : ",");
				}
				yield return returnType.InverseFormat == null ? ";" : "??default;";

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

				yield return $"{externFunction}({self},{nativeDelegate}_Object);}}}}";
				yield return "catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}";
				yield return $"remove{{{managedDelegate}_Object-=value;}}}}";
			}
		}
	}
}
