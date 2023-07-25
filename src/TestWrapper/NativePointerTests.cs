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
			Assert.IsTrue(pointer.Native.HasValue);
			Assert.AreNotEqual(IntPtr.Zero, pointer.Native);
			pointer.Dispose();
			Assert.IsFalse(pointer.Native.HasValue);
		}

		[TestMethod]
		public void StringParameter()
		{
			using var pointer = new PointerChild();

			Assert.AreEqual(630, pointer.SumCharacters("test 123"));
		}

		[TestMethod]
		public void SpanParameter()
		{
			using var pointer = new PointerChild();

			var numbers = new[] { 1, 2, -1, 100 };
			var scale = 3;
			var scaled = numbers.ToArray();

			pointer.ScaleSpan(scaled, scale);

			for (int i = 0; i < numbers.Length; i++)
				Assert.AreEqual(numbers[i] * scale, scaled[i]);
		}
	}
}
