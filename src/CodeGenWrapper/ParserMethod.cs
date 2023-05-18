namespace CodeGenWrapper
{
	public record ParserMethod(string Name, ParserType Result, List<string> Flags, int EndIndex)
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

			var identifiers = ParserHelper.ParseIdentifiers(ref section);
			if (!(identifiers?.Count > 0))
				return null;

			var name = identifiers[^1];
			identifiers.RemoveAt(identifiers.Count - 1);

			if (!ParserHelper.RequireAndAdvance('(', ref section!))
				return null;
			if (!ParserHelper.RequireAndAdvance(')', ref section!))
				return null;
			
			if (section[section.First] != ';')
				return null;

			return new ParserMethod(name, type, identifiers, section.First + 1);
		}
	}
}
