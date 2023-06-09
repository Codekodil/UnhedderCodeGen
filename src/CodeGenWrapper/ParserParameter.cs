namespace CodeGenWrapper
{
	public record ParserParameter(ParserType Type, string Name)
	{
		public record Parsed(List<ParserParameter> Parameters, int LastIndex) : ILastIndex;
		public static Parsed? Parse(StringSection section)
		{
			if (!ParserHelper.RequireAndAdvance('(', ref section!))
				return null;

			if (ParserHelper.CurrentSymbol(section) == ')')
				return new Parsed(new List<ParserParameter>(), section.First);

			var parameters = new List<ParserParameter>();
			StringSection? nextSection = section;
			do
			{
				if ((section = nextSection!) == null)
					return null;

				if (!(ParserHelper.GetAndAdvance(ParserType.Parse, out var parameterType, ref section!) &&
					ParserHelper.GetIdentifierAndAdvance(out var parameterName, ref section!)))
					return null;

				parameters.Add(new ParserParameter(parameterType, parameterName));

				nextSection = ParserHelper.AdvanceNextSymbol(section);
			}
			while (ParserHelper.CurrentSymbol(section) == ',');
			if (ParserHelper.CurrentSymbol(section) != ')')
				return null;

			return new Parsed(parameters, section.First);
		}
	}
}
