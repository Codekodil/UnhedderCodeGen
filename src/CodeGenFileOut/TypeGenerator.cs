using CodeGenWrapper;
using static CodeGenWrapper.TypeChecker;

namespace CodeGenFileOut
{
	public static class TypeGenerator
	{
		public static (string Generated, string BufferType, string TransformFormat, string? InverseFormat, bool RequireSize, string? Alloc, string? Free) GenerateCpp(this ParserType type)
		{
			string generated;
			string? bufferType = null;

			bool asPointer;
			bool asShared;
			string transformFormat = "{0}";
			string? inverseFormat = "{0}";
			string? alloc = null;
			string? free = null;
			switch (type.CheckedType)
			{
				case MatchedVoid:
					generated = "void";
					asPointer = false;
					asShared = false;
					inverseFormat = null;
					break;
				case MatchedData data:
					generated = data.Type;
					asPointer = type.Pointer;
					asShared = type.Shared;
					if (type.Span)
						transformFormat = $"std::span<{generated}>({{0}},{{1}})";
					break;
				case MatchedParsed parsed:
					generated = parsed.Class.FullNameCpp();
					asPointer = parsed.Class.Pointer;
					asShared = parsed.Class.Shared;
					if (parsed.Class.Shared)
					{
						if (type.Pointer)
						{
							transformFormat = "({0}?{0}->get():nullptr)";
							inverseFormat = null;
						}
						else
						{
							transformFormat = "({0}?*{0}:nullptr)";
							inverseFormat = $"({{0}}?new std::shared_ptr<{parsed.Class.FullNameCpp()}>({{0}}):nullptr)";
						}
					}
					if (type.Span)
					{
						var spanType = type.Shared ? $"std::shared_ptr<{generated}>" : $"{generated}*";
						if (transformFormat != "{0}")
						{
							var vector = GetLocal("local_", type);
							var iterator = GetLocal("i_", type);

							alloc = $"auto {vector}=std::vector<{spanType}>({{1}});" +
								$"for(int {iterator}=0;{iterator}<{{1}};{iterator}++)" +
								$"{vector}[{iterator}]={string.Format(transformFormat, $"{{0}}[{iterator}]")};";

							free = $"for(int {iterator}=0;{iterator}<{{1}};{iterator}++)" +
								$"if({vector}[{iterator}]!={string.Format(transformFormat, $"{{0}}[{iterator}]")}){{0}}[{iterator}]={string.Format(inverseFormat!, $"{vector}[{iterator}]")};";

							transformFormat = $"&{vector}[0]";
						}
						transformFormat = $"std::span<{spanType}>({transformFormat},{{1}})";
					}
					break;
				case MatchedString:
					generated = "const char*";
					asPointer = false;
					asShared = false;
					break;
				default:
					throw new Exception($"Type {type} was not type checked");
			}
			if (type.Pointer)
				bufferType = generated + "*";
			if (type.Shared)
				bufferType = $"std::shared_ptr<{generated}>";
			if (asPointer)
				generated += "*";
			if (asShared)
				generated = $"std::shared_ptr<{generated}>*";
			if (type.Span)
				generated += "*";

			return (generated, bufferType ?? generated, transformFormat, inverseFormat, type.Span, alloc, free);
		}

