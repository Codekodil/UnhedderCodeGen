using System.Text;

namespace CodeGenWrapper
{
	public record ParserHeader(StringSection FilteredFile)
	{
		public static async Task<ParserHeader> NormalizeHeader(Stream file)
		{
			using var reader = new StreamReader(file);

			var lineFilter = new StringBuilder();

			string line;
			var ifDepth = 0;
			while ((line = (await reader.ReadLineAsync())!) != null)
			{
				if (line.StartsWith("#if"))
					ifDepth++;
				else if (line.StartsWith("#endif"))
					ifDepth--;
				else if (!line.StartsWith("#") && ifDepth == 0)
				{
					var commentIndex = line.IndexOf("//");
					if (commentIndex >= 0)
						lineFilter.Append(line.Substring(0, commentIndex));
					else
						lineFilter.Append(line);
					lineFilter.Append('\n');
				}
			}

			var continiusFilter = new StringBuilder();
			char? previous = null;
			foreach (var c in lineFilter.ToString())
			{
				if ("\n\t\r ".Contains(c))
				{
					if (previous != ' ')
						continiusFilter.Append(previous = ' ');
				}
				else
					continiusFilter.Append(previous = c);
			}
			var section = new StringSection(continiusFilter.ToString());

			if (section.Length == 0)
				return new ParserHeader(section);

			return new ParserHeader(section.Shrink(section.Chars[0] == ' ' ? 1 : 0, section[^1..] == " " ? 1 : 0));
		}
	}
}
