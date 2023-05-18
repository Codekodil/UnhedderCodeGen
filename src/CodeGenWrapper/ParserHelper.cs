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

		public static List<string>? ParseIdentifiers(ref StringSection section)
		{
			var identifiers = new List<string>();
			while (AtIdentifier(ref section))
			{
				if ((section = AdvanceNextSymbol(section)!) == null)
					return null;
			}
			bool AtIdentifier(ref StringSection section)
			{
				var identifier = CurrentIdentifier(section);
				if (identifier == null)
					return false;
				identifiers.Add(identifier);
				return true;
			}
			return identifiers;
		}

		public static bool RequireAndAdvance(char Symbol, [MaybeNullWhen(false)] ref StringSection section)
		{
			if (section.Length <= 0 || section[section.First] != Symbol)
				return false;
			return (section = AdvanceNextSymbol(section)!) != null;
		}

		public static bool RequireAndAdvance(string identifier, [MaybeNullWhen(false)] ref StringSection section)
		{
			if (CurrentIdentifier(section) != identifier)
				return false;
			return (section = AdvanceNextSymbol(section)!) != null;
		}
	}
}
