namespace TestWrapper
{
	[TestClass]
	public class ReflectionTests
	{
		[TestMethod]
		public void NoWrapper()
		{
			Assert.IsNull(GetType().Assembly.GetType("DontWrap"));
		}
	}
}
