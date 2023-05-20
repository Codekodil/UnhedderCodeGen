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
				var ns = ParserNamespace.Parse(section);
				if (ns != null)
				{
					namespaces.Add(ns);
					section = new StringSection(section, ns.Section.Last + 1, section.Last);
					continue;
				}
				var cl = ParserClass.Parse(section);
				if (cl != null)
				{
					classes.Add(cl);
					section = new StringSection(section, cl.Section.Last + 1, section.Last);
					continue;
				}
			} while ((section = ParserHelper.AdvanceNextSymbol(section)!) != null);

			Namespaces = namespaces.AsReadOnly();
			Classes = classes.AsReadOnly();
		}
	}
}
