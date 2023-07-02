using System.Collections;

namespace CodeGenWrapper
{
	public class ParserDeclaration : IEnumerable<ParserClass>
	{
		public IReadOnlyList<ParserNamespace> Namespaces { get; }
		public IReadOnlyList<ParserClass> Classes { get; }
		public ParserDeclaration(StringSection section) : this(section, new List<string>()) { }
		public ParserDeclaration(StringSection section, List<string> namespaces)
		{
			var parsedNamespaces = new List<ParserNamespace>();
			var classes = new List<ParserClass>();
			do
			{
				var ns = ParserNamespace.Parse(section, namespaces);
				if (ns != null)
				{
					parsedNamespaces.Add(ns);
					section = new StringSection(section, ns.Section.Last + 1, section.Last);
					continue;
				}
				var cl = ParserClass.Parse(section, namespaces);
				if (cl != null)
				{
					classes.Add(cl);
					section = new StringSection(section, cl.Section.Last + 1, section.Last);
					continue;
				}
			} while ((section = ParserHelper.AdvanceNextSymbol(section)!) != null);

			Namespaces = parsedNamespaces.AsReadOnly();
			Classes = classes.AsReadOnly();
		}

		public void TypeCheck(TypeChecker typeChecker)
		{
			foreach (var c in this)
				c.TypeCheck(typeChecker);
			foreach (var ns in Namespaces)
				ns.Declarations.TypeCheck(typeChecker);
		}

		public IEnumerator<ParserClass> GetEnumerator()
		{
			IEnumerable<ParserClass> result = Classes;
			foreach (var ns in Namespaces)
				result = result.Concat(ns.Declarations);
			return result.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
