using System.Diagnostics.CodeAnalysis;

namespace CodeGenWrapper
{
	public record ParserClass(string Name, bool Abstract, StringSection Section, List<string> Flags, List<ParserMethod> Methods)
	{
		public static ParserClass? Parse(StringSection section)
		{
			if (!(
				ParserHelper.RequireAndAdvance("class", ref section!) &&
				ParserHelper.GetIdentifiersAndAdvance(out var identifiers, ref section!) &&
				identifiers.Count > 0))
				return null;

			var block = ParserHelper.CurrentCurlyBlock(section);
			if (block == null)
				return null;

			ParseMembers(block, out var methods);

			var isAbstract = identifiers[^1] == "abstract";
			if (isAbstract)
			{
				identifiers.RemoveAt(identifiers.Count - 1);
				if (identifiers.Count == 0)
					return null;
			}
			var name = identifiers[^1];
			identifiers.RemoveAt(identifiers.Count - 1);
			return new ParserClass(name, isAbstract, block, identifiers, methods);
		}

		private static void ParseMembers(StringSection section, out List<ParserMethod> methods)
		{
			methods = new List<ParserMethod>();
			var isPublic = false;
			while (section != null)
			{
				var current = ParserHelper.CurrentIdentifier(section);

				bool IsVisibility(string modifier, [MaybeNullWhenAttribute(false)] out StringSection advancedSection)
				{
					advancedSection = section.Shrink(modifier.Length + 1, 0);
					return current == modifier && section.Length >= modifier.Length + 1 && section[section.First + modifier.Length] == ':';
				}

				{
					if (IsVisibility("public", out var s))
					{ isPublic = true; section = s; continue; }
				}
				{
					if (IsVisibility("private", out var s))
					{ isPublic = false; section = s; continue; }
				}
				{
					if (IsVisibility("protected", out var s))
					{ isPublic = false; section = s; continue; }
				}


				if (isPublic)
				{
					var method = ParserMethod.Parse(section);
					if (method != null)
					{
						methods.Add(method);
						section = ParserHelper.AdvanceNextSymbol(new StringSection(section, method.LastIndex, section.Last))!;
						continue;
					}
				}

				section = ParserHelper.AdvanceNextSymbol(section)!;
			}
		}
	}
}
