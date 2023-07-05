using CodeGenWrapper;
using static CodeGenWrapper.TypeChecker;

namespace CodeGenFileOut
{
	public static class ParameterGenerator
	{
		public static (string Parameter, string Argument, string? Alloc, string? Free) GenerateCpp(this ParserParameter param)
		{
			string type;

			bool parameterPointer;
			bool parameterShared;
			string? argumentTransform = null;
			//string? inverseArgumentTransform = null;
			switch (param.Type.CheckedType)
			{
				case MatchedVoid:
					type = "void";
					parameterPointer = false;
					parameterShared = false;
					break;
				case MatchedData data:
					type = data.Type;
					parameterPointer = param.Type.Pointer;
					parameterShared = param.Type.Shared;
					break;
				case MatchedParsed parsed:
					type = parsed.Class.FullNameCpp();
					parameterPointer = parsed.Class.Pointer;
					parameterShared = parsed.Class.Shared;
					if (parsed.Class.Shared)
					{
						if (param.Type.Pointer)
							argumentTransform = "{0}->get()";
						else
							argumentTransform = "*{0}";
					}
					break;
				default:
					throw new Exception($"Type {param.Type} was not type checked");
			}
			if (parameterPointer)
				type += "*";
			if (parameterShared)
				type = $"std::shared_ptr<{type}>*";

			if (param.Type.Span)
			{
				var generated = $"{type} {param.Name}_,int {param.Name}_Size";

				return (generated, $"std::span({param.Name}_,{param.Name}_Size)", null, null);
			}
			{
				var generated = $"{type} {param.Name}_";

				return (generated, argumentTransform == null ? $"{param.Name}_" : string.Format(argumentTransform, $"{param.Name}_"), null, null);
			}
		}
	}
}
