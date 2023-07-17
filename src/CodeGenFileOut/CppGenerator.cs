﻿using CodeGenConfig;
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

				foreach (var std in new[] { "memory", "vector", "string" })
					file.WriteLine($"#include<{std}>");

				file.WriteLine(@"extern""C""{");

				file.WriteLine("__declspec(dllexport)void*__stdcall Wrapper_Shared_Ptr_Get(std::shared_ptr<void>*self){return self->get();}");

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

				file.Write("}");
			}
		}
	}
}
