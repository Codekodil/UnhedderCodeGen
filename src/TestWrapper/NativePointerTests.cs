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
			pointer.Dispose();
			Assert.AreEqual(false, pointer.Native.HasValue);
		}

		[TestMethod]
		public void InvokeNativeAction()
		{
			using var pointer1 = new PointerChild();
			using var pointer2 = new PointerChild();

			var i = 0;
			pointer2.Event += () => i++;
			pointer1.Event += () =>
			{
				pointer2.Invoke();
				i *= 2;
				pointer2.Invoke();
			};
			pointer1.Invoke();
			pointer1.Invoke();
			pointer1.Invoke();

			Assert.AreEqual(21, i);
		}
	}
}
