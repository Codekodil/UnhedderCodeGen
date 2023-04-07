using CodeGenConsole;

var config = await Config.LoadAsync(args[0]);

await ConfigLib.RunConsoleAsync(config);