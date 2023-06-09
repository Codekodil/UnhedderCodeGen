namespace CodeGenWrapper
{
	public record ParserNamespace(string Name, StringSection Section, ParserDeclaration Declarations)
	{
		public static ParserNamespace? Parse(StringSection section)
		{
			if (!(
				ParserHelper.RequireAndAdvance("namespace", ref section!) &&
				ParserHelper.GetIdentifierAndAdvance(out var name, ref section!)))
				return null;

			var block = ParserHelper.CurrentCurlyBlock(section);

			return block == null ? null : new ParserNamespace(name, block, new ParserDeclaration(block));
		}
	}
}
