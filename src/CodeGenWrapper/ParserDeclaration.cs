namespace CodeGenWrapper
{
	public class ParserDeclaration
	{
		public IReadOnlyList<ParserNamespace> Namespaces { get; }
		public ParserDeclaration(StringSection section)
		{
			var namespaces = new List<ParserNamespace>();
			do
			{
				var identifier = ParserHelper.CurrentIdentifier(section);
				if (identifier == "namespace")
				{
					var ns = ParserNamespace.Parse(section.Shrink(10, 0));
					if (ns != null)
					{
						namespaces.Add(ns);
						section = new StringSection(section, ns.Section.Last + 1, section.Last);
					}
				}
			} while ((section = ParserHelper.AdvanceNextSymbol(section)!) != null);

			Namespaces = namespaces.AsReadOnly();
		}
	}
}
