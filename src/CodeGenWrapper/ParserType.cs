namespace CodeGenWrapper
{
	public record ParserType(string Name, int LastIndex)
	{
		public static ParserType? Parse(StringSection section)
		{
			var name = ParserHelper.CurrentIdentifier(section);
			if (name == "void")
				return new ParserType(name, section.First + name.Length - 1);

			return null;
		}
	}
}
