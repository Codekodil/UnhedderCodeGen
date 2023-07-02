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

			try
			{
				using var file = new StreamWriter(config.HppResultPath);
				await file.WriteLineAsync($"#define {Flags.Ignore}");
				await file.WriteLineAsync($"#define {Flags.Pointer}");
				await file.WriteLineAsync($"#define {Flags.Shared}");
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}