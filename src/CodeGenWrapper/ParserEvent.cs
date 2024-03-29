﻿namespace CodeGenWrapper
{
	public record ParserEvent(string Name, ParserType Result, IReadOnlyList<ParserParameter> Parameters, bool Ignore, int LastIndex)
	{
		public static ParserEvent? Parse(StringSection section)
		{
			if (!(
				ParserHelper.GetAndAdvance(ParserType.Parse, out var type, ref section!) &&
				ParserHelper.GetIdentifiersAndAdvance(out var identifiers, ref section!) &&
				ParserHelper.RequireAndAdvance('(', ref section!) &&
				ParserHelper.RequireAndAdvance("__stdcall", ref section!) &&
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

			return new ParserEvent(name, type, parameters.Parameters, identifiers.Contains(Flags.Ignore), section.First);
		}

		public override string ToString() =>
			$"{Result} (*{Name})({string.Join(", ", Parameters.Select(p => $"{p.Type} {p.Name}"))})";
	}
}
