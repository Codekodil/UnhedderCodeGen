using NativeExample.Example;

namespace WrapperTests
{
	[TestClass]
	public class FundamentalTests
	{
		[TestMethod]
		public void BasicStorageCreation()
		{
			using var t = new BasicStorage(10);
			Assert.AreEqual(10, t.Number);
			Assert.AreEqual(20, t.Multiply(2));
		}
	}
}