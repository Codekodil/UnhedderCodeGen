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
				foreach (var c in declarations.SelectMany(d => d).Where(c => c.Pointer || c.Shared))
				{
#if DEBUG
					file.WriteLine("");
					file.WriteLine("");
					file.WriteLine($"/*------------------------- {c.FullNameCs()} -------------------------*/");

					file.WriteLine("");
#endif
					file.WriteLine($"namespace {string.Join(".", new[] { config.NativeLibraryName }.Concat(c.Namespaces))}{{");
					file.WriteLine($"internal class {c.Name}:IDisposable{{public IntPtr?Native;public {c.Name}(IntPtr?native){{Native=native;{(c.ThreadSafe ? "_safeGuard=new _SafeGuard(Wrapper_Delete);" : "")}}}");
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
					file.WriteLine("//Events:");
#endif
					foreach (var @event in c.GenerateEventCs(dllImport))
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
					file.WriteLine(c.GenerateDeleteCs(dllImport));

					file.WriteLine("}}");
				}
#if DEBUG
				file.WriteLine("");
				file.WriteLine("");
				file.WriteLine($"/*------------------------- SafeGuard -------------------------*/");

				file.WriteLine("");
#endif
				file.WriteLine(string.Join(
#if DEBUG
			"\n\t",
#else
			"",
#endif
			$"namespace {config.NativeLibraryName}{{",
			"internal class _SafeGuard{",
			"private readonly object _locker = new object();",
			"private int _callCount = 0;",
			"private TaskCompletionSource? _disposeTask;",
			"private Action _delete;",
			"public _SafeGuard(Action delete)=>_delete = delete;",
			"public DisposableLock Lock(string objectName)=>new DisposableLock(this, objectName);",
			"",
			"public Task DeleteAsync(){",
			"var doDelete=false;",
			"lock(_locker){if(_disposeTask==null){_disposeTask=new TaskCompletionSource();doDelete=_callCount==0;}}",
			"if(doDelete){try{_delete();_disposeTask.SetResult();}catch(Exception e){_disposeTask.SetException(e);}}",
			"return _disposeTask.Task;}",
			"public struct DisposableLock:IDisposable{",
			"private readonly _SafeGuard _guard;",
			"",
			"public DisposableLock(_SafeGuard guard,string objectName){",
			"_guard = guard;",
			"lock(guard._locker){if(guard._disposeTask!=null)throw new ObjectDisposedException(objectName);guard._callCount++;}}",
			"public void Dispose(){",
			"var doDelete=false;",
			"lock(_guard._locker){if(--_guard._callCount==0)doDelete=_guard._disposeTask!=null;}",
			"if(doDelete){try{_guard._delete();_guard._disposeTask!.SetResult();}catch(Exception e){_guard._disposeTask!.SetException(e);}}}",
			"}}}"));
			}
		}
	}
}
