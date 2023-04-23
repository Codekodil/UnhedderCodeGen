using CodeGenConfig;
using CodeGenWrapper;

var config = await ConfigLoader.Load("../../../testConfig.json");
var wrapper = new Wrapper();
wrapper.PathsFromConfig(config);
Console.WriteLine("test");