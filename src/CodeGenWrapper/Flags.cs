using System.Reflection;

namespace CodeGenWrapper
{
	public static class Flags
	{
		public const string Wrapper = "Wrapper_Generate";
		public const string Shared = "Wrapper_Shared";
		public const string Ignore = "Wrapper_Ignore";
		public const string ThreadSafe = "Wrapper_ThreadSafe";
		public const string Lookup = "Wrapper_Lookup";

		public static IEnumerable<string> All => typeof(Flags)
			.GetFields(BindingFlags.Public | BindingFlags.Static)
			.Select(f => f.GetValue(null))
			.Cast<string>();
	}
}
