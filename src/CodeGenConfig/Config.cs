namespace CodeGenConfig
{
	public class Config
	{
		public string? Pch { get; set; }
		public string[] HeaderDirectories { get; set; } = new string[0];
		public string? CppResultPath { get; set; }
		public string? HppResultPath { get; set; }
		public string? CsResultPath { get; set; }
		public string? NativeLibraryName { get; set; }
	}
}
