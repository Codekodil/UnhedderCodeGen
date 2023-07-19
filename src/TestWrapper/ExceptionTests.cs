using TestNative;
using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class ExceptionTests
	{
		[TestMethod]
		public void ConstructorThrow()
		{
			Assert.ThrowsException<NativeException>(() => new ExceptionObject("test"), "test");
		}

		[TestMethod]
		public void MethodThrow()
		{
			using var exceptionObject = new ExceptionObject();

			Assert.ThrowsException<NativeException>(() => exceptionObject.Throw("test"), "test");
		}

		[TestMethod]
		public void MethodThrowArgument()
		{
			using var exceptionObject = new ExceptionObject();

			Assert.ThrowsException<ArgumentException>(() => exceptionObject.ThrowArgument());
		}
	}
}
