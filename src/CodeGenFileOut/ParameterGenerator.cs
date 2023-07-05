using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ParameterGenerator
	{
		public static (string Parameter, string Argument, string? Alloc, string? Free) GenerateCpp(this ParserParameter param)
		{
			var typeInfo = param.Type.GenerateCpp();

			var generated = $"{typeInfo.Generated} {param.Name}_" + (typeInfo.RequireSize ? $",int {param.Name}_Size" : "");

			return (generated, string.Format(typeInfo.TransformFormat, $"{param.Name}_", $"{param.Name}_Size"), null, null);
		}
	}
}
