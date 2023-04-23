using System.Text.Json;

namespace CodeGenConfig
{
	public static class ConfigLoader
	{
		public static async Task<Config> Load(string path)
		{
			Config result = new Config();
			try
			{
				using var file = File.OpenRead(path);
				return result = await JsonSerializer.DeserializeAsync<Config>(file) ?? result;
			}
			catch (FileNotFoundException)
			{
				return result;
			}
			finally
			{
#if DEBUG
				using var file = new StreamWriter(path);
				await JsonSerializer.SerializeAsync(file.BaseStream, result);
#endif
			}
		}
	}
}
