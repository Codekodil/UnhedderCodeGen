namespace CodeGenWrapper
{
	public class StringSection
	{
		private readonly char[] _chars;
		public IReadOnlyList<char> Chars => Array.AsReadOnly(_chars);
		public int First { get; }
		public int Last { get; }
		public int Length => Last - First + 1;

		public char this[int index] => _chars[index];
		public string this[Range range]
		{
			get
			{
				var start = range.Start.IsFromEnd ? Last - range.Start.Value + 1 : First + range.Start.Value;
				var end = range.End.IsFromEnd ? Last - range.End.Value : First + range.End.Value - 1;
				start = Math.Min(Last + 1, Math.Max(First, start));
				end = Math.Min(Last, Math.Max(start - 1, end));
				return new string(_chars, start, end - start + 1);
			}
		}

		public StringSection(string chars)
		{
			_chars = chars.ToCharArray();
			First = 0;
			Last = _chars.Length - 1;
		}
		public StringSection(StringSection section, int first, int last)
		{
			_chars = section._chars;
			First = first;
			Last = last;
		}
		public StringSection Shrink(int shrinkFront, int shrinkBack)
		{
			var first = Math.Max(0, Math.Min(_chars.Length - 1, First + shrinkFront));
			return new StringSection(this, first, Math.Max(first - 1, Math.Min(_chars.Length - 1, Last - shrinkBack)));
		}

		public string ToStringValue => ToString();
		public override string ToString() => this[..];
	}
}
