using CodeGenConfig;
using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class HeaderGenerator
	{
		public static async Task<bool> WriteAsync(Config config)
		{
			if (config.HppResultPath == null)
				return false;

			var file = new FileGenerator(config.HppResultPath);
			foreach (var flag in Flags.All)
				file.WriteLine($"#define {flag}");

			try { await file.Emplace(); }
			catch (Exception) { return false; }

			return true;
		}
	}
}