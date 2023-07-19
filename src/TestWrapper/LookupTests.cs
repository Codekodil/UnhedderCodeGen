using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class LookupTests
	{
		[TestMethod]
		public void LookupPointer()
		{
			using var pointer = new LookupPointer();
			using var shared = new LookupShared(pointer);

			Assert.AreEqual(pointer, shared.GetPtr());
		}

		[TestMethod]
		public void LookupShared()
		{
			using var shared = new LookupShared();
			using var pointer = new LookupPointer(shared);

			Assert.AreEqual(shared, pointer.GetPtr());
		}
	}
}
