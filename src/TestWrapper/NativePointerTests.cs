using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class NativePointerTests
	{
		[TestMethod]
		public void CreatePointer()
		{
			using var pointer = new PointerChild();
			Assert.AreEqual(true, pointer.Native.HasValue);
			Assert.AreNotEqual(IntPtr.Zero, pointer.Native);
			pointer.Invoke();
			pointer.Dispose();
			Assert.AreEqual(false, pointer.Native.HasValue);
		}
	}
}
