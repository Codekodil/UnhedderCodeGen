namespace CodeGenWrapper
{
	public record ParserClass(string Name, StringSection Section)
	{
		public static ParserClass? Parse(StringSection section)
		{
			var identifiers = new List<string>();
			do
			{
				if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
					return null;
			} while (AtIdentifier());
			bool AtIdentifier()
			{
				var identifier = ParserHelper.CurrentIdentifier(section);
				if (identifier == null)
					return false;
				identifiers.Add(identifier);
				return true;
			}
			if (identifiers.Count == 0)
				return null;

			var block = ParserHelper.CurrentCurlyBlock(section);
			if (block == null)
				return null;

			return new ParserClass(identifiers[identifiers.Count - 1], block);
		}
	}
}
