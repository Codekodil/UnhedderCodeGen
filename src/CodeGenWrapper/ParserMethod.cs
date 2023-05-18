namespace CodeGenWrapper
{
	public record ParserMethod(string Name, ParserType Result, int EndIndex)
	{
		public static ParserMethod? Parse(StringSection section)
		{
			var type = ParserType.Parse(section);
			if (type == null)
				return null;

			section = new StringSection(section, type.EndIndex, section.Last);

			if (char.IsWhiteSpace(section[section.First]))
				if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
					return null;

			var name = ParserHelper.CurrentIdentifier(section);
			if (name == null)
				return null;

			if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
				return null;

			if (section[section.First] != '(')
				return null;

			if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
				return null;

			if (section[section.First] != ')')
				return null;

			if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
				return null;

			if (section[section.First] != ';')
				return null;

			return new ParserMethod(name, type, section.First + 1);
		}
	}
}
