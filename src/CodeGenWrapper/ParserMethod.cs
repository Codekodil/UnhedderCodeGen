namespace CodeGenWrapper
{
	public record ParserMethod(string Name, ParserType Result, List<ParserMethod.Parameter> Parameters, List<string> Flags, int LastIndex)
	{
		public record Parameter(ParserType Type, string Name);

		public static ParserMethod? Parse(StringSection section)
		{
			var type = ParserType.Parse(section);
			if (type == null)
				return null;

			section = new StringSection(section, type.LastIndex, section.Last);

			if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
				return null;

			var identifiers = ParserHelper.ParseIdentifiers(ref section);
			if (!(identifiers?.Count > 0))
				return null;

			var name = identifiers[^1];
			identifiers.RemoveAt(identifiers.Count - 1);

			var parameters = new List<Parameter>();

			if (!ParserHelper.RequireAndAdvance('(', ref section!))
				return null;

			if (ParserHelper.CurrentSymbol(section) == ')')
			{
				if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
					return null;
			}
			else
			{
				char? seperator;
				do
				{
					var parameterType = ParserType.Parse(section);
					if (parameterType == null)
						return null;

					section = new StringSection(section, parameterType.LastIndex, section.Last);

					if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
						return null;

					var parameterName = ParserHelper.CurrentIdentifier(section);
					if (parameterName == null)
						return null;

					parameters.Add(new Parameter(parameterType, parameterName));

					if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
						return null;

					seperator = ParserHelper.CurrentSymbol(section);

					if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
						return null;
				}
				while (seperator == ',');
				if (seperator != ')')
					return null;
			}

			if (ParserHelper.CurrentSymbol(section) != ';')
				return null;

			return new ParserMethod(name, type, parameters, identifiers, section.First);
		}
	}
}
