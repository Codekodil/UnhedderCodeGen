﻿using CodeGenWrapper;
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
					break;
				case MatchedParsed parsed:
					generated = parsed.Class.FullNameCpp();
					asPointer = parsed.Class.Pointer;
					asShared = parsed.Class.Shared;
					if (parsed.Class.Shared)
					{
						if (type.Pointer)
							transformFormat = "{0}->get()";
						else
							transformFormat = "*{0}";
						inverseFormat = $"new std::shared_ptr<{parsed.Class.FullNameCpp()}>({{0}})";
					}
					break;
				default:
					throw new Exception($"Type {type} was not type checked");
			}
			if (asPointer)
				generated += "*";
			if (asShared)
				generated = $"std::shared_ptr<{generated}>*";
			if (type.Span)
				transformFormat = $"std::span({transformFormat},{{1}})";

			return (generated, transformFormat, inverseFormat, type.Span, null, null);
		}

		private static int _localCount = 0;
		public static (string Generated, string Native, string TransformFormat, string? InverseFormat, bool RequireSize, string? Alloc, string? Free) GenerateCs(this ParserType type)
		{
			string generated;
			string native;

			bool asPointer;
			bool asShared;
			string transformFormat = "{0}";
			string? inverseFormat = "{0}";
			string? alloc = null;
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
					break;
				case MatchedParsed parsed:
					generated = parsed.Class.FullNameCs();
					native = "IntPtr";
					asPointer = false;
					asShared = false;
					var variableName = $"local{_localCount++}";
					alloc = $"var {variableName}={{0}}.Native??throw new System.ObjectDisposedException(nameof({{0}}));";
					transformFormat = variableName;
					inverseFormat = null;
					break;
				default:
					throw new Exception($"Type {type} was not type checked");
			}

			return (generated, native, transformFormat, inverseFormat, type.Span, alloc, null);
		}
	}
}
