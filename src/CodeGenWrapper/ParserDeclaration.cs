namespace CodeGenWrapper
{
	public class ParserDeclaration
	{
		public IReadOnlyList<ParserNamespace> Namespaces { get; }
		public IReadOnlyList<ParserClass> Classes { get; }
		public ParserDeclaration(StringSection section)
		{
			var namespaces = new List<ParserNamespace>();
			var classes = new List<ParserClass>();
			do
			{
				var identifier = ParserHelper.CurrentIdentifier(section);
				if (identifier == "namespace")
				{
					var ns = ParserNamespace.Parse(section.Shrink(identifier.Length + 1, 0));
					if (ns != null)
					{
						namespaces.Add(ns);
						section = new StringSection(section, ns.Section.Last + 1, section.Last);
					}
				}
				else if (identifier == "class")
				{
					var cl = ParserClass.Parse(section.Shrink(identifier.Length + 1, 0));
					if (cl != null)
					{
						classes.Add(cl);
						section = new StringSection(section, cl.Section.Last + 1, section.Last);
					}
				}
			} while ((section = ParserHelper.AdvanceNextSymbol(section)!) != null);

			Namespaces = namespaces.AsReadOnly();
			Classes = classes.AsReadOnly();
		}
	}
}
