using CodeGenConfig;

namespace CodeGenWrapper
{
	public class Wrapper
	{
		public string? PchPath { get; set; }
		public List<string> HeaderFilePaths { get; set; } = new List<string>();

		public void PathsFromConfig(Config config)
		{
			PchPath = config.Pch == null ? null : Path.GetFullPath(config.Pch);
			HeaderFilePaths = config.HeaderDirectories
				.SelectMany(p => Directory.GetFiles(Path.GetFullPath(p), "*.h"))
				.Where(p => p != PchPath)
				.ToList();
		}

		public async Task ParseHeaders()
		{
			var headerTasks = HeaderFilePaths.Select(async h =>
			{
				using var file = File.OpenRead(h);
				return new { Header = await ParserHeader.NormalizeHeader(file), File = h };
			}).ToList();

			foreach (var task in headerTasks)
			{
				var result = await task;
				Console.WriteLine($"File: {result.File}");
				var declarations = new ParserDeclaration(result.Header.FilteredFile);

				WriteDeclarations(declarations, "  ");
				void WriteDeclarations(ParserDeclaration declarations, string prefix)
				{
					foreach (var cl in declarations.Classes)
					{
						Console.WriteLine($"{prefix}Class {cl.Name}");
					}
					foreach (var ns in declarations.Namespaces)
					{
						Console.WriteLine($"{prefix}Namespace {ns.Name}");
						WriteDeclarations(ns.Declarations, prefix + "  ");
					}
				}
			}

			await Task.WhenAll(headerTasks);
		}
	}
}
