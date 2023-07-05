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
			file.WriteLine($"#define {Flags.Ignore}");
			file.WriteLine($"#define {Flags.Pointer}");
			file.Write($"#define {Flags.Shared}");

			try { await file.Emplace(); }
			catch (Exception) { return false; }

			return true;
		}
	}
}