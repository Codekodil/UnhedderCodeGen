using CodeGenConfig;
using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class CppGenerator
	{
		public static async Task<bool> WriteAsync(Config config, IReadOnlyList<ParserDeclaration> declarations)
		{
			if (config.CppResultPath == null)
				return false;

			var file = new FileGenerator(config.CppResultPath);
			await Task.Run(Generate);
			try { await file.Emplace(); }
			catch (Exception) { return false; }
			return true;


			void Generate()
			{
				var classes = declarations.SelectMany(d => d).Where(c => c.Pointer || c.Shared).ToList();

				foreach (var include in new[] { config.Pch }.Concat(classes.Select(c => c.File)).Distinct())
					if (include != null)
						file.WriteLine($@"#include""{Path.GetRelativePath(Path.GetDirectoryName(config.CppResultPath)!, include)}""");

				foreach (var std in new[] { "memory", "vector", "string", "exception" })
					file.WriteLine($"#include<{std}>");

				file.WriteLine(@"thread_local std::string exceptionMessage="""";");
				file.WriteLine(@"extern""C""{");

				file.WriteLine("__declspec(dllexport)void*__stdcall Wrapper_Shared_Ptr_Get(std::shared_ptr<void>*self){return self->get();}");
				file.WriteLine("__declspec(dllexport)int __stdcall Wrapper_Get_Exception(char*buffer,int maxSize){int length=std::min(maxSize,(int)exceptionMessage.size());memcpy(buffer,exceptionMessage.c_str(),length);return length;}");
				file.WriteLine("#pragma warning(push)");
				file.WriteLine("#pragma warning(disable:4297)");

				foreach (var c in classes)
				{
#if DEBUG
					file.WriteLine("");
					file.WriteLine("");
					file.WriteLine($"/*------------------------- {c.FullNameCpp()} -------------------------*/");

					file.WriteLine("");
					file.WriteLine("//Constructors:");
#endif
					foreach (var constructor in c.GenerateConstructorCpp())
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
					foreach (var method in c.GenerateMethodCpp())
					{
#if DEBUG
						file.WriteLine("");
#endif
						file.WriteLine(method);
					}
#if DEBUG
					file.WriteLine("");
					file.WriteLine("//Events:");
#endif
					foreach (var @event in c.GenerateEventCpp())
					{
#if DEBUG
						file.WriteLine("");
#endif
						file.WriteLine(@event);
					}
#if DEBUG
					file.WriteLine("");
					file.WriteLine("//Delete:");
					file.WriteLine("");
#endif
					file.WriteLine(c.GenerateDeleteCpp());
				}

				file.WriteLine("}");
				file.WriteLine("#pragma warning(pop)");
			}
		}
	}
}
