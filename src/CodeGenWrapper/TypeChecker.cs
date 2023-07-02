namespace CodeGenWrapper
{
	public class TypeChecker
	{
		private static readonly Dictionary<string, string> _dataTypes;
		static TypeChecker()
		{
			_dataTypes = new Dictionary<string, string> {
				{ "bool",   "bool" },
				{ "int",    "int" },
				{ "long",   "bool" },
				{ "short",  "short" },
				{ "char",   "byte" }
			};
		}

		public record MatchedType;
		public record MatchedParsed(ParserClass Class) : MatchedType;
		public record MatchedData(string Type) : MatchedType;
		public record MatchedVoid : MatchedType;

		//outer key: name
		//outer key: namespace
		private readonly Dictionary<string, Dictionary<string, ParserClass>> _buckets;

		public TypeChecker(IEnumerable<ParserDeclaration> declarations)
		{
			_buckets = declarations
				.SelectMany(d => d)
				.GroupBy(c => c.Name)
				.ToDictionary(b => b.Key, b => b.
					ToDictionary(c => string.Join("::", c.Namespaces)));
		}

		public enum TypeLocation
		{
			ConstructorParameter,
			MethodParameter,
			MethodResult,
			EventParameter,
			EventResult,
		}

		public bool TypeValid(ParserType type, IReadOnlyList<string> namespaces, TypeLocation location)
		{
			return (type.CheckedType ?? (type.CheckedType = FindMatch())) != null;

			MatchedType? FindMatch()
			{
				if (location == TypeLocation.MethodResult || location == TypeLocation.EventResult)
				{
					if (type.Span)
						return null;

					if (type.Name == "void" && !type.Shared && !type.Pointer)
						return new MatchedVoid();
				}

				if (_dataTypes.ContainsKey(type.Name))
				{
					if (!type.Span && !type.Pointer && !type.Shared)
						return new MatchedData(type.Name);
				}

				var typename = type.Name;
				var typeNamespaces = new List<string>();
				{
					int i;
					while ((i = typename.IndexOf("::")) >= 0)
					{
						typeNamespaces.Add(typename[..i]);
						typename = typename[(i + 2)..];
					}
				}

				if (_buckets.TryGetValue(typename, out var bucket))
				{
					foreach (var ns in PossibleNamespaces())
					{
						if (bucket.TryGetValue(ns, out var c))
						{
							if ((c.Pointer || c.Shared) &&
								c.Pointer == type.Pointer &&
								c.Shared == type.Shared)
								return new MatchedParsed(c);
							break;
						}
					}

					IEnumerable<string> PossibleNamespaces()
					{
						var scopedNsCopy = namespaces.ToList();
						while (scopedNsCopy.Count > 0)
						{
							yield return string.Join("::", scopedNsCopy.Concat(typeNamespaces));
							scopedNsCopy.RemoveAt(scopedNsCopy.Count - 1);
						}
						yield return string.Join("::", typeNamespaces);
					}
				}

				return null;
			}
		}
	}
}
