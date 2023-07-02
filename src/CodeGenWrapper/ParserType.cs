namespace CodeGenWrapper
{
	public record ParserType(string Name, int LastIndex, bool Span, bool Pointer, bool Shared) : ILastIndex
	{
		private abstract record Type();
		private record SimpleType(string Name) : Type;
		private record PointerType(Type Type) : Type;
		private record TemplateType(string Name, Type Type) : Type;

		public TypeChecker.MatchedType? CheckedType { get; set; }

		public static ParserType? Parse(StringSection section)
		{
			var nested = NestedParse(section);
			if (!nested.HasValue)
				return null;

			var span = false;
			var pointer = false;
			var shared = false;

			var type = nested.Value.Item1;

			if (type is TemplateType spanType && spanType.Name == "std::span")
			{
				span = true;
				type = spanType.Type;
			}
			if (type is TemplateType sharedType && sharedType.Name == "std::shared_ptr")
			{
				shared = true;
				type = sharedType.Type;
			}
			if (type is PointerType pointerType)
			{
				pointer = true;
				type = pointerType.Type;
			}
			if (type is SimpleType simpleType)
				return new ParserType(simpleType.Name, nested.Value.Item2, span, pointer, shared);

			return null;
		}
		private static (Type, int)? NestedParse(StringSection section)
		{
			var name = ParserHelper.CurrentIdentifier(section);
			if (name == null)
				return null;

			var identifiers = new List<string> { name };

			(string, StringSection)? next;
			while ((next = NextIdentifier()).HasValue)
			{
				identifiers.Add(next.Value.Item1);
				section = next.Value.Item2;
			}

			(string, StringSection)? NextIdentifier()
			{
				var nextSection = section;
				for (var i = 0; i < 2; ++i)
				{
					if ((nextSection = ParserHelper.AdvanceNextSymbol(nextSection)!) == null)
						return null;
					if (ParserHelper.CurrentSymbol(nextSection) != ':')
						return null;
				}
				if ((nextSection = ParserHelper.AdvanceNextSymbol(nextSection)!) == null)
					return null;
				var nextName = ParserHelper.CurrentIdentifier(nextSection);
				if (nextName == null)
					return null;
				return (nextName, nextSection);
			}

			name = string.Join("::", identifiers);

			var nextSymbolSection = ParserHelper.AdvanceNextSymbol(section);
			var nextSymbol = nextSymbolSection == null ? null : ParserHelper.CurrentSymbol(nextSymbolSection);
			switch (nextSymbol)
			{
				case '*':
					return (new PointerType(new SimpleType(name)), nextSymbolSection!.First);
				case '<':
					nextSymbolSection = ParserHelper.AdvanceNextSymbol(nextSymbolSection!);
					if (nextSymbolSection == null)
						break;
					var inner = NestedParse(nextSymbolSection);
					if (inner == null)
						break;
					nextSymbolSection = ParserHelper.AdvanceNextSymbol(new StringSection(nextSymbolSection, inner.Value.Item2, nextSymbolSection.Last));
					if (nextSymbolSection == null || ParserHelper.CurrentSymbol(nextSymbolSection) != '>')
						break;
					return (new TemplateType(name, inner.Value.Item1), nextSymbolSection.First);
			}
			return (new SimpleType(name), section.First + identifiers[^1].Length - 1);
		}

		public override string ToString()
		{
			var result = Name;
			if (Pointer) result += "*";
			if (Shared) result += "^";
			if (Span) result += "[]";
			return result;
		}
	}
}
