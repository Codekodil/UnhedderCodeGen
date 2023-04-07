using System.Text.Json;

namespace CodeGenConsole
{
	public class Config
	{
		public static async Task<Config> LoadAsync(string path)
		{
			var result = new Config();
			{
				using var file = File.OpenRead(path);
				var config = await JsonSerializer.DeserializeAsync<Config>(file);
				if (config != null)
					result = config;
			}
#if DEBUG
			{
				using var file = File.OpenWrite(path);
				await JsonSerializer.SerializeAsync(file, result);
			}
#endif
			return result;
		}



		public class Module
		{
			public string Path { get; set; } = ".";
			public string[] Headers { get; set; } = new string[0];
			public string LibPath { get; set; } = ".";
		}
		public Module[] Modules { get; set; } = new[] { new Module() };
		public string OutputDirectory { get; set; } = ".";
	}
}
