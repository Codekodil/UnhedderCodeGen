using System.Diagnostics.CodeAnalysis;

namespace CodeGenWrapper
{
	public static class ParserHelper
	{
		public static string? CurrentIdentifier(StringSection section)
		{
			if (section.Length <= 0)
				return null;

			if (!char.IsLetter(section[section.First]))
				return null;

			string result = "";
			var i = section.First;
			do
			{
				result += section[i];
				i++;
			} while (i <= section.Last && char.IsLetterOrDigit(section[i]));
			return result;
		}

		public static char? CurrentSymbol(StringSection section)
		{
			if (section.Length <= 0)
				return null;

			var symbol = section[section.First];
			return char.IsLetterOrDigit(symbol) ? null : symbol;
		}

		public static StringSection? AdvanceNextSymbol(StringSection section)
		{
			if (section.Length <= 0)
				return null;

			var i = section.First;

			if (char.IsLetterOrDigit(section[i]))
				do i++; while (i <= section.Last && char.IsLetterOrDigit(section[i]));
			else if (!char.IsWhiteSpace(section[i]))
				i++;
			while (i <= section.Last && char.IsWhiteSpace(section[i])) i++;

			return i <= section.Last ? new StringSection(section, i, section.Last) : null;
		}

		public static StringSection? CurrentCurlyBlock(StringSection section)
		{
			if (section[section.First] != '{')
				return null;
			var beginning = section.First + 1;
			while (char.IsWhiteSpace(section[beginning]))
				beginning++;
			var depth = 1;
			var next = AdvanceNextSymbol(section);
			while (next != null && depth > 0)
			{
				section = next;
				next = AdvanceNextSymbol(next);
				switch (section[section.First])
				{
					case '{': depth++; break;
					case '}': depth--; break;
				}
			}
			return depth > 0 ? null : new StringSection(section, beginning, section.First - 1);
		}

		public static bool RequireAndAdvance(char symbol, [MaybeNullWhen(false)] ref StringSection section)
		{
			if (CurrentSymbol(section) != symbol)
				return false;
			return (section = AdvanceNextSymbol(section)) != null;
		}

		public static bool RequireAndAdvance(string identifier, [MaybeNullWhen(false)] ref StringSection section)
		{
			if (CurrentIdentifier(section) != identifier)
				return false;
			return (section = AdvanceNextSymbol(section)) != null;
		}

		public static bool GetIdentifierAndAdvance([MaybeNullWhen(false)] out string identifier, [MaybeNullWhen(false)] ref StringSection section)
		{
			if ((identifier = CurrentIdentifier(section)) == null)
				return false;
			return (section = AdvanceNextSymbol(section)) != null;
		}

		public static bool GetIdentifiersAndAdvance(out List<string> identifiers, [MaybeNullWhen(false)] ref StringSection section)
		{
			identifiers = new List<string>();

			StringSection? nextSection = section;
			while (GetIdentifierAndAdvance(out var identifier, ref nextSection))
			{
				identifiers.Add(identifier);
				section = nextSection;
			}

			return nextSection != null;
		}

		public static bool GetSymbolAndAdvance(out char symbol, [MaybeNullWhen(false)] ref StringSection section)
		{
			var current = CurrentSymbol(section);
			symbol = current ?? default;
			if (!current.HasValue)
				return false;
			return (section = AdvanceNextSymbol(section)) != null;
		}

		public static bool GetAndAdvance<T>(Func<StringSection, T?> parse, [MaybeNullWhen(false)] out T parsed, [MaybeNullWhen(false)] ref StringSection section) where T : ILastIndex
		{
			if ((parsed = parse(section)) == null)
				return false;
			section = new StringSection(section, parsed.LastIndex, section.Last);
			return (section = AdvanceNextSymbol(section)) != null;
		}
	}
}
