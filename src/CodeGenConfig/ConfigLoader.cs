using System.Text.Json;

namespace CodeGenConfig
{
	public static class ConfigLoader
	{
		public static async Task<Config> Load(string path)
		{
			var configPath = Path.GetDirectoryName(Path.GetFullPath(path))!;
			Config result = new Config();
			try
			{
				using var file = File.OpenRead(path);
				return result = await JsonSerializer.DeserializeAsync<Config>(file) ?? result;
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine($"File [{Path.GetFullPath(path)}] was not found");
				return result;
			}
			finally
			{
#if DEBUG
				using var file = new StreamWriter(path);
				await JsonSerializer.SerializeAsync(file.BaseStream, result, new JsonSerializerOptions { WriteIndented = true });
#endif
				result.Pch = FullPath(result.Pch);
				result.HeaderDirectories = result.HeaderDirectories.Select(FullPath).ToArray()!;
				result.CppResultPath = FullPath(result.CppResultPath);
				result.HppResultPath = FullPath(result.HppResultPath);
				result.CsResultPath = FullPath(result.CsResultPath);
				string? FullPath(string? path)
				{
					if (path == null || Path.IsPathRooted(path))
						return path;
					return Path.GetFullPath(Path.Combine(configPath, path));
				}
			}
		}
	}
}
