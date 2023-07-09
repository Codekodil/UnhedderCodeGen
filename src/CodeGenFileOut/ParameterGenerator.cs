using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ParameterGenerator
	{
		public static (string Parameter, string Argument, string? Alloc, string? Free) GenerateCpp(this ParserParameter param)
		{
			var typeInfo = param.Type.GenerateCpp();

			var generated = $"{typeInfo.Generated} {param.Name}_" + (typeInfo.RequireSize ? $",int {param.Name}_Size" : "");

			return (
				generated,
				string.Format(typeInfo.TransformFormat, $"{param.Name}_", $"{param.Name}_Size"),
				typeInfo.Alloc == null ? null : string.Format(typeInfo.Alloc, $"{param.Name}_", $"{param.Name}_Size"),
				typeInfo.Free == null ? null : string.Format(typeInfo.Free, $"{param.Name}_", $"{param.Name}_Size"));
		}

		public static (string Parameter, string Native, string Argument, string? Alloc, string? Free) GenerateCs(this ParserParameter param)
		{
			var typeInfo = param.Type.GenerateCs();

			var generated = $"{typeInfo.Generated} {param.Name}_";
			var native = $"{typeInfo.Native} {param.Name}_" + (typeInfo.RequireSize ? $",int {param.Name}_Size" : "");

			return (
				generated,
				native,
				string.Format(typeInfo.TransformFormat, $"{param.Name}_", $"{param.Name}_Size"),
				typeInfo.Alloc == null ? null : string.Format(typeInfo.Alloc, $"{param.Name}_", $"{param.Name}_Size"),
				typeInfo.Free == null ? null : string.Format(typeInfo.Free, $"{param.Name}_", $"{param.Name}_Size"));
		}
	}
}
