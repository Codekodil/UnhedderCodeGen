using CodeGenConfig;
using CodeGenFileOut;
using CodeGenWrapper;

var config = await ConfigLoader.Load(args.Single());
var wrapper = new Wrapper();
wrapper.PathsFromConfig(config);
var declarations = await wrapper.ParseHeaders();
var typeChecker = new TypeChecker(declarations);
foreach (var declaration in declarations)
	declaration.TypeCheck(typeChecker);

foreach (var c in declarations.SelectMany(d => d))
{
	Console.WriteLine(c);
	foreach (var constructor in c.Constructors)
		Console.WriteLine("\t" + constructor);
	foreach (var method in c.Methods)
		Console.WriteLine("\t" + method);
	foreach (var @event in c.Events)
		Console.WriteLine("\t" + @event);
}

var writeHeader = HeaderGenerator.WriteAsync(config);
var writeCpp = CppGenerator.WriteAsync(config, declarations.AsReadOnly());
var writeCs = CsGenerator.WriteAsync(config, declarations.AsReadOnly());

if (!(await writeHeader))
	Console.WriteLine($"Could not generate header file [{config.HppResultPath}]");
if (!(await writeCpp))
	Console.WriteLine($"Could not generate cpp file [{config.CppResultPath}]");
if (!(await writeCs))
	Console.WriteLine($"Could not generate cs file [{config.CsResultPath}][DllImport({config.NativeLibraryName})]");