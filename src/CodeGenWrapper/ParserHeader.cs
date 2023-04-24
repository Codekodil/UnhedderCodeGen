using System.Text;

namespace CodeGenWrapper
{
	public class ParserHeader
	{
		public StringSection.BaseString FilteredFile { get; private set; } = new StringSection.BaseString("");

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


			return new ParserHeader { FilteredFile = new StringSection.BaseString(continiusFilter.ToString()) };
		}
	}
}
