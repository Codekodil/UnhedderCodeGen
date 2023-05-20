namespace CodeGenWrapper
{
	public record ParserNamespace(string Name, StringSection Section, ParserDeclaration Declarations)
	{
		public static ParserNamespace? Parse(StringSection section)
		{
			if (!ParserHelper.RequireAndAdvance("namespace", ref section!))
				return null;

			var name = ParserHelper.CurrentIdentifier(section);
			if (name == null)
				return null;
			var next = ParserHelper.AdvanceNextSymbol(section);
			if (next == null)
				return null;
			var block = ParserHelper.CurrentCurlyBlock(next);

			return block == null ? null : new ParserNamespace(name, block, new ParserDeclaration(block));
		}
	}
}