		public static (string Generated, string Native, string TransformFormat, string? InverseFormat, bool RequireSize, string? Alloc, string? Free) GenerateCs(this ParserType type)
		{
			string generated;
			string native;

			bool asPointer;
			bool asShared;
			string transformFormat = "{0}";
			string? inverseFormat = "{0}";
			string? alloc = null;
			string? free = null;
			switch (type.CheckedType)
			{
				case MatchedVoid:
					native = generated = "void";
					asPointer = false;
					asShared = false;
					inverseFormat = null;
					break;
				case MatchedData data:
					native = generated = data.Type;
					asPointer = type.Pointer;
					asShared = type.Shared;
					if (type.Pointer)
					{
						generated = $"ref {generated}";
						native = "IntPtr";
						var fixedName = GetLocal("local", type);
						alloc = $"fixed({data.Type}*{fixedName}=&{{0}}){{{{";
						transformFormat = $"(IntPtr){fixedName}";
						free = "}}";
					}
					if (type.Span)
					{
						var fixedName = GetLocal("local", type);
						alloc = $"fixed({data.Type}*{fixedName}={{0}}){{{{";
						transformFormat = $"(IntPtr){fixedName},{{0}}.Length";
						free = "}}";
					}
					break;
				case MatchedParsed parsed:
					generated = $"{parsed.Class.FullNameCs()}?";
					native = "IntPtr";
					asPointer = false;
					asShared = false;
					inverseFormat = parsed.Class.Lookup ?
						$"{parsed.Class.FullNameCs()}._lookup.GetOrMake({{0}})" :
						$"({{0}}==IntPtr.Zero?null:new {parsed.Class.FullNameCs()}((IntPtr?){{0}}))";
					if (type.Span)
					{
						var fixedName = GetLocal("local", type);
						var iterator = GetLocal("i", type);
						var locks = GetLocal("locks", type);

						alloc = $"fixed(IntPtr*{fixedName}=stackalloc IntPtr[{{0}}.Length]){{{{";
						if (parsed.Class.ThreadSafe)
						{
							alloc += $"var {locks}=new _SafeGuard.DisposableLock?[{{0}}.Length];";
							alloc += $"for(int {iterator}=0;{iterator}<{{0}}.Length;{iterator}++)";
							alloc += $"{locks}[{iterator}]={{0}}[{iterator}]==null?null:{{0}}[{iterator}]!._safeGuard.Lock(nameof({{0}}));";
							alloc += "try{{";
							alloc += $"for(int {iterator}=0;{iterator}<{{0}}.Length;{iterator}++)";
							alloc += $"{fixedName}[{iterator}]={ClassGenerator.ToIntPtr($"({{0}}[{iterator}])", "nameof({0})")};";
						}
						else
						{
							alloc += $"for(int {iterator}=0;{iterator}<{{0}}.Length;{iterator}++)";
							alloc += $"{fixedName}[{iterator}]={ClassGenerator.ToIntPtr($"({{0}}[{iterator}])", "nameof({0})")};";
						}

						transformFormat = $"(IntPtr){fixedName},{{0}}.Length";

						free = $"for(int {iterator}=0;{iterator}<{{0}}.Length;{iterator}++)" +
							$"if({fixedName}[{iterator}]!={{0}}[{iterator}]?.Native){{0}}[{iterator}]={string.Format(inverseFormat, $"{fixedName}[{iterator}]")};";

						if (parsed.Class.ThreadSafe)
						{
							free += "}}finally{{";
							free += $"for(int {iterator}=0;{iterator}<{{0}}.Length;{iterator}++)";
							free += $"{locks}[{iterator}]?.Dispose();";
							free += "}}";
						}

						free += "}}";
					}
					else
					{
						if (parsed.Class.ThreadSafe)
						{
							alloc = $"using var {GetLocal("lock", type)}={{0}}?._safeGuard.Lock(nameof({{0}}));";
							transformFormat = "{0}!.Native!.Value";
						}
						else
						{
							transformFormat = ClassGenerator.ToIntPtr("{0}", "nameof({0})");
						}
					}
					break;
				case MatchedString:
					generated = "string";
					native = "[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string";
					asPointer = false;
					asShared = false;
					break;
				default:
					throw new Exception($"Type {type} was not type checked");
			}

			if (type.Span)
			{
				generated = $"Span<{generated}>";
				native = "IntPtr";
			}

			return (generated, native, transformFormat, inverseFormat, type.Span, alloc, free);
		}

		private static readonly HashSet<string> _locals = new HashSet<string>();
		private static string GetLocal(string name, ParserType type)
		{
			var deterministicHash = Math.Abs($"{type.Name}{type.Span}{type.Pointer}{type.Shared}".Select((c, i) => (i + 1) * c).Sum() % 9000);
			while (true)
			{
				var result = $"{name}{deterministicHash++}";
				if (_locals.Add(result))
					return result;
			}
		}
	}
}
