namespace CodeGenWrapper
{
	public record ParserType(string Name, int EndIndex)
	{
		public static ParserType? Parse(StringSection section)
		{
			var name = ParserHelper.CurrentIdentifier(section);
			if (name == "void")
				return new ParserType(name, section.First + name.Length);

			return null;
		}
	}
}
