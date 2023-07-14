using CodeGenConfig;
using CodeGenWrapper;
using System.Reflection;

namespace CodeGenFileOut
{
	public static class HeaderGenerator
	{
		public static async Task<bool> WriteAsync(Config config)
		{
			if (config.HppResultPath == null)
				return false;

			var file = new FileGenerator(config.HppResultPath);
			foreach (var flag in typeof(Flags).GetFields(BindingFlags.Public | BindingFlags.Static))
				file.WriteLine($"#define {flag.GetValue(null)}");

			try { await file.Emplace(); }
			catch (Exception) { return false; }

			return true;
		}
	}
}