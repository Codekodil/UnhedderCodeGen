using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ClassGenerator
	{
		public static string UniqueName(this ParserClass c) => string.Join("_", c.Namespaces.Concat(new[] { c.Name }));
		public static string FullNameCpp(this ParserClass c) => string.Join("::", c.Namespaces.Concat(new[] { c.Name }));
		public static string FullNameCs(this ParserClass c) => string.Join(".", c.Namespaces.Concat(new[] { c.Name }));
		public static string ToIntPtr(string obj, string nameof) => $"({obj}==null?IntPtr.Zero:{obj}!.Native??throw new System.ObjectDisposedException({nameof}))";
		public static string ToIntPtr(this ParserClass c) => $"Native??throw new System.ObjectDisposedException(nameof({c.Name}))";
		public static (string Parameter, string Pointer) SelfNameCpp(this ParserClass c)
		{
			var typeInfo = new ParserType("", 0, false, true, false)
			{ CheckedType = new TypeChecker.MatchedParsed(c) }
			.GenerateCpp();

			return ($"{typeInfo.Generated} self", c.Shared ? "(*self)" : "self");
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
				yield return $"({c.SelfNameCpp().Parameter}){{try{{";
				yield return "delete self;}";
				yield return @"catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage=""unknown"";throw;}}";
			}
		}

		public static string GenerateDeleteCs(this ParserClass c, string dllImport)
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
				var externFunction = $"Wrapper_Delete_{c.UniqueName()}";
				if (c.ThreadSafe)
				{
					yield return "internal _SafeGuard _safeGuard;";
					yield return "public ValueTask DisposeAsync()=>new ValueTask(_safeGuard.DeleteAsync());";
				}
				else
				{
					yield return "public void Dispose()=>Wrapper_Delete();";
				}
				yield return $"~{c.Name}()=>Wrapper_Delete();";
				yield return "private void Wrapper_Delete(){try{";
				yield return "if(!Native.HasValue)return;";
				foreach (var e in c.Events)
				{
					yield return $"if({e.NativeDelegateCs()}_Object!=null){{";
					yield return $"{e.NativeSetterCs(c)}(Native.Value,null);";
					yield return $"{e.NativeDelegateCs()}_Object=null;}}";
				}
				yield return $"{externFunction}(Native.Value);";
				yield return "Native=default;}";
				yield return "catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}";
				yield return dllImport;
				yield return $"private static extern void {externFunction}(IntPtr native);";
			}
		}
	}
}
