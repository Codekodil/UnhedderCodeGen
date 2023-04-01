using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using System.Text.Json;

namespace CodeGenConsole
{
	public class ConfigLib : ILibrary
	{
		private Config _config = new Config();
		private ConfigLib() { }

		public static async Task<ConfigLib> NewAsync(string path)
		{
			var result = new ConfigLib();
			{
				using var file = File.OpenRead(path);
				var config = await JsonSerializer.DeserializeAsync<Config>(file);
				if (config != null)
					result._config = config;
			}
#if DEBUG
			{
				using var file = File.OpenWrite(path);
				await JsonSerializer.SerializeAsync(file, result._config);
			}
#endif
			return result;
		}

		public Task RunConsoleAsync() => Task.Run(() => ConsoleDriver.Run(this));



		public void Setup(Driver driver)
		{
			driver.ParserOptions.LanguageVersion = CppSharp.Parser.LanguageVersion.CPP20;
			driver.Options.GeneratorKind = GeneratorKind.CSharp;
			driver.Options.OutputDir = @"..\..\..\";
#if DEBUG
			driver.Options.GenerateDebugOutput = true;
#endif

			foreach (var moduleConfig in _config.Modules)
			{
				var name = Path.GetFileName(Path.GetFullPath(moduleConfig.Path));

				var module = driver.Options.AddModule(name);
				module.IncludeDirs.Add(moduleConfig.Path);
				module.IncludeDirs.AddRange(moduleConfig.Headers);

				module.Headers.AddRange(FilesInPath(moduleConfig.Path, "h"));

				module.LibraryDirs.Add(moduleConfig.LibPath);
				module.Libraries.AddRange(FilesInPath(moduleConfig.LibPath, "lib"));

				IEnumerable<string> FilesInPath(string path, string ending) =>
					Directory.GetFiles(path, "*." + ending).Select(Path.GetFileName)!;
			}

		}

		public void SetupPasses(Driver driver) { }
		public void Preprocess(Driver driver, ASTContext ctx)
		{
			ctx.IgnoreHeadersWithName("packing");
		}
		public void Postprocess(Driver driver, ASTContext ctx) { }
	}
}
