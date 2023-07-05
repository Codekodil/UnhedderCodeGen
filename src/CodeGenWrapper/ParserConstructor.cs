namespace CodeGenWrapper
{
	public record ParserConstructor(IReadOnlyList<ParserParameter> Parameters, bool Ignore, int LastIndex)
	{
		public static ParserConstructor? Parse(string className, StringSection section)
		{
			if (!(
				ParserHelper.GetIdentifiersAndAdvance(out var identifiers, ref section!) &&
				identifiers.Count > 0 &&
				identifiers[^1] == className &&
				ParserHelper.GetAndAdvance(ParserParameter.Parse, out var parameters, ref section!) &&
				ParserHelper.CurrentSymbol(section) == ';'))
				return null;

			identifiers.RemoveAt(identifiers.Count - 1);

			return new ParserConstructor(parameters.Parameters, identifiers.Contains(Flags.Ignore), section.First);
		}

		public override string ToString() =>
			$"new ({string.Join(", ", Parameters.Select(p => $"{p.Type} {p.Name}"))})";
	}
}
