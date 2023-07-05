using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ClassGenerator
	{
		public static string UniqueName(this ParserClass c) => string.Join("_", c.Namespaces.Concat(new[] { c.Name }));
		public static string FullNameCpp(this ParserClass c) => string.Join("::", c.Namespaces.Concat(new[] { c.Name }));
		public static (string Parameter, string Pointer) SelfNameCpp(this ParserClass c)
		{
			var typeInfo = new ParserType("", 0, false, true, false)
			{ CheckedType = new TypeChecker.MatchedParsed(c) }
			.GenerateCpp();

			return ($"{typeInfo.Generated} self", string.Format(typeInfo.TransformFormat, "self"));
		}
	}
}
