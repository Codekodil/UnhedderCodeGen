using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class ClassGenerator
	{
		public static string UniqueName(this ParserClass c) => string.Join("_", c.Namespaces.Concat(new[] { c.Name }));
		public static string FullNameCpp(this ParserClass c) => string.Join("::", c.Namespaces.Concat(new[] { c.Name }));
	}
}
