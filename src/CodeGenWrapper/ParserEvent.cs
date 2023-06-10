namespace CodeGenWrapper
{
	public record ParserEvent(string Name, ParserType Result, List<ParserParameter> Parameters, List<string> Flags, int LastIndex)
	{
		public static ParserEvent? Parse(StringSection section)
		{
			if (!(
				ParserHelper.GetAndAdvance(ParserType.Parse, out var type, ref section!) &&
				ParserHelper.GetIdentifiersAndAdvance(out var identifiers, ref section!) &&
				ParserHelper.RequireAndAdvance('(', ref section!) &&
				ParserHelper.RequireAndAdvance('_', ref section!) &&
				ParserHelper.RequireAndAdvance('_', ref section!) &&
				ParserHelper.RequireAndAdvance("stdcall", ref section!) &&
				ParserHelper.RequireAndAdvance('*', ref section!) &&
				ParserHelper.GetIdentifierAndAdvance(out var name, ref section!) &&
				ParserHelper.RequireAndAdvance(')', ref section!) &&
				ParserHelper.GetAndAdvance(ParserParameter.Parse, out var parameters, ref section!)))
				return null;

			if (!(
				ParserHelper.CurrentSymbol(section) == ';' ||
				ParserHelper.RequireAndAdvance('=', ref section!) &&
				ParserHelper.RequireAndAdvance("nullptr", ref section!) &&
				ParserHelper.CurrentSymbol(section) == ';'))
				return null;

			return new ParserEvent(name, type, parameters.Parameters, identifiers, section.First);
		}
	}
}
