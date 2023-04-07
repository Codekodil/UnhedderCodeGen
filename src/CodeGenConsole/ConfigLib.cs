using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using System.Text.Json;

namespace CodeGenConsole
{
	public class ConfigLib : ILibrary
	{
		private Config _config = new Config();
		public ConfigLib(Config config) => _config = config;

		public Task RunConsoleAsync() => Task.Run(() => ConsoleDriver.Run(this));
		public static Task RunConsoleAsync(Config config) => new ConfigLib(config).RunConsoleAsync();



		public void Setup(Driver driver)
		{
			driver.ParserOptions.LanguageVersion = CppSharp.Parser.LanguageVersion.CPP20;
			driver.ParserOptions.AddArguments("-fcxx-exceptions");
			driver.Options.GeneratorKind = GeneratorKind.CSharp;
			driver.Options.OutputDir = _config.OutputDirectory;
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
