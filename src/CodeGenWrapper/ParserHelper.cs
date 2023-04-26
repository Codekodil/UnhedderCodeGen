namespace CodeGenWrapper
{
	public static class ParserHelper
	{
		public static string? CurrentIdentifier(StringSection section)
		{
			if (section.Length <= 0)
				return null;

			if (!char.IsLetter(section[section.First]))
				return null;

			string result = "";
			var i = section.First;
			do
			{
				result += section[i];
				i++;
			} while (i <= section.Last && char.IsLetterOrDigit(section[i]));
			return result;
		}

		public static StringSection? AdvanceNextSymbol(StringSection section)
		{
			if (section.Length <= 0)
				return null;

			var i = section.First;

			if (char.IsLetterOrDigit(section[i]))
				do i++; while (i <= section.Last && char.IsLetterOrDigit(section[i]));
			else if (!char.IsWhiteSpace(section[i]))
				i++;
			while (i <= section.Last && char.IsWhiteSpace(section[i])) i++;

			return i <= section.Last ? new StringSection(section, i, section.Last) : null;
		}

		public static StringSection? CurrentCurlyBlock(StringSection section)
		{
			if (section[section.First] != '{')
				return null;
			var beginning = section.First + 1;
			while (char.IsWhiteSpace(section[beginning]))
				beginning++;
			var depth = 1;
			var next = ParserHelper.AdvanceNextSymbol(section);
			while (next != null && depth > 0)
			{
				section = next;
				next = ParserHelper.AdvanceNextSymbol(next);
				switch (section[section.First])
				{
					case '{': depth++; break;
					case '}': depth--; break;
				}
			}
			return depth > 0 ? null : new StringSection(section, beginning, section.First - 1);
		}
	}
}
