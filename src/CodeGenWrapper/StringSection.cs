namespace CodeGenWrapper
{
	public class StringSection
	{
		public record BaseString(string String);

		public BaseString Base { get; }
		public int First { get; }
		public int Last { get; }

		public StringSection(BaseString @base, int first, int last)
		{
			Base = @base;
			First = first;
			Last = last;
		}

		public string ToStringValue => ToString();
		public override string ToString() => Base.String[First..(Last + 1)];
	}
}
