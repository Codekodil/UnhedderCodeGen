using CodeGenConfig;
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