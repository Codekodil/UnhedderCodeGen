using CodeGenConfig;
using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class CsGenerator
	{
		public static async Task<bool> WriteAsync(Config config, IReadOnlyList<ParserDeclaration> declarations)
		{
			if (config.CsResultPath == null || config.NativeLibraryName == null)
				return false;

			var file = new FileGenerator(config.CsResultPath);
			await Task.Run(Generate);
			try { await file.Emplace(); }
			catch (Exception) { return false; }
			return true;


			void Generate()
			{
				var dllImport = $"[System.Runtime.InteropServices.DllImport(\"{config.NativeLibraryName}\")]";
				foreach (var c in declarations.SelectMany(d => d))
				{
#if DEBUG
					file.WriteLine("");
					file.WriteLine("");
					file.WriteLine($"/*------------------------- {c.FullNameCs()} -------------------------*/");

					file.WriteLine("");
#endif
					file.WriteLine($"namespace {string.Join(".", new[] { config.NativeLibraryName }.Concat(c.Namespaces))}{{");
					file.WriteLine($"internal class {c.Name}:IDisposable{{public IntPtr?Native;public {c.Name}(IntPtr?native)=>Native=native;");
#if DEBUG
					file.WriteLine("");
					file.WriteLine("//Constructors:");
#endif
					foreach (var constructor in c.GenerateConstructorCs(dllImport))
					{
#if DEBUG
						file.WriteLine("");
#endif
						file.WriteLine(constructor);
					}
#if DEBUG
					file.WriteLine("");
					file.WriteLine("//Methods:");
#endif
					foreach (var method in c.GenerateMethodCs(dllImport))
					{
#if DEBUG
						file.WriteLine("");
#endif
						file.WriteLine(method);
					}
#if DEBUG
					file.WriteLine("");
					file.WriteLine("//Delete:");
					file.WriteLine("");
#endif
					file.WriteLine(c.GenerateDeleteCs(dllImport));

					file.WriteLine("}}");
				}
			}
		}
	}
}
