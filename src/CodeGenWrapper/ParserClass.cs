﻿using System.Diagnostics.CodeAnalysis;

namespace CodeGenWrapper
{
	public record ParserClass(string Name, StringSection Section, List<ParserMethod> Methods)
	{
		public static ParserClass? Parse(StringSection section)
		{
			var identifiers = new List<string>();
			while (AtIdentifier())
			{
				if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
					return null;
			}
			bool AtIdentifier()
			{
				var identifier = ParserHelper.CurrentIdentifier(section);
				if (identifier == null)
					return false;
				identifiers.Add(identifier);
				return true;
			}
			if (identifiers.Count == 0)
				return null;

			var block = ParserHelper.CurrentCurlyBlock(section);
			if (block == null)
				return null;

			ParseMembers(block, out var methods);

			return new ParserClass(identifiers[identifiers.Count - 1], block, methods);
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
						section = new StringSection(section, method.EndIndex, section.Last);
						continue;
					}
				}

				section = ParserHelper.AdvanceNextSymbol(section)!;
			}
		}
	}
}
