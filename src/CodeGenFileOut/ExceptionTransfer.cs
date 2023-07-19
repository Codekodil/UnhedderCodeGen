namespace CodeGenFileOut
{
	public static class ExceptionTransfer
	{
		public const string ThrowNullReference = @$"throw std::exception(""{nameof(NullReferenceException)}"");";
		public const string TestSelf = $"if(!self){ThrowNullReference}";
	}
}
