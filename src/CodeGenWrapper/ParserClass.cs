using System.Diagnostics.CodeAnalysis;

namespace CodeGenWrapper
{
	public record ParserClass(string Name, List<string> Namespaces, bool Abstract, StringSection Section, bool Pointer, bool Shared, List<ParserConstructor> Constructors, List<ParserMethod> Methods, List<ParserEvent> Events)
	{
		public static ParserClass? Parse(StringSection section, List<string> namespaces)
		{
			if (!(
				ParserHelper.RequireAndAdvance("class", ref section!) &&
				ParserHelper.GetIdentifiersAndAdvance(out var identifiers, ref section!) &&
				identifiers.Count > 0))
				return null;

			var block = ParserHelper.CurrentCurlyBlock(section);
			if (block == null)
				return null;

			var isAbstract = identifiers[^1] == "abstract";
			if (isAbstract)
			{
				identifiers.RemoveAt(identifiers.Count - 1);
				if (identifiers.Count == 0)
					return null;
			}
			var name = identifiers[^1];
			identifiers.RemoveAt(identifiers.Count - 1);

			ParseMembers(name, block, out var constructors, out var methods, out var events);

			constructors.RemoveAll(c => c.Ignore);
			methods.RemoveAll(m => m.Ignore);
			events.RemoveAll(e => e.Ignore);

			var isShared = identifiers.Contains(Flags.Shared);
			return new ParserClass(name, namespaces, isAbstract, block, !isShared && identifiers.Contains(Flags.Pointer), isShared, constructors, methods, events);
		}

		private static void ParseMembers(string className, StringSection section, out List<ParserConstructor> constructors, out List<ParserMethod> methods, out List<ParserEvent> events)
		{
			constructors = new List<ParserConstructor>();
			methods = new List<ParserMethod>();
			events = new List<ParserEvent>();
			var isPublic = false;
			while (section != null)
			{
				var current = ParserHelper.CurrentIdentifier(section);

				bool IsVisibility(string modifier, [MaybeNullWhen(false)] out StringSection advancedSection)
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
					var constructor = ParserConstructor.Parse(className, section);
					if (constructor != null)
					{
						constructors.Add(constructor);
						section = ParserHelper.AdvanceNextSymbol(new StringSection(section, constructor.LastIndex, section.Last))!;
						continue;
					}
					var method = ParserMethod.Parse(section);
					if (method != null)
					{
						methods.Add(method);
						section = ParserHelper.AdvanceNextSymbol(new StringSection(section, method.LastIndex, section.Last))!;
						continue;
					}
					var @event = ParserEvent.Parse(section);
					if (@event != null)
					{
						events.Add(@event);
						section = ParserHelper.AdvanceNextSymbol(new StringSection(section, @event.LastIndex, section.Last))!;
						continue;
					}
				}

				section = ParserHelper.AdvanceNextSymbol(section)!;
			}
		}

		public void TypeCheck(TypeChecker typeChecker)
		{
			Constructors.RemoveAll(ConstructorInvalid);
			Methods.RemoveAll(MethodInvalid);
			Events.RemoveAll(EventInvalid);

			bool ConstructorInvalid(ParserConstructor constructor) =>
				constructor.Parameters.Any(p => !typeChecker.TypeValid(p.Type, Namespaces, TypeChecker.TypeLocation.ConstructorParameter));

			bool MethodInvalid(ParserMethod method) =>
				method.Parameters.Any(p => !typeChecker.TypeValid(p.Type, Namespaces, TypeChecker.TypeLocation.MethodParameter))
				|| !typeChecker.TypeValid(method.Result, Namespaces, TypeChecker.TypeLocation.MethodResult);

			bool EventInvalid(ParserEvent @event) =>
				@event.Parameters.Any(p => !typeChecker.TypeValid(p.Type, Namespaces, TypeChecker.TypeLocation.EventParameter))
				|| !typeChecker.TypeValid(@event.Result, Namespaces, TypeChecker.TypeLocation.EventResult);
		}

		public override string ToString()
		{
			var result = string.Join("::", Namespaces.Concat(new[] { Name }));
			if (Pointer) result += " " + Flags.Pointer;
			if (Shared) result += " " + Flags.Shared;
			return result;
		}
	}
}
