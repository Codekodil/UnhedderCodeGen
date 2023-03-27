using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

ConsoleDriver.Run(new Lib());

class Lib : ILibrary
{
	public void Setup(Driver driver)
	{
		driver.ParserOptions.LanguageVersion = CppSharp.Parser.LanguageVersion.CPP20;
		driver.Options.GeneratorKind = GeneratorKind.CSharp;
		driver.Options.OutputDir = @"..\..\..\";
#if DEBUG
		driver.Options.GenerateDebugOutput = true;
#endif

		var module = driver.Options.AddModule("UnhedderNative");
		module.IncludeDirs.Add(@"..\..\..\..\..\NativeExample");
		module.IncludeDirs.Add(@"..\..\..\..\..\..\glm\glm");
		module.Headers.Add("BasicStorage.h");
		module.Headers.Add("GlmMapping.h");
		module.LibraryDirs.Add(@"..\..\..\..\..\x64\Debug");
		module.Libraries.Add("NativeExample.lib");
	}

	public void SetupPasses(Driver driver) { }
	public void Preprocess(Driver driver, ASTContext ctx)
	{
		ctx.IgnoreHeadersWithName("packing");
	}
	public void Postprocess(Driver driver, ASTContext ctx) { }
}