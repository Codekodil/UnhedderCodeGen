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

#if DEBUG
				file.WriteLine("");
				file.WriteLine("");
#endif
				file.WriteLine($"namespace {config.NativeLibraryName}{{internal static class SharedPointer{{{dllImport}public static extern IntPtr Wrapper_Shared_Ptr_Get(IntPtr self);}}}}");
				file.WriteLine($"namespace {config.NativeLibraryName}{{internal class NativeException:Exception{{private NativeException(string message):base(message){{}}{dllImport}private static extern int Wrapper_Get_Exception(IntPtr buffer,int maxSize);public static unsafe Exception GetNative(){{fixed(byte*buffer=stackalloc byte[128]){{return System.Text.Encoding.ASCII.GetString(buffer,Wrapper_Get_Exception((IntPtr)buffer,128))switch{{nameof(NullReferenceException)=>new NullReferenceException(),nameof(ArgumentException)=>new ArgumentException(),nameof(ArgumentNullException)=>new ArgumentNullException(),nameof(ArgumentOutOfRangeException)=>new ArgumentOutOfRangeException(),var message => new NativeException(message)}};}}}}}}}}");

				foreach (var c in declarations.SelectMany(d => d).Where(c => c.Pointer || c.Shared))
				{
#if DEBUG
					file.WriteLine("");
					file.WriteLine("");
					file.WriteLine($"/*------------------------- {c.FullNameCs()} -------------------------*/");

					file.WriteLine("");
#endif
					file.WriteLine($"namespace {string.Join(".", new[] { config.NativeLibraryName }.Concat(c.Namespaces))}{{");
					file.WriteLine($"internal class {c.Name}:{(c.ThreadSafe ? nameof(IAsyncDisposable) : nameof(IDisposable))}{{public IntPtr?Native;public {c.Name}(IntPtr?native){{Native=native;{(c.ThreadSafe ? "_safeGuard=new _SafeGuard(Wrapper_Delete);" : "")}}}");

					if (c.Lookup)
						file.WriteLine($"internal class {c.Name}PointerLookup:PointerLookup<{c.Name}>{{protected override {c.Name} New(IntPtr ptr)=>new {c.Name}((IntPtr?)ptr);protected override bool Shared()=>{(c.Shared ? "true" : "false")};protected override void Delete(IntPtr ptr)=>Wrapper_Delete_{c.UniqueName()}(ptr);}}internal static readonly {c.Name}PointerLookup _lookup=new {c.Name}PointerLookup();");
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
					"if(doDelete){try{_guard._delete();_guard._disposeTask!.SetResult();}catch(Exception e){_guard._disposeTask!.SetException(e);}}}}",
					"}}"));

#if DEBUG
				file.WriteLine("");
				file.WriteLine("");
				file.WriteLine($"/*------------------------- PointerLookup -------------------------*/");

				file.WriteLine("");
#endif
				file.WriteLine(string.Join(
#if DEBUG
					"\n\t",
#else
					"",
#endif
					$"namespace {config.NativeLibraryName}{{",
					"internal abstract class PointerLookup<T>where T:class{",
					"",
					"protected abstract T New(IntPtr ptr);",
					"protected abstract bool Shared();",
					"protected abstract void Delete(IntPtr ptr);",
					"",
					"private readonly Dictionary<IntPtr,WeakReference<T>>_references=new Dictionary<IntPtr,WeakReference<T>>();",
					"public PointerLookup(){PeriodicGC();",
					"async void PeriodicGC(){while(true){await Task.Delay(10000);lock(_references){",
					"var toRemove=new List<IntPtr>();",
					"foreach(var kv in _references)if(!kv.Value.TryGetTarget(out _))toRemove.Add(kv.Key);",
					"foreach(var remove in toRemove)_references.Remove(remove);}}}}",
					"",
					"public T GetOrMake(IntPtr ptr){lock(_references){var memory=Shared()?SharedPointer.Wrapper_Shared_Ptr_Get(ptr):ptr;",
					"if(!(_references.TryGetValue(memory,out var weak)&&weak.TryGetTarget(out var t)))_references[memory]=new WeakReference<T>(t=New(ptr));else if(Shared())Delete(ptr);return t;}}",
					"public void Add(T reference,IntPtr ptr){lock(_references)_references[Shared()?SharedPointer.Wrapper_Shared_Ptr_Get(ptr):ptr]=new WeakReference<T>(reference);}",
					"}}"));
			}
		}
	}
}
