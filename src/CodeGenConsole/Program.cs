using CodeGenConsole;

var lib = await ConfigLib.NewAsync(args[0]);

await lib.RunConsoleAsync();