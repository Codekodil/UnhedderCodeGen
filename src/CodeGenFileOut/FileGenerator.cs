namespace CodeGenFileOut
{
	public record FileGenerator(string Path)
	{
		private string _content = "//Generated with https://github.com/Codekodil/UnhedderCodeGen\n";

		public void WriteLine(object obj) =>
			Write(obj.ToString() + "\n");
		public void Write(object obj) =>
			_content += obj.ToString();

		public async Task Emplace()
		{
			if (File.Exists(Path))
			{
				var content = await File.ReadAllTextAsync(Path);
				if (content == _content)
					return;
			}
			await File.WriteAllTextAsync(Path, _content);
		}
	}
}
