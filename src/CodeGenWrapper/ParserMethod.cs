namespace CodeGenWrapper
{
	public record ParserMethod(string Name, ParserType Result, List<ParserParameter> Parameters, List<string> Flags, int LastIndex)
	{
		public static ParserMethod? Parse(StringSection section)
		{
			if (!(
				ParserHelper.GetAndAdvance(ParserType.Parse, out var type, ref section!) &&
				ParserHelper.GetIdentifiersAndAdvance(out var identifiers, ref section!) &&
				identifiers.Count > 0 &&
				ParserHelper.GetAndAdvance(ParserParameter.Parse, out var parameters, ref section!) &&
				ParserHelper.CurrentSymbol(section) == ';'))
				return null;

			var name = identifiers[^1];
			identifiers.RemoveAt(identifiers.Count - 1);

			return new ParserMethod(name, type, parameters.Parameters, identifiers, section.First);
		}
	}
}
