namespace CodeGenConsole
{
	public class Config
	{
		public class Module
		{
			public string Path { get; set; } = "./";
			public string[] Headers { get; set; } = new string[0];
			public string LibPath { get; set; } = "./";
		}
		public Module[] Modules { get; set; } = new[] { new Module() };
	}
}
