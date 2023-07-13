using CodeGenWrapper;
using static CodeGenWrapper.TypeChecker;

namespace CodeGenFileOut
{
	public static class TypeGenerator
	{
		public static (string Generated, string TransformFormat, string? InverseFormat, bool RequireSize, string? Alloc, string? Free) GenerateCpp(this ParserType type)
		{
			string generated;

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
							transformFormat = "({0}?{0}->get():nullptr)";
						else
							transformFormat = "({0}?*{0}:nullptr)";
						inverseFormat = $"new std::shared_ptr<{parsed.Class.FullNameCpp()}>({{0}})";
					}
					if (type.Span)
					{
						var spanType = type.Shared ? $"std::shared_ptr<{generated}>" : $"{generated}*";
						if (transformFormat != "{0}")
						{
							var uniqueArray = GetLocal("local_", type);
							var iterator = GetLocal("i_", type);

							alloc = $"auto {uniqueArray}=std::make_unique<{spanType}[]>({{1}});" +
								$"for(int {iterator}=0;{iterator}<{{1}};{iterator}++)" +
								$"{uniqueArray}[{iterator}]={string.Format(transformFormat, $"{{0}}[{iterator}]")};";

							free = $"for(int {iterator}=0;{iterator}<{{1}};{iterator}++)" +
								$"if({uniqueArray}[{iterator}]==nullptr){{0}}[{iterator}]=nullptr;" +
								$"else if({uniqueArray}[{iterator}]!={string.Format(transformFormat, $"{{0}}[{iterator}]")}){{0}}[{iterator}]={string.Format(inverseFormat, $"{uniqueArray}[{iterator}]")};";

							transformFormat = $"{uniqueArray}.get()";
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
			if (asPointer)
				generated += "*";
			if (asShared)
				generated = $"std::shared_ptr<{generated}>*";
			if (type.Span)
				generated += "*";

			return (generated, transformFormat, inverseFormat, type.Span, alloc, free);
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
					if (type.Span)
					{
						var fixedName = GetLocal("local", type);
						var iterateName = GetLocal("i", type);

						alloc = $"fixed(IntPtr*{fixedName}=stackalloc IntPtr[{{0}}.Length]){{{{" +
							$"for(int {iterateName}=0;{iterateName}<{{0}}.Length;{iterateName}++)" +
							$"{fixedName}[{iterateName}]={ClassGenerator.ToIntPtr($"{{0}}[{iterateName}]", "nameof({0})")};";

						transformFormat = $"(IntPtr){fixedName},{{0}}.Length";

						free = $"for(int {iterateName}=0;{iterateName}<{{0}}.Length;{iterateName}++)" +
							$"if({fixedName}[{iterateName}]==IntPtr.Zero){{0}}[{iterateName}]=null;" +
							$"else if({fixedName}[{iterateName}]!={{0}}[{iterateName}]?.Native){{0}}[{iterateName}]=new {parsed.Class.FullNameCs()}((IntPtr?){fixedName}[{iterateName}]);}}}}";
					}
					else
					{
						transformFormat = ClassGenerator.ToIntPtr("{0}", "nameof({0})");
					}
					inverseFormat = null;
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
