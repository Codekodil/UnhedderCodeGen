using CodeGenConfig;

namespace CodeGenWrapper
{
	public class Wrapper
	{
		public string? PchPath { get; set; }
		public List<string> HeaderFilePaths { get; set; } = new List<string>();

		public void PathsFromConfig(Config config)
		{
			HeaderFilePaths = config.HeaderDirectories
				.SelectMany(p => Directory.GetFiles(p, "*.h"))
				.ToList();
		}

		public async Task<List<ParserDeclaration>> ParseHeaders()
		{
			var headerTasks = HeaderFilePaths.Select(async h =>
			{
				using var file = File.OpenRead(h);
				var header = await ParserHeader.NormalizeHeader(file);
				return new ParserDeclaration(header.FilteredFile, new List<string>(), h);
			}).ToList();

			return (await Task.WhenAll(headerTasks)).Cast<ParserDeclaration>().ToList();
		}
	}
}
