namespace CodeGenWrapper
{
	public record ParserType(string Name, int LastIndex, bool Span, bool Pointer, bool Shared)
	{
		private static readonly HashSet<string> _baseTypes = new HashSet<string>
		{
			"void",
			"int",
			"float",
			"double",
			"char"
		};

		private static readonly HashSet<string> _stdTypes = new HashSet<string>
		{
			"string",
			"span",
			"shared_ptr"
		};

		private abstract record Type();
		private record SimpleType(string Name) : Type;
		private record PointerType(Type Type) : Type;
		private record TemplateType(string Name, Type Type) : Type;

		public static ParserType? Parse(StringSection section)
		{
			var nested = NestedParse(section);
			if (!nested.HasValue)
				return null;

			var span = false;
			var pointer = false;
			var shared = false;

			var type = nested.Value.Item1;

			if (type is TemplateType spanType && spanType.Name == "span")
			{
				span = true;
				type = spanType.Type;
			}
			if (type is TemplateType sharedType && sharedType.Name == "shared_ptr")
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

			var lookUp = _baseTypes;
			if (name == "std")
			{
				lookUp = _stdTypes;
				for (var i = 0; i < 2; ++i)
				{
					if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
						return null;
					if (ParserHelper.CurrentSymbol(section) != ':')
						return null;
				}
				if ((section = ParserHelper.AdvanceNextSymbol(section)!) == null)
					return null;
				name = ParserHelper.CurrentIdentifier(section);
				if (name == null)
					return null;
			}

			if (!lookUp.Contains(name))
				return null;

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
			return (new SimpleType(name), section.First + name!.Length - 1);
		}
	}
}
