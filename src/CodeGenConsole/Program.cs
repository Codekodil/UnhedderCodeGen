using CodeGenConfig;
using CodeGenWrapper;

var config = await ConfigLoader.Load(args.Single());
var wrapper = new Wrapper();
wrapper.PathsFromConfig(config);
await wrapper.ParseHeaders();