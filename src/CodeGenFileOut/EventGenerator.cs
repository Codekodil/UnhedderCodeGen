using CodeGenWrapper;

namespace CodeGenFileOut
{
	public static class EventGenerator
	{
		public static IEnumerable<string> GenerateEventCpp(this ParserClass c)
		{
			return c.Events.Select(GenerateSections).Select(s => string.Join(
#if DEBUG
			"\n\t"
#else
			""
#endif
			, s));

			IEnumerable<string> GenerateSections(ParserEvent e)
			{
				//__declspec(dllexport) void __stdcall Wrappy_Surface_SetEvent_Signaling(std::shared_ptr<UnhedderNative::Surface>* self, void(__stdcall* event)(int arg_index,bool arg_errorcatched)){(*self)->Signaling = event;}

				yield return "__declspec(dllexport)";
				yield return "void ";
				yield return $"__stdcall Wrapper_Event_{c.UniqueName()}_{e.Name}";

				var returnType = e.Result.GenerateCpp();
				var parameter = e.Parameters.Select(ParameterGenerator.GenerateCpp).ToList();
				var self = c.SelfNameCpp();

				yield return $"({self.Parameter},";
				yield return returnType.Generated;

				if (parameter.Count == 0)
				{
					yield return "(__stdcall*event)()){";
				}
				else
				{
					yield return "(__stdcall*event)(";
					for (int i = 0; i < parameter.Count; i++)
						yield return parameter[i].Parameter + (i == parameter.Count - 1 ? "" : ",");
					yield return ")){";
				}

				yield return $"{self.Pointer}->{e.Name}=event;}}";
			}
		}
	}
}
